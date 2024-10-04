using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class FireType
    {
        private Dictionary<string, Dictionary<string, int>> attacks;
        private string v1;
        private int v2;

        public FireType(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public float GetAttackPower(Pokemon enemy, string attackName)
        {

            Random random = new Random();
            int attackPower = random.Next(0, attacks[attackName]["power"] - 20);


            if (enemy is GrassType)
            {
                Console.WriteLine("Attack is super effective");
                return attackPower * 1.5f;
            }
            else if (enemy is WaterType)
            {
                Console.WriteLine("Attack is not very effective");
                return attackPower * .5f;
            }
            else
            {
                return attackPower;
            }
        }



        public void SetAttacks()
        {
            attacks = new Dictionary<string, Dictionary<string, int>>
        {
            { "Ember", new Dictionary<string, int> { { "power", 40 }, { "Accuracy", 100 } } },
            { "Flame Wheel", new Dictionary<string, int> { { "power", 70 }, { "Accuracy", 90 } } },
            { "NUKE", new Dictionary<string, int> { { "power", 1000 }, { "Accuracy", 1 } } }
        };
        }

        public void growl()
        {
            Console.WriteLine("Rwar");
            Console.WriteLine("Weird, That was supposed to work");
        }

    }
}
