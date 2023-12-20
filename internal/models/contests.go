package models

import (
	"database/sql"
	"time"
)

type Contest struct {
	ID          int
	CreatedDate time.Time
	Active      bool
	Created     time.Time
}

type ContestModel struct {
	DB *sql.DB
}

func (m *ContestModel) Insert(active bool) (int, error) {
	return 0, nil
}

func (m *ContestModel) Get(id int) (*Contest, error) {
	return nil, nil
}

func (m *ContestModel) Latest() ([]*Contest, error) {
	return nil, nil
}
