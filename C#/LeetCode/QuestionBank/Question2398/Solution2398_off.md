### [预算内的最多机器人数目](https://leetcode.cn/problems/maximum-number-of-robots-within-budget/solutions/2909103/yu-suan-nei-de-zui-duo-ji-qi-ren-shu-mu-hd2yq/)

#### 方法一：双指针 + 单调队列

根据题目的总开销计算公式，显然连续运行的机器人数目越多，总开销越大。假设连续运行的机器人下标区间为 $[j,i]$：

- 当我们固定右下标 $i$ 时，总开销随左下标 $j$ 减小而单调递增。
- 当右下标 $i$ 增大时，使总开销不超过 $budget$ 的区间最小左下标 $j$ 也会增大。

因此我们可以使用双指针来求解本题，同时使用单调队列 $q$ 来维护区间内 $chargeTimes$ 的最大值。

从小到大枚举右下标 $i$，令 $runningCostSum$ 为区间 $[j,i]$ 的 $runningCosts$ 之和，执行以下操作：

- 当 $q$ 非空，且 $q$ 的队尾元素对应的 $chargeTimes$ 值小于等于 $chargeTimes[i]$ 时，我们不断地将 $q$ 的队尾元素出队，从而维护 $q$ 的队首元素对应的 $chargeTimes$ 值始终为区间 $[j,i]$ 的最大值。
- 计算区间 $[j,i]$ 的总开销，如果总开销大于 $budget$，那么我们需要将 $j$ 右移，即 $j=j+1$，同时如果 $q$ 的队首元素为 $j$，那么我们需要将 $j$ 从 $q$ 中移出。
- 最后 $i-j+1$ 就是以 $i$ 为最右机器人，能连续运行的机器人最大数目。

取所有这些最大数目的最大值为结果。

```C++
class Solution {
public:
    int maximumRobots(vector<int>& chargeTimes, vector<int>& runningCosts, long long budget) {
        int res = 0, n = chargeTimes.size();
        long long runningCostSum = 0;
        deque<int> q;
        for (int i = 0, j = 0; i < n; i++) {
            runningCostSum += runningCosts[i];
            while (!q.empty() && chargeTimes[q.back()] <= chargeTimes[i]) {
                q.pop_back();
            }
            q.push_back(i);
            while (j <= i && (i - j + 1) * runningCostSum + chargeTimes[q.front()] > budget) {
                if (!q.empty() && q.front() == j) {
                    q.pop_front();
                }
                runningCostSum -= runningCosts[j];
                j++;
            }
            res = max(res, i - j + 1);
        }
        return res;
    }
};
```

```Go
func maximumRobots(chargeTimes []int, runningCosts []int, budget int64) int {
    res, n := 0, len(chargeTimes)
    runningCostSum := int64(0)
    var q []int
    for i, j := 0, 0; i < n; i++ {
        runningCostSum += int64(runningCosts[i])
        for len(q) > 0 && chargeTimes[q[len(q)-1]] <= chargeTimes[i] {
            q = q[:len(q)-1]
        }
        q = append(q, i)
        for j <= i && int64(i - j + 1) * runningCostSum + int64(chargeTimes[q[0]]) > budget {
            if len(q) > 0 && q[0] == j {
                q = q[1:]
            }
            runningCostSum -= int64(runningCosts[j])
            j++
        }
        res = max(res, i - j + 1)
    }
    return res
}
```

```Python
class Solution:
    def maximumRobots(self, chargeTimes: List[int], runningCosts: List[int], budget: int) -> int:
        res, n, runningCostSum = 0, len(chargeTimes), 0
        q, j = deque(), 0
        for i in range(n):
            runningCostSum += runningCosts[i]
            while q and chargeTimes[q[-1]] <= chargeTimes[i]:
                q.pop()
            q.append(i)
            while j <= i and (i - j + 1) * runningCostSum + chargeTimes[q[0]] > budget:
                if q and q[0] == j:
                    q.popleft()
                runningCostSum -= runningCosts[j]
                j += 1
            res = max(res, i - j + 1)
        return res
```

```Java
class Solution {
    public int maximumRobots(int[] chargeTimes, int[] runningCosts, long budget) {
        int res = 0, n = chargeTimes.length;
        long runningCostSum = 0;
        Deque<Integer> q = new ArrayDeque<>();
        for (int i = 0, j = 0; i < n; i++) {
            runningCostSum += runningCosts[i];
            while (!q.isEmpty() && chargeTimes[q.peekLast()] <= chargeTimes[i]) {
                q.pollLast();
            }
            q.addLast(i);
            while (j <= i && (i - j + 1) * runningCostSum + chargeTimes[q.peekFirst()] > budget) {
                if (!q.isEmpty() && q.peekFirst() == j) {
                    q.pollFirst();
                }
                runningCostSum -= runningCosts[j];
                j++;
            }
            res = Math.max(res, i - j + 1);
        }
        return res;
    }
}
```

