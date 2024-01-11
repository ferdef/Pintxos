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

	app.render(w, http.StatusOK, "pintxo_view.tmpl", &templateData{
		Pintxo: pintxo,
	})
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
	w.Write([]byte("Display the form for create a new pintxo..."))
}

func (app *application) pintxosCreatePost(w http.ResponseWriter, r *http.Request) {
	title := "New title"
	descr := "New Description"

	id, err := app.pintxos.Insert(title, descr)
	if err != nil {
		app.serverError(w, err)
		return
	}

	http.Redirect(w, r, fmt.Sprintf("/pintxos/view?%d", id), http.StatusSeeOther)
}
