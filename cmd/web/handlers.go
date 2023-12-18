package main

import (
	"fmt"
	"net/http"
	"strconv"
)

func home(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("Welcome to the pintxos website"))
}

func contestsList(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("Listing current contests"))
}

func pintxosList(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("Listing pintxos"))
}

func votesList(w http.ResponseWriter, r *http.Request) {
	contest, err := strconv.Atoi(r.URL.Query().Get("contest"))
	if err != nil || contest < 0 {
		http.NotFound(w, r)
		return
	}
	fmt.Fprintf(w, "Listing votes for contest ID %d", contest)
}
