### [分割数组](https://leetcode.cn/problems/split-the-array/solutions/3021463/fen-ge-shu-zu-by-leetcode-solution-3pa3/)

#### 方法一：哈希表

**思路与算法**

用哈希表统计每个元素的出现次数，如果出现次数大于两次，则不能分割数组。
如果没有出现两次以上的元素，则可以分割数组。

**代码**

```C++
class Solution {
public:
    bool isPossibleToSplit(vector<int>& nums) {
        unordered_map<int, int> count;
        for (int num : nums) {
            if (++count[num] > 2) {
                return false;
            }
        }
        return true;
    }
};
```

```Java
class Solution {
    public boolean isPossibleToSplit(int[] nums) {
        Map<Integer, Integer> count = new HashMap<>();
        for (int num : nums) {
            count.put(num, count.getOrDefault(num, 0) + 1);
            if (count.get(num) > 2) {
                return false;
            }
        }
        return true;
    }
}
```

```Python
class Solution:
    def isPossibleToSplit(self, nums: List[int]) -> bool:
        count = {}
        for num in nums:
            count[num] = count.get(num, 0) + 1
            if count[num] > 2:
                return False
        return True
```

```JavaScript
var isPossibleToSplit = function(nums) {
    const count = {};
    for (const num of nums) {
        count[num] = (count[num] || 0) + 1;
        if (count[num] > 2) {
            return false;
        }
    }
    return true;
};
```

```TypeScript
function isPossibleToSplit(nums: number[]): boolean {
    const count = {};
    for (const num of nums) {
        count[num] = (count[num] || 0) + 1;
        if (count[num] > 2) {
            return false;
        }
    }
    return true;
};
```

```Go
func isPossibleToSplit(nums []int) bool {
    count := make(map[int]int)
    for _, num := range nums {
        count[num]++
        if count[num] > 2 {
            return false
        }
    }
    return true
}
```

```CSharp
public class Solution {
    public bool IsPossibleToSplit(int[] nums) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
            if (count[num] > 2) {
                return false;
            }
        }
        return true;
    }
}
```

```C
bool isPossibleToSplit(int* nums, int numsSize) {
    int count[101] = {0};
    for (int i = 0; i < numsSize; i++) {
        if (++count[nums[i]] > 2) {
            return false;
        }
    }
    return true;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn is_possible_to_split(nums: Vec<i32>) -> bool {
        let mut count = HashMap::new();
        for num in nums {
            let counter = count.entry(num).or_insert(0);
            *counter += 1;
            if *counter > 2 {
                return false;
            }
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
