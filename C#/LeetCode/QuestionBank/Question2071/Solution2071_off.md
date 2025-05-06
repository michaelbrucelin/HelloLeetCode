### [你可以安排的最多任务数目](https://leetcode.cn/problems/maximum-number-of-tasks-you-can-assign/solutions/1101831/ni-ke-yi-an-pai-de-zui-duo-ren-wu-shu-mu-p7dm/)

#### 方法一：二分查找 + 贪心选择工人

**提示 1**

如果我们已经知道「一定」可以完成 $k$ 个任务，那么：

- 我们可以在 $tasks$ 中选择 $k$ 个值**最小**的任务；
- 我们可以在 $workers$ 中选择 $k$ 个值**最大**的工人。

**提示 2**

如果我们可以完成 $k$ 个任务，并且满足提示 1，那么一定可以完成 $k-1$ 个任务，并且可以选择 $k-1$ 个值最小的任务以及 $k-1$ 个值最大的工人，同样满足提示 1。

**思路与算法**

根据提示 2，我们就可以使用二分查找的方法找到 $k$ 的上界 $k′$，使得我们可以完成 $k′$ 个任务，但不能完成 $ k′+1 $ 个任务。我们找到的 $k′$ 即为答案。

在二分查找的每一步中，当我们得到 $k$ 个值最小的任务以及 $k$ 个值最大的工人后，我们应该如何判断这些任务是否都可以完成呢？

我们可以考虑值**最大**的那个任务，此时会出现两种情况：

- 如果有工人的值大于等于该任务的值，那么我们一定不需要使用药丸，并且一定让值**最大**的工人完成该任务。
    > 证明的思路为：由于我们考虑的是值最大的那个任务，因此所有能完成该任务的工人都能完成剩余的所有任务。因此如果一个值并非最大的工人（无论是否使用药丸）完成该任务，而值最大的工人完成了另一个任务，那么我们将这两个工人完成的任务交换，仍然是可行的。
- 如果所有工人的值都小于该任务的值，那么我们必须使用药丸让一名工人完成任务，并且一定让值**最小**的工人完成该任务。
    > 这里的值**最小**指的是在使用药丸能完成任务的前提下，值最小的工人。
    > 证明的思路为：由于我们考虑的是值最大的那个任务，因此所有通过使用药丸能完成该任务的工人都能完成剩余的所有任务。如果一个值并非最小的工人使用药丸完成该任务，而值最小的工人（无论是否使用药丸）完成了另一个任务，那么我们将这两个工人完成的任务交换，仍然是可行的。

因此，我们可以从大到小枚举每一个任务，并使用有序集合维护所有的工人。当枚举到任务的值为 $t$ 时：

- 如果有序集合中最大的元素大于等于 $t$，那么我们将最大的元素从有序集合中删除。
- 如果有序集合中最大的元素小于 $t$，那么我们在有序集合中找出最小的大于等于 $t-strength$ 的元素并删除。
    对于这种情况，如果我们没有药丸剩余，或者有序集合中不存在大于等于 $t-strength$ 的元素，那么我们就无法完成所有任务。

这样一来，我们就解决了二分查找后判断可行性的问题。

**代码**

```C++
class Solution {
public:
    int maxTaskAssign(vector<int>& tasks, vector<int>& workers, int pills, int strength) {
        int n = tasks.size(), m = workers.size();
        sort(tasks.begin(), tasks.end());
        sort(workers.begin(), workers.end());
        
        auto check = [&](int mid) -> bool {
            int p = pills;
            // 工人的有序集合
            multiset<int> ws;
            for (int i = m - mid; i < m; ++i) {
                ws.insert(workers[i]);
            }
            // 从大到小枚举每一个任务
            for (int i = mid - 1; i >= 0; --i) {
                // 如果有序集合中最大的元素大于等于 tasks[i]
                if (auto it = prev(ws.end()); *it >= tasks[i]) {
                    ws.erase(it);
                }
                else {
                    if (!p) {
                        return false;
                    }
                    auto rep = ws.lower_bound(tasks[i] - strength);
                    if (rep == ws.end()) {
                        return false;
                    }
                    --p;
                    ws.erase(rep);
                }
            }
            return true;
        };
        
        int left = 1, right = min(m, n), ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (check(mid)) {
                ans = mid;
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }
        return ans;
    }
};
```

