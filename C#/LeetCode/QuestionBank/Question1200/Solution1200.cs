using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1200
{
    public class Solution1200 : Interface1200
    {
        /// <summary>
        /// 排序 + 遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(arr);
            int min = arr[1] - arr[0], len = arr.Length;
            for (int i = 2; i < len; i++) min = Math.Min(min, arr[i] - arr[i - 1]);
            for (int i = 1; i < len; i++)
                if (arr[i] - arr[i - 1] == min) result.Add(new int[] { arr[i - 1], arr[i] });

            return result;
        }

        /// <summary>
        /// 与MinimumAbsDifference()一样，这里将上面的两次遍历改为一次遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public IList<IList<int>> MinimumAbsDifference2(int[] arr)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(arr);
            int min = arr[1] - arr[0], len = arr.Length;
            result.Add(new int[] { arr[0], arr[1] });
            for (int i = 2, _diff; i < len; i++)
            {
                _diff = arr[i] - arr[i - 1];
                if (_diff < min)
                {
                    result.Clear(); result.Add(new int[] { arr[i - 1], arr[i] });
                    min = _diff;
                }
                else if (_diff == min)
                {
                    result.Add(new int[] { arr[i - 1], arr[i] });
                }
            }

            return result;
        }
    }
}
