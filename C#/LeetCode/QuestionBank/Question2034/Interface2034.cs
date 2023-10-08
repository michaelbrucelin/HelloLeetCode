using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2034
{
    /// <summary>
    /// Your StockPrice object will be instantiated and called as such:
    /// StockPrice obj = new StockPrice();
    /// obj.Update(timestamp,price);
    /// int param_2 = obj.Current();
    /// int param_3 = obj.Maximum();
    /// int param_4 = obj.Minimum();

    /// </summary>
    public interface Interface2034
    {
        public void Update(int timestamp, int price);

        public int Current();

        public int Maximum();

        public int Minimum();
    }
}
