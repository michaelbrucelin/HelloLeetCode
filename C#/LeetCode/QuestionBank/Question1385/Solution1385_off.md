### [两个数组间的距离值](https://leetcode.cn/problems/find-the-distance-value-between-two-arrays/solutions/168350/liang-ge-shu-zu-jian-de-ju-chi-zhi-by-leetcode-sol/)

#### 方法一：模拟

**思路**

按照题意模拟：对于 `arr1` 数组中的每一个元素 $x_i$，枚举数组 `arr2` 中的每一个元素 $y_j$，检查是否对于每一个 $y_j$ 都有 $\vert x_i-y_j\vert >d$，如果是，就将答案增加 $1$。

**代码**

```C++
class Solution {
public:
    int findTheDistanceValue(vector<int>& arr1, vector<int>& arr2, int d) {
        int cnt = 0;
        for (auto &x: arr1) {
            bool ok = true;
            for (auto &y: arr2) {
                ok &= (abs(x - y) > d);
            }
            cnt += ok;
        }
        return cnt;
    }
};
```

```Java
class Solution {
    public int findTheDistanceValue(int[] arr1, int[] arr2, int d) {
        int cnt = 0;
        for (int x : arr1) {
            boolean ok = true;
            for (int y : arr2) {
                ok &= Math.abs(x - y) > d;
            }
            cnt += ok ? 1 : 0;
        }
        return cnt;
    }
}
```

```Python
class Solution:
    def findTheDistanceValue(self, arr1: List[int], arr2: List[int], d: int) -> int:
        cnt = 0
        for x in arr1:
            if all(abs(x - y) > d for y in arr2):
                cnt += 1
        return cnt
```

```CSharp
public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
        int cnt = 0;
        foreach (int x in arr1) {
            bool ok = true;
            foreach (int y in arr2) {
                ok &= Math.Abs(x - y) > d;
            }
            cnt += ok ? 1 : 0;
        }
        return cnt;
    }
}
```

```Go
func findTheDistanceValue(arr1 []int, arr2 []int, d int) int {
    cnt := 0
    for _, x := range arr1 {
        ok := true
        for _, y := range arr2 {
            ok = ok && abs(x - y) > d
        }
        if ok {
            cnt++
        }
    }
    return cnt
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```C
int findTheDistanceValue(int* arr1, int arr1Size, int* arr2, int arr2Size, int d) {
    int cnt = 0;
    for (int i = 0; i < arr1Size; i++) {
        bool ok = true;
        for (int j = 0; j < arr2Size; j++) {
            ok = ok && (abs(arr1[i] - arr2[j]) > d);
        }
        cnt += ok ? 1 : 0;
    }
    return cnt;
}
```

```JavaScript
var findTheDistanceValue = function(arr1, arr2, d) {
    let cnt = 0;
    for (const x of arr1) {
        let ok = true;
        for (const y of arr2) {
            ok &= Math.abs(x - y) > d;
        }
        cnt += ok ? 1 : 0;
    }
    return cnt;
};
```

```TypeScript
function findTheDistanceValue(arr1: number[], arr2: number[], d: number): number {
    let cnt: number = 0;
    for (const x of arr1) {
        let ok: boolean = true;
        for (const y of arr2) {
            ok = ok && Math.abs(x - y) > d;
        }
        cnt += ok ? 1 : 0;
    }
    return cnt;
}
```

```Rust
impl Solution {
    pub fn find_the_distance_value(arr1: Vec<i32>, arr2: Vec<i32>, d: i32) -> i32 {
        arr1.iter()
            .filter(|&&x| arr2.iter().all(|&y| (x - y).abs() > d))
            .count() as i32
    }
}
```

**复杂度分析**

假设 `arr1` 中元素个数为 $n$，`arr2` 中元素个数为 $m$。

- 时间复杂度：从代码可以看出这里的渐进时间复杂度是 $O(n\times m)$。
- 空间复杂度：这里没有使用任何的辅助空间，故渐进空间复杂度为 $O(1)$。

#### 方法二：二分查找

**思路**

在上一种方法中，要知道是否每一个 $y_j$ 是不是满足 $\vert x_i-y_j\vert >d$，我们枚举了所有 $y_j$。实际上我们只要找到大于等于 $x_i$ 的第一个 $y_j$ 和小于 $x$ 的第一个 $y_j$，看看它们满不满足这个性质就可以了。

我们可以对 `arr2` 进行排序，然后对于 `arr1` 中的每个元素 $x_i$，在 `arr2` 中二分寻找上述的两个 $y_j$，如果这两个元素满足性质，则所有元素都满足性质，将答案增加 $1$。

代码如下。

**代码**

```C++
class Solution {
public:
    int findTheDistanceValue(vector<int>& arr1, vector<int>& arr2, int d) {
        sort(arr2.begin(), arr2.end());
        int cnt = 0;
        for (auto &x: arr1) {
            unsigned p = lower_bound(arr2.begin(), arr2.end(), x) - arr2.begin();
            bool ok = true;
            if (p < arr2.size()) {
                ok &= (arr2[p] - x > d);
            }
            if (p - 1 >= 0 && p - 1 <= arr2.size()) {
                ok &= (x - arr2[p - 1] > d);
            }
            cnt += ok;
        }
        return cnt;
    }
};
```

```Java
class Solution {
    public int findTheDistanceValue(int[] arr1, int[] arr2, int d) {
        Arrays.sort(arr2);
        int cnt = 0;
        for (int x : arr1) {
            int p = binarySearch(arr2, x);
            boolean ok = true;
            if (p < arr2.length) {
                ok &= arr2[p] - x > d;
            }
            if (p - 1 >= 0 && p - 1 <= arr2.length) {
                ok &= x - arr2[p - 1] > d;
            }
            cnt += ok ? 1 : 0;
        }
        return cnt;
    }

