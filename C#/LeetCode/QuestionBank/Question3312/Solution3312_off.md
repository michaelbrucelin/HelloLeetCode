### [查询排序后的最大公约数](https://leetcode.cn/problems/sorted-gcd-pair-queries/solutions/3992178/cha-xun-pai-xu-hou-de-zui-da-gong-yue-sh-o8z1/)

#### 方法一：容斥原理 $+$ 前缀和 $+$ 二分查找

**思路与算法**

记 $n$ 为数组 $nums$ 的长度，$m$ 为 $nums$ 中的最大值。

如果直接枚举所有 $O(n^2)$ 量级的数对并计算它们的最大公约数，在 $n$ 可达 $105$ 的规模下显然不可行。本题的关键是从值域角度考虑：由于 $m\le 5\times 10^4$，我们可以统计每个可能的 $GCD$ 值有多少个数对以其为最大公约数。

首先统计每个数值在 $nums$ 中的出现次数，记在数组 $cnt$ 中。然后利用倍数枚举（调和级数），对于每个正整数 $i\in [1,m]$，统计 $nums$ 中有多少个数是 $i$ 的倍数。这些数中任选两个组成的数对，其最大公约数至少是 $i$。

至少是 $i$ 不等于恰好是 $i$，因为其中还包含了最大公约数为 $2i,3i,\dots $ 的数对。因此从大到小遍历 $i$，利用容斥原理：对于每个 $i$，先算出以 $i$ 为公约数的数对个数，然后减去所有以 $i$ 的倍数（$2i,3i,\dots $）为最大公约数的数对个数，剩下的就是以 $i$ 为最大公约数的数对个数。

最后对得到的各个 $GCD$ 的数对个数求前缀和，对于每个查询 $queries[i]$，在不超过某个 $GCD$ 的数对个数前缀和数组中二分查找即可。

**代码**

```C++
class Solution {
public:
    vector<int> gcdValues(vector<int>& nums, vector<long long>& queries) {
        int m = *max_element(nums.begin(), nums.end());
        vector<long long> cnt(m + 1);
        for (int num : nums) {
            cnt[num]++;
        }
        for (int i = 1; i <= m; i++) {
            for (int j = i * 2; j <= m; j += i) {
                cnt[i] += cnt[j];
            }
        }
        for (int i = 1; i <= m; i++) {
            cnt[i] = cnt[i] * (cnt[i] - 1) / 2;
        }
        for (int i = m; i >= 1; i--) {
            for (int j = i * 2; j <= m; j += i) {
                cnt[i] -= cnt[j];
            }
        }
        for (int i = 1; i <= m; i++) {
            cnt[i] += cnt[i - 1];
        }
        vector<int> ans;
        for (long long q : queries) {
            q++;
            int pos = lower_bound(cnt.begin(), cnt.end(), q) - cnt.begin();
            ans.push_back(pos);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def gcdValues(self, nums: List[int], queries: List[int]) -> List[int]:
        m = max(nums)
        cnt = [0] * (m + 1)
        for num in nums:
            cnt[num] += 1
        for i in range(1, m + 1):
            for j in range(i * 2, m + 1, i):
                cnt[i] += cnt[j]
        for i in range(1, m + 1):
            cnt[i] = cnt[i] * (cnt[i] - 1) // 2
        for i in range(m, 0, -1):
            for j in range(i * 2, m + 1, i):
                cnt[i] -= cnt[j]
        for i in range(1, m + 1):
            cnt[i] += cnt[i - 1]
        ans = []
        for q in queries:
            q += 1
            pos = bisect_left(cnt, q)
            ans.append(pos)
        return ans
```

