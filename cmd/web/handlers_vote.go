package main

import (
	"fmt"
	"net/http"
	"strconv"

	"github.com/julienschmidt/httprouter"
)

func (app *application) votesList(w http.ResponseWriter, r *http.Request) {
	params := httprouter.ParamsFromContext(r.Context())

	contest, err := strconv.Atoi(params.ByName("contest"))
	if err != nil || contest < 0 {
		app.notFound(w)
		return
	}
	fmt.Fprintf(w, "Listing votes for contest ID %d", contest)
}
