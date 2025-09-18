using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3408
{
    public class Solution3408_3
    {
    }

    /// <summary>
    /// 堆 + 懒删除
    /// </summary>
    public class TaskManager_3 : Interface3408
    {
        public TaskManager_3(IList<IList<int>> tasks)
        {
            _tasks = new Dictionary<int, int[]>();
            IComparer<(int priority, int taskid)> comparer = Comparer<(int priority, int taskid)>.Create(
                (x, y) => x.priority != y.priority ? y.priority - x.priority : y.taskid - x.taskid
            );
            _orders = new PriorityQueue<(int priority, int taskid), (int priority, int taskid)>(comparer);
            foreach (var task in tasks) Add(task[0], task[1], task[2]);
        }

        private Dictionary<int, int[]> _tasks;
        private PriorityQueue<(int, int), (int, int)> _orders;

        public void Add(int userId, int taskId, int priority)
        {
            _tasks.Add(taskId, [userId, priority]);
            _orders.Enqueue((priority, taskId), (priority, taskId));
        }

        public void Edit(int taskId, int newPriority)
        {
            if (newPriority == _tasks[taskId][1]) return;
            _tasks[taskId][1] = newPriority;
            _orders.Enqueue((newPriority, taskId), (newPriority, taskId));
        }

        public int ExecTop()
        {
            if (_tasks.Count == 0) return -1;

            (int priority, int taskid) item;
            while (true)
            {
                item = _orders.Dequeue();
                // if (_tasks.ContainsKey(item.taskid) && _tasks[item.taskid][1] == item.priority) break;
                if (_tasks.TryGetValue(item.taskid, out int[] value) && value[1] == item.priority) break;
            }
            int userId = _tasks[item.taskid][0];
            Rmv(item.taskid);

            return userId;
        }

        public void Rmv(int taskId)
        {
            _tasks.Remove(taskId);
        }
    }
}
