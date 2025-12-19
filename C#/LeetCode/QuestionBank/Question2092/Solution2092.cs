using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2092
{
    public class Solution2092 : Interface2092
    {
        /// <summary>
        /// 离散版并查集 + 排序 + 类BFS
        /// 1. 同一时间 x 与 y 开会，同时 x 与 z 开会，则相当于 y 与 z 开会，所以按照时间把同时间所有开会的人按并查集的方式合并
        /// 2. 按照时间排序，一点一点找即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="meetings"></param>
        /// <param name="firstPerson"></param>
        /// <returns></returns>
        public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
        {
            // 按时间把同一时间开会的人分组
            Dictionary<int, HashSet<int>> map1 = new Dictionary<int, HashSet<int>>();
            foreach (int[] meet in meetings)
            {
                if (map1.TryGetValue(meet[2], out var set)) set.UnionWith([meet[0], meet[1]]); else map1.Add(meet[2], [meet[0], meet[1]]);
            }

            // 把同一时间开会的人用并查集的方式合并
            Dictionary<int, UnionFind> map2 = new Dictionary<int, UnionFind>();
            foreach (int key in map1.Keys) map2.Add(key, new UnionFind(map1[key]));
            foreach (int[] meet in meetings) map2[meet[2]].Union(meet[0], meet[1]);

            // 取出同一时间开会人员的分组
            SortedDictionary<int, Dictionary<int, HashSet<int>>> map3 = new SortedDictionary<int, Dictionary<int, HashSet<int>>>();
            foreach (int key in map2.Keys) map3.Add(key, map2[key].Groups());

            HashSet<int> result = [0, firstPerson];
            foreach (var groups in map3.Values) foreach (var group in groups.Values) if (result.Overlaps(group)) result.UnionWith(group);

            return result.ToArray();
        }

        public class UnionFind
        {
            public UnionFind(HashSet<int> list)
            {
                member = new Dictionary<int, int>();
                foreach (int i in list) member.Add(i, i);
            }

            private Dictionary<int, int> member;

            public void Union(int x, int y)
            {
                int _x = Find(x), _y = Find(y);
                switch (_x - _y)
                {
                    case < 0: member[_y] = _x; break;
                    case > 0: member[_x] = _y; break;
                    default: break;
                }
            }

            public int Find(int x)
            {
                if (member[x] == x) return x;
                int _x = Find(member[x]);
                member[x] = _x;
                return _x;
            }

            public Dictionary<int, HashSet<int>> Groups()
            {
                Dictionary<int, HashSet<int>> result = new Dictionary<int, HashSet<int>>();
                int key;
                foreach (int x in member.Keys)
                {
                    key = Find(x);
                    if (result.TryGetValue(key, out var set)) set.Add(x); else result.Add(key, [x]);
                }

                return result;
            }
        }
    }
}
