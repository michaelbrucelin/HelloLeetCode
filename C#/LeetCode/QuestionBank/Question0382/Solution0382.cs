using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0382
{
    public class Solution0382
    {
    }

    /// <summary>
    /// 随机
    /// 转成List然后随机
    /// </summary>
    public class Solution : Interface0382
    {
        public Solution(ListNode head)
        {
            random = new Random();
            list = [];
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr.val); ptr = ptr.next; }
            n = list.Count;
        }

        private Random random;
        private List<int> list;
        private int n;

        public int GetRandom()
        {
            return list[random.Next(n)];
        }
    }
}
