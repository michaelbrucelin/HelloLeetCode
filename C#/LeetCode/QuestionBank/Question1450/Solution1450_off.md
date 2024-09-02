### [在既定时间做作业的学生人数](https://leetcode.cn/problems/number-of-students-doing-homework-at-a-given-time/solutions/1756925/zai-ji-ding-shi-jian-zuo-zuo-ye-de-xue-s-uv49/)

#### 方法一：枚举

题目要求找到 $queryTime$ 时正在做作业的学生人数，第 $i$ 名学生的起始时间 $startTime[i]$ 和完成时间 $endTime[i]$ 如果满足 $startTime[i] \le queryTime \le endTime[i]$，则可知该名学生在 $queryTime$ 时一定正在作业。我们遍历所有学生的起始时间和结束时间，统计符合上述条件的学生总数即可。

```Python
class Solution:
    def busyStudent(self, startTime: List[int], endTime: List[int], queryTime: int) -> int:
        return sum(s <= queryTime <= e for s, e in zip(startTime, endTime))
```

```C++
class Solution {
public:
    int busyStudent(vector<int>& startTime, vector<int>& endTime, int queryTime) {
        int n = startTime.size();
        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (startTime[i] <= queryTime && endTime[i] >= queryTime) {
                ans++;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int busyStudent(int[] startTime, int[] endTime, int queryTime) {
        int n = startTime.length;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (startTime[i] <= queryTime && endTime[i] >= queryTime) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
        int n = startTime.Length;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            if (startTime[i] <= queryTime && endTime[i] >= queryTime) {
                ans++;
            }
        }
        return ans;
    }
}
```

```C
int busyStudent(int* startTime, int startTimeSize, int* endTime, int endTimeSize, int queryTime){
    int ans = 0;
    for (int i = 0; i < startTimeSize; i++) {
        if (startTime[i] <= queryTime && endTime[i] >= queryTime) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var busyStudent = function(startTime, endTime, queryTime) {
    const n = startTime.length;
    let ans = 0;
    for (let i = 0; i < n; i++) {
        if (startTime[i] <= queryTime && endTime[i] >= queryTime) {
            ans++;
        }
    }
    return ans;
};
```

```Go
func busyStudent(startTime []int, endTime []int, queryTime int) (ans int) {
    for i, s := range startTime {
        if s <= queryTime && queryTime <= endTime[i] {
            ans++
        }
    }
    return
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 数组的长度。只需遍历一遍数组即可。
- 空间复杂度：$O(1)$。

#### 方法二：差分数组

利用差分数组的思想，对差分数组求前缀和，可以得到统计出 $t$ 时刻正在做作业的人数。我们初始化差分数组 $cnt$ 每个元素都为 $0$，在每个学生的起始时间处 $cnt[startTime[i]]$ 加 $1$，在每个学生的结束时间处 $cnt[endTime[i]+1]$ 减 $1$，因此我们可以统计出 $queryTime$ 时刻正在做作业的人数为 $\sum_{j=0}^{queryTime}cnt[j]$。

```Python
class Solution:
    def busyStudent(self, startTime: List[int], endTime: List[int], queryTime: int) -> int:
        maxEndTime = max(endTime)
        if queryTime > maxEndTime:
            return 0
        cnt = [0] * (maxEndTime + 2)
        for s, e in zip(startTime, endTime):
            cnt[s] += 1
            cnt[e + 1] -= 1
        return sum(cnt[:queryTime + 1])
