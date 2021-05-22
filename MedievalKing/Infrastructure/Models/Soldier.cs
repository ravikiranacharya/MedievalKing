using MedievalKing.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models
{
    public class Soldier: ISoldier
    {
        public List<String> InferiorClasses { get; set; }
        public bool HasAdvantage(string platoonClass)
        {
            return InferiorClasses.Contains(platoonClass);
        }

    }
}
