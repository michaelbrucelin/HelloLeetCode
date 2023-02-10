#### [方法二：有序集合](https://leetcode.cn/problems/third-maximum-number/solutions/1032401/di-san-da-de-shu-by-leetcode-solution-h3sp/)

我们可以遍历数组，同时用一个有序集合来维护数组中前三大的数。具体做法是每遍历一个数，就将其插入有序集合，若有序集合的大小超过 $3$，就删除集合中的最小元素。这样可以保证有序集合的大小至多为 $3$，且遍历结束后，若有序集合的大小为 $3$，其最小值就是数组中第三大的数；若有序集合的大小不足 $3$，那么就返回有序集合中的最大值。

```python
from sortedcontainers import SortedList

class Solution:
    def thirdMax(self, nums: List[int]) -> int:
        s = SortedList()
        for num in nums:
            if num not in s:
                s.add(num)
                if len(s) > 3:
                    s.pop(0)
        return s[0] if len(s) == 3 else s[-1]
```

```cpp
class Solution {
public:
    int thirdMax(vector<int> &nums) {
        set<int> s;
        for (int num : nums) {
            s.insert(num);
            if (s.size() > 3) {
                s.erase(s.begin());
            }
        }
        return s.size() == 3 ? *s.begin() : *s.rbegin();
    }
};
```

```java
class Solution {
    public int thirdMax(int[] nums) {
        TreeSet<Integer> s = new TreeSet<Integer>();
        for (int num : nums) {
            s.add(num);
            if (s.size() > 3) {
                s.remove(s.first());
            }
        }
        return s.size() == 3 ? s.first() : s.last();
    }
}
```

```csharp
public class Solution {
    public int ThirdMax(int[] nums) {
        SortedSet<int> s = new SortedSet<int>();
        foreach (int num in nums) {
            s.Add(num);
            if (s.Count > 3) {
                s.Remove(s.Min);
            }
        }
        return s.Count == 3 ? s.Min : s.Max;
    }
}
```

```go
func thirdMax(nums []int) int {
    t := redblacktree.NewWithIntComparator()
    for _, num := range nums {
        t.Put(num, nil)
        if t.Size() > 3 {
            t.Remove(t.Left().Key)
        }
    }
    if t.Size() == 3 {
        return t.Left().Key.(int)
    }
    return t.Right().Key.(int)
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。由于有序集合的大小至多为 $3$，插入和删除的时间复杂度可以视作是 $O(1)$ 的，因此时间复杂度为 $O(n)$。
-   空间复杂度：$O(1)$。
