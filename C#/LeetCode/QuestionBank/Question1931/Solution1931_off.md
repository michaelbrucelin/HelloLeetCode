### [用三种不同颜色为网格涂色](https://leetcode.cn/problems/painting-a-grid-with-three-different-colors/solutions/870045/yong-san-chong-bu-tong-yan-se-wei-wang-g-7nb2/)

#### 方法一：状态压缩动态规划

**提示 1**

要使得任意两个相邻的格子的颜色均不相同，我们需要保证：

- 同一行内任意两个相邻格子的颜色互不相同；
- 相邻的两行之间，同一列上的两个格子的颜色互不相同。

因此，我们可以考虑：

- 首先通过枚举的方法，找出所有对一行进行涂色的方案数；
- 然后通过动态规划的方法，计算出对整个 $m \times n$ 的方格进行涂色的方案数。

在本题中，$m$ 和 $n$ 的最大值分别是 $5$ 和 $1000$，我们需要将较小的 $m$ 看成行的长度，较大的 $n$ 看成列的长度，这样才可以对一行进行枚举。

**思路与算法**

我们首先枚举对一行进行涂色的方案数。

对于我们可以选择红绿蓝三种颜色，我们可以将它们看成 $0,1,2$。这样一来，一种涂色方案就对应着一个长度为 $m$ 的三进制数，其十进制的范围为 $[0,3^m)$。

因此，我们可以枚举 $[0,3^m)$ 范围内的所有整数，将其转换为长度为 $m$ 的三进制串，再判断其是否满足任意相邻的两个数位均不相同即可。

随后我们就可以使用动态规划来计算方案数了。我们用 $f[i][mask]$ 表示我们已经对 $0,1, \dots,i$ 行进行了涂色，并且第 $i$ 行的涂色方案对应的三进制表示为 $mask$ 的前提下的总方案数。在进行状态转移时，我们可以考虑第 $i-1$ 行的涂色方案 $mask′$：

$$f[i][mask] = \sum\limits_{mask 与 mask′同一数位上的数字均不相同} f[i-1][mask′]$$

只要 $mask′$ 与 $mask$ 同一数位上的数字均不相同，就说明这两行可以相邻，我们就可以进行状态转移。

最终的答案即为所有满足 $mask \in [0,3^m)$ 的 $f[n-1][mask]$ 之和。

**细节**

上述动态规划中的边界条件在于第 $0$ 行的涂色。当 $i=0$ 时，$f[i-1][..]$ 不是合法状态，无法进行转移，我们需要对它们进行特判：即如果 $mask$ 任意相邻的两个数位均不相同，那么 $f[0][mask]=1$，否则 $f[0][mask]=0$。

在其余情况下的状态转移时，对于给定的 $mask$，我们总是要找出所有满足要求的 $mask′$，因此我们不妨也把它们预处理出来，具体可以参考下方给出的代码。

最后需要注意的是，在状态转移方程中，$f[i][..]$ 只会从 $f[i-1][..]$ 转移而来，因此我们可以使用两个长度为 $3^m$ 的一维数组，交替地进行状态转移。

**代码**

