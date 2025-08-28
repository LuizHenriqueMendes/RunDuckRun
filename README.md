  # RunDuckRun - Unity 2D

### RunDuckRun é um jogo de plataforma 2D feito na Unity, é o meu primeiro jogo 'completo', então por favor, tenha piedade!

- Esse projeto demorou mais do que o necessário para ser finalizado, na verdade muito mais... Em vários momentos eu acabei pausando o desenvolvimento do jogo por desânimo e por outros motivos, como faculdade, estágio, etc.
- Se eu não me engano comecei ele em 2021, então dá pra perceber que demorou muito pra acabar kkkk

- Como estou postando o repositório com o jogo já finalizado, não vou falar muito sobre o código completo (ainda por cima porque grande parte das coisas é antiga e não sei o que passava na minha cabeça);
- Pensei em dar uma limpada no repositório, arrumar alguns códigos, ou até mesmo tentar otimizar algumas partes, mas mudei de ideia, me imagino em alguns anos vendo novamente esse projeto e percebendo alguns erros de principante que provavelmente estou cometendo.

#### Aqui estão os pontos que acho interessante destacar sobre o RunDuckRun

- A base do jogo é uma Grid, então o chão em que o player pisa são blocos desenhados (por um amigo meu), escolhi este método, pois ele me dá mais liberdade pra desenhar as fases e descobrir jeitos interessantes treinar um pouco de level design.
- O Script do Player é bem simples, ele é responsável principalmente pelas vidas, que quando chegam a zero, teletransportam o player de volta à fase 1;
- O CheckPoint (Ovo no ninho) é responsável por passar para o próximo nível, foi uma das coisas que deu mais trabalho, pois para passar de nível, o player precisa coletar todos os ovos, então precisava contar os ovos que o jogar tinha pego, e precisava atribuir à uma verificação para ver se poderia passar;
  - Isso deu trabalho também, pelo Score que fica no superior da tela, me deparei com algumas dificuldades, exemplo: como fazer a pontuação seguir para a fase seguinte e como zerar quando o player morresse!
  - O que na verdade era mais simples do que parecia, precisando apenas criar uma classe que carregasse o static score, para "proteger" a pontuação conforme a fase passava.
- Em relação ao inimigos, ambos tem uma dinâmica bem parecida, optei por colocar um ground-check na frente do animal e, caso ele detectasse a falta do chão, faria o animal virar para outra direção!
  - Depois percebi que ficaria muito limitado a deixar os inimigos em 'ilhas' para que eles pudessem "ir e voltar", então consegui desenvolver o código pra caso houvesse colisão com algo, ele também virasse, aumentando então a possibilidade, podendo limitar o movimento com outro inimigo, com um espinho ou até com uma parede.
- Por fim, falando da interface, diria que o mais difícil foi a arte dela, fiz um menu final com um botão de replay e um menu inicial com a opção de iniciar o jogo e explicando os controles.
  - Tem também um botão de pause, que eu quis fazer mais para treinar do que com um propósito real.

#### Coisas que eu poderia melhorar...

- Obviamente o jogo não está perfeito, mas fico muito contente com o resultado, acho o jogo divertido e um pouco complicado (talvez por ser um pouco ruim), mas algumas coisas que poderiam mudar:
  - Menu de opções! Aumentar ou diminuir a música seria importante...
  - Código mais organizado, mas esse não me culpo tanto, para algumas partes eu estava aprendendo a programar, então realmente não era minha prioridade na época;
  - Um inimigo que fique parado, sem ser um espinho que não combina muito com a estética do jogo, para emplementar no meio das fases.
- Sendo honesto não consigo pensar muito em como melhorar o jogo, mas conforme o tempo passe e eu revisite o projeto, posso adicionar mais comentários!

## Obrigado por ler até aqui! Agradeço o tempo para testar meu primeiro jogo e até por ler o Read.me, que imagino que sejam poucos a fazer isso;
## Espero ver você futuramente em outros projetos, mas por este, acredito que seja tudo! 
