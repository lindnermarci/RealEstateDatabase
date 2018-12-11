CREATE TABLE Ingatlan(
    Ing_ID int NOT NULL,
    Cim varchar(70),
    Tipus varchar(20),
    Alapterulet int,
    SzobaDb int,
    CONSTRAINT ingatlan_pk PRIMARY KEY(Ing_ID));

 CREATE TABLE Tulajdonos(
     Tul_ID int NOT NULL,
     Nev varchar(20),
     Cim varchar(70),
     Mobilszam varchar(10),
     Email varchar(40),
     CONSTRAINT tulajdonos_pk PRIMARY KEY(Tul_ID)
     );
     
 CREATE TABLE Ugyfel(
     Ugyfel_ID int NOT NULL,
     Nev varchar(20),
     Cim varchar(70),
     Mobilszam varchar(10),
     Email varchar(40),
     CONSTRAINT ugyfel_pk PRIMARY KEY(Ugyfel_ID)
 );
 
 CREATE TABLE Tulajdonol(
     Tul_ID int NOT NULL,
     Ing_ID int NOT NULL,
     CONSTRAINT ingatlan_fk FOREIGN KEY(Ing_ID) REFERENCES
     Ingatlan(Ing_ID),
     CONSTRAINT tulajdonos_fk FOREIGN KEY(Tul_ID) REFERENCES
     Tulajdonos(Tul_ID),
     CONSTRAINT tulajdonol_pk PRIMARY KEY(Tul_ID,Ing_ID)
 );
 
 

 CREATE TABLE Szerzodes(
     Szerzodes_ID int NOT NULL,
     Ing_ID int NOT NULL,
     Ugyfel_ID int NOT NULL,
     Tipus varchar(20),
     Ar int,
     Datum date,
     CONSTRAINT szerzodes_pk PRIMARY KEY(Szerzodes_ID),
     CONSTRAINT Ingatlan_fk_szerz FOREIGN KEY(Ing_ID) REFERENCES
     Ingatlan(Ing_ID),
     CONSTRAINT ugyfel_fk FOREIGN KEY(Ugyfel_ID) REFERENCES
     Ugyfel(Ugyfel_ID)
); 
     
INSERT INTO Ingatlan VALUES(1,'1322 Budapest Dózsa György út 82.','ház',44,1);
INSERT INTO Ingatlan VALUES(5,'1058 Budapest Rákóczy út 55.','lakás',45,3);
INSERT INTO Ingatlan VALUES(6,'1416 Budapest Eötvös utca 3.','ház',79,3);
INSERT INTO Ingatlan VALUES(7,'1771 Budapest Rózsa utca 32.','üdülő',70,2);
INSERT INTO Ingatlan VALUES(2,'1915 Budapest Deák tér 34.','ház',96,1);
INSERT INTO Ingatlan VALUES(3,'1392 Budapest Andrássy út 66.','gazdasági',99,3);
INSERT INTO Ingatlan VALUES(4,'1249 Budapest Fillér utca 51.','lakás',81,2);
INSERT INTO Ingatlan VALUES(8,'1938 Budapest Lovag utca 28.','üdülő',61,2);
INSERT INTO Ingatlan VALUES(9,'1381 Budapest Lázár utca 38.','gazdasági',80,3);
INSERT INTO Ingatlan VALUES(10,'1110 Budapest Jókai utca 48.','ház',97,3);
INSERT INTO Ingatlan VALUES(11,'1167 Budapest Szent István körút 9.','telek',52,1);
INSERT INTO Ingatlan VALUES(12,'1489 Budapest Erzsébeth körút 69.','gazdasági',42,3);
INSERT INTO Ingatlan VALUES(13,'1347 Budapest Teréz körút 87.','üdülő',46,2);
INSERT INTO Ingatlan VALUES(14,'1297 Budapest Hungária körút 40.','lakás',75,1);

INSERT INTO Tulajdonos VALUES(1,'Kiss Jenő','1915 Budapest Homok utca 34.','061234567','kiss.jeno@yahoo.com');
INSERT INTO Tulajdonos VALUES(2,'Nagy András','1768 Budapest Futó tér 56.','069763928','toleráns@gmail.com');
INSERT INTO Tulajdonos VALUES(3,'Almási Kinga','1484 Budapest Baross utca 78.','061253155','figyelmes@yahoo.com');
INSERT INTO Tulajdonos VALUES(4,'Hotváth Rozi','1984 Budapest Rigó utca 22.','064721284','magabiztos@gmail.com');
INSERT INTO Tulajdonos VALUES(5,'Andrássy Gyula','1807 Budapest Németh utca 4.','064062809','társaságkedvelő@freemail.hu');
INSERT INTO Tulajdonos VALUES(6,'Kis Pista','1881 Budapest Práter utca 34.','066309133','higgadt@freemail.hu');
INSERT INTO Tulajdonos VALUES(7,'Kovács Jutka','1045 Budapest Nap utca 11.','069914173','udvarias@gmail.com');
INSERT INTO Tulajdonos VALUES(8,'Eleven Anna','1283 Budapest Deák tér 34.','064822438','nagyképű@yahoo.com');
INSERT INTO Tulajdonos VALUES(9,'Kövér Kálmán','1750 Budapest József utca 34.','061678672','morcos@yahoo.com');
INSERT INTO Tulajdonos VALUES(10,'Horváth Géza','1816 Budapest Jókai tér 4.','067056318','naív@freemail.hu');
INSERT INTO Tulajdonos VALUES(11,'Jenei Gyula','1033 Budapest Jenő tér 87.','066367769','vitatkozós@yahoo.com');
INSERT INTO Tulajdonos VALUES(12,'Nagy Jutka','1088 Budapest Kisfaludy utca 65.','065055215','fukar@yahoo.com');

