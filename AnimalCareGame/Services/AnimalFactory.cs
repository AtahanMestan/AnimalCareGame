using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalCareGame.Models;

namespace AnimalCareGame.Services
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(int choice, string name, int age)
        {
            switch (choice)
            {
                case 1:
                    return new Cat(name, age);
                case 2:
                    return new Dog(name, age);
                default:
                    return null;
            }
        }
        public void DisplayAnimalMenu()
        {
            Console.WriteLine("Bir hayvan seçiniz:");
            Console.WriteLine("1. Kedi");
            Console.WriteLine("2. Köpek");
        }
    }
}
