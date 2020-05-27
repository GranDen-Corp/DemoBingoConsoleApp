using System;
using System.Collections.Generic;
using System.Linq;
using GranDen.GameLib.Bingo;

namespace BingoDemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\nTest Bingo game......");

            var prizes = HorizontalPrize.Concat(VerticalPrize).Concat(DiagonalPrize).ToList();
            var bingo = new Bingo2dPrizeClincher(prizes);

            //actually you can provide only the points that marked true.
            var input = new List<MarkPoint2D>()
                .AddMarkPoint2Ds(
                    (0, 0, true ), (0, 1, true ), (0, 2, true ), (0, 3, true ),
                    (1, 0, true ), (1, 1, true ), (1, 2, false), (1, 3, false),
                    (2, 0, true ), (2, 1, false), (2, 2, true ), (2, 3, false),
                    (3, 0, true ), (3, 1, false), (3, 2, false), (3, 3, true )
                );

            var matchedAward = bingo.Decide(input);

            Console.WriteLine($"Get {matchedAward.Count} prize(s):");
            Console.WriteLine(string.Join(", ", matchedAward));
        }

        private static List<PrizeLine2D> HorizontalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (1, 0), (2, 0), (3, 0)}, "Horizontal Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 1), (1, 1), (2, 1), (3, 1)}, "Horizontal Line2"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 2), (1, 2), (2, 2), (3, 2)}, "Horizontal Line3"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 3), (1, 3), (2, 3), (3, 3)}, "Horizontal Line4"),
        };

        private static List<PrizeLine2D> VerticalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (0, 1), (0, 2), (0, 3)}, "Vertical Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(1, 0), (1, 1), (1, 2), (1, 3)}, "Vertical Line2"),
            new PrizeLine2D(new List<(int X, int Y)> {(2, 0), (2, 1), (2, 2), (2, 3)}, "Vertical Line3"),
            new PrizeLine2D(new List<(int X, int Y)> {(3, 0), (3, 1), (3, 2), (3, 3)}, "Vertical Line4"),
        };

        private static List<PrizeLine2D> DiagonalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (1, 1), (2, 2), (3, 3)}, "Diagonal Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(3, 0), (2, 1), (1, 2), (0, 3)}, "Diagonal Line2"),
        };
    }
}