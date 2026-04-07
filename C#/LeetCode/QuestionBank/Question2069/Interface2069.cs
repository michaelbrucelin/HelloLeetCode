using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2069
{
    /// <summary>
    /// Your Robot object will be instantiated and called as such:
    /// Robot obj = new Robot(width, height);
    /// obj.Step(num);
    /// int[] param_2 = obj.GetPos();
    /// string param_3 = obj.GetDir();
    /// </summary>
    public interface Interface2069
    {
        // public Robot(int width, int height) { }

        public void Step(int num);

        public int[] GetPos();

        public string GetDir();
    }
}
