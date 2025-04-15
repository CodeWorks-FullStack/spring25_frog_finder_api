-- Active: 1744731680233@@mysql.codeworksacademy.com@3306@adaptable_shaman_540684_db

CREATE TABLE cats(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name VARCHAR(255),
  likes_cheese BOOLEAN
);

INSERT INTO 
cats (name, likes_cheese)
VALUES ('iron man', 1), ('frankie', 1), ('falcon', 0), ('gopher', 0);

INSERT INTO 
cats (name, likes_cheese)
VALUES ('ramona', 1);

SELECT * FROM cats;

SELECT likes_cheese, name AS rad_name FROM cats;

SELECT * FROM cats WHERE id = 15;

SELECT *  FROM cats WHERE likes_cheese = false;

DELETE FROM cats;

DELETE FROM cats WHERE id = 2;

DROP TABLE cats;