```Python
from sortedcontainers import SortedList

class Solution:
    def maxTaskAssign(self, tasks: List[int], workers: List[int], pills: int, strength: int) -> int:
        n, m = len(tasks), len(workers)
        tasks.sort()
        workers.sort()

        def check(mid: int) -> bool:
            p = pills
            #  工人的有序集合
            ws = SortedList(workers[m - mid:])
            # 从大到小枚举每一个任务
            for i in range(mid - 1, -1, -1):
                # 如果有序集合中最大的元素大于等于 tasks[i]
                if ws[-1] >= tasks[i]:
                    ws.pop()
                else:
                    if p == 0:
                        return False
                    rep = ws.bisect_left(tasks[i] - strength)
                    if rep == len(ws):
                        return False
                    p -= 1
                    ws.pop(rep)
            return True

        left, right, ans = 1, min(m, n), 0
        while left <= right:
            mid = (left + right) // 2
            if check(mid):
                ans = mid
                left = mid + 1
            else:
                right = mid - 1
        
        return ans
```

```Java
class Solution {
    public int maxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
        Arrays.sort(tasks);
        Arrays.sort(workers);
        int n = tasks.length, m = workers.length;
        int left = 1, right = Math.min(m, n), ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (check(tasks, workers, pills, strength, mid)) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }

    private boolean check(int[] tasks, int[] workers, int pills, int strength, int mid) {
        int p = pills;
        TreeMap<Integer, Integer> ws = new TreeMap<>();
        for (int i = workers.length - mid; i < workers.length; ++i) {
            ws.put(workers[i], ws.getOrDefault(workers[i], 0) + 1);
        }
        for (int i = mid - 1; i >= 0; --i) {
            Integer key = ws.lastKey();
            if (key >= tasks[i]) {
                ws.put(key, ws.get(key) - 1);
                if (ws.get(key) == 0) {
                    ws.remove(key);
                }
            } else {
                if (p == 0) {
                    return false;
                }
                key = ws.ceilingKey(tasks[i] - strength);
                if (key == null) {
                    return false;
                }
                ws.put(key, ws.get(key) - 1);
                if (ws.get(key) == 0) {
                    ws.remove(key);
                }
                --p;
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
        Array.Sort(tasks);
        Array.Sort(workers);
        int n = tasks.Length, m = workers.Length;
        int left = 1, right = Math.Min(m, n), ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (Check(tasks, workers, pills, strength, mid)) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }

    private bool Check(int[] tasks, int[] workers, int pills, int strength, int mid) {
        int p = pills;
        var ws = new SortedDictionary<int, int>();
        for (int i = workers.Length - mid; i < workers.Length; ++i) {
            if (ws.ContainsKey(workers[i])) {
                ws[workers[i]]++;
            } else {
                ws[workers[i]] = 1;
            }
        }
        for (int i = mid - 1; i >= 0; --i) {
            var lastKey = ws.Keys.Max();
            if (lastKey >= tasks[i]) {
                ws[lastKey]--;
                if (ws[lastKey] == 0) {
                    ws.Remove(lastKey);
                }
            } else {
                if (p == 0) {
                    return false;
                }
                var key = ws.Keys.Where(k => k >= tasks[i] - strength).DefaultIfEmpty(-1).First();
                if (key == -1) {
                    return false;
                }
                ws[key]--;
                if (ws[key] == 0) {
                    ws.Remove(key);
                }
                --p;
            }
        }
        return true;
    }
}
```

