using System;
using System.Runtime.InteropServices;
using AnimalCareGame.Models;
using AnimalCareGame.Services;

namespace AnimalGameTest;

  class Program
{
    static void Main(string[] args)
    {
        AnimalFactory animalFactory = new AnimalFactory();
        Animal selectedAnimal = null;
        int age = 2; 
        
        while (selectedAnimal == null)
        {
            animalFactory.DisplayAnimalMenu();
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Hayvanınıza bir isim verin: ");
            string name = Console.ReadLine();

            selectedAnimal = animalFactory.CreateAnimal(choice, name, age); //Geçersiz seçim durumu kontrol edilecek.

            if (selectedAnimal == null)
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyiniz.");
            }
        }
        AnimalService animalService = new AnimalService();
        while (true)
        {
            Console.WriteLine($"\n{selectedAnimal.Name} ile ne yapmak istersiniz?");
            Console.WriteLine("1. Besle");
            Console.WriteLine("2. Oyna");
            Console.WriteLine("3. Durum Kontrol Et");
            Console.WriteLine("4. Oyuncak Kullan");
            Console.WriteLine("5. Araçları göster");
            Console.WriteLine("6. Dinlendir");
            Console.WriteLine("7. Çıkış");

            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    animalService.FeedAnimal(selectedAnimal);
                    break;
                case 2:
                    animalService.PlayWithAnimal(selectedAnimal);
                    break;
                case 3:
                    Console.WriteLine($"{selectedAnimal.Name} adlı hayvanın sağlık durumu: {selectedAnimal.Health}");
                    Console.WriteLine($"{selectedAnimal.Name} adlı hayvanın mutluluk durumu: {selectedAnimal.Happiness}");
                    Console.WriteLine($"{selectedAnimal.Name} adlı hayvanın enerjisi: {selectedAnimal.Energy}");
                    Console.WriteLine($"{selectedAnimal.Name} adlı hayvanın seviyesi: {selectedAnimal.level}");
                    break;
                case 4:
                    Console.WriteLine("Kullanmak istediğiniz oyuncak ismini girin:");
                    foreach (var toy in selectedAnimal.toys)
                    {
                        Console.WriteLine($"- {toy.Name}");
                    }
                    string toyName = Console.ReadLine();
                    selectedAnimal.UseToy(toyName);
                    break;
                case 5:
                    Console.WriteLine($"{selectedAnimal.Name} adlı hayvanın sahip olduğu oyuncaklar:");
                    foreach (var toy in selectedAnimal.toys)
                    {
                        Console.WriteLine($"- {toy.Name}");
                    }
                    break;
                case 6:
                    animalService.LetAnimalRest(selectedAnimal); // Dinlendirme metodu
                    break;
                case 7:
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}






