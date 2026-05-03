using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0649
{
    public class Solution0649 : Interface0649
    {
        /// <summary>
        /// 贪心 + 模拟
        /// 禁止掉自己后边最靠前的地方阵营的参议院即可
        /// </summary>
        /// <param name="senate"></param>
        /// <returns></returns>
        public string PredictPartyVictory(string senate)
        {
            int len = senate.Length;
            Queue<int> radiant = new Queue<int>(), dire = new Queue<int>();
            for (int i = 0; i < len; i++)
            {
                if (senate[i] == 'R') radiant.Enqueue(i); else dire.Enqueue(i);
            }

            while (radiant.Count > 0 && dire.Count > 0)
            {
                if (radiant.Peek() < dire.Peek())
                {
                    dire.Dequeue();
                    radiant.Enqueue(radiant.Dequeue() + len);
                }
                else
                {
                    radiant.Dequeue();
                    dire.Enqueue(dire.Dequeue() + len);
                }
            }

            return radiant.Count > 0 ? "Radiant" : "Dire";
        }

        /// <summary>
        /// 将队列改为双链表试一下
        /// </summary>
        /// <param name="senate"></param>
        /// <returns></returns>
        public string PredictPartyVictory2(string senate)
        {
            int len = senate.Length;
            LinkedList<int> radiant = new LinkedList<int>(), dire = new LinkedList<int>();
            for (int i = 0; i < len; i++)
            {
                if (senate[i] == 'R') radiant.AddLast(i); else dire.AddLast(i);
            }

            LinkedListNode<int> pr = radiant.First, pd = dire.First;
            while (pr != null && pd != null)
            {
                if (pr.Value < pd.Value)
                {
                    pd = pd.Next; dire.RemoveFirst();
                    radiant.AddLast(pr.Value + len); pr = pr.Next; radiant.RemoveFirst();
                }
                else
                {
                    pr = pr.Next; radiant.RemoveFirst();
                    dire.AddLast(pd.Value + len); pd = pd.Next; dire.RemoveFirst();
                }
            }

            return radiant.Count > 0 ? "Radiant" : "Dire";
        }

        /// <summary>
        /// 将队列改为列表试一下
        /// </summary>
        /// <param name="senate"></param>
        /// <returns></returns>
        public string PredictPartyVictory3(string senate)
        {
            int len = senate.Length;
            List<int> radiant = new List<int>(), dire = new List<int>();
            for (int i = 0; i < len; i++)
            {
                if (senate[i] == 'R') radiant.Add(i); else dire.Add(i);
            }

            int pr = 0, pd = 0;
            while (pr < radiant.Count && pd < dire.Count)
            {
                if (radiant[pr] < dire[pd])
                {
                    dire.RemoveAt(0);
                    radiant.Add(radiant[pr] + len); radiant.RemoveAt(0);
                }
                else
                {
                    radiant.RemoveAt(0);
                    dire.Add(dire[pd] + len); dire.RemoveAt(0);
                }
            }

            return radiant.Count > 0 ? "Radiant" : "Dire";
        }

        /// <summary>
        /// 将队列改为列表试一下，优化一下
        /// </summary>
        /// <param name="senate"></param>
        /// <returns></returns>
        public string PredictPartyVictory4(string senate)
        {
            int len = senate.Length;
            List<int> radiant = new List<int>(), dire = new List<int>();
            for (int i = 0; i < len; i++)
            {
                if (senate[i] == 'R') radiant.Add(i); else dire.Add(i);
            }

            int pr = 0, pd = 0;
            while (pr < radiant.Count && pd < dire.Count)
            {
                if (radiant[pr] < dire[pd])
                {
                    pd++;
                    radiant.Add(radiant[pr] + len); pr++;
                }
                else
                {
                    pr++;
                    dire.Add(dire[pd] + len); pd++;
                }
            }

            return pr < radiant.Count ? "Radiant" : "Dire";
        }
    }
}
