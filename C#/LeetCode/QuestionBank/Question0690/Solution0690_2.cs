using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0690
{
    public class Solution0690_2 : Interface0690
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetImportance(IList<Employee> employees, int id)
        {
            Dictionary<int, Employee> map = new Dictionary<int, Employee>();
            foreach (Employee employee in employees) map.Add(employee.id, employee);

            int result = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id);
            int item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                result += map[item].importance;
                foreach (int _id in map[item].subordinates) queue.Enqueue(_id);
            }

            return result;
        }
    }
}
