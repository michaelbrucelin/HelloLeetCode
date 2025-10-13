### [施咒的最大总伤害](https://leetcode.cn/problems/maximum-total-damage-with-spell-casting/solutions/3801010/shi-zhou-de-zui-da-zong-shang-hai-by-lee-e2kq/)

#### 方法一：动态规划

**思路与算法**

在选择一种咒语后，就不能使用伤害绝对值相差 $1$ 或 $2$ 的咒语。由于答案只与所选的咒语集合相关，而与顺序无关，我们可以按从小到大的顺序进行选择，并将相同伤害的法术看成同一种。

设伤害值为 $power_i$ 的咒语数量为 $count_i$。令 $f(i)$ 表示从第 $0$ 到 $i$ 种咒语中选择，并且最后选择第 $i$ 种咒语的最大总伤害，则有：

$$f(i)=\max\limits_{power_j<power_i-2}f(j)+power_i\times count_i$$

由于我们按伤害递增顺序遍历咒语，可以在遍历的过程中使用一个单调指针维护 $\max\limits_{power_j<power_i-2}f(j)$，即用于转移的最大值。最后答案为 $f(i)$ 中的最大值。

**实现**

```C++
class Solution {
public:
    long long maximumTotalDamage(vector<int>& power) {
        map<int, int> count;
        for (int p : power){
            count[p]++;
        }
        vector<pair<int, int>> vec={{-1e9,0}};
        for (auto& p : count){
            vec.push_back(p);
        }
        int n = vec.size();
        vector<long long> f(n, 0);
        long long mx = 0;
        for (int i = 1, j = 1; i < n; i++) {
            while (j < i && vec[j].first < vec[i].first - 2) {
                mx = max(mx, f[j]);
                j++;
            }
            f[i] = mx + 1LL * vec[i].first * vec[i].second;
        }
        long long ans = 0;
        for (int i = 1; i < n; i++){
            ans = max(ans, f[i]);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maximumTotalDamage(self, power):
        count = Counter(power)
        vec = [(-10**9, 0)]
        for k in sorted(count.keys()):
            vec.append((k, count[k]))
        n = len(vec)
        f = [0] * n
        mx = 0
        j = 1
        for i in range(1, n):
            while j < i and vec[j][0] < vec[i][0] - 2:
                mx = max(mx, f[j])
                j += 1
            f[i] = mx + vec[i][0] * vec[i][1]
        return max(f)

```

```Java
class Solution {
    public long maximumTotalDamage(int[] power) {
        TreeMap<Integer,Integer> count = new TreeMap<>();
        for (int p : power) {
            count.put(p, count.getOrDefault(p, 0) + 1);
        }
        List<int[]> vec = new ArrayList<>();
        vec.add(new int[]{-1000000000,0});
        for (Map.Entry<Integer,Integer> e : count.entrySet()) {
            vec.add(new int[]{e.getKey(), e.getValue()});
        }
        int n = vec.size();
        long[] f = new long[n];
        long mx = 0, ans = 0;
        int j = 1;
        for (int i = 1; i < n; i++) {
            while (j < i && vec.get(j)[0] < vec.get(i)[0] - 2) {
                mx = Math.max(mx, f[j]);
                j++;
            }
            f[i] = mx + 1L * vec.get(i)[0] * vec.get(i)[1];
            ans = Math.max(ans, f[i]);
        }
        return ans;
    }
}
```

```C
int cmp(const void* a, const void* b) {
    int x = *(const int*)a;
    int y = *(const int*)b;
    return (x > y) - (x < y);
}

long long maximumTotalDamage(int* power, int powerSize) {
    int* keys = (int*)malloc(sizeof(int) * powerSize);
    int* vals = (int*)malloc(sizeof(int) * powerSize);
    int m = 0;

    qsort(power, powerSize, sizeof(int), cmp);

    for (int i = 0; i < powerSize; i++) {
        if (m == 0 || power[i] != keys[m - 1]) {
            keys[m] = power[i];
            vals[m] = 1;
            m++;
        } else {
            vals[m - 1]++;
        }
    }

    int* vk = (int*)malloc(sizeof(int) * (m + 1));
    int* vv = (int*)malloc(sizeof(int) * (m + 1));
    vk[0] = -1000000000;
    vv[0] = 0;
    for (int i = 0; i < m; i++) {
        vk[i + 1] = keys[i];
        vv[i + 1] = vals[i];
    }
    int n = m + 1;

    long long* f = (long long*)calloc(n, sizeof(long long));
    long long mx = 0, ans = 0;
    int j = 1;
    for (int i = 1; i < n; i++) {
        while (j < i && vk[j] < vk[i] - 2) {
            if (f[j] > mx){
                mx = f[j];
            }
            j++;
        }
        f[i] = mx + 1LL * vk[i] * vv[i];
        if (f[i] > ans){
            ans = f[i];
        }
    }

    free(keys);
    free(vals);
    free(vk);
    free(vv);
    free(f);
    return ans;
}
```

