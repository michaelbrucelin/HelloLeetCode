### [完成所有任务的最少时间](https://leetcode.cn/problems/minimum-time-to-complete-all-tasks/solutions/2773362/wan-cheng-suo-you-ren-wu-de-zui-shao-shi-nnbt/)

#### 方法一：贪心

首先将 $\textit{tasks}$ 按照 $\textit{end}$ 从小到大进行排序。使用 $\textit{run}$ 数组标记哪些时间点有任务有运行，从小到大遍历数组 $\textit{tasks}$，假设当前遍历的元素为 $\textit{tasks}[i] = [\textit{start}_i, \textit{end}_i, \textit{duration}_i]$，统计 $\textit{run}$ 数组在时间段 $[\textit{start}_i, \textit{end}_i]$ 内有运行的时间点数目 $\textit{total}$：

- 如果 $\textit{total} \ge \textit{duration}_i$，那么第 $i$ 个任务可以放到先前运行的时间里运行。
- 如果 $\textit{total} \lt \textit{duration}_i$，那么我们可以将第 $i$ 个任务的 $\textit{total}$ 个时间放到先前运行的时间里运行，$\textit{duration}_i - \textit{total}$ 个时间从右到左依次放到区间 $[\textit{start}_i, \textit{end}_i]$ 内没有运行的时间点，从而保证后续的任务尽量利用先前任务的运行时间。

最后返回 $\textit{run}$ 里的总运行时间。

##### 代码

```c++
class Solution {
public:
    int findMinimumTime(vector<vector<int>>& tasks) {
        int n = tasks.size();
        sort(tasks.begin(), tasks.end(), [&](const vector<int> &t1, const vector<int> &t2) -> bool {
            return t1[1] < t2[1];
        });
        vector<int> run(tasks[n - 1][1] + 1);
        int res = 0;
        for (int i = 0; i < n; i++) {
            int start = tasks[i][0], end = tasks[i][1], duration = tasks[i][2];
            duration -= accumulate(run.begin() + start, run.begin() + end + 1, 0);
            res += max(duration, 0);
            for (int j = end; j >= 0 && duration > 0; j--) {
                if (run[j] == 0) {
                    duration--;
                    run[j] = 1;
                }
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int findMinimumTime(int[][] tasks) {
        int n = tasks.length;
        Arrays.sort(tasks, (a, b) -> a[1] - b[1]);
        int[] run = new int[tasks[n - 1][1] + 1];
        int res = 0;
        for (int i = 0; i < n; i++) {
            int start = tasks[i][0], end = tasks[i][1], duration = tasks[i][2];
            for (int j = start; j <= end; j++) {
                duration -= run[j];
            }
            res += Math.max(duration, 0);
            for (int j = end; j >= 0 && duration > 0; j--) {
                if (run[j] == 0) {
                    duration--;
                    run[j] = 1;
                }
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int FindMinimumTime(int[][] tasks) {
        int n = tasks.Length;
        Array.Sort(tasks, (a, b) => a[1] - b[1]);
        int[] run = new int[tasks[n - 1][1] + 1];
        int res = 0;
        for (int i = 0; i < n; i++) {
            int start = tasks[i][0], end = tasks[i][1], duration = tasks[i][2];
            for (int j = start; j <= end; j++) {
                duration -= run[j];
            }
            res += Math.Max(duration, 0);
            for (int j = end; j >= 0 && duration > 0; j--) {
                if (run[j] == 0) {
                    duration--;
                    run[j] = 1;
                }
            }
        }
        return res;
    }
}
```

```go
func findMinimumTime(tasks [][]int) int {
    n := len(tasks)
    sort.Slice(tasks, func(i, j int) bool {
        return tasks[i][1] < tasks[j][1]
    })
    run := make([]int, tasks[n - 1][1] + 1)
    res := 0
    for i := 0; i < n; i++ {
        start, end, duration := tasks[i][0], tasks[i][1], tasks[i][2]
        for j := start; j <= end; j++ {
            duration -= run[j]
        }
        res += max(duration, 0)
        for j := end; j >= 0 && duration > 0; j-- {
            if run[j] == 0 {
                duration--
                run[j] = 1
            }
        }
    }
    return res
}
```

