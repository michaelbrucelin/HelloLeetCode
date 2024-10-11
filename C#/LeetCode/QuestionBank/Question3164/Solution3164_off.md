### [优质数对的总数 II](https://leetcode.cn/problems/find-the-number-of-good-pairs-ii/solutions/2928182/you-zhi-shu-dui-de-zong-shu-ii-by-leetco-obro/)

#### 方法一：枚举倍数

**思路与算法**

分别统计 $nums1​$ 和 $nums2​$ 的频数。

遍历 $nums2​$ 出现过的数 $a$，枚举 $a \times k$ 的倍数，如果在 $nums1​$ 出现过就可以组成优质数对，更新结果。

返回优质数对的总数。

**代码**

```C++
class Solution {
public:
    long long numberOfPairs(vector<int>& nums1, vector<int>& nums2, int k) {
        unordered_map<int, int> count, count2;
        int max1 = 0;
        for (int num : nums1) {
            count[num]++;
            max1 = max(max1, num);
        }
        for (int num : nums2) {
            count2[num]++;
        }
        long long res = 0;
        for (const auto& pair : count2) {
            int a = pair.first, cnt = pair.second;
            for (int b = a * k; b <= max1; b += a * k) {
                if (count.count(b) > 0) {
                    res += 1L * count[b] * cnt;
                }
            }
        }
        return res;

    }
};
```

```Java
class Solution {
    public long numberOfPairs(int[] nums1, int[] nums2, int k) {
        Map<Integer, Integer> count = new HashMap<>();
        Map<Integer, Integer> count2 = new HashMap<>();
        int max1 = 0;
        for (int num : nums1) {
            count.put(num, count.getOrDefault(num, 0) + 1);
            max1 = Math.max(max1, num);
        }
        for (int num : nums2) {
            count2.put(num, count2.getOrDefault(num, 0) + 1);
        }
        long res = 0;
        for (int a : count2.keySet()) {
            for (int b = a * k; b <= max1; b += a * k) {
                if (count.containsKey(b)) {
                    res += 1L * count.get(b) * count2.get(a);
                }
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def numberOfPairs(self, nums1: List[int], nums2: List[int], k: int) -> int:
        count = Counter(nums1)
        max1 = max(count)
        res = 0
        for a, cnt in Counter(nums2).items():
            for b in range(a * k, max1 + 1, a * k):
                if b in count:
                    res += count[b] * cnt
        return res
```

```JavaScript
var numberOfPairs = function(nums1, nums2, k) {
    const count = {};
    const count2 = {};
    let res = 0, max1 = 0;
    for (let num of nums1) {
        count[num] = (count[num] || 0) + 1;
        max1 = Math.max(max1, num);
    }
    for (let num of nums2) {
        count2[num] = (count2[num] || 0) + 1;
    }
    for (let a in count2) {
        let cnt = count2[a];
        for (let b = a * k; b <= max1; b += a * k) {
            if (b in count) {
                res += count[b] * cnt;
            }
        }
    }
    return res;
};
```

```TypeScript
function numberOfPairs(nums1: number[], nums2: number[], k: number): number {
    const count = {};
    const count2 = {};
    let res = 0, max1 = 0;
    for (let num of nums1) {
        count[num] = (count[num] || 0) + 1;
        max1 = Math.max(max1, num);
    }
    for (let num of nums2) {
        count2[num] = (count2[num] || 0) + 1;
    }
    for (let a in count2) {
        let cnt = count2[a];
        for (let b = Number(a) * k; b <= max1; b += Number(a) * k) {
            if (b in count) {
                res += count[b] * cnt;
            }
        }
    }
    return res;
};
```

```Go
func numberOfPairs(nums1 []int, nums2 []int, k int) int64 {
    count := make(map[int]int)
    count2 := make(map[int]int)
    max1 := 0
    for _, num := range nums1 {
        count[num]++
        if num > max1 {
            max1 = num
        }
    }
    for _, num := range nums2 {
        count2[num]++
    }
    var res int64
    for a, cnt := range count2 {
        for b := a * k; b <= max1; b += a * k {
            if _, ok := count[b]; ok {
                res += int64(count[b] * cnt)
            }
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public long NumberOfPairs(int[] nums1, int[] nums2, int k) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        Dictionary<int, int> count2 = new Dictionary<int, int>();
        int max1 = 0;
        foreach (int num in nums1) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
            max1 = Math.Max(max1, num);
        }
        foreach (int num in nums2) {
            if (count2.ContainsKey(num)) {
                count2[num]++;
            } else {
                count2[num] = 1;
            }
        }
        long res = 0;
        foreach (int a in count2.Keys) {
            for (int b = a * k; b <= max1; b += a * k) {
                if (count.ContainsKey(b)) {
                    res += 1l * count[b] * count2[a];
                }
            }
        }
        return res;
    }
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn number_of_pairs(nums1: Vec<i32>, nums2: Vec<i32>, k: i32) -> i32 {
        let mut count: HashMap<i32, i32> = HashMap::new();
        let mut count2: HashMap<i32, i32> = HashMap::new();
        let mut res = 0;
        let mut max1 = 0;
        for &num in &nums1 {
            *count.entry(num).or_insert(0) += 1;
            max1 = std::cmp::max(max1, num);
        }
        for &num in &nums2 {
            *count2.entry(num).or_insert(0) += 1;
        }
        for (&a, &cnt) in &count2 {
            for b in (a * k..=max1).step_by((a * k) as usize) {
                if let Some(&value) = count.get(&b) {
                    res += value * cnt;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m+kv​ \times logm)$，其中 $n$ 和 $m$ 分别是数组 $nums1​$ 和 $nums2​$ 的长度，$k$ 是给定的正整数，$v$ 是数组 $nums1​$ 最大值，$logm$ 是「调和级数」求和的结果。
- 空间复杂度：$O(n+m)$。
