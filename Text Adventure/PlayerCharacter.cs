using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Text_Adventure
{
    internal class PlayerCharacter
    {
     
        void init()
        {
            Console.WriteLine("What is The Player name");
            string Playername = Console.ReadLine();
        }


        public string selectCard()
        {
            int counter = 0;
            string response = " ";
            for(card in hand)
            {
                response += $"{counter}{name} {(card.current_hp)}";
                counter += 1;
            }
            return response;
        }

        public void CurrentPokemon()
        {
           string activePokemon = Pokemon;
        }


        public void getCurrentPokemon()
        {
            return activePokemon;
        }
    }
}
