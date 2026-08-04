### [找出缺失的元素](https://leetcode.cn/problems/find-missing-elements/solutions/4000587/zhao-chu-que-shi-de-yuan-su-by-leetcode-o4gtw/)

#### 方法一：排序 + 枚举

**思路与算法**

我们可以先对数组进行排序。对于每一个元素 $nums[i]$，范围 $[nums[i]+1,nums[i+1])$ 中的所有元素都是缺失元素。

**代码**

```C++
class Solution {
public:
    vector<int> findMissingElements(vector<int>& nums) {
        int n = nums.size();
        ranges::sort(nums);
        vector<int> ans;
        for (int i = 0; i < n - 1; i++) {
            for (int j = nums[i] + 1; j < nums[i + 1]; j++) {
                ans.push_back(j);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<Integer> findMissingElements(int[] nums) {
        Arrays.sort(nums);
        List<Integer> ans = new ArrayList<>();

        for (int i = 0; i < nums.length - 1; i++) {
            for (int j = nums[i] + 1; j < nums[i + 1]; j++) {
                ans.add(j);
            }
        }

        return ans;
    }
}
```

```Python
class Solution:
    def findMissingElements(self, nums: List[int]) -> List[int]:
        nums.sort()
        ans = []
        for x, y in pairwise(nums):
            ans.extend(range(x + 1, y))
        return ans
```

```Go
func findMissingElements(nums []int) []int {
    slices.Sort(nums)
    ans := []int{}
    for i := 0; i < len(nums)-1; i++ {
        for j := nums[i] + 1; j < nums[i+1]; j++ {
            ans = append(ans, j)
        }
    }
    return ans
}
```

```CSharp
public class Solution {
    public IList<int> FindMissingElements(int[] nums) {
        Array.Sort(nums);
        var ans = new List<int>();
        for (int i = 0; i < nums.Length - 1; i++) {
            for (int j = nums[i] + 1; j < nums[i + 1]; j++) {
                ans.Add(j);
            }
        }
        return ans;
    }
}
```

```C
int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int* findMissingElements(int* nums, int numsSize, int* returnSize) {
    qsort(nums, numsSize, sizeof(int), cmp);

    int capacity = nums[numsSize - 1] - nums[0];
    int* ans = (int*)malloc(capacity * sizeof(int));
    int cnt = 0;

    for (int i = 0; i < numsSize - 1; i++) {
        for (int j = nums[i] + 1; j < nums[i + 1]; j++) {
            ans[cnt++] = j;
        }
    }

    *returnSize = cnt;
    return ans;
}
```

```JavaScript
var findMissingElements = function(nums) {
    nums.sort((a, b) => a - b);
    const ans = [];
    for (let i = 0; i < nums.length - 1; i++) {
        for (let j = nums[i] + 1; j < nums[i + 1]; j++) {
            ans.push(j);
        }
    }
    return ans;
};
```