```C++
class Solution {
private:
    static constexpr int mod = 1000000007;

public:
    int colorTheGrid(int m, int n) {
        // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
        // 键表示 mask，值表示 mask 的三进制串（以列表的形式存储）
        unordered_map<int, vector<int>> valid;

        // 在 [0, 3^m) 范围内枚举满足要求的 mask
        int mask_end = pow(3, m);
        for (int mask = 0; mask < mask_end; ++mask) {
            vector<int> color;
            int mm = mask;
            for (int i = 0; i < m; ++i) {
                color.push_back(mm % 3);
                mm /= 3;
            }
            bool check = true;
            for (int i = 0; i < m - 1; ++i) {
                if (color[i] == color[i + 1]) {
                    check = false;
                    break;
                }
            }
            if (check) {
                valid[mask] = move(color);
            }
        }

        // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
        unordered_map<int, vector<int>> adjacent;
        for (const auto& [mask1, color1]: valid) {
            for (const auto& [mask2, color2]: valid) {
                bool check = true;
                for (int i = 0; i < m; ++i) {
                    if (color1[i] == color2[i]) {
                        check = false;
                        break;
                    }
                }
                if (check) {
                    adjacent[mask1].push_back(mask2);
                }
            }
        }

        vector<int> f(mask_end);
        for (const auto& [mask, _]: valid) {
            f[mask] = 1;
        }
        for (int i = 1; i < n; ++i) {
            vector<int> g(mask_end);
            for (const auto& [mask2, _]: valid) {
                for (int mask1: adjacent[mask2]) {
                    g[mask2] += f[mask1];
                    if (g[mask2] >= mod) {
                        g[mask2] -= mod;
                    }
                }
            }
            f = move(g);
        }

        int ans = 0;
        for (int num: f) {
            ans += num;
            if (ans >= mod) {
                ans -= mod;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def colorTheGrid(self, m: int, n: int) -> int:
        mod = 10**9 + 7
        # 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
        # 键表示 mask，值表示 mask 的三进制串（以列表的形式存储）
        valid = dict()
        
        # 在 [0, 3^m) 范围内枚举满足要求的 mask
        for mask in range(3**m):
            color = list()
            mm = mask
            for i in range(m):
                color.append(mm % 3)
                mm //= 3
            if any(color[i] == color[i + 1] for i in range(m - 1)):
                continue
            valid[mask] = color
        
        # 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
        adjacent = defaultdict(list)
        for mask1, color1 in valid.items():
            for mask2, color2 in valid.items():
                if not any(x == y for x, y in zip(color1, color2)):
                    adjacent[mask1].append(mask2)
        
        f = [int(mask in valid) for mask in range(3**m)]
        for i in range(1, n):
            g = [0] * (3**m)
            for mask2 in valid.keys():
                for mask1 in adjacent[mask2]:
                    g[mask2] += f[mask1]
                    if g[mask2] >= mod:
                        g[mask2] -= mod
            f = g
            
        return sum(f) % mod
```

```Java
class Solution {
    static final int mod = 1000000007;

    public int colorTheGrid(int m, int n) {
        // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
        Map<Integer, List<Integer>> valid = new HashMap<>();
        // 在 [0, 3^m) 范围内枚举满足要求的 mask
        int maskEnd = (int) Math.pow(3, m);
        for (int mask = 0; mask < maskEnd; ++mask) {
            List<Integer> color = new ArrayList<>();
            int mm = mask;
            for (int i = 0; i < m; ++i) {
                color.add(mm % 3);
                mm /= 3;
            }
            boolean check = true;
            for (int i = 0; i < m - 1; ++i) {
                if (color.get(i).equals(color.get(i + 1))) {
                    check = false;
                    break;
                }
            }
            if (check) {
                valid.put(mask, color);
            }
        }

        // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
        Map<Integer, List<Integer>> adjacent = new HashMap<>();
        for (int mask1 : valid.keySet()) {
            for (int mask2 : valid.keySet()) {
                boolean check = true;
                for (int i = 0; i < m; ++i) {
                    if (valid.get(mask1).get(i).equals(valid.get(mask2).get(i))) {
                        check = false;
                        break;
                    }
                }
                if (check) {
                    adjacent.computeIfAbsent(mask1, k -> new ArrayList<>()).add(mask2);
                }
            }
        }

        Map<Integer, Integer> f = new HashMap<>();
        for (int mask : valid.keySet()) {
            f.put(mask, 1);
        }
        for (int i = 1; i < n; ++i) {
            Map<Integer, Integer> g = new HashMap<>();
            for (int mask2 : valid.keySet()) {
                for (int mask1 : adjacent.getOrDefault(mask2, new ArrayList<>())) {
                    g.put(mask2, (g.getOrDefault(mask2, 0) + f.getOrDefault(mask1, 0)) % mod);
                }
            }
            f = g;
        }

        int ans = 0;
        for (int num : f.values()) {
            ans = (ans + num) % mod;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private const int mod = 1000000007;

    public int ColorTheGrid(int m, int n) {
        // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
        var valid = new Dictionary<int, List<int>>();
        // 在 [0, 3^m) 范围内枚举满足要求的 mask
        int maskEnd = (int)Math.Pow(3, m);
        for (int mask = 0; mask < maskEnd; ++mask) {
            var color = new List<int>();
            int mm = mask;
            for (int i = 0; i < m; ++i) {
                color.Add(mm % 3);
                mm /= 3;
            }
            bool check = true;
            for (int i = 0; i < m - 1; ++i) {
                if (color[i] == color[i + 1]) {
                    check = false;
                    break;
                }
            }
            if (check) {
                valid[mask] = color;
            }
        }

        // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
        var adjacent = new Dictionary<int, List<int>>();
        foreach (var mask1 in valid.Keys) {
            foreach (var mask2 in valid.Keys) {
                bool check = true;
                for (int i = 0; i < m; ++i) {
                    if (valid[mask1][i] == valid[mask2][i]) {
                        check = false;
                        break;
                    }
                }
                if (check) {
                    if (!adjacent.ContainsKey(mask1)) {
                        adjacent[mask1] = new List<int>();
                    }
                    adjacent[mask1].Add(mask2);
                }
            }
        }

        var f = new Dictionary<int, int>();
        foreach (var mask in valid.Keys) {
            f[mask] = 1;
        }
        for (int i = 1; i < n; ++i) {
            var g = new Dictionary<int, int>();
            foreach (var mask2 in valid.Keys) {
                if (adjacent.ContainsKey(mask2)) {
                    foreach (var mask1 in adjacent[mask2]) {
                        if (!g.ContainsKey(mask2)) {
                            g[mask2] = 0;
                        }
                        g[mask2] = (g[mask2] + f[mask1]) % mod;
                    }
                }
            }
            f = g;
        }

        int ans = 0;
        foreach (var num in f.Values) {
            ans = (ans + num) % mod;
        }
        return ans;
    }
}
```

