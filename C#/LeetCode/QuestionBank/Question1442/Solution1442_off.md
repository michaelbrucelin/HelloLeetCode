### [形成两个异或相等数组的三元组数目](https://leetcode.cn/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/solutions/579281/xing-cheng-liang-ge-yi-huo-xiang-deng-sh-jud0/?envType=problem-list-v2&envId=ySsxoJfz)

#### 前言

用 $\oplus$ 表示按位异或运算。

定义长度为 $n$ 的数组 $arr$ 的异或前缀和

$$S_i=\begin{cases}0, & i=0 \\ arr_0\oplus arr_1\oplus \dots \oplus arr_{i-1}, & 1\le i\le n\end{cases}$$

由该定义可得

$$S_i=\begin{cases}0, & i=0 \\ S_{i-1}\oplus arr_{i-1}, & 1\le i\le n\end{cases}$$

这是一个关于 $S_i$ 的递推式，根据该递推式我们可以用 $O(n)$ 的时间得到数组 $arr$ 的异或前缀和数组。

对于两个下标不同的异或前缀和 $S_i$ 和 $S_j$，设 $0<i<j$，有

$$S_i\oplus S_j=(arr_0\oplus arr_1\oplus \dots \oplus arr_{i-1})\oplus (arr_0\oplus arr_1\oplus \dots \oplus arr_{i-1}\oplus arr_i\oplus \dots \oplus arr_{j-1})$$

由于异或运算满足结合律和交换律，且任意数异或自身等于 $0$，上式可化简为

$$S_i\oplus S_j=arr_i\oplus \dots \oplus arr_{j-1}$$

从而，数组 $arr$ 的子区间 $[i,j]$ 的元素异或和为可表示为

$$S_i\oplus S_{j+1}$$

因此问题中的 $a$ 和 $b$ 可表示为

$$a=S_i\oplus S_jb=S_j\oplus S_{k+1}$$

若 $a=b$，则有

$$S_i\oplus S_j=S_j\oplus S_{k+1}$$

即

$$S_i=S_{k+1}$$

#### 方法一：三重循环

计算数组 $arr$ 的异或前缀和 $S$，枚举符合 $0\le i<j\le k<n$ 的下标 $i$，$j$ 和 $k$，统计满足等式 $S_i=S_{k+1}$ 的三元组个数。

```C++
class Solution {
public:
    int countTriplets(vector<int> &arr) {
        int n = arr.size();
        vector<int> s(n + 1);
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                for (int k = j; k < n; ++k) {
                    if (s[i] == s[k + 1]) {
                        ++ans;
                    }
                }
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int countTriplets(int[] arr) {
        int n = arr.length;
        int[] s = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                for (int k = j; k < n; ++k) {
                    if (s[i] == s[k + 1]) {
                        ++ans;
                    }
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length;
        int[] s = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                for (int k = j; k < n; ++k) {
                    if (s[i] == s[k + 1]) {
                        ++ans;
                    }
                }
            }
        }
        return ans;
    }
}
```

```Go
func countTriplets(arr []int) (ans int) {
    n := len(arr)
    s := make([]int, n+1)
    for i, val := range arr {
        s[i+1] = s[i] ^ val
    }
    for i := 0; i < n; i++ {
        for j := i + 1; j < n; j++ {
            for k := j; k < n; k++ {
                if s[i] == s[k+1] {
                    ans++
                }
            }
        }
    }
    return
}
```

```Python
class Solution:
    def countTriplets(self, arr: List[int]) -> int:
        n = len(arr)
        s = [0]
        for val in arr:
            s.append(s[-1] ^ val)

        ans = 0
        for i in range(n):
            for j in range(i + 1, n):
                for k in range(j, n):
                    if s[i] == s[k + 1]:
                        ans += 1

        return ans
```

```JavaScript
var countTriplets = function(arr) {
    const n = arr.length;
    const s = [0];
    for (const num of arr) {
        s.push(s[s.length - 1] ^ num);
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            for (let k = j; k < n; k++) {
                if (s[i] === s[k + 1]) {
                    ans++;
                }
            }
        }
    }

    return ans;
};
```

