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

        
        private List<List<Platoon>> GetAllPermutations(List<Platoon> platoons)
        {
            return Permutations<List<Platoon>>(platoons);
        }

        private static List<List<Platoon>> Permutations<T>(List<Platoon> list)
        {
            var result = new List<List<Platoon>>();
            if (list.Count == 1)
            { 
                result.Add(list);
                return result;
            }

            foreach (var element in list)
            { 
                var remainingList = new List<Platoon>(list);
                remainingList.Remove(element); 
                foreach (var permutation in Permutations<T>(remainingList))
                { 
                    permutation.Add(element);
                    result.Add(permutation);
                }
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
