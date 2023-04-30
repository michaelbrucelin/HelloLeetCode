#### [方法二：哈希表](https://leetcode.cn/problems/longest-harmonious-subsequence/solutions/1110137/zui-chang-he-xie-zi-xu-lie-by-leetcode-s-8cyr/)

**思路与算法**

在方法一中，我们枚举了 $x$ 后，遍历数组找出所有的 $x$ 和 $x + 1$的出现的次数。我们也可以用一个哈希映射来存储每个数出现的次数，这样就能在 $O(1)$ 的时间内得到 $x$ 和 $x + 1$ 出现的次数。

我们首先遍历一遍数组，得到哈希映射。随后遍历哈希映射，设当前遍历到的键值对为 $(x, value)$，那么我们就查询 $x + 1$ 在哈希映射中对应的统计次数，就得到了 $x$ 和 $x + 1$ 出现的次数，和谐子序列的长度等于 $x$ 和 $x + 1$ 出现的次数之和。

**代码**

```java
class Solution {
    public int findLHS(int[] nums) {
        HashMap <Integer, Integer> cnt = new HashMap <>();
        int res = 0;
        for (int num : nums) {
            cnt.put(num, cnt.getOrDefault(num, 0) + 1);
        }
        for (int key : cnt.keySet()) {
            if (cnt.containsKey(key + 1)) {
                res = Math.max(res, cnt.get(key) + cnt.get(key + 1));
            }
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    int findLHS(vector<int>& nums) {
        unordered_map<int, int> cnt;
        int res = 0;
        for (int num : nums) {
            cnt[num]++;
        }
        for (auto [key, val] : cnt) {
            if (cnt.count(key + 1)) {
                res = max(res, val + cnt[key + 1]);
            }
        }
        return res;
    }
};
```

```csharp
public class Solution {
    public int FindLHS(int[] nums) {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        int res = 0;
        foreach (int num in nums) {
            if (dictionary.ContainsKey(num)) {
                dictionary[num]++;
            } else {
                dictionary.Add(num, 1);
            }
        }
        foreach (int key in dictionary.Keys) {
            if (dictionary.ContainsKey(key + 1)) {
                res = Math.Max(res, dictionary[key] + dictionary[key + 1]);
            }
        }
        return res;
    }
}
```

```python
class Solution:
    def findLHS(self, nums: List[int]) -> int:
        cnt = Counter(nums)
        return max((val + cnt[key + 1] for key, val in cnt.items() if key + 1 in cnt), default=0)
```

```javascript
var findLHS = function(nums) {
    const cnt = new Map();
    let res = 0;
    for (const num of nums) {
        cnt.set(num, (cnt.get(num) || 0) + 1);
    }
    for (const key of cnt.keys()) {
        if (cnt.has(key + 1)) {
            res = Math.max(res, cnt.get(key) + cnt.get(key + 1));
        }
    }
    return res;
};
```

```go
func findLHS(nums []int) (ans int) {
    cnt := map[int]int{}
    for _, num := range nums {
        cnt[num]++
    }
    for num, c := range cnt {
        if c1 := cnt[num+1]; c1 > 0 && c+c1 > ans {
            ans = c + c1
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 为数组的长度。
-   空间复杂度：$O(N)$，其中 $N$ 为数组的长度。数组中最多有 $N$ 个不同元素，因此哈希表最多存储 $N$ 个数据。
