using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models.Soldiers
{
    public class FootArcher: Soldier
    {
        public FootArcher()
        {
            InferiorClasses = new List<string>() { "Militia", "CavalryArcher" };
        }

        public override double GetEffect(string terrain)
        {
            switch (terrain)
            {
                case "Hill":
                    return 2;
                case "Muddy":
                    return 2;
                default:
                    return 1;
            }
        }
    }
}