```python
class Solution:
    def findMinimumTime(self, tasks: List[List[int]]) -> int:
        tasks.sort(key = lambda task: task[1])
        run, res = [False] * (tasks[-1][1] + 1), 0
        for start, end, duration in tasks:
            duration -= sum(run[start : end+1])
            res += max(duration, 0)
            for j in range(end, -1, -1):
                if duration <= 0:
                    break
                if not run[j]:
                    run[j], duration = True, duration - 1
        return res
```

```c
static int cmp(const void *a, const void *b) {
    return (*(int **)a)[1] - (*(int **)b)[1];
}

int findMinimumTime(int** tasks, int tasksSize, int* tasksColSize) {
    int n = tasksSize;
    qsort(tasks, tasksSize, sizeof(int *), cmp);
    int run[tasks[n - 1][1] + 1];
    int res = 0;
    memset(run, 0, sizeof(run));
    for (int i = 0; i < n; i++) {
        int start = tasks[i][0], end = tasks[i][1], duration = tasks[i][2];
        for (int j = start; j <= end; j++) {
            duration -= run[j];
        }
        res += fmax(duration, 0);
        for (int j = end; j >= 0 && duration > 0; j--) {
            if (run[j] == 0) {
                duration--;
                run[j] = 1;
            }
        }
    }
    return res;
}
```

```javascript
var findMinimumTime = function(tasks) {
    const n = tasks.length;
    tasks.sort((t1, t2) => t1[1] - t2[1]);
    const run = new Array(tasks[n - 1][1] + 1).fill(0);
    let res = 0;
    for (let i = 0; i < n; i++) {
        let start = tasks[i][0], end = tasks[i][1], duration = tasks[i][2];
        duration -= run.slice(start, end + 1).reduce((acc, val) => acc + val, 0);
        res += Math.max(duration, 0);
        for (let j = end; j >= start && duration > 0; j--) {
            if (run[j] === 0) {
                duration--;
                run[j] = 1;
            }
        }
    }
    return res;
};
```

```typescript
function findMinimumTime(tasks: number[][]): number {
    const n = tasks.length;
    tasks.sort((t1, t2) => t1[1] - t2[1]);
    const run = new Array<number>(tasks[n - 1][1] + 1).fill(0);
    let res = 0;
    for (let i = 0; i < n; i++) {
        const start = tasks[i][0], end = tasks[i][1];
        let duration = tasks[i][2];
        duration -= run.slice(start, end + 1).reduce((acc, val) => acc + val, 0);
        res += Math.max(duration, 0);
        for (let j = end; j >= start && duration > 0; j--) {
            if (run[j] === 0) {
                duration--;
                run[j] = 1;
            }
        }
    }
    return res;
};
```

