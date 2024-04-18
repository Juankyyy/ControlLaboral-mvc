-- SQLBook: Code
USE bkcgurx7j7va674tuqsg;
DROP TABLE Employees;
TRUNCATE TABLE Employees;
CREATE TABLE Employees (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(100) NOT NULL,
    LastNames VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE NOT NULL,
    Password VARCHAR(150) UNIQUE NOT NULL,
    DocumentNumber INT UNIQUE NOT NULL,
    Gender VARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    Job VARCHAR (100) NOT NULL
);

INSERT INTO Employees (Names, LastNames, Email, Password, DocumentNumber, Gender, Birthdate, Job)
VALUES ("Juanky", "Herrera", "juanky@gmail.com", "juanky123", "1025643816", "Masculino", "2005-02-03", "Admin"),
("Mateo", "Velez", "mateo@gmail.com", "mateo123", "1020246127", "Masculino", "2002-02-01", "Admin"),
("Wilmar", "Puerta", "wilmar@gmail.com", "wilmar123", "1024823194", "Masculino", "2002-03-06", "Empleado")

INSERT INTO Employees (Names, LastNames, Email, Password, DocumentNumber, Gender, Birthdate, Job)
VALUES ("Juanky", "Herrera", "juanky@gmail.com" "juanky123", "1025643816", "Masculino", "2005-02-03", "Admin")

SELECT * FROM Employees;
SELECT * FROM TimeControls;

DROP TABLE TimeControls;
TRUNCATE TABLE TimeControls;

CREATE TABLE TimeControls (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    DateEntry DATETIME NOT NULL,
    DateExit DATETIME NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Employees(Id)
);
