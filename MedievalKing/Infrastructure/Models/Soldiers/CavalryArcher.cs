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
    }
}
