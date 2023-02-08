using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1233
{
    public class Solution1233 : Interface1233
    {
        /// <summary>
        /// 排序 + 双指针
        /// 1. 将所有folder排序
        /// 2. 使用快慢指针
        ///         如果慢指针是快指针的前缀，  那么慢指针不动，快指针指向下一个目录
        ///         如果慢指针不是快指针的前缀，那么慢指针指向的目录加入结果，并将慢指针指向快指针，快指针指向下一个目录
        /// 
        /// folder = ["/a","/a/b","/c/d","/c/d/e","/c/f"]  ["/a/","/a/b","/c/d/","/c/d/e","/c/f"]
        /// 预期结果 ["/a",       "/c/d",         "/c/f"]  ["/a/","/a/b","/c/d/","/c/d/e","/c/f"]
        /// 由上面的示例知，题目不会处理结尾带"/"的目录
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public IList<string> RemoveSubfolders(string[] folder)
        {
            if (folder.Length == 1) return folder;

            List<string> result = new List<string>();
            Array.Sort(folder, StringComparer.Ordinal);
            int slow = 0, fast = 1, len = folder.Length;
            while (fast < len)
            {
                if (folder[fast].StartsWith($"{folder[slow]}/"))  // 由于测试知题目不处理/a/这种目录，所以这里这样直接补一个"/"是正确的
                {
                    fast++;
                }
                else
                {
                    result.Add(folder[slow]); slow = fast; fast++;
                }
            }
            result.Add(folder[slow]);

            return result;
        }
    }
}
