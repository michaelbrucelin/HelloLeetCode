using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2034
{
    public class Solution2034
    {
    }

    /// <summary>
    /// 双字典
    /// Dictionary<int, int>        key 时间戳 value 价格
    /// SortedDictionary<int, int>  key 价格   value 该价格的数量
    /// 
    /// 超出时间限制了，没想明白为什么会TLE
    /// </summary>
    public class StockPrice : Interface2034
    {
        public StockPrice()
        {
            t2p = new Dictionary<int, int>();
            p2t = new SortedDictionary<int, int>();
            cur_time = -1;
        }

        private Dictionary<int, int> t2p;
        private SortedDictionary<int, int> p2t;
        private int cur_time;

        public int Current()
        {
            return t2p[cur_time];
        }

        public int Maximum()
        {
            return p2t.Last().Key;   // 题目确保了p2t不为空
        }

        public int Minimum()
        {
            return p2t.First().Key;  // 题目确保了p2t不为空
        }

        public void Update(int timestamp, int price)
        {
            if (timestamp >= cur_time) cur_time = timestamp;

            if (t2p.ContainsKey(timestamp))  // update
            {
                int _price = t2p[timestamp];
                t2p[timestamp] = price;
                if (p2t.ContainsKey(price)) p2t[price]++; else p2t.Add(price, 1);
                if (p2t[_price] != 1) p2t[_price]--; else p2t.Remove(_price);
            }
            else                             // insert
            {
                t2p.Add(timestamp, price);
                if (p2t.ContainsKey(price)) p2t[price]++; else p2t.Add(price, 1);
            }
        }
    }
}
