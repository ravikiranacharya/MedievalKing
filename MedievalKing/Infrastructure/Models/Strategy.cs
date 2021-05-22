using MedievalKing.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedievalKing.Infrastructure.Models
{
    public class Strategy : IStrategy
    {
        public List<Platoon> Platoons { get; set; }
        public List<Platoon> OwnPlatoons { get; set; }
        public List<Platoon> OppositionPlatoons { get; set; }
        public void GetWinningStrategy()
        {   
            var allPermutations = GetAllPermutations(OwnPlatoons);

            foreach(var permutation in allPermutations)
            {
                if(IsWinningPosition(permutation, OppositionPlatoons))
                {
                    this.Platoons = permutation;
                    return;
                }
            }
            Platoons = new List<Platoon>();

        }

        // This method is incomplete. Need to cover logic to get all permutations instead of rotating right
        private List<List<Platoon>> GetAllPermutations(List<Platoon> platoons)
        {
            
            var result = new List<List<Platoon>>();
            
            for(var i=0; i<platoons.Count-1; i++)
            {

                var tempPlatoons = platoons;
                var mover = tempPlatoons[i];
                tempPlatoons[i] = tempPlatoons[i + 1];
                tempPlatoons[i + 1] = mover;
                result.Add(tempPlatoons);
            }

            return result;
        }

        private bool IsWinningPosition(List<Platoon> ownPlatoons, List<Platoon> oppositionPlatoons)
        {  
            var battlesWon = 0;
            for (var i = 0; i < ownPlatoons.Count; i++)
            {
                if (ownPlatoons[i].HasAdvantage(oppositionPlatoons[i]))
                {
                    battlesWon++;
                }
            }

            return battlesWon > ownPlatoons.Count/2;
        }

        public override string ToString()
        {
            var list = new List<string>();
            foreach(var p in Platoons)
            {
                list.Add(p.ToString());
            }
            return string.Join(";", list);
        }
    }
}
