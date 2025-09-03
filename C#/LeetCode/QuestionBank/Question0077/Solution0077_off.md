### [组合](https://leetcode.cn/problems/combinations/solutions/405094/zu-he-by-leetcode-solution/?envType=problem-list-v2&envId=tBJHVASZ)

#### 方法一：递归实现组合型枚举

**思路与算法**

从 $n$ 个当中选 $k$ 个的所有方案对应的枚举是组合型枚举。在「方法一」中我们用递归来实现组合型枚举。

首先我们先回忆一下如何用递归实现二进制枚举（子集枚举），假设我们需要找到一个长度为 $n$ 的序列 $a$ 的所有子序列，代码框架是这样的：

```C++
vector<int> temp;
void dfs(int cur, int n) {
    if (cur == n + 1) {
        // 记录答案
        // ...
        return;
    }
    // 考虑选择当前位置
    temp.push_back(cur);
    dfs(cur + 1, n, k);
    temp.pop_back();
    // 考虑不选择当前位置
    dfs(cur + 1, n, k);
}
```

上面的代码中，$dfs(cur,n)$ 参数表示当前位置是 $cur$，原序列总长度为 $n$。原序列的每个位置在答案序列种的状态有被选中和不被选中两种，我们用 $temp$ 数组存放已经被选出的数字。在进入 $dfs(cur,n)$ 之前 $[1,cur-1]$ 位置的状态是确定的，而 $[cur,n]$ 内位置的状态是不确定的，$dfs(cur,n)$ 需要确定 $cur$ 位置的状态，然后求解子问题 $dfs(cur+1,n)$。对于 $cur$ 位置，我们需要考虑 $a[cur]$ 取或者不取，如果取，我们需要把 $a[cur]$ 放入一个临时的答案数组中（即上面代码中的 $temp$），再执行 $dfs(cur+1,n)$，执行结束后需要对 $temp$ 进行回溯；如果不取，则直接执行 $dfs(cur+1,n)$。在整个递归调用的过程中，$cur$ 是从小到大递增的，当 $cur$ 增加到 $n+1$ 的时候，记录答案并终止递归。可以看出二进制枚举的时间复杂度是 $O(2^n)$。

组合枚举的代码框架可以借鉴二进制枚举。例如我们需要在 $n$ 个元素选 $k$ 个，在 $dfs$ 的时候需要多传入一个参数 $k$，即 $dfs(cur,n,k)$。在每次进入这个 $dfs$ 函数时，我们都去判断当前 $temp$ 的长度是否为 $k$，如果为 $k$，就把 $temp$ 加入答案并直接返回，即：

```C++
vector<int> temp;
void dfs(int cur, int n) {
    // 记录合法的答案
    if (temp.size() == k) {
        ans.push_back(temp);
        return;
    }
    // cur == n + 1 的时候结束递归
    if (cur == n + 1) {
        return;
    }
    // 考虑选择当前位置
    temp.push_back(cur);
    dfs(cur + 1, n, k);
    temp.pop_back();
    // 考虑不选择当前位置
    dfs(cur + 1, n, k);
}
```

这个时候我们可以做一个剪枝，如果当前 $temp$ 的大小为 $s$，未确定状态的区间 $[cur,n]$ 的长度为 $t$，如果 $s+t<k$，那么即使 $t$ 个都被选中，也不可能构造出一个长度为 $k$ 的序列，故这种情况就没有必要继续向下递归，即我们可以在每次递归开始的时候做一次这样的判断：

```C++
if (temp.size() + (n - cur + 1) < k) {
    return;
}
```

代码就变成了这样：

```C++
vector<int> temp;
void dfs(int cur, int n) {
    // 剪枝：temp 长度加上区间 [cur, n] 的长度小于 k，不可能构造出长度为 k 的 temp
    if (temp.size() + (n - cur + 1) < k) {
        return;
    }
    // 记录合法的答案
    if (temp.size() == k) {
        ans.push_back(temp);
        return;
    }
    // cur == n + 1 的时候结束递归
    if (cur == n + 1) {
        return;
    }
    // 考虑选择当前位置
    temp.push_back(cur);
    dfs(cur + 1, n, k);
    temp.pop_back();
    // 考虑不选择当前位置
    dfs(cur + 1, n, k);
}
```

