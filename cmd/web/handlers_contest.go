package main

import (
	"errors"
	"fmt"
	"net/http"
	"strconv"
	"time"

	"github.com/julienschmidt/httprouter"
	"pintxos.f3rd3f.com/internal/models"
)

func (app *application) contestsView(w http.ResponseWriter, r *http.Request) {
	params := httprouter.ParamsFromContext(r.Context())

	id, err := strconv.Atoi(params.ByName("id"))
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

	data := app.newTemplateData(r)
	data.Contest = contest

	app.render(w, http.StatusOK, "contest_view.tmpl", data)
}

func (app *application) contestsList(w http.ResponseWriter, r *http.Request) {
	contests, err := app.contests.Latest()
	if err != nil {
		app.serverError(w, err)
		return
	}

	for _, contest := range contests {
		fmt.Fprintf(w, "%v+", contest)
	}
}

func (app *application) contestsCreate(w http.ResponseWriter, r *http.Request) {
	data := app.newTemplateData(r)

	app.render(w, http.StatusOK, "contest_create.tmpl", data)
}

func (app *application) contestsCreatePost(w http.ResponseWriter, r *http.Request) {
	contest_date := time.Now()
	active := true

	id, err := app.contests.Insert(contest_date, active)
	if err != nil {
		app.serverError(w, err)
		return
	}

	http.Redirect(w, r, fmt.Sprintf("/contests/view/%d", id), http.StatusSeeOther)
}
