using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1436
{
    public class Solution1436 : Interface1436
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public string DestCity(IList<IList<string>> paths)
        {
            string result = paths[0][1];
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 1; i < paths.Count; i++) if (paths[i][0] == result)
                    {
                        result = paths[i][1]; flag = true; break;
                    }
            }

            return result;
        }
    }
}
