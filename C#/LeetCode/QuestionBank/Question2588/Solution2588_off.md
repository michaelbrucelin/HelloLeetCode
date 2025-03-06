### [统计美丽子数组数目](https://leetcode.cn/problems/count-the-number-of-beautiful-subarrays/solutions/3088649/tong-ji-mei-li-zi-shu-zu-shu-mu-by-leetc-xvig/)

#### 方法一：前缀和

**思路与算法**

根据题意可以知，由于每次操作中需要从子数组中选择两个不同的数分别减去 $2^k$，使得子数组中所有元素均变为 $0$，由此可知对于子数组中所有元素 $2^k$ 出现的次数之和必须是偶数。换一种说法，即对于二进制中第 $i$ 位，则数组中所有元素第 $i$ 位为 $1$ 的数目一定为偶数，则此时满足数组中所有元素第 $i$ 位的异或和一定为 $0$。

根据上述推论可知，如果给定的子数组 $nums[i \dots j]$ 为**美丽子数组**，则此时一定满足:

$$nums[i] \oplus nums[i+1] \oplus nums[i+2] \oplus nums[i+3] \dots nums[j]=0$$

此时我们只需要找到满足元素异或值为 $0$ 的子数组即可。假设数组中前 $j+1$ 个元素 $nums[0 \dots j]$ 异或的结果为 $x$，即此时满足：

$$nums[0] \oplus nums[1] \oplus nums[2] \oplus nums[3] \dots nums[j]=x$$

此时期望能够计算出以索引 $j$ 为结尾的**美丽子数组**数目，由于任意数字 $x$ 与 $0$ 异或的结果仍然为 $x$，即 $x \oplus 0=x$，如果此时存在 $k$ 且 $k<j$，且满足子数组 $nums[0 \dots k]$ 异或的结果为 $x$，即：

$$nums[0] \oplus nums[1] \oplus nums[2] \oplus nums[3] \dots nums[k]=x$$

则此时子数组 $nums[k+1 \dots j]$ 异或的结果一定为 $0$，此时子数组 $nums[k+1 \dots j]$ 一定为**美丽子数组**，此时只需要找到数组 $nums$ 满足前缀异或的结果为 $x$ 的数目，即可得到以 j 为结尾的**美丽子数组**的数目。
实际计算时，可参考「[560\. 和为 K 的子数组](https://leetcode.cn/problems/subarray-sum-equals-k/solutions/238572/he-wei-kde-zi-shu-zu-by-leetcode-solution/)」方法二的解法，设 $p[i]$ 表示数组前缀 $nums[0 \dots i]$ 的异或值，我们依次从小到大枚举下标 $i$，维护哈希表 $cnt[x]$ 表示满足前缀异或值 $p[j]=x$ 且 $j<i$ 的数目，此时以 $i$ 为结尾的**美丽子数组**的数目即为 $cnt[p[i]]$，将该数目累加到返回结果 $ans$ 中，并更新 $cnt[p[i]]$ 加 $1$，最后返回累加结果 $ans$ 即可。

**代码**

```C++
class Solution {
public:
    long long beautifulSubarrays(vector<int>& nums) {
        unordered_map<int, int> cnt;
        int mask = 0;
        long long ans = 0;
        cnt[0] = 1;
        for (int x : nums) {
            mask ^= x;
            ans += cnt[mask]; 
            cnt[mask]++;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public long beautifulSubarrays(int[] nums) {
        Map<Integer, Integer> cnt = new HashMap<>();
        int mask = 0;
        long ans = 0;
        cnt.put(0, 1);
        for (int x : nums) {
            mask ^= x;
            ans += cnt.getOrDefault(mask, 0);
            cnt.put(mask, cnt.getOrDefault(mask, 0) + 1);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long BeautifulSubarrays(int[] nums) {
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        int mask = 0;
        long ans = 0;
        cnt[0] = 1;
        foreach (int x in nums) {
            mask ^= x;
            if (cnt.ContainsKey(mask)) {
                ans += cnt[mask];
            }
            if (cnt.ContainsKey(mask)) {
                cnt[mask]++;
            } else {
                cnt[mask] = 1;
            }
        }
        return ans;
    }
}
```

```Go
func beautifulSubarrays(nums []int) int64 {
    cnt := make(map[int]int)
    mask := 0
    var ans int64 = 0
    cnt[0] = 1
    for _, x := range nums {
        mask ^= x
        ans += int64(cnt[mask])
        cnt[mask]++
    }
    return ans
}
```

```Python
class Solution:
    def beautifulSubarrays(self, nums: List[int]) -> int:
        cnt = {0: 1}
        mask = 0
        ans = 0
        for x in nums:
            mask ^= x
            ans += cnt.get(mask, 0)
            cnt[mask] = cnt.get(mask, 0) + 1
        return ans
```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

long long beautifulSubarrays(int* nums, int numsSize) {
    HashItem *cnt = NULL;
    int mask = 0;
    long long ans = 0;

    hashAddItem(&cnt, 0, 1);
    for (int i = 0; i < numsSize; i++) {
        mask ^= nums[i];
        ans += hashGetItem(&cnt, mask, 0); 
        hashSetItem(&cnt, mask, hashGetItem(&cnt, mask, 0) + 1);
    }

    return ans;
}
```

```JavaScript
var beautifulSubarrays = function(nums) {
    const cnt = new Map();
    cnt.set(0, 1);
    let mask = 0, ans = 0;
    for (const x of nums) {
        mask ^= x;
        ans += cnt.get(mask) || 0;
        cnt.set(mask, (cnt.get(mask) || 0) + 1);
    }
    return ans;
};
```

```TypeScript
function beautifulSubarrays(nums: number[]): number {
    const cnt = new Map<number, number>();
    cnt.set(0, 1);
    let mask = 0, ans = 0;
    for (const x of nums) {
        mask ^= x;
        ans += cnt.get(mask) || 0;
        cnt.set(mask, (cnt.get(mask) || 0) + 1);
    }
    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn beautiful_subarrays(nums: Vec<i32>) -> i64 {
        let mut cnt = HashMap::new();
        cnt.insert(0, 1);
        let mut mask = 0;
        let mut ans = 0;
        for x in nums {
            mask ^= x;
            ans += *cnt.get(&mask).unwrap_or(&0);
            *cnt.entry(mask).or_insert(0) += 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。我们只需遍历一遍数组即可，需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。需要存储数组中前 $i$ 个元素异或的值，需要的空间为 $O(n)$。
