## Descrição da Api

### Api Loja

A Api Loja utiliza o protocolo HTTPS, realizando a conexão com o banco e devolvendo as requisições do usuario.
Foi utilizado o servidor IIS Express para realizar as requisições, bem como a versão de software livre do Entity Framework, o Entity Framework Core para realizar conexões com o banco de dados.
Existem 7 tipos de  requisição. Sendo elas:
* Adicionar Produto (POST)
* Listar todos os Produtos (GET)
* Listar um Produto (GET)
* Remover um Produto (DELETE)
* Atualizar as informações de um Produto (PUT)
* Autorizar Pagamentos (POST)
* Cadastrar Compras (POST)

Com essas funcionalidades é possível utilizar o servidor para realizar requisições na porta 44343 com um ip local.

# Instalação
Primeiro é necessário instalar as dependências do servidor começando pelo Visual Studio 2019, logo após a instalação do Visual Studio é necessario instalar uma interface gerenciadora de banco de dados, a fim de verificação das funcionalidades de cadastro, utilizando [Microsoft SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) (SSMS) e [SQL Server Express](https://download.microsoft.com/download/7/f/8/7f8a9c43-8c8a-4f7c-9f92-83c18d96b681/SQL2019-SSEI-Expr.exe).

Após a instalação do servidor e do gerenciador de banco de dados, é necessario alterar a ConnectionString localizada no arquivo appsettings.json, é necessario alterar o endereço do servidor para o endereço criado pelo SQL Server Express, é possivel achar esse endereço ao iniciar o SSMS.

Configurada a conexão da Api com o Banco de Dados, é necessario fazer o download de um encaminhador de requisições como o [Postman](https://www.postman.com/downloads/) ou o [insomnia](https://insomnia.rest/download/), já que esta Api não possui interface de usuario.

# Dependências

* Visual Studio 2019.

* Microsoft SQL Server Management Studio (SSMS).

* SQL Server Express.

* Um encaminhador de requisições.

# Especificação

* O Protocolo utilizado é o HTTPS através da porta 44343 no ip local do servidor.

* A requisição de cadastro de produtos funciona na rota api/Produtos e recebe os seguintes parametros no corpo da requisição POST em formato JSON e devolve uma mensagem de sucesso:
    * Nome ( o nome do produto à ser salvo no banco de dados )
    * Valor_unitario ( O preço do produto )
    * Qtde_estoque (A quantide de produtos disponivel)
* A requisição de listar produtos funciona na rota api/Produtos, a requisição GET deverá ser enviada e receberá os dados de todos os produtos cadastrados no banco.
* A requisição de listar um produto especifico funciona na rota api/Produtos/:id, onde ":id" é um inteiro que representa o id do produto no banco de dados, Exemplo: "localhost:44343/api/Produtos/1", a requisição GET deverá ser enviada e receberá os dados do produto do qual o id fora requisitado.
* A requisição de remover produtos funciona na rota api/Produtos/:id, onde ":id" é um inteiro que representa o id do produto no banco de dados, Exemplo: "localhost:44343/api/Produtos/1", a requisição DELETE deverá ser enviada e removerá este produto do banco.
* A requisição de atualizar os dados de um produto funciona na rota api/Produtos/:id, onde ":id" é um inteiro que representa o id do usuario no banco de dados e será enviado como parametro, Exemplo: "localhost:44343/api/Produtos/1", a requisição PUT deverá ser enviada e conter o seguinte formato no corpo da requisição:
    * Id ( Id do produto à ser alterado )
    * Nome ( o nome do produto à ser alterado no banco de dados )
    * Valor_unitario ( O preço do produto à ser alterado )
    * Qtde_estoque ( A nova quantidade disponivel do produto )
Seguindo esse formato a requisição atualizará as informações no banco de dados com as novas que foram passadas.
* A requisição de autorizar pagamentos funciona na rota api/Produtos e recebe os seguintes parametros no corpo da requição POST em formato JSON:
  * Valor ( valor da compra a ser autorizada, seguindo a regra de: compras são aceitas se o seu valor for maior que 100 )
  * Cartao: ( Objeto que contem os dados do cartão )
    * Titular ( Nome do titular do cartão )
    * Numero_cartao ( Numero do cartão )
    * Data_expiracao ( Data de validade do cartão )
    * Bandeira ( Bandeira do cartão )
    * Cvv ( Codigo de verificação do cartão ) 

# Execução

Para executar o servidor da api, basta abrir o visual studio e executar o projeto no modo IIS Express.

# Teste

Para testar se o servidor está executando basta tentar realizar uma requisição GET em localhost:44343/api/Produtos utilizando qualquer ferramenta , como insomnia ou postman. 

O servidor devolverá a lista de todos os produtos cadastrados caso o servidor tenha sido iniciado com sucesso.

# Licença
* [Visual Studio 2019]( https://visualstudio.microsoft.com/pt-br/vs/community/ ) (Licença de uso aberta para pessoa física). 

* [SSMS]( https://www.microsoft.com/pt-br/licensing/product-licensing/sql-server?activetab=sql-server-pivot:primaryr2 ).

* [Postman]( https://www.postman.com/pricing/ ).

* [Insomnia]( https://insomnia.rest/pricing/ )

# Organização

* Pastas
   * Properties - Contém o arquivo necessarios para a execução do projeto, o arquivo é:
        * launchSettings - Arquivo JSON com as configurações de inicialização da Api
   * Controllers - Contém os arquivos responsaveis por chamar os services, os arquivos são:
        * ComprasController - Arquivo C# com a requisição para cadastrar compra
        * PagamentosController - Arquivo C# com a requisição para validar pagamentos
        * ProdutosController - Arquivo C# com as requisições de produto (Cadastro, Listagem, Atualização e Remoção)
   * Models - Contém os arquivos de mapeamento de entidades do banco de dados e os arquivos de conexão com as respectivas tabelas
        * Compras - contém os arquivos relacionados a compras:
            * Compra - Arquivo C# com o mapeamento da entidade compra
            * CompraDbContext - Arquivo que relaciona o modelo à tabela do banco de dados
        * Misc - contém os arquivos relacionados à suporte, como parametrização de constantes e retorno de funções:
            * Constantes - Arquivo com constantes parametrizadas a fim de organização e manutenibilidade de codigo
            * Detalhes - Arquivo para facilitar o retorno personalizado de requisições
        * Pagamentos - contém os arquivos relacionados ao pagamento:
            * Cartap - Modelo de cartao para verificação de validade
            * Pagamento - Modelo de pagamento para requição
        * Produtos - contém os arquivos relacionados aos produtos:
            * Produto - Modelo de produto para requisições
            * ProdutoDbContext - Arquivo que relaciona o modelo à tabela do banco de dados
    * Services - Arquivos responsaveis pelas validações e execução das requisições
        * PagamentoServices - Validador que contém os metodos da requisição de pagamento
        * ProdutoServices - Validador que contém os metodos das requisições de produto

# Responsável

* Matheus Henrique Marques Lourenço - git(matheuslourenco200@gmail.com) user: **@TeslaOrigins**
