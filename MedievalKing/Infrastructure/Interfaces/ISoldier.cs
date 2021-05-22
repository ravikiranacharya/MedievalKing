using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Interfaces
{
    public interface ISoldier
    {
        bool HasAdvantage(string platoonClass);
        abstract double GetEffect(string terrain);
    }
}
