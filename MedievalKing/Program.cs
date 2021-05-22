using MedievalKing.Helpers;
using MedievalKing.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MedievalKing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = File.ReadAllText("Input/InputFile.txt");
                if (!InputHelper.ValidateInput(input))
                {
                    throw new Exception("Invalid input");
                }

                var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                var ownKingdom = lines[0];
                var opponentKingdom = lines[1];
                
                var terrains = lines[2];
                var terrainList = new List<String>();
                foreach(var terrain in terrains.Split(";"))
                {
                    terrainList.Add(terrain);
                }

                var ownPlatoons = (List<Platoon>)InputHelper.ParseKingdom(ownKingdom, terrainList);
                var opponentPlatoons = (List<Platoon>)InputHelper.ParseKingdom(opponentKingdom, terrainList);

                var strategy = new Strategy();
                strategy.OwnPlatoons = ownPlatoons;
                strategy.OppositionPlatoons = opponentPlatoons;
                strategy.GetWinningStrategy();

                if(strategy.Platoons.Count == 0)
                {
                    Console.WriteLine("There is no chance of winning");
                    return;
                }

                Console.WriteLine(strategy.ToString());
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
