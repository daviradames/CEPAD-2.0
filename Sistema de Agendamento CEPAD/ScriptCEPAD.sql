Create database CEPAD_III
use CEPAD_III
use master
drop database CEPAD_III

CREATE TABLE Tipo_Atendimento (
ID_TA Int identity (1,1) PRIMARY KEY,
Consulta char(1),
Castração char(1)
) 

CREATE TABLE porte (
ID_Porte Int identity (1,1) PRIMARY KEY,
Nome_Porte varchar(20),
Pequeno char(1),
Medio char(1),
Grande char(1)
)
insert into porte values ('pequeno', 'p', 'm', 'g')
insert into porte values ('médio', 'p', 'm', 'g')
insert into porte values ('grande', 'p', 'm', 'g')

CREATE TABLE Tipo (
ID_Tipo Int identity (1,1) PRIMARY KEY,
Nome_Tipo_Animal varchar (50)
)
insert into Tipo values ('Cachorro')
insert into Tipo values ('Gato')

CREATE TABLE Disp_Atend (
DT_Inicio date,
DT_Fim date,
NT_Atend_Ofer Int,
Num_Atend_Agendado Int,
ID_TA Int,
ID_Porte Int,
ID_Tipo Int,
PRIMARY KEY(DT_Inicio,DT_Fim),
FOREIGN KEY(ID_TA) REFERENCES Tipo_Atendimento (ID_TA),
FOREIGN KEY(ID_Porte) REFERENCES Porte (ID_Porte),
FOREIGN KEY(ID_Tipo) REFERENCES Tipo (ID_Tipo)
)



CREATE TABLE Cor (
ID_Cor Int identity (1,1)PRIMARY KEY,
Nome_Cor varchar(20)
)
insert into Cor values ('preto')
insert into Cor values ('branco')
insert into Cor values ('malhado')


CREATE TABLE Agenda (
ID_Agenda Int identity (1,1) PRIMARY KEY,
ID_Especie Int,
ID_TA Int,
ID_Porte Int,
ID_Usuario Int,
FOREIGN KEY(ID_TA) REFERENCES Tipo_Atendimento (ID_TA),
FOREIGN KEY(ID_Porte) REFERENCES porte (ID_Porte)
)

CREATE TABLE Usuario (
ID_Usuario Int identity (1,1) PRIMARY KEY,
USuario Varchar(100),
Senha varchar(20)
)

CREATE TABLE Municipe (
ID_Municipe Int identity (1,1) PRIMARY KEY,
Nome varchar(200),
RG Int,
DT_Nasc date,
Tel_Fixo Int,
UF char(2),
Rua varchar(200),
NR_Casa Int,
Bairro varchar(200),
Celular Int,
CPF Varchar(12),
ID_Usuario Int,
Email varchar(200),
Cidade varchar(200),
Complemento varchar(200),
CONSTRAINT UQ_CPF_CLIENTE UNIQUE (CPF),
FOREIGN KEY(ID_Usuario) REFERENCES Usuario (ID_Usuario)
)



CREATE TABLE Especie (
ID_Especie Int identity (1,1) PRIMARY KEY,
Nome_Especie varchar(20)
)

insert into Especie values ('shitzu')
insert into Especie values ('yokshire')

CREATE TABLE Animal (
ID_Animal Int identity (1,1) PRIMARY KEY,
DT_Nasc date,
Nome_Animal varchar(200),
Castrado char(1),
Pelagem char(1),
COD_RGA Int,
Micro_Chip Int,
Sexo char(1),
Especificação varchar(200),
ID_Tipo Int,
ID_Porte Int,
ID_Municipe Int,
ID_Especie Int,
ID_Cor int,
FOREIGN KEY(ID_Tipo) REFERENCES Tipo (ID_Tipo),
FOREIGN KEY(ID_Porte) REFERENCES porte (ID_Porte),
FOREIGN KEY(ID_Municipe) REFERENCES Municipe (ID_Municipe),
FOREIGN KEY(ID_Especie) REFERENCES Especie (ID_Especie),
FOREIGN KEY(ID_Cor) REFERENCES Cor (ID_Cor),

)

CREATE TABLE Agendamento_De_Atend (
Desc_Caso varchar(500),
DT_Inicio date,
DT_Fim date,
ID_Animal Int,
FOREIGN KEY(DT_Fim,DT_Inicio) REFERENCES Disp_Atend (DT_Inicio,DT_Fim),
FOREIGN KEY(ID_Animal) REFERENCES Animal (ID_Animal)
)


CREATE TABLE Administrador (
ID_Adm Int identity (1,1) PRIMARY KEY,
RM Int,
Cargo varchar(20),
ID_Usuario Int,
FOREIGN KEY(ID_Usuario) REFERENCES Usuario (ID_Usuario)
)

CREATE TABLE Item_Agendado (
ID_Protocolo Int identity (1,1) PRIMARY KEY,
ID_Agenda Int,
ID_Animal Int,
FOREIGN KEY(ID_Agenda) REFERENCES Agenda (ID_Agenda),
FOREIGN KEY(ID_Animal) REFERENCES Animal (ID_Animal)
)




ALTER TABLE Disp_Atend ADD FOREIGN KEY(ID_TA) REFERENCES Tipo_Atendimento (ID_TA)
ALTER TABLE Disp_Atend ADD FOREIGN KEY(ID_Porte) REFERENCES porte (ID_Porte)
ALTER TABLE Disp_Atend ADD FOREIGN KEY(ID_Tipo) REFERENCES Tipo (ID_Tipo)
ALTER TABLE Agenda ADD FOREIGN KEY(ID_Especie) REFERENCES Especie (ID_Especie)
ALTER TABLE Agenda ADD FOREIGN KEY(ID_Usuario) REFERENCES Usuario (ID_Usuario)
ALTER TABLE Animal ADD FOREIGN KEY(ID_Especie) REFERENCES Especie (ID_Especie)