```Rust
use std::collections::BTreeMap;

impl Solution {
    pub fn max_task_assign(tasks: Vec<i32>, workers: Vec<i32>, pills: i32, strength: i32) -> i32 {
        let mut tasks = tasks;
        let mut workers = workers;
        tasks.sort();
        workers.sort();
        let n = tasks.len();
        let m = workers.len();
        let (mut left, mut right, mut ans) = (1, m.min(n), 0);

        while left <= right {
            let mid = (left + right) / 2;
            if Self::check(&tasks, &workers, pills, strength, mid) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        ans as i32
    }

    fn check(tasks: &[i32], workers: &[i32], pills: i32, strength: i32, mid: usize) -> bool {
        let mut p = pills;
        let mut ws = BTreeMap::new();
        for &w in workers.iter().skip(workers.len() - mid) {
            *ws.entry(w).or_insert(0) += 1;
        }
        for &t in tasks.iter().take(mid).rev() {
            if let Some((&max_key, _)) = ws.iter().next_back() {
                if max_key >= t {
                    *ws.get_mut(&max_key).unwrap() -= 1;
                    if ws[&max_key] == 0 {
                        ws.remove(&max_key);
                    }
                } else {
                    if p == 0 {
                        return false;
                    }
                    if let Some((&key, _)) = ws.range(t - strength..).next() {
                        *ws.get_mut(&key).unwrap() -= 1;
                        if ws[&key] == 0 {
                            ws.remove(&key);
                        }
                        p -= 1;
                    } else {
                        return false;
                    }
                }
            }
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n + m \log m + min(m,n) \log^2min(m,n))$。
    - 对数组 $tasks$ 排序需要 $O(n \log n)$ 的时间；
    - 对数组 $workers$ 排序需要 $O(m \log m)$ 的时间；
    - 二分查找的下界为 $1$，上界为 $m$ 和 $n$ 中的较小值，因此二分查找的次数为 $\log min(m,n)$。每一次查找需要枚举 $min(m,n)$ 个任务，并且枚举的过程中需要对工人的有序集合进行删除操作，单次操作时间复杂度为 $\log min(m,n)$。因此二分查找的总时间复杂度为 $O(min(m,n) \log^2min(m,n))$。
- 空间复杂度：$O(\log n + \log m+min(m,n))$。
    - 对数组 $tasks$ 排序需要 $O(\log n)$ 的栈空间；
    - 对数组 $workers$ 排序需要 $O(\log m)$ 的栈空间；
    - 二分查找中使用的有序集合需要 $O(min(m,n))$ 的空间。

**扩展**

可以发现，当我们从大到小枚举每一个任务时，如果我们维护了（在使用药丸的情况下）所有可以完成任务的工人，那么：

- 如果有工人可以不使用药丸完成该任务，那么我们选择（删除）值最大的工人；
- 如果所有工人都需要使用药丸才能完成该任务，那么我们选择（删除）值最小的工人。

而随着任务值的减少，可以完成任务的工人只增不减，因此我们可以使用一个「双端队列」来维护所有可以（在使用药丸的情况下）所有可以完成任务的工人，此时要么队首的工人被选择（删除），要么队尾的工人被选择（删除），那么单次删除操作的时间复杂度由 $O(\log min(m,n))$ 降低为 $O(1)$，总时间复杂度降低为：

$$O(n \log n+m \log m+min(m,n) \log min(m,n))\=O(n \log n+m \log m)$$

```C++
class Solution {
public:
    int maxTaskAssign(vector<int>& tasks, vector<int>& workers, int pills, int strength) {
        int n = tasks.size(), m = workers.size();
        sort(tasks.begin(), tasks.end());
        sort(workers.begin(), workers.end());
        
        auto check = [&](int mid) -> bool {
            int p = pills;
            deque<int> ws;
            int ptr = m - 1;
            // 从大到小枚举每一个任务
            for (int i = mid - 1; i >= 0; --i) {
                while (ptr >= m - mid && workers[ptr] + strength >= tasks[i]) {
                    ws.push_front(workers[ptr]);
                    --ptr;
                }
                if (ws.empty()) {
                    return false;
                }
                // 如果双端队列中最大的元素大于等于 tasks[i]
                else if (ws.back() >= tasks[i]) {
                    ws.pop_back();
                }
                else {
                    if (!p) {
                        return false;
                    }
                    --p;
                    ws.pop_front();
                }
            }
            return true;
        };
        
        int left = 1, right = min(m, n), ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (check(mid)) {
                ans = mid;
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }
        return ans;
    }
};
```

```Python
from sortedcontainers import SortedList

class Solution:
    def maxTaskAssign(self, tasks: List[int], workers: List[int], pills: int, strength: int) -> int:
        n, m = len(tasks), len(workers)
        tasks.sort()
        workers.sort()

        def check(mid: int) -> bool:
            p = pills
            ws = deque()
            ptr = m - 1
            # 从大到小枚举每一个任务
            for i in range(mid - 1, -1, -1):
                while ptr >= m - mid and workers[ptr] + strength >= tasks[i]:
                    ws.appendleft(workers[ptr])
                    ptr -= 1
                if not ws:
                    return False
                # 如果双端队列中最大的元素大于等于 tasks[i]
                elif ws[-1] >= tasks[i]:
                    ws.pop()
                else:
                    if p == 0:
                        return False
                    p -= 1
                    ws.popleft()
            return True

        left, right, ans = 1, min(m, n), 0
        while left <= right:
            mid = (left + right) // 2
            if check(mid):
                ans = mid
                left = mid + 1
            else:
                right = mid - 1
        
        return ans
