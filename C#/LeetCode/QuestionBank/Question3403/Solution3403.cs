using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3403
{
    public class Solution3403 : Interface3403
    {
        /// <summary>
        /// BFS
        /// 1. 假定word长度为m，分成n份，那么最长为m-n+1
        /// 2. BFS，每一轮使用大顶堆来记录当前字符
        /// 
        /// 思想上就是N个指针齐头并进，每前进一步淘汰掉一些
        /// </summary>
        /// <param name="word"></param>
        /// <param name="numFriends"></param>
        /// <returns></returns>
        public string AnswerString(string word, int numFriends)
        {
            if (numFriends == 1) return word;

            int len = word.Length;
            char maxchar = word[0];
            for (int i = 1; i < len; i++) maxchar = (char)Math.Max(maxchar, word[i]);
            int maxlen = len - numFriends + 1;
            if (maxlen == 1) return maxchar.ToString();

            PriorityQueue<(int start, int curr), int> queue = new PriorityQueue<(int start, int curr), int>();
            for (int i = 0; i < len; i++) if (word[i] == maxchar) queue.Enqueue((i, i), -maxchar);
            if (queue.Count == 1) return word.Substring(queue.Peek().start, Math.Min(maxlen, len - queue.Peek().start));

            string _word = $"{word}A";                         // 添加一个哨兵字符，方便处理
            PriorityQueue<(int start, int curr), int> _queue;
            char _maxchar, _itemchar; (int start, int curr) item; int _len;
            for (_len = 1; _len < maxlen; _len++)
            {
                if (queue.Count == 1) return word.Substring(queue.Peek().start, Math.Min(maxlen, len - queue.Peek().start));
                _maxchar = _word[queue.Peek().curr];
                _queue = new PriorityQueue<(int start, int curr), int>();
                while (queue.Count > 0)
                {
                    item = queue.Dequeue();
                    if ((_itemchar = _word[item.curr]) < _maxchar) break;
                    _queue.Enqueue((item.start, item.curr + 1), -_word[item.curr + 1]);
                }
                queue = _queue;
            }

            return word.Substring(queue.Peek().start, Math.Min(maxlen, len - queue.Peek().start));
        }
    }
}