至此，其实我们已经得到了一个时间复杂度为 $O({k \choose n})$ 的组合枚举，由于每次记录答案的复杂度为 $O(k)$，故这里的时间复杂度为 $O({k \choose n}\times k)$，但是我们还可以进一步优化代码。在上面这份代码中有三个 $if$ 判断，其实第三处的 $if$ 是可以被删除的。因为：

- 首先，$cur=n+1$ 的时候，一定不可能出现 $s>k$（s 是前文中定义的 $temp$ 的大小），因为自始至终 $s$ 绝不可能大于 $k$，它等于 $k$ 的时候就会被第二处 $if$ 记录答案并返回；
- 如果 $cur=n+1$ 的时候 $s=k$，它也会被第二处 $if$ 记录答案并返回；
- 如果 $cur=n+1$ 的时候 $s<k$，一定会在 $cur<n+1$ 的某个位置的时候发现 $s+t<k$，它也会被第一处 $if$ 剪枝。

因此，第三处 $if$ 可以删除。最终我们得到了如下的代码。

**代码**

```C++
class Solution {
public:
    vector<int> temp;
    vector<vector<int>> ans;

    void dfs(int cur, int n, int k) {
        // 剪枝：temp 长度加上区间 [cur, n] 的长度小于 k，不可能构造出长度为 k 的 temp
        if (temp.size() + (n - cur + 1) < k) {
            return;
        }
        // 记录合法的答案
        if (temp.size() == k) {
            ans.push_back(temp);
            return;
        }
        // 考虑选择当前位置
        temp.push_back(cur);
        dfs(cur + 1, n, k);
        temp.pop_back();
        // 考虑不选择当前位置
        dfs(cur + 1, n, k);
    }

    vector<vector<int>> combine(int n, int k) {
        dfs(1, n, k);
        return ans;
    }
};
```

```Java
class Solution {
    List<Integer> temp = new ArrayList<Integer>();
    List<List<Integer>> ans = new ArrayList<List<Integer>>();

    public List<List<Integer>> combine(int n, int k) {
        dfs(1, n, k);
        return ans;
    }

    public void dfs(int cur, int n, int k) {
        // 剪枝：temp 长度加上区间 [cur, n] 的长度小于 k，不可能构造出长度为 k 的 temp
        if (temp.size() + (n - cur + 1) < k) {
            return;
        }
        // 记录合法的答案
        if (temp.size() == k) {
            ans.add(new ArrayList<Integer>(temp));
            return;
        }
        // 考虑选择当前位置
        temp.add(cur);
        dfs(cur + 1, n, k);
        temp.remove(temp.size() - 1);
        // 考虑不选择当前位置
        dfs(cur + 1, n, k);
    }
}
```

```JavaScript
var combine = function(n, k) {
    const ans = [];
    const dfs = (cur, n, k, temp) => {
        // 剪枝：temp 长度加上区间 [cur, n] 的长度小于 k，不可能构造出长度为 k 的 temp
        if (temp.length + (n - cur + 1) < k) {
            return;
        }
        // 记录合法的答案
        if (temp.length == k) {
            ans.push(temp);
            return;
        }
        // 考虑选择当前位置
        dfs(cur + 1, n, k, [...temp, cur]);
        // 考虑不选择当前位置
        dfs(cur + 1, n, k, temp);
    }
    dfs(1, n, k, []);
    return ans;
};
```

```Go
func combine(n int, k int) (ans [][]int) {
    temp := []int{}
    var dfs func(int)
    dfs = func(cur int) {
        // 剪枝：temp 长度加上区间 [cur, n] 的长度小于 k，不可能构造出长度为 k 的 temp
        if len(temp) + (n - cur + 1) < k {
            return
        }
        // 记录合法的答案
        if len(temp) == k {
            comb := make([]int, k)
            copy(comb, temp)
            ans = append(ans, comb)
            return
        }
        // 考虑选择当前位置
        temp = append(temp, cur)
        dfs(cur + 1)
        temp = temp[:len(temp)-1]
        // 考虑不选择当前位置
        dfs(cur + 1)
    }
    dfs(1)
    return
}
```

