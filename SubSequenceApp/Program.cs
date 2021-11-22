using System;

namespace SubSequenceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string Word = "abppblee";  
            string[] PossibleChoices = new string[] { "able", "ale", "apple", "bale", "kangaroo" };
            string[] ChoicesFound = new string[PossibleChoices.Length];
            MatchWords(ChoicesFound, PossibleChoices, Word);
            string LargestWord = GetTheLargestWord(ChoicesFound);
            Console.WriteLine(LargestWord);
            Console.ReadLine();
        }

        private static string GetTheLargestWord(string[] choicesFound)
        {
            string BiggestWord = "";
            int lastSize = 0;
            for(var k = 0; k < choicesFound.Length; k++)
            {
                if(choicesFound[k] != null && choicesFound[k].Length > lastSize)
                {
                    BiggestWord = choicesFound[k];
                    lastSize = choicesFound[k].Length;
                }
            }

            return BiggestWord;
        }

        public static void MatchWords(string[] ChoicesFound, string[] PossibleChoices, string Word)
        {
            int idx = 0;
            foreach (var Choice in PossibleChoices)
            {
                string TempChoice = "";

                for (int j = 0; j < Choice.Length; j++)
                {
                    for (int i = 0; i < Word.Length; i++)
                    {
                        if (Word[i].Equals(Choice[j]))
                        {
                            TempChoice += Word[i];
                            break;
                        }
                    }
                }

                if (TempChoice == Choice) { 
                    ChoicesFound[idx] = TempChoice;
                    idx++;
                }
            }
        }
    }
}
