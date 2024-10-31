using AnimalCareGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalCareGame.Services
{
    public class AnimalService
    {
        public void FeedAnimal(Animal animal)
        {
            animal.Feed();
        }
        public void PlayWithAnimal(Animal animal)
        {
            animal.Play();
        }
        public void LetAnimalRest(Animal animal)
        {
            animal.Sleep();
        }
    }
}
