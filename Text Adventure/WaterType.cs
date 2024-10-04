using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class WaterType : Pokemon
    {
        private Dictionary<string, Dictionary<string, int>> attacks;
        private string v1;
        private int v2;

        public WaterType(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public float GetAttackPower(Pokemon enemy, string attackName)
        {
            Random random = new Random();
            int attackPower = random.Next(0, attacks[attackName]["power"] - 20);

            if (enemy is FireType)
            {
                Console.WriteLine("attack is super effective");
                return attackPower * 1.5f;
            }
            else if (enemy is GrassType)
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
            Console.WriteLine("splish splosh");
            Console.WriteLine("Cute you Growled");
        }

        public void SetAttacks()
        {
            attacks = new Dictionary<string, Dictionary<string, int>>
        {
            { "Bubble", new Dictionary<string, int> { { "power", 70 }, { "Accuracy", 60 } } },
            { "Hydro Pump", new Dictionary<string, int> { { "power", 90 }, { "Accuracy", 90 } } },
            { "Surf", new Dictionary<string, int> { { "power", 65 }, { "Accuracy", 100 } } }
        };
        }
    }
}