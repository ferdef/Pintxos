package models

import (
	"database/sql"
	"errors"
	"time"
)

type Contest struct {
	ID          int
	ContestDate time.Time
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
	stmt := `SELECT id, contest_date, active, created FROM contest
			 WHERE id = ?`

	c := &Contest{}

	err := m.DB.QueryRow(stmt, id).Scan(&c.ID, &c.ContestDate, &c.Active, &c.Created)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, ErrNoRecord
		} else {
			return nil, err
		}
	}

	return c, nil
}

func (m *ContestModel) Latest() ([]*Contest, error) {
	return nil, nil
}
