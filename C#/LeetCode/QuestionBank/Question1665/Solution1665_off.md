### [完成所有任务的最少初始能量](https://leetcode.cn/problems/minimum-initial-energy-to-finish-tasks/solutions/3963826/wan-cheng-suo-you-ren-wu-de-zui-shao-chu-rvsp/)

#### 方法一：贪心（差值递增）

核心思想为将差值小的任务产生的额度借给差值大的任务，尽可能减少初始能量。

举个例子，假设有两个任务，$tasks[0]=[3,3]$，tasks[1]=[3,x]。那么当我们实际需要消耗 $6$ 点能量来完成这两个任务时（按照任务 1、任务 $0$ 的顺序），任务 $1$ 中的 $x$ 可以取 $3$ 到 $6$。

这说明当一个任务开始所需最少的能量与实际需要消耗的能量相等时，只要当前能量满足它需要消耗的能量时，它就能够不受任何限制地完成，那么它开始所需的最少能量就能当作某种额度借给其他任务，用来拉高其他任务开始所需的最少能量。

那么我们可以按照开始一个任务需要达到的最低能量 $minimum[i]$ 与其实际需要耗费的能量 $actual[i]$ 的差值从小到大进行排序，将差值小的任务放前面，差值大的放后面，这样能够将更多的额度借给差值大的任务，尽可能减少初始能量。

- 每遍历到一个任务，首先用 $ans$ 来累加这个任务将要消耗的能量，这是完成前面所有任务的基础，并且能够尽可能利用前面任务的额度。
- 若完成这些任务所需的能量不能够达到开始当前任务的最低能量的话，将 $ans$ 更新为这个任务开始的最低能量，这样才能保证完成当前的任务。

这样计算出来的 $ans$ 便是完成所有任务所需的最少初始能量。

```C++
class Solution {
public:
    int minimumEffort(vector<vector<int>>& tasks) {
        sort(tasks.begin(), tasks.end(), [&](vector<int> &a, vector<int> &b){
            return a[1] - a[0] < b[1] - b[0];
        });
        int ans = 0;
        for (auto task : tasks) {
            ans = max(ans + task[0], task[1]);
        }
        return ans;
    }
};
```

```Go
func minimumEffort(tasks [][]int) int {
    sort.Slice(tasks, func(i, j int) bool {
        return tasks[i][1]-tasks[i][0] < tasks[j][1]-tasks[j][0]
    })
    ans := 0
    for _, task := range tasks {
        if ans+task[0] > task[1] {
            ans = ans + task[0]
        } else {
            ans = task[1]
        }
    }
    return ans
}
```

```Python
class Solution:
    def minimumEffort(self, tasks: List[List[int]]) -> int:
        tasks.sort(key=lambda x: x[1] - x[0])
        ans = 0
        for task in tasks:
            ans = max(ans + task[0], task[1])
        return ans
```

```Java
class Solution {
    public int minimumEffort(int[][] tasks) {
        Arrays.sort(tasks, (a, b) -> a[1] - a[0] - (b[1] - b[0]));
        int ans = 0;
        for (int[] task : tasks) {
            ans = Math.max(ans + task[0], task[1]);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinimumEffort(int[][] tasks) {
        Array.Sort(tasks, (a, b) => (a[1] - a[0]).CompareTo(b[1] - b[0]));
        int ans = 0;
        foreach (int[] task in tasks) {
            ans = Math.Max(ans + task[0], task[1]);
        }
        return ans;
    }
}
```

```C
int compare(const void* a, const void* b) {
    int* taskA = *(int**)a;
    int* taskB = *(int**)b;
    return (taskA[1] - taskA[0]) - (taskB[1] - taskB[0]);
}

int minimumEffort(int** tasks, int tasksSize, int* tasksColSize) {
    qsort(tasks, tasksSize, sizeof(int*), compare);
    int ans = 0;
    for (int i = 0; i < tasksSize; i++) {
        int task0 = tasks[i][0];
        int task1 = tasks[i][1];
        if (ans + task0 > task1) {
            ans = ans + task0;
        } else {
            ans = task1;
        }
    }
    return ans;
}
```

```JavaScript
function minimumEffort(tasks) {
    tasks.sort((a, b) => (a[1] - a[0]) - (b[1] - b[0]));
    let ans = 0;
    for (const task of tasks) {
        ans = Math.max(ans + task[0], task[1]);
    }
    return ans;
}
```

