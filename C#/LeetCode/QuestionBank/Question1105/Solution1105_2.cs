using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1105
{
    public class Solution1105_2 : Interface1105
    {
        /// <summary>
        /// dfs
        /// 与Solution1105一样，增加记忆化搜索，Dictionary<(int id, int width), int> memory
        ///     键是书的id，当前层剩余的宽度，值是后面所有书的高度（含当前层）
        /// 
        /// 未完成，日后有时间再做
        /// </summary>
        /// <param name="books"></param>
        /// <param name="shelfWidth"></param>
        /// <returns></returns>
        public int MinHeightShelves(int[][] books, int shelfWidth)
        {
            if (books.Length == 1) return books[0][1];

            Dictionary<(int id, int width), int> memory = new Dictionary<(int id, int width), int>();
            return books[0][1] + dfs(books, shelfWidth, books[0][1], shelfWidth - books[0][0], 1, memory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <param name="shelfWidth"></param>
        /// <param name="height">当前层的高度</param>
        /// <param name="width">当前层剩余可用的厚度</param>
        /// <param name="bookid">该放第几本书</param>
        /// <returns></returns>
        private int dfs(int[][] books, int shelfWidth, int height, int width, int bookid, Dictionary<(int id, int width), int> memory)
        {
            if (bookid == books.Length) return height;
            if (memory.ContainsKey((bookid, width))) return memory[(bookid, width)];

            int _height = books[bookid][1], _width = books[bookid][0];
            // 1. 新创建一层
            int height1 = dfs(books, shelfWidth, _height, shelfWidth - _width, bookid + 1, memory);
            // 2. 放入当前层
            if (_width <= width)
            {
                int increase = _height > height ? _height - height : 0;
                int height2 = dfs(books, shelfWidth, height + increase, width - _width, bookid + 1, memory);
                memory.Add((bookid, width), Math.Min(height1, height2));
                return Math.Min(height1, height2);
            }
            else
            {
                memory.Add((bookid, width), height1);
                return height1;
            }
        }
    }
}
