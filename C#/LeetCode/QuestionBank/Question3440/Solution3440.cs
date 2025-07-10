using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3440
{
    public class Solution3440 : Interface3440
    {
        /// <summary>
        /// 排序
        /// 1. 统计出所有的“间隙”
        /// 2. 将结果初始化相邻“间隙”和的最大值
        /// 3. 将间隙按“大小”降序排序
        /// 4. 枚举每个会议，尝试将其移走（放入最大间隙）
        /// </summary>
        /// <param name="eventTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
        {
            if (startTime.Length == 1) return eventTime + startTime[0] - endTime[0];

            int result = 0, len = startTime.Length;
            List<(int gap, int l, int r)> gaps = new List<(int gap, int l, int r)>();
            gaps.Add((startTime[0], 0, startTime[0]));
            for (int i = 1; i < len; i++) gaps.Add((startTime[i] - endTime[i - 1], endTime[i - 1], startTime[i]));
            gaps.Add((eventTime - endTime[^1], endTime[^1], eventTime));
            for (int i = 0; i < len; i++) result = Math.Max(result, gaps[i].gap + gaps[i + 1].gap);

            // 前3个间隙一定有不相邻的间隙，所以不用排序
            (int gap, int l, int r)[] top3 = new (int gap, int l, int r)[3];
            top3[0] = top3[1] = top3[2] = (-1, -1, -1);
            foreach (var item in gaps)
            {
                if (item.gap > top3[0].gap)
                {
                    top3[2] = top3[1]; top3[1] = top3[0]; top3[0] = item;
                }
                else if (item.gap > top3[1].gap)
                {
                    top3[2] = top3[1]; top3[1] = item;
                }
                else if (item.gap > top3[2].gap)
                {
                    top3[2] = item;
                }
            }
            // 尝试将每个会议移走
            for (int i = 0; i < len; i++) for (int j = 0; j < 3; j++)
                {
                    if (top3[j].r != startTime[i] && top3[j].l != endTime[i])
                    {
                        if (top3[j].gap >= endTime[i] - startTime[i]) result = Math.Max(result, gaps[i].gap + gaps[i + 1].gap + endTime[i] - startTime[i]);
                        break;
                    }
                }

            return result;
        }
    }
}
