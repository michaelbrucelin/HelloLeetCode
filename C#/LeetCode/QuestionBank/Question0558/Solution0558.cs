using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0558
{
    public class Solution0558 : Interface0558
    {
        /// <summary>
        /// dfs
        /// 如果两个节点都是叶子节点，结果已知，递归停止
        /// 如果有一个节点为叶子节点，假定是node1
        ///     如果node1的值为true，结果为true，递归停止
        ///     如果node1的值为false，需要继续递归，而且递归后的结果一定不会合并为叶子节点
        /// 如果两个节点都不是叶子节点，需要继续递归，需要注意的是，合并后可能变成叶子节点
        /// </summary>
        /// <param name="quadTree1"></param>
        /// <param name="quadTree2"></param>
        /// <returns></returns>
        public Node Intersect(Node quadTree1, Node quadTree2)
        {
            Node result = new Node();
            Node p1 = quadTree1, p2 = quadTree2;
            if (p1.isLeaf && p2.isLeaf)
            {
                result.isLeaf = true; result.val = p1.val || p2.val;
            }
            else if (p1.isLeaf || p2.isLeaf)
            {
                if ((p1.isLeaf && p1.val) || (p2.isLeaf && p2.val))
                {
                    result.isLeaf = true; result.val = true;
                }
                else
                {
                    result.isLeaf = false;
                    if (p1.isLeaf)
                    {
                        Node node = new Node() { isLeaf = true, val = p1.val };
                        result.topLeft = Intersect(node, p2.topLeft);
                        result.topRight = Intersect(node, p2.topRight);
                        result.bottomLeft = Intersect(node, p2.bottomLeft);
                        result.bottomRight = Intersect(node, p2.bottomRight);
                    }
                    else
                    {
                        Node node = new Node() { isLeaf = true, val = p2.val };
                        result.topLeft = Intersect(p1.topLeft, node);
                        result.topRight = Intersect(p1.topRight, node);
                        result.bottomLeft = Intersect(p1.bottomLeft, node);
                        result.bottomRight = Intersect(p1.bottomRight, node);
                    }
                }
            }
            else
            {
                result.isLeaf = false;
                result.topLeft = Intersect(p1.topLeft, p2.topLeft);
                result.topRight = Intersect(p1.topRight, p2.topRight);
                result.bottomLeft = Intersect(p1.bottomLeft, p2.bottomLeft);
                result.bottomRight = Intersect(p1.bottomRight, p2.bottomRight);
                if (result.topLeft.isLeaf && result.topRight.isLeaf && result.bottomLeft.isLeaf && result.bottomRight.isLeaf)
                {
                    if (result.topLeft.val && result.topRight.val && result.bottomLeft.val && result.bottomRight.val)
                    {
                        result.isLeaf = true; result.val = true; result.topLeft = result.topRight = result.bottomLeft = result.bottomRight = null;
                    }
                    else if (!result.topLeft.val && !result.topRight.val && !result.bottomLeft.val && !result.bottomRight.val)
                    {
                        result.isLeaf = true; result.val = false; result.topLeft = result.topRight = result.bottomLeft = result.bottomRight = null;
                    }
                }
            }

            return result;
        }
    }
}
