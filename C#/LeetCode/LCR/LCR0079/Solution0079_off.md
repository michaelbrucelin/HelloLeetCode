### [所有子集](https://leetcode.cn/problems/TVdhkn/solutions/1411943/suo-you-zi-ji-by-leetcode-solution-my7d/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：迭代法实现子集枚举

**思路与算法**

记原序列中元素的总数为 $n$。原序列中的每个数字 $a_i$ 的状态可能有两种，即「在子集中」和「不在子集中」。我们用 $1$ 表示「在子集中」，$0$ 表示不在子集中，那么每一个子集可以对应一个长度为 $n$ 的 $0/1$ 序列，第 $i$ 位表示 $ai$ 是否在子集中。例如，$n=3$，$a=\{5,2,9\}$ 时：

| 0/1 序列 | 子集 | 0/1 序列对应的二进制数 |
| --- | --- | --- |
| 000 | {} | 0 |
| 001 | {9} | 1 |
| 010 | {2} | 2 |
| 011 | {2,9} | 3 |
| 100 | {5} | 4 |
| 101 | {5,9} | 5 |
| 110 | {5,2} | 6 |
| 111 | {5,2,9} | 7 |

可以发现 $0/1$ 序列对应的二进制数正好从 $0$ 到 $2^n-1$。我们可以枚举 $mask\in [0,2^n-1]$，mask 的二进制表示是一个 $0/1$ 序列，我们可以按照这个 $0/1$ 序列在原集合当中取数。当我们枚举完所有 $2^n$ 个 $mask$，我们也就能构造出所有的子集。

**代码**

```C++
class Solution {
public:
    vector<int> t;
    vector<vector<int>> ans;

    vector<vector<int>> subsets(vector<int>& nums) {
        int n = nums.size();
        for (int mask = 0; mask < (1 << n); ++mask) {
            t.clear();
            for (int i = 0; i < n; ++i) {
                if (mask & (1 << i)) {
                    t.push_back(nums[i]);
                }
            }
            ans.push_back(t);
        }
        return ans;
    }
};
```

```Java
class Solution {
    List<Integer> t = new ArrayList<Integer>();
    List<List<Integer>> ans = new ArrayList<List<Integer>>();

    public List<List<Integer>> subsets(int[] nums) {
        int n = nums.length;
        for (int mask = 0; mask < (1 << n); ++mask) {
            t.clear();
            for (int i = 0; i < n; ++i) {
                if ((mask & (1 << i)) != 0) {
                    t.add(nums[i]);
                }
            }
            ans.add(new ArrayList<Integer>(t));
        }
        return ans;
    }
}
```

```Go
func subsets(nums []int) (ans [][]int) {
    n := len(nums)
    for mask := 0; mask < 1<<n; mask++ {
        set := []int{}
        for i, v := range nums {
            if mask>>i&1 > 0 {
                set = append(set, v)
            }
        }
        ans = append(ans, append([]int(nil), set...))
    }
    return
}
```

```JavaScript
var subsets = function(nums) {
    const ans = [];
    const n = nums.length;
    for (let mask = 0; mask < (1 << n); ++mask) {
        const t = [];
        for (let i = 0; i < n; ++i) {
            if (mask & (1 << i)) {
                t.push(nums[i]);
            }
        }
        ans.push(t);
    }
    return ans;
};
```

