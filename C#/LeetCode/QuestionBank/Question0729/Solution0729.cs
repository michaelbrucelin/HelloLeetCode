using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0729
{
    public class Solution0729
    {
    }

    public class MyCalendar : Interface0729
    {
        /// <summary>
        /// 插入排序，二分法
        /// 理论上用跳表更好
        /// </summary>
        public MyCalendar()
        {
            books = new List<(int start, int end)>();
        }

        private List<(int start, int end)> books;

        public bool Book(int startTime, int endTime)
        {
            int id = Search(startTime, endTime);
            if (id == -1) return false;
            Insert(startTime, endTime, id);
            return true;
        }

        private int Search(int startTime, int endTime)
        {
            int id = 0, left = 0, right = books.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (books[mid].start <= startTime)
                {
                    id = left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (id > 0 && books[id - 1].end > startTime) return -1;
            if (id < books.Count && books[id].start < endTime) return -1;

            return id;
        }

        private void Insert(int startTime, int endTime, int id)
        {
            if (id == books.Count)
            {
                books.Add((startTime, endTime));
            }
            else
            {
                books.Add((0, 0));
                for (int i = books.Count - 1; i > id; i--) books[i] = books[i - 1];
                books[id] = ((startTime, endTime));
            }
        }
    }
}
