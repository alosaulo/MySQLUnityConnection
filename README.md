# MySQLUnityConnection
A small project for testing unity and mysql connection in localhost

## Contexto do Esquema

O esquema 'gameDB' foi criado para gerenciar um sistema de jogos online. Ele contém informações sobre os usuários, seus logins, pontuações, conquistas, histórico de jogos, jogos disponíveis na plataforma, e relações de amizade entre os usuários.

### Tabela 'login'

A tabela 'login' é responsável por armazenar informações de autenticação dos usuários, incluindo nomes de usuários e senhas.

- 'id': Chave primária, identificador único do login.
- 'LOGIN' Nome do usuário utilizado para acessar o sistema.
- 'SENHA': Senha associada ao nome de usuário.

### Tabela 'jogo'

A tabela 'jogo' contém informações sobre os jogos disponíveis na plataforma.

- 'id': Chave primária, identificador único do jogo.
- 'NOME': Nome do jogo.
- 'DESCRICAO': Descrição textual do jogo.

### Tabela 'usuario'

A tabela 'usuario' contém informações sobre os perfis dos usuários, como nome, idade e sexo.

- 'id': Chave primária, identificador único do usuário.
- 'LOGINID': Chave estrangeira que faz referência à tabela 'login', ligando o perfil do usuário às suas credenciais de acesso.
- 'NOME': Nome real do usuário.
- 'IDADE': Idade do usuário.
- 'SEXO': Sexo do usuário.

### Tabela 'score'

A tabela 'score' armazena informações sobre as pontuações alcançadas pelos usuários nos jogos.

- 'id': Chave primária, identificador único da pontuação.
- 'LOGINID': Chave estrangeira que faz referência à tabela 'login', identificando o usuário.
- 'PONTOS': Pontos alcançados pelo usuário.

### Tabela 'amigos'

A tabela 'amigos' guarda as relações de amizade entre os usuários.

- 'LOGINID1': Chave estrangeira que faz referência à tabela 'login', identificando um usuário na relação de amizade.
- 'LOGINID2': Chave estrangeira que faz referência à tabela 'login', identificando o outro usuário na relação de amizade.

### Tabela 'conquistas'

A tabela 'conquistas' armazena as conquistas alcançadas pelos usuários em diferentes jogos.

- 'id': Chave primária, identificador único da conquista.
- 'LOGINID': Chave estrangeira que faz referência à tabela 'login', identificando o usuário.
- 'JOGOID': Chave estrangeira que faz referência à tabela 'jogo', identificando o jogo.
- 'NOME_CONQUISTA': Nome da conquista.
- 'DATA_CONQUISTA': Data em que a conquista foi alcançada.

### Tabela 'historico_jogos'

A tabela 'historico_jogos' registra o histórico de jogos jogados pelos usuários, incluindo datas e pontuações.

- 'id': Chave primária, identificador único do registro.
- 'LOGINID': Chave estrangeira que faz referência à tabela 'login', identificando o usuário.
- 'JOGOID': Chave estrangeira que faz referência à tabela 'jogo', identificando o jogo.
- 'DATA_JOGO': Data em que o jogo foi jogado.
- 'PONTOS': Pontos alcançados no jogo.

Essa estrutura permite uma gestão completa das interações dos usuários com a plataforma de jogos, incluindo seus logins, perfis, pontuações, conquistas, e relações com outros usuários.