```C
int** subsets(int* nums, int numsSize, int* returnSize, int** returnColumnSizes) {
    int** ans = malloc(sizeof(int*) * (1 << numsSize));
    *returnColumnSizes = malloc(sizeof(int) * (1 << numsSize));
    *returnSize = 1 << numsSize;
    int t[numsSize];
    for (int mask = 0; mask < (1 << numsSize); ++mask) {
        int tSize = 0;
        for (int i = 0; i < numsSize; ++i) {
            if (mask & (1 << i)) {
                t[tSize++] = nums[i];
            }
        }
        int* tmp = malloc(sizeof(int) * tSize);
        memcpy(tmp, t, sizeof(int) * tSize);
        (*returnColumnSizes)[mask] = tSize;
        ans[mask] = tmp;
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n\times 2^n)$。一共 $2^n$ 个状态，每种状态需要 $O(n)$ 的时间来构造子集。
- 空间复杂度：$O(n)$。即构造子集使用的临时数组 $t$ 的空间代价。

#### 方法二：递归法实现子集枚举

**思路与算法**

我们也可以用递归来实现子集枚举。

假设我们需要找到一个长度为 $n$ 的序列 $a$ 的所有子序列，代码框架是这样的：

```C++
vector<int> t;
void dfs(int cur, int n) {
    if (cur == n) {
        // 记录答案
        // ...
        return;
    }
    // 考虑选择当前位置
    t.push_back(cur);
    dfs(cur + 1, n, k);
    t.pop_back();
    // 考虑不选择当前位置
    dfs(cur + 1, n, k);
}
```

上面的代码中，$dfs(cur,n)$ 参数表示当前位置是 $cur$，原序列总长度为 $n$。原序列的每个位置在答案序列中的状态有被选中和不被选中两种，我们用 $t$ 数组存放已经被选出的数字。在进入 $dfs(cur,n)$ 之前 $[0,cur-1]$ 位置的状态是确定的，而 $[cur,n-1]$ 内位置的状态是不确定的，$dfs(cur,n)$ 需要确定 $cur$ 位置的状态，然后求解子问题 $dfs(cur+1,n)$。对于 $cur$ 位置，我们需要考虑 $a[cur]$ 取或者不取，如果取，我们需要把 $a[cur]$ 放入一个临时的答案数组中（即上面代码中的 $t$），再执行 $dfs(cur+1,n)$，执行结束后需要对 $t$ 进行回溯；如果不取，则直接执行 $dfs(cur+1,n)$。在整个递归调用的过程中，$cur$ 是从小到大递增的，当 $cur$ 增加到 $n$ 的时候，记录答案并终止递归。可以看出二进制枚举的时间复杂度是 $O(2^n)$。

**代码**

```C++
class Solution {
public:
    vector<int> t;
    vector<vector<int>> ans;

    void dfs(int cur, vector<int>& nums) {
        if (cur == nums.size()) {
            ans.push_back(t);
            return;
        }
        t.push_back(nums[cur]);
        dfs(cur + 1, nums);
        t.pop_back();
        dfs(cur + 1, nums);
    }

    vector<vector<int>> subsets(vector<int>& nums) {
        dfs(0, nums);
        return ans;
    }
};
```

```Java
class Solution {
    List<Integer> t = new ArrayList<Integer>();
    List<List<Integer>> ans = new ArrayList<List<Integer>>();

    public List<List<Integer>> subsets(int[] nums) {
        dfs(0, nums);
        return ans;
    }

    public void dfs(int cur, int[] nums) {
        if (cur == nums.length) {
            ans.add(new ArrayList<Integer>(t));
            return;
        }
        t.add(nums[cur]);
        dfs(cur + 1, nums);
        t.remove(t.size() - 1);
        dfs(cur + 1, nums);
    }
}
```

```Go
func subsets(nums []int) (ans [][]int) {
    set := []int{}
    var dfs func(int)
    dfs = func(cur int) {
        if cur == len(nums) {
            ans = append(ans, append([]int(nil), set...))
            return
        }
        set = append(set, nums[cur])
        dfs(cur + 1)
        set = set[:len(set)-1]
        dfs(cur + 1)
    }
    dfs(0)
    return
}
```

```JavaScript
var subsets = function(nums) {
    const t = [];
    const ans = [];
    const n = nums.length;
    const dfs = (cur) => {
        if (cur === nums.length) {
            ans.push(t.slice());
            return;
        }
        t.push(nums[cur]);
        dfs(cur + 1, nums);
        t.pop(t.length - 1);
        dfs(cur + 1, nums);
    }
    dfs(0, nums);
    return ans;
};
```

```C
int** ans;
int* ansColSize;
int ansSize;

int* t;
int tSize;

void dfs(int cur, int* nums, int numsSize) {
    if (cur == numsSize) {
        int* tmp = malloc(sizeof(int) * tSize);
        memcpy(tmp, t, sizeof(int) * tSize);
        ansColSize[ansSize] = tSize;
        ans[ansSize++] = tmp;
        return;
    }
    t[tSize++] = nums[cur];
    dfs(cur + 1, nums, numsSize);
    tSize--;
    dfs(cur + 1, nums, numsSize);
}

int** subsets(int* nums, int numsSize, int* returnSize, int** returnColumnSizes) {
    ans = malloc(sizeof(int*) * (1 << numsSize));
    ansColSize = malloc(sizeof(int) * (1 << numsSize));
    t = malloc(sizeof(int) * numsSize);
    *returnSize = 1 << numsSize;
    ansSize = tSize = 0;
    dfs(0, nums, numsSize);
    *returnColumnSizes = ansColSize;
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n\times 2^n)$。一共 $2^n$ 个状态，每种状态需要 $O(n)$ 的时间来构造子集。
- 空间复杂度：$O(n)$。临时数组 $t$ 的空间代价是 $O(n)$，递归时栈空间的代价为 $O(n)$。
