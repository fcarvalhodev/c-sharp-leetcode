Problema: Salto Par ou Ímpar

Você irá prover um array de inteiros arr. A partir do primeiro índice, você efetuará uma série de pulos. A primeira série de pulos se chamará odd-numbered (1º, 3º, 5º), e a segunda série se chamará even-numbered (2º, 4º, 6º).  Note que, os pulos são numerados e não os índices. 

Você poderá pular dos índices I para o J (onde i < j) da seguinte maneira:

Durante o pulo odd-numbered (1,3,5…), você pulará para o índice J, ou seja arr[i] <= arr[j] e arr[j] é o menor valor possível. Se existir múltiplos índices  J, você pode pular apenas o menor valor de J.
Durante o pulo even-numbered  (2,4,6…), você pulará para o índice J, ou seja arr[i] >= arr[j] e arr[j] é o maior valor possível. Se existir múltiplos índices J, você pode pular para o menor valor possível de J.
Pode ser caso para alguns índices de I, que não há valor para serem pulados.

A princípio, o índice é bom se a partir do índice, você pode alcançar o final do array (índice arr.length -1) pulando alguns números (possivelmente 0 ou maior que 1).

Ao final do problema, retorne o número de bons índices iniciais.

Exemplo 1:

Input: arr = [10,13,12,14,15]
Output: 2
Explicação:

Começando do índice i = 0, nós podemos fazer o primeiro pulo para i = 2 (desde que arr[2] é o menor entre arr[1], [arr2], [arr3], [arr4] e é maior ou igual ao arr[0], então a gente não pode efetuar outro pulo.

Começando do índice i = 1, e  = 2, nós podemos fazer o primeiro pulo para i = 3, e então podemos fazer um outro pulo.

Começando do índice i = 3, nós podemos efetuar o primeiro pulo para i = 4, então nós alcançaremos o final.

Começando do índice i = 4, nós já teremos alcançado o final.

No total, temos 2 maneiras diferentes de começar o índice i = 3 e i = 4, onde nós podemos alcançar o final com alguns pulos.

Exemplo 2: 

Input: arr [ 2,3,1,1,4]
Output: 3

Explicação: 

A partir do índice i = 0, nós efetuaremos pulos para i = 1, i = 2, e i = 3

Durante o primeiro pulo (odd-numbered), o primeiro pulo é para  i = 1, porque arr[i] é o menor valor dentro de [ arr[1], arr[2], arr[3], arr[4]] que é maior ou igual ou igual arr[0].

Durante o segundo pulo (even-numbered), nós pulamos de i = 1 para i = 2, é o maior valor dentro de [ arr[2], arr[3], arr[4]] que é menor ou igual ou igual arr[1]. O arr[2] também é o maior valor que é o menor entre os índices, mas o índice é maior que o anterior, por isso pulamos para i = 2 e não i = 3.

Durante o terceiro pulo (odd-numbered), nós pularemos do índice i = 2 para i = 3, porque arr[3] é o menor valor entre [arr[3], arr[4]) que é o maior ou igual ao arr[2].

Nós não podemos pular de i = 3 para i = 4, então o índice inicial i = 0 não é bom.

De uma maneira similar, nós podemos reduzir para:

A partir do índice i = 1, nós pulamos para i = 4, então alcançaremos o final.
A partir do índice i = 2, nós pulamos para i = 3, nesse caso, não podemos mais pular.
A partir do índice i = 3, nós podemos pular para i = 4, então nós alcançamos o final novamente.
A partir do índice i = 4, nós já estaremos no final.

No total, há 3 maneiras diferentes de começarmos com os indices i = 1, i = 3 e i = 4, onde podemos alcançar o final com alguns pulos.

Exemplo: 3
Input: arr = [5,1,3,4,2]
Output: 3
Explicação:
Nós podemos alcançar o final do array a partir dos índices 1, 2, e 4.

Constraints:

1 < = arr.length <=2 *104
0 <= arr[i] < 105

