### [找出最长等值子数组](https://leetcode.cn/problems/find-the-longest-equal-subarray/solutions/2784932/zhao-chu-zui-chang-deng-zhi-zi-shu-zu-by-vcnw/)

#### 方法一：滑动窗口

**思路与算法**

题目要求找到数组中删除最多 $k$ 个元素后**最长等值子数组**的长度，所谓**最长等值子数组**即数组种连续相同元素的最长长度。假设可以找到数组中每个不同元素构成的的**最长等值子数组**，即可找到全局的最大值。首先我们需要对数组中的元素进行分类，然后依次枚举求出每个不同元素构成的**最长等值子数组**长度。

首先分析一个简单问题，假定给定区间 $[l,r]$，此时元素 $x$ 在区间出现的次数为 $\textit{cnt}[x]$，则该区间中以要构造以 $x$ 为等值子数组需要删除的元素个数即为 $r - l + 1 - \textit{cnt}[x]$，如果此时 $r - l + 1 - \textit{cnt}[x] \le k$，则可以构成一个符合题意的**等值子数组**。

我们将索引按照不同元素进行分类，假设元素 $x$ 在数组中从小到大出现的位置为 $a_0,a_1,\cdots,a_m$ ，此时枚举不同的区间 $[a_j,a_i]$ 并计算出区间中构成的**等值子数组**的长度即可，此时给定区间内需要删除的元素个数即为 $a_i - a_j - (i - j)$。实际我们不必枚举所有的区间，可以利用**滑动窗口**的思路，只需枚举区间的右端点 aia_iai ，当区间 $[a_j,a_i]$ 需要删除的元素大于 $k$ 时我们再移动 $a_j$ ，直到区间需要删除的元素小于等于 $k$，即此时满足 $a_i - a_j - (i - j) \le k$ 即可。找到所有合法**等值子数组**的长度，返回最大值即可。

**代码**

```C++
class Solution {
public:
    int longestEqualSubarray(vector<int>& nums, int k) {
        int n = nums.size();
        unordered_map<int, vector<int>> pos;
        for (int i = 0; i < n; i++) {
            pos[nums[i]].emplace_back(i);
        }
        int ans = 0;
        for (auto &[_, vec] : pos) {
            /* 缩小窗口，直到不同元素数量小于等于 k */
            for (int i = 0, j = 0; i < vec.size(); i++) {
                while (vec[i] - vec[j] - (i - j) > k) {
                    j++;
                }
                ans = max(ans, i - j + 1);
            }
        }
        return ans;
    }
};
```

```C
int longestEqualSubarray(int* nums, int numsSize, int k){
    int cnt[numsSize + 1];
    int *pos[numsSize + 1];
    int arrSize[numsSize + 1];
    memset(cnt, 0, sizeof(cnt));
    memset(arrSize, 0, sizeof(arrSize));
    memset(pos, 0, sizeof(pos));

    for (int i = 0; i < numsSize; i++) {
        cnt[nums[i]]++;
    }
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        if (pos[x] == NULL) {
            pos[x] = (int *)malloc(sizeof(int) * cnt[x]);
        }
        pos[x][arrSize[x]++] = i;
    }
    int ans = 0;
    for (int t = 0; t <= numsSize; t++) {
        for (int i = 0, j = 0; i < cnt[t]; i++) {
            /* 缩小窗口，直到不同元素数量小于等于 k */
            while (pos[t][i] - pos[t][j] - (i - j) > k) {
                j++;
            }
            ans = fmax(ans, i - j + 1);
        }
    }
    for (int i = 0; i <= numsSize; i++) {
        free(pos[i]);
    }
    return ans;
}
```

