### [无需开会的工作日](https://leetcode.cn/problems/count-days-without-meetings/solutions/3713170/wu-xu-kai-hui-de-gong-zuo-ri-by-leetcode-6c3i/)

#### 方法一：区间合并

**思路与算法**

我们可以将每个会议看作一个闭区间，合并所有区间后将总天数减去每一段合并后的区间就是答案。关于合并区间的方法，可以参考「[56\. 合并区间](https://leetcode.cn/problems/merge-intervals/solutions/203562/he-bing-qu-jian-by-leetcode-solution/)」的题解。

在实现时，我们可以在合并区间的同时减去正在被合并的区间的长度。

**代码**

```C++
class Solution {
public:
    int countDays(int days, vector<vector<int>>& meetings) {
        sort(meetings.begin(), meetings.end());
        int l = 1, r = 0;
        for (auto m : meetings) {
            if (m[0] > r) {
                days -= (r - l + 1);
                l = m[0];
            }
            r = max(r, m[1]);
        }
        days -= (r - l + 1);
        return days;
    }
};
```

```Java
class Solution {
    public int countDays(int days, int[][] meetings) {
        Arrays.sort(meetings, Comparator.comparingInt(a -> a[0]));
        int l = 1, r = 0;
        for (int[] m : meetings) {
            if (m[0] > r) {
                days -= (r - l + 1);
                l = m[0];
            }
            r = Math.max(r, m[1]);
        }
        days -= (r - l + 1);
        return days;
    }
}
```

```Python
class Solution:
    def countDays(self, days: int, meetings: List[List[int]]) -> int:
        meetings.sort()
        l, r = 1, 0
        for m in meetings:
            if m[0] > r:
                days -= r - l + 1
                l = m[0]
            r = max(r, m[1])
        days -= r - l + 1
        return days

```

```CSharp
public class Solution {
    public int CountDays(int days, int[][] meetings) {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        int l = 1, r = 0;
        foreach (var m in meetings) {
            if (m[0] > r) {
                days -= (r - l + 1);
                l = m[0];
            }
            r = Math.Max(r, m[1]);
        }
        days -= (r - l + 1);
        return days;
    }
}
```

```Go
func countDays(days int, meetings [][]int) int {
    sort.Slice(meetings, func(i, j int) bool {
        return meetings[i][0] < meetings[j][0]
    })
    l, r := 1, 0
    for _, m := range meetings {
        if m[0] > r {
            days -= r - l + 1
            l = m[0]
        }
        if m[1] > r {
            r = m[1]
        }
    }
    days -= r - l + 1
    return days
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int**)a)[0] - (*(int**)b)[0];
}

int countDays(int days, int** meetings, int meetingsSize,
              int* meetingsColSize) {

    qsort(meetings, meetingsSize, sizeof(int*), compare);
    int l = 1, r = 0;
    for (int i = 0; i < meetingsSize; ++i) {
        int start = meetings[i][0], end = meetings[i][1];
        if (start > r) {
            days -= (r - l + 1);
            l = start;
        }
        if (end > r) {
            r = end;
        }
    }
    days -= (r - l + 1);
    return days;
}
```

```JavaScript
var countDays = function(days, meetings) {
    meetings.sort((a, b) => a[0] - b[0]);
    let l = 1, r = 0;
    for (const [start, end] of meetings) {
        if (start > r) {
            days -= (r - l + 1);
            l = start;
        }
        r = Math.max(r, end);
    }
    days -= (r - l + 1);
    return days;
};
```

```TypeScript
function countDays(days: number, meetings: number[][]): number {
    meetings.sort((a, b) => a[0] - b[0]);
    let l = 1, r = 0;
    for (const [start, end] of meetings) {
        if (start > r) {
            days -= (r - l + 1);
            l = start;
        }
        r = Math.max(r, end);
    }
    days -= (r - l + 1);
    return days;
};
```

```Rust
impl Solution {
    pub fn count_days(mut days: i32, mut meetings: Vec<Vec<i32>>) -> i32 {
        meetings.sort_by_key(|m| m[0]);
        let (mut l, mut r) = (1, 0);
        for m in meetings {
            let (start, end) = (m[0], m[1]);
            if start > r {
                days -= r - l + 1;
                l = start;
            }
            r = r.max(end);
        }
        days -= r - l + 1;
        days
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $meetings$ 数组的长度。对数组排序需要 $O(n\log n)$ 时间。
- 空间复杂度：$O(S_n)$，即为对 $meetings$ 排序所需的空间，其值取决于语言的具体实现，在 Java 和 C++ 中是 $O(\log n)$，在 Python 中是 $O(n)$。