```

```Java
class Solution {
    public int maxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
        int n = tasks.length, m = workers.length;
        Arrays.sort(tasks);
        Arrays.sort(workers);
        int left = 1, right = Math.min(m, n), ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (check(tasks, workers, pills, strength, mid)) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }

    // 检查是否可以在mid个任务中使用pills和strength
    private boolean check(int[] tasks, int[] workers, int pills, int strength, int mid) {
        int p = pills;
        int m = workers.length;
        Deque<Integer> ws = new ArrayDeque<>();
        int ptr = m - 1;
        // 从大到小枚举每一个任务
        for (int i = mid - 1; i >= 0; --i) {
            while (ptr >= m - mid && workers[ptr] + strength >= tasks[i]) {
                ws.addFirst(workers[ptr]);
                --ptr;
            }
            if (ws.isEmpty()) {
                return false;
            } else if (ws.getLast() >= tasks[i]) { 
                // 如果双端队列中最大的元素大于等于 tasks[i]
                ws.pollLast();
            } else {
                if (p == 0) {
                    return false;
                }
                --p;
                ws.pollFirst();
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
        int n = tasks.Length, m = workers.Length;
        Array.Sort(tasks);
        Array.Sort(workers);
        
        Func<int, bool> check = mid => {
            int p = pills;
            var ws = new LinkedList<int>();
            int ptr = m - 1;
            // 从大到小枚举每一个任务
            for (int i = mid - 1; i >= 0; --i) {
                while (ptr >= m - mid && workers[ptr] + strength >= tasks[i]) {
                    ws.AddFirst(workers[ptr]);
                    --ptr;
                }
                if (ws.Count == 0) {
                    return false;
                } else if (ws.Last.Value >= tasks[i]) {
                    // 如果双端队列中最大的元素大于等于 tasks[i]
                    ws.RemoveLast();
                } else {
                    if (p == 0) {
                        return false;
                    }
                    --p;
                    ws.RemoveFirst();
                }
            }
            return true;
        };
        
        int left = 1, right = Math.Min(m, n), ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (check(mid)) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }
}
```

```Go
func maxTaskAssign(tasks []int, workers []int, pills int, strength int) int {
    n, m := len(tasks), len(workers)
    sort.Ints(tasks)
    sort.Ints(workers)

    check := func(mid int) bool {
        p := pills
        ws := list.New() // 使用双端队列
        ptr := m - 1
        // 从大到小枚举每一个任务
        for i := mid - 1; i >= 0; i-- {
            for ptr >= m-mid && workers[ptr]+strength >= tasks[i] {
                ws.PushFront(workers[ptr]) // 添加到队头
                ptr--
            }
            if ws.Len() == 0 {
                return false
            }
            // 如果双端队列中最大的元素大于等于 tasks[i]
            if ws.Back().Value.(int) >= tasks[i] {
                ws.Remove(ws.Back()) // 移除队尾
            } else {
                if p == 0 {
                    return false
                }
                p--
                ws.Remove(ws.Front()) // 移除队头
            }
        }
        return true
    }

    left, right, ans := 1, min(m, n), 0
    for left <= right {
        mid := (left + right) / 2
        if check(mid) {
            ans = mid
            left = mid + 1
        } else {
            right = mid - 1
        }
    }
    return ans
}
```

```C
bool check(int* tasks, int* workers, int workersSize, int pills, int strength, int mid) {
    int m = workersSize;
    int p = pills;
    int ws[m];
    int ptr = m - 1;
    int head = m - 1, tail = m - 1;
    // 从大到小枚举每一个任务
    for (int i = mid - 1; i >= 0; --i) {
        while (ptr >= workersSize - mid && workers[ptr] + strength >= tasks[i]) {
            ws[head] = workers[ptr];
            --head;
            --ptr;
        }
        if (head == tail) {
            return false;
        } else if (ws[tail] >= tasks[i]) {  // 如果双端队列中最大的元素大于等于 tasks[i]
            tail--;
        } else {
            if (!p) {
                return false;
            }
            --p;
            head++;
        }
    }

    return true;
}

int compare(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int maxTaskAssign(int* tasks, int tasksSize, int* workers, int workersSize, int pills, int strength) {
    int n = tasksSize, m = workersSize;
    qsort(tasks, n, sizeof(int), compare);
    qsort(workers, m, sizeof(int), compare);

    int left = 1, right = (m < n) ? m : n, ans = 0;
    while (left <= right) {
        int mid = (left + right) / 2;
        if (check(tasks, workers, workersSize, pills, strength, mid)) {
            ans = mid;
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }
    return ans;
}
```

```JavaScript
var maxTaskAssign = function(tasks, workers, pills, strength) {
    let n = tasks.length, m = workers.length;
    tasks.sort((a, b) => a - b);
    workers.sort((a, b) => a - b);

    const check = (mid) => {
        let p = pills;
        let ws = new Deque();
        let ptr = m - 1;
        // 从大到小枚举每一个任务
        for (let i = mid - 1; i >= 0; --i) {
            while (ptr >= m - mid && workers[ptr] + strength >= tasks[i]) {
                ws.pushFront(workers[ptr]);
                --ptr;
            }
            if (ws.isEmpty()) {
                return false;
            }
            // 如果双端队列中最大的元素大于等于 tasks[i]
            else if (ws.back() >= tasks[i]) {
                ws.popBack();
            }
            else {
                if (!p) {
                    return false;
                }
                --p;
                ws.popFront();
            }
        }
        return true;
    }

    let left = 1, right = Math.min(m, n), ans = 0;
    while (left <= right) {
        let mid = Math.floor((left + right) / 2);
        if (check(mid)) {
            ans = mid;
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }
    return ans;
};
```

```TypeScript
function maxTaskAssign(tasks: number[], workers: number[], pills: number, strength: number): number {
    let n = tasks.length, m = workers.length;
    tasks.sort((a, b) => a - b);
    workers.sort((a, b) => a - b);
    const check = (mid: number): boolean => {
        let p = pills;
        let ws = new Deque();
        let ptr = m - 1;
        // 从大到小枚举每一个任务
        for (let i = mid - 1; i >= 0; --i) {
            while (ptr >= m - mid && workers[ptr] + strength >= tasks[i]) {
                ws.pushFront(workers[ptr]);
                --ptr;
            }
            if (ws.isEmpty()) {
                return false;
            }
            // 如果双端队列中最大的元素大于等于 tasks[i]
            else if (ws.back() >= tasks[i]) {
                ws.popBack();
            }
            else {
                if (!p) {
                    return false;
                }
                --p;
                ws.popFront();
            }
        }
        return true;
    }

    let left = 1, right = Math.min(m, n), ans = 0;
    while (left <= right) {
        let mid = Math.floor((left + right) / 2);
        if (check(mid)) {
            ans = mid;
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }
    return ans;
}

```

```Rust
use std::collections::VecDeque;
use std::cmp::{max, min};

impl Solution {
    pub fn max_task_assign(tasks: Vec<i32>, workers: Vec<i32>, pills: i32, strength: i32) -> i32 {
        let n = tasks.len();
        let m = workers.len();
        let mut tasks = tasks;
        let mut workers = workers;
        tasks.sort();
        workers.sort();
        
        let check = |mid: usize| -> bool {
            let mut p = pills;
            let mut ws = VecDeque::new();
            let mut ptr = m - 1;
            // 从大到小枚举每一个任务
            for i in (0..mid).rev() {
                while ptr as i32 >= (m - mid) as i32 && workers[ptr] + strength >= tasks[i] {
                    ws.push_front(workers[ptr]);
                    ptr -= 1;
                }
                if ws.is_empty() {
                    return false;
                }
                // 如果双端队列中最大的元素大于等于 tasks[i]
                if *ws.back().unwrap() >= tasks[i] {
                    ws.pop_back();
                } else {
                    if p == 0 {
                        return false;
                    }
                    p -= 1;
                    ws.pop_front();
                }
            }
            true
        };
        
        let mut left = 1;
        let mut right = min(m, n);
        let mut ans = 0;
        while left <= right {
            let mid = (left + right) / 2;
            if check(mid) {
                ans = mid as i32;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        ans
    }
}
```