```Java
class Solution {
    public int[] gcdValues(int[] nums, long[] queries) {
        int m = 0;
        for (int num : nums) {
            m = Math.max(m, num);
        }
        long[] cnt = new long[m + 1];
        for (int num : nums) {
            cnt[num]++;
        }
        for (int i = 1; i <= m; i++) {
            for (int j = i * 2; j <= m; j += i) {
                cnt[i] += cnt[j];
            }
        }
        for (int i = 1; i <= m; i++) {
            cnt[i] = cnt[i] * (cnt[i] - 1) / 2;
        }
        for (int i = m; i >= 1; i--) {
            for (int j = i * 2; j <= m; j += i) {
                cnt[i] -= cnt[j];
            }
        }
        for (int i = 1; i <= m; i++) {
            cnt[i] += cnt[i - 1];
        }
        int[] ans = new int[queries.length];
        for (int k = 0; k < queries.length; k++) {
            long q = queries[k] + 1;
            int left = 1, right = m;
            while (left < right) {
                int mid = (left + right) / 2;
                if (cnt[mid] >= q) {
                    right = mid;
                } else {
                    left = mid + 1;
                }
            }
            ans[k] = left;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] GcdValues(int[] nums, long[] queries) {
        int m = nums.Max();
        long[] cnt = new long[m + 1];
        foreach (int num in nums) {
            cnt[num]++;
        }
        for (int i = 1; i <= m; i++) {
            for (int j = i * 2; j <= m; j += i) {
                cnt[i] += cnt[j];
            }
        }
        for (int i = 1; i <= m; i++) {
            cnt[i] = cnt[i] * (cnt[i] - 1) / 2;
        }
        for (int i = m; i >= 1; i--) {
            for (int j = i * 2; j <= m; j += i) {
                cnt[i] -= cnt[j];
            }
        }
        for (int i = 1; i <= m; i++) {
            cnt[i] += cnt[i - 1];
        }
        int[] ans = new int[queries.Length];
        for (int k = 0; k < queries.Length; k++) {
            long q = queries[k] + 1;
            int left = 1, right = m;
            while (left < right) {
                int mid = (left + right) / 2;
                if (cnt[mid] >= q) {
                    right = mid;
                } else {
                    left = mid + 1;
                }
            }
            ans[k] = left;
        }
        return ans;
    }
}
```

```Go
func gcdValues(nums []int, queries []int64) []int {
    m := nums[0]
    for _, num := range nums {
        if num > m {
            m = num
        }
    }
    cnt := make([]int64, m+1)
    for _, num := range nums {
        cnt[num]++
    }
    for i := 1; i <= m; i++ {
        for j := i * 2; j <= m; j += i {
            cnt[i] += cnt[j]
        }
    }
    for i := 1; i <= m; i++ {
        cnt[i] = cnt[i] * (cnt[i] - 1) / 2
    }
    for i := m; i >= 1; i-- {
        for j := i * 2; j <= m; j += i {
            cnt[i] -= cnt[j]
        }
    }
    for i := 1; i <= m; i++ {
        cnt[i] += cnt[i-1]
    }
    ans := make([]int, len(queries))
    for k, q := range queries {
        q++
        left, right := 1, m
        for left < right {
            mid := (left + right) / 2
            if cnt[mid] >= q {
                right = mid
            } else {
                left = mid + 1
            }
        }
        ans[k] = left
    }
    return ans
}
```

```TypeScript
function gcdValues(nums: number[], queries: number[]): number[] {
    const m = Math.max(...nums);
    const cnt: number[] = new Array(m + 1).fill(0);
    for (const num of nums) {
        cnt[num]++;
    }
    for (let i = 1; i <= m; i++) {
        for (let j = i * 2; j <= m; j += i) {
            cnt[i] += cnt[j];
        }
    }
    for (let i = 1; i <= m; i++) {
        cnt[i] = Math.floor(cnt[i] * (cnt[i] - 1) / 2);
    }
    for (let i = m; i >= 1; i--) {
        for (let j = i * 2; j <= m; j += i) {
            cnt[i] -= cnt[j];
        }
    }
    for (let i = 1; i <= m; i++) {
        cnt[i] += cnt[i - 1];
    }
    const ans: number[] = [];
    for (let q of queries) {
        q++;
        let left = 1, right = m;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (cnt[mid] >= q) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        ans.push(left);
    }
    return ans;
}
```

