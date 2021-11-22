using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Essa lista ordena os elementos pelo valor da chave.
            SortedList<string, Person> people = new  SortedList<string, Person>();
            people.Add("Marcin", new Person { Name = "Marcin", Country = CountryEnum.PL, Age = 29 });
            people.Add("Sabine", new Person { Name = "Sabine", Country = CountryEnum.DE, Age = 25 });
            people.Add("Ann", new Person { Name = "Ann", Country = CountryEnum.UK, Age = 31 });

            foreach(KeyValuePair<string, Person> person in people)
            {
                Console.WriteLine($"{person.Value.Name}({person.Value.Age} years) from {person.Value.Country}");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CountryEnum Country { get; set; }
    }

    enum CountryEnum
    {
        PL,
        UK,
        DE
    }
}