```TypeScript
function findMissingElements(nums: number[]): number[] {
    nums.sort((a, b) => a - b);
    const ans: number[] = [];
    for (let i = 0; i < nums.length - 1; i++) {
        for (let j = nums[i] + 1; j < nums[i + 1]; j++) {
            ans.push(j);
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn find_missing_elements(mut nums: Vec<i32>) -> Vec<i32> {
        nums.sort_unstable();
        let mut ans = Vec::new();
        for i in 0..nums.len() - 1 {
            for x in nums[i] + 1..nums[i + 1] {
                ans.push(x);
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+D)$，其中 $n$ 是 $nums$ 的长度，$D$ 是 $nums$ 中最大值和最小值的差值。排序的时间是 $O(n\log n)$，排序之后遍历数组计算缺失的元素的时间是 $O(D)$，因此时间复杂度是 $O(n\log n+D)$。
- 空间复杂度：$O(1)$。仅使用了若干额外变量，返回数组不计入复杂度。

#### 方法二：哈希集合 $+$ 枚举

**思路与算法**

我们可以使用一个哈希集合保存所有的元素，然后枚举从最小值到最大值的每一个值，判断其是否存在于哈希集合中。

**代码**

```C++
class Solution {
public:
    vector<int> findMissingElements(vector<int>& nums) {
        unordered_set<int> st(nums.begin(), nums.end());
        int mn = ranges::min(nums);
        int mx = ranges::max(nums);
        vector<int> ans;
        for (int i = mn + 1; i < mx; i++) {
            if (!st.contains(i)) {
                ans.push_back(i);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<Integer> findMissingElements(int[] nums) {
        Set<Integer> st = new HashSet<>();
        int mn = Integer.MAX_VALUE;
        int mx = Integer.MIN_VALUE;
        for (int x : nums) {
            st.add(x);
            mn = Math.min(mn, x);
            mx = Math.max(mx, x);
        }

        List<Integer> ans = new ArrayList<>();
        for (int i = mn + 1; i < mx; i++) {
            if (!st.contains(i)) {
                ans.add(i);
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def findMissingElements(self, nums: List[int]) -> List[int]:
        st = set(nums)
        mn = min(nums)
        mx = max(nums)
        return [x for x in range(mn + 1, mx) if x not in st]
```

```Go
func findMissingElements(nums []int) []int {
    st := make(map[int]struct{}, len(nums))
    mn, mx := nums[0], nums[0]
    for _, x := range nums {
        st[x] = struct{}{}
        if x < mn {
            mn = x
        }
        if x > mx {
            mx = x
        }
    }

    ans := []int{}
    for i := mn + 1; i < mx; i++ {
        if _, ok := st[i]; !ok {
            ans = append(ans, i)
        }
    }
    return ans
}
```

```CSharp
public class Solution {
    public IList<int> FindMissingElements(int[] nums) {
        var st = new HashSet<int>(nums);
        int mn = nums.Min();
        int mx = nums.Max();

        var ans = new List<int>();
        for (int i = mn + 1; i < mx; i++) {
            if (!st.Contains(i)) {
                ans.Add(i);
            }
        }
        return ans;
    }
}
```

```C
int* findMissingElements(int* nums, int numsSize, int* returnSize) {
    int mn = nums[0], mx = nums[0];
    for (int i = 1; i < numsSize; i++) {
        if (nums[i] < mn) mn = nums[i];
        if (nums[i] > mx) mx = nums[i];
    }

    int range = mx - mn + 1;
    char* vis = (char*)calloc(range, sizeof(char));
    for (int i = 0; i < numsSize; i++) {
        vis[nums[i] - mn] = 1;
    }

    int* ans = (int*)malloc(range * sizeof(int));
    int cnt = 0;
    for (int i = mn + 1; i < mx; i++) {
        if (!vis[i - mn]) {
            ans[cnt++] = i;
        }
    }

    free(vis);
    *returnSize = cnt;
    return ans;
}
```

```JavaScript
var findMissingElements = function(nums) {
    const st = new Set(nums);
    const mn = Math.min(...nums);
    const mx = Math.max(...nums);

    const ans = [];
    for (let i = mn + 1; i < mx; i++) {
        if (!st.has(i)) {
            ans.push(i);
        }
    }
    return ans;
};
```

```TypeScript
function findMissingElements(nums: number[]): number[] {
    const st = new Set(nums);
    const mn = Math.min(...nums);
    const mx = Math.max(...nums);

    const ans: number[] = [];
    for (let i = mn + 1; i < mx; i++) {
        if (!st.has(i)) {
            ans.push(i);
        }
    }
    return ans;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn find_missing_elements(nums: Vec<i32>) -> Vec<i32> {
        let st: HashSet<i32> = nums.iter().copied().collect();
        let &mn = nums.iter().min().unwrap();
        let &mx = nums.iter().max().unwrap();

        let mut ans = Vec::new();
        for x in mn + 1..mx {
            if !st.contains(&x) {
                ans.push(x);
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(D+n)$，其中 $D$ 是 $nums$ 中最大值和最小值的差值，$n$ 是 $nums$ 的长度。枚举最小值到最大值的每一个值需要 $O(D)$，计算数组中的最大值和最小值需要遍历整个数组。
- 空间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。哈希集合需要 $O(n)$ 空间。
