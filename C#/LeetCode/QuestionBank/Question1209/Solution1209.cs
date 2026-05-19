using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1209
{
    public class Solution1209 : Interface1209
    {
        /// <summary>
        /// 模拟
        /// 使用双链表模拟，链表节点记录连续字符的数量
        /// 
        /// TLE？参考测试用例04，提交TLE了，不应该啊，猜测是双链表比栈慢，用栈再试试
        /// 改为栈后速度明显快多了，甚至还多了一步操作（反转栈），显然C#中的双链表的开销比栈大多了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string s, int k)
        {
            if (k == 1) return "";
            if (s.Length == 1) return s;

            LinkedList<(char, int)> list = new LinkedList<(char, int)>();
            char chr = '\0', c; int cnt = -1, len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if ((c = s[i]) == chr)
                {
                    cnt++;
                }
                else
                {
                    if ((cnt %= k) != 0)
                    {
                        list.AddLast((chr, cnt));
                        chr = c; cnt = 1;
                    }
                    else
                    {
                        if (c == list.Last().Item1)
                        {
                            (chr, cnt) = list.Last();
                            cnt++;
                            list.RemoveLast();
                        }
                        else
                        {
                            chr = c; cnt = 1;
                        }
                    }
                }
            }
            cnt %= k;
            list.AddLast((chr, cnt));

            StringBuilder buffer = new StringBuilder();
            LinkedListNode<(char, int)> ptr = list.First;
            while (ptr != null)
            {
                (chr, cnt) = ptr.Value;
                for (int i = 0; i < cnt; i++) buffer.Append(chr);
                ptr = ptr.Next;
            }

            return buffer.ToString();
        }
    }
}
