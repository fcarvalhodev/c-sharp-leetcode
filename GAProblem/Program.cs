using System;
using System.Collections.Generic;

namespace GAProblem
{
    class Program
    {
        private static Random rnd = new Random();

        static void Main(string[] args)
        {

        }

        public static string FindBinaryGeneticString(Func<string, double> fitness,
                                                int length, double probCrossover,
                                                double probMutation)
        {
            var population = new List<string>();
            var number = length; //number of population
            double fitSum = 0;
            var fitnesses = new List<double>();

            for (var i = 0; i < number; i++)
            {
                population.Add(Generate(length));
                var fit = fitness(population[i]);
                fitnesses.Add(fit);
                fitSum += fit;
            }

            for (var times = 0; times < population.Count; times++)
            {
                var population_new = new List<string>();

                for (var i = 0; i < (number / 2); i++)
                {
                    var chromosome1 = Select(population, fitnesses, fitSum);
                    var chromosome2 = Select(population, fitnesses, fitSum);
                    var pair = Crossover(chromosome1, chromosome2, probCrossover);
                    chromosome1 = Mutate(pair[0], probMutation);
                    chromosome2 = Mutate(pair[1], probMutation);
                    population_new.Add(chromosome1);
                    population_new.Add(chromosome2);
                }

                population = population_new;
                fitnesses = new List<double>();
                fitSum = 0;

                for (var i = 0; i < number; i++)
                {
                    var fit = fitness(population[i]);
                    fitnesses.Add(fit);
                    fitSum += fit;
                }
            }

            var fittest = 0;
            var p = 0;
            for(var i = 0; i < fitnesses.Count; i++)
            {
                if (fitnesses[i] > fittest)
                {
                    fittest = Convert.ToInt32(fitnesses[i]);
                    p = i;
                }
            }

            return population[p];
        }

        public static string[] Crossover(string chromosome1, string chromosome2, double p)
        {
            if (rnd.Next() < p)
            {
                var calculate = rnd.Next() * (chromosome1.Length - 1);
                var pp = calculate;
                var temp = chromosome2;
                chromosome2 = chromosome2.Substring(0, pp) + chromosome1.Substring(pp);
                chromosome1 = chromosome1.Substring(0, pp) + temp.Substring(pp);
            }
            return new string[] { chromosome1, chromosome2 };
        }

        public static string Generate(int length)
        {
            var chromosome = string.Empty;

            for (var i = 0; i < length; i++)
                chromosome += Math.Round(new decimal(rnd.NextDouble())).ToString();

            return chromosome;
        }

        public static string Mutate(string chromosome, double p)
        {
            char[] arr = new char[chromosome.Length];
            for (var i = 0; i < chromosome.Length; i++)
            {
                if (rnd.Next() < p)
                {
                    int currentValue = Convert.ToInt32(chromosome[i]);
                    int downSize = 1 - currentValue;
                    arr[i] = downSize.ToString()[i];
                }
                else
                {
                    arr[i] = chromosome[i];
                }
            }
            string result = new string(arr);
            return result;
        }

        public static string Select(List<string> population, List<double> fitnesses, double fitSum)
        {
            Random rnd = new Random();
            int level = rnd.Next() * Convert.ToInt32(fitSum);
            var sum = 0;
            string result = string.Empty;

            for (var i = 0; i < fitnesses.Count; i++)
            {
                var parsedValue = Convert.ToInt32(fitnesses[i]);
                sum += parsedValue;
                if (sum >= level)
                {
                    result = population[i];
                    break;
                }
            }

            return result;
        }
    }
}