```JavaScript
var gcdValues = function(nums, queries) {
    const m = Math.max(...nums);
    const cnt = new Array(m + 1).fill(0);
    for (const num of nums) {
        cnt[num]++;
    }
    for (let i = 1; i <= m; i++) {
        for (let j = i * 2; j <= m; j += i) {
            cnt[i] += cnt[j];
        }
    }
    for (let i = 1; i <= m; i++) {
        cnt[i] = Math.floor(cnt[i] * (cnt[i] - 1) / 2);
    }
    for (let i = m; i >= 1; i--) {
        for (let j = i * 2; j <= m; j += i) {
            cnt[i] -= cnt[j];
        }
    }
    for (let i = 1; i <= m; i++) {
        cnt[i] += cnt[i - 1];
    }
    const ans = [];
    for (let q of queries) {
        q++;
        let left = 1, right = m;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (cnt[mid] >= q) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        ans.push(left);
    }
    return ans;
};
```

```C
int* gcdValues(int* nums, int numsSize, long long* queries, int queriesSize, int* returnSize) {
    int m = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] > m) {
            m = nums[i];
        }
    }
    long long* cnt = (long long*)calloc(m + 1, sizeof(long long));
    for (int i = 0; i < numsSize; i++) {
        cnt[nums[i]]++;
    }
    for (int i = 1; i <= m; i++) {
        for (int j = i * 2; j <= m; j += i) {
            cnt[i] += cnt[j];
        }
    }
    for (int i = 1; i <= m; i++) {
        cnt[i] = cnt[i] * (cnt[i] - 1) / 2;
    }
    for (int i = m; i >= 1; i--) {
        for (int j = i * 2; j <= m; j += i) {
            cnt[i] -= cnt[j];
        }
    }
    for (int i = 1; i <= m; i++) {
        cnt[i] += cnt[i - 1];
    }
    int* ans = (int*)malloc(queriesSize * sizeof(int));
    for (int k = 0; k < queriesSize; k++) {
        long long q = queries[k] + 1;
        int left = 1, right = m;
        while (left < right) {
            int mid = (left + right) / 2;
            if (cnt[mid] >= q) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        ans[k] = left;
    }
    free(cnt);
    *returnSize = queriesSize;
    return ans;
}
```

```Rust
impl Solution {
    pub fn gcd_values(nums: Vec<i32>, queries: Vec<i64>) -> Vec<i32> {
        let m = *nums.iter().max().unwrap() as usize;
        let mut cnt = vec![0i64; m + 1];
        for &num in &nums {
            cnt[num as usize] += 1;
        }
        for i in 1..=m {
            let mut j = i * 2;
            while j <= m {
                cnt[i] += cnt[j];
                j += i;
            }
        }
        for i in 1..=m {
            cnt[i] = cnt[i] * (cnt[i] - 1) / 2;
        }
        for i in (1..=m).rev() {
            let mut j = i * 2;
            while j <= m {
                cnt[i] -= cnt[j];
                j += i;
            }
        }
        for i in 1..=m {
            cnt[i] += cnt[i - 1];
        }
        let mut ans = Vec::new();
        for &q in &queries {
            let q = (q + 1) as i64;
            let pos = cnt.partition_point(|&x| x < q);
            ans.push(pos as i32);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m\log m+q\log m)$，其中 $m$ 为 $nums$ 中的最大值，$q$ 为 $queries$ 的长度。枚举倍数的调和级数复杂度为 $O(m\log m)$，每个查询二分查找复杂度为 $O(\log m)$。
- 空间复杂度：$O(m)$。需要一个大小为 $m+1$ 的数组来统计信息。
