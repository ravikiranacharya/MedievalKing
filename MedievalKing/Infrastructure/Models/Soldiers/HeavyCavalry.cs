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
    }
}
