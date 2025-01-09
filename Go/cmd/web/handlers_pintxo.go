package main

import (
	"errors"
	"fmt"
	"net/http"
	"strconv"

	"github.com/julienschmidt/httprouter"
	"pintxos.f3rd3f.com/internal/models"
)

func (app *application) pintxosView(w http.ResponseWriter, r *http.Request) {
	params := httprouter.ParamsFromContext(r.Context())

	id, err := strconv.Atoi(params.ByName("id"))
	if err != nil || id < 0 {
		app.notFound(w)
		return
	}

	pintxo, err := app.pintxos.Get(id)

	if err != nil {
		if errors.Is(err, models.ErrNoRecord) {
			app.notFound(w)
		} else {
			app.serverError(w, err)
		}
		return
	}

	data := app.newTemplateData(r)
	data.Pintxo = pintxo

	app.render(w, http.StatusOK, "pintxo_view.tmpl", data)
}

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
	data := app.newTemplateData(r)

	app.render(w, http.StatusOK, "pintxo_create.tmpl", data)
}

func (app *application) pintxosCreatePost(w http.ResponseWriter, r *http.Request) {
	err := r.ParseForm()
	if err != nil {
		app.clientError(w, http.StatusBadRequest)
		return
	}

	title := r.PostForm.Get("title")
	descr := r.PostForm.Get("description")

	id, err := app.pintxos.Insert(title, descr)
	if err != nil {
		app.serverError(w, err)
		return
	}

	http.Redirect(w, r, fmt.Sprintf("/pintxos/view/%d", id), http.StatusSeeOther)
}
