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
        public string Terrain { get; set; }

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
                    return null;
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

                var ownStrength = ownSoldierInstance.GetEffect(platoonObj.Terrain) * this.NumberOfSoldiers;
                var oppositionStrength = opponentSoldierInstance.GetEffect(platoonObj.Terrain) * platoonObj.NumberOfSoldiers;

                if (ownSoldierInstance.HasAdvantage(platoonObj.Class))
                {
                    return oppositionStrength < 2 * ownStrength;
                }
                else
                {
                    return oppositionStrength < ownStrength;
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
