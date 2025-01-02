using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0729
{
    public class Solution0729_2
    {
    }

    public class MyCalendar_2 : Interface0729
    {
        /// <summary>
        /// 插入排序，二分法
        /// 逻辑同Solution0729，这里合并了可以合并的区间，理论上用跳表更好
        /// </summary>
        public MyCalendar_2()
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
            if (id > 0 && startTime == books[id - 1].end)
            {
                if (id < books.Count && endTime == books[id].start)
                {
                    books[id - 1] = (books[id - 1].start, books[id].end);
                    for (int i = id + 1; i < books.Count; i++) books[i - 1] = books[i];
                    books.RemoveAt(books.Count - 1);
                }
                else
                {
                    books[id - 1] = (books[id - 1].start, endTime);
                }
            }
            else if (id < books.Count && endTime == books[id].start)
            {
                books[id] = (startTime, books[id].end);
            }
            else
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
}
