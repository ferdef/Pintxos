package main

import (
	"path/filepath"
	"text/template"

	"pintxos.f3rd3f.com/internal/models"
)

type templateData struct {
	Contest  *models.Contest
	Contests []*models.Contest
	Pintxo   *models.Pintxo
	Pintxos  []*models.Pintxo
}

func newTemplateCache() (map[string]*template.Template, error) {
	cache := map[string]*template.Template{}

	pages, err := filepath.Glob("./ui/html/pages/*.tmpl")
	if err != nil {
		return nil, err
	}

	for _, page := range pages {
		name := filepath.Base(page)

		files := []string{
			"./ui/html/base.tmpl",
			"./ui/html/partials/nav.tmpl",
			page,
		}

		ts, err := template.ParseFiles(files...)
		if err != nil {
			return nil, err
		}

		cache[name] = ts
	}

	return cache, nil
}
