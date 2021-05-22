using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Interfaces
{
    public interface IStrategy
    {
        void GetWinningStrategy();
        string ToString();
    }
}
