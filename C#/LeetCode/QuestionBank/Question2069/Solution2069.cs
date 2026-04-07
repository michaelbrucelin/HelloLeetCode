using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2069
{
    public class Solution2069
    {
    }

    public class Robot
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Robot(int width, int height)
        {
            steps = [width - 1, height - 1, width - 1, height - 1];
            dirx = [1, 0, -1, 0];
            diry = [0, 1, 0, -1];
            dirs = ["East", "North", "West", "South"];
            x = y = 0;
            step = width - 1;
            circle = (width << 1) + (height << 1) - 4;
            idx = 0;
        }

        private int[] steps, dirx, diry;
        private string[] dirs;
        private int x, y, step, circle, idx;

        public void Step(int num)
        {
            if (num % circle != 0) num %= circle;  // 整圈数拐角处的方向需要单独处理，这里就直接单跑一圈
            while (num > 0)
            {
                if (num <= step)
                {
                    step -= num;
                    x += num * dirx[idx]; y += num * diry[idx];
                    num = 0;
                }
                else
                {
                    num -= step;
                    x += step * dirx[idx]; y += step * diry[idx];
                    idx = (idx + 1) & 3;                           // 转方向
                    step = steps[idx];
                }
            }
        }

        public int[] GetPos()
        {
            return [x, y];
        }

        public string GetDir()
        {
            return dirs[idx];
        }
    }
}