```Java
class Solution {
    public int longestEqualSubarray(List<Integer> nums, int k) {
        int n = nums.size();
        Map<Integer, List<Integer>> pos = new HashMap<>();
        for (int i = 0; i < n; i++) {
            pos.computeIfAbsent(nums.get(i), x -> new ArrayList<>()).add(i);
        }
        int ans = 0;
        for (List<Integer> vec : pos.values()) {
            for (int i = 0, j = 0; i < vec.size(); i++) {
                /* 缩小窗口，直到不同元素数量小于等于 k */
                while (vec.get(i) - vec.get(j) - (i - j) > k) {
                    j++;
                }
                ans = Math.max(ans, i - j + 1);
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int LongestEqualSubarray(IList<int> nums, int k) {
        int n = nums.Count;
        IDictionary<int, IList<int>> pos = new Dictionary<int, IList<int>>();
        for (int i = 0; i < n; i++) {
            pos.TryAdd(nums[i], new List<int>());
            pos[nums[i]].Add(i);
        }
        int ans = 0;
        foreach (IList<int> vec in pos.Values) {
            for (int i = 0, j = 0; i < vec.Count; i++) {
                /* 缩小窗口，直到不同元素数量小于等于 k */
                while (vec[i] - vec[j] - (i - j) > k) {
                    j++;
                }
                ans = Math.Max(ans, i - j + 1);
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def longestEqualSubarray(self, nums: List[int], k: int) -> int:
        pos = defaultdict(list)
        for i, num in enumerate(nums):
            pos[num].append(i)

        ans = 0
        for vec in pos.values():
            j = 0
            for i in range(len(vec)):
                # 缩小窗口，直到不同元素数量小于等于 k 
                while vec[i] - vec[j] - (i - j) > k:
                    j += 1
                ans = max(ans, i - j + 1)

        return ans
```

```Go
func longestEqualSubarray(nums []int, k int) int {
    pos := make(map[int][]int)
    for i, num := range nums {
        pos[num] = append(pos[num], i)
    }
    ans := 0
    for _, vec := range pos {
        j := 0
        for i := 0; i < len(vec); i++ {
            /* 缩小窗口，直到不同元素数量小于等于 k */
            for vec[i] - vec[j] - (i - j) > k {
                j++
            }
            ans = max(ans, i - j + 1)
        }
    }
    return ans
}
```

```JavaScript
var longestEqualSubarray = function(nums, k) {
    let n = nums.length;
    let pos = new Map();
    for (let i = 0; i < n; i++) {
        if (!pos.has(nums[i])) {
            pos.set(nums[i], []);
        }
        pos.get(nums[i]).push(i);
    }
    let ans = 0;
    for (let vec of pos.values()) {
        for (let i = 0, j = 0; i < vec.length; i++) {
            /* 缩小窗口，直到不同元素数量小于等于 k */
            while (vec[i] - vec[j] - (i - j) > k) {
                j++;
            }
            ans = Math.max(ans, i - j + 1);
        }
    }
    return ans;
};
```

