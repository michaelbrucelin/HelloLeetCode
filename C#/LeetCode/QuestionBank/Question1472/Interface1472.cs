using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1472
{
    /// <summary>
    /// Your BrowserHistory object will be instantiated and called as such:
    /// BrowserHistory obj = new BrowserHistory(homepage);
    /// obj.Visit(url);
    /// string param_2 = obj.Back(steps);
    /// string param_3 = obj.Forward(steps);
    /// </summary>
    public interface Interface1472
    {
        // public BrowserHistory(string homepage) { }

        public void Visit(string url);

        public string Back(int steps);

        public string Forward(int steps);
    }
}
