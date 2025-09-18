using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3408
{
    public class Solution3408
    {
    }

    /// <summary>
    /// 两个字典
    /// 
    /// 逻辑没问题，TLE，大概率出现在SortedSet上，改成堆+懒删除试试，参考测试用例02
    /// </summary>
    public class TaskManager : Interface3408
    {
        public TaskManager(IList<IList<int>> tasks)
        {
            _tasks = new Dictionary<int, int[]>();
            _orders = new SortedDictionary<int, SortedSet<int>>();
            foreach (var task in tasks) Add(task[0], task[1], task[2]);
        }

        private Dictionary<int, int[]> _tasks;
        private SortedDictionary<int, SortedSet<int>> _orders;

        public void Add(int userId, int taskId, int priority)
        {
            _tasks.Add(taskId, [userId, priority]);
            // if (_orders.ContainsKey(priority)) _orders[priority].Add(taskId); else _orders.Add(priority, [taskId]);
            if (_orders.TryGetValue(priority, out SortedSet<int> value)) value.Add(taskId); else _orders.Add(priority, [taskId]);
        }

        public void Edit(int taskId, int newPriority)
        {
            int priority = _tasks[taskId][1];
            if (newPriority == priority) return;
            _tasks[taskId][1] = newPriority;
            if (_orders[priority].Count > 1) _orders[priority].Remove(taskId); else _orders.Remove(priority);
            // if (_orders.ContainsKey(newPriority)) _orders[newPriority].Add(taskId); else _orders.Add(newPriority, [taskId]);
            if (_orders.TryGetValue(newPriority, out SortedSet<int> value)) value.Add(taskId); else _orders.Add(newPriority, [taskId]);
        }

        public int ExecTop()
        {
            if (_tasks.Count == 0) return -1;
            int taskId = _orders.Last().Value.Last();
            int userId = _tasks[taskId][0];
            Rmv(taskId);

            return userId;
        }

        public void Rmv(int taskId)
        {
            int priority = _tasks[taskId][1];
            _tasks.Remove(taskId);
            if (_orders[priority].Count > 1) _orders[priority].Remove(taskId); else _orders.Remove(priority);
        }
    }
}