```TypeScript
function longestEqualSubarray(nums: number[], k: number): number {
    let n = nums.length;
    let pos = new Map<number, number[]>();
    for (let i = 0; i < n; i++) {
        if (!pos.has(nums[i])) {
            pos.set(nums[i], []);
        }
        pos.get(nums[i]).push(i);
    }
    let ans = 0;
    for (let vec of pos.values()) {
        for (let i = 0, j = 0; i < vec.length; i++) {
            /* 缩小窗口，直到不同元素数量小于等于 k */
            while (vec[i] - vec[j] - (i - j) > k) {
                j++;
            }
            ans = Math.max(ans, i - j + 1);
        }
    }
    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn longest_equal_subarray(nums: Vec<i32>, k: i32) -> i32 {
        let mut pos: HashMap<i32, Vec<usize>> = HashMap::new();
        let n = nums.len();
        for (i, &num) in nums.iter().enumerate() {
            pos.entry(num).or_insert(Vec::new()).push(i);
        }
        let mut ans = 0;
        for vec in pos.values() {
            let mut j = 0;
            for i in 0..vec.len() {
                /* 缩小窗口，直到不同元素数量小于等于 k */
                while vec[i] as i32 - vec[j] as i32 - (i as i32 - j as i32) > k {
                    j += 1;
                }
                ans = ans.max(i - j + 1);
            }
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示数组 $\textit{nums}$ 的长度。分组需要的时间复杂度为 $O(n)$，通过滑动窗口找到每种元素的最大长度只需遍历所有的连续相等字符的长度计数即可，最多有 $n$ 个连续字符串的长度计数，因此总的时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示数组 $\textit{nums}$ 的长度。分组保存每种元素的索引序列需要的空间为 $O(n)$。

#### 方法二：一次遍历优化

**思路与算法**

根据方法一的可知，假设求给定的区间 $[l,r]$ 的等值子数组，则此时区间中最优选择的**等值元素**一定是 $\textit{nums}[l]$，且此时满足 $\textit{nums}[l] = \textit{nums}[r]$，$nums[l]$ 为区间 $[l,r]$ 的「[众数](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%BC%97%E6%95%B0%2F44796)」。最优选择的等值元素为 $x$，当 $x$ 为「[众数](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%BC%97%E6%95%B0%2F44796)」时需要删除的元素个数最少，如果此时 $x \neq \textit{nums}[l]$，则实际还需要删除 $\textit{nums}[l]$，相当于多删除了一次，此时应该将 $l$ 右移，直到 $\textit{nums}[l] = x$。

我们只需要计算满足 $x = \textit{nums}[l] = \textit{nums}[r]$ 且 $x$ 为众数的最优区间即可，此时如果区间 $[l,r]$ 中除 $x$ 以外的元素个数小于等于 $k$ 即可构成合法的**等值子数组**。实际计算时，我们枚举区间的右边界 $r$，此时对于左边界 $l$：

- 如果 $\textit{nums}[l] = \textit{nums}[r]$，此时在区间 $[l,r]$ 中除 $\textit{nums}[l]$ 以外的元素个数大于 $k$ 时，此时需要将区间向右移动；
- 如果 $\textit{nums}[l] \neq \textit{nums}[r]$，此时在区间 $[l,r]$ 中除 $\textit{nums}[l]$ 以外的元素个数大于 $k$ 时，此时 $\textit{nums}[l]$ 一定不是目标等值元素 $x$，此时可以跳过 $\textit{nums}[l]$，将区间向右移动；
- 对于最优解来说需要满足 $\textit{nums}[l] = \textit{nums}[r]$ 且 $\textit{nums}[l]$ 可做为目标等值元素。只需要统计满足 $\textit{nums}[l]$ 可以做为等值元素的区间即可，最优解一定包含在该范围中，此时我们需要计算 $\textit{nums}[r]$ 出现的次数；

**代码**

```C++
class Solution {
public:
    int longestEqualSubarray(vector<int>& nums, int k) {
        int n = nums.size();
        int ans = 0;
        unordered_map<int, int> cnt;
        for (int i = 0, j = 0; j < n; j++) {
            cnt[nums[j]]++;
            /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
            while (j - i + 1 - cnt[nums[i]] > k) {
                cnt[nums[i]]--;
                i++;
            }
            ans = max(ans, cnt[nums[j]]);
        }
        return ans;
    }
};
```

```C
int longestEqualSubarray(int* nums, int numsSize, int k){
    int cnt[numsSize + 1];
    int ans = 0;
    memset(cnt, 0, sizeof(cnt));

    for (int i = 0, j = 0; j < numsSize; j++) {
        cnt[nums[j]]++;
        /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
        while (j - i + 1 - cnt[nums[i]] > k) {
            cnt[nums[i]]--;
            i++;
        }
        ans = fmax(ans, cnt[nums[j]]);
    }
    return ans;
}
```

```Java
class Solution {
    public int longestEqualSubarray(List<Integer> nums, int k) {
        int n = nums.size();
        int ans = 0;
        Map<Integer, Integer> cnt = new HashMap<>();
        for (int i = 0, j = 0; j < n; j++) {
            cnt.put(nums.get(j), cnt.getOrDefault(nums.get(j), 0) + 1);
            /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
            while (j - i + 1 - cnt.get(nums.get(i)) > k) {
                cnt.put(nums.get(i), cnt.get(nums.get(i)) - 1);
                i++;
            }
            ans = Math.max(ans, cnt.get(nums.get(j)));
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int LongestEqualSubarray(IList<int> nums, int k) {
        int n = nums.Count;
        int ans = 0;
        IDictionary<int, int> cnt = new Dictionary<int, int>();
        for (int i = 0, j = 0; j < n; j++) {
            cnt.TryAdd(nums[j], 0);
            cnt[nums[j]]++;
            /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
            while (j - i + 1 - cnt[nums[i]] > k) {
                cnt[nums[i]]--;
                i++;
            }
            ans = Math.Max(ans, cnt[nums[j]]);
        }
        return ans;
    }
}
```

```Python
class Solution:
    def longestEqualSubarray(self, nums: List[int], k: int) -> int:
        ans = 0
        cnt = defaultdict(int)
        i = 0
        for j, x in enumerate(nums):
            cnt[x] += 1
            # 当前区间中，无法以 nums[i] 为等值元素构成合法等值数组
            while j - i + 1 - cnt[nums[i]] > k:
                cnt[nums[i]] -= 1
                i += 1
            ans = max(ans, cnt[nums[j]])
        return ans
```

```Go
func longestEqualSubarray(nums []int, k int) int {
    n := len(nums)
    ans := 0
    cnt := make(map[int]int)
    for i, j := 0, 0; j < n; j++ {
        cnt[nums[j]]++
        /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
        for j - i + 1 - cnt[nums[i]] > k {
            cnt[nums[i]]--
            i++
        }
        if cnt[nums[j]] > ans {
            ans = cnt[nums[j]]
        }
    }
    return ans
}
```

```JavaScript
var longestEqualSubarray = function(nums, k) {
    let n = nums.length;
    let ans = 0;
    let cnt = new Map();
    for (let i = 0, j = 0; j < n; j++) {
        cnt.set(nums[j], (cnt.get(nums[j]) || 0) + 1);
        /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
        while (j - i + 1 - cnt.get(nums[i]) > k) {
            cnt.set(nums[i], cnt.get(nums[i]) - 1);
            i++;
        }
        ans = Math.max(ans, cnt.get(nums[j]));
    }
    return ans;
};
```

```TypeScript
function longestEqualSubarray(nums: number[], k: number): number {
    let n = nums.length;
    let ans = 0;
    let cnt = new Map<number, number>();
    for (let i = 0, j = 0; j < n; j++) {
        cnt.set(nums[j], (cnt.get(nums[j]) || 0) + 1);
        /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
        while (j - i + 1 - (cnt.get(nums[i]) as number) > k) {
            cnt.set(nums[i], (cnt.get(nums[i]) as number) - 1);
            i++;
        }
        ans = Math.max(ans, cnt.get(nums[j]) as number);
    }
    return ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn longest_equal_subarray(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let mut ans = 0;
        let mut cnt = HashMap::new();
        let mut i = 0;
        for j in 0..n {
            *cnt.entry(nums[j]).or_insert(0) += 1;
            /*当前区间中，无法以 nums[i] 为等值元素构成合法等值数组*/
            while j as i32 - i as i32 + 1 - cnt[&nums[i]] > k {
                *cnt.get_mut(&nums[i]).unwrap() -= 1;
                i += 1;
            }
            ans = ans.max(cnt[&nums[j]]);
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示数组 $\textit{nums}$ 的长度。通过滑动窗口找到最优解需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示数组 $\textit{nums}$ 的长度。分组保存每种元素的索引序列需要的空间为 $O(n)$。