    public int binarySearch(int[] arr, int target) {
        int low = 0, high = arr.length - 1;
        if (arr[high] < target) {
            return high + 1;
        }
        while (low < high) {
            int mid = (high - low) / 2 + low;
            if (arr[mid] < target) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }
        return low;
    }
}
```

```Python
class Solution:
    def findTheDistanceValue(self, arr1: List[int], arr2: List[int], d: int) -> int:
        arr2.sort()
        cnt = 0
        for x in arr1:
            p = bisect.bisect_left(arr2, x)
            if p == len(arr2) or abs(x - arr2[p]) > d:
                if p == 0 or abs(x - arr2[p - 1]) > d:
                    cnt += 1
        return cnt
```

```CSharp
public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
        Array.Sort(arr2);
        int cnt = 0;

        foreach (int x in arr1) {
            int p = Array.BinarySearch(arr2, x);
            if (p < 0) p = ~p;

            bool ok = true;
            if (p < arr2.Length) {
                ok &= (arr2[p] - x > d);
            }
            if (p - 1 >= 0 && p - 1 < arr2.Length) {
                ok &= (x - arr2[p - 1] > d);
            }
            cnt += ok ? 1 : 0;
        }
        return cnt;
    }
}
```

```Go
func findTheDistanceValue(arr1 []int, arr2 []int, d int) int {
    sort.Ints(arr2)
    cnt := 0

    for _, x := range arr1 {
        p := sort.SearchInts(arr2, x)

        ok := true
        if p < len(arr2) {
            ok = ok && (arr2[p] - x > d)
        }
        if p - 1 >= 0 && p - 1 < len(arr2) {
            ok = ok && (x - arr2[p-1] > d)
        }

        if ok {
            cnt++
        }
    }
    return cnt
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int findTheDistanceValue(int* arr1, int arr1Size, int* arr2, int arr2Size, int d) {
    qsort(arr2, arr2Size, sizeof(int), compare);
    int cnt = 0;

    for (int i = 0; i < arr1Size; i++) {
        int x = arr1[i];
        int left = 0, right = arr2Size;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr2[mid] < x) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        int p = left;

        bool ok = true;
        if (p < arr2Size) {
            ok = ok && (arr2[p] - x > d);
        }
        if (p - 1 >= 0 && p - 1 < arr2Size) {
            ok = ok && (x - arr2[p - 1] > d);
        }

        cnt += ok ? 1 : 0;
    }
    return cnt;
}
```

```JavaScript
var findTheDistanceValue = function(arr1, arr2, d) {
    arr2.sort((a, b) => a - b);
    let cnt = 0;

    for (const x of arr1) {
        let left = 0, right = arr2.length;
        while (left < right) {
            const mid = left + ((right - left) >> 1);
            if (arr2[mid] < x) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        const p = left;

        let ok = true;
        if (p < arr2.length) {
            ok = ok && (arr2[p] - x > d);
        }
        if (p - 1 >= 0 && p - 1 < arr2.length) {
            ok = ok && (x - arr2[p - 1] > d);
        }

        cnt += ok ? 1 : 0;
    }
    return cnt;
};
```

```TypeScript
function findTheDistanceValue(arr1: number[], arr2: number[], d: number): number {
    arr2.sort((a, b) => a - b);
    let cnt: number = 0;

    for (const x of arr1) {
        let left: number = 0, right: number = arr2.length;
        while (left < right) {
            const mid: number = left + ((right - left) >> 1);
            if (arr2[mid] < x) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        const p: number = left;

        let ok: boolean = true;
        if (p < arr2.length) {
            ok = ok && (arr2[p] - x > d);
        }
        if (p - 1 >= 0 && p - 1 < arr2.length) {
            ok = ok && (x - arr2[p - 1] > d);
        }

        cnt += ok ? 1 : 0;
    }
    return cnt;
}
```

```Rust
impl Solution {
    pub fn find_the_distance_value(arr1: Vec<i32>, arr2: Vec<i32>, d: i32) -> i32 {
        let mut arr2 = arr2;
        arr2.sort_unstable();

        arr1.iter()
            .filter(|&&x| {
                let p = arr2.binary_search(&x).unwrap_or_else(|i| i);
                (p >= arr2.len() || arr2[p] - x > d)
                    && (p == 0 || x - arr2[p - 1] > d)
            })
            .count() as i32
    }
}
```

**复杂度分析**

假设 `arr1` 中元素个数为 $n$，`arr2` 中元素个数为 $m$。

- 时间复杂度：给 `arr2` 排序的时间代价是 $O(m\log m)$，对于 `arr1` 中的每个元素都在 `arr2` 中二分的时间代价是 $O(n\log m)$，故渐进时间复杂度为 $O((n+m)\log m)$。
- 空间复杂度：这里没有使用任何的辅助空间，故渐进空间复杂度为 $O(1)$。