```Go
const mod = 1000000007

func colorTheGrid(m int, n int) int {
    // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
    valid := make(map[int][]int)

    // 在 [0, 3^m) 范围内枚举满足要求的 mask
    maskEnd := int(math.Pow(3, float64(m)))
    for mask := 0; mask < maskEnd; mask++ {
        color := make([]int, m)
        mm := mask
        for i := 0; i < m; i++ {
            color[i] = mm % 3
            mm /= 3
        }
        check := true
        for i := 0; i < m-1; i++ {
            if color[i] == color[i+1] {
                check = false
                break
            }
        }
        if check {
            valid[mask] = color
        }
    }

    // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
    adjacent := make(map[int][]int)
    for mask1 := range valid {
        for mask2 := range valid {
            check := true
            for i := 0; i < m; i++ {
                if valid[mask1][i] == valid[mask2][i] {
                    check = false
                    break
                }
            }
            if check {
                adjacent[mask1] = append(adjacent[mask1], mask2)
            }
        }
    }

    f := make(map[int]int)
    for mask := range valid {
        f[mask] = 1
    }
    for i := 1; i < n; i++ {
        g := make(map[int]int)
        for mask2 := range valid {
            for _, mask1 := range adjacent[mask2] {
                g[mask2] = (g[mask2] + f[mask1]) % mod
            }
        }
        f = g
    }

    ans := 0
    for _, num := range f {
        ans = (ans + num) % mod
    }
    return ans
}
```

