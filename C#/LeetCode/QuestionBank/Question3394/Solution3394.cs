using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3394
{
    public class Solution3394 : Interface3394
    {
        /// <summary>
        /// 合并区间
        /// 记录下不可切割的区间，然后合并区间即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public bool CheckValidCuts(int n, int[][] rectangles)
        {
            List<(int, int)> _rngs1 = [], _rngs2 = [];
            foreach (int[] rec in rectangles) { _rngs1.Add((rec[0], rec[2])); _rngs2.Add((rec[1], rec[3])); }
            _rngs1.Sort((x, y) => x.Item1 - y.Item1);
            _rngs2.Sort((x, y) => x.Item1 - y.Item1);

            List<(int, int)> rngs1 = [], rngs2 = [];
            int left, right, _left, _right, cnt;
            if (_rngs1.Count > 2)
            {
                (left, right) = _rngs1[0]; cnt = _rngs1.Count;
                for (int i = 1; i < cnt; i++)
                {
                    (_left, _right) = _rngs1[i];
                    if (right > _left) { right = Math.Max(right, _right); } else { rngs1.Add((left, right)); (left, right) = _rngs1[i]; }
                }
                rngs1.Add((left, right));
            }
            if (_rngs2.Count > 2)
            {
                (left, right) = _rngs2[0]; cnt = _rngs2.Count;
                for (int i = 1; i < cnt; i++)
                {
                    (_left, _right) = _rngs2[i];
                    if (right > _left) { right = Math.Max(right, _right); } else { rngs2.Add((left, right)); (left, right) = _rngs2[i]; }
                }
                rngs2.Add((left, right));
            }

            return rngs1.Count > 2 || rngs2.Count > 2;
        }
    }
}
