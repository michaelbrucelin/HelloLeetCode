### [子序列最大优雅度](https://leetcode.cn/problems/maximum-elegance-of-a-k-length-subsequence/solutions/2807350/zi-xu-lie-zui-da-you-ya-du-by-leetcode-s-mw6g/)

#### 方法一：贪心

首先将二维整数数组 $\textit{items}$ 按照 $\textit{profit}$ 从大到小进行排序。当子序列为前 $k$ 个项目时，子序列的利润总和 $\textit{total}\_\textit{profit}$ 最大，但是 $\textit{distinct}\_\textit{categories}$ 不一定为最大。考虑第 $k + 1$ 个项目时，如果将它与已选的 $k$ 个项目之一进行替换，那么显然只能使 $\textit{distinct}\_\textit{categories}$ 增加，是否替换有几种情况：

- 如果 $k + 1$ 个项目与已选的 $k$ 个项目的已有类别相同，那么选择它后，$\textit{distinct}\_\textit{categories}$ 不会增加，但是 $\textit{total}\_\textit{profit}$ 可能会减少，总体优雅度不会增加，所以不选择该项目。
- 如果 $k + 1$ 个项目与已选的 $k$ 个项目的已有类别都不相同，那么选择它后，对应的替换项目有两种情况：
    - 如果对应的替换项目的类别只出现一次，那么替换后，$\textit{distinct}\_\textit{categories}$ 不变，总体优雅度也不会增加，所以不选择该项目。
    - 如果对应的替换项目的类别出现两次以上，取利润最小的项目进行替换，那么替换后，$\textit{distinct}\_\textit{categories}$ 会增加，总体优雅度有可能增加，所以可以选择该项目。（如果现在不选择该项目，后续出现类似的情况时，因为利润是从大到小排序的，总体优雅度不会更大。）

经过以上分类讨论后，我们知道每次考虑新增一个项目时，只有一种情况可能使总体优雅度更大。在求解过程中，我们可以使用栈来维护在已选的 $k$ 个项目中，类别出现两次以上且利润非最大的所有项目，同时因为项目已经按照利润从大到小排序，所以栈顶元素为利润类别出现两次以上且利润最小的项目。求得以上所有可能的子序列的优雅度，取最大值为结果。

```C++
class Solution {
public:
    long long findMaximumElegance(vector<vector<int>>& items, int k) {
        sort(items.begin(), items.end(), [&](const vector<int> &item1, const vector<int> &item2) -> bool {
            return item1[0] > item2[0];
        });
        unordered_set<int> categorySet;
        long long res = 0, profit = 0;
        stack<int> st;
        for (int i = 0; i < items.size(); i++) {
            if (i < k) {
                profit += items[i][0];
                if (categorySet.count(items[i][1]) == 0) {
                    categorySet.insert(items[i][1]);
                } else {
                    st.push(items[i][0]);
                }
            } else if (categorySet.count(items[i][1]) == 0 && !st.empty()) {
                profit += items[i][0] - st.top();
                st.pop();
                categorySet.insert(items[i][1]);
            }
            res = max(res, (long long)(profit + categorySet.size() * categorySet.size()));
        }
        return res;
    }
};
```

```Java
class Solution {
    public long findMaximumElegance(int[][] items, int k) {
        Arrays.sort(items, (item0, item1) -> item1[0] - item0[0]);
        var categorySet = new HashSet<Integer>();
        long profit = 0, res = 0;
        var st = new ArrayDeque<Integer>();
        for (int i = 0; i < items.length; i++) {
            if (i < k) {
                profit += items[i][0];
                if (!categorySet.add(items[i][1])) {
                    st.push(items[i][0]);
                }
            } else if (!st.isEmpty() && categorySet.add(items[i][1])) {
                profit += items[i][0] - st.pop();
            }
            res = Math.max(res, profit + (long)categorySet.size() * categorySet.size());
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long FindMaximumElegance(int[][] items, int k) {
        Array.Sort(items, (item0, item1) => item1[0] - item0[0]);
        ISet<int> categorySet = new HashSet<int>();
        long profit = 0, res = 0;
        Stack<int> st = new Stack<int>();
        for (int i = 0; i < items.Length; i++) {
            if (i < k) {
                profit += items[i][0];
                if (!categorySet.Add(items[i][1])) {
                    st.Push(items[i][0]);
                }
            } else if (st.Count > 0 && categorySet.Add(items[i][1])) {
                profit += items[i][0] - st.Pop();
            }
            res = Math.Max(res, profit + (long)categorySet.Count * categorySet.Count);
        }
        return res;
    }
}
```

