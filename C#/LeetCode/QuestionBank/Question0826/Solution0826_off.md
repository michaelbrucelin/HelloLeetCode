### [安排工作以达到最大收益](https://leetcode.cn/problems/most-profit-assigning-work/solutions/2776977/an-pai-gong-zuo-yi-da-dao-zui-da-shou-yi-c0s1/)

#### 方法一：排序 + 双指针

##### 思路与算法

我们首先对工人按照能力大小排序，对工作按照难度排序。

我们使用「双指针」的方法，一个指针指向工人数组，一个指向任务数组，从低难度的任务开始遍历。对于每个工人，我们继续遍历任务，直到难度大于其能力，并把可以完成任务中的最大利润更新到结果中。

最后返回所有工人能得到的利润总和。

##### 代码

```c++
class Solution {
public:
    int maxProfitAssignment(vector<int>& difficulty, vector<int>& profit, vector<int>& worker) {
        vector<pair<int, int>> jobs;
        int n = profit.size(), res = 0, i = 0, best = 0;
        for (int j = 0; j < n; ++j) {
            jobs.emplace_back(difficulty[j], profit[j]);
        }
        sort(jobs.begin(), jobs.end());
        sort(worker.begin(), worker.end());
        for (int w : worker) {
            while (i < n && w >= jobs[i].first) {
                best = max(best, jobs[i].second);
                i++;
            }
            res += best;
        }
        return res;
    }
};
```

```java
class Solution {
    public int maxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        List<Pair<Integer, Integer>> jobs = new ArrayList<>();
        int N = profit.length, res = 0, i = 0, best = 0;
        for (int j = 0; j < N; ++j) {
            jobs.add(new Pair<Integer, Integer>(difficulty[j], profit[j]));
        }
        Collections.sort(jobs, Comparator.comparing(Pair::getKey));
        Arrays.sort(worker);
        for (int w : worker) {
            while (i < N && w >= jobs.get(i).getKey()) {
                best = Math.max(best, jobs.get(i).getValue());
                i++;
            }
            res += best;
        }
        return res;
    }
}
```

```python
class Solution:
    def maxProfitAssignment(self, difficulty: List[int], profit: List[int], worker: List[int]) -> int:
        jobs = sorted(zip(difficulty, profit))
        res = i = best = 0
        worker.sort()
        for w in worker:
            while i < len(jobs) and w >= jobs[i][0]:
                best = max(best, jobs[i][1])
                i += 1
            res += best
        return res
```

```javascript
var maxProfitAssignment = function(difficulty, profit, worker) {
    const jobs = difficulty.map((d, i) => [d, profit[i]]).sort((a, b) => a[0] - b[0]);
    let res = 0, i = 0, best = 0;
    for (const w of worker.sort((a, b) => a - b)) {
        while (i < jobs.length && w >= jobs[i][0]) {
            best = Math.max(best, jobs[i][1]);
            i++;
        }
        res += best;
    }
    return res;
};
```

```typescript
function maxProfitAssignment(difficulty: number[], profit: number[], worker: number[]): number {
    const jobs = difficulty.map((d, i) => [d, profit[i]]).sort((a, b) => a[0] - b[0]);
    let res = 0, i = 0, best = 0;
    for (const w of worker.sort((a, b) => a - b)) {
        while (i < jobs.length && w >= jobs[i][0]) {
            best = Math.max(best, jobs[i][1]);
            i++;
        }
        res += best;
    }
    return res;
};
```

```go
func maxProfitAssignment(difficulty []int, profit []int, worker []int) int {
    jobs := make([][2]int, len(difficulty))
    for i := range difficulty {
        jobs[i] = [2]int{difficulty[i], profit[i]}
    }
    sort.Slice(jobs, func(i, j int) bool { return jobs[i][0] < jobs[j][0] })
    sort.Ints(worker)

    res, i, best := 0, 0, 0
    for _, w := range worker {
        for i < len(jobs) && w >= jobs[i][0] {
            best = max(best, jobs[i][1])
            i++
        }
        res += best
    }
    return res
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```

```rust
impl Solution {
    pub fn max_profit_assignment(difficulty: Vec<i32>, profit: Vec<i32>, worker: Vec<i32>) -> i32 {
        let mut jobs: Vec<(i32, i32)> = difficulty.into_iter().zip(profit).collect();
        jobs.sort_by_key(|&x| x.0);

        let mut worker = worker;
        worker.sort();

        let mut res = 0;
        let mut i = 0;
        let mut best = 0;
        for w in worker {
            while i < jobs.len() && w >= jobs[i].0 {
                best = std::cmp::max(best, jobs[i].1);
                i += 1;
            }
            res += best;
        }
        res
    }
}、
```

```csharp
public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        var jobs = difficulty.Zip(profit, (d, p) => (d, p)).OrderBy(x => x.d).ToArray();
        Array.Sort(worker);
        int res = 0, i = 0, best = 0;
        foreach (int w in worker) {
            while (i < jobs.Length && w >= jobs[i].d) {
                best = Math.Max(best, jobs[i].p);
                i++;
            }
            res += best;
        }
        return res;
    }
}
```

```c
typedef struct {
    int difficulty;
    int profit;
} Job;

int compareJobs(const void *a, const void *b) {
    return ((Job*)a)->difficulty - ((Job*)b)->difficulty;
}

int compare (const void * a, const void * b){
   return ( *(int*)a - *(int*)b );
}

int maxProfitAssignment(int* difficulty, int difficultySize, int* profit, int profitSize, int* worker, int workerSize) {
    // Create an array of jobs
    Job jobs[difficultySize];
    for (int i = 0; i < difficultySize; i++) {
        jobs[i].difficulty = difficulty[i];
        jobs[i].profit = profit[i];
    }

    qsort(jobs, difficultySize, sizeof(Job), compareJobs);
    qsort(worker, workerSize, sizeof(int), compare);

    int res = 0, i = 0, best = 0;
    for (int j = 0; j < workerSize; j++) {
        while (i < difficultySize && worker[j] >= jobs[i].difficulty) {
            best = (best > jobs[i].profit) ? best : jobs[i].profit;
            i++;
        }
        res += best;
    }
    return res;
}
```

##### 复杂度分析

- 时间复杂度：$O(n\log n + m\log m)$。
- 空间复杂度：$O(n + \log m)$。
