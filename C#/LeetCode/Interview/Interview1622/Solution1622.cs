using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1622
{
    public class Solution1622 : Interface1622
    {
        /// <summary>
        /// 状态机
        /// 没写完，以后再写
        /// </summary>
        /// <param name="K"></param>
        /// <returns></returns>
        public IList<string> PrintKMoves(int K)
        {
            Dictionary<(char, char), (int, int, char)> _map = new Dictionary<(char, char), (int, int, char)>()
            {
                {('_','R'),(1,0,'D')},{('_','D'),(0,-1,'L')},{('_','L'),(-1,0,'U')},{('_','U'),(0,1,'R')},
                {('X','R'),(-1,0,'U')},{('X','U'),(0,-1,'L')},{('X','L'),(1,0,'D')},{('X','D'),(0,1,'R')}
            };
            FrozenDictionary<(char, char), (int, int, char)> map = _map.ToFrozenDictionary();

            List<char[]> buffer = new List<char[]>();
            int len = 1;


            List<string> result = new List<string>();
            foreach (char[] chars in buffer) result.Add(new string(chars, 0, len));
            return result;
        }
    }
}
