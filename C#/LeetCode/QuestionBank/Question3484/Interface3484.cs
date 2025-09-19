using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3484
{
    /// <summary>
    /// Your Spreadsheet object will be instantiated and called as such:
    /// Spreadsheet obj = new Spreadsheet(rows);
    /// obj.SetCell(cell,value);
    /// obj.ResetCell(cell);
    /// int param_3 = obj.GetValue(formula);
    /// </summary>
    public interface Interface3484
    {
        // public Spreadsheet(int rows){}

        public void SetCell(string cell, int value);

        public void ResetCell(string cell);

        public int GetValue(string formula);
    }
}
