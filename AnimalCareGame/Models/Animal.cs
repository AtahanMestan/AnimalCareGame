using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AnimalCareGame.Models
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private int health;
        private int happiness;
        public int level;
        private int energy;
        public  List<Toy> toys {  get; private set; }
        public int Health
        {
            get { return health; }
            protected set { health = value; }
        }
        public int Happiness
        {
            get { return happiness; }
            protected set { happiness = value; }
        }
        public int Energy
        {
            get { return energy; }
            set { energy = value; }
        }


        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
            Health = 100; // Başlangıçtaki sağlık değeri
            Energy = 100;
            Happiness = 50;
            level = 1;
            toys = new List<Toy>();

        }
        public abstract void MakeSound(); // Her hayvanın kendi sesi olacak.

        public void Feed()
        {
            Health += 10; // Beslenme sağlık artışı.
            happiness += 5; // Beslenme Mutluluk artışı
            Energy += 5; // Beslenme sonrası enerji artışı
            CheckLevelUp();
            Console.WriteLine($"{Name} karnı tok görünüyor :)");
        }
        public void Play()
        {
            if (Energy > 0)
            {
                Health -= 5;
                Happiness += 10;
                Energy -= 20; // Oynarken enerji kaybı
                CheckLevelUp();
                Console.WriteLine($"{Name} eğleniyor!");
            }
            else
            {
                Console.WriteLine($"{Name} yorgun, dinlenmesi gerekiyor!");
            }
        }
        public void Sleep()
        {
            Energy = 100; // Uyku sonrası enerji dolumu
            Console.WriteLine($"{Name} uyuyor ve dinleniyor.");
        }
        public void UseToy(string toyName)
        {
            var toy = toys.Find(t => t.Name == toyName);
            if (toy != null)
            {
                Happiness += toy.HappinessBoost; //Mutluluk artışı
                CheckLevelUp();
            }
            else
            {
                Console.WriteLine($"{toyName} Kullanılamaz yada Mevcut değil.");
            }
        }
        private void CheckLevelUp()
        {
            if (Happiness >= 100)
            {
                level++;
                Happiness = 50;
                GrantTools();
                Console.WriteLine($"{Name} seviye atladı! Şu anki seviyesi: {level}");
            }
        }
        private void GrantTools()
        {
            if (this is Cat)
            {
                toys.Add(new Toy("Kedi Tarağı", 15));
                toys.Add(new Toy("Kedi Oyuncağı", 20));
            }
            else if (this is Dog)
            {
                toys.Add(new Toy("Köpek Tarağı", 15));
                toys.Add(new Toy("Köpek Oyuncağı", 20));
            }
        }

    }
}
