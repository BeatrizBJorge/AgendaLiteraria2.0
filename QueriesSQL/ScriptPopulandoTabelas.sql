USE db_agendalit

-- Populando tabela usuarios
INSERT INTO usuarios (nome, datanasc, nomeUsuario, email, senha) VALUES
					 ('admin', '1950-12-12', 'adminUser', 'teste@email.com', 'senha123'),
					 ('Bia Jorginho', '2010-12-08', 'jorginho.bia', 'jorginho.bia@email.com', 'senha123');
						
-- Populando tabela listas
INSERT INTO listas (nomeLista) VALUES
					('Já Li'),
					('Estou Lendo'),
					('Quero Ler');

-- Populando tabela Livros
INSERT INTO livros (nome, autor, capa, filtro, controller, action) VALUES
					('A Pequena Lagarta', 'Flávio Colombini', 'imagens/APequenaLagarta.jpg', 'gratuito', 'Livros', 'APequenaLagarta'),
					('A Casa no Mar Cerúleo', 'T. J. Klune', 'imagens/ACasaNoMarCeruleo.PNG', '0', 'Livros', 'ACasaNoMarCeruleo'),
					('Além da Porta Sussurrante', 'T. J. Klune', 'imagens/AlemDaPortaSussurrante.PNG', '0', 'Livros', 'AlemDaPortaSussrante'),
                    ('O Mar sem Estrelas', 'Erin Morgenstern', 'imagens/OMarSemEstrelas.PNG', '0', 'Livros', 'OMarSemEstrelas'),
                    ('O Circo da Noite', 'T. J. Klune', 'imagens/Capas/OCircoDaNoite.PNG', '0', 'Livros', 'OCircoDaNoite'),
                    ('Em Algum Lugar nas Estrelas', 'Clare Vanderpool', 'imagens/EmAlgumLugarNasEstrelas.png', '0', 'Livros', 'EmAlgumLugarNasEstrelas'),
                    ('Minha Vida Fora dos Trilhos', 'Clare Vanderpool', 'imagens/MinhaVidaForaDosTrilhos.png', '0', 'Livros', 'MinhaVidaForaDosTrilhos'),
                    ('Coraline', 'Neil Gaiman', 'imagens/Coraline.png', '0', 'Livros', 'Coraline'),
                    ('Leve-me com Você', 'Catherine Ryan Hyde', 'imagens/LeveMeComVoce.png', '0', 'Livros', 'LeveMeComVoce'),
                    ('A Longa Viagem a um Pequeno Planeta Hostil', 'Becky Chambers', 'imagens/ALongaViagem.png', '0', 'Livros', 'AViagemPlanetaHostil'),
                    ('Eragon', 'Christopher Paolini', 'imagens/Eragon.png', '0', 'Livros', 'Eragon'),
                    ('Eldest', 'Christopher Paolini', 'imagens/Eldest.png', '0', 'Livros', 'Eldest'),
                    ('O Hobbit', 'J. R. R. Tolkien', 'imagens/OHobbit.png', '0', 'Livros', 'Hobbit'),
                    ('O Senhor dos Anéis: A Sociedade do Anel', 'J. R. R. Tolkien', 'imagens/SenhorDosAneis.png', '0', 'Livros', 'SenhorDosAneis_SociedadeAnel'),
                    ('O Jardim Secreto', 'Frances Hodgson Burnett', 'imagens/JardimSecreto.png', '0', 'Livros', 'JardimSecreto'),
                    ('A Guerra que Salvou Minha Vida', 'Kimberly Brubaker Bradley', 'imagens/GuerraQueSalvouMinhaVida.png', '0', 'Livros', 'GuerraQueSalvouMinhaVida'),
                    ('O Sol Também é uma Estrela', 'Nicola Yoon', 'imagens/OSolTambemEUmaEstrela.png', '0', 'Livros', 'SolTambemEUmaEstrela'),
                    ('Os Dois Morrem no Final', 'Adam Silvera', 'imagens/OsDoisMorremNoFinal.png', '0', 'Livros', 'OsDoisMorremNoFinal'),
                    ('O Primeiro a Morrer no Final', 'Adam Silvera', 'imagens/OPrimeiroAMorrerNoFinal.png', '0', 'Livros', 'PrimeiroAMorrerNoFinal'),
                    ('Toda Luz que Não Podemos Ver', 'Anthony Doerr', 'imagens/TodaLuzQueNaoPodemosVer.png', '0', 'Livros', 'TodaLuzQueNaoPodemosVer'),
                    ('O Silêncio da Casa Fria', 'Laura Purcell', 'imagens/Capas/SilencioDaCasaFria.png', '0', 'Livros', 'SilencioDaCasaFria'),
                    ('A Vida Invisível de Addie LaRue', 'V. E. Schwab', 'imagens/VidaInvisivelAddieLaRue.png', '0', 'Livros', 'VidaInvisivelAddieLaRue'),
                    ('Vilão', 'V. E. Schwab', 'imagens/Vilao.png', '0', 'Livros', 'Vilao'),
                    ('O Lar da Srta. Peregrine para Crianças Peculiares', 'Ransom Riggs', 'imagens/CriancasPeculiares.png', '0', 'Livros', 'CriancasPeculiares'),
                    ('A Ilusão do Tempo', 'Andri Snaer Magnason', 'imagens/IlusaoDoTempo.png', '0', 'Livros', 'IlusaoDoTempo'),
                    ('Piranesi', 'Susanna Clarke', 'imagens/Piranesi.png', '0', 'Livros', 'Piranesi'),
                    ('Cinco Mulheres', 'Machado de Assis', 'imagens/CincoMulheres.jpg', 'gratuito', 'Livros', 'CincoMulheres'),
                    ('O Amanhã não está à Venda', 'Ailton Krenak', 'imagens/OAmanhaNaoEstaVenda.jpg', 'gratuito', 'Livros', 'OAmanhaNaoEstaVenda'),
                    ('Os Miseráveis', 'Aljâhiz', 'imagens/OsMiseraveis.jpg', 'gratuito', 'Livros', 'OsMiseraveis'),
                    ('Plantas Medicinais', 'Maria Zélia de Almeida', 'imagens/PlantasMedicinais.jpg', 'gratuito', 'Livros', 'PlantasMedicinais'),
                    ('Psicologia Social e Pessoalidade', 'Mary Jane P. Spink', 'imagens/PsicologiaSocial.jpg', 'gratuito', 'Livros', 'PsicologiaSocial'),
                    ('Sempre foi Você (A agência)', 'Elizabeth Grey', 'imagens/SempreFoiVoce.jpg', 'gratuito', 'Livros', 'SempreFoiVoce'),
                    ('As Viagens de Gulliver', 'Jonathan Swift', 'imagens/ViagensDeGulliver.jpg', 'gratuito', 'Livros', 'ViagensDeGulliver');

-- Populando tabela lista_usuario					
INSERT INTO lista_usuario (idUsuario, idLivro, idLista) VALUES
							(1, 5, 3),  -- admim adicionou O circo da noite em Quero Ler
							(2, 14, 2), -- jorginho adicionou O Senhor dos Anéis: A Sociedade do Anel em Estou Lendo
							(2, 23, 1), -- jorginho adicionou Vilão em Ja Li
							(2, 7, 3),  -- jorginho adicionou Minha Vida Fora dos Trilhos em Quero ler
							(2, 12, 2); -- jorginho adicionou Eldest em Estou lendo