```Go
func maximumTotalDamage(power []int) int64 {
    count := map[int]int{}
    for _, p := range power {
        count[p]++
    }
    keys := make([]int, 0, len(count))
    for k := range count {
        keys = append(keys, k)
    }
    sort.Ints(keys)
    vec := [][2]int{{-1000000000, 0}}
    for _, k := range keys {
        vec = append(vec, [2]int{k, count[k]})
    }
    n := len(vec)
    f := make([]int64, n)
    var mx int64
    var ans int64
    j := 1
    for i := 1; i < n; i++ {
        for j < i && vec[j][0] < vec[i][0]-2 {
            if f[j] > mx {
                mx = f[j]
            }
            j++
        }
        f[i] = mx + int64(vec[i][0])*int64(vec[i][1])
        if f[i] > ans {
            ans = f[i]
        }
    }
    return ans
}
```

```CSharp
public class Solution {
    public long MaximumTotalDamage(int[] power) {
        var count = new SortedDictionary<int,int>();
        foreach (var p in power) {
            if (!count.ContainsKey(p)) {
                count[p]=0;
            }
            count[p]++;
        }
        var vec = new List<(int,int)>();
        vec.Add((-1000000000,0));
        foreach (var kv in count) {
            vec.Add((kv.Key, kv.Value));
        }
        int n = vec.Count;
        long[] f = new long[n];
        long mx=0, ans=0;
        int j=1;
        for (int i=1;i<n;i++) {
            while (j<i && vec[j].Item1<vec[i].Item1-2) {
                mx=Math.Max(mx,f[j]);
                j++;
            }
            f[i]=mx+(long)vec[i].Item1*vec[i].Item2;
            ans=Math.Max(ans,f[i]);
        }
        return ans;
    }
}
```

```JavaScript
var maximumTotalDamage = function (power) {
    let count = new Map();
    for (let p of power) {
        count.set(p, (count.get(p) || 0) + 1);
    }
    let vec = [[-1000000000, 0]];
    let keys = Array.from(count.keys()).sort((a, b) => a - b);
    for (let k of keys) {
        vec.push([k, count.get(k)]);
    }
    let n = vec.length;
    let f = Array(n).fill(0);
    let mx = 0, ans = 0, j = 1;
    for (let i = 1; i < n; i++) {
        while (j < i && vec[j][0] < vec[i][0] - 2) {
            mx = Math.max(mx, f[j]);
            j++;
        }
        f[i] = mx + vec[i][0] * vec[i][1];
        ans = Math.max(ans, f[i]);
    }
    return ans;
};
```

```TypeScript
function maximumTotalDamage(power: number[]): number {
    let count = new Map<number, number>();
    for (let p of power) {
        count.set(p, (count.get(p) || 0) + 1);
    }
    let vec: [number, number][] = [[-1000000000, 0]];
    let keys = Array.from(count.keys()).sort((a, b) => a - b);
    for (let k of keys) {
        vec.push([k, count.get(k)!]);
    }
    let n = vec.length;
    let f = new Array<number>(n).fill(0);
    let mx = 0, ans = 0, j = 1;
    for (let i = 1; i < n; i++) {
        while (j < i && vec[j][0] < vec[i][0] - 2) {
            mx = Math.max(mx, f[j]);
            j++;
        }
        f[i] = mx + vec[i][0] * vec[i][1];
        ans = Math.max(ans, f[i]);
    }
    return ans;
};
```

```Rust
use std::collections::BTreeMap;
impl Solution {
    pub fn maximum_total_damage(power: Vec<i32>) -> i64 {
        let mut count = BTreeMap::new();
        for p in power {
            *count.entry(p).or_insert(0)+=1;
        }
        let mut vec = vec![(-1_000_000_000i32,0i32)];
        for (k,v) in count {
            vec.push((k,v));
        }
        let n=vec.len();
        let mut f=vec![0i64;n];
        let mut mx=0i64;
        let mut ans=0i64;
        let mut j=1usize;
        for i in 1..n {
            while j<i && vec[j].0<vec[i].0-2 {
                if f[j]>mx {
                    mx=f[j];
                }
                j+=1;
            }
            f[i]=mx+vec[i].0 as i64 * vec[i].1 as i64;
            if f[i]>ans {
                ans=f[i];
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $power$ 的长度。排序需要 $O(n\log n)$，动态规划需要 $O(n)$。
- 空间复杂度：$O(n)$。哈希表和动态规划所需的数组都需要 $O(n)$。
