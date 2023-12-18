package main

import (
	"log"
	"net/http"
)

func main() {
	mux := http.NewServeMux()

	// Adding Statics
	fileServer := http.FileServer(http.Dir("./ui/static/"))
	mux.Handle("/static/", http.StripPrefix("/static", fileServer))

	// Adding landing page
	mux.HandleFunc("/", home)

	// Adding remaining pages
	mux.HandleFunc("/contests", contestsList)
	mux.HandleFunc("/pintxos", pintxosList)
	mux.HandleFunc("/votes", votesList)

	log.Print("Starting server on :4001")
	err := http.ListenAndServe(":4001", mux)
	log.Fatal(err)
}
