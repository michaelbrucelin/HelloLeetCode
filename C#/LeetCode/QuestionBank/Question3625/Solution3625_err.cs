using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3625
{
    public class Solution3625_err : Interface3625
    {
        /// <summary>
        /// 按斜率分组，排列组合
        /// 1. 两点确立一条直线，ax+by+c=0，令a>=0，a b c无公约数
        ///        则直接可以用(a,b,c)表示，斜率可以用(a,b)表示
        /// 2. 数据结构Dictionary<(int,int), Dictionary<int,int>> info
        ///        外层key(a,b)表示斜率，内层key(c)表示直线，内层val表示数量
        /// 3. 枚举每两个点的组合，将其记录到上面的info中
        ///        相同斜率 + 不同直线，即可构成一个梯形
        /// 4. 已知两点(x1,y1), (x2,y2)
        ///        如果x1 = x2, 则x = x1, 即(1, 0, -x1)
        ///        如果y1 = y2, 则y = y1, 即(0, 1, -y1)
        ///        否则，(y1-y2)x+(x2-x1)y+(x1y2-x2y1)=0，则(y1-y2, x2-x1, x1y2-x2y1)
        /// 
        /// 思路整体是正确的，但是忽略了平行四边形计算了两次，参考测试用例03,04
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int CountTrapezoids(int[][] points)
        {
            Dictionary<(int, int), Dictionary<int, int>> info = new Dictionary<(int, int), Dictionary<int, int>>();
            int x1, y1, x2, y2, a, b, c, gcd, n = points.Length;
            (int, int) key1; int key2;
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    x1 = points[i][0]; y1 = points[i][1]; x2 = points[j][0]; y2 = points[j][1];
                    switch ((x1 - x2, y1 - y2))
                    {
                        case (0, _):
                            key1 = (1, 0); key2 = -x1;
                            break;
                        case (_, 0):
                            key1 = (0, 1); key2 = -y1;
                            break;
                        default:
                            a = y1 - y2; b = x2 - x1; c = x1 * y2 - x2 * y1;
                            if (a < 0) { a = -a; b = -b; c = -c; }
                            gcd = _gcd(a, Math.Abs(b)); if (c != 0) gcd = _gcd(gcd, Math.Abs(c));
                            a /= gcd; b /= gcd; c /= gcd;
                            key1 = (a, b); key2 = c;
                            break;
                    }
                    if (info.TryGetValue(key1, out var _info))
                    {
                        if (_info.TryGetValue(key2, out int val)) _info[key2] = ++val; else _info.Add(key2, 1);
                    }
                    else
                    {
                        info.Add(key1, new Dictionary<int, int>() { { key2, 1 } });
                    }
                }

            int result = 0, total;
            foreach (var _info in info.Values)
            {
                if (_info.Count == 1) continue;
                total = 0;
                foreach (int val in _info.Values) total += val;
                foreach (int val in _info.Values) result += val * (total - val);
            }

            return result >> 1;

            static int _gcd(int x, int y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }

                return x << move;
            }
        }
    }
}