```C
#define MOD 1000000007

struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode*)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

typedef struct {
    int key;
    struct ListNode *val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    struct ListNode *p = createListNode(val);
    if (!pEntry) {
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->val = p;
        HASH_ADD_INT(*obj, key, pEntry);
    } else {
        p->next = pEntry->val;
        pEntry->val = p;
    }
    return true;
}

bool hashSetItem(HashItem **obj, int key, struct ListNode *list) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->val = list;
        HASH_ADD_INT(*obj, key, pEntry);
    } else {
        freeList(pEntry->val);
        pEntry->val = list;
    }
    return true;
}

struct ListNode* hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr); 
        freeList(curr->val); 
        free(curr);
    }
}

// 主函数
int colorTheGrid(int m, int n) {
    // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
    // 键表示 mask，值表示 mask 的三进制串（以列表的形式存储）
    HashItem *valid = NULL;
    // 在 [0, 3^m) 范围内枚举满足要求的 mask
    int mask_end = pow(3, m);
    for (int mask = 0; mask < mask_end; ++mask) {
        int mm = mask;
        int color[m];
        for (int i = 0; i < m; ++i) {
            color[i] = mm % 3;
            mm /= 3;
        }
        bool check = true;
        for (int i = 0; i < m - 1; ++i) {
            if (color[i] == color[i + 1]) {
                check = false;
                break;
            }
        }
        if (check) {
            for (int i = 0; i < m; i++) {
                hashAddItem(&valid, mask, color[i]);
            }
        }
    }

    // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
    HashItem *adjacent = NULL;
    for (HashItem *pEntry1 = valid; pEntry1; pEntry1 = pEntry1->hh.next) {
        int mask1 = pEntry1->key;
        for (HashItem *pEntry2 = valid; pEntry2; pEntry2 = pEntry2->hh.next) {
            int mask2 = pEntry2->key;
            bool check = true;
            for (struct ListNode *p1 = pEntry1->val, *p2 = pEntry2->val; p1 && p2; p1 = p1->next, p2 = p2->next) {
                if (p1->val == p2->val) {
                    check = false;
                    break;
                }
            }
            if (check) {
                hashAddItem(&adjacent, mask1, mask2);
            }
        }
    }

    int f[mask_end];
    memset(f, 0, sizeof(f));
    for (HashItem *pEntry = valid; pEntry; pEntry = pEntry->hh.next) {
        int mask = pEntry->key;
        f[mask] = 1;
    }
    for (int i = 1; i < n; ++i) {
        int g[mask_end];
        memset(g, 0, sizeof(g));
        for (HashItem *pEntry1 = valid; pEntry1; pEntry1 = pEntry1->hh.next) {
            int mask2 = pEntry1->key;
            for (struct ListNode *p = hashGetItem(&adjacent, mask2); p != NULL; p = p->next) {
                int mask1 = p->val;
                g[mask2] += f[mask1];
                if (g[mask2] >= MOD) {
                    g[mask2] -= MOD;
                }
            }
        }
        memcpy(f, g, sizeof(f));
    }

    int ans = 0;
    for (int i = 0; i < mask_end; i++) {
        ans += f[i];
        if (ans >= MOD) {
            ans -= MOD;
        }
    }
    hashFree(&valid);
    hashFree(&adjacent);
    return ans;
}
```

```JavaScript
var colorTheGrid = function(m, n) {
    const mod = 1000000007;
    // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
    const valid = new Map();
    // 在 [0, 3^m) 范围内枚举满足要求的 mask
    const maskEnd = Math.pow(3, m);
    for (let mask = 0; mask < maskEnd; ++mask) {
        const color = [];
        let mm = mask;
        for (let i = 0; i < m; ++i) {
            color.push(mm % 3);
            mm = Math.floor(mm / 3);
        }
        let check = true;
        for (let i = 0; i < m - 1; ++i) {
            if (color[i] === color[i + 1]) {
                check = false;
                break;
            }
        }
        if (check) {
            valid.set(mask, color);
        }
    }

    // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
    const adjacent = new Map();
    for (const [mask1, color1] of valid.entries()) {
        for (const [mask2, color2] of valid.entries()) {
            let check = true;
            for (let i = 0; i < m; ++i) {
                if (color1[i] === color2[i]) {
                    check = false;
                    break;
                }
            }
            if (check) {
                if (!adjacent.has(mask1)) {
                    adjacent.set(mask1, []);
                }
                adjacent.get(mask1).push(mask2);
            }
        }
    }

    let f = new Map();
    for (const [mask, _] of valid.entries()) {
        f.set(mask, 1);
    }
    for (let i = 1; i < n; ++i) {
        const g = new Map();
        for (const [mask2, _] of valid.entries()) {
            for (const mask1 of adjacent.get(mask2) || []) {
                g.set(mask2, ((g.get(mask2) || 0) + f.get(mask1)) % mod);
            }
        }
        f = g;
    }

    let ans = 0;
    for (const num of f.values()) {
        ans = (ans + num) % mod;
    }
    return ans;
}
```

