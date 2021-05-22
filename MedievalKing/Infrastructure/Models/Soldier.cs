using MedievalKing.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models
{
    public abstract class Soldier: ISoldier
    {
        public List<String> InferiorClasses { get; set; }

        public abstract double GetEffect(string terrain);

        public bool HasAdvantage(string platoonClass)
        {
            return InferiorClasses.Contains(platoonClass);
        }

    }
}