```C
int countTriplets(int* arr, int arrSize) {
    int n = arrSize;
    int s[n + 1];
    s[0] = 0;
    for (int i = 0; i < n; ++i) {
        s[i + 1] = s[i] ^ arr[i];
    }
    int ans = 0;
    for (int i = 0; i < n; ++i) {
        for (int j = i + 1; j < n; ++j) {
            for (int k = j; k < n; ++k) {
                if (s[i] == s[k + 1]) {
                    ++ans;
                }
            }
        }
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，其中 $n$ 是数组 $arr$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法二：二重循环

当等式 $S_i=S_{k+1}$ 成立时，$[i+1,k]$ 的范围内的任意 $j$ 都是符合要求的，对应的三元组个数为 $k-i$。因此我们只需枚举下标 $i$ 和 $k$。

**代码**

```C++
class Solution {
public:
    int countTriplets(vector<int> &arr) {
        int n = arr.size();
        vector<int> s(n + 1);
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int k = i + 1; k < n; ++k) {
                if (s[i] == s[k + 1]) {
                    ans += k - i;
                }
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int countTriplets(int[] arr) {
        int n = arr.length;
        int[] s = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int k = i + 1; k < n; ++k) {
                if (s[i] == s[k + 1]) {
                    ans += k - i;
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length;
        int[] s = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int k = i + 1; k < n; ++k) {
                if (s[i] == s[k + 1]) {
                    ans += k - i;
                }
            }
        }
        return ans;
    }
}
```

```Go
func countTriplets(arr []int) (ans int) {
    n := len(arr)
    s := make([]int, n+1)
    for i, val := range arr {
        s[i+1] = s[i] ^ val
    }
    for i := 0; i < n; i++ {
        for k := i + 1; k < n; k++ {
            if s[i] == s[k+1] {
                ans += k - i
            }
        }
    }
    return
}
```

```Python
class Solution:
    def countTriplets(self, arr: List[int]) -> int:
        n = len(arr)
        s = [0]
        for val in arr:
            s.append(s[-1] ^ val)

        ans = 0
        for i in range(n):
            for k in range(i + 1, n):
                if s[i] == s[k + 1]:
                    ans += k - i

        return ans
