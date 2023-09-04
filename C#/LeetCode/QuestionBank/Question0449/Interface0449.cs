using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0449
{
    /// <summary>
    /// Your Codec object will be instantiated and called as such:
    /// Codec ser = new Codec();
    /// Codec deser = new Codec();
    /// String tree = ser.serialize(root);
    /// TreeNode ans = deser.deserialize(tree);
    /// return ans;
    /// </summary>
    public interface Interface0449
    {
        /// <summary>
        /// Encodes a tree to a single string.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string serialize(TreeNode root);

        /// <summary>
        /// Decodes your encoded data to tree.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public TreeNode deserialize(string data);
    }
}
