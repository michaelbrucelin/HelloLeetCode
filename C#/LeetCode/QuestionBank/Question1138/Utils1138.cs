using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1138
{
    public class Utils1138
    {
        private static readonly (int row, int col)[] map = new (int row, int col)[] {
              (0, 0), (0, 1), (0, 2), (0, 3), (0, 4)
            , (1, 0), (1, 1), (1, 2), (1, 3), (1, 4)
            , (2, 0), (2, 1), (2, 2), (2, 3), (2, 4)
            , (3, 0), (3, 1), (3, 2), (3, 3), (3, 4)
            , (4, 0), (4, 1), (4, 2), (4, 3), (4, 4)
            , (5, 0) };

        public void Dial()
        {
            List<char> result;
            for (int i = 0; i < 26; i++)
            {
                var src = map[i];
                for (int j = 0; j < 26; j++)
                {
                    result = new List<char>();
                    var tgt = map[j];
                    if (tgt.row < src.row) for (int k = 0; k < src.row - tgt.row; k++) result.Add('U');
                    if (tgt.col < src.col) for (int k = 0; k < src.col - tgt.col; k++) result.Add('L');
                    if (tgt.row > src.row) for (int k = 0; k < tgt.row - src.row; k++) result.Add('D');
                    if (tgt.col > src.col) for (int k = 0; k < tgt.col - src.col; k++) result.Add('R');
                    result.Add('!');
                    Console.Write($"{{{i * 26 + j},\"{new string(result.ToArray())}\"}}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
