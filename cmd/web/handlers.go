package main

import (
	"errors"
	"fmt"
	"net/http"
	"strconv"
	"text/template"
	"time"

	"pintxos.f3rd3f.com/internal/models"
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

func (app *application) contestsCreate(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		w.Header().Set("Allow", http.MethodPost)
		app.clientError(w, http.StatusMethodNotAllowed)
		return
	}

	contest_date := time.Now()
	active := true

	id, err := app.contests.Insert(contest_date, active)
	if err != nil {
		app.serverError(w, err)
		return
	}

	http.Redirect(w, r, fmt.Sprintf("/contests/view?id=%d", id), http.StatusSeeOther)
}

func (app *application) contestsView(w http.ResponseWriter, r *http.Request) {
	id, err := strconv.Atoi(r.URL.Query().Get("id"))
	if err != nil || id < 0 {
		app.notFound(w)
		return
	}

	contest, err := app.contests.Get(id)
	if err != nil {
		if errors.Is(err, models.ErrNoRecord) {
			app.notFound(w)
		} else {
			app.serverError(w, err)
		}
		return
	}

	fmt.Fprintf(w, "%+v", contest)
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
