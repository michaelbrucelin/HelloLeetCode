### [根据数字二进制下 $1$ 的数目排序](https://leetcode.cn/problems/sort-integers-by-the-number-of-1-bits/solutions/109168/gen-ju-shu-zi-er-jin-zhi-xia-1-de-shu-mu-pai-xu-by/)

#### 前言

题目本身很简单，只要调用系统自带的排序函数，然后自己改写排序规则即可，所以这里主要讲解如何计算数字二进制下 $1$ 的个数。

#### 方法一：暴力

对每个十进制的数转二进制的时候统计二进制表示中的 $1$ 的个数即可。

```C++
class Solution {
public:
    int get(int x){
        int res = 0;
        while (x) {
            res += (x % 2);
            x /= 2;
        }
        return res;
    }
    vector<int> sortByBits(vector<int>& arr) {
        vector<int> bit(10001, 0);
        for (auto x: arr) {
            bit[x] = get(x);
        }
        sort(arr.begin(), arr.end(), [&](int x, int y){
            if (bit[x] < bit[y]) {
                return true;
            }
            if (bit[x] > bit[y]) {
                return false;
            }
            return x < y;
        });
        return arr;
    }
};
```

```Java
class Solution {
    public int[] sortByBits(int[] arr) {
        int[] bit = new int[10001];
        List<Integer> list = new ArrayList<Integer>();
        for (int x : arr) {
            list.add(x);
            bit[x] = get(x);
        }
        Collections.sort(list, new Comparator<Integer>() {
            public int compare(Integer x, Integer y) {
                if (bit[x] != bit[y]) {
                    return bit[x] - bit[y];
                } else {
                    return x - y;
                }
            }
        });
        for (int i = 0; i < arr.length; ++i) {
            arr[i] = list.get(i);
        }
        return arr;
    }

    public int get(int x) {
        int res = 0;
        while (x != 0) {
            res += x % 2;
            x /= 2;
        }
        return res;
    }
}
```

```Go
func onesCount(x int) (c int) {
    for ; x > 0; x /= 2 {
        c += x % 2
    }
    return
}

func sortByBits(a []int) []int {
    sort.Slice(a, func(i, j int) bool {
        x, y := a[i], a[j]
        cx, cy := onesCount(x), onesCount(y)
        return cx < cy || cx == cy && x < y
    })
    return a
}
```

```C
int* bit;

int get(int x) {
    int res = 0;
    while (x) {
        res += (x % 2);
        x /= 2;
    }
    return res;
}

int cmp(const void* _x, const void* _y) {
    int x = *(int*)_x, y = *(int*)_y;
    return bit[x] == bit[y] ? x - y : bit[x] - bit[y];
}

int* sortByBits(int* arr, int arrSize, int* returnSize) {
    bit = malloc(sizeof(int) * 10001);
    memset(bit, 0, sizeof(int) * 10001);
    for (int i = 0; i < arrSize; ++i) {
        bit[arr[i]] = get(arr[i]);
    }
    qsort(arr, arrSize, sizeof(int), cmp);
    free(bit);
    *returnSize = arrSize;
    return arr;
}
```

```CSharp
public class Solution {
    public int[] SortByBits(int[] arr) {
        int GetBitCount(int x) {
            int res = 0;
            while (x > 0) {
                res += (x & 1);
                x >>= 1;
            }
            return res;
        }

        var bitCounts = new int[10001];
        foreach (int x in arr) {
            bitCounts[x] = GetBitCount(x);
        }

        Array.Sort(arr, (x, y) => {
            if (bitCounts[x] != bitCounts[y]) {
                return bitCounts[x].CompareTo(bitCounts[y]);
            }
            return x.CompareTo(y);
        });

        return arr;
    }
}
```

```Python
class Solution:
    def sortByBits(self, arr: List[int]) -> List[int]:
        def get_bit_count(x):
            res = 0
            while x:
                res += x & 1
                x >>= 1
            return res

        bit_counts = [0] * 10001
        for x in arr:
            bit_counts[x] = self.get_bit_count(x)

        arr.sort(key=lambda x: (bit_counts[x], x))
        return arr
```

```JavaScript
var sortByBits = function(arr) {
    const getBitCount = (x) => {
        let res = 0;
        while (x) {
            res += x & 1;
            x >>>= 1;
        }
        return res;
    };

    const bitCounts = new Array(10001).fill(0);
    for (const x of arr) {
        bitCounts[x] = getBitCount(x);
    }

    arr.sort((x, y) => {
        if (bitCounts[x] !== bitCounts[y]) {
            return bitCounts[x] - bitCounts[y];
        }
        return x - y;
    });

    return arr;
};
```

```TypeScript
function sortByBits(arr: number[]): number[] {
    const getBitCount = (x: number): number => {
        let res = 0;
        while (x) {
            res += x & 1;
            x >>>= 1;
        }
        return res;
    };

    const bitCounts: number[] = new Array(10001).fill(0);
    for (const x of arr) {
        bitCounts[x] = getBitCount(x);
    }

    arr.sort((x: number, y: number): number => {
        if (bitCounts[x] !== bitCounts[y]) {
            return bitCounts[x] - bitCounts[y];
        }
        return x - y;
    });

    return arr;
}
```

