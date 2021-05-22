using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Interfaces
{
    public interface IPlatoon
    {
        bool HasAdvantage(IPlatoon platoon);
        ISoldier CreateSoldier(string className);
        string ToString();
    }
}
