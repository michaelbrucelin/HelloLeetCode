using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0430
{
    public class Test0430
    {
        public void Test()
        {
            Interface0430 solution = new Solution0430();
            Node head;
            Node result, answer;
            int id = 0;

            Node[] nodes = new Node[16];
            for (int i = 0; i < nodes.Length; i++) nodes[i] = new Node() { val = i };

            // 1. 
            // head = [1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12];
            for (int i = 1; i < 15; i++) { nodes[i].prev = nodes[i - 1]; nodes[i].next = nodes[i + 1]; nodes[i].child = null; }
            nodes[1].prev = nodes[6].next = nodes[7].prev = nodes[10].next = nodes[11].prev = nodes[12].next = null;
            nodes[3].child = nodes[7]; nodes[8].child = nodes[11];
            // answer = [1, 2, 3, 7, 8, 11, 12, 9, 10, 4, 5, 6];
            solution.Flatten(nodes[1]);

            // 2. 
            // head = [1, 2, null, 3];
            for (int i = 1; i < 15; i++) { nodes[i].prev = nodes[i - 1]; nodes[i].next = nodes[i + 1]; nodes[i].child = null; }
            nodes[1].prev = nodes[2].next = nodes[3].prev = nodes[3].next = null;
            nodes[1].child = nodes[3];
            // answer = [1, 3, 2];
            solution.Flatten(nodes[1]);

            // 3. 
            // head = [];
            solution.Flatten(null);

            // 4. 
            // head = [1, null, 2, null, 3, null];
            for (int i = 1; i < 15; i++) { nodes[i].prev = nodes[i].next = nodes[i].child = null; }
            nodes[1].child = nodes[2]; nodes[2].child = nodes[3];
            // answer = [1, 2, 3];
            solution.Flatten(nodes[1]);

            // 5. 
            // head = [1, 2, 3, 4, 5, 6, null, null, null, 7, 8, null, null, 11, 12];
            for (int i = 1; i < 15; i++) { nodes[i].prev = nodes[i - 1]; nodes[i].next = nodes[i + 1]; nodes[i].child = null; }
            nodes[1].prev = nodes[6].next = nodes[7].prev = nodes[8].next = nodes[11].prev = nodes[12].next = null;
            nodes[3].child = nodes[7]; nodes[8].child = nodes[11];
            // answer = [1, 2, 3, 7, 8, 11, 12, 4, 5, 6];
            solution.Flatten(nodes[1]);
        }
    }
}
