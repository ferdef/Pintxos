package main

import (
	"errors"
	"fmt"
	"net/http"
	"strconv"
	"text/template"

	"pintxos.f3rd3f.com/internal/models"
)

func (app *application) pintxosList(w http.ResponseWriter, r *http.Request) {
	pintxos, err := app.pintxos.Latest()
	if err != nil {
		app.serverError(w, err)
		return
	}

	for _, pintxo := range pintxos {
		fmt.Fprintf(w, "%v+", pintxo)
	}
}

func (app *application) pintxosCreate(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		w.Header().Set("Allow", http.MethodPost)
		app.clientError(w, http.StatusMethodNotAllowed)
		return
	}

	title := "New title"
	descr := "New Description"

	id, err := app.pintxos.Insert(title, descr)
	if err != nil {
		app.serverError(w, err)
		return
	}

	http.Redirect(w, r, fmt.Sprintf("/pintxos/view?id=%d", id), http.StatusSeeOther)
}

func (app *application) pintxosView(w http.ResponseWriter, r *http.Request) {
	id, err := strconv.Atoi(r.URL.Query().Get("id"))
	if err != nil || id < 0 {
		app.notFound(w)
		return
	}

	pintxo, err := app.pintxos.Get(id)
	fmt.Printf("%v", pintxo)
	if err != nil {
		if errors.Is(err, models.ErrNoRecord) {
			app.notFound(w)
		} else {
			app.serverError(w, err)
		}
		return
	}

	files := []string{
		"./ui/html/base.tmpl",
		"./ui/html/partials/nav.tmpl",
		"./ui/html/pages/pintxo_view.tmpl",
	}

	ts, err := template.ParseFiles(files...)
	if err != nil {
		app.serverError(w, err)
		return
	}

	data := &templatePintxoData{
		Pintxo: pintxo,
	}

	err = ts.ExecuteTemplate(w, "base", data)
	if err != nil {
		app.serverError(w, err)
	}
}