```

```C++
class Solution {
public:
    int busyStudent(vector<int>& startTime, vector<int>& endTime, int queryTime) {
        int n = startTime.size();
        int maxEndTime = *max_element(endTime.begin(), endTime.end());
        if (queryTime > maxEndTime) {
            return 0;
        }
        vector<int> cnt(maxEndTime + 2);
        for (int i = 0; i < n; i++) {
            cnt[startTime[i]]++;
            cnt[endTime[i] + 1]--;
        }
        int ans = 0;
        for (int i = 0; i <= queryTime; i++) {
            ans += cnt[i];
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int busyStudent(int[] startTime, int[] endTime, int queryTime) {
        int n = startTime.length;
        int maxEndTime = Arrays.stream(endTime).max().getAsInt();
        if (queryTime > maxEndTime) {
            return 0;
        }
        int[] cnt = new int[maxEndTime + 2];
        for (int i = 0; i < n; i++) {
            cnt[startTime[i]]++;
            cnt[endTime[i] + 1]--;
        }
        int ans = 0;
        for (int i = 0; i <= queryTime; i++) {
            ans += cnt[i];
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
        int n = startTime.Length;
        int maxEndTime = endTime.Max();
        if (queryTime > maxEndTime) {
            return 0;
        }
        int[] cnt = new int[maxEndTime + 2];
        for (int i = 0; i < n; i++) {
            cnt[startTime[i]]++;
            cnt[endTime[i] + 1]--;
        }
        int ans = 0;
        for (int i = 0; i <= queryTime; i++) {
            ans += cnt[i];
        }
        return ans;
    }
}
```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int busyStudent(int* startTime, int startTimeSize, int* endTime, int endTimeSize, int queryTime){
    int maxEndTime = 0;
    for (int i = 0; i < endTimeSize; i++) {
        maxEndTime = MAX(maxEndTime, endTime[i]);
    }
    if (queryTime > maxEndTime) {
        return 0;
    }
    int *cnt = (int *)malloc(sizeof(int) * (maxEndTime + 2));
    memset(cnt, 0, sizeof(maxEndTime) * (maxEndTime + 2));
    for (int i = 0; i < startTimeSize; i++) {
        cnt[startTime[i]]++;
        cnt[endTime[i] + 1]--;
    }
    int ans = 0;
    for (int i = 0; i <= queryTime; i++) {
        ans += cnt[i];
    }
    free(cnt);
    return ans;
}
```

```JavaScript
var busyStudent = function(startTime, endTime, queryTime) {
    const n = startTime.length;
    const maxEndTime = _.max(endTime);
    if (queryTime > maxEndTime) {
        return 0;
    }
    const cnt = new Array(maxEndTime + 2).fill(0);
    for (let i = 0; i < n; i++) {
        cnt[startTime[i]]++;
        cnt[endTime[i] + 1]--;
    }
    let ans = 0;
    for (let i = 0; i <= queryTime; i++) {
        ans += cnt[i];
    }
    return ans;
};
```

```Go
func busyStudent(startTime []int, endTime []int, queryTime int) (ans int) {
    maxEndTime := 0
    for _, e := range endTime {
        maxEndTime = max(maxEndTime, e)
    }
    if queryTime > maxEndTime {
        return
    }
    cnt := make([]int, maxEndTime+2)
    for i, s := range startTime {
        cnt[s]++
        cnt[endTime[i]+1]--
    }
    for _, c := range cnt[:queryTime+1] {
        ans += c
    }
    return
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**复杂度分析**

- 时间复杂度：$O(n+queryTime)$，其中 $n$ 为数组的长度，$queryTime$ 为给定的查找时间。首先需要遍历一遍数组，需要的时间为 $O(n)$，然后需要查分求和求出 $queryTime$ 时间点正在作业的学生总数，需要的时间为 $O(queryTime)$，因此总的时间为 $O(n+queryTime)$。
- 空间复杂度：$O(max(endTime))$。

#### 方法三：二分查找

对于每个学生的作业时间 $[startTime[i],endTime[i]]$，一定满足 $startTime[i] \le endTime[i]$。如果第 $i$ 名学生在 $queryTime$ 时正在作业，则一定满足 $startTime[i] \le queryTime \le endTime[i]$。设起始时间小于等于 $queryTime$ 的学生集合为 $lessStart$，设结束时间小于 $queryTime$ 的学生集合为 $lessEnd$，则根据上述推理可以知道 $lessEnd \in lessStart$，我们从 $lessStart$ 去除 $lessEnd$ 的子集部分即为符合条件的学生集合。因此我们通过二分查找找到始时间小于等于 $queryTime$ 的学生人数，然后减去结束时间小于 $queryTime$ 的学生人数，最终结果即为符合条件要求。

```Python
class Solution:
    def busyStudent(self, startTime: List[int], endTime: List[int], queryTime: int) -> int:
        startTime.sort()
        endTime.sort()
        return bisect_right(startTime, queryTime) - bisect_left(endTime, queryTime)
```

```C++
class Solution {
public: 
    int busyStudent(vector<int>& startTime, vector<int>& endTime, int queryTime) {
        sort(startTime.begin(), startTime.end());
        sort(endTime.begin(), endTime.end());
        int lessStart = upper_bound(startTime.begin(), startTime.end(), queryTime) - startTime.begin();
        int lessEnd = lower_bound(endTime.begin(), endTime.end(), queryTime) - endTime.begin();
        return lessStart - lessEnd;
    }
};
```

```Java
class Solution {
    public int busyStudent(int[] startTime, int[] endTime, int queryTime) {
        Arrays.sort(startTime);
        Arrays.sort(endTime);
        int lessStart = upperbound(startTime, 0, startTime.length - 1, queryTime);
        int lessEnd = lowerbound(endTime, 0, endTime.length - 1, queryTime);
        return lessStart - lessEnd;
    }

    public static int upperbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] > target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }

    public static int lowerbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] >= target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
        Array.Sort(startTime);
        Array.Sort(endTime);
        int lessStart = Upperbound(startTime, 0, startTime.Length - 1, queryTime);
        int lessEnd = Lowerbound(endTime, 0, endTime.Length - 1, queryTime);
        return lessStart - lessEnd;
    }

    public static int Upperbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] > target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }

    public static int Lowerbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] >= target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }
}
```

```C
static inline int cmp(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

static int upperbound(const int *arr, int l, int r, int target) {
    int ans = r + 1;
    while (l <= r) {
        int mid = l + ((r - l) >> 1);
        if (arr[mid] > target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
}

static int lowerbound(const int *arr, int l, int r, int target) {
    int ans = r + 1;
    while (l <= r) {
        int mid = l + ((r - l) >> 1);
        if (arr[mid] >= target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
}

int busyStudent(int* startTime, int startTimeSize, int* endTime, int endTimeSize, int queryTime){
    qsort(startTime, startTimeSize, sizeof(int), cmp);
    qsort(endTime, endTimeSize, sizeof(int), cmp);
    int lessStart = upperbound(startTime, 0, startTimeSize - 1, queryTime);
    int lessEnd = lowerbound(endTime, 0, endTimeSize - 1, queryTime);
    return lessStart - lessEnd;
}
```

```JavaScript
var busyStudent = function(startTime, endTime, queryTime) {
    startTime.sort((a, b) => a - b);
    endTime.sort((a, b) => a - b);
    const lessStart = upperbound(startTime, 0, startTime.length - 1, queryTime);
    const lessEnd = lowerbound(endTime, 0, endTime.length - 1, queryTime);
    return lessStart - lessEnd;
}

const upperbound = (arr, l, r, target) => {
    let ans = r + 1;
    while (l <= r) {
        const mid = l + ((r - l) >> 1);
        if (arr[mid] > target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
}

const lowerbound = (arr, l, r, target) => {
    let ans = r + 1;
    while (l <= r) {
        let mid = l + ((r - l) >> 1);
        if (arr[mid] >= target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
};
```

```Go
func busyStudent(startTime []int, endTime []int, queryTime int) (ans int) {
    sort.Ints(startTime)
    sort.Ints(endTime)
    return sort.SearchInts(startTime, queryTime+1) - sort.SearchInts(endTime, queryTime)
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 为 数组的长度。排序需要的时间为 $O(nlogn)$，二分查找的时间复杂度为 $O(logn)$。
- 空间复杂度：$O(logn)$。排序需要的栈空间为 $O(logn)$。
