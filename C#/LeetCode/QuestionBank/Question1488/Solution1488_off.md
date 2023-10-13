### [避免洪水泛滥](https://leetcode.cn/problems/avoid-flood-in-the-city/solutions/2472026/bi-mian-hong-shui-fan-lan-by-leetcode-so-n5c9/)

#### 方法一：贪心 + 二分查找

**思路与算法**

我们要思考如何在洪水即将发生时，有选择地对湖泊进行抽干操作。为了做到这一点，我们使用有序集合 $st$ 来存储了那些在某些日期没有下雨的日子。这些晴天日子可以被用来在湖泊即将发生洪水时，有选择地抽干湖泊，从而阻止洪水的发生。有序集合 $st$ 的排序方式是按照晴天日子的顺序排列的，**这就确保了我们总是在最早的晴天日子中进行抽干操作，以最大程度地避免洪水的发生**。对于最后剩余的晴天，我们可以将它们用于抽干任意一个湖泊，为了方便，我们令其为 $1$。现在我们初始化一个大小和 $rains$ 一样的答案数组 $ans$，并初始化为 $1$，然后从左到右来遍历数组 $rains$：

-   若 $rains[i] = 0$，则将 $i$ 加入有序集合 $st$。
-   若 $rains[i] > 0$，表示第 $rains[i]$ 湖泊将下雨，令 $ans[i] = -1$ 表示这一天的湖泊不可抽干：
    -   若第 $rains[i]$ 是第一次下雨，则此时不会发生洪水。
    -   否则我们需要在有序集合 $st$ 中找到大于等于该湖泊上一次下雨天数的最小索引 $idx$（可以用**二分查找**实现），如果 $idx$ 不存在（即没有晴天可以用于抽干），此时不能避免洪水的发生，按照题目要求返回一个空数组。否则我们令 $ans[idx] = rains[i]$，并在 $st$ 中删除 $idx$，表示我们会在第 $idx$ 天抽干 $rains[i]$ 湖泊的水来避免第 $i$ 天洪水的发生。

**代码**

```cpp
class Solution {
public:
    vector<int> avoidFlood(vector<int>& rains) {
        vector<int> ans(rains.size(), 1);
        set<int> st;
        unordered_map<int, int> mp;
        for (int i = 0; i < rains.size(); ++i) {
            if (rains[i] == 0) {
                st.insert(i);
            } else {
                ans[i] = -1;
                if (mp.count(rains[i])) {
                    auto it = st.lower_bound(mp[rains[i]]);
                    if (it == st.end()) {
                        return {};
                    }
                    ans[*it] = rains[i];
                    st.erase(it);
                }
                mp[rains[i]] = i;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int[] avoidFlood(int[] rains) {
        int[] ans = new int[rains.length];
        Arrays.fill(ans, 1);
        TreeSet<Integer> st = new TreeSet<Integer>();
        Map<Integer, Integer> mp = new HashMap<Integer, Integer>();
        for (int i = 0; i < rains.length; ++i) {
            if (rains[i] == 0) {
                st.add(i);
            } else {
                ans[i] = -1;
                if (mp.containsKey(rains[i])) {
                    Integer it = st.ceiling(mp.get(rains[i]));
                    if (it == null) {
                        return new int[0];
                    }
                    ans[it] = rains[i];
                    st.remove(it);
                }
                mp.put(rains[i], i);
            }
        }
        return ans;
    }
}
```

```python
from sortedcontainers import SortedList

class Solution:
    def avoidFlood(self, rains: List[int]) -> List[int]:
        ans = [1] * len(rains)
        st = SortedList()
        mp = {}
        for i, rain in enumerate(rains):
            if rain == 0:
                st.add(i)
            else:
                ans[i] = -1
                if rain in mp:
                    it = st.bisect(mp[rain])
                    if it == len(st):
                        return []
                    ans[st[it]] = rain
                    st.discard(st[it])
                mp[rain] = i
        return ans
```

```go
func avoidFlood(rains []int) []int {
    n := len(rains)
    ans := make([]int, n)
    st := []int{} 
    mp := make(map[int]int)
    for i := 0; i < n; i++ {
        ans[i] = 1
    }
    for i, rain := range rains {
        if rain == 0 {
            st = append(st, i)
        } else {
            ans[i] = -1
            if day, ok := mp[rain]; ok {
                it := sort.SearchInts(st, day)
                if it == len(st) {
                    return []int {}
                }
                ans[st[it]] = rain
                copy(st[it : len(st) - 1], st[it + 1 : len(st)])
                st = st[: len(st) - 1]
            }
            mp[rain] = i
        }
    }
    return ans
}
```

**复杂度分析**

-   时间复杂度：$O(n \times \log n)$，其中 $n$ 为数组 $rains$ 的长度。每次有序集合的插入和查询的时间复杂度为 $O(\log n)$，最坏情况下会进行 $n$ 次有序集合的插入操作，所以总的时间复杂度为 $O(n \times \log n)$。
-   空间复杂度：$O(n)$，其中 $n$ 为数组 $rains$ 的长度。主要为哈希表和有序集合的空间开销。
