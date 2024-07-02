### [质数的最大距离](https://leetcode.cn/problems/maximum-prime-difference/solutions/2823598/zhi-shu-de-zui-da-ju-chi-by-leetcode-sol-g6ze/)

#### 方法一：一次遍历

**思路与算法**

根据题目描述，数组 $nums$ 中元素均不大于 $100$，因此我们可以首先预处理出所有不大于 $100$ 的质数。由于 $100$ 远小于数组 $nums$ 的最大长度 $3 \times 10^5$，因此任意一种预处理质数的方法都对时间复杂度的影响不大，包括：

- 对每个数枚举其质因数；
- 使用筛法；
- 直接列举出所有的 $25$ 个质数。

随后，我们只需对数组进行一次遍历，遍历的过程中使用 $first$ 记录第一个出现的质数位置。如果 $nums[i]$ 是质数，那么用 $i - first$ 更新答案即可。

**代码**

```C++
class Solution {
public:
    int maximumPrimeDifference(vector<int>& nums) {
        unordered_set<int> primes = {
            2, 3, 5, 7, 11,
            13, 17, 19, 23, 29,
            31, 37, 41, 43, 47,
            53, 59, 61, 67, 71,
            73, 79, 83, 89, 97
        };

        int n = nums.size();
        int first = -1, ans = 0;
        for (int i = 0; i < n; ++i) {
            if (primes.count(nums[i])) {
                if (first != -1) {
                    ans = max(ans, i - first);
                }
                else {
                    first = i;
                }
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maximumPrimeDifference(int[] nums) {
        Set<Integer> primes = new HashSet<>(Arrays.asList(
            2, 3, 5, 7, 11,
            13, 17, 19, 23, 29,
            31, 37, 41, 43, 47,
            53, 59, 61, 67, 71,
            73, 79, 83, 89, 97
        ));

        int n = nums.length;
        int first = -1, ans = 0;
        for (int i = 0; i < n; ++i) {
            if (primes.contains(nums[i])) {
                if (first != -1) {
                    ans = Math.max(ans, i - first);
                } else {
                    first = i;
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaximumPrimeDifference(int[] nums) {
        ISet<int> primes = new HashSet<int> {
            2, 3, 5, 7, 11,
            13, 17, 19, 23, 29,
            31, 37, 41, 43, 47,
            53, 59, 61, 67, 71,
            73, 79, 83, 89, 97
        };

        int n = nums.Length;
        int first = -1, ans = 0;
        for (int i = 0; i < n; ++i) {
            if (primes.Contains(nums[i])) {
                if (first != -1) {
                    ans = Math.Max(ans, i - first);
                } else {
                    first = i;
                }
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maximumPrimeDifference(self, nums: List[int]) -> int:
        primes = {
            2, 3, 5, 7, 11,
            13, 17, 19, 23, 29,
            31, 37, 41, 43, 47,
            53, 59, 61, 67, 71,
            73, 79, 83, 89, 97
        }

        first, ans = -1, 0
        for i, num in enumerate(nums):
            if num in primes:
                if first != -1:
                    ans = max(ans, i - first)
                else:
                    first = i
        return ans
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

int maximumPrimeDifference(int* nums, int numsSize) {
    int primes[] = {
        2, 3, 5, 7, 11,
        13, 17, 19, 23, 29,
        31, 37, 41, 43, 47,
        53, 59, 61, 67, 71,
        73, 79, 83, 89, 97
    };
    int primesSize = sizeof(primes) / sizeof(int);
    HashItem *set = NULL;
    for (int i = 0; i < primesSize; i++) {
        hashAddItem(&set, primes[i]);
    }

    int first = -1, ans = 0;
    for (int i = 0; i < numsSize; ++i) {
        if (hashFindItem(&set, nums[i])) {
            if (first != -1) {
                ans = fmax(ans, i - first);
            } else {
                first = i;
            }
        }
    }
    hashFree(&set);
    return ans;
}
```

```JavaScript
var maximumPrimeDifference = function(nums) {
    const primes = new Set([
        2, 3, 5, 7, 11,
        13, 17, 19, 23, 29,
        31, 37, 41, 43, 47,
        53, 59, 61, 67, 71,
        73, 79, 83, 89, 97
    ]);

    const n = nums.length;
    let first = -1, ans = 0;
    for (let i = 0; i < n; ++i) {
        if (primes.has(nums[i])) {
            if (first !== -1) {
                ans = Math.max(ans, i - first);
            } else {
                first = i;
            }
        }
    }
    return ans;
};
```

```TypeScript
function maximumPrimeDifference(nums: number[]): number {
    const primes: Set<number> = new Set([
        2, 3, 5, 7, 11,
        13, 17, 19, 23, 29,
        31, 37, 41, 43, 47,
        53, 59, 61, 67, 71,
        73, 79, 83, 89, 97
    ]);

    const n: number = nums.length;
    let first: number = -1, ans: number = 0;
    for (let i: number = 0; i < n; ++i) {
        if (primes.has(nums[i])) {
            if (first !== -1) {
                ans = Math.max(ans, i - first);
            } else {
                first = i;
            }
        }
    }
    return ans;
};
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn maximum_prime_difference(nums: Vec<i32>) -> i32 {
        let primes: HashSet<i32> = [
            2, 3, 5, 7, 11,
            13, 17, 19, 23, 29,
            31, 37, 41, 43, 47,
            53, 59, 61, 67, 71,
            73, 79, 83, 89, 97
        ].iter().cloned().collect();

        let mut first = -1;
        let mut ans = 0;

        for (i, &num) in nums.iter().enumerate() {
            if primes.contains(&num) {
                if first != -1 {
                    ans = ans.max(i as i32 - first);
                } else {
                    first = i as i32;
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+K)$，其中 $n$ 是数组 $nums$ 的长度。如果直接显示列举所有的质数，那么 $K=O(\dfrac{C}{logC})$（质数的密度），其中 $C$ 是数组 $nums$ 元素的范围。如果使用「[筛法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmath%2Fnumber-theory%2Fsieve%2F)」得到所有的质数，那么根据使用的筛不同，$K=O(CloglogC)$（埃氏筛）或 $K=O(C)$（线性筛）。
- 空间复杂度：如果直接显示列举所有的质数，那么空间复杂度为 $O(\dfrac{C}{logC})$，否则为 $O(C)$。
