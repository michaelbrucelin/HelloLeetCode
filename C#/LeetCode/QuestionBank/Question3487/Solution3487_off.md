### [删除后的最大子数组元素和](https://leetcode.cn/problems/maximum-unique-subarray-sum-after-deletion/solutions/3724108/shan-chu-hou-de-zui-da-zi-shu-zu-yuan-su-b7l6/)

#### 方法一：对正数去重

**思路**

题目其实是要求找到一个非空子序列，并且元素不能重复，求最大和。我们可以贪心地、不重复地将所有正数放入一个哈希集合并求和。如果该哈希集合内不存在任何整数，则返回数组中元素的最大值。

**代码**

```Python
class Solution:
    def maxSum(self, nums: List[int]) -> int:
        positiveNumsSet = set([num for num in nums if num > 0])
        return max(nums) if len(positiveNumsSet) == 0 else sum(positiveNumsSet)
```

```C++
class Solution {
public:
    int maxSum(vector<int>& nums) {
        unordered_set<int> positiveNumsSet;
        for (int num : nums) {
            if (num > 0) {
                positiveNumsSet.emplace(num);
            }
        }
        if (positiveNumsSet.empty()) {
            return *max_element(nums.begin(), nums.end());
        }
        return accumulate(positiveNumsSet.begin(), positiveNumsSet.end(), 0);
    }
};
```

```Java
class Solution {
    public int maxSum(int[] nums) {
        Set<Integer> positiveNumsSet = new HashSet<>();
        for (int num : nums) {
            if (num > 0) {
                positiveNumsSet.add(num);
            }
        }
        if (positiveNumsSet.isEmpty()) {
            return Arrays.stream(nums).max().getAsInt();
        }
        return positiveNumsSet.stream().mapToInt(Integer::intValue).sum();
    }
}
```

```CSharp
public class Solution {
    public int MaxSum(int[] nums) {
        HashSet<int> positiveNumsSet = new HashSet<int>();
        foreach (int num in nums) {
            if (num > 0) {
                positiveNumsSet.Add(num);
            }
        }
        if (positiveNumsSet.Count == 0) {
            return nums.Max();
        }
        return positiveNumsSet.Sum();
    }
}
```

```Go
func maxSum(nums []int) int {
    positiveNumsSet := make(map[int]bool)
    maxNum := nums[0]
    for _, num := range nums {
        if num > 0 {
            positiveNumsSet[num] = true
        }
        maxNum = max(maxNum, num)
    }
    
    if len(positiveNumsSet) == 0 {
        return maxNum
    }
    sum := 0
    for num := range positiveNumsSet {
        sum += num
    }
    return sum
}
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

int maxSum(int* nums, int numsSize) {
    HashItem *positiveNumsSet = NULL;
    int maxNum = nums[0];
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] > 0) {
            hashAddItem(&positiveNumsSet, nums[i]);
        }
        maxNum = fmax(maxNum, nums[i]);
    }
    if (HASH_COUNT(positiveNumsSet) == 0) {
        hashFree(&positiveNumsSet);
        return maxNum;
    }
    int sum = 0;
    for (HashItem *pEntry = positiveNumsSet; pEntry; pEntry = pEntry->hh.next) {
        sum += pEntry->key;
    }
    hashFree(&positiveNumsSet);
    return sum;
}
```

```JavaScript
var maxSum = function(nums) {
    const positiveNumsSet = new Set(nums.filter(num => num > 0));
    return positiveNumsSet.size === 0 ? Math.max(...nums) : [...positiveNumsSet].reduce((a, b) => a + b, 0);
};
```

```TypeScript
function maxSum(nums: number[]): number {
    const positiveNumsSet = new Set(nums.filter(num => num > 0));
    return positiveNumsSet.size === 0 ? Math.max(...nums) : [...positiveNumsSet].reduce((a, b) => a + b, 0);
};
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn max_sum(nums: Vec<i32>) -> i32 {
        let positive_nums_set: HashSet<i32> = nums.iter().filter(|&&x| x > 0).cloned().collect();
        if positive_nums_set.is_empty() {
            *nums.iter().max().unwrap()
        } else {
            positive_nums_set.iter().sum()
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$。
