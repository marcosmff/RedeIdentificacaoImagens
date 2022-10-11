using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Helpers
{
    internal static class ValoresEsperadosHelper
    {
        public static Dictionary<string, int[]> ValoresEperados = new Dictionary<string, int[]>()
        {
            {"GRASS", new int[]     { 0, 0, 0, 0, 0, 0, 1} },
            {"PATH", new int[]      { 0, 0, 0, 0, 0, 1, 0} },
            {"WINDOW", new int[]    { 0, 0, 0, 0, 1, 0, 0} },
            {"CEMENT", new int[]    { 0, 0, 0, 1, 0, 0, 0} },
            {"FOLIAGE", new int[]   { 0, 0, 1, 0, 0, 0, 0} },
            {"SKY", new int[]       { 0, 1, 0, 0, 0, 0, 0} },
            {"BRICKFACE", new int[] { 1, 0, 0, 0, 0, 0, 0} }
        };

        public static Dictionary<string, int> IndicesValoresEperados = new Dictionary<string, int>()
        {
            {"GRASS",     6 },
            {"PATH",      5 },
            {"WINDOW",    4 },
            {"CEMENT",    3 },
            {"FOLIAGE",   2 },
            {"SKY",       1 },
            {"BRICKFACE", 0 }
        };
    }
}
