package main

import (
	"fmt"
	"net/http"
	"strconv"
	"text/template"
)

func (app *application) home(w http.ResponseWriter, r *http.Request) {
	// Get rid of unwanted paths
	if r.URL.Path != "/" {
		http.NotFound(w, r)
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

	err = ts.ExecuteTemplate(w, "base", nil)
	if err != nil {
		app.serverError(w, err)
	}
}

func (app *application) contestsList(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("Listing current contests"))
}

func (app *application) pintxosList(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("Listing pintxos"))
}

func (app *application) votesList(w http.ResponseWriter, r *http.Request) {
	contest, err := strconv.Atoi(r.URL.Query().Get("contest"))
	if err != nil || contest < 0 {
		app.notFound(w)
		return
	}
	fmt.Fprintf(w, "Listing votes for contest ID %d", contest)
}

func (app *application) pintxosCreate(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		w.Header().Set("Allow", http.MethodPost)
		app.clientError(w, http.StatusMethodNotAllowed)
		return
	}
	w.Write([]byte("Create a new pintxo..."))
}
