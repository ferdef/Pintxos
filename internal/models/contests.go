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

func (m *ContestModel) Insert(contest_date time.Time, active bool) (int, error) {
	stmt := `INSERT INTO contest (contest_date, active, created)
			 VALUES(?, ?, UTC_TIMESTAMP())`

	result, err := m.DB.Exec(stmt, contest_date, active)
	if err != nil {
		return 0, err
	}

	id, err := result.LastInsertId()
	if err != nil {
		return 0, err
	}

	return int(id), nil
}

func (m *ContestModel) Get(id int) (*Contest, error) {
	return nil, nil
}

func (m *ContestModel) Latest() ([]*Contest, error) {
	return nil, nil
}
