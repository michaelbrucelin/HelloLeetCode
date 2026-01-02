using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1476
{
    /// <summary>
    /// Your SubrectangleQueries object will be instantiated and called as such:
    /// SubrectangleQueries obj = new SubrectangleQueries(rectangle);
    /// obj.UpdateSubrectangle(row1,col1,row2,col2,newValue);
    /// int param_2 = obj.GetValue(row,col);
    /// </summary>
    public interface Interface1476
    {
        // public SubrectangleQueries(int[][] rectangle) { }

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue);

        public int GetValue(int row, int col);
    }
}
