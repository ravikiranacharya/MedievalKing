using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models.Soldiers
{
    public class Militia: Soldier
    {
        public Militia()
        {
            InferiorClasses = new List<string>() {"Spearmen", "LightCavalry" };
        }

        public override double GetEffect(string terrain)
        {
            switch (terrain)
            {
                case "Hill":
                    return 0.5;
                case "Muddy":
                    return 2;
                default:
                    return 1;
            }
        }
    }
}
