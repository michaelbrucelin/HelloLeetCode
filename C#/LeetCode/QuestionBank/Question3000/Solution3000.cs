using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3000
{
    public class Solution3000 : Interface3000
    {
        public int AreaOfMaxDiagonal(int[][] dimensions)
        {
            int line = 0, _line, area = 0;
            foreach (var arr in dimensions)
            {
                _line = arr[0] * arr[0] + arr[1] * arr[1];
                if (_line > line)
                {
                    area = arr[0] * arr[1];
                    line = _line;
                }
                else if (_line == line)
                {
                    area = Math.Max(area, arr[0] * arr[1]);
                }
            }

            return area;
        }
    }
}
