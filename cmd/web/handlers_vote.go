package main

import (
	"fmt"
	"net/http"
	"strconv"
)

func (app *application) votesList(w http.ResponseWriter, r *http.Request) {
	contest, err := strconv.Atoi(r.URL.Query().Get("contest"))
	if err != nil || contest < 0 {
		app.notFound(w)
		return
	}
	fmt.Fprintf(w, "Listing votes for contest ID %d", contest)
}
