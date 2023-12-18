package main

import (
	"fmt"
	"log"
	"net/http"
	"strconv"
	"text/template"
)

func home(w http.ResponseWriter, r *http.Request) {
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
		log.Print(err.Error())
		http.Error(w, "Internal Server Error", 500)
		return
	}

	err = ts.ExecuteTemplate(w, "base", nil)
	if err != nil {
		log.Print(err.Error())
		http.Error(w, "Internal Server Error", 500)
	}
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
