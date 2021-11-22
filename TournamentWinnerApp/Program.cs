using System;
using System.Collections.Generic;

namespace TournamentWinnerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = TournamentWinner(new List<List<string>>
            {
                new List<string>{ "HTML", "C#" },
                new List<string>{ "C#", "Python" },
                new List<string>{ "Python", "HTML" },
            }, new List<int> { 0, 0, 1 });
            Console.WriteLine(result);
        }

        // Write your code here.
        //So I have always two teams againt's each other, home team vs away team
        //Can have only one winer
        //There is no tie
        //How do I know who beats who ? By the results array which has 0 and 1
        public static string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            SortedList<string, int> matchs = new SortedList<string, int>();
            for (var i = 0; i < competitions.Count; i++)
            {
                DoMatch(competitions[i], results[i], matchs);
            }

            string bestTeam = GetTheBestTeam(matchs);

            return bestTeam;
        }

        private static string GetTheBestTeam(SortedList<string, int> matchs)
        {
            int CurrentHigherValue = 0;
            string CurrentWinner = "";
            foreach (KeyValuePair<string, int> team in matchs)
            {
                if (team.Value > CurrentHigherValue)
                {
                    CurrentWinner = team.Key;
                    CurrentHigherValue = team.Value;
                }
            }

            return CurrentWinner;
        }

        private static void DoMatch(List<string> competitions, int currentMatchResult, SortedList<string, int> matchs)
        {

            if ((int)TeamType.Home == currentMatchResult)
            {
                string winner = competitions[0];
                if (matchs.ContainsKey(winner))
                    matchs[winner] += 3;
                else
                    matchs.Add(winner, 3);
            }
            else
            {
                string winner = competitions[1];
                if (matchs.ContainsKey(winner))
                    matchs[winner] += 3;
                else
                    matchs.Add(winner, 3);
            }
        }

        enum TeamType
        {
            Away,
            Home
        }
    }
}
