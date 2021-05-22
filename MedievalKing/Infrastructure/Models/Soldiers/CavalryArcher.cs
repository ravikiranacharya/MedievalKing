using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models.Soldiers
{
    public class CavalryArcher: Soldier
    {
        public CavalryArcher()
        {
            InferiorClasses = new List<string>() { "Spearmen", "HeavyCavalry" };
        }

        public override double GetEffect(string terrain)
        {
            switch (terrain)
            {
                case "Hill":
                    return 2;
                case "Plains":
                    return 2;
                default:
                    return 1;
            }
        }
    }
}
