using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models.Soldiers
{
    public class HeavyCavalry: Soldier
    {
        public HeavyCavalry()
        {
            InferiorClasses = new List<string>() { "Militia", "FootArcher", "LightCavalry" };
        }

        public override double GetEffect(string terrain)
        {
            switch (terrain)
            {
                case "Hill":
                    return 0.5;
                case "Plains":
                    return 2;
                default:
                    return 1;
            }
        }
    }
}
