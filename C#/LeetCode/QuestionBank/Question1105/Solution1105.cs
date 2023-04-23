using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1105
{
    public class Solution1105 : Interface1105
    {
        /// <summary>
        /// dfs
        /// 每一本新书有两种选择：
        ///     1. 放到当前层中（如果可以放得下的话）
        ///     2. 新建一层
        /// 太慢，参考测试用例04，本机测试没有跑出结果（等待了15分钟）
        /// </summary>
        /// <param name="books"></param>
        /// <param name="shelfWidth"></param>
        /// <returns></returns>
        public int MinHeightShelves(int[][] books, int shelfWidth)
        {
            if (books.Length == 1) return books[0][1];
            return dfs(books, shelfWidth, books[0][1], books[0][1], shelfWidth - books[0][0], 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <param name="shelfWidth"></param>
        /// <param name="heightTotal">已经积累的高度</param>
        /// <param name="height">当前层的高度</param>
        /// <param name="width">当前层剩余可用的厚度</param>
        /// <param name="bookid">该放第几本书</param>
        /// <returns></returns>
        private int dfs(int[][] books, int shelfWidth, int heightTotal, int height, int width, int bookid)
        {
            if (bookid == books.Length) return heightTotal;

            int _height = books[bookid][1], _width = books[bookid][0];
            // 1. 新创建一层
            int height1 = dfs(books, shelfWidth, heightTotal + _height, _height, shelfWidth - _width, bookid + 1);
            // 2. 放入当前层
            if (_width <= width)
            {
                int increase = _height > height ? _height - height : 0;
                int height2 = dfs(books, shelfWidth, heightTotal + increase, height + increase, width - _width, bookid + 1);
                return Math.Min(height1, height2);
            }
            else
            {
                return height1;
            }
        }
    }
}
