using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models.Soldiers
{
    public class LightCavalry : Soldier
    {
        public LightCavalry()
        {
            InferiorClasses = new List<string>() { "FootArcher", "CavalryArcher" };
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
