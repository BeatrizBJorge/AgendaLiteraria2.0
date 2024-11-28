CREATE DATABASE db_agendalit;
GO

USE db_agendalit;
GO

-- Criação da tabela usuarios
CREATE TABLE usuarios
(
	idUsuario		INT IDENTITY(1,1)		NOT NULL,
	nome			VARCHAR (250) 			NOT NULL,
	datanasc		DATE 					NOT NULL,
	nomeUsuario		VARCHAR (50) UNIQUE 	NOT NULL,
	email			VARCHAR (250) 			NOT NULL,
	senha			VARCHAR (250) 			NOT NULL,
	
	-- REGISTRANDO A CHAVE PRIMARIA PK
	CONSTRAINT PK_usuarios_idUsuario PRIMARY KEY (idUsuario),
	
);
GO

-- Criação da tabela livros
CREATE TABLE livros
(
	idLivro			INT IDENTITY(1,1)		NOT NULL,
	nome			VARCHAR (250) 			NOT NULL,
	autor			VARCHAR (50)  			NOT NULL,
	capa			VARCHAR (250) 			NOT NULL,
	filtro			VARCHAR (10)			NOT NULL,
	controller		VARCHAR (25) 			NOT NULL,
	action          VARCHAR (60)			NOT NULL,
	
	-- REGISTRANDO A CHAVE PRIMARIA PK
	CONSTRAINT PK_livros_idUsuario PRIMARY KEY (idLivro),
);
GO

-- Criação da tabela listas
CREATE TABLE listas
(
	idLista			INT IDENTITY(1,1)		NOT NULL,
	nomeLista		VARCHAR (250) 			NOT NULL,
	
	-- REGISTRANDO A CHAVE PRIMARIA PK
	CONSTRAINT PK_listas_idLista PRIMARY KEY (idLista),
	
);
GO

-- Criação da tabela lista_usuario
CREATE TABLE lista_usuario
(
	idListaUsuario		INT IDENTITY(1,1)	NOT NULL,
	idUsuario 			INT					NOT NULL,
	idLivro				INT					NOT NULL,
	idLista				INT 				NOT NULL,
	
	-- REGISTRANDO A CHAVE PRIMARIA PK
	CONSTRAINT PK_listas_idListaUsuario PRIMARY KEY (idListaUsuario),
	
	-- REGISTRANDO A CHAVE ESTRANGEIRA FK
	CONSTRAINT FK_listas_idUsuario FOREIGN KEY (idUsuario) REFERENCES usuarios (idUsuario),
	CONSTRAINT FK_listas_idLivro FOREIGN KEY (idLivro) REFERENCES livros (idLivro),
	CONSTRAINT FK_listas_idLista FOREIGN KEY (idLista) REFERENCES listas (idLista),
);
GO
