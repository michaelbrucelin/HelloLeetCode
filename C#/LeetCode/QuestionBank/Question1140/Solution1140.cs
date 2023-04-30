using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1140
{
    public class Solution1140 : Interface1140
    {
        /// <summary>
        /// 递归暴力解
        /// 
        /// 未完成
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        public int StoneGameII(int[] piles)
        {
            return rec(piles, 0, 1, 0, 0, true);
        }

        private int rec(int[] piles, int start, int m, int first, int second, bool isfirst)
        {
            //int cnt = piles.Length - start, max = m << 1;
            //if (cnt <= max + 1)
            //{
            //    if (isfirst)
            //        for (int i = 0; i < max; i++) first += piles[start + i];
            //    else
            //        for (int i = start + max; i < piles.Length; i++) first += piles[i];
            //    return first;
            //}
            //else
            //{
            //    if (isfirst)
            //    {
            //        int _first = 0;
            //        for (int i = 0; i < max; i++)
            //        {
            //            int _cnt = cnt - i - 1, _m = Math.Max(m, i + 1) << 1;
            //            if (_cnt > _m + 1)
            //            {
            //                _first = Math.Max(_first, rec(piles, start+i+1,_m))
            //            }
            //        }
            //        first += _first;
            //    }
            //}

            throw new NotImplementedException();
        }
    }
}
