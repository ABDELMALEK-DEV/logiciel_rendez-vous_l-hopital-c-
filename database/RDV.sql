create database Gestion_rendez_vous
use Gestion_rendez_vous

create table Patient (CodePatient varchar(50) primary key, NomPatient varchar(50), AdressePatient varchar(50), DateNaissance date, SexePatient varchar(50))
create table Medecin (CodeMedecin varchar(50) primary key, NomMedecin varchar(50), TelMedecin varchar(50), DateEmbauche date, SpecialiteMedecin varchar(50))
create table RDV (NumeroRDV int primary key, DateRDV date, HeureRDV varchar(50), CodeMedecin varchar(50) foreign key references Medecin(CodeMedecin), CodePatient varchar(50) foreign key references Patient(CodePatient))