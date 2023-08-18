using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1388
{
    public class Solution1388 : Interface1388
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 将数组中的值使用 - 分割拼接为字符串作为记忆化的状态（key）
        /// 
        /// 逻辑没问题，提交会TLE，参考测试用例03
        /// </summary>
        /// <param name="slices"></param>
        /// <returns></returns>
        public int MaxSizeSlices(int[] slices)
        {
            Dictionary<string, int> memory = new Dictionary<string, int>();
            return dfs(slices, memory);
        }

        private int dfs(int[] slices, Dictionary<string, int> memory)
        {
            string key = GetKey(slices);
            if (memory.ContainsKey(key)) return memory[key];
            if (slices.Length == 0) { memory.Add("", 0); return 0; }

            int sum = 0;
            for (int i = 0; i < slices.Length; i++)
                sum = Math.Max(sum, slices[i] + dfs(CutSlices(slices, i), memory));
            memory.Add(key, sum);

            return memory[key];
        }

        private string GetKey(int[] slices)
        {
            if (slices.Length == 0) return "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < slices.Length; i++)
            {
                sb.Append(slices[i]); sb.Append('-');
            }

            return sb.ToString();
        }

        private int[] CutSlices(int[] slices, int id)
        {
            int len = slices.Length;
            int[] result = new int[len - 3];
            if (len == 3) return result;

            if (id == 0)
                Array.Copy(slices, 2, result, 0, len - 3);
            else if (id == 1)
                Array.Copy(slices, 3, result, 0, len - 3);
            else if (id == len - 1)
                Array.Copy(slices, 1, result, 0, len - 3);
            else if (id == len - 2)
                Array.Copy(slices, 0, result, 0, len - 3);
            else
            {
                for (int i = 0; i < id - 1; i++) result[i] = slices[i];
                for (int i = id + 2; i < len; i++) result[i - 3] = slices[i];
            }

            return result;
        }
    }
}
