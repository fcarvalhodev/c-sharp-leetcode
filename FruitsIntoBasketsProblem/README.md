Problema: Cesto de Frutas

Você está visitando uma fazendo que tem um único corredor de árvores e frutas da esquerda para a direita. As árvores são representadas por array de frutas, onde frutas[i] é o tipo da fruta que a árvore iº produz.

Você irá coletar o quanto de fruta for possível. Entretanto, o dono da fazenda possui regras bem restritivas que você precisa seguir.

Você pode ter apenas duas cestas, e em cada cesta você só pode ter um tipo de fruta. Não existe limite na quantidade de fruta em que cada cesto pode segurar.
Começando de qualquer árvore, você precisa escolher exatamente uma fruta de cada árvore (incluindo a árvore inicial), enquanto se move para a direita. 
Ao atingir uma árvore em que a fruta não pode ficar na cesta, você precisa parar.

Dado a um inteiro de frutas, retorne o máximo número de frutas que você pegar.

Exemplo:1
Input: frutas = [1,2,1]
Output: 3
Explicação: Você pode colher de todas as três árvores.

Exemplo:2
Input: frutas = [1,2,3,2,2]
Output: 4
Explicação: Nós podemos pegar das árvores [2,3,2,2]. Se tivéssemos começado com a primeira árvore, nós teríamos pegado apenas das árvores [1,2].


