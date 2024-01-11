package main

import (
	"net/http"

	"github.com/justinas/alice"
)

// The routes() method returns a servemux containing our application routes.
func (app *application) routes() http.Handler {
	mux := http.NewServeMux()

	fileServer := http.FileServer(http.Dir("./ui/static/"))
	mux.Handle("/static/", http.StripPrefix("/static", fileServer))

	mux.HandleFunc("/", app.home)

	mux.HandleFunc("/contests", app.contestsList)
	mux.HandleFunc("/contests/create", app.contestsCreate)
	mux.HandleFunc("/contests/view", app.contestsView)
	mux.HandleFunc("/pintxos", app.pintxosList)
	mux.HandleFunc("/pintxos/create", app.pintxosCreate)
	mux.HandleFunc("/pintxos/view", app.pintxosView)
	mux.HandleFunc("/votes", app.votesList)

	standard := alice.New(app.recoverPanic, app.logRequest, secureHeaders)
	
	return standard.Then(mux)
}
