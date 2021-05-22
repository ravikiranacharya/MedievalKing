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

                var kingdoms = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                var ownKingdom = kingdoms[0];
                var opponentKingdom = kingdoms[1];

                var ownPlatoons = (List<Platoon>)InputHelper.ParseKingdom(ownKingdom);
                var opponentPlatoons = (List<Platoon>)InputHelper.ParseKingdom(opponentKingdom);

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