```Go
func findMaximumElegance(items [][]int, k int) int64 {
    sort.Slice(items, func(i, j int) bool {
        return items[i][0] > items[j][0]
    })
    categorySet := map[int]bool{}
    var res, profit int64
    var st []int
    for i, item := range items {
        if i < k {
            profit += int64(item[0])
            if categorySet[item[1]] {
                st = append(st, item[0])
            } else {
                categorySet[item[1]] = true
            }
        } else if !categorySet[item[1]] && len(st) > 0 {
            profit += int64(item[0] - st[len(st) - 1])
            st = st[:len(st)-1]
            categorySet[item[1]] = true
        }
        res = max(res, profit + int64(len(categorySet) * len(categorySet)))
    }
    return res
}
```

```Python
class Solution:
    def findMaximumElegance(self, items: List[List[int]], k: int) -> int:
        items.sort(key = lambda item: -item[0])
        categorySet = set()
        res, profit = 0, 0
        st = []
        for i, item in enumerate(items):
            if i < k:
                profit += item[0]
                if item[1] in categorySet:
                    st.append(item[0])
                else:
                    categorySet.add(item[1])
            elif item[1] not in categorySet and len(st) > 0:
                profit += item[0] - st.pop()
                categorySet.add(item[1])
            res = max(res, profit + len(categorySet) * len(categorySet))
        return res
```

```C
int cmp(const void *p0, const void *p1) {
    return (*(const int **)p1)[0] - (*(const int **)p0)[0];
}

long long findMaximumElegance(int **items, int itemsSize, int *itemsColSize, int k){
    qsort(items, itemsSize, sizeof(int *), cmp);
    int *categorySet = (int *)malloc((itemsSize + 1) * sizeof(int));
    memset(categorySet, 0, (itemsSize + 1) * sizeof(int));
    long long res = 0, profit = 0;
    int *st = (int *)malloc(itemsSize * sizeof(int));
    long long ms = 0, mc = 0;
    for (int i = 0; i < itemsSize; i++) {
        if (i < k) {
            profit += items[i][0];
            if (categorySet[items[i][1]] == 0) {
                categorySet[items[i][1]] = 1;
                mc++;
            } else {
                st[ms++] = items[i][0];
            }
        } else if (categorySet[items[i][1]] == 0 && ms > 0) {
            profit += items[i][0] - st[--ms];
            categorySet[items[i][1]] = 1;
            mc++;
        }
        res = fmax(res, profit + mc * mc);
    }
    free(st);
    free(categorySet);
    return res;
}
```

```JavaScript
var findMaximumElegance = function(items, k) {
    items.sort((item0, item1) => item1[0] - item0[0])
    let categorySet = new Set();
    let profit = 0, res = 0;
    let st = [];
    for (let i = 0; i < items.length; i++) {
        if (i < k) {
            profit += items[i][0];
            if (!categorySet.has(items[i][1])) { 
                categorySet.add(items[i][1]);
            } else {
                st.push(items[i][0]);
            }
        } else if (st.length > 0 && !categorySet.has(items[i][1])) {
            profit += items[i][0] - st.pop();
            categorySet.add(items[i][1]);
        }
        res = Math.max(res, profit + categorySet.size * categorySet.size);
    }
    return res;
};
```

```TypeScript
function findMaximumElegance(items: number[][], k: number): number {
    items.sort((item0, item1) => item1[0] - item0[0])
    let categorySet = new Set();
    let profit = 0, res = 0;
    let st = [];
    for (let i = 0; i < items.length; i++) {
        if (i < k) {
            profit += items[i][0];
            if (!categorySet.has(items[i][1])) { 
                categorySet.add(items[i][1]);
            } else {
                st.push(items[i][0]);
            }
        } else if (st.length > 0 && !categorySet.has(items[i][1])) {
            profit += items[i][0] - st.pop();
            categorySet.add(items[i][1]);
        }
        res = Math.max(res, profit + categorySet.size * categorySet.size);
    }
    return res;
};
```

```Rust
use std::collections::{HashSet, VecDeque};

impl Solution {
    pub fn find_maximum_elegance(mut items: Vec<Vec<i32>>, k: i32) -> i64 {
        items.sort_unstable_by_key(|item| -item[0]);
        let (mut categorySet, mut st) = (HashSet::new(), VecDeque::new());
        let (mut res, mut profit) = (0 as i64, 0 as i64);
        for (i, item) in items.iter().enumerate() {
            if i < k as usize {
                profit += item[0] as i64;
                if !categorySet.contains(&item[1]) {
                    categorySet.insert(item[1]);
                } else {
                    st.push_back(item[0]);
                }
            } else if (!categorySet.contains(&item[1]) && !st.is_empty()) {
                profit += (item[0] - st.back().unwrap()) as i64;
                st.pop_back();
                categorySet.insert(item[1]);
            }
            res = res.max(profit + (categorySet.len() * categorySet.len()) as i64);
        }
        res as i64
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$，其中 $n$ 为数组 $\textit{items}$ 的长度。排序需要 $O(n \log n)$，求解答案需要 $O(n)$。
- 空间复杂度：$O(n)$。栈与哈希表的空间开销为 $O(n)$。
