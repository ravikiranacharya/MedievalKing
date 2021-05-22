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
    }
}