```TypeScript
function colorTheGrid(m: number, n: number): number {
    const mod = 1000000007;
    // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
    const valid = new Map<number, number[]>();

    // 在 [0, 3^m) 范围内枚举满足要求的 mask
    const maskEnd = Math.pow(3, m);
    for (let mask = 0; mask < maskEnd; ++mask) {
        const color: number[] = [];
        let mm = mask;
        for (let i = 0; i < m; ++i) {
            color.push(mm % 3);
            mm = Math.floor(mm / 3);
        }
        let check = true;
        for (let i = 0; i < m - 1; ++i) {
            if (color[i] === color[i + 1]) {
                check = false;
                break;
            }
        }
        if (check) {
            valid.set(mask, color);
        }
    }

    // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
    const adjacent = new Map<number, number[]>();
    for (const [mask1, color1] of valid.entries()) {
        for (const [mask2, color2] of valid.entries()) {
            let check = true;
            for (let i = 0; i < m; ++i) {
                if (color1[i] === color2[i]) {
                    check = false;
                    break;
                }
            }
            if (check) {
                if (!adjacent.has(mask1)) {
                    adjacent.set(mask1, []);
                }
                adjacent.get(mask1)!.push(mask2);
            }
        }
    }

    let f = new Map<number, number>();
    for (const [mask, _] of valid.entries()) {
        f.set(mask, 1);
    }
    for (let i = 1; i < n; ++i) {
        const g = new Map<number, number>();
        for (const [mask2, _] of valid.entries()) {
            for (const mask1 of adjacent.get(mask2) || []) {
                g.set(mask2, ((g.get(mask2) || 0) + f.get(mask1)!) % mod);
            }
        }
        f = g;
    }

    let ans = 0;
    for (const num of f.values()) {
        ans = (ans + num) % mod;
    }
    return ans;
}
```

```Rust
use std::collections::HashMap;

const MOD: i32 = 1_000_000_007;

impl Solution {
    pub fn color_the_grid(m: i32, n: i32) -> i32 {
        let m = m as usize;
        let n = n as usize;
        // 哈希映射 valid 存储所有满足要求的对一行进行涂色的方案
        let mut valid = HashMap::new();
        // 在 [0, 3^m) 范围内枚举满足要求的 mask
        let mask_end = 3i32.pow(m as u32);
        for mask in 0..mask_end {
            let mut color = Vec::new();
            let mut mm = mask;
            for _ in 0..m {
                color.push(mm % 3);
                mm /= 3;
            }
            let mut check = true;
            for i in 0..m - 1 {
                if color[i] == color[i + 1] {
                    check = false;
                    break;
                }
            }
            if check {
                valid.insert(mask, color);
            }
        }

        // 预处理所有的 (mask1, mask2) 二元组，满足 mask1 和 mask2 作为相邻行时，同一列上两个格子的颜色不同
        let mut adjacent = HashMap::new();
        for (&mask1, color1) in &valid {
            for (&mask2, color2) in &valid {
                let mut check = true;
                for i in 0..m {
                    if color1[i] == color2[i] {
                        check = false;
                        break;
                    }
                }
                if check {
                    adjacent.entry(mask1).or_insert(Vec::new()).push(mask2);
                }
            }
        }

        let mut f = HashMap::new();
        for &mask in valid.keys() {
            f.insert(mask, 1);
        }
        for _ in 1..n {
            let mut g = HashMap::new();
            for &mask2 in valid.keys() {
                let mut total = 0;
                if let Some(list) = adjacent.get(&mask2) {
                    for &mask1 in list {
                        total = (total + f.get(&mask1).unwrap_or(&0)) % MOD;
                    }
                }
                g.insert(mask2, total);
            }
            f = g;
        }

        let mut ans = 0;
        for &num in f.values() {
            ans = (ans + num) % MOD;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(3^{2m} \cdot n)$。
  - 预处理 $mask$ 的时间复杂度为 $O(m \cdot 3^m)$；
  - 预处理 $(mask,mask′)$ 二元组的时间复杂度为 $O(3^{2m})$；
  - 动态规划的时间复杂度为 $O(3^{2m} \cdot n)$，其在渐近意义下大于前两者。
- 空间复杂度：$O(3^{2m})$。
  - 存储 $mask$ 的哈希映射需要的空间为 $O(m \cdot 3^m)$；
  - 存储 $(mask,mask′)$ 二元组需要的空间为 $O(3^{2m})$，在渐进意义下大于其余两者；
  - 动态规划存储状态需要的空间为 $O(3^m)$。

不过需要注意的是，在实际的情况下，当 $m=5$ 时，满足要求的 $mask$ 仅有 $48$ 个，远小于 $3^m=324$；满足要求的 $(mask,mask′)$ 二元组仅有 $486$ 对，远小于 $3^{2m}=59049$。因此该算法的实际运行时间会较快。
