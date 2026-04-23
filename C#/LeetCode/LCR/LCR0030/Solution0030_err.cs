using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0030
{
    public class Solution0030_err
    {
    }

    /// <summary>
    /// 堆 + 懒删除，但是不是O(1)，是O(logn)
    /// 
    /// 提交提示错误，参考测试用例02
    /// 看输出的结果，GetRandom()的结果分布及其不均匀，但是实在看不出代码（忽略时间复杂度）有什么问题，先不管了
    /// 
    /// 想明白为什么错了，经典错误，再次印证要先有数学证明才可以，解释见Solution0030_err.md
    /// </summary>
    public class RandomizedSet : Interface0030
    {
        public RandomizedSet()
        {
            set = new HashSet<int>();
            minpq = new PriorityQueue<int, double>();
            random = new Random();
        }

        private HashSet<int> set;
        private PriorityQueue<int, double> minpq;
        private Random random;

        public bool Insert(int val)
        {
            if (set.Add(val))
            {
                minpq.Enqueue(val, random.NextDouble());
                return true;
            }
            return false;
        }

        public bool Remove(int val)
        {
            return set.Remove(val);
        }

        public int GetRandom()
        {
            int x = minpq.Dequeue();
            while (!set.Contains(x)) x = minpq.Dequeue();
            minpq.Enqueue(x, random.NextDouble());
            return x;
        }
    }
}
