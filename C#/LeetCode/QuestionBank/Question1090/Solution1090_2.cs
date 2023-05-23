using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1090
{
    public class Solution1090_2 : Interface1090
    {
        /// <summary>
        /// 暴力
        /// 思路与Solution1090一样，暴力解一次试试
        /// 
        /// 逻辑没有问题，提交果然超时了
        /// 国际版可以通过，国内版提交最后一个（第81个）测试用例超时
        /// </summary>
        /// <param name="values"></param>
        /// <param name="labels"></param>
        /// <param name="numWanted"></param>
        /// <param name="useLimit"></param>
        /// <returns></returns>
        public int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit)
        {
            int result = 0;
            List<int> _values = new List<int>(values), _labels = new List<int>(labels);
            Dictionary<int, int> use = new Dictionary<int, int>();
            while (numWanted-- > 0)
            {
                int maxid = -1;
                for (int i = 0; i < _values.Count; i++)
                {
                    if (use.ContainsKey(_labels[i]))
                    {
                        if (use[_labels[i]] < useLimit)
                        {
                            if (maxid == -1 || _values[i] > _values[maxid]) maxid = i;
                        }
                        else
                        {
                            _values.RemoveAt(i); _labels.RemoveAt(i); i--;
                        }
                    }
                    else
                    {
                        if (maxid == -1 || _values[i] > _values[maxid]) maxid = i;
                    }
                }
                if (maxid == -1) break;

                result += _values[maxid];
                if (use.ContainsKey(_labels[maxid])) use[_labels[maxid]]++; else use.Add(_labels[maxid], 1);
                _values.RemoveAt(maxid); _labels.RemoveAt(maxid);
            }

            return result;
        }
    }
}
