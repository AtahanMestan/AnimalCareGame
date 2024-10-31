using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalCareGame.Models
{
    public class Toy
    {
        public string Name { get; }
        public int HappinessBoost { get; }

        public Toy(string name, int happinessBoost)
        {
            Name = name;
            HappinessBoost = happinessBoost;
        }
    }
}
