CREATE TABLE contest (
    id INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    contest_date DATE NOT NULL,
    active BOOLEAN NOT NULL DEFAULT false,
    created DATETIME NOT NULL
);

-- Add an index on the created column.
CREATE INDEX idx_contest_contest_date ON contest(contest_date);