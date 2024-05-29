using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0031
{
    /// <summary>
    /// 使用字典+链表模拟
    /// 字典可以保证获取数据的时间复杂度是O(1)，链表可以保证移动和删除数据的时间复杂度是O(1)
    /// </summary>
    public class LRUCache : Interface0031
    {
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        private int capacity;
        private SortedDictionary<int, LinkedNode<int>> container = new SortedDictionary<int, LinkedNode<int>>();
        private LinkedNode<int> firstNode = null;
        private LinkedNode<int> lastNode = null;

        public int Get(int key)
        {
            if (!container.ContainsKey(key)) return -1;

            LinkedNode<int> node = container[key];
            if (node == lastNode)
                return node.Value;

            Delete(key);
            Put(key, node.Value);

            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (container.Count == 0)
            {
                LinkedNode<int> node = new LinkedNode<int>(key, value);
                container.Add(key, node);
                firstNode = lastNode = node;
            }
            else if (container.ContainsKey(key))
            {
                if (container[key] == lastNode)
                {
                    lastNode.Value = value;
                }
                else
                {
                    LinkedNode<int> node = Delete(key);
                    if (node == null) node = new LinkedNode<int>(key, value);
                    else
                    {
                        node.Key = key;
                        node.Value = value;
                    }

                    PutLast(node);
                }
            }
            else  // 至少有一个节点，且不包含key
            {
                if (container.Count < capacity)
                {
                    LinkedNode<int> node = new LinkedNode<int>(key, value);
                    PutLast(node);
                }
                else
                {
                    LinkedNode<int> node = Delete(firstNode.Key);
                    if (node == null) node = new LinkedNode<int>(key, value);
                    else
                    {
                        node.Key = key;
                        node.Value = value;
                    }

                    PutLast(node);
                }
            }
        }

        private LinkedNode<int> Delete(int key)
        {
            if (!container.ContainsKey(key)) return null;

            LinkedNode<int> node = container[key];
            if (container.Count == 1)
            {
                firstNode = lastNode = null;
            }
            else
            {
                if (node == firstNode)
                {
                    firstNode = firstNode.Next;
                    firstNode.Previous = null;
                }
                else if (node == lastNode)
                {
                    lastNode = lastNode.Previous;
                    lastNode.Next = null;
                }
                else
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                }
            }
            container.Remove(key);

            node.Previous = node.Next = null;
            return node;  // 之所以要把删除的节点返回，是为了省点内存
        }

        private void PutLast(LinkedNode<int> node)
        {
            if (container.Count >= capacity) return;

            if (container.Count == 0)
            {
                firstNode = lastNode = node;
            }
            else
            {
                lastNode.Next = node;
                node.Previous = lastNode;
                lastNode = node;
            }

            container.Add(node.Key, node);
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
