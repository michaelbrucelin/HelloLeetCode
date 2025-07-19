using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1233
{
    public class Solution1233_2 : Interface1233
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public IList<string> RemoveSubfolders(string[] folder)
        {
            if (folder.Length == 1) return folder;

            List<string> result = new List<string>();
            Array.Sort(folder);
            result.Add(folder[0]);
            int len = folder.Length;
            for (int i = 1; i < len; i++) if (!$"{folder[i]}/".StartsWith($"{result[^1]}/")) result.Add(folder[i]);

            return result;
        }
    }
}
