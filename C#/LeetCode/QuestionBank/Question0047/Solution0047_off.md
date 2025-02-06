### [全排列 II](https://leetcode.cn/problems/permutations-ii/solutions/417937/quan-pai-lie-ii-by-leetcode-solution/)

#### 方法一：搜索回溯

**思路和算法**

此题是「[46\. 全排列](https://leetcode-cn.com/problems/permutations/)」的进阶，序列中包含了重复的数字，要求我们返回不重复的全排列，那么我们依然可以选择使用搜索回溯的方法来做。

我们将这个问题看作有 $n$ 个排列成一行的空格，我们需要从左往右依次填入题目给定的 $n$ 个数，每个数只能使用一次。那么很直接的可以想到一种穷举的算法，即从左往右每一个位置都依此尝试填入一个数，看能不能填完这 $n$ 个空格，在程序中我们可以用「回溯法」来模拟这个过程。

我们定义递归函数 $backtrack(idx,perm)$ 表示当前排列为 $perm$，下一个待填入的位置是第 $idx$ 个位置（下标从 $0$ 开始）。那么整个递归函数分为两个情况：

- 如果 $idx = n$，说明我们已经填完了 $n$ 个位置，找到了一个可行的解，我们将 $perm$ 放入答案数组中，递归结束。
- 如果 $idx < n$，我们要考虑第 $idx$ 个位置填哪个数。根据题目要求我们肯定不能填已经填过的数，因此很容易想到的一个处理手段是我们定义一个标记数组 $vis$ 来标记已经填过的数，那么在填第 $idx$ 个数的时候我们遍历题目给定的 $n$ 个数，如果这个数没有被标记过，我们就尝试填入，并将其标记，继续尝试填下一个位置，即调用函数 $backtrack(idx+1,perm)$。搜索回溯的时候要撤销该个位置填的数以及标记，并继续尝试其他没被标记过的数。

但题目解到这里并没有满足「全排列不重复」 的要求，在上述的递归函数中我们会生成大量重复的排列，因为对于第 $idx$ 的位置，如果存在重复的数字 $i$，我们每次会将重复的数字都重新填上去并继续尝试导致最后答案的重复，因此我们需要处理这个情况。

要解决重复问题，我们只要设定一个规则，保证在填第 $idx$ 个数的时候**重复数字只会被填入一次即可**。而在本题解中，我们选择对原数组排序，保证相同的数字都相邻，然后每次填入的数一定是这个数所在重复数集合中「从左往右第一个未被填过的数字」，即如下的判断条件：

```cpp
if (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]) {
    continue;
}
```

这个判断条件保证了对于重复数的集合，一定是从左往右逐个填入的。

假设我们有 $3$ 个重复数排完序后相邻，那么我们一定保证每次都是拿从左往右第一个未被填过的数字，即整个数组的状态其实是保证了 $[未填入，未填入，未填入]$ 到 $[填入，未填入，未填入]$，再到 $[填入，填入，未填入]$，最后到 $[填入，填入，填入]$ 的过程的，因此可以达到去重的目标。

**代码**

```C++
class Solution {
    vector<int> vis;

public:
    void backtrack(vector<int>& nums, vector<vector<int>>& ans, int idx, vector<int>& perm) {
        if (idx == nums.size()) {
            ans.emplace_back(perm);
            return;
        }
        for (int i = 0; i < (int)nums.size(); ++i) {
            if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1])) {
                continue;
            }
            perm.emplace_back(nums[i]);
            vis[i] = 1;
            backtrack(nums, ans, idx + 1, perm);
            vis[i] = 0;
            perm.pop_back();
        }
    }

    vector<vector<int>> permuteUnique(vector<int>& nums) {
        vector<vector<int>> ans;
        vector<int> perm;
        vis.resize(nums.size());
        sort(nums.begin(), nums.end());
        backtrack(nums, ans, 0, perm);
        return ans;
    }
};
```

```Java
class Solution {
    boolean[] vis;

    public List<List<Integer>> permuteUnique(int[] nums) {
        List<List<Integer>> ans = new ArrayList<List<Integer>>();
        List<Integer> perm = new ArrayList<Integer>();
        vis = new boolean[nums.length];
        Arrays.sort(nums);
        backtrack(nums, ans, 0, perm);
        return ans;
    }

    public void backtrack(int[] nums, List<List<Integer>> ans, int idx, List<Integer> perm) {
        if (idx == nums.length) {
            ans.add(new ArrayList<Integer>(perm));
            return;
        }
        for (int i = 0; i < nums.length; ++i) {
            if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1])) {
                continue;
            }
            perm.add(nums[i]);
            vis[i] = true;
            backtrack(nums, ans, idx + 1, perm);
            vis[i] = false;
            perm.remove(idx);
        }
    }
}
```

```JavaScript
var permuteUnique = function(nums) {
    const ans = [];
    const vis = new Array(nums.length).fill(false);
    const backtrack = (idx, perm) => {
        if (idx === nums.length) {
            ans.push(perm.slice());
            return;
        }
        for (let i = 0; i < nums.length; ++i) {
            if (vis[i] || (i > 0 && nums[i] === nums[i - 1] && !vis[i - 1])) {
                continue;
            }
            perm.push(nums[i]);
            vis[i] = true;
            backtrack(idx + 1, perm);
            vis[i] = false;
            perm.pop();
        }
    }
    nums.sort((x, y) => x - y);
    backtrack(0, []);
    return ans;
};
```

```Go
func permuteUnique(nums []int) (ans [][]int) {
    sort.Ints(nums)
    n := len(nums)
    perm := []int{}
    vis := make([]bool, n)
    var backtrack func(int)
    backtrack = func(idx int) {
        if idx == n {
            ans = append(ans, append([]int(nil), perm...))
            return
        }
        for i, v := range nums {
            if vis[i] || i > 0 && !vis[i-1] && v == nums[i-1] {
                continue
            }
            perm = append(perm, v)
            vis[i] = true
            backtrack(idx + 1)
            vis[i] = false
            perm = perm[:len(perm)-1]
        }
    }
    backtrack(0)
    return
}
```

```C
int* vis;

void backtrack(int* nums, int numSize, int** ans, int* ansSize, int idx, int* perm) {
    if (idx == numSize) {
        int* tmp = malloc(sizeof(int) * numSize);
        memcpy(tmp, perm, sizeof(int) * numSize);
        ans[(*ansSize)++] = tmp;
        return;
    }
    for (int i = 0; i < numSize; ++i) {
        if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1])) {
            continue;
        }
        perm[idx] = nums[i];
        vis[i] = 1;
        backtrack(nums, numSize, ans, ansSize, idx + 1, perm);
        vis[i] = 0;
    }
}

int cmp(void* a, void* b) {
    return *(int*)a - *(int*)b;
}

int** permuteUnique(int* nums, int numsSize, int* returnSize, int** returnColumnSizes) {
    int** ans = malloc(sizeof(int*) * 2001);
    int* perm = malloc(sizeof(int) * 2001);
    vis = malloc(sizeof(int) * numsSize);
    memset(vis, 0, sizeof(int) * numsSize);
    qsort(nums, numsSize, sizeof(int), cmp);
    *returnSize = 0;
    backtrack(nums, numsSize, ans, returnSize, 0, perm);
    *returnColumnSizes = malloc(sizeof(int) * (*returnSize));
    for (int i = 0; i < *returnSize; i++) {
        (*returnColumnSizes)[i] = numsSize;
    }
    return ans;
}
```

```Python
class Solution:
    def __init__(self):
        self.vis = []

    def backtrack(self, nums: List[int], ans: List[List[int]], idx: int, perm: List[int]):
        if idx == len(nums):
            ans.append(perm[:])
            return
        for i in range(len(nums)):
            if self.vis[i] or (i > 0 and nums[i] == nums[i - 1] and not self.vis[i - 1]):
                continue
            perm.append(nums[i])
            self.vis[i] = 1
            self.backtrack(nums, ans, idx + 1, perm)
            self.vis[i] = 0
            perm.pop()

    def permuteUnique(self, nums: List[int]) -> List[List[int]]:
        ans = []
        perm = []
        self.vis = [0] * len(nums)
        nums.sort()
        self.backtrack(nums, ans, 0, perm)
        return ans
```

```TypeScript
function permuteUnique(nums: number[]): number[][] {
    const ans: number[][] = [];
    const perm: number[] = [];
    const vis: boolean[] = new Array(nums.length).fill(false);
    nums.sort((a, b) => a - b);
    function backtrack(idx: number) {
        if (idx === nums.length) {
            ans.push([...perm]);
            return;
        }
        for (let i = 0; i < nums.length; i++) {
            if (vis[i] || (i > 0 && nums[i] === nums[i - 1] && !vis[i - 1])) {
                continue;
            }
            perm.push(nums[i]);
            vis[i] = true;
            backtrack(idx + 1);
            vis[i] = false;
            perm.pop();
        }
    }
    backtrack(0);
    return ans;
}
```

```CSharp
public class Solution {
    private List<bool> vis;

    private void Backtrack(IList<int> nums, IList<IList<int>> ans, int idx, IList<int> perm) {
        if (idx == nums.Count) {
            ans.Add(new List<int>(perm));
            return;
        }
        for (int i = 0; i < nums.Count; ++i) {
            if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1])) {
                continue;
            }
            perm.Add(nums[i]);
            vis[i] = true;
            Backtrack(nums, ans, idx + 1, perm);
            vis[i] = false;
            perm.RemoveAt(perm.Count - 1);
        }
    }

    public IList<IList<int>> PermuteUnique(int[] nums) {
        var ans = new List<IList<int>>();
        var perm = new List<int>();
        vis = new List<bool>(new bool[nums.Length]);
        Array.Sort(nums);
        Backtrack(nums, ans, 0, perm);
        return ans;
    }
}
```

```Rust
impl Solution {
    pub fn permute_unique(nums: Vec<i32>) -> Vec<Vec<i32>> {
        fn backtrack(nums: &Vec<i32>, ans: &mut Vec<Vec<i32>>, perm: &mut Vec<i32>, vis: &mut Vec<bool>, idx: usize) {
            if idx == nums.len() {
                ans.push(perm.clone());
                return;
            }
            for i in 0..nums.len() {
                if vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]) {
                    continue;
                }
                perm.push(nums[i]);
                vis[i] = true;
                backtrack(nums, ans, perm, vis, idx + 1);
                vis[i] = false;
                perm.pop();
            }
        }
        let mut nums = nums.clone();
        nums.sort();
        let mut ans = Vec::new();
        let mut perm = Vec::new();
        let mut vis = vec![false; nums.len()];
        backtrack(&nums, &mut ans, &mut perm, &mut vis, 0);
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times n!)$，其中 $n$ 为序列的长度。
    算法的复杂度首先受 $backtrack$ 的调用次数制约，$backtrack$ 的调用次数为 $\sum_{k = 1}^nP(n,k)$ 次，其中 $P(n,k) = \dfrac{n!}{(n-k)!} = n(n-1) \dots (n-k+1)$，该式被称作 [n 的 k - 排列，或者部分排列](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E6%8E%92%E5%88%97%2F7804523)。
    而 $\sum_{k = 1}^nP(n,k) = n!+\dfrac{n!}{1!}+\dfrac{n!}{2!}+\dfrac{n!}{3!}+ \dots +\dfrac{n!}{(n-1)!}<2n!+\dfrac{n!}{2}+\dfrac{n!}{2^2}+\dots+\dfrac{n!}{2^{n-2}}<3n!$
    这说明 $backtrack$ 的调用次数是 $O(n!)$ 的。
    而对于 $backtrack$ 调用的每个叶结点（最坏情况下没有重复数字共 $n!$ 个），我们需要将当前答案使用 $O(n)$ 的时间复制到答案数组中，相乘得时间复杂度为 $O(n \times n!)$。
    因此时间复杂度为 $O(n \times n!)$。
- 空间复杂度：$O(n)$。我们需要 $O(n)$ 的标记数组，同时在递归的时候栈深度会达到 $O(n)$，因此总空间复杂度为 $O(n+n)=O(2n)=O(n)$。
