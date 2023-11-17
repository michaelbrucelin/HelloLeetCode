### [最大和查询](https://leetcode.cn/problems/maximum-sum-queries/solutions/2524819/zui-da-he-cha-xun-by-leetcode-solution-jlk0/)

#### 方法一：单调栈 + 二分查找

**思路**

首先我们将 $nums_1$ 和 $nums_2$ 按照下标合并成一个数组方便排序，数组的元素是二元数组。然后将数组 $queries$ 进行扩充带上原始下标，是为了排序后能带上原来的下标信息，因为要返回的 $answer$ 数组是要与原始下标对应的。然后将两个数组分别按照 $nums_1$ 和 $queries$ 中的 $x$ 进行降序排序，得到 $sortedNums$ 和 $sortedQueries$。这样，我们就可以通过按照大小顺序访问 $sortedNums$ 和 $sortedQueries$，使得在访问 $queries[i]$ 时，满足 $sortedNums[j][0] \geq x_i$ 的 $sortedNums[j]$ 已经全部被访问过，而未被访问过的 $sortedNums[j]$ 则均不满足上述条件。这样，我们就可以在后续计算时，可以忽略这个条件，而着眼于另一个条件。

接下来，就需要考虑另一个条件，满足 $sortedNums[j][1] \geq y_i$，并且要求出满足这个条件的最大的 $sortedNums[j][0] + sortedNums[j][1]$。此时 $sortedNums[j][1]$ 和 $y_i$ 都是无序的。考虑 $sortedNums[j][1]$ 和之前访问过的 $sortedNums[j'][1]$ 的关系：

-   如果 $sortedNums[j][1] \leq sortedNums[j'][1]$，那么的 $sortedNums[j]$ 与 $sortedNums[j']$ 相比毫无竞争力。因为先访问 $sortedNums[j']$，那么则有 $sortedNums[j'][0] \geq sortedNums[j][0]$，又有 $sortedNums[j'][1] \geq sortedNums[j][1]$，则有 $sortedNums[j'][0] + sortedNums[j'][1] \geq sortedNums[j][0] + sortedNums[j][1]$。$sortedNums[j]$ 在满足条件上既无优先性，在目标值上也无法提供更优值。
-   如果 $sortedNums[j][1] > sortedNums[j'][1]$。这时 $sortedNums[j]$ 会在满足不等式的条件上提供一个优先性。又因为此时它有优先性，我们就可以不考虑满足 $sortedNums[j'][0] + sortedNums[j'][1] \leq sortedNums[j][0] + sortedNums[j][1]$ 的 $j'$。这提醒我们可以将访问过的 $sortedNums[j][0] + sortedNums[j][1]$ 维护成一个单调栈，每次访问到一个 $sortedNums[j]$，都将栈尾的具有更小的目标值的和的元素弹出。

根据上述两种情况，我们可以这样设计我们的单调栈：栈的元素是二元数组 $[sortedNums[j][1], sortedNums[j][0] + sortedNums[j][1]]$，并且按照第一个元素递增（第一种情况里已证明），按照第二个元素递减。

接下来，访问 $sortedQueries$ 时，我们可以利用二分搜索来寻找单调栈中第一个满足 $stack[k][0] \geq y_i$ 的元素，此时目标值的最大值即为 $stack[k][1]$，将其填入 $answer$。

**代码**

```python
class Solution:
    def maximumSumQueries(self, nums1: List[int], nums2: List[int], queries: List[List[int]]) -> List[int]:
        sortedNums = sorted([[a, b] for a, b in zip(nums1, nums2)], key = lambda x: -x[0])
        sortedQueries = sorted([[i, x, y] for i, (x, y) in enumerate(queries)], key=lambda q:-q[1])
        stack = []
        answer = [-1] * len(queries)
        j = 0
        for i, x, y in sortedQueries:
            while j < len(sortedNums) and sortedNums[j][0] >= x:
                num1, num2 = sortedNums[j]
                while stack and stack[-1][1] <= num1 + num2:
                    stack.pop()
                if not stack or stack[-1][0] < num2:
                    stack.append([num2, num1 + num2])
                j += 1
            k = bisect_left(stack, [y, 0])
            if k < len(stack):
                answer[i] = stack[k][1]
        return answer
```

```java
class Solution {
    public int[] maximumSumQueries(int[] nums1, int[] nums2, int[][] queries) {
        int n = nums1.length;
        int[][] sortedNums = new int[n][2];
        for (int i = 0; i < n; i++) {
            sortedNums[i][0] = nums1[i];
            sortedNums[i][1] = nums2[i];
        }
        Arrays.sort(sortedNums, (a, b) -> b[0] - a[0]);
        int q = queries.length;
        int[][] sortedQueries = new int[q][3];
        for (int i = 0; i < q; i++) {
            sortedQueries[i][0] = i;
            sortedQueries[i][1] = queries[i][0];
            sortedQueries[i][2] = queries[i][1];
        }
        Arrays.sort(sortedQueries, (a, b) -> b[1] - a[1]);
        List<int[]> stack = new ArrayList<int[]>();
        int[] answer = new int[q];
        Arrays.fill(answer, -1);
        int j = 0;
        for (int[] query : sortedQueries) {
            int i = query[0], x = query[1], y = query[2];
            while (j < n && sortedNums[j][0] >= x) {
                int[] pair = sortedNums[j];
                int num1 = pair[0], num2 = pair[1];
                while (!stack.isEmpty() && stack.get(stack.size() - 1)[1] <= num1 + num2) {
                    stack.remove(stack.size() - 1);
                }
                if (stack.isEmpty() || stack.get(stack.size() - 1)[0] < num2) {
                    stack.add(new int[]{num2, num1 + num2});
                }
                j++;
            }
            int k = binarySearch(stack, y);
            if (k < stack.size()) {
                answer[i] = stack.get(k)[1];
            }
        }
        return answer;
    }

    public int binarySearch(List<int[]> list, int target) {
        int low = 0, high = list.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (list.get(mid)[0] >= target) {
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
    public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries) {
        int n = nums1.Length;
        int[][] sortedNums = new int[n][];
        for (int i = 0; i < n; i++) {
            sortedNums[i] = new int[2];
            sortedNums[i][0] = nums1[i];
            sortedNums[i][1] = nums2[i];
        }
        Array.Sort(sortedNums, (a, b) => b[0] - a[0]);
        int q = queries.Length;
        int[][] sortedQueries = new int[q][];
        for (int i = 0; i < q; i++) {
            sortedQueries[i] = new int[3];
            sortedQueries[i][0] = i;
            sortedQueries[i][1] = queries[i][0];
            sortedQueries[i][2] = queries[i][1];
        }
        Array.Sort(sortedQueries, (a, b) => b[1] - a[1]);
        IList<Tuple<int, int>> stack = new List<Tuple<int, int>>();
        int[] answer = new int[q];
        Array.Fill(answer, -1);
        int j = 0;
        foreach (int[] query in sortedQueries) {
            int i = query[0], x = query[1], y = query[2];
            while (j < n && sortedNums[j][0] >= x) {
                int[] pair = sortedNums[j];
                int num1 = pair[0], num2 = pair[1];
                while (stack.Count > 0 && stack[stack.Count - 1].Item2 <= num1 + num2) {
                    stack.RemoveAt(stack.Count - 1);
                }
                if (stack.Count == 0 || stack[stack.Count - 1].Item1 < num2) {
                    stack.Add(new Tuple<int, int>(num2, num1 + num2));
                }
                j++;
            }
            int k = BinarySearch(stack, y);
            if (k < stack.Count) {
                answer[i] = stack[k].Item2;
            }
        }
        return answer;
    }

    public int BinarySearch(IList<Tuple<int, int>> list, int target) {
        int low = 0, high = list.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (list[mid].Item1 >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```c++
class Solution {
public:
    vector<int> maximumSumQueries(vector<int>& nums1, vector<int>& nums2, vector<vector<int>>& queries) {
        vector<pair<int, int>> sortedNums;
        vector<tuple<int, int, int>> sortedQueries;
        for (int i = 0; i < nums1.size(); i++) {
            sortedNums.emplace_back(nums1[i], nums2[i]);
        }
        sort(sortedNums.begin(), sortedNums.end(), greater<pair<int, int>>());
        for (int i = 0; i < queries.size(); i++) {
            sortedQueries.emplace_back(i, queries[i][0], queries[i][1]);
        }
        sort(sortedQueries.begin(), sortedQueries.end(), [](tuple<int, int, int> &a, tuple<int, int, int> &b) {
            return get<1>(a) > get<1>(b);
        });

        vector<pair<int, int>> stk;
        vector<int> answer(queries.size(), -1);
        int j = 0;
        for (auto &[i, x, y] : sortedQueries) {
            while (j < sortedNums.size() && sortedNums[j].first >= x) {
                auto [num1, num2] = sortedNums[j];
                while (!stk.empty() && stk.back().second <= num1 + num2) {
                    stk.pop_back();
                }
                if (stk.empty() || stk.back().first < num2) {
                    stk.emplace_back(num2, num1 + num2);
                }
                j++;
            }
            int k = lower_bound(stk.begin(), stk.end(), make_pair(y, 0)) - stk.begin();
            if (k < stk.size()) {
                answer[i] = stk[k].second;
            }
        }            
        return answer;
    }
};
```

```c
static int cmp1(const void *a, const void *b) {
    return ((int *)b)[0] - ((int *)a)[0];
}

static int cmp2(const void *a, const void *b) {
    return ((int *)b)[1] - ((int *)a)[1];
}

int binarySearch(const int **list, int low, int high, int target) {
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (list[mid][0] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

int* maximumSumQueries(int* nums1, int nums1Size, int* nums2, int nums2Size, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int sortedNums[nums1Size][2];
    int sortedQueries[queriesSize][3];
    for (int i = 0; i < nums1Size; i++) {
        sortedNums[i][0] = nums1[i];
        sortedNums[i][1] = nums2[i];
    }
    qsort(sortedNums, nums1Size, sizeof(sortedNums[0]), cmp1);
    for (int i = 0; i < queriesSize; i++) {
        sortedQueries[i][0] = i;
        sortedQueries[i][1] = queries[i][0];
        sortedQueries[i][2] = queries[i][1];
    }
    qsort(sortedQueries, queriesSize, sizeof(sortedQueries[0]), cmp2);
    
    int **stack = (int **)calloc(nums1Size, sizeof(int *));
    int top = 0;
    for (int i = 0; i < nums1Size; i++) {
        stack[i] = (int *)calloc(2, sizeof(int));
    }
    int *answer = (int *)calloc(queriesSize, sizeof(int));
    int j = 0;
    for (int i = 0; i < queriesSize; i++) {
        answer[i] = -1;
    }
    for (int i = 0; i < queriesSize; i++) {
        int index = sortedQueries[i][0];
        int x = sortedQueries[i][1];
        int y = sortedQueries[i][2];
        while (j < nums1Size && sortedNums[j][0] >= x) {
            int num1 = sortedNums[j][0];
            int num2 = sortedNums[j][1];
            while (top > 0 && stack[top - 1][1] <= num1 + num2) {
                top--;
            }
            if (top == 0 || stack[top - 1][0] < num2) {
                stack[top][0] = num2;
                stack[top][1] = num1 + num2;
                top++;
            }
            j++;
        }
        int k = binarySearch(stack, 0, top, y);
        if (k < top) {
            answer[index] = stack[k][1];
        }
    }   
    for (int i = 0; i < nums1Size; i++) {
        free(stack[i]);
    }    
    free(stack);
    *returnSize = queriesSize;    
    return answer;
}
```

```go
func maximumSumQueries(nums1 []int, nums2 []int, queries [][]int) []int {
    sortedNums := make([][]int, len(nums1))
    for i := 0; i < len(nums1); i++ {
        sortedNums[i] = []int{nums1[i], nums2[i]}
    }
    sort.Slice(sortedNums, func(i, j int) bool { 
        return sortedNums[i][0] > sortedNums[j][0]
    })

    sortedQueries := make([][]int, len(queries))
    for i := 0; i < len(queries); i++ {
        sortedQueries[i] = []int{i, queries[i][0], queries[i][1]}
    }
    sort.Slice(sortedQueries, func(i, j int) bool { 
        return sortedQueries[i][1] > sortedQueries[j][1]
    })

    stack := [][]int{}
    answer := make([]int, len(queries))
    for i := 0; i < len(queries); i++ {
        answer[i] = -1
    }
    j := 0
    for _, q := range sortedQueries {
        i, x, y := q[0], q[1], q[2]
        for j < len(sortedNums) && sortedNums[j][0] >= x {
            num1, num2 := sortedNums[j][0], sortedNums[j][1]
            for len(stack) > 0 && stack[len(stack) - 1][1] <= num1 + num2 {
                stack = stack[:len(stack) - 1]
            }
            if len(stack) == 0 || stack[len(stack) - 1][0] < num2 {
                stack = append(stack, []int{num2, num1 + num2})
            }
            j++
        }
        k := sort.Search(len(stack), func(i int) bool { 
            return stack[i][0] >= y 
        })
        
        if k < len(stack) {
            answer[i] = stack[k][1]
        }
    }            
    return answer
}
```

```javascript
var maximumSumQueries = function(nums1, nums2, queries) {
    const sortedNums = nums1.map((x, i) => [x, nums2[i]]);
    const sortedQueries = queries.map((x, i) => [i, ...x]);
    sortedNums.sort((a, b) => b[0] - a[0]);
    sortedQueries.sort((a, b) => b[1] - a[1]);

    const answer = new Array(queries.length).fill(-1);
    const stack = [];
    let j = 0;
    for (const q of sortedQueries) {
        const i = q[0];
        const x = q[1];
        const y = q[2];
        while (j < sortedNums.length && sortedNums[j][0] >= x) {
            const num1 = sortedNums[j][0];
            const num2 = sortedNums[j][1];
            while (stack.length > 0 && stack[stack.length - 1][1] <= num1 + num2) {
                stack.pop();
            }
            if (stack.length == 0 || stack[stack.length - 1][0] < num2) {
                stack.push([num2, num1 + num2]);
            }
            j++;
        }
        const k = binarySearch(stack, y);
        if (k < stack.length) {
            answer[i] = stack[k][1];
        }
    }         
    return answer;
};

function binarySearch(arr, target) {
    let low = 0, high = arr.length
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (arr[mid][0] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
} 
```

**复杂度分析**

-   时间复杂度：$O((n+q)\times \log{n} + q\times \log{q})$，其中 $n$ 是数组 $nums1$ 的长度，其中 $q$ 是数组 $queries$ 的长度。两次排序分别消耗 $O(n\times \log{n})$ 和 $O(q\times \log{q})$。$n$ 个元素最多进栈出栈各一次。二分搜索会进行 $q$ 次，每次消耗 $O(\log{n})$，总的时间复杂度为 $O((n+q)\times \log{n} + q\times \log{q})$。
-   空间复杂度：$O(n+q)$，需要消耗 $O(n+q)$ 来保存两个排序完的数组，栈消耗 $O(n)$，总的空间复杂度为 $O(n+q)$。
