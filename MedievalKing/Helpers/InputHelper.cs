using MedievalKing.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Helpers
{
    public static class InputHelper
    {
        
        public static IEnumerable<Platoon> ParseKingdom(string line, List<string> terrains)
        {
            var platoons = new List<Platoon>();

            if (!ValidateKingdom(line))
            {
                throw new Exception(string.Format("Invalid kingdom: {0}", line));
            }

            var platoonList = line.Split(";");
            //foreach(var p in platoonList)
            //{
            //    if (!ValidatePlatoon(p))
            //    {
            //        throw new Exception(string.Format("Invalid platoon: {0}", p));
            //    }

            //    var chunks = p.Split("#");

            //    var platoon = new Platoon();
            //    platoon.Class = chunks[0];
            //    platoon.NumberOfSoldiers = Convert.ToInt32(chunks[1]);
                
            //    platoons.Add(platoon);
            //}

            for(var i=0; i< platoonList.Length; i++)
            {
                var p = platoonList[i];
                if (!ValidatePlatoon(p))
                {
                    throw new Exception(string.Format("Invalid platoon: {0}", p));
                }

                var chunks = p.Split("#");

                var platoon = new Platoon();
                platoon.Class = chunks[0];
                platoon.NumberOfSoldiers = Convert.ToInt32(chunks[1]);
                platoon.Terrain = terrains[i];
                platoons.Add(platoon);
            }

            return platoons;
        }

        private static bool ValidateKingdom(string line)
        {
            return !string.IsNullOrEmpty(line) && line.Contains("#");
        }

        private static bool ValidatePlatoon(string platoon)
        {
            var isValid = !string.IsNullOrEmpty(platoon) && platoon.Contains("#");
            if (!isValid)
            {
                return false;
            }
            var chunks = platoon.Split("#");
            
            int.TryParse(chunks[1], out int numberOfSoldiers);
            isValid = isValid && chunks.Length == 2 && numberOfSoldiers != 0;

            return isValid;
        }

        public static bool ValidateInput(string input)
        {
            try
            {
                return !string.IsNullOrEmpty(input) && input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length == 3;
            }
            catch(Exception ex)
            {
                throw new Exception("Invalid input");
            }
            
        }
    }
}
