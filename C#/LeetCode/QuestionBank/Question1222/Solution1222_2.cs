using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1222
{
    public class Solution1222_2 : Interface1222
    {
        /// <summary>
        /// 遍历
        /// 相当于找出8个不同标准的最大值或最小值
        /// </summary>
        /// <param name="queens"></param>
        /// <param name="king"></param>
        /// <returns></returns>
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            Dictionary<string, int[]> map = new Dictionary<string, int[]> {
                { "left", null }, { "right", null }, { "up", null }, { "down", null },
                { "left_up", null }, { "right_down", null }, { "right_up", null }, { "left_down", null } };
            foreach (var arr in queens)
            {
                if (arr[0] == king[0])                          // 垂直
                {
                    if (arr[1] > king[1])                       // 上
                    {
                        if (map["up"] == null || map["up"][1] > arr[1]) map["up"] = arr;
                    }
                    else                                        // 下
                    {
                        if (map["down"] == null || map["down"][1] < arr[1]) map["down"] = arr;
                    }
                }
                else if (arr[1] == king[1])                     // 水平
                {
                    if (arr[0] > king[0])                       // 右
                    {
                        if (map["right"] == null || map["right"][0] > arr[0]) map["right"] = arr;
                    }
                    else                                        // 左
                    {
                        if (map["left"] == null || map["left"][0] < arr[0]) map["left"] = arr;
                    }
                }
                else if (arr[0] + arr[1] == king[0] + king[1])  // 反对角线
                {
                    if (arr[0] > king[0])                       // 右上
                    {
                        if (map["right_up"] == null || map["right_up"][0] > arr[0]) map["right_up"] = arr;
                    }
                    else                                        // 左下
                    {
                        if (map["left_down"] == null || map["left_down"][0] < arr[0]) map["left_down"] = arr;
                    }
                }
                else if (arr[0] - king[0] == arr[1] - king[1])  // 对角线
                {
                    if (arr[0] > king[0])                       // 右下
                    {
                        if (map["right_down"] == null || map["right_down"][0] > arr[0]) map["right_down"] = arr;
                    }
                    else                                        // 左上
                    {
                        if (map["left_up"] == null || map["left_up"][0] < arr[0]) map["left_up"] = arr;
                    }
                }
            }

            IList<IList<int>> result = new List<IList<int>>();
            foreach (var arr in map.Values) if (arr != null) result.Add(arr);

            return result;
        }
    }
}
