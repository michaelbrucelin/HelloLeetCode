using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1472
{
    public class Solution1472
    {
    }

    /// <summary>
    /// 模拟
    /// </summary>
    public class BrowserHistory : Interface1472
    {
        public BrowserHistory(string homepage)
        {
            history = new List<string> { homepage };
            idx = 0;
            cnt = 1;
        }

        private List<string> history;
        private int idx;
        private int cnt;

        public void Visit(string url)
        {
            if (history.Count > idx + 1) history[idx + 1] = url; else history.Add(url);
            idx++;
            cnt = idx + 1;
        }

        public string Back(int steps)
        {
            if (idx >= steps) idx -= steps; else idx = 0;
            return history[idx];
        }

        public string Forward(int steps)
        {
            if (cnt - idx > steps) idx += steps; else idx = cnt - 1;
            return history[idx];
        }
    }
}