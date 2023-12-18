package main

import (
	"log"
	"net/http"
)

func main() {
	mux := http.NewServeMux()
	err := http.ListenAndServe(":4001", mux)
	log.Fatal(err)
}
