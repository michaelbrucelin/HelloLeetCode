using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1600
{
    public class Solution1600_2
    {
    }

    /// <summary>
    /// N叉树的前序遍历，迭代
    /// </summary>
    public class ThroneInheritance_2 : Interface1600
    {
        public ThroneInheritance_2(string kingName)
        {
            king = new Node(kingName);
            nodes = new Dictionary<string, Node>();
            nodes.Add(kingName, king);
        }

        private Node king;
        private Dictionary<string, Node> nodes;

        public void Birth(string parentName, string childName)
        {
            Node child = new Node(childName);
            nodes[parentName].Children.Add(child);
            nodes.Add(childName, child);
        }

        public void Death(string name)
        {
            nodes[name].Alive = false;
        }

        public IList<string> GetInheritanceOrder()
        {
            List<string> result = new List<string>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(king);
            Node item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item.Alive) result.Add(item.Name);
                for (int i = item.Children.Count - 1; i >= 0; i--) stack.Push(item.Children[i]);
            }

            return result;
        }

        public class Node
        {
            public Node(string name)
            {
                this.name = name;
                alive = true;
                children = new List<Node>();
            }

            private string name;
            private bool alive;
            private List<Node> children;

            public string Name
            {
                get { return name; }
            }

            public bool Alive
            {
                get { return alive; }
                set { alive = value; }
            }

            public List<Node> Children
            {
                get { return children; }
            }
        }
    }
}