```Rust
impl Solution {
    pub fn sort_by_bits(mut arr: Vec<i32>) -> Vec<i32> {
        fn get_bit_count(mut x: i32) -> i32 {
            let mut res = 0;
            while x != 0 {
                res += x & 1;
                x >>= 1;
            }
            res
        }

        let mut bit_counts = vec![0; 10001];
        for &x in &arr {
            bit_counts[x as usize] = get_bit_count(x);
        }

        arr.sort_by(|&x, &y| {
            let count_x = bit_counts[x as usize];
            let count_y = bit_counts[y as usize];
            if count_x != count_y {
                count_x.cmp(&count_y)
            } else {
                x.cmp(&y)
            }
        });

        arr
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 为整数数组 $arr$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 为整数数组 $arr$ 的长度。

#### 方法二：递推预处理

我们定义 $bit[i]$ 为数字 $i$ 二进制表示下数字 $1$ 的个数，则可以列出递推式：

$$bit[i]=bit[i>>1]+(i\&1)$$

所以我们线性预处理 $bit$ 数组然后去排序即可。

```C++
class Solution {
public:
    vector<int> sortByBits(vector<int>& arr) {
        vector<int> bit(10001, 0);
        for (int i = 1; i <= 10000; ++i) {
            bit[i] = bit[i >> 1] + (i & 1);
        }
        sort(arr.begin(), arr.end(), [&](int x, int y){
            if (bit[x] < bit[y]) {
                return true;
            }
            if (bit[x] > bit[y]) {
                return false;
            }
            return x < y;
        });
        return arr;
    }
};
```

```Java
class Solution {
    public int[] sortByBits(int[] arr) {
        List<Integer> list = new ArrayList<Integer>();
        for (int x : arr) {
            list.add(x);
        }
        int[] bit = new int[10001];
        for (int i = 1; i <= 10000; ++i) {
            bit[i] = bit[i >> 1] + (i & 1);
        }
        Collections.sort(list, new Comparator<Integer>() {
            public int compare(Integer x, Integer y) {
                if (bit[x] != bit[y]) {
                    return bit[x] - bit[y];
                } else {
                    return x - y;
                }
            }
        });
        for (int i = 0; i < arr.length; ++i) {
            arr[i] = list.get(i);
        }
        return arr;
    }
}
```

```Go
var bit = [1e4 + 1]int{}

func init() {
    for i := 1; i <= 1e4; i++ {
        bit[i] = bit[i>>1] + i&1
    }
}

func sortByBits(a []int) []int {
    sort.Slice(a, func(i, j int) bool {
        x, y := a[i], a[j]
        cx, cy := bit[x], bit[y]
        return cx < cy || cx == cy && x < y
    })
    return a
}
```

```C
int* bit;

int cmp(const void* _x, const void* _y) {
    int x = *(int*)_x, y = *(int*)_y;
    return bit[x] == bit[y] ? x - y : bit[x] - bit[y];
}

int* sortByBits(int* arr, int arrSize, int* returnSize) {
    bit = malloc(sizeof(int) * 10001);
    memset(bit, 0, sizeof(int) * 10001);
    for (int i = 1; i <= 10000; ++i) {
        bit[i] = bit[i >> 1] + (i & 1);
    }
    qsort(arr, arrSize, sizeof(int), cmp);
    free(bit);
    *returnSize = arrSize;
    return arr;
}
```

```CSharp
public class Solution {
    public int[] SortByBits(int[] arr) {
        int[] bit = new int[10001];
        for (int i = 1; i <= 10000; ++i) {
            bit[i] = bit[i >> 1] + (i & 1);
        }

        Array.Sort(arr, (x, y) => {
            if (bit[x] != bit[y]) {
                return bit[x].CompareTo(bit[y]);
            }
            return x.CompareTo(y);
        });

        return arr;
    }
}
```

```Python
class Solution:
    def sortByBits(self, arr: List[int]) -> List[int]:
        bit = [0] * 10001
        for i in range(1, 10001):
            bit[i] = bit[i >> 1] + (i & 1)

        arr.sort(key=lambda x: (bit[x], x))
        return arr
```

```JavaScript
var sortByBits = function(arr) {
    const bit = new Array(10001).fill(0);
    for (let i = 1; i <= 10000; ++i) {
        bit[i] = bit[i >> 1] + (i & 1);
    }

    arr.sort((x, y) => {
        if (bit[x] !== bit[y]) {
            return bit[x] - bit[y];
        }
        return x - y;
    });

    return arr;
};
```

```TypeScript
function sortByBits(arr: number[]): number[] {
    const bit: number[] = new Array(10001).fill(0);
    for (let i = 1; i <= 10000; ++i) {
        bit[i] = bit[i >> 1] + (i & 1);
    }

    arr.sort((x: number, y: number): number => {
        if (bit[x] !== bit[y]) {
            return bit[x] - bit[y];
        }
        return x - y;
    });

    return arr;
}
```

```Rust
impl Solution {
    pub fn sort_by_bits(mut arr: Vec<i32>) -> Vec<i32> {
        let mut bit = vec![0; 10001];
        for i in 1..=10000 {
            bit[i] = bit[i >> 1] + (i & 1);
        }

        arr.sort_by(|&x, &y| {
            let count_x = bit[x as usize];
            let count_y = bit[y as usize];
            if count_x != count_y {
                count_x.cmp(&count_y)
            } else {
                x.cmp(&y)
            }
        });

        arr
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 为整数数组 $arr$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 为整数数组 $arr$ 的长度。