```

```JavaScript
var countTriplets = function(arr) {
    const n = arr.length;
    const s = [0];
    for (const num of arr) {
        s.push(s[s.length - 1] ^ num);
    }

    let ans = 0;
    for (let i = 0; i < n; i++) {
        for (let k = i + 1; k < n; k++) {
            if (s[i] === s[k + 1]) {
                ans += k - i;
            }
        }
    }

    return ans;
};
```

```C
int countTriplets(int* arr, int arrSize) {
    int n = arrSize;
    int s[n + 1];
    s[0] = 0;
    for (int i = 0; i < n; ++i) {
        s[i + 1] = s[i] ^ arr[i];
    }
    int ans = 0;
    for (int i = 0; i < n; ++i) {
        for (int k = i + 1; k < n; ++k) {
            if (s[i] == s[k + 1]) {
                ans += k - i;
            }
        }
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $arr$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法三：哈希表（一重循环）

对于下标 $k$，若下标 $i=i_1,i_2,\dots ,i_m$ 时均满足 $S_i=S_{k+1}$，根据方法二，这些二元组 $(i_1,k),(i_2,k),\dots ,(i_m,k)$ 对答案的贡献之和为

$$(k-i_1)+(k-i_2)+\dots +(k-i_m)=m\cdot k-(i_1+i_2+\dots +i_m)$$

也就是说，当遍历下标 $k$ 时，我们需要知道所有满足 $S_i=S_{k+1}$ 的

- 下标 $i$ 的出现次数 $m$
- 下标 $i$ 之和

这可以借助两个哈希表来做到，在遍历下标 $k$ 的同时，一个哈希表统计 $S_k$ 的出现次数，另一个哈希表统计值为 $S_k$ 的下标之和。

```C++
class Solution {
public:
    int countTriplets(vector<int> &arr) {
        int n = arr.size();
        vector<int> s(n + 1);
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        unordered_map<int, int> cnt, total;
        int ans = 0;
        for (int k = 0; k < n; ++k) {
            if (cnt.count(s[k + 1])) {
                ans += cnt[s[k + 1]] * k - total[s[k + 1]];
            }
            ++cnt[s[k]];
            total[s[k]] += k;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int countTriplets(int[] arr) {
        int n = arr.length;
        int[] s = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        Map<Integer, Integer> cnt = new HashMap<Integer, Integer>();
        Map<Integer, Integer> total = new HashMap<Integer, Integer>();
        int ans = 0;
        for (int k = 0; k < n; ++k) {
            if (cnt.containsKey(s[k + 1])) {
                ans += cnt.get(s[k + 1]) * k - total.get(s[k + 1]);
            }
            cnt.put(s[k], cnt.getOrDefault(s[k], 0) + 1);
            total.put(s[k], total.getOrDefault(s[k], 0) + k);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length;
        int[] s = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        Dictionary<int, int> total = new Dictionary<int, int>();
        int ans = 0;
        for (int k = 0; k < n; ++k) {
            if (cnt.ContainsKey(s[k + 1])) {
                ans += cnt[s[k + 1]] * k - total[s[k + 1]];
            }
            if (!cnt.ContainsKey(s[k])) {
                cnt.Add(s[k], 1);
            } else {
                ++cnt[s[k]];
            }
            if (!total.ContainsKey(s[k])) {
                total.Add(s[k], k);
            } else {
                total[s[k]] += k;
            }
        }
        return ans;
    }
}
```

```Go
func countTriplets(arr []int) (ans int) {
    n := len(arr)
    s := make([]int, n+1)
    for i, v := range arr {
        s[i+1] = s[i] ^ v
    }
    cnt := map[int]int{}
    total := map[int]int{}
    for k := 0; k < n; k++ {
        if m, has := cnt[s[k+1]]; has {
            ans += m*k - total[s[k+1]]
        }
        cnt[s[k]]++
        total[s[k]] += k
    }
    return
}
```

```Python
class Solution:
    def countTriplets(self, arr: List[int]) -> int:
        n = len(arr)
        s = [0]
        for val in arr:
            s.append(s[-1] ^ val)

        cnt, total = Counter(), Counter()
        ans = 0
        for k in range(n):
            if s[k + 1] in cnt:
                ans += cnt[s[k + 1]] * k - total[s[k + 1]]
            cnt[s[k]] += 1
            total[s[k]] += k

        return ans
```

```JavaScript
var countTriplets = function(arr) {
    const n = arr.length;
    s = [0];
    for (const num of arr) {
        s.push(s[s.length - 1] ^ num);
    }

    const cnt = new Map(), total = new Map();
    let ans = 0;
    for (let k = 0; k < n; k++) {
        if (cnt.has(s[k + 1])) {
            ans += cnt.get(s[k + 1]) * k - total.get(s[k + 1]);
        }
        cnt.set(s[k], (cnt.get(s[k]) || 0) + 1);
        total.set(s[k], (total.get(s[k]) || 0) + k);
    }

    return ans;
};
```

```C
struct HashTable {
    int val, key;
    UT_hash_handle hh;
};

bool count(struct HashTable* hashTable, int x) {
    struct HashTable* tmp;
    HASH_FIND_INT(hashTable, &x, tmp);
    return tmp != NULL;
}

int getValue(struct HashTable* hashTable, int x) {
    struct HashTable* tmp;
    HASH_FIND_INT(hashTable, &x, tmp);
    return tmp == NULL ? 0 : tmp->val;
}

void addValue(struct HashTable** hashTable, int x, int y) {
    struct HashTable* tmp;
    HASH_FIND_INT(*hashTable, &x, tmp);
    if (tmp == NULL) {
        tmp = malloc(sizeof(struct HashTable));
        tmp->key = x;
        tmp->val = y;
        HASH_ADD_INT(*hashTable, key, tmp);
    } else {
        tmp->val += y;
    }
}

int countTriplets(int* arr, int arrSize) {
    int n = arrSize;
    int s[n + 1];
    s[0] = 0;
    for (int i = 0; i < n; ++i) {
        s[i + 1] = s[i] ^ arr[i];
    }
    struct HashTable *cnt = NULL, *total = NULL;
    int ans = 0;
    for (int k = 0; k < n; ++k) {
        if (count(cnt, s[k + 1])) {
            ans += getValue(cnt, s[k + 1]) * k - getValue(total, s[k + 1]);
        }
        addValue(&cnt, s[k], 1);
        addValue(&total, s[k], k);
    }
    return ans;
}
```

**优化**

我们可以在计算异或前缀和的同时计算答案，从而做到仅遍历 $arr$ 一次就计算出答案。

```C++
class Solution {
public:
    int countTriplets(vector<int> &arr) {
        int n = arr.size();
        unordered_map<int, int> cnt, total;
        int ans = 0, s = 0;
        for (int k = 0; k < n; ++k) {
            int val = arr[k];
            if (cnt.count(s ^ val)) {
                ans += cnt[s ^ val] * k - total[s ^ val];
            }
            ++cnt[s];
            total[s] += k;
            s ^= val;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int countTriplets(int[] arr) {
        int n = arr.length;
        Map<Integer, Integer> cnt = new HashMap<Integer, Integer>();
        Map<Integer, Integer> total = new HashMap<Integer, Integer>();
        int ans = 0, s = 0;
        for (int k = 0; k < n; ++k) {
            int val = arr[k];
            if (cnt.containsKey(s ^ val)) {
                ans += cnt.get(s ^ val) * k - total.get(s ^ val);
            }
            cnt.put(s, cnt.getOrDefault(s, 0) + 1);
            total.put(s, total.getOrDefault(s, 0) + k);
            s ^= val;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length;
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        Dictionary<int, int> total = new Dictionary<int, int>();
        int ans = 0, s = 0;
        for (int k = 0; k < n; ++k) {
            int val = arr[k];
            if (cnt.ContainsKey(s ^ val)) {
                ans += cnt[s ^ val] * k - total[s ^ val];
            }
            if (!cnt.ContainsKey(s)) {
                cnt.Add(s, 1);
            } else {
                ++cnt[s];
            }
            if (!total.ContainsKey(s)) {
                total.Add(s, k);
            } else {
                total[s] += k;
            }
            s ^= val;
        }
        return ans;
    }
}
```

```Go
func countTriplets(arr []int) (ans int) {
    cnt := map[int]int{}
    total := map[int]int{}
    s := 0
    for k, val := range arr {
        if m, has := cnt[s^val]; has {
            ans += m*k - total[s^val]
        }
        cnt[s]++
        total[s] += k
        s ^= val
    }
    return
}
```

```Python
class Solution:
    def countTriplets(self, arr: List[int]) -> int:
        cnt, total = Counter(), Counter()
        ans = s = 0

        for k, val in enumerate(arr):
            if (t := s ^ val) in cnt:
                ans += cnt[t] * k - total[t]
            cnt[s] += 1
            total[s] += k
            s = t

        return ans
```

```JavaScript
var countTriplets = function(arr) {
    const cnt = new Map(), total = new Map();
    let ans = 0, s = 0;

    for (const [k, val] of arr.entries()) {
        const t = s ^ val;
        if (cnt.has(t)) {
            ans += cnt.get(t) * k - total.get(t);
        }
        cnt.set(s, (cnt.get(s) || 0) + 1);
        total.set(s, (total.get(s) || 0) + k);
        s = t;
    }
    return ans;
};
```

```C
struct HashTable {
    int val, key;
    UT_hash_handle hh;
};

bool count(struct HashTable* hashTable, int x) {
    struct HashTable* tmp;
    HASH_FIND_INT(hashTable, &x, tmp);
    return tmp != NULL;
}

int getValue(struct HashTable* hashTable, int x) {
    struct HashTable* tmp;
    HASH_FIND_INT(hashTable, &x, tmp);
    return tmp == NULL ? 0 : tmp->val;
}

void addValue(struct HashTable** hashTable, int x, int y) {
    struct HashTable* tmp;
    HASH_FIND_INT(*hashTable, &x, tmp);
    if (tmp == NULL) {
        tmp = malloc(sizeof(struct HashTable));
        tmp->key = x;
        tmp->val = y;
        HASH_ADD_INT(*hashTable, key, tmp);
    } else {
        tmp->val += y;
    }
}

int countTriplets(int* arr, int arrSize) {
    int n = arrSize;
    struct HashTable *cnt = NULL, *total = NULL;
    int ans = 0, s = 0;
    for (int k = 0; k < n; ++k) {
        int val = arr[k];
        if (count(cnt, s ^ val)) {
            ans += getValue(cnt, s ^ val) * k - getValue(total, s ^ val);
        }
        addValue(&cnt, s, 1);
        addValue(&total, s, k);
        s ^= val;
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。
- 空间复杂度：$O(n)$。我们需要使用 $O(n)$ 的空间存储两个哈希表。
