using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1717
{
    public class Solution1717_2 : Interface1717
    {
        /// <summary>
        /// 链表
        /// 思路与Solution1717完全一致，这里使用链表代替数据，这样删除的动作执行的会更快
        /// 
        /// TLE，参考测试用例03，下面的MaximumGain2()做了优化
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MaximumGain(string s, int x, int y)
        {
            LinkedList<char> list = new LinkedList<char>(s);
            list.AddFirst(new LinkedListNode<char>('\0'));    // 哨兵
            (char c, int score)[] infos;
            if (x >= y) infos = [('a', x), ('b', y)]; else infos = [('b', y), ('a', x)];

            int result = 0;
            LinkedListNode<char> ptr;
            bool flag;
            foreach (var info in infos)
            {
                flag = true;
                while (flag)
                {
                    flag = false;
                    ptr = list.First;
                    while (ptr != null)
                    {
                        if (ptr.Value == info.c && ptr.Next != null && ptr.Value + ptr.Next.Value == 195)
                        {
                            result += info.score;
                            flag = true;
                            ptr = ptr.Previous;
                            list.Remove(ptr.Next);
                            list.Remove(ptr.Next);
                        }
                        ptr = ptr.Next;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 这次快了很多，如果是aaabbb的形式，MaximumGain()的时间复杂度是O(n^2)，而这里是O(n)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MaximumGain2(string s, int x, int y)
        {
            LinkedList<char> list = new LinkedList<char>(s);
            list.AddFirst(new LinkedListNode<char>('\0'));    // 哨兵
            (char c, int score)[] infos;
            if (x >= y) infos = [('a', x), ('b', y)]; else infos = [('b', y), ('a', x)];

            int result = 0;
            LinkedListNode<char> ptr;
            bool flag;
            foreach (var info in infos)
            {
                flag = true;
                while (flag)
                {
                    flag = false;
                    ptr = list.First;
                    while (ptr != null)
                    {
                        if (ptr.Value == info.c && ptr.Next != null && ptr.Value + ptr.Next.Value == 195)
                        {
                            result += info.score;
                            flag = true;
                            ptr = ptr.Previous;
                            list.Remove(ptr.Next);
                            list.Remove(ptr.Next);
                        }
                        else
                        {
                            ptr = ptr.Next;
                        }
                    }
                }
            }

            return result;
        }
    }
}
