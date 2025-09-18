using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3408
{
    public class Solution3408_2
    {
    }

    /// <summary>
    /// 两个字典
    /// 
    /// 逻辑没问题，比Solution3408快了一些，但是依然TLE，大概率出现在SortedSet上，改成堆+懒删除试试，参考测试用例03
    /// </summary>
    public class TaskManager_2 : Interface3408
    {
        public TaskManager_2(IList<IList<int>> tasks)
        {
            _tasks = new Dictionary<int, int[]>();
            IComparer<(int priority, int taskid)> comparer = Comparer<(int priority, int taskid)>.Create(
                (x, y) => x.priority != y.priority ? y.priority - x.priority : y.taskid - x.taskid
            );
            _orders = new SortedSet<(int priority, int taskid)>(comparer);
            foreach (var task in tasks) Add(task[0], task[1], task[2]);
        }

        private Dictionary<int, int[]> _tasks;
        private SortedSet<(int priority, int taskid)> _orders;

        public void Add(int userId, int taskId, int priority)
        {
            _tasks.Add(taskId, [userId, priority]);
            _orders.Add((priority, taskId));
        }

        public void Edit(int taskId, int newPriority)
        {
            int priority = _tasks[taskId][1];
            if (newPriority == priority) return;
            _tasks[taskId][1] = newPriority;
            _orders.Remove((priority, taskId));
            _orders.Add((newPriority, taskId));
        }

        public int ExecTop()
        {
            if (_tasks.Count == 0) return -1;
            int taskId = _orders.First().taskid;
            int userId = _tasks[taskId][0];
            Rmv(taskId);

            return userId;
        }

        public void Rmv(int taskId)
        {
            int priority = _tasks[taskId][1];
            _tasks.Remove(taskId);
            _orders.Remove((priority, taskId));
        }
    }
}
