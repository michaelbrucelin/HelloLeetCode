### [将整数按权重排序](https://leetcode.cn/problems/sort-integers-by-the-power-value/solutions/168355/jiang-zheng-shu-an-quan-zhong-pai-xu-by-leetcode-s/)

#### 题目分析

我们要按照权重为第一关键字，原值为第二关键字对区间 `[lo, hi]` 进行排序，关键在于我们怎么求权重。

#### 方法一：递归

**思路**

记 $x$ 的权重为 $f(x)$，按照题意很明显我们可以构造这样的递归式：

$$f(x)=\left\{\begin{array}{lr}​0, & x = 1 \\ f(3x+1)+1, & x mod 2 = 1 \\ f(\dfrac{x}{2}​)+1​, & x mod 2 = 0\end{array}\right.​$$

于是我们就可以递归求解每个数字的权重了。

**代码**

```C++
class Solution {
public:
    int getF(int x) {
        if (x == 1) return 0;
        if (x & 1) return getF(x * 3 + 1) + 1;
        else return getF(x / 2) + 1;
    }

    int getKth(int lo, int hi, int k) {
        vector <int> v;
        for (int i = lo; i <= hi; ++i) v.push_back(i);
        sort(v.begin(), v.end(), [&] (int u, int v) {
            if (getF(u) != getF(v)) return getF(u) < getF(v);
            else return u < v;
        });
        return v[k - 1];
    }
};
```

```Java
class Solution {
    public int getKth(int lo, int hi, int k) {
        List<Integer> list = new ArrayList<Integer>();
        for (int i = lo; i <= hi; ++i) {
            list.add(i);
        }
        Collections.sort(list, new Comparator<Integer>() {
            public int compare(Integer u, Integer v) {
                if (getF(u) != getF(v)) {
                    return getF(u) - getF(v);
                } else {
                    return u - v;
                }
            }
        });
        return list.get(k - 1);
    }

    public int getF(int x) {
        if (x == 1) {
            return 0;
        } else if ((x & 1) != 0) {
            return getF(x * 3 + 1) + 1;
        } else {
            return getF(x / 2) + 1;
        }
    }
}
```

```Python
class Solution:
    def getKth(self, lo: int, hi: int, k: int) -> int:
        def getF(x):
            if x == 1:
                return 0
            return (getF(x * 3 + 1) if x % 2 == 1 else getF(x // 2)) + 1
        
        v = list(range(lo, hi + 1))
        v.sort(key=lambda x: (getF(x), x))
        return v[k - 1]
```

```CSharp
public class Solution {
    public int GetKth(int lo, int hi, int k) {
        List<int> v = new List<int>();
        for (int i = lo; i <= hi; i++) {
            v.Add(i);
        }
        v.Sort((u, v) => {
            int f1 = GetF(u);
            int f2 = GetF(v);
            if (f1 != f2) {
                return f1.CompareTo(f2);
            }
            return u.CompareTo(v);
        });
        return v[k - 1];
    }

    public int GetF(int x) {
        if (x == 1) {
            return 0;
        }
        if ((x & 1) == 1) {
            return GetF(x * 3 + 1) + 1;
        } else {
            return GetF(x / 2) + 1;
        }
    }
}
```

```Go
func getKth(lo int, hi int, k int) int {
    v := []int{}
    for i := lo; i <= hi; i++ {
        v = append(v, i)
    }
    sort.Slice(v, func(i, j int) bool {
        if getF(v[i]) != getF(v[j]) {
            return getF(v[i]) < getF(v[j])
        }
        return v[i] < v[j]
    })
    return v[k - 1]
}

func getF(x int) int {
    if x == 1 {
        return 0
    }
    if x & 1 == 1 {
        return getF(x * 3 + 1) + 1
    } else {
        return getF(x / 2) + 1
    }
}
```

```C
int getF(int x) {
    if (x == 1) {
        return 0;
    }
    if (x & 1) {
        return getF(x * 3 + 1) + 1;
    } else {
        return getF(x / 2) + 1;
    }
}

int compare(const void *a, const void *b) {
    int u = *(int*)a;
    int v = *(int*)b;
    int f1 = getF(u);
    int f2 = getF(v);
    if (f1 != f2) {
        return f1 - f2;
    }
    return u - v;
}

int getKth(int lo, int hi, int k) {
    int size = hi - lo + 1;
    int *v = (int *)malloc(size * sizeof(int));
    for (int i = 0; i < size; ++i) v[i] = lo + i;
    qsort(v, size, sizeof(int), compare);
    int res = v[k - 1];
    free(v);
    return res;
}
```

```JavaScript
function getF(x) {
    if (x === 1) {
        return 0;
    }
    if (x & 1) {
        return getF(x * 3 + 1) + 1;
    } else {
        return getF(Math.floor(x / 2)) + 1;
    }
}

var getKth = function(lo, hi, k) {
    let v = [];
    for (let i = lo; i <= hi; i++) {
        v.push(i);
    }
    v.sort((u, v) => {
        let f1 = getF(u);
        let f2 = getF(v);
        if (f1 !== f2) {
            return f1 - f2;
        }
        return u - v;
    });
    return v[k - 1];
};
```

```TypeScript
function getKth(lo: number, hi: number, k: number): number {
    let v: number[] = [];
    for (let i = lo; i <= hi; i++) {
        v.push(i);
    }
    v.sort((u, v) => {
        let f1 = getF(u);
        let f2 = getF(v);
        if (f1 !== f2) {
            return f1 - f2;
        }
        return u - v;
    });
    return v[k - 1];
};

function getF(x: number): number {
    if (x === 1) {
        return 0;
    }
    if (x & 1) {
        return getF(x * 3 + 1) + 1;
    } else {
        return getF(Math.floor(x / 2)) + 1;
    }
}
```

```Rust
impl Solution {
    pub fn get_kth(lo: i32, hi: i32, k: i32) -> i32 {
        let mut v: Vec<i32> = (lo..=hi).collect();
        v.sort_by(|&u, &v| {
            let f1 = Self::get_f(u);
            let f2 = Self::get_f(v);
            if f1 != f2 {
                f1.cmp(&f2)
            } else {
                u.cmp(&v)
            }
        });
        v[k as usize - 1]
    }

    fn get_f(x: i32) -> i32 {
        if x == 1 {
            return 0;
        }
        if x & 1 == 1 {
            Self::get_f(x * 3 + 1) + 1
        } else {
            Self::get_f(x / 2) + 1
        }
    }
}
```

**复杂度分析**

记区间长度为 $n$，等于 `hi - lo + 1`。

- 时间复杂度：这里的区间一定是 $[1,1000]$ 的子集，在 $[1,1000]$ 中权重最大数的权重为 $178$，即这个递归函数要执行 $178$ 次，所以排序的每次比较的时间代价为 $O(178)$，故渐进时间复杂度为 $O(178 \times nlogn)$。
- 空间复杂度：我们使用了长度为 $n$ 的数组辅助进行排序，同时再使用递归计算权重时最多会使用 $178$ 层的栈空间，故渐进空间复杂度为 $O(n+178)$。

#### 方法二：记忆化

**思路**

我们知道在求 $f(3)$ 的时候会调用到 $f(10)$，在求 $f(20)$ 的时候也会调用到 $f(10)$。同样的，如果单纯递归计算权重的话，会存在很多重复计算，我们可以用记忆化的方式来加速这个过程，即「先查表，再计算」和「先记忆，再返回」。我们可以用一个哈希映射作为这里的记忆化的「表」，这样保证每个元素的权值只被计算 $1$ 次。在 $[1,1000]$ 中所有 $x$ 求 $f(x)$ 的值的过程中，只可能出现 $2228$ 种 $x$，于是效率就会大大提高。

代码如下。

**代码**

```C++
class Solution {
public:
    unordered_map <int, int> f;

    int getF(int x) {
        if (f.find(x) != f.end()) return f[x];
        if (x == 1) return f[x] = 0;
        if (x & 1) return f[x] = getF(x * 3 + 1) + 1;
        else return f[x] = getF(x / 2) + 1;
    }

    int getKth(int lo, int hi, int k) {
        vector <int> v;
        for (int i = lo; i <= hi; ++i) v.push_back(i);
        sort(v.begin(), v.end(), [&] (int u, int v) {
            if (getF(u) != getF(v)) return getF(u) < getF(v);
            else return u < v;
        });
        return v[k - 1];
    }
};
```

```Java
class Solution {
    Map<Integer, Integer> f = new HashMap<Integer, Integer>();

    public int getKth(int lo, int hi, int k) {
        List<Integer> list = new ArrayList<Integer>();
        for (int i = lo; i <= hi; ++i) {
            list.add(i);
        }
        Collections.sort(list, new Comparator<Integer>() {
            public int compare(Integer u, Integer v) {
                if (getF(u) != getF(v)) {
                    return getF(u) - getF(v);
                } else {
                    return u - v;
                }
            }
        });
        return list.get(k - 1);
    }

    public int getF(int x) {
        if (!f.containsKey(x)) {
            if (x == 1) {
                f.put(x, 0);
            } else if ((x & 1) != 0) {
                f.put(x, getF(x * 3 + 1) + 1);
            } else {
                f.put(x, getF(x / 2) + 1);
            }
        }
        return f.get(x);
    }
}
```

```Python
class Solution:
    def getKth(self, lo: int, hi: int, k: int) -> int:
        f = {1: 0}

        def getF(x):
            if x in f:
                return f[x]
            f[x] = (getF(x * 3 + 1) if x % 2 == 1 else getF(x // 2)) + 1
            return f[x]
        
        v = list(range(lo, hi + 1))
        v.sort(key=lambda x: (getF(x), x))
        return v[k - 1]
```

```CSharp
public class Solution {
    Dictionary<int, int> f = new Dictionary<int, int>();

    public int GetKth(int lo, int hi, int k) {
        List<int> v = new List<int>();
        for (int i = lo; i <= hi; i++) {
            v.Add(i);
        }
        v.Sort((u, v) => {
            int f1 = GetF(u);
            int f2 = GetF(v);
            if (f1 != f2) {
                return f1.CompareTo(f2);
            }
            return u.CompareTo(v);
        });
        return v[k - 1];
    }

    public int GetF(int x) {
        if (f.ContainsKey(x)) {
            return f[x];
        }
        if (x == 1) {
            return f[x] = 0;
        }
        if ((x & 1) == 1) {
            return f[x] = GetF(x * 3 + 1) + 1;
        } else {
            return f[x] = GetF(x / 2) + 1;
        }
    }
}
```

```Go
var f = make(map[int]int)

func getF(x int) int {
    if val, exists := f[x]; exists {
        return val
    }
    if x == 1 {
        f[x] = 0
        return 0
    }
    if x&1 == 1 {
        f[x] = getF(x * 3 + 1) + 1
    } else {
        f[x] = getF(x / 2) + 1
    }
    return f[x]
}

func getKth(lo int, hi int, k int) int {
    v := make([]int, 0)
    for i := lo; i <= hi; i++ {
        v = append(v, i)
    }
    sort.Slice(v, func(i, j int) bool {
        if getF(v[i]) != getF(v[j]) {
            return getF(v[i]) < getF(v[j])
        }
        return v[i] < v[j]
    })
    return v[k - 1]
}
```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

HashItem *f = NULL;

int getF(int x) {
    int result = hashGetItem(&f, x, -1); 
    if (result != -1) {
        return result;
    }

    if (x == 1) {
        result = 0;
    } else if (x & 1) {
        result = getF(x * 3 + 1) + 1;
    } else {
        result = getF(x / 2) + 1;
    }
    hashAddItem(&f, x, result);
    return result;
}

int compare(const void *a, const void *b) {
    int u = *(int*)a;
    int v = *(int*)b;
    int f1 = getF(u);
    int f2 = getF(v);
    if (f1 != f2) {
        return f1 - f2;
    }
    return u - v;
}

int getKth(int lo, int hi, int k) {
    int size = hi - lo + 1;
    int *v = (int *)malloc(size * sizeof(int));
    for (int i = 0; i < size; ++i) {
        v[i] = lo + i;
    }
    qsort(v, size, sizeof(int), compare);
    int result = v[k - 1];
    free(v);
    hashFree(&f);
    return result;
}
```

```JavaScript
const f = new Map();

function getF(x) {
    if (f.has(x)) {
        return f.get(x);
    }
    if (x === 1) {
        return f.set(x, 0).get(x);
    }
    if (x & 1) {
        return f.set(x, getF(x * 3 + 1) + 1).get(x);
    }
    return f.set(x, getF(x / 2) + 1).get(x);
}

var getKth = function(lo, hi, k) {
    let v = [];
    for (let i = lo; i <= hi; i++) {
        v.push(i);
    }
    v.sort((u, v) => {
        let f1 = getF(u);
        let f2 = getF(v);
        if (f1 !== f2) {
            return f1 - f2;
        }
        return u - v;
    });
    return v[k - 1];
};
```

```TypeScript
function getKth(lo: number, hi: number, k: number): number {
    let v: number[] = [];
    for (let i = lo; i <= hi; i++) {
        v.push(i);
    }
    v.sort((u, v) => {
        let f1 = getF(u);
        let f2 = getF(v);
        if (f1 !== f2) {
            return f1 - f2;
        }
        return u - v;
    });
    return v[k - 1];
};

const f: Map<number, number> = new Map();

function getF(x: number): number {
    if (f.has(x)) {
        return f.get(x)!;
    }
    if (x === 1) {
        return f.set(x, 0).get(x)!;
    }
    if (x & 1) {
        return f.set(x, getF(x * 3 + 1) + 1).get(x)!;
    }
    return f.set(x, getF(x / 2) + 1).get(x)!;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    fn get_f(x: i32, f: &mut HashMap<i32, i32>) -> i32 {
        if let Some(&val) = f.get(&x) {
            return val;
        }
        let res = if x == 1 {
            0
        } else if x & 1 == 1 {
            Self::get_f(x * 3 + 1, f) + 1
        } else {
            Self::get_f(x / 2, f) + 1
        };
        f.insert(x, res);
        res
    }

    pub fn get_kth(lo: i32, hi: i32, k: i32) -> i32 {
        let mut f: HashMap<i32, i32> = HashMap::new();
        let mut v: Vec<i32> = (lo..=hi).collect();
        v.sort_by(|&u, &v| {
            let f1 = Self::get_f(u, &mut f);
            let f2 = Self::get_f(v, &mut f);
            if f1 != f2 {
                f1.cmp(&f2)
            } else {
                u.cmp(&v)
            }
        });
        v[k as usize - 1]
    }
}
```

**复杂度分析**

- 时间复杂度：平均情况下比较的次数为 $nlogn$，把 $2228$ 次平摊到每一次的时间代价为 $O(\dfrac{2228}{nlogn}​)$，故总时间代价为 $O(\dfrac{2228}{nlogn}​ \times nlogn)=O(2228)$。
- 空间复杂度：我们使用了长度为 $n$ 的数组辅助进行排序，哈希映射只可能存在 $2228$ 种键，故渐进空间复杂度为 $O(n+2228)$。由于这里我们使用了记忆化，因此递归使用的栈空间层数会均摊到所有的 $n$ 中，由于 $n$ 的最大值为 $1000$，因此每一个 $n$ 使用的栈空间为 $O(\dfrac{2228}{1000}​) \approx O(2)$，相较于排序的哈希映射需要的空间可以忽略不计。
