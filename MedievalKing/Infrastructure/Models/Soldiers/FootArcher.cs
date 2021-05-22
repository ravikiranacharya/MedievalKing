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
    }
}
