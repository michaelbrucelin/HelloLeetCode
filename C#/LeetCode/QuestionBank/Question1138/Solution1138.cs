using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1138
{
    public class Solution1138 : Interface1138
    {
        private static readonly (int row, int col)[] map = new (int row, int col)[] {
              (0, 0), (0, 1), (0, 2), (0, 3), (0, 4)
            , (1, 0), (1, 1), (1, 2), (1, 3), (1, 4)
            , (2, 0), (2, 1), (2, 2), (2, 3), (2, 4)
            , (3, 0), (3, 1), (3, 2), (3, 3), (3, 4)
            , (4, 0), (4, 1), (4, 2), (4, 3), (4, 4)
            , (5, 0) };

        /// <summary>
        /// 分析
        /// 1. 本质上就是将字母换算为坐标，然后比较横纵坐标即可
        /// 2. 将a-z映射为0-25，id/5是横坐标，id%5是纵坐标
        /// 
        /// 需要注意的是，向上与向左不会越界，而向下与向右有可能越界
        /// 所以移动时，优先向上与向左的移动，然后再向下与向右移动，如果目标需要同时向下与向右移动，可以看到此时一定不会越界
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string AlphabetBoardPath(string target)
        {
            List<char> result = new List<char>();
            (int row, int col) prev = (0, 0);
            for (int i = 0; i < target.Length; i++)
            {
                var curr = map[target[i] - 'a'];
                if (curr.row < prev.row) for (int j = 0; j < prev.row - curr.row; j++) result.Add('U');
                if (curr.col < prev.col) for (int j = 0; j < prev.col - curr.col; j++) result.Add('L');
                if (curr.row > prev.row) for (int j = 0; j < curr.row - prev.row; j++) result.Add('D');
                if (curr.col > prev.col) for (int j = 0; j < curr.col - prev.col; j++) result.Add('R');
                result.Add('!');
                prev = curr;
            }

            return new string(result.ToArray());
        }

        /// <summary>
        /// 将char列表换成StringBuilder试试
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string AlphabetBoardPath2(string target)
        {
            StringBuilder result = new StringBuilder();
            (int row, int col) prev = (0, 0);
            for (int i = 0; i < target.Length; i++)
            {
                var curr = map[target[i] - 'a'];
                if (curr.row < prev.row) for (int j = 0; j < prev.row - curr.row; j++) result.Append('U');
                if (curr.col < prev.col) for (int j = 0; j < prev.col - curr.col; j++) result.Append('L');
                if (curr.row > prev.row) for (int j = 0; j < curr.row - prev.row; j++) result.Append('D');
                if (curr.col > prev.col) for (int j = 0; j < curr.col - prev.col; j++) result.Append('R');
                result.Append('!');
                prev = curr;
            }

            return result.ToString();
        }

        public string AlphabetBoardPath3(string target)
        {
            StringBuilder result = new StringBuilder();
            (int row, int col) prev = (0, 0);
            for (int i = 0; i < target.Length; i++)
            {
                var curr = map[target[i] - 'a'];
                if (curr.row < prev.row) result.Append(new string('U', prev.row - curr.row));
                if (curr.col < prev.col) result.Append(new string('L', prev.col - curr.col));
                if (curr.row > prev.row) result.Append(new string('D', curr.row - prev.row));
                if (curr.col > prev.col) result.Append(new string('R', curr.col - prev.col));
                result.Append('!');
                prev = curr;
            }

            return result.ToString();
        }
    }
}
