package main

import (
	"net/http"

	"github.com/julienschmidt/httprouter"
	"github.com/justinas/alice"
)

// The routes() method returns a servemux containing our application routes.
func (app *application) routes() http.Handler {
	router := httprouter.New()

	router.NotFound = http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		app.notFound(w)
	})

	fileServer := http.FileServer(http.Dir("./ui/static/"))
	router.Handler(http.MethodGet, "/static/*filepath", http.StripPrefix("/static", fileServer))

	router.HandlerFunc(http.MethodGet, "/", app.home)

	router.HandlerFunc(http.MethodGet, "/contests", app.contestsList)
	router.HandlerFunc(http.MethodGet, "/contests/view/:id", app.contestsView)
	router.HandlerFunc(http.MethodGet, "/contests/create", app.contestsCreate)
	router.HandlerFunc(http.MethodPost, "/contests/create", app.contestsCreatePost)

	router.HandlerFunc(http.MethodGet, "/pintxos", app.pintxosList)
	router.HandlerFunc(http.MethodGet, "/pintxos/view/:id", app.pintxosView)
	router.HandlerFunc(http.MethodGet, "/pintxos/create", app.pintxosCreate)
	router.HandlerFunc(http.MethodPost, "/pintxos/create", app.pintxosCreatePost)

	router.HandlerFunc(http.MethodGet, "/votes/:contest", app.votesList)

	standard := alice.New(app.recoverPanic, app.logRequest, secureHeaders)

	return standard.Then(router)
}
