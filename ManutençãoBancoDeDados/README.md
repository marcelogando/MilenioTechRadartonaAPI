# Manutenção do Banco de Dados

O banco de dados possui arquitetura utilizando 2 schemas(**public** e **camadavisualizacao**), na camada **public** estão as tabelas de funcionamento da API e também as bases fornecidas durante a radartona, as mesmas são consumidas pelo Banco de dados para pré processar os dados a partir das tabelas baseRadares, contagens, trajetos e viagens.

Essas tabelas passam por um pré processamento, desse modo, os dados são transformados em json a partir da data da consulta e do id do radar, esse pré processamento é realizado por PROCEDURES SQL no banco de dados, assim, são gerados as tabelas no schema **camadavisualizacao** que serão consumidos pela API na hora de apresentar dados para o usuário

Após a inserção de dados nas tabelas é necessário rodar as seguintes procedures para que a **camada de visualização** seja atualizada. As procedures são baseadas na data em que os dados de backup foram inseridos.

### Tabela contagens

```sql
-- DataInicial e DataFinal são dados do tipo 'yyyy-MM-dd'
InsereFluxoVeiculosRadares(DataInicial, DataFinal)
InsereTipoVeiculosRadares(DataInicial, DataFinal)
InsereInfracoesRadares(DataInicial, DataFinal)
InsereAcuraciaIdentificacaoRadares(DataInicial, DataFinal)
```

### Tabela Trajetos

```sql
-- DataInicial e DataFinal são dados do tipo 'yyyy-MM-dd'
InsereTrajetos(DataInicial, DataFinal)
InsereVelocidadeMediaTrajeto(DataInicial, DataFinal)
```

### Tabela Viagens

```sql
-- DataInicial e DataFinal são dados do tipo 'yyyy-MM-dd'
InsereViagens(DataInicial, DataFinal)
```

# Tabela BaseRadares

Adicionar radares normalizados por código com registros equivalentes na tabela **base_radares_lat_lon**