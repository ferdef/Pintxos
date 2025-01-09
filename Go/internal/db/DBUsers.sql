CREATE USER 'web'@'%';
GRANT SELECT, INSERT, UPDATE, DELETE ON gopintxos.* TO 'web'@'%';
ALTER USER 'web'@'%' IDENTIFIED BY '.WebPassword';