```JavaScript
var maximumRobots = function(chargeTimes, runningCosts, budget) {
    let res = 0;
    let n = chargeTimes.length;
    let runningCostSum = 0;
    const q = [];
    for (let i = 0, j = 0; i < n; i++) {
        runningCostSum += runningCosts[i];
        while (q.length && chargeTimes[q[q.length - 1]] <= chargeTimes[i]) {
            q.pop();
        }
        q.push(i);
        while (j <= i && (i - j + 1) * runningCostSum + chargeTimes[q[0]] > budget) {
            if (q.length && q[0] === j) {
                q.shift();
            }
            runningCostSum -= runningCosts[j];
            j++;
        }
        res = Math.max(res, i - j + 1);
    }
    return res;
};
```

```TypeScript
function maximumRobots(chargeTimes: number[], runningCosts: number[], budget: number): number {
    let res = 0;
    let n = chargeTimes.length;
    let runningCostSum = 0;
    const q = [];
    for (let i = 0, j = 0; i < n; i++) {
        runningCostSum += runningCosts[i];
        while (q.length && chargeTimes[q[q.length - 1]] <= chargeTimes[i]) {
            q.pop();
        }
        q.push(i);
        while (j <= i && (i - j + 1) * runningCostSum + chargeTimes[q[0]] > budget) {
            if (q.length && q[0] === j) {
                q.shift();
            }
            runningCostSum -= runningCosts[j];
            j++;
        }
        res = Math.max(res, i - j + 1);
    }
    return res;
};
```

```CSharp
public class Solution {
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget) {
        int res = 0;
        int n = chargeTimes.Length;
        long runningCostSum = 0;
        LinkedList<int> q = new LinkedList<int>();
        for (int i = 0, j = 0; i < n; i++) {
            runningCostSum += runningCosts[i];
            while (q.Count > 0 && chargeTimes[q.Last.Value] <= chargeTimes[i]) {
                q.RemoveLast();
            }
            q.AddLast(i);
            while (j <= i && (i - j + 1) * runningCostSum + chargeTimes[q.First.Value] > budget) {
                if (q.Count > 0 && q.First.Value == j) {
                    q.RemoveFirst();
                }
                runningCostSum -= runningCosts[j];
                j++;
            }
            res = Math.Max(res, i - j + 1);
        }
        return res;
    }
}
```

```C
int maximumRobots(int* chargeTimes, int chargeTimesSize, int* runningCosts, int runningCostsSize, long long budget) {
    int res = 0, n = chargeTimesSize;
    long long runningCostSum = 0;
    int* q = (int*)malloc(sizeof(int) * n), qf = 0, qb = 0;
    for (int i = 0, j = 0; i < n; i++) {
        runningCostSum += runningCosts[i];
        while (qb > qf && chargeTimes[q[qb - 1]] <= chargeTimes[i]) {
            qb--;
        }
        q[qb++] = i;
        while (j <= i && (i - j + 1) * runningCostSum + chargeTimes[q[qf]] > budget) {
            if (qb > qf && q[qf] == j) {
                qf++;
            }
            runningCostSum -= runningCosts[j];
            j++;
        }
        res = fmax(res, i - j + 1);
    }
    free(q);
    return res;
}
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn maximum_robots(charge_times: Vec<i32>, running_costs: Vec<i32>, budget: i64) -> i32 {
        let mut res = 0;
        let mut n = charge_times.len();
        let mut running_cost_sum = 0i64;
        let mut q: VecDeque<usize> = VecDeque::new();
        let mut j = 0;
        for i in 0..n {
            running_cost_sum += running_costs[i] as i64;
            while !q.is_empty() && charge_times[*q.back().unwrap()] <= charge_times[i] {
                q.pop_back();
            }
            q.push_back(i);
            while j <= i && (i - j + 1) as i64 * running_cost_sum + charge_times[*q.front().unwrap()] as i64 > budget {
                if !q.is_empty() && *q.front().unwrap() == j {
                    q.pop_front();
                }
                running_cost_sum -= running_costs[j] as i64;
                j += 1;
            }
            res = res.max(i - j + 1);
        }
        res as i32
    }
}
```

```Cangjie
class Solution {
    func maximumRobots(chargeTimes: Array<Int64>, runningCosts: Array<Int64>, budget: Int64): Int64 {
        var res = 0
        var n = chargeTimes.size
        var runningCostSum = 0
        var j = 0
        var q = ArrayList<Int64>()
        for (i in 0..n) {
            runningCostSum += runningCosts[i]
            while (!q.isEmpty() && chargeTimes[q.get(q.size - 1).getOrThrow()] <= chargeTimes[i]) {
                q.remove(q.size - 1)
            }
            q.append(i)
            while (j <= i && (i - j + 1) * runningCostSum + chargeTimes[q.get(0).getOrThrow()] > budget) {
                if (!q.isEmpty() && q.get(0).getOrThrow() == j) {
                    q.remove(0)
                }
                runningCostSum -= runningCosts[j]
                j++
            }
            res = max(res, i - j + 1)
        }
       
        return res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是机器人数目。双指针需要 $O(n)$ 的时间。
- 空间复杂度：$O(n)$。单调队列需要 $O(n)$ 的空间。
