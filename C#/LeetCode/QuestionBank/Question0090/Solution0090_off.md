### [子集 II](https://leetcode.cn/problems/subsets-ii/solutions/690549/zi-ji-ii-by-leetcode-solution-7inq/)

#### 前言

本题解基于「[78\. 子集的官方题解](https://leetcode-cn.com/problems/subsets/solution/zi-ji-by-leetcode-solution/)」，请读者在充分理解该题解后继续阅读。

#### 方法一：迭代法实现子集枚举

**思路**

考虑数组 $[1,2,2]$，选择前两个数，或者第一、三个数，都会得到相同的子集。

也就是说，对于当前选择的数 $x$，若前面有与其相同的数 $y$，且没有选择 $y$，此时包含 $x$ 的子集，必然会出现在包含 $y$ 的所有子集中。

我们可以通过判断这种情况，来避免生成重复的子集。代码实现时，可以先将数组排序；迭代时，若发现没有选择上一个数，且当前数字与上一个数相同，则可以跳过当前生成的子集。

**代码**

```C++
class Solution {
public:
    vector<int> t;
    vector<vector<int>> ans;

    vector<vector<int>> subsetsWithDup(vector<int> &nums) {
        sort(nums.begin(), nums.end());
        int n = nums.size();
        for (int mask = 0; mask < (1 << n); ++mask) {
            t.clear();
            bool flag = true;
            for (int i = 0; i < n; ++i) {
                if (mask & (1 << i)) {
                    if (i > 0 && (mask >> (i - 1) & 1) == 0 && nums[i] == nums[i - 1]) {
                        flag = false;
                        break;
                    }
                    t.push_back(nums[i]);
                }
            }
            if (flag) {
                ans.push_back(t);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    List<Integer> t = new ArrayList<Integer>();
    List<List<Integer>> ans = new ArrayList<List<Integer>>();

    public List<List<Integer>> subsetsWithDup(int[] nums) {
        Arrays.sort(nums);
        int n = nums.length;
        for (int mask = 0; mask < (1 << n); ++mask) {
            t.clear();
            boolean flag = true;
            for (int i = 0; i < n; ++i) {
                if ((mask & (1 << i)) != 0) {
                    if (i > 0 && (mask >> (i - 1) & 1) == 0 && nums[i] == nums[i - 1]) {
                        flag = false;
                        break;
                    }
                    t.add(nums[i]);
                }
            }
            if (flag) {
                ans.add(new ArrayList<Integer>(t));
            }
        }
        return ans;
    }
}
```

```Go
func subsetsWithDup(nums []int) (ans [][]int) {
    sort.Ints(nums)
    n := len(nums)
outer:
    for mask := 0; mask < 1<<n; mask++ {
        t := []int{}
        for i, v := range nums {
            if mask>>i&1 > 0 {
                if i > 0 && mask>>(i-1)&1 == 0 && v == nums[i-1] {
                    continue outer
                }
                t = append(t, v)
            }
        }
        ans = append(ans, append([]int(nil), t...))
    }
    return
}
```

```JavaScript
var subsetsWithDup = function(nums) {
    nums.sort((a, b) => a - b);
    let t = [], ans = [];
    const n = nums.length;
    for (let mask = 0; mask < (1 << n); ++mask) {
        t = [];
        let flag = true;
        for (let i = 0; i < n; ++i) {
            if ((mask & (1 << i)) != 0) {
                if (i > 0 && (mask >> (i - 1) & 1) == 0 && nums[i] == nums[i - 1]) {
                    flag = false;
                    break;
                }
                t.push(nums[i]);
            }
        }
        if (flag) {
            ans.push(t.slice());
        }
    }
    return ans;
};
```

```C
int** subsetsWithDup(int* nums, int numsSize, int* returnSize, int** returnColumnSizes) {
    qsort(nums, numsSize, sizeof(int), cmp);
    int n = numsSize;
    *returnSize = 0;
    *returnColumnSizes = malloc(sizeof(int) * (1 << n));
    int** ans = malloc(sizeof(int*) * (1 << n));
    for (int mask = 0; mask < (1 << n); ++mask) {
        int* t = malloc(sizeof(int) * n);
        int tSize = 0;
        bool flag = true;
        for (int i = 0; i < n; ++i) {
            if (mask & (1 << i)) {
                if (i > 0 && (mask >> (i - 1) & 1) == 0 && nums[i] == nums[i - 1]) {
                    flag = false;
                    break;
                }
                t[tSize++] = nums[i];
            }
        }
        t = realloc(t, sizeof(int) * tSize);
        if (flag) {
            ans[*returnSize] = t;
            (*returnColumnSizes)[(*returnSize)++] = tSize;
        }
    }
    ans = realloc(ans, sizeof(int*) * (*returnSize));
    return ans;
}
```

```Python
class Solution:
    def subsetsWithDup(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        n = len(nums)
        ans = []
        for mask in range(1 << n):
            t = []
            flag = True
            for i in range(n):
                if mask & (1 << i):
                    if i > 0 and not (mask & (1 << (i - 1))) and nums[i] == nums[i - 1]:
                        flag = False
                        break
                    t.append(nums[i])
            if flag:
                ans.append(t)
        return ans
```

```CSharp
public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> ans = new List<IList<int>>();
        int n = nums.Length;

        for (int mask = 0; mask < (1 << n); ++mask) {
            List<int> t = new List<int>();
            bool flag = true;
            for (int i = 0; i < n; ++i) {
                if ((mask & (1 << i)) != 0) {
                    if (i > 0 && (mask & (1 << (i - 1))) == 0 && nums[i] == nums[i - 1]) {
                        flag = false;
                        break;
                    }
                    t.Add(nums[i]);
                }
            }
            if (flag) {
                ans.Add(t);
            }
        }
        return ans;
    }
}
```

```TypeScript
function subsetsWithDup(nums: number[]): number[][] {
    nums.sort((a, b) => a - b);
    const ans: number[][] = [];
    const n = nums.length;

    for (let mask = 0; mask < (1 << n); ++mask) {
        const t: number[] = [];
        let flag = true;
        for (let i = 0; i < n; ++i) {
            if (mask & (1 << i)) {
                if (i > 0 && (mask & (1 << (i - 1))) === 0 && nums[i] === nums[i - 1]) {
                    flag = false;
                    break;
                }
                t.push(nums[i]);
            }
        }
        if (flag) {
            ans.push(t);
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn subsets_with_dup(nums: Vec<i32>) -> Vec<Vec<i32>> {
        let mut nums = nums;
        nums.sort();
        let mut ans = vec![];
        let n = nums.len();
        for mask in 0..(1 << n) {
            let mut t = vec![];
            let mut flag = true;
            for i in 0..n {
                if (mask & (1 << i)) != 0 {
                    if i > 0 && (mask & (1 << (i - 1))) == 0 && nums[i] == nums[i - 1] {
                        flag = false;
                        break;
                    }
                    t.push(nums[i]);
                }
            }
            if flag {
                ans.push(t);
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times 2^n)$，其中 $n$ 是数组 $nums$ 的长度。排序的时间复杂度为 $O(n \log n)$。一共 $2^n$ 个状态，每种状态需要 $O(n)$ 的时间来构造子集，一共需要 $O(n \times 2^n)$ 的时间来构造子集。由于在渐进意义上 $O(n \log n)$ 小于 $O(n \times 2^n)$，故总的时间复杂度为 $O(n \times 2^n)$。
- 空间复杂度：$O(n)$。即构造子集使用的临时数组 $t$ 的空间代价。

#### 方法二：递归法实现子集枚举

**思路**

与方法一类似，在递归时，若发现没有选择上一个数，且当前数字与上一个数相同，则可以跳过当前生成的子集。

**代码**

```C++
class Solution {
public:
    vector<int> t;
    vector<vector<int>> ans;

    void dfs(bool choosePre, int cur, vector<int> &nums) {
        if (cur == nums.size()) {
            ans.push_back(t);
            return;
        }
        dfs(false, cur + 1, nums);
        if (!choosePre && cur > 0 && nums[cur - 1] == nums[cur]) {
            return;
        }
        t.push_back(nums[cur]);
        dfs(true, cur + 1, nums);
        t.pop_back();
    }

    vector<vector<int>> subsetsWithDup(vector<int> &nums) {
        sort(nums.begin(), nums.end());
        dfs(false, 0, nums);
        return ans;
    }
};
```

```Java
class Solution {
    List<Integer> t = new ArrayList<Integer>();
    List<List<Integer>> ans = new ArrayList<List<Integer>>();

    public List<List<Integer>> subsetsWithDup(int[] nums) {
        Arrays.sort(nums);
        dfs(false, 0, nums);
        return ans;
    }

    public void dfs(boolean choosePre, int cur, int[] nums) {
        if (cur == nums.length) {
            ans.add(new ArrayList<Integer>(t));
            return;
        }
        dfs(false, cur + 1, nums);
        if (!choosePre && cur > 0 && nums[cur - 1] == nums[cur]) {
            return;
        }
        t.add(nums[cur]);
        dfs(true, cur + 1, nums);
        t.remove(t.size() - 1);
    }
}
```

```Go
func subsetsWithDup(nums []int) (ans [][]int) {
    sort.Ints(nums)
    t := []int{}
    var dfs func(bool, int)
    dfs = func(choosePre bool, cur int) {
        if cur == len(nums) {
            ans = append(ans, append([]int(nil), t...))
            return
        }
        dfs(false, cur+1)
        if !choosePre && cur > 0 && nums[cur-1] == nums[cur] {
            return
        }
        t = append(t, nums[cur])
        dfs(true, cur+1)
        t = t[:len(t)-1]
    }
    dfs(false, 0)
    return
}
```

```JavaScript
var subsetsWithDup = function(nums) {
    nums.sort((a, b) => a - b);
    let t = [], ans = [];
    const dfs = (choosePre, cur, nums) => {
        if (cur === nums.length) {
            ans.push(t.slice());
            return;
        }
        dfs(false, cur + 1, nums);
        if (!choosePre && cur > 0 && nums[cur - 1] === nums[cur]) {
            return;
        }
        t.push(nums[cur]);
        dfs(true, cur + 1, nums);
        t = t.slice(0, t.length - 1);
    }
    dfs(false, 0, nums);
    return ans;
};
```

```C
int cmp(int* a, int* b) {
    return *a - *b;
}

int* t;
int tSize;

void dfs(bool choosePre, int cur, int* nums, int numSize, int** ret, int* returnSize, int** returnColumnSizes) {
    if (cur == numSize) {
        int* tmp = malloc(sizeof(int) * tSize);
        memcpy(tmp, t, sizeof(int) * tSize);
        ret[*returnSize] = tmp;
        (*returnColumnSizes)[(*returnSize)++] = tSize;
        return;
    }
    dfs(false, cur + 1, nums, numSize, ret, returnSize, returnColumnSizes);
    if (!choosePre && cur > 0 && nums[cur - 1] == nums[cur]) {
        return;
    }
    t[tSize++] = nums[cur];
    dfs(true, cur + 1, nums, numSize, ret, returnSize, returnColumnSizes);
    tSize--;
}

int** subsetsWithDup(int* nums, int numsSize, int* returnSize, int** returnColumnSizes) {
    qsort(nums, numsSize, sizeof(int), cmp);
    int n = numsSize;
    *returnSize = 0;
    *returnColumnSizes = malloc(sizeof(int) * (1 << n));
    int** ret = malloc(sizeof(int*) * (1 << n));
    t = malloc(sizeof(int) * n);
    dfs(false, 0, nums, n, ret, returnSize, returnColumnSizes);
    return ret;
}
```

```Python
class Solution:
    def subsetsWithDup(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        ans = []
        t = []

        def dfs(choosePre: bool, cur: int):
            if cur == len(nums):
                ans.append(t[:])
                return
            dfs(False, cur + 1)
            if not choosePre and cur > 0 and nums[cur] == nums[cur - 1]:
                return
            t.append(nums[cur])
            dfs(True, cur + 1)
            t.pop()
        dfs(False, 0)
        return ans
```

```CSharp
public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> ans = new List<IList<int>>();
        List<int> t = new List<int>();
        Dfs(false, 0, nums, t, ans);
        return ans;
    }

    private void Dfs(bool choosePre, int cur, int[] nums, List<int> t, IList<IList<int>> ans) {
        if (cur == nums.Length) {
            ans.Add(new List<int>(t));
            return;
        }
        Dfs(false, cur + 1, nums, t, ans);
        if (!choosePre && cur > 0 && nums[cur - 1] == nums[cur]) {
            return;
        }
        t.Add(nums[cur]);
        Dfs(true, cur + 1, nums, t, ans);
        t.RemoveAt(t.Count - 1);
    }
}
```

```TypeScript
function subsetsWithDup(nums: number[]): number[][] {
    nums.sort((a, b) => a - b);
    const ans: number[][] = [];
    const t: number[] = [];

    function dfs(choosePre: boolean, cur: number) {
        if (cur === nums.length) {
            ans.push([...t]);
            return;
        }
        dfs(false, cur + 1);
        if (!choosePre && cur > 0 && nums[cur] === nums[cur - 1]) {
            return;
        }
        t.push(nums[cur]);
        dfs(true, cur + 1);
        t.pop();
    }

    dfs(false, 0);
    return ans;
}
```

```Rust
impl Solution {
    pub fn subsets_with_dup(nums: Vec<i32>) -> Vec<Vec<i32>> {
        fn dfs(nums: &Vec<i32>, cur: usize, choose_pre: bool, t: &mut Vec<i32>, ans: &mut Vec<Vec<i32>>) {
            if cur == nums.len() {
                ans.push(t.clone());
                return;
            }
            dfs(nums, cur + 1, false, t, ans);
            if !choose_pre && cur > 0 && nums[cur] == nums[cur - 1] {
                return;
            }
            t.push(nums[cur]);
            dfs(nums, cur + 1, true, t, ans);
            t.pop();
        }

        let mut nums = nums;
        nums.sort();
        let mut ans = vec![];
        let mut t = vec![];
        dfs(&nums, 0, false, &mut t, &mut ans);
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times 2^n)$，其中 $n$ 是数组 $nums$ 的长度。排序的时间复杂度为 $O(n \log n)$。最坏情况下 $nums$ 中无重复元素，需要枚举其所有 $2^n$ 个子集，每个子集加入答案时需要拷贝一份，耗时 $O(n)$，一共需要 $O(n \times 2^n)$+$O(n)$\=$O(n \times 2^n)$ 的时间来构造子集。由于在渐进意义上 $O(n \log n)$ 小于 $O(n \times 2^n)$，故总的时间复杂度为 $O(n \times 2^n)$。
- 空间复杂度：$O(n)$。临时数组 t 的空间代价是 $O(n)$，递归时栈空间的代价为 $O(n)$。
