package main

import "pintxos.f3rd3f.com/internal/models"

type templateData struct {
	Contest  *models.Contest
	Contests []*models.Contest
	Pintxo   *models.Pintxo
	Pintxos  []*models.Pintxo
}
