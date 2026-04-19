using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3044
{
    public class Solution3044 : Interface3044
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int MostFrequentPrime(int[][] mat)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int rcnt = mat.Length, ccnt = mat[0].Length;
            for (int r = 0, num, _r, _c; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    for (int ri = -1; ri <= 1; ri++) for (int ci = -1; ci <= 1; ci++) if (ri != 0 || ci != 0)
                            {
                                num = mat[r][c];
                                for (int i = 1; ; i++)
                                {
                                    _r = r + ri * i; _c = c + ci * i;
                                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt)
                                    {
                                        num = num * 10 + mat[_r][_c];
                                        map.TryAdd(num, 0); map[num]++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                }

            int result = -1, cnt = 0;
            foreach (int x in map.Keys) if ((map[x] > cnt || (map[x] == cnt && x > result)) && is_prime(x))
                {
                    result = x; cnt = map[x];
                }
            return result;

            static bool is_prime(int n)
            {
                if (n <= 1) return false;
                if (n == 2) return true;
                if ((n & 1) == 0) return false;

                int boundary = (int)Math.Floor(Math.Sqrt(n));
                for (int i = 3; i <= boundary; i += 2) if (n % i == 0) return false;

                return true;
            }
        }
    }
}
