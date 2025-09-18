using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3408
{
    /// <summary>
    /// Your TaskManager object will be instantiated and called as such:
    /// TaskManager obj = new TaskManager(tasks);
    /// obj.Add(userId,taskId,priority);
    /// obj.Edit(taskId,newPriority);
    /// obj.Rmv(taskId);
    /// int param_4 = obj.ExecTop();
    /// </summary>
    public interface Interface3408
    {
        // public TaskManager(IList<IList<int>> tasks){}

        public void Add(int userId, int taskId, int priority);

        public void Edit(int taskId, int newPriority);

        public void Rmv(int taskId);

        public int ExecTop();
    }
}
