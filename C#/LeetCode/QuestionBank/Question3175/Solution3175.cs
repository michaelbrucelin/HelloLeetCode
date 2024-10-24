using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3175
{
    public class Solution3175 : Interface3175
    {
        /// <summary>
        /// 队列，模拟
        /// </summary>
        /// <param name="skills"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindWinningPlayer(int[] skills, int k)
        {
            if (k == 1) return skills[0] > skills[1] ? 0 : 1;

            int len = skills.Length;
            if (k >= len)
            {
                int maxid = 0;
                for (int i = 1; i < len; i++) if (skills[i] > skills[maxid]) maxid = i;
                return maxid;
            }

            Queue<(int id, int skill)> queue = new Queue<(int id, int skill)>();
            for (int i = 1; i < len; i++) queue.Enqueue((i, skills[i]));
            (int id, int skill) winer = (0, skills[0]), newer;
            int cnt = 0;
            while (true)
            {
                newer = queue.Dequeue();
                if (winer.skill > newer.skill)
                {
                    if (++cnt >= k) return winer.id;
                    queue.Enqueue(newer);
                }
                else
                {
                    cnt = 1;
                    queue.Enqueue(winer);
                    winer = newer;
                }
            }

            throw new Exception("logic error");
        }
    }
}
