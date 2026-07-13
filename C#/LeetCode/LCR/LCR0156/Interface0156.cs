using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0156
{
    /// <summary>
    /// Your Codec object will be instantiated and called as such:
    /// Codec codec = new Codec();
    /// codec.deserialize(codec.serialize(root));
    /// </summary>
    public interface Interface0156
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
