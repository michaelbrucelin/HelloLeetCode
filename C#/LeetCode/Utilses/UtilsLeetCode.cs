using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    public static class UtilsLeetCode
    {
        public enum TestCaseType { array_2d };

        public static string TestCase2CSharpDeclare(string raw, TestCaseType type)
        {
            string declare = string.Empty;
            switch (type)
            {
                case TestCaseType.array_2d:
                    declare = $"new int[][]{{{raw[1..^1].Replace("]", "}").Replace("[", "new int[]{")}}}";
                    break;
                default:
                    break;
            }

            return declare;
        }
    }
}
