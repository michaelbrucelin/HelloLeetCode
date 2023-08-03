using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0722
{
    public class Solution0722 : Interface0722
    {
        /// <summary>
        /// 模拟
        /// 把所有代码合并为一个字符串，每一行中间用\n隔开，这样代码比较好处理
        /// 从第一个合并后的字符开始遍历，每个字符都放入缓冲区，直至：
        ///     1. 遇到 \n ，将缓冲区的结果写入结果，清空缓冲区，继续向后处理
        ///     2. 遇到 // ，将缓冲区的结果写入结果，清空缓冲区，从后面第一个 \n 后继续向后处理
        ///     3. 遇到 /* ，向后找到第一个 */，之间的字符舍弃，继续向后处理
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IList<string> RemoveComments(string[] source)
        {
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < source.Length; i++) buffer.Append($"{source[i]}\n");

            List<string> result = new List<string>();
            StringBuilder line = new StringBuilder();
            int ptr = 0, len = buffer.Length;
            while (ptr < len)
            {
                switch (buffer[ptr])
                {
                    case '\n':
                        if (line.Length > 0) { result.Add(line.ToString()); line.Clear(); }
                        ptr++;
                        break;
                    case '/':
                        if (ptr < len - 1) switch (buffer[ptr + 1])
                            {
                                case '/':
                                    if (line.Length > 0) { result.Add(line.ToString()); line.Clear(); }
                                    while (buffer[ptr++] != '\n') ;
                                    break;
                                case '*':
                                    ptr += 2;
                                    while (buffer[ptr] != '*' || buffer[ptr + 1] != '/') ptr++;  // 题目保证了块注释一定闭合，所里这里不验证ptr是否越界
                                    ptr += 2;
                                    break;
                                default:
                                    line.Append(buffer[ptr++]);
                                    break;
                            }
                        else line.Append(buffer[ptr++]);
                        break;
                    default:
                        line.Append(buffer[ptr++]);
                        break;
                }
            }

            return result;
        }
    }
}
