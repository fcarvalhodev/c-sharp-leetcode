using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitsIntoBasketsProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fruits = new int[] { 1, 2, 1 };
            int result = TotalFruit(fruits);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int TotalFruit(int[] fruits)
        {
            if (fruits == null)
                return 0;

            int lastFruit = -1;
            int secondLastFruit = -1;
            int lastFruitCount = -1;
            int currentMax = 1;
            int max = 0;

            // traverse whole tree 
            for (int i = 0; i < fruits.Length; i++)
            {
                // if current fruit is among the last two fruit increase currentMax
                if ((fruits[i] == lastFruit) || (fruits[i] == secondLastFruit))
                {
                    currentMax++;
                }
                else
                {
                    // if current fruit is not among the last two fruit
                    //then secondLastFruitCount becomes lastFruitCount and lastFruitCount becomes 1
                    if (lastFruitCount != -1)
                        currentMax = lastFruitCount + 1;
                }

                if (fruits[i] != lastFruit)
                {
                    // keep updating the last two fruits  
                    secondLastFruit = lastFruit;
                    lastFruit = fruits[i];
                    lastFruitCount = 1;
                }
                else
                {
                    //if still last fruit is same increase the count 
                    lastFruitCount++;
                }

                max = Math.Max(max, currentMax);
            }

            return max;
        }
    }
}


// 1 - Percorrer cada arvore e verificar o tipo.
// 2 - Para cada tipo encontrado eu armazeno em uma cesta.
// 3 - Posso colher a quantidade máxima que der, mas respeitando apenas 1 tipo para cada cesta.
// 4 - Preciso validar a quantidade de cada tipo para ter certeza que eu colhar o máximo possível.
// 5 - Com a lista montada, ordenar pelo valor e somar os valores dos dois primeiros resultados.

//int result = 0;
//Dictionary<int, int> basket = new Dictionary<int, int>();

//for (int i = 0; i < fruits.Length; i++)
//{
//    int typeCurrValue = 0;
//    if (!basket.ContainsKey(fruits[i]))
//    {
//        basket.Add(fruits[i], typeCurrValue + 1);
//    }
//    else
//    {
//        basket[fruits[i]] = (int)basket[fruits[i]] + 1;
//    }
//}

////int temp;

//for (int i = 0; i < basket.Count - 1; i++)
//{
//    // traverse i+1 to array length
//    for (int j = i + 1; j < basket.Count; j++)
//    {
//        // compare array element with
//        // all next element
//        var elementI = basket.ElementAt(i);
//        var elementJ = basket.ElementAt(j);

//        if (elementI.Value < elementJ.Value)
//        {

//            basket.Remove(elementI.Key);
//            basket.Remove(elementJ.Key);
//            basket.Add(elementI.Key, elementI.Value);
//            basket.Add(elementJ.Key, elementJ.Value);

//        }
//    }
//}

//result = basket.ElementAt(0).Value + basket.ElementAt(1).Value;
//return result;



