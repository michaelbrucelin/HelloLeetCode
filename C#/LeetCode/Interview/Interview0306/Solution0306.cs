using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0306
{
    public class Solution0306
    {
    }

    public class AnimalShelf : Interface0306
    {
        public AnimalShelf()
        {
            queue = new Queue<(int id, int age)>[2];
            queue[0] = new Queue<(int id, int age)>();
            queue[1] = new Queue<(int id, int age)>();
            id = 0;
        }

        private Queue<(int id, int age)>[] queue;
        private int id;

        public int[] DequeueAny()
        {
            switch (queue[0].Count, queue[1].Count)
            {
                case (0, 0): return new int[] { -1, -1 };
                case ( > 0, 0): return new int[] { queue[0].Dequeue().id, 0 };
                case (0, > 0): return new int[] { queue[1].Dequeue().id, 1 };
                default:
                    if (queue[0].Peek().age < queue[1].Peek().age)
                        return new int[] { queue[0].Dequeue().id, 0 };
                    else
                        return new int[] { queue[1].Dequeue().id, 1 };
            }
        }

        public int[] DequeueCat()
        {
            if (queue[0].Count > 0) return new int[] { queue[0].Dequeue().id, 0 };
            return new int[] { -1, -1 };
        }

        public int[] DequeueDog()
        {
            if (queue[1].Count > 0) return new int[] { queue[1].Dequeue().id, 1 };
            return new int[] { -1, -1 };
        }

        public void Enqueue(int[] animal)
        {
            queue[animal[1]].Enqueue((animal[0], id++));
        }
    }
}
