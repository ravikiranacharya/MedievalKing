using MedievalKing.Infrastructure.Interfaces;
using MedievalKing.Infrastructure.Models.Soldiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalKing.Infrastructure.Models
{
    public class Platoon: IPlatoon
    {
        public int NumberOfSoldiers { get; set; }
        public string Class { get; set; }

        public ISoldier CreateSoldier(string className)
        {
            switch (className)
            {
                case "CavalryArcher":
                    return new CavalryArcher();
                case "FootArcher":
                    return new FootArcher();
                case "HeavyCavalry":
                    return new HeavyCavalry();
                case "LightCavalry":
                    return new LightCavalry();
                case "Militia":
                    return new Militia();
                case "Spearmen":
                    return new Spearmen();
                default:
                    return new Soldier();
            }
        }

        public bool HasAdvantage(IPlatoon platoon)
        {
            var platoonObj = (Platoon)platoon;
            if (this.Class.Equals(platoonObj.Class))
            {
                if(this.NumberOfSoldiers > platoonObj.NumberOfSoldiers)
                {
                    return true;
                }
            }
            else
            {
                var ownSoldierInstance = CreateSoldier(this.Class);
                var opponentSoldierInstance = CreateSoldier(platoonObj.Class);

                if (ownSoldierInstance.HasAdvantage(platoonObj.Class))
                {
                    return platoonObj.NumberOfSoldiers < 2 * this.NumberOfSoldiers;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}#{1}", this.Class, this.NumberOfSoldiers);
        }
    }
}
