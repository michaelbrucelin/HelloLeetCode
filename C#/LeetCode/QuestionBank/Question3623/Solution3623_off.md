### [统计梯形的数目 I](https://leetcode.cn/problems/count-number-of-trapezoids-i/solutions/3844282/tong-ji-ti-xing-de-shu-mu-i-by-leetcode-ziwtk/)

#### 方法一：哈希表 + 几何数学

**思路及解法**

题目要求我们找出水平梯形的数量，我们可以统计每个不同高度即不同 $y$ 值对应的点有多少个，假设高度为 $y$ 的点有 $p_y$ 个，那么这个高度上的点能够组成的边的条数为 $\dfrac{p_y(p_y-1)}{2}$ 条。

分别在两个不同高度上选择一条边即可组成一个水平梯形，统计其个数即可。

**代码**

```C++
class Solution {
public:
    int countTrapezoids(vector<vector<int>>& points) {
        unordered_map<int, int> pointNum;
        const int mod = 1e9 + 7;
        long long ans = 0, sum = 0;
        for (auto& point : points) {
            pointNum[point[1]]++;
        }
        for (auto& [_, pNum] : pointNum) {
            long long edge = (long long)pNum * (pNum - 1) / 2;
            ans += edge * sum;
            sum += edge;
        }
        return ans % mod;
    }
};
```

```Java
class Solution {
    public int countTrapezoids(int[][] points) {
        Map<Integer, Integer> pointNum = new HashMap<>();
        final int mod = 1000000007;
        long ans = 0, sum = 0;
        for (int[] point : points) {
            pointNum.put(point[1], pointNum.getOrDefault(point[1], 0) + 1);
        }
        for (int pNum : pointNum.values()) {
            long edge = (long) pNum * (pNum - 1) / 2;
            ans = (ans + edge * sum) % mod;
            sum = (sum + edge) % mod;
        }
        return (int) ans;
    }
}
```

```Python
class Solution:
    def countTrapezoids(self, points: List[List[int]]) -> int:
        point_num = defaultdict(int)
        mod = 10**9 + 7
        ans, total_sum = 0, 0
        for point in points:
            point_num[point[1]] += 1
        for p_num in point_num.values():
            edge = p_num * (p_num - 1) // 2
            ans = (ans + edge * total_sum) % mod
            total_sum = (total_sum + edge) % mod
        return ans
```

```CSharp
public class Solution {
    public int CountTrapezoids(int[][] points) {
        Dictionary<int, int> pointNum = new Dictionary<int, int>();
        const int mod = 1000000007;
        long ans = 0, sum = 0;
        
        foreach (int[] point in points) {
            int y = point[1];
            if (pointNum.ContainsKey(y)) {
                pointNum[y]++;
            } else {
                pointNum[y] = 1;
            }
        }
        
        foreach (int pNum in pointNum.Values) {
            long edge = (long)pNum * (pNum - 1) / 2;
            ans = (ans + edge * sum) % mod;
            sum = (sum + edge) % mod;
        }
        
        return (int)ans;
    }
}
```

```Go
func countTrapezoids(points [][]int) int {
    pointNum := make(map[int]int)
    mod := 1000000007
    ans, sum := 0, 0
    
    for _, point := range points {
        y := point[1]
        pointNum[y]++
    }
    
    for _, pNum := range pointNum {
        edge := pNum * (pNum - 1) / 2
        ans = (ans + edge * sum) % mod
        sum = (sum + edge) % mod
    }
    
    return ans
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

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
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

int countTrapezoids(int** points, int pointsSize, int* pointsColSize) {
    HashItem *pointNum = NULL;
    const int mod = 1e9 + 7;
    long long ans = 0, sum = 0;
    for (int i = 0; i < pointsSize; i++) {
        hashSetItem(&pointNum, points[i][1], hashGetItem(&pointNum, points[i][1], 0) + 1);
    }
    for (HashItem *pEntry = pointNum; pEntry; pEntry = pEntry->hh.next) {
        int pNum = pEntry->val;
        long long edge = (long long)pNum * (pNum - 1) / 2;
        ans += edge * sum;
        sum += edge;
    }
    hashFree(&pointNum);
    return ans % mod;
}
```

```JavaScript
var countTrapezoids = function(points) {
    const pointNum = new Map();
    const mod = 1000000007n;
    let ans = 0n, sum = 0n;
    
    for (const point of points) {
        const y = point[1];
        pointNum.set(y, (pointNum.get(y) || 0) + 1);
    }
    
    for (const pNum of pointNum.values()) {
        const edge = BigInt(pNum) * BigInt(pNum - 1) / 2n;
        ans = (ans + edge * sum) % mod;
        sum = (sum + edge) % mod;
    }
    
    return Number(ans);
};
```

```TypeScript
function countTrapezoids(points: number[][]): number {
    const pointNum: Map<number, number> = new Map();
    const mod: bigint = 1000000007n;
    let ans: bigint = 0n, sum: bigint = 0n;
    
    for (const point of points) {
        const y: number = point[1];
        pointNum.set(y, (pointNum.get(y) || 0) + 1);
    }
    
    for (const pNum of pointNum.values()) {
        const edge: bigint = BigInt(pNum) * BigInt(pNum - 1) / 2n;
        ans = (ans + edge * sum) % mod;
        sum = (sum + edge) % mod;
    }
    
    return Number(ans);
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn count_trapezoids(points: Vec<Vec<i32>>) -> i32 {
        let mut point_num: HashMap<i32, i32> = HashMap::new();
        let mod_val: i64 = 1000000007;
        let mut ans: i64 = 0;
        let mut sum: i64 = 0;
        
        for point in points {
            let y = point[1];
            *point_num.entry(y).or_insert(0) += 1;
        }
        
        for &p_num in point_num.values() {
            let edge = p_num as i64 * (p_num as i64 - 1) / 2;
            ans = (ans + edge * sum) % mod_val;
            sum = (sum + edge) % mod_val;
        }
        
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $points$ 的长度。
- 空间复杂度：$O(n)$。
