using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3335
{
    public class Solution3335_2 : Interface3335
    {
        /// <summary>
        /// 数学，找规律
        /// 将每个字符独立来看
        /// a  26->2, 51->2, 52->4, 76->5, 77->7, 78->8, 101->9, 102->12, 103->15, 104->16, 126->17, 127->21, 128->27, 129->31, 130->32
        /// b  25->2, 50->3, 51->4, 75->5, 76->7, 77->8, 100->9, 101->12, 102->15, 103->16, 125->17, 126->21, 127->27, 128->31, 129->32
        /// c  24->2, 49->3, 50->4, 74->5, 75->7, 76->8, 99->9,  100->12, 101->15, 102->16, 124->17, 125->21, 126->27, 127->31, 128->32
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int LengthAfterTransformations(string s, int t)
        {
            throw new NotImplementedException();
        }
    }
}