```C
int* temp;
int tempSize;

int** ans;
int ansSize;

void dfs(int cur, int n, int k) {
    // 剪枝：temp 长度加上区间 [cur, n] 的长度小于 k，不可能构造出长度为 k 的 temp
    if (tempSize + (n - cur + 1) < k) {
        return;
    }
    // 记录合法的答案
    if (tempSize == k) {
        int* tmp = malloc(sizeof(int) * k);
        for (int i = 0; i < k; i++) {
            tmp[i] = temp[i];
        }
        ans[ansSize++] = tmp;
        return;
    }
    // 考虑选择当前位置
    temp[tempSize++] = cur;
    dfs(cur + 1, n, k);
    tempSize--;
    // 考虑不选择当前位置
    dfs(cur + 1, n, k);
}

int** combine(int n, int k, int* returnSize, int** returnColumnSizes) {
    temp = malloc(sizeof(int) * k);
    ans = malloc(sizeof(int*) * 200001);
    tempSize = ansSize = 0;
    dfs(1, n, k);
    *returnSize = ansSize;
    *returnColumnSizes = malloc(sizeof(int) * ansSize);
    for (int i = 0; i < ansSize; i++) {
        (*returnColumnSizes)[i] = k;
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O({k \choose n}\times k)$，分析见「思路」部分。
- 空间复杂度：$O(n+k)=O(n)$，即递归使用栈空间的空间代价和临时数组 $temp$ 的空间代价。

#### 方法二：非递归（字典序法）实现组合型枚举

**思路与算法**

**小贴士：这个方法理解起来比「方法一」复杂，建议读者遇到不理解的地方可以在草稿纸上举例模拟这个过程。**

这里的非递归版不是简单的用栈模拟递归转化为非递归：我们希望通过合适的手段，消除递归栈带来的额外空间代价。

假设我们把原序列中被选中的位置记为 $1$，不被选中的位置记为 $0$，对于每个方案都可以构造出一个二进制数。我们让原序列从大到小排列（即 ${n,n-1,\dots 1,0}$）。我们先看一看 $n=4$，$k=2$ 的例子：

| 原序列中被选中的数 | 对应的二进制数 | 方案 |
| --- | --- | --- |
| 43[2][1] | 0011 | 2,1 |
| 4[3]2[1] | 0101 | 3,1 |
| 4[3][2]1 | 0110 | 3,2 |
| [4]32[1] | 1001 | 4,1 |
| [4]3[2]1 | 1010 | 4,2 |
| [4][3]21 | 1100 | 4,3 |

我们可以看出「对应的二进制数」一列包含了由 $k$ 个 $1$ 和 $n-k$ 个 $0$ 组成的所有二进制数，并且按照字典序排列。这给了我们一些启发，我们可以通过某种方法枚举，使得生成的序列是根据字典序递增的。我们可以考虑我们一个二进制数数字 $x$，它由 $k$ 个 $1$ 和 $n-k$ 个 $0$ 组成，**如何找到它的字典序中的下一个数字 $next(x)$**，这里分两种情况：

- 规则一：$x$ 的最低位为 $1$，这种情况下，如果末尾由 $t$ 个连续的 $1$，我们直接将倒数第 $t$ 位的 $1$ 和倒数第 $t+1$ 位的 $0$ 替换，就可以得到 $next(x)$。如 $0011\rightarrow 0101$，$0101\rightarrow 0110$，$1001\rightarrow 1010$，$1001111\rightarrow 1010111$。
- 规则二：$x$ 的最低位为 $0$，这种情况下，末尾有 $t$ 个连续的 $0$，而这 $t$ 个连续的 $0$ 之前有 $m$ 个连续的 $1$，我们可以将倒数第 $t+m$ 位置的 $1$ 和倒数第 $t+m+1$ 位的 $0$ 对换，然后把倒数第 $t+1$ 位到倒数第 $t+m-1$ 位的 $1$ 移动到最低位。如 $0110\rightarrow 1001$，$1010\rightarrow 1100$，$1011100\rightarrow 1100011$。

至此，我们可以写出一个朴素的程序，用一个长度为 $n$ 的 $0/1$ 数组来表示选择方案对应的二进制数，初始状态下最低的 $k$ 位全部为 $1$，其余位置全部为 $0$，然后不断通过上述方案求 $next$，就可以构造出所有的方案。

我们可以进一步优化实现，我们来看 $n=5$，$k=3$ 的例子，根据上面的策略我们可以得到这张表：

| 二进制数 | 方案 |
| --- | --- |
| 00111 | 3,2,1 |
| 01011 | 4,2,1 |
| 01101 | 4,3,1 |
| 01110 | 4,3,2 |
| 10011 | 5,2,1 |
| 10101 | 5,3,1 |
| 10110 | 5,3,2 |
| 11001 | 5,4,1 |
| 11010 | 5,4,2 |
| 11100 | 5,4,3 |

在朴素的方法中我们通过二进制数来构造方案，而二进制数是需要通过迭代的方法来获取 $next$ 的。考虑不通过二进制数，直接在方案上变换来得到下一个方案。假设一个方案从低到高的 $k$ 个数分别是 ${a0,a1,\dots ,ak-1}$，我们可以从低位向高位找到第一个 $j$ 使得 $aj+1\ne aj+1$，我们知道出现在 $a$ 序列中的数字在二进制数中对应的位置一定是 $1$，即表示被选中，那么 $aj+1\ne aj+1$ 意味着 $aj$ 和 $aj+1$ 对应的二进制位中间有 $0$，即这两个 $1$ 不连续。我们把 $aj$ 对应的 $1$ 向高位推送，也就对应着 aj←aj+1，而对于 $i\in [0,j-1]$ 内所有的 $ai$ 把值恢复成 $i+1$，即对应这 $j$ 个 $1$ 被移动到了二进制数的最低 $j$ 位。这似乎只考虑了上面的「规则二」。但是实际上 **「规则一」是「规则二」在 $t=0$ 时的特殊情况**，因此这么做和按照两条规则模拟是等价的。

在实现的时候，我们可以用一个数组 $temp$ 来存放 $a$ 序列，一开始我们先把 $1$ 到 $k$ 按顺序存入这个数组，他们对应的下标是 $0$ 到 $k-1$。为了计算的方便，我们需要在下标 $k$ 的位置放置一个哨兵 $n+1$**（思考题：为什么是 $n+1$ 呢？）**。然后对这个 $temp$ 序列按照这个规则进行变换，每次把前 $k$ 位（即除了最后一位哨兵）的元素形成的子数组加入答案。每次变换的时候，我们把第一个 $aj+1\ne aj+1$ 的 $j$ 找出，使 $aj$ 自增 $1$，同时对 $i\in [0,j-1]$ 的 $ai$ 重新置数。如此循环，直到 $temp$ 中的所有元素为 $n$ 内最大的 $k$ 个元素。

回过头看这个思考题，它是为了我们判断退出条件服务的。我们如何判断枚举到了终止条件呢？其实不是直接通过 $temp$ 来判断的，我们会看每次找到的 $j$ 的位置，如果 $j=k$ 了，就说明 $[0,k-1]$ 内的所有的数字是比第 $k$ 位小的最后 $k$ 个数字，这个时候我们找不到任何方案的字典序比当前方案大了，结束枚举。

**代码**

```C++
class Solution {
public:
    vector<int> temp;
    vector<vector<int>> ans;

