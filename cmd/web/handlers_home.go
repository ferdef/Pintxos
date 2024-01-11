package main

import (
	"net/http"
)

func (app *application) home(w http.ResponseWriter, r *http.Request) {
	contests, err := app.contests.Latest()
	if err != nil {
		app.serverError(w, err)
		return
	}

	pintxos, err := app.pintxos.Latest()
	if err != nil {
		app.serverError(w, err)
		return
	}

	app.render(w, http.StatusOK, "home.tmpl", &templateData{
		Contests: contests,
		Pintxos:  pintxos,
	})
}
