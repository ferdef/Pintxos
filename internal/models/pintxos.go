package models

import (
	"database/sql"
	"errors"
	"time"
)

type Pintxo struct {
	ID      int
	Title   string
	Descr   string
	Created time.Time
}

type PintxoModel struct {
	DB *sql.DB
}

func (m *PintxoModel) Insert(title string, descr string) (int, error) {
	stmt := `INSERT INTO pintxo (title, descr, created)
			 VALUES(?, ?, UTC_TIMESTAMP())`

	result, err := m.DB.Exec(stmt, title, descr)
	if err != nil {
		return 0, err
	}

	id, err := result.LastInsertId()
	if err != nil {
		return 0, err
	}

	return int(id), nil
}

func (m *PintxoModel) Get(id int) (*Pintxo, error) {
	stmt := `SELECT id, title, descr, created FROM pintxo
			 WHERE id = ?`

	p := &Pintxo{}

	err := m.DB.QueryRow(stmt, id).Scan(&p.ID, &p.Title, &p.Descr, &p.Created)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, ErrNoRecord
		} else {
			return nil, err
		}
	}

	return p, nil
}

func (m *PintxoModel) Latest() ([]*Pintxo, error) {
	stmt := `SELECT id, title, descr, created FROM pintxo
			 ORDER BY id DESC LIMIT 10`

	rows, err := m.DB.Query(stmt)
	if err != nil {
		return nil, err
	}

	defer rows.Close()

	pintxos := []*Pintxo{}

	for rows.Next() {
		p := &Pintxo{}

		err = rows.Scan(&p.ID, &p.Title, &p.Descr, &p.Created)
		if err != nil {
			return nil, err
		}

		pintxos = append(pintxos, p)
	}

	if err = rows.Err(); err != nil {
		return nil, err
	}

	return pintxos, nil
}
