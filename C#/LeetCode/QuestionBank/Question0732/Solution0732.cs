using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0732
{
    public class Solution0732
    {
    }

    /// <summary>
    /// 线段树
    /// </summary>
    public class MyCalendarThree : Interface0732
    {
        public MyCalendarThree()
        {
            lborder = 0;
            rborder = (int)1e9;
            tree = new Dictionary<int, int[]>();
        }

        private int lborder;
        private int rborder;
        private Dictionary<int, int[]> tree;

        public int Book(int startTime, int endTime)
        {
            Update(startTime, endTime, 1, lborder, rborder, 1);
            throw new NotImplementedException();
        }

        private void Update(int left, int right, int val, int lborder, int rborder, int idx)
        {

        }
    }
}