```TypeScript
function minimumEffort(tasks: number[][]): number {
    tasks.sort((a, b) => (a[1] - a[0]) - (b[1] - b[0]));
    let ans = 0;
    for (const task of tasks) {
        ans = Math.max(ans + task[0], task[1]);
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn minimum_effort(mut tasks: Vec<Vec<i32>>) -> i32 {
        tasks.sort_by(|a, b| (a[1] - a[0]).cmp(&(b[1] - b[0])));
        let mut ans = 0;
        for task in tasks.iter() {
            ans = std::cmp::max(ans + task[0], task[1]);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $tasks$ 的长度。主要时间消耗在排序上，遍历数组的时间复杂度为 $O(n)$。
- 空间复杂度：$O(\log n)$，用于排序时的递归调用栈空间。

#### 方法二：贪心（差值递减）

核心思想为优先完成差值大的任务，减少能量浪费。

在初始能量不变的情况下，最后一个任务开始需要达到的最低能量 $minimum[i]$ 与其实际需要耗费的能量 $actual[i]$ 的差值 $remain$ 越大，那么最终剩余的能量越多，基于这个想法，我们可以先做 $remain$ 大的任务，尽可能将 $remain$ 小的任务留到最后做，这样的话就能够保证在完成所有任务的情况下多余的能量最少。

于是可以先按照每个任务的差值 $remain$ 从大到小进行排序，然后依次完成任务，并计算所需的能量，过程如下：

- 使用 $ans$ 来记录所需的能量，$remain$ 来记录完成上一个任务后还剩余多少能量。
- 每遍历到一个任务后，如果当前剩余的能量大于这个任务所需达到的最低能量，那么直接消耗能量已有能量处理这个任务，不需要增加所需能量。否则的话需要补充能量 $task[1]-remain$ 来完成这个任务。
- 如果能够直接消耗已有能量来处理这个任务，那么完成这个任务后剩余的能量为 $remain-task[0]$；如果需要补充能量的话（补充到这个任务所需达到最低的能量），那么完成任务前的 $remain$ 会被更新为 $task[1]$，完成这个任务后剩余的能量为 $task[1]-task[0]$。

最终得到的 $ans$ 便是最少的初始能量。

```C++
class Solution {
public:
    int minimumEffort(vector<vector<int>>& tasks) {
        sort(tasks.begin(), tasks.end(), [&](vector<int> &a, vector<int> &b){
            return a[1] - a[0] > b[1] - b[0];
        });
        int ans = 0;
        int remain = 0;
        for (auto task : tasks) {
            ans += remain > task[1] ? 0 : task[1] - remain;
            remain = max(task[1] - task[0], remain - task[0]);
        }
        return ans;
    }
};
```

```Go
func minimumEffort(tasks [][]int) int {
    sort.Slice(tasks, func(i, j int) bool {
        return tasks[i][1]-tasks[i][0] > tasks[j][1]-tasks[j][0]
    })
    ans := 0
    remain := 0
    for _, task := range tasks {
        if remain > task[1] {
            // 不需要增加能量
        } else {
            ans += task[1] - remain
        }
        if task[1]-task[0] > remain-task[0] {
            remain = task[1] - task[0]
        } else {
            remain = remain - task[0]
        }
    }
    return ans
}
```

```Python
class Solution:
    def minimumEffort(self, tasks: List[List[int]]) -> int:
        tasks.sort(key=lambda x: x[1] - x[0], reverse=True)
        ans = 0
        remain = 0
        for task in tasks:
            if remain <= task[1]:
                ans += task[1] - remain
            remain = max(task[1] - task[0], remain - task[0])
        return ans
```

```Java
class Solution {
    public int minimumEffort(int[][] tasks) {
        Arrays.sort(tasks, (a, b) -> (b[1] - b[0]) - (a[1] - a[0]));
        int ans = 0;
        int remain = 0;
        for (int[] task : tasks) {
            if (remain <= task[1]) {
                ans += task[1] - remain;
            }
            remain = Math.max(task[1] - task[0], remain - task[0]);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinimumEffort(int[][] tasks) {
        Array.Sort(tasks, (a, b) => (b[1] - b[0]).CompareTo(a[1] - a[0]));
        int ans = 0;
        int remain = 0;
        foreach (int[] task in tasks) {
            if (remain <= task[1]) {
                ans += task[1] - remain;
            }
            remain = Math.Max(task[1] - task[0], remain - task[0]);
        }
        return ans;
    }
}
```

```C
int compareDesc(const void* a, const void* b) {
    int* taskA = *(int**)a;
    int* taskB = *(int**)b;
    return (taskB[1] - taskB[0]) - (taskA[1] - taskA[0]);
}

int maxInt(int a, int b) {
    return a > b ? a : b;
}

int minimumEffort(int** tasks, int tasksSize, int* tasksColSize) {
    qsort(tasks, tasksSize, sizeof(int*), compareDesc);
    int ans = 0;
    int remain = 0;
    for (int i = 0; i < tasksSize; i++) {
        int task0 = tasks[i][0];
        int task1 = tasks[i][1];
        if (remain <= task1) {
            ans += task1 - remain;
        }
        remain = maxInt(task1 - task0, remain - task0);
    }
    return ans;
}
```

```JavaScript
function minimumEffort(tasks) {
    tasks.sort((a, b) => (b[1] - b[0]) - (a[1] - a[0]));
    let ans = 0;
    let remain = 0;
    for (const task of tasks) {
        if (remain <= task[1]) {
            ans += task[1] - remain;
        }
        remain = Math.max(task[1] - task[0], remain - task[0]);
    }
    return ans;
}
```

```TypeScript
function minimumEffort(tasks: number[][]): number {
    tasks.sort((a, b) => (b[1] - b[0]) - (a[1] - a[0]));
    let ans = 0;
    let remain = 0;
    for (const task of tasks) {
        if (remain <= task[1]) {
            ans += task[1] - remain;
        }
        remain = Math.max(task[1] - task[0], remain - task[0]);
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn minimum_effort(mut tasks: Vec<Vec<i32>>) -> i32 {
        tasks.sort_by(|a, b| (b[1] - b[0]).cmp(&(a[1] - a[0])));
        let mut ans = 0;
        let mut remain = 0;
        for task in tasks.iter() {
            if remain <= task[1] {
                ans += task[1] - remain;
            }
            remain = std::cmp::max(task[1] - task[0], remain - task[0]);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $tasks$ 的长度。主要时间消耗在排序上，遍历数组的时间复杂度为 $O(n)$。
- 空间复杂度：$O(\log n)$，用于排序时的递归调用栈空间。
