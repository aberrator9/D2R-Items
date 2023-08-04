USE D2R;

INSERT INTO weapons (name, tier, type, sockets, onehanddmg, twohanddmg)
VALUES ('Throwmaster', 'Normal', 'Pizza', 4, 6000, 9001);

SELECT * FROM weapons;

--CREATE TABLE weapons(
--	id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--	name VARCHAR(30) NOT NULL,
--	tier VARCHAR(30) NOT NULL,
--	type VARCHAR(30) NOT NULL,
--	sockets INT NOT NULL,
--	onehanddmg INT NOT NULL,
--	twohanddmg INT NOT NULL,
--);