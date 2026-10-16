using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0382
{
    public class Solution0382_2
    {
    }

    /// <summary>
    /// 水塘抽样
    /// </summary>
    public class Solution_2 : Interface0382
    {
        public Solution_2(ListNode head)
        {
            this.head = head;
            random = new Random();
        }

        private ListNode head;
        private Random random;

        public int GetRandom()
        {
            int result = -1, idx = 0;
            ListNode ptr = head;
            while (ptr != null)
            {
                if (random.Next(idx + 1) == idx) result = ptr.val;
                idx++;
                ptr = ptr.next;
            }

            return result;
        }
    }
}
