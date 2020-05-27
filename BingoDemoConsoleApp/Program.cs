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

            var prizes = _horizontalPrize.Concat(_verticalPrize).Concat(_diagonalPrize).ToList();
            var bingo = new Bingo2dPrizeClincher(prizes);

            var input = new List<MarkPoint2D>
            {
                new MarkPoint2D((0, 0)), new MarkPoint2D((0, 1)), new MarkPoint2D((0, 2)), new MarkPoint2D((0, 3)),
                new MarkPoint2D((1, 1)), new MarkPoint2D((2, 2)), new MarkPoint2D((3, 3)),
                new MarkPoint2D((1, 0)), new MarkPoint2D((2, 0)), new MarkPoint2D((3, 0)),
            };

            var matchedAward = bingo.Decide(input);

            Console.WriteLine($"Get {matchedAward.Count} prize(s):");
            Console.WriteLine(string.Join(", ", matchedAward));
        }

        private static List<PrizeLine2D> _horizontalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (1, 0), (2, 0), (3, 0)}, "Horizontal Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 1), (1, 1), (2, 1), (3, 1)}, "Horizontal Line2"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 2), (1, 2), (2, 2), (3, 2)}, "Horizontal Line3"),
            new PrizeLine2D(new List<(int X, int Y)> {(0, 3), (1, 3), (2, 3), (3, 3)}, "Horizontal Line4"),
        };

        private static List<PrizeLine2D> _verticalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (0, 1), (0, 2), (0, 3)}, "Vertical Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(1, 0), (1, 1), (1, 2), (1, 3)}, "Vertical Line2"),
            new PrizeLine2D(new List<(int X, int Y)> {(2, 0), (2, 1), (2, 2), (2, 3)}, "Vertical Line3"),
            new PrizeLine2D(new List<(int X, int Y)> {(3, 0), (3, 1), (3, 2), (3, 3)}, "Vertical Line4"),
        };

        private static List<PrizeLine2D> _diagonalPrize => new List<PrizeLine2D>
        {
            new PrizeLine2D(new List<(int X, int Y)> {(0, 0), (1, 1), (2, 2), (3, 3)}, "Diagonal Line1"),
            new PrizeLine2D(new List<(int X, int Y)> {(3, 0), (2, 1), (1, 2), (0, 3)}, "Diagonal Line2"),
        };
    }
}