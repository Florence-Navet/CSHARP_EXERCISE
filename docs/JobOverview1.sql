
CREATE TABLE Filieres
(
  Code VARCHAR(20)  NOT NULL,
  Nom  nvarchar(20) NOT NULL,
  PRIMARY KEY (Code)
);

CREATE TABLE Logiciels
(
  Code        VARCHAR(20) NOT NULL,
  CodeFiliere VARCHAR(20) NOT NULL,
  Nom         VARCHAR(20) NOT NULL,
  PRIMARY KEY (Code)
);

CREATE TABLE Modules
(
  Code               VARCHAR(20) NOT NULL,
  CodeLogiciel       VARCHAR(20) NOT NULL,
  Nom                varchar(20) NOT NULL,
  CodeModuleParent   VARCHAR(20) NOT NULL,
  CodeLogicielParent VARCHAR(20) NOT NULL,
  PRIMARY KEY (Code, CodeLogiciel)
);

CREATE TABLE Releases
(
  Numero        SMALLINT    NOT NULL,
  NumeroVersion real        NOT NULL,
  CodeLogiciel  VARCHAR(20) NOT NULL,
  DatePubli     date        NOT NULL,
  PRIMARY KEY (Numero, NumeroVersion, CodeLogiciel)
);

CREATE TABLE Versions
(
  Numero           real        NOT NULL,
  CodeLogiciel     VARCHAR(20) NOT NULL,
  DateOuverture    DATE        NOT NULL,
  Millesime        SMALLINT    NOT NULL,
  DateSortiePrevue DATE        NOT NULL,
  DateSortieReelle DATE        NOT NULL,
  PRIMARY KEY (Numero, CodeLogiciel)
);

ALTER TABLE Modules
  ADD CONSTRAINT FK_Logiciels_TO_Modules
    FOREIGN KEY (CodeLogiciel)
    REFERENCES Logiciels (Code);

ALTER TABLE Logiciels
  ADD CONSTRAINT FK_Filieres_TO_Logiciels
    FOREIGN KEY (CodeFiliere)
    REFERENCES Filieres (Code);

ALTER TABLE Versions
  ADD CONSTRAINT FK_Logiciels_TO_Versions
    FOREIGN KEY (CodeLogiciel)
    REFERENCES Logiciels (Code);

ALTER TABLE Modules
  ADD CONSTRAINT FK_Modules_TO_Modules
    FOREIGN KEY (CodeModuleParent, CodeLogicielParent)
    REFERENCES Modules (Code, CodeLogiciel);

ALTER TABLE Releases
  ADD CONSTRAINT FK_Versions_TO_Releases
    FOREIGN KEY (NumeroVersion, CodeLogiciel)
    REFERENCES Versions (Numero, CodeLogiciel);
