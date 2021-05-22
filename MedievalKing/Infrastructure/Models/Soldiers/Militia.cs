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
    }
}
