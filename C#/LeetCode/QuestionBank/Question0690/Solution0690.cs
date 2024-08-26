using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0690
{
    public class Solution0690 : Interface0690
    {
        /// <summary>
        /// Hash，递归
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetImportance(IList<Employee> employees, int id)
        {
            Dictionary<int, Employee> map = new Dictionary<int, Employee>();
            foreach (Employee employee in employees) map.Add(employee.id, employee);

            int result = 0;
            dfs(id);

            return result;

            void dfs(int id)
            {
                result += map[id].importance;
                foreach (int _id in map[id].subordinates) dfs(_id);
            }
        }
    }
}
