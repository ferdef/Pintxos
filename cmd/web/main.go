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

	err := http.ListenAndServe(":4001", mux)
	log.Fatal(err)
}
