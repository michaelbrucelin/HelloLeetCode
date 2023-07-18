using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1851
{
    public class Solution1851 : Interface1851
    {
        /// <summary>
        /// 数据结构
        /// 预处理int[][] intervals，使之可以更快的被查询
        /// 1. 将int[][] intervals转为SortedDictionary<int, List<int>>
        ///     1.1. 字典的key是区间的长度，即right - left + 1
        ///     1.2. 字典的值是长度为key的区间的左端点，并升序排序
        /// 2. 查询某个整数n时
        ///     2.1. key从小到达遍历
        ///     2.2. 每个key对应的区间的左端点升序，且区间长度相等，所以可以二分查找
        /// 
        /// 逻辑没错，超时，草靠测试用例03
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] MinInterval(int[][] intervals, int[] queries)
        {
            SortedDictionary<int, List<int>> db = new SortedDictionary<int, List<int>>();
            foreach (int[] interval in intervals)
            {
                int key = interval[1] - interval[0] + 1;
                if (db.ContainsKey(key)) db[key].Add(interval[0]); else db.Add(key, new List<int>() { interval[0] });
            }
            foreach (int key in db.Keys) db[key].Sort();

            int len = queries.Length;
            int[] result = new int[len];
            Array.Fill(result, -1);
            for (int i = 0, query; i < len; i++)
            {
                query = queries[i];
                foreach (int cnt in db.Keys)
                {
                    List<int> lefts = db[cnt];
                    if (query < lefts[0] || query >= lefts[^1] + cnt) continue;
                    int left = 0, right = lefts.Count - 1, mid;
                    while (left <= right)
                    {
                        mid = left + ((right - left) >> 1);
                        if (lefts[mid] + cnt - 1 < query) left = mid + 1;
                        else if (lefts[mid] > query) right = mid - 1;
                        else { result[i] = cnt; goto Found; }
                    }
                }
                Found:;
            }

            return result;
        }
    }
}
