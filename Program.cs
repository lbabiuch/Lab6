using System;
using System.Linq;
using System.Collections.Generic;
using RandomDataGenerator.Randomizers;
using RandomDataGenerator.FieldOptions;

namespace ConsoleApp2
{
    class Osoba
    {
        public int id;
        public string imie;
        public string nazwisko;

        public Osoba (int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
    class Program
    {
        static void Main()
        {
            List<int> lista = Enumerable.Range(100, 150).ToList();

            List<int> podzielnePrzez3 = lista.Where(x => x % 3 == 0).ToList();
            int elementyNaStrone = 25;
            int nrStrony = 2;
            List<int> strona = lista.Skip(elementyNaStrone * (nrStrony - 1))
              .Take(elementyNaStrone)
              .ToList();     
            var srednia = lista.Average();

            //Console.WriteLine(srednia);
            //foreach (var item in srednia)
            //  Console.WriteLine(item);

            /*List<Osoba> osoby = Enumerable.Range(1, 50)
                .Select(x => new Osoba()
                {
                    id = x,
                    imie = x.ToString(),
                    nazwisko = "aaa"
                }).ToList();*/


            /*foreach (var item in osoby)
            {
                Console.WriteLine($"{item.id}: {item.imie} {item.nazwisko}");
            }*/

            //IEnumerable<int> ids = osoby.Select(x => x.id);

            /*foreach (var item in ids)
            {
                Console.WriteLine(item);
            }*/

            /*List<string> nazwiska = osoby.Select(x => x.nazwisko).ToList();
            foreach (var item in nazwiska)
            {
                Console.WriteLine(nazwiska);
            }*/

            /*osoby.Select(x => x.nazwisko)
                .ToList()
                .ForEach(x => Console.WriteLine(x));*/

            /*int pierwszy = lista.FirstOrDefault(x => x % 300 == 0);
            Console.WriteLine(pierwszy);*/

            var intGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsInteger());
            var firstNameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var lastNameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            /*
            Osoba random = new Osoba(
                intGenerator.Generate().Value,
                firstNameGenerator.Generate(),
                lastNameGenerator.Generate()
                );

            Console.WriteLine($"{random.id}: {random.imie} {random.nazwisko}");*/

            //100 osob + sortowanie po nazwisku
            var list = new List<Osoba>();

            for (int i = 0; i <= 100; i++)
            {
                list.Add(new Osoba(
                    i,
                    firstNameGenerator.Generate(),
                    lastNameGenerator.Generate()));
            }

            var posortowane = list.OrderBy(x => x.imie).ToList();

            foreach (var item in posortowane)
            {
                Console.WriteLine($"{item.id}: {item.imie} {item.nazwisko}");
            }
        }
    }
}