INSERT INTO Ugyfel VALUES(1,'Nagy Beáta','1319 Régi utca 11.','063453680','renata@gmail.com');
INSERT INTO Ugyfel VALUES(2,'Nagy Kata','1719 Lovas utca 34.','062143680','szisztok@gmail.com');
INSERT INTO Ugyfel VALUES(3,'Horváth Kata','1904 Endrő utca 34.','063105399','szisztok@yahoo.com');
INSERT INTO Ugyfel VALUES(4,'Almási Márton','1676 Budapest Fecske utca 34.','067460139','businessmail@yahoo.com');
INSERT INTO Ugyfel VALUES(5,'Nagy András','1547 Budapest Mátyás utca 34.','069446056','encimem@yahoo.com');
INSERT INTO Ugyfel VALUES(6,'Almási Kata','1096 Budapest Szamár utca 34.','068270423','encimem@freemail.hu');
INSERT INTO Ugyfel VALUES(7,'Horváth Judit','1774 Budapes Őr utca 34.','061789448','szisztok@freemail.hu');
INSERT INTO Ugyfel VALUES(8,'Nagy Kata','1244 Budapest József utca 34.','062267882','businessmail@freemail.hu');
INSERT INTO Ugyfel VALUES(9,'Almási Márton','1269 Budapest Német utca 34.','066431495','hello@yahoo.com');
INSERT INTO Ugyfel VALUES(10,'Nagy András','1149 Budapest Nap utca 34.','061202145','legalabb@freemail.hu');
INSERT INTO Ugyfel VALUES(11,'Horváth Márton','1493 Budapest Futó utca 34.','064644511','hello@freemail.hu');
INSERT INTO Ugyfel VALUES(12,'Rákóczy Márton','1080 Budapest Práter utca 34.','067000233','szisztok@yahoo.com');

INSERT INTO Tulajdonol VALUES (1,14);
INSERT INTO Tulajdonol VALUES (1,13);
INSERT INTO Tulajdonol VALUES (2,12);
INSERT INTO Tulajdonol VALUES (2,11);
INSERT INTO Tulajdonol VALUES (3,10);
INSERT INTO Tulajdonol VALUES (4,9);
INSERT INTO Tulajdonol VALUES (5,8);
INSERT INTO Tulajdonol VALUES (6,7);
INSERT INTO Tulajdonol VALUES (7,6);
INSERT INTO Tulajdonol VALUES (8,5);
INSERT INTO Tulajdonol VALUES (9,4);
INSERT INTO Tulajdonol VALUES (10,3);
INSERT INTO Tulajdonol VALUES (11,2);
INSERT INTO Tulajdonol VALUES (12,1);

INSERT INTO Szerzodes VALUES (11,13,11,'vetel','36990103','2017-06-27');
INSERT INTO Szerzodes VALUES (12,12,12,'vétel','36990103','2017-06-27');
INSERT INTO Szerzodes VALUES (13,11,8,'vétel','36990103','2017-06-27');
INSERT INTO Szerzodes VALUES (14,10,5,'vétel','36990103','2017-06-27');
INSERT INTO Szerzodes VALUES (1,9,1,'bérlés','150000','2017-09-22');
INSERT INTO Szerzodes VALUES (2,8,2,'vétel','25083656','2017-09-13');
INSERT INTO Szerzodes VALUES (3,7,3,'vétel','19940397','2017-07-19');
INSERT INTO Szerzodes VALUES (4,6,4,'bérlés','200000','2017-08-17');
INSERT INTO Szerzodes VALUES (5,5,5,'vétel','30600766','2017-01-23');
INSERT INTO Szerzodes VALUES (6,4,6,'vétel','41064294','2017-02-28');
INSERT INTO Szerzodes VALUES (7,3,7,'vétel','27859112','2017-09-18');
INSERT INTO Szerzodes VALUES (8,2,8,'vétel','34906618','2017-11-22');
INSERT INTO Szerzodes VALUES (9,1,9,'bérlés','175000','2017-12-1');
INSERT INTO Szerzodes VALUES (10,14,10,'vétel','26638413','2017-5-18');