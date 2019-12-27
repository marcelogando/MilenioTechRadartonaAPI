# Milênio Bus - RadartonaAPI

## Apresentação

Esse projeto foi idealizado na Radartona, uma maratona de programação que aconteceu nos dias 08, 09 e 10/11/2019 no escritório do MobiLab+, localizado em São Paulo.

A Radartona é uma iniciativa da Prefeitura de São Paulo, por meio das Secretarias de Mobilidade e Transporte e Inovação e Tecnologia, do Mobilab+, da Prodam, da CET, da SPTrans. Tem como parceiros a Iniciativa Bloomberg para Segurança Global no Trânsito e o Banco Mundial e como apoiadores a Vital Strategies e Scipopulis.

O concurso para Solução API tem o seguinte desafio: “Como organizar os dados obtidos por meio de equipamentos de fiscalização eletrônica de trânsito, no município de São Paulo e disponibilizá-los para utilização pela Administração Pública e pela comunidade em geral?”

Nosso projeto visa solucionar o desafio, trazendo visibilidade e estruturação dos dados para utilidade pública. Além da consulta na API com retorno XML/JSON, temos a opção de exportar os resultados obtidos para arquivo CSV.

- Slides 1ª Fase - [Clique aqui](/MilenioRadartonaAPI/Presentation/api.pdf).
- Slides 2ª Fase - [Clique aqui](/MilenioRadartonaAPI/Presentation/Finaaaaaaaaal.pdf).

## Pré-requisitos

* C#
* ASP.Net Core
* Python
* Docker Compose
* PostgreSQL

## Instalação no servidor

Ao instanciar o servidor pela primeira vez, contornar os dados de proxy (caso se aplique) no github e no docker.
O do docker pode ser contornado a partir do Dockerfile em anexo aqui.

Já o github, contornar a proxy assim:
git config --global http.proxy http://user:senha@10.10.190.25:3128


```bash
git clone https://github.com/marcelogando/RadartonaAPI.git

cd RadartonaAPI

sudo docker build -t milenio_tech_api .

(Se tiver SSL, rodar esse)
sudo docker run --rm -it -d -p 80:80 -p 443:80 --name milenio_tech_api milenio_tech_api -dit --restart unless-stopped

(Se não tiver SSL, rodar esse)
sudo docker run --rm -it -d -p 80:80 --name milenio_tech_api milenio_tech_api -dit --restart unless-stopped
```

## Testes

Para rodar os testes, execute os comandos abaixo:

```shell
$ pip install

$ pip shell

$ pytest
```

## Funcionalidades 

- Protocolo HTTPS
- Saídas em JSON e XML
- Exportação de arquivo CSV
- Versionamentode API (v0,v1)
- Autenticação com OAuth2.0
- Log de login
- Log de controle de armazenamento
- Funcionamento Assíncrono
- Paginação
- Testes unitários e automatizados
- Agnóstica a plataforma e  multiplataforma
- Serviço funciona em banco SQL (postgres, mysql ou sqlite) ou NoSQL (mongoDB)
- API das bases: radares, trajetos, contagens e predição
- Filtros
- Frontend
- Predição dos dados
- Site (cadastramento de usuário, administrador, tutorial, autocadastramento de usuários)

## Arquitetura

### UML Banco de Dados - Data Lake

![datalake](/MilenioRadartonaAPI/Presentation/datalake-ultimato.png)

## Casos de uso da API

![casos_uso](/MilenioRadartonaAPI/Presentation/casos_de_uso.jpg)

## Documentação

A aplicação está documentada em OpenAPI 3.0 - [Documentação](https://app.swaggerhub.com/apis-docs/willianchan/API_Milenio_Bus_Radartona/1.0.0-oas3)

É fornecido uma coleção com todas as rotas para Postman - [Collection](radartona.postman_collection.json)

## Licença

Esse projeto está licenciado pelo MIT. Consulte aqui - [LICENSE](https://github.com/marcelogando/RadartonaAPI/blob/master/LICENSE).

## Autores

* **Anna Flávia Castro** - [LinkedIn](https://br.linkedin.com/in/anna-fl%C3%A1via-castro-675264182) - [GitHub](https://github.com/annaflavia-castro)

* **Lucas Simões** - [LinkedIn](https://br.linkedin.com/in/lucazsimoes) - [GitHub](https://github.com/ImZicky)

* **Marcel Ogando** - [LinkedIn](https://br.linkedin.com/in/marcel-ogando) - [GitHub](https://github.com/marcelogando)

* **Willian Chan** - [LinkedIn](https://br.linkedin.com/in/willianchan) - [GitHub](https://github.com/willianchan)

## Referências

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/)
- [Python](https://wiki.python.org.br/DocumentacaoPython)
- [Docker](https://docs.docker.com/)
- [PostgreSQL](https://www.postgresql.org/docs/)