    vector<vector<int>> combine(int n, int k) {
        // 初始化
        // 将 temp 中 [0, k - 1] 每个位置 i 设置为 i + 1，即 [0, k - 1] 存 [1, k]
        // 末尾加一位 n + 1 作为哨兵
        for (int i = 1; i <= k; ++i) {
            temp.push_back(i);
        }
        temp.push_back(n + 1);
        
        int j = 0;
        while (j < k) {
            ans.emplace_back(temp.begin(), temp.begin() + k);
            j = 0;
            // 寻找第一个 temp[j] + 1 != temp[j + 1] 的位置 t
            // 我们需要把 [0, t - 1] 区间内的每个位置重置成 [1, t]
            while (j < k && temp[j] + 1 == temp[j + 1]) {
                temp[j] = j + 1;
                ++j;
            }
            // j 是第一个 temp[j] + 1 != temp[j + 1] 的位置
            ++temp[j];
        }
        return ans;
    }
};
```

```Java
class Solution {
    List<Integer> temp = new ArrayList<Integer>();
    List<List<Integer>> ans = new ArrayList<List<Integer>>();

    public List<List<Integer>> combine(int n, int k) {
        List<Integer> temp = new ArrayList<Integer>();
        List<List<Integer>> ans = new ArrayList<List<Integer>>();
        // 初始化
        // 将 temp 中 [0, k - 1] 每个位置 i 设置为 i + 1，即 [0, k - 1] 存 [1, k]
        // 末尾加一位 n + 1 作为哨兵
        for (int i = 1; i <= k; ++i) {
            temp.add(i);
        }
        temp.add(n + 1);
        
        int j = 0;
        while (j < k) {
            ans.add(new ArrayList<Integer>(temp.subList(0, k)));
            j = 0;
            // 寻找第一个 temp[j] + 1 != temp[j + 1] 的位置 t
            // 我们需要把 [0, t - 1] 区间内的每个位置重置成 [1, t]
            while (j < k && temp.get(j) + 1 == temp.get(j + 1)) {
                temp.set(j, j + 1);
                ++j;
            }
            // j 是第一个 temp[j] + 1 != temp[j + 1] 的位置
            temp.set(j, temp.get(j) + 1);
        }
        return ans;
    }
}
```

```JavaScript
var combine = function(n, k) {
    const temp = [];
    const ans = [];
    // 初始化
    // 将 temp 中 [0, k - 1] 每个位置 i 设置为 i + 1，即 [0, k - 1] 存 [1, k]
    // 末尾加一位 n + 1 作为哨兵
    for (let i = 1; i <= k; ++i) {
        temp.push(i);
    }
    temp.push(n + 1);
    
    let j = 0;
    while (j < k) {
        ans.push(temp.slice(0, k));
        j = 0;
        // 寻找第一个 temp[j] + 1 != temp[j + 1] 的位置 t
        // 我们需要把 [0, t - 1] 区间内的每个位置重置成 [1, t]
        while (j < k && temp[j] + 1 == temp[j + 1]) {
            temp[j] = j + 1;
            ++j;
        }
        // j 是第一个 temp[j] + 1 != temp[j + 1] 的位置
        ++temp[j];
    }
    return ans;
};
```

```Go
func combine(n int, k int) (ans [][]int) {
    // 初始化
    // 将 temp 中 [0, k - 1] 每个位置 i 设置为 i + 1，即 [0, k - 1] 存 [1, k]
    // 末尾加一位 n + 1 作为哨兵
    temp := []int{}
    for i := 1; i <= k; i++ {
        temp = append(temp, i)
    }
    temp = append(temp, n+1)

    for j := 0; j < k; {
        comb := make([]int, k)
        copy(comb, temp[:k])
        ans = append(ans, comb)
        // 寻找第一个 temp[j] + 1 != temp[j + 1] 的位置 t
        // 我们需要把 [0, t - 1] 区间内的每个位置重置成 [1, t]
        for j = 0; j < k && temp[j]+1 == temp[j+1]; j++ {
            temp[j] = j + 1
        }
        // j 是第一个 temp[j] + 1 != temp[j + 1] 的位置
        temp[j]++
    }
    return
}
```

```C
int** combine(int n, int k, int* returnSize, int** returnColumnSizes) {
    int* temp = malloc(sizeof(int) * (k + 1));
    int tempSize = 0;

    int** ans = malloc(sizeof(int*) * 200001);
    int ansSize = 0;

    // 初始化
    // 将 temp 中 [0, k - 1] 每个位置 i 设置为 i + 1，即 [0, k - 1] 存 [1, k]
    // 末尾加一位 n + 1 作为哨兵
    for (int i = 1; i <= k; ++i) {
        temp[i - 1] = i;
    }
    temp[k] = n + 1;

    int j = 0;
    while (j < k) {
        int* tmp = malloc(sizeof(int) * k);
        for (int i = 0; i < k; i++) {
            tmp[i] = temp[i];
        }
        ans[ansSize++] = tmp;
        j = 0;
        // 寻找第一个 temp[j] + 1 != temp[j + 1] 的位置 t
        // 我们需要把 [0, t - 1] 区间内的每个位置重置成 [1, t]
        while (j < k && temp[j] + 1 == temp[j + 1]) {
            temp[j] = j + 1;
            ++j;
        }
        // j 是第一个 temp[j] + 1 != temp[j + 1] 的位置
        ++temp[j];
    }
    *returnSize = ansSize;
    *returnColumnSizes = malloc(sizeof(int) * ansSize);
    for (int i = 0; i < ansSize; i++) {
        (*returnColumnSizes)[i] = k;
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O({k \choose n}\times k)$。外层循环的执行次数是 ${k \choose n}$ 次，每次需要做一个 $O(k)$ 的添加答案和 $O(k)$ 的内层循环，故时间复杂度 $O({k \choose n}\times k)$。
- 空间复杂度：$O(k)$。即 $temp$ 的空间代价。