```rust
impl Solution {
    pub fn find_minimum_time(tasks: Vec<Vec<i32>>) -> i32 {
        let n = tasks.len();
        let mut sorted_tasks = tasks;
        sorted_tasks.sort_by(|a, b| a[1].cmp(&b[1]));
        let max_end_time = sorted_tasks[n - 1][1];
        let mut run = vec![0; max_end_time as usize + 1];
        let mut res = 0;
        for task in sorted_tasks.iter() {
            let start = task[0] as usize;
            let end = task[1] as usize;
            let mut duration = task[2] as i32;
            let covered_duration: i32 = run[start ..=end].iter().sum();
            duration -= covered_duration;
            res += duration.max(0);
            for j in (start..=end).rev() {
                if duration <= 0 {
                    break;
                }
                if run[j] == 0 {
                    run[j] = 1;
                    duration -= 1;
                }
            }
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n \times M)$，其中 $n$ 是 $\textit{tasks}$ 的大小，$M$ 是 $\textit{tasks}$ 的时间段右端点 $\textit{end}$ 的最大值。
- 空间复杂度：$O(M + \log n)$。对 $\textit{tasks}$ 数组进行排序需要 $O(\log n)$，$\textit{run}$ 数组需要 $O(M)$。

#### 方法二：贪心 + 扫描线

令 $M$ 是 $\textit{tasks}$ 的时间段右端点 $\textit{end}$ 的最大值，我们可以利用扫描线的思想，依次扫描区间 $[1, M]$，令当前扫描的时间点为 $i$：

1. 遍历 $\textit{tasks}$ 数组，令当前遍历的任务为 $\textit{tasks}[j] = [\textit{start}_j, \textit{end}_j, \textit{duration}_j]$。如果 $\textit{end}_j - i + 1 = \textit{duration}_j$，那么说明当前任务 $j$ 必须要在时间点 $i$ 运行，标记当前时间 $i$；否则基于贪心的思想，当前任务 $j$ 可以延后运行。
2. 如果当前时间点 $i$ 被标记为需要运行任务，那么我们遍历所有任务，将所有可以在当前时间点运行的任务都运行，同时更新对应任务的 $\textit{duration}$。

最后返回所有运行的时间点数目。

##### 代码

```c++
class Solution {
public:
    int findMinimumTime(vector<vector<int>>& tasks) {
        int res = 0;
        for (int i = 1; ; i++) {
            bool finished = true, run = false;
            for (auto &task : tasks) {
                if (task[2] > 0 && task[1] - i + 1 == task[2]) {
                    run = true;
                }
                if (i <= task[1]) {
                    finished = false;
                }
            }
            if (finished) {
                break;
            }

            if (run) {
                for (auto &task : tasks) {
                    if (i >= task[0] && i <= task[1] && task[2] > 0) {
                        task[2]--;
                    }
                }
                res++;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int findMinimumTime(int[][] tasks) {
        int res = 0;
        for (int i = 1; ; i++) {
            boolean finished = true, run = false;
            for (int[] task : tasks) {
                if (task[2] > 0 && task[1] - i + 1 == task[2]) {
                    run = true;
                }
                if (i <= task[1]) {
                    finished = false;
                }
            }
            if (finished) {
                break;
            }

            if (run) {
                for (int[] task : tasks) {
                    if (i >= task[0] && i <= task[1] && task[2] > 0) {
                        task[2]--;
                    }
                }
                res++;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int FindMinimumTime(int[][] tasks) {
        int res = 0;
        for (int i = 1; ; i++) {
            bool finished = true, run = false;
            foreach (int[] task in tasks) {
                if (task[2] > 0 && task[1] - i + 1 == task[2]) {
                    run = true;
                }
                if (i <= task[1]) {
                    finished = false;
                }
            }
            if (finished) {
                break;
            }

            if (run) {
                foreach (int[] task in tasks) {
                    if (i >= task[0] && i <= task[1] && task[2] > 0) {
                        task[2]--;
                    }
                }
                res++;
            }
        }
        return res;
    }
}
```

```go
func findMinimumTime(tasks [][]int) int {
    res := 0
    for i := 1; ; i++ {
        finished, run := true, false
        for _, task := range tasks {
            if task[2] > 0 && task[1] - i + 1 == task[2] {
                run = true
            }
            if i <= task[1] {
                finished = false
            }
        }
        if finished {
            break
        }

        if run {
            for _, task := range tasks {
                if i >= task[0] && i <= task[1] && task[2] > 0 {
                    task[2]--
                }
            }
            res++
        }
    }
    return res
}
```

```python
class Solution:
    def findMinimumTime(self, tasks: List[List[int]]) -> int:
        res, m = 0, max(tasks, key = lambda task: task[1])[1]
        for i in range(1, m + 1):
            run = False
            for _, end, duration in tasks:
                if duration > 0 and end - i + 1 == duration:
                    run = True
            if run:
                for task in tasks:
                    if i >= task[0] and i <= task[1] and task[2] > 0:
                        task[2] -= 1
                res += 1
        return res
```

```c
int findMinimumTime(int** tasks, int tasksSize, int* tasksColSize) {
    int res = 0;
    for (int i = 1; ; i++) {
        bool finished = true, run = false;
        for (int j = 0; j < tasksSize; j++) {
            int *task = tasks[j];
            if (task[2] > 0 && task[1] - i + 1 == task[2]) {
                run = true;
            }
            if (i <= task[1]) {
                finished = false;
            }
        }
        if (finished) {
            break;
        }

        if (run) {
            for (int j = 0; j < tasksSize; j++) {
                int *task = tasks[j]; 
                if (i >= task[0] && i <= task[1] && task[2] > 0) {
                    task[2]--;
                }
            }
            res++;
        }
    }
    return res;
}
```

```javascript
var findMinimumTime = function(tasks) {
    let res = 0;
    for (let i = 1; ; i++) {
        let finished = true, run = false;
        for (const task of tasks) {
            if (task[2] > 0 && task[1] - i + 1 === task[2]) {
                run = true;
            }
            if (i <= task[1]) {
                finished = false;
            }
        }
        if (finished) {
            break;
        }

        if (run) {
            for (const task of tasks) {
                if (i >= task[0] && i <= task[1] && task[2] > 0) {
                    task[2]--;
                }
            }
            res++;
        }
    }
    return res;
};
```

```typescript
function findMinimumTime(tasks: number[][]): number {
    let res: number = 0;
    for (let i: number = 1; ; i++) {
        let finished: boolean = true, run: boolean = false;
        for (const task of tasks) {
            if (task[2] > 0 && task[1] - i + 1 === task[2]) {
                run = true;
            }
            if (i <= task[1]) {
                finished = false;
            }
        }
        if (finished) {
            break;
        }
        if (run) {
            for (const task of tasks) {
                if (i >= task[0] && i <= task[1] && task[2] > 0) {
                    task[2] -= 1;
                }
            }
            res++;
        }
    }
    return res;
};
```

```rust
impl Solution {
    pub fn find_minimum_time(tasks: Vec<Vec<i32>>) -> i32 {
        let mut res = 0;
        let mut i = 1;
        let mut tasks = tasks;
        loop {
            let mut finished = true;
            let mut run = false;
            for task in &tasks {
                if task[2] > 0 && task[1] - i + 1 == task[2] {
                    run = true;
                }
                if i <= task[1] {
                    finished = false;
                }
            }
            if finished {
                break;
            }
            if run {
                for task in &mut tasks {
                    if i >= task[0] && i <= task[1] && task[2] > 0 {
                        task[2] -= 1;
                    }
                }
                res += 1;
            }
            i += 1;
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n \times M)$，其中 $n$ 是 $\textit{tasks}$ 的大小，$M$ 是 $\textit{tasks}$ 的时间段右端点 $\textit{end}$ 的最大值。
- 空间复杂度：$O(1)$。原地修改数组。

#### 方法三：贪心 + 二分查找 + 栈

首先将 $\textit{tasks}$ 按照 $\textit{end}$ 从小到大进行排序。类似于方法一，我们可以用时间区间替代 $\textit{run}$ 数组来维护有运行任务的时间点。使用栈依次保存新增的运行时间区间与总运行时间长度，初始时栈元素为 $\{-1, -1, 0\}$，我们遍历 $\textit{tasks}$ 数组，记当前遍历的元素为 $\textit{tasks}[i] = [\textit{start}_i, \textit{end}_i, \textit{duration}_i]$，通过二分查找找到所有在区间 $[\textit{start}_i, \textit{end}_i]$ 内有运行任务的时间点数目 $\textit{total}$：

- 如果 $\textit{total} \ge \textit{duration}_i$，那么当前任务可以放到先前运行的时间内运行。
- 如果 $\textit{total} \lt \textit{duration}_i$，那么剩余 $\textit{duration}_i - \textit{total}$ 个时间需要新增时间点，我们从右到左依次将新增的时间点与栈的区间进行合并，然后将合并后的新区间压入栈中。

最后返回所有运行的时间。

##### 代码

```c++
class Solution {
public:
    int findMinimumTime(vector<vector<int>>& tasks) {
        sort(tasks.begin(), tasks.end(), [&](const vector<int> &t1, const vector<int> &t2) -> bool {
            return t1[1] < t2[1];
        });
        vector<vector<int>> st;
        st.push_back({-1, -1, 0});
        for (auto &task : tasks) {
            int start = task[0], end = task[1], duration = task[2];
            int k = lower_bound(st.begin(), st.end(), start, [&](const vector<int> &seg, int x) -> bool {
                return seg[0] < x;
            }) - st.begin();
            duration -= st.back()[2] - st[k - 1][2];
            if (start <= st[k - 1][1]) {
                duration -= st[k - 1][1] - start + 1;
            }
            if (duration <= 0) {
                continue;
            }
            while (end - st.back()[1] <= duration) {
                duration += st.back()[1] - st.back()[0] + 1;
                st.pop_back();
            }
            st.push_back({end - duration + 1, end, st.back()[2] + duration});
        }
        return st.back()[2];
    }
};
```

```java
class Solution {
    public int findMinimumTime(int[][] tasks) {
        Arrays.sort(tasks, (a, b) -> a[1] - b[1]);
        List<int[]> stack = new ArrayList<int[]>();
        stack.add(new int[]{-1, -1, 0});
        for (int[] task : tasks) {
            int start = task[0], end = task[1], duration = task[2];
            int k = binarySearch(stack, start);
            duration -= stack.get(stack.size() - 1)[2] - stack.get(k - 1)[2];
            if (start <= stack.get(k - 1)[1]) {
                duration -= stack.get(k - 1)[1] - start + 1;
            }
            if (duration <= 0) {
                continue;
            }
            while (end - stack.get(stack.size() - 1)[1] <= duration) {
                duration += stack.get(stack.size() - 1)[1] - stack.get(stack.size() - 1)[0] + 1;
                stack.remove(stack.size() - 1);
            }
            stack.add(new int[]{end - duration + 1, end, stack.get(stack.size() - 1)[2] + duration});
        }
        return stack.get(stack.size() - 1)[2];
    }

    public int binarySearch(List<int[]> stack, int target) {
        int low = 0, high = stack.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (stack.get(mid)[0] > target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```csharp
public class Solution {
    public int FindMinimumTime(int[][] tasks) {
        Array.Sort(tasks, (a, b) => a[1] - b[1]);
        IList<int[]> stack = new List<int[]>();
        stack.Add(new int[]{-1, -1, 0});
        foreach (int[] task in tasks) {
            int start = task[0], end = task[1], duration = task[2];
            int k = BinarySearch(stack, start);
            duration -= stack[stack.Count - 1][2] - stack[k - 1][2];
            if (start <= stack[k - 1][1]) {
                duration -= stack[k - 1][1] - start + 1;
            }
            if (duration <= 0) {
                continue;
            }
            while (end - stack[stack.Count - 1][1] <= duration) {
                duration += stack[stack.Count - 1][1] - stack[stack.Count - 1][0] + 1;
                stack.RemoveAt(stack.Count - 1);
            }
            stack.Add(new int[]{end - duration + 1, end, stack[stack.Count - 1][2] + duration});
        }
        return stack[stack.Count - 1][2];
    }

    public int BinarySearch(IList<int[]> stack, int target) {
        int low = 0, high = stack.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (stack[mid][0] > target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```go
func findMinimumTime(tasks [][]int) int {
    sort.Slice(tasks, func(i, j int) bool {
        return tasks[i][1] < tasks[j][1]
    })
    var st [][]int
    st = append(st, []int{-1, -1, 0})
    for _, task := range tasks {
        start, end, duration := task[0], task[1], task[2]
        k := sort.Search(len(st), func(i int) bool {
            return st[i][0] >= start
        })
        duration -= st[len(st) - 1][2] - st[k - 1][2]
        if start <= st[k - 1][1] {
            duration -= st[k - 1][1] - start + 1
        }
        if duration <= 0 {
            continue
        }
        for end - st[len(st) - 1][1] <= duration {
            duration += st[len(st) - 1][1] - st[len(st) - 1][0] + 1
            st = st[:len(st) - 1]
        }
        st = append(st, []int{end - duration + 1, end, st[len(st) - 1][2] + duration})
    }
    return st[len(st) - 1][2]
}
```

```python
class Solution:
    def findMinimumTime(self, tasks: List[List[int]]) -> int:
        tasks.sort(key = lambda task: task[1])
        st = [[-1, -1, 0]]
        for start, end, duration in tasks:
            k = bisect_left(st, start, key = lambda s: s[0])
            duration -= st[-1][2] - st[k - 1][2]
            if start <= st[k - 1][1]:
                duration -= st[k - 1][1] - start + 1
            if duration <= 0:
                continue
            while end - st[-1][1] <= duration:
                duration += st[-1][1] - st[-1][0] + 1
                st.pop()
            st.append([end - duration + 1, end, st[-1][2] + duration])
        return st[-1][2]
```

```c
static int cmp(const void *a, const void *b) {
    return (*(int **)a)[1] - (*(int **)b)[1];
}

int binarySearch(int **stack, int stackSize, int target) {
    int low = 0, high = stackSize;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (stack[mid][0] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

int findMinimumTime(int** tasks, int tasksSize, int* tasksColSize) {
    qsort(tasks, tasksSize, sizeof(int *), cmp);
    int **stack = (int **)malloc(sizeof(int *) * (tasksSize + 1));
    for (int i = 0; i <= tasksSize; i++) {
        stack[i] = (int *)malloc(sizeof(int) * 3);
    }
    int top = 0;
    stack[top][0] = -1;
    stack[top][1] = -1;
    stack[top][2] = 0;
    top++;
    for (int i = 0; i < tasksSize; i++) {
        int *task = tasks[i];
        int start = task[0], end = task[1], duration = task[2];
        int k = binarySearch(stack, top, start);
        duration -= stack[top - 1][2] - stack[k - 1][2];
        if (start <= stack[k - 1][1]) {
            duration -= stack[k - 1][1] - start + 1;
        }
        if (duration <= 0) {
            continue;
        }
        while (end - stack[top - 1][1] <= duration) {
            duration += stack[top - 1][1] - stack[top - 1][0] + 1;
            top--;
        }
        stack[top][0] = end - duration + 1;
        stack[top][1] = end;
        stack[top][2] = stack[top - 1][2] + duration;
        top++;
    }
    int ret = stack[top - 1][2];
    for (int i = 0; i <= tasksSize; i++) {
        free(stack[i]);
    }
    free(stack);
    return ret;
}
```

```javascript
var findMinimumTime = function(tasks) {
    tasks.sort((t1, t2) => t1[1] - t2[1]);
    const stack = [[-1, -1, 0]];
    for (let [start, end, duration] of tasks) {
        const k =  binarySearch(stack, start);
        duration -= stack[stack.length - 1][2] - stack[k - 1][2];
        if (start <= stack[k - 1][1]) {
            duration -= stack[k - 1][1] - start + 1;
        }
        if (duration <= 0) {
            continue;
        }
        while (end - stack[stack.length - 1][1] <= duration) {
            duration += stack[stack.length - 1][1] - stack[stack.length - 1][0] + 1;
            stack.pop();
        }
        stack.push([end - duration + 1, end, stack[stack.length - 1][2] + duration]);
        console.log(stack);
    }
    return stack[stack.length - 1][2];
};

const binarySearch = (stack, target) => {
    let low = 0, high = stack.length;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (stack[mid][0] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}
```

```typescript
function findMinimumTime(tasks: number[][]): number {
    tasks.sort((t1, t2) => t1[1] - t2[1]);
    const stack: number[][] = [[-1, -1, 0]];
    for (let [start, end, duration] of tasks) {
        const k = binarySearch(stack, start);
        duration -= stack[stack.length - 1][2] - stack[k - 1][2];
        if (start <= stack[k - 1][1]) {
            duration -= stack[k - 1][1] - start + 1;
        }
        if (duration <= 0) {
            continue;
        }
        while (end - stack[stack.length - 1][1] <= duration) {
            duration += stack[stack.length - 1][1] - stack[stack.length - 1][0] + 1;
            stack.pop();
        }
        stack.push([end - duration + 1, end, stack[stack.length - 1][2] + duration]);
    }
    return stack[stack.length - 1][2];
};

const binarySearch = (stack: number[][], target: number): number => {
    let low = 0;
    let high = stack.length;
    while (low < high) {
        const mid = Math.floor((low + high) / 2);
        if (stack[mid][0] > target) {
        high = mid;
        } else {
        low = mid + 1;
        }
    }
    return low;
};
```

```rust
impl Solution {
    pub fn find_minimum_time(tasks: Vec<Vec<i32>>) -> i32 {
        let mut tasks = tasks;
        tasks.sort_by(|a, b| a[1].cmp(&b[1]));
        let mut stack = vec![[-1, -1, 0]];
        for task in tasks.iter() {
            let start = task[0];
            let end = task[1];
            let mut duration = task[2];
            let k = Self::binary_search(&stack, start);
            duration -= stack.last().unwrap()[2] - stack[k - 1][2];
            if start <= stack[k - 1][1] {
                duration -= stack[k - 1][1] - start + 1;
            }
            if duration <= 0 {
                continue;
            }
            while end - stack.last().unwrap()[1] <= duration {
                duration += stack.last().unwrap()[1] - stack.last().unwrap()[0] + 1;
                stack.pop();
            }
            stack.push([end - duration + 1, end, stack.last().unwrap()[2] + duration]);
        }
        stack.last().unwrap()[2]
    }

    fn binary_search(stack: &Vec<[i32; 3]>, target: i32) -> usize {
        let mut low = 0;
        let mut high = stack.len();
        while low < high {
            let mid = low + (high - low) / 2;
            if stack[mid][0] > target {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        low
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n \log n)$，其中 $n$ 是 $\textit{tasks}$ 的大小。
- 空间复杂度：$O(n)$。
