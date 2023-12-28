package main

import (
	"net/http"
	"text/template"
)

func (app *application) home(w http.ResponseWriter, r *http.Request) {
	// Get rid of unwanted paths
	if r.URL.Path != "/" {
		http.NotFound(w, r)
		return
	}

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

	files := []string{
		"./ui/html/base.tmpl",
		"./ui/html/partials/nav.tmpl",
		"./ui/html/pages/home.tmpl",
	}

	ts, err := template.ParseFiles(files...)
	if err != nil {
		app.serverError(w, err)
		return
	}

	data := &templateData{
		Contests: contests,
		Pintxos:  pintxos,
	}

	err = ts.ExecuteTemplate(w, "base", data)
	if err != nil {
		app.serverError(w, err)
	}
}
