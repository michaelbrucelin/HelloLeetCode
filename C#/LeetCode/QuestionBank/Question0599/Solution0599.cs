﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0599
{
    public class Solution0599 : Interface0599
    {
        /// <summary>
        /// 遍历
        /// 如果两个数组分别是矩阵的横纵坐标，那么按照反斜线方向遍历矩阵即可
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            List<string> result = new List<string>();
            int len1 = list1.Length, len2 = list2.Length;
            bool found = false;
            for (int sum = 0; sum < len1 + len2 - 1; sum++)
            {
                for (int i = 0; i <= sum && i < len1; i++)
                {
                    if (sum - i < len2 && list1[i] == list2[sum - i])
                    {
                        result.Add(list1[i]); found = true;
                    }
                }
                if (found) break;
            }

            return result.ToArray();
        }
    }
}
