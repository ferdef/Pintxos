package main

import (
	"flag"
	"log"
	"net/http"
)

func main() {
	addr := flag.String("addr", ":4001", "HTTP network address")
	flag.Parse()

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

	log.Printf("Starting server on %s", *addr)
	err := http.ListenAndServe(*addr, mux)
	log.Fatal(err)
}
