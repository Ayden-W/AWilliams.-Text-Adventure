using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class GrassType : Pokemon
    {
        private Dictionary<string, Dictionary<string, int>> attacks;

        public float GetAttackPower(Pokemon enemy, string attackName)
        {
            Random random = new Random();
            int attackPower = random.Next(0, attacks[attackName]["power"] - 20);

            if (enemy is WaterType)
            {
                Console.WriteLine("attack is super effective");
                return attackPower * 1.5f;
            }
            else if (enemy is FireType)
            {
                Console.WriteLine("attack is not very effective");
                return attackPower * 0.5f;
            }
            else
            {
                return attackPower;
            }
        }

        public void Growl()
        {
            Console.WriteLine("cheep cheep");
        }

        public void SetAttacks()
        {
            attacks = new Dictionary<string, Dictionary<string, int>>
        {
            { "razer", new Dictionary<string, int> { { "power", 70 }, { "Accuracy", 60 } } },
            { "Whip", new Dictionary<string, int> { { "power", 90 }, { "Accuracy", 90 } } },
            { "Seed Bomb", new Dictionary<string, int> { { "power", 65 }, { "Accuracy", 100 } } }
        };
        }
    }
}
