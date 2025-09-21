### [最大频率元素计数](https://leetcode.cn/problems/count-elements-with-maximum-frequency/solutions/3777507/zui-da-pin-lu-yuan-su-ji-shu-by-leetcode-4fhx/)

#### 方法一：哈希表

**思路与算法**

遍历数组，用哈希表统计每个元素出现频率。遍历哈希表，找到最大频率。再次遍历哈希表，若遍历到出现频率为最大频率的元素，将该元素的出现频率累加到结果中，返回答案。

**代码**

```C++
class Solution {
public:
    int maxFrequencyElements(vector<int>& nums) {
        unordered_map<int, int> count;
        for (int a : nums) {
            count[a]++;
        }
        int maxf = 0;
        for (auto const& pair : count) {
            if (pair.second > maxf) {
                maxf = pair.second;
            }
        }
        int res = 0;
        for (auto const& pair : count) {
            if (pair.second == maxf) {
                res += maxf;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int maxFrequencyElements(int[] nums) {
        Map<Integer, Integer> count = new HashMap<>();
        for (int a : nums) {
            count.put(a, count.getOrDefault(a, 0) + 1);
        }
        int maxf = 0;
        for (int value : count.values()) {
            if (value > maxf) {
                maxf = value;
            }
        }
        int res = 0;
        for (int value : count.values()) {
            if (value == maxf) {
                res += maxf;
            }
        }
        return res;
    }
}
```

```Python
    def maxFrequencyElements(self, nums: List[int]) -> int:
        count = Counter(nums)
        maxf = max(count.values())
        res = 0
        for a in count:
            if count[a] == maxf:
                res += maxf
        return res
```

```JavaScript
var maxFrequencyElements = function(nums) {
    let count = {};
    for (let a of nums) {
        count[a] = (count[a] || 0) + 1;
    }
    let maxf = 0;
    for (let key in count) {
        if (count[key] > maxf) {
            maxf = count[key];
        }
    }
    let res = 0;
    for (let key in count) {
        if (count[key] === maxf) {
            res += maxf;
        }
    }
    return res;
};
```

```TypeScript
function maxFrequencyElements(nums: number[]): number {
    let count = {};
    for (let a of nums) {
        count[a] = (count[a] || 0) + 1;
    }
    let maxf = 0;
    for (let key in count) {
        if (count[key] > maxf) {
            maxf = count[key];
        }
    }
    let res = 0;
    for (let key in count) {
        if (count[key] === maxf) {
            res += maxf;
        }
    }
    return res;
};
```

```Go
func maxFrequencyElements(nums []int) int {
    count := make(map[int]int)
    for _, a := range nums {
        count[a]++
    }
    maxf := 0
    for _, freq := range count {
        if freq > maxf {
            maxf = freq
        }
    }
    res := 0
    for _, freq := range count {
        if freq == maxf {
            res += maxf
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int a in nums) {
            if (count.ContainsKey(a)) {
                count[a]++;
            } else {
                count[a] = 1;
            }
        }
        int maxf = 0;
        foreach (int freq in count.Values) {
            if (freq > maxf) {
                maxf = freq;
            }
        }
        int res = 0;
        foreach (int freq in count.Values) {
            if (freq == maxf) {
                res += maxf;
            }
        }
        return res;
    }
}
```

```C
typedef struct {
    int key;
    int value;
} Pair;

int maxFrequencyElements(int* nums, int numsSize) {
    Pair* count = (Pair*)malloc(numsSize * sizeof(Pair));
    int countSize = 0;
    for (int i = 0; i < numsSize; i++) {
        int found = 0;
        for (int j = 0; j < countSize; j++) {
            if (count[j].key == nums[i]) {
                count[j].value++;
                found = 1;
                break;
            }
        }
        if (!found) {
            count[countSize].key = nums[i];
            count[countSize].value = 1;
            countSize++;
        }
    }
    int maxf = 0;
    for (int i = 0; i < countSize; i++) {
        if (count[i].value > maxf) {
            maxf = count[i].value;
        }
    }
    int res = 0;
    for (int i = 0; i < countSize; i++) {
        if (count[i].value == maxf) {
            res += maxf;
        }
    }
    free(count);
    return res;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn max_frequency_elements(nums: Vec<i32>) -> i32 {
        let mut count: HashMap<i32, i32> = HashMap::new();
        for a in nums {
            *count.entry(a).or_insert(0) += 1;
        }
        let mut maxf = 0;
        for &freq in count.values() {
            if freq > maxf {
                maxf = freq;
            }
        }
        let mut res = 0;
        for &freq in count.values() {
            if freq == maxf {
                res += maxf;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
