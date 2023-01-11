#### [方法一：哈希表](https://leetcode.cn/problems/single-number-iii/solutions/587516/zhi-chu-xian-yi-ci-de-shu-zi-iii-by-leet-4i8e/)

**思路与算法**

我们可以使用一个哈希映射统计数组中每一个元素出现的次数。

在统计完成后，我们对哈希映射进行遍历，将所有只出现了一次的数放入答案中。

**代码**

```cpp
class Solution {
public:
    vector<int> singleNumber(vector<int>& nums) {
        unordered_map<int, int> freq;
        for (int num: nums) {
            ++freq[num];
        }
        vector<int> ans;
        for (const auto& [num, occ]: freq) {
            if (occ == 1) {
                ans.push_back(num);
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int[] singleNumber(int[] nums) {
        Map<Integer, Integer> freq = new HashMap<Integer, Integer>();
        for (int num : nums) {
            freq.put(num, freq.getOrDefault(num, 0) + 1);
        }
        int[] ans = new int[2];
        int index = 0;
        for (Map.Entry<Integer, Integer> entry : freq.entrySet()) {
            if (entry.getValue() == 1) {
                ans[index++] = entry.getKey();
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int[] SingleNumber(int[] nums) {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (freq.ContainsKey(num)) {
                ++freq[num];
            } else {
                freq.Add(num, 1);
            }
        }
        int[] ans = new int[2];
        int index = 0;
        foreach (KeyValuePair<int, int> pair in freq) {
            if (pair.Value == 1) {
                ans[index++] = pair.Key;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def singleNumber(self, nums: List[int]) -> List[int]:
        freq = Counter(nums)
        return [num for num, occ in freq.items() if occ == 1]
```

```javascript
var singleNumber = function(nums) {
    const freq = new Map();
    for (const num of nums) {
        freq.set(num, (freq.get(num) || 0) + 1);
    }
    const ans = [];
    for (const [num, occ] of freq.entries()) {
        if (occ === 1) {
            ans.push(num);
        }
    }
    return ans;
};
```

```typescript
function singleNumber(nums: number[]): number[] {
    const freq = new Map();
    for (const num of nums) {
        freq.set(num, (freq.get(num) || 0) + 1);
    }
    const ans: number[] = [];
    for (const [num, occ] of freq.entries()) {
        if (occ === 1) {
            ans.push(num);
        }
    }
    return ans;
};
```

```go
func singleNumber(nums []int) (ans []int) {
    freq := map[int]int{}
    for _, num := range nums {
        freq[num]++
    }
    for num, occ := range freq {
        if occ == 1 {
            ans = append(ans, num)
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
-   空间复杂度：$O(n)$，即为哈希映射需要使用的空间。
