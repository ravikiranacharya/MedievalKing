using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models.Soldiers
{
    public class Spearmen: Soldier
    {
        public Spearmen()
        {
            InferiorClasses = new List<string>() { "LightCavalry", "HeavyCavalry" };
        }
    }
}
