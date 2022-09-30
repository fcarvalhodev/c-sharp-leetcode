using System;

namespace BalloonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            solution("BAOOLLNNOLOLGBAX");
        }

        static int solution(string s)
        {
            //Balloon
            //1-B
            //1-A
            //2-L
            //2-O
            //1-N
            int wordLength = s.Length;
            double LettersToRemove = 0;
            int result = 0;
            int Bs = 0;
            int As = 0;
            int Ls = 0;
            int Os = 0;
            int Ns = 0;
            foreach (char c in s)
            {
                string letter = c.ToString();
                switch (letter)
                {
                    case "B":
                        Bs++;
                        break;
                    case "A":
                        As++;
                        break;
                    case "L":
                        Ls++;
                        break;
                    case "O":
                        Os++;
                        break;
                    case "N":
                        Ns++;
                        break;
                    default:
                        LettersToRemove++;
                        break;
                }
            }

            if (Bs > 1)
                LettersToRemove += Bs - 1;
            if (As > 1)
                LettersToRemove += As - 1;
            if (Ls > 2)
                LettersToRemove += Ls - 2;
            if (Os > 2)
                LettersToRemove += Os - 2;
            if (Ns > 1)
                LettersToRemove += Ns -1;

            int sizeIsValid = Convert.ToInt32(wordLength - LettersToRemove);
            if (sizeIsValid < 7)
                return 0;

            result = Convert.ToInt32(Math.Ceiling(LettersToRemove / 7));
            return result;
        }
    }
}
