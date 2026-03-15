using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2196
{
    public class Solution2196 : Interface2196
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="descriptions"></param>
        /// <returns></returns>
        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            Dictionary<int, TreeNode> map = new Dictionary<int, TreeNode>();
            HashSet<int> set = [];
            int parent, child, isleft;
            foreach (int[] item in descriptions)
            {
                parent = item[0]; child = item[1]; isleft = item[2];
                if (!map.ContainsKey(parent)) map.Add(parent, new TreeNode(parent));
                if (!map.ContainsKey(child)) map.Add(child, new TreeNode(child));
                if (isleft == 1) map[parent].left = map[child]; else map[parent].right = map[child];
                set.Add(child);
            }

            foreach (int key in map.Keys) if (!set.Contains(key)) return map[key];
            return null;
        }
    }
}
