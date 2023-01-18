using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1825
{
    public class Solution1825
    {
    }

    /// <summary>
    /// 用队列存储最后添加的m个元素
    /// 用List存储m个排列的元素，使用API排序
    /// 
    /// 提交会超时，参考测试用例3
    /// </summary>
    public class MKAverage : Interface1825
    {
        public MKAverage(int m, int k)
        {
            this.m = m;
            this.k = k;
            queue = new Queue<int>();
            list = new List<int>();
        }

        private int m, k;
        private Queue<int> queue;
        private List<int> list;

        public void AddElement(int num)
        {
            if (queue.Count < m)
            {
                queue.Enqueue(num); list.Add(num);
                if (list.Count == m) list.Sort();
            }
            else
            {
                list.Remove(queue.Dequeue());
                queue.Enqueue(num); list.Add(num);
                list.Sort();
            }
        }

        public int CalculateMKAverage()
        {
            if (queue.Count < m) return -1;
            else
            {
                int sum = 0;
                for (int i = k; i < m - k; i++) sum += list[i];
                return sum / (m - (k << 1));
            }
        }
    }
}
