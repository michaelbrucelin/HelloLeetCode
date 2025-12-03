### [统计梯形的数目 II](https://leetcode.cn/problems/count-number-of-trapezoids-ii/solutions/3844283/tong-ji-ti-xing-de-shu-mu-ii-by-leetcode-6uwd/)

#### 方法一：哈希表 + 几何数学

**思路及解法**

本题与「[3623\. 统计梯形的数目 I](https://leetcode.cn/problems/count-number-of-trapezoids-i/description/)」 的区别在于对线段的斜率没有限制了，并且不能统计平行四边形的数量。

我们可以沿用「[3623\. 统计梯形的数目 I](https://leetcode.cn/problems/count-number-of-trapezoids-i/description/)」 的思路，分别统计不同斜率对应的梯形的数量。但是在只知道斜率的情况下，无法判断两条线段是否共线，因此需要引入截距来区分不共线的线段，这里的截距可以类比为 「[3623\. 统计梯形的数目 I](https://leetcode.cn/problems/count-number-of-trapezoids-i/description/)」 中的高度 $y$ 值。

平行四边形可以通过中点相同的不同斜率的两条线段来确定，因此我们可以统计相同中点不同斜率的线段的数量来统计平行四边形的数量。

由于使用哈希表套 $map$ 的形式会导致创建大量无用的 $map$ 对象，这样会导致时间复杂度过高，因此我们使用哈希表套 $vector$ 的形式来统计相同斜率线段的各种截距以及相同中点线段的各种斜率。减轻了创建 $map$ 对象的开销。在计算梯形和平行四边形的过程中再对相同斜率线段的不同截距以及相同终点线段的不同斜率创建 $map$ 对象，统计每种截距、中点中线段的个数，这样可以提高运行速度。

$slopeToIntercept$ 代表相同斜率线段的各种截距，$midToSlope$ 代表相同中点线段的各种斜率。

**代码**

```C++
class Solution {
public:
    int countTrapezoids(vector<vector<int>>& points) {
        int n = points.size();
        int inf = 1e9 + 7;
        unordered_map<float, vector<float>> slopeToIntercept;
        unordered_map<int, vector<float>> midToSlope;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            int x1 = points[i][0];
            int y1 = points[i][1];
            for (int j = i + 1; j < n; j++) {
                int x2 = points[j][0];
                int y2 = points[j][1];
                int dx = x1 - x2;
                int dy = y1 - y2;
                float k, b;
                if (x2 == x1) {
                    k = inf;
                    b = x1;
                } else {
                    k = (float)(y2 - y1) / (x2 - x1);
                    b = (float)(y1 * dx - x1 * dy) / dx;
                }
                int mid = (x1 + x2) * 10000 + (y1 + y2);
                slopeToIntercept[k].push_back(b);
                midToSlope[mid].push_back(k);
            }
        }
        for (auto& [_, sti] : slopeToIntercept) {
            if (sti.size() == 1) {
                continue;
            }
            map<float, int> cnt;
            for (float b : sti) {
                cnt[b]++;
            }
            int sum = 0;
            for (auto& [_, count] : cnt) {
                ans += sum * count;
                sum += count;
            }
        }
        for (auto& [_, mts] : midToSlope) {
            if (mts.size() == 1) {
                continue;
            }
            map<float, int> cnt;
            for (float k : mts) {
                cnt[k]++;
            }
            int sum = 0;
            for (auto& [_, count] : cnt) {
                ans -= sum * count;
                sum += count;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countTrapezoids(self, points: List[List[int]]) -> int:
        n = len(points)
        inf = 10**9 + 7
        slope_to_intercept = defaultdict(list)
        mid_to_slope = defaultdict(list)
        ans = 0
        
        for i in range(n):
            x1, y1 = points[i]
            for j in range(i + 1, n):
                x2, y2 = points[j]
                dx = x1 - x2
                dy = y1 - y2
                
                if x2 == x1:
                    k = inf
                    b = x1
                else:
                    k = (y2 - y1) / (x2 - x1)
                    b = (y1 * dx - x1 * dy) / dx
                
                mid = (x1 + x2) * 10000 + (y1 + y2)
                slope_to_intercept[k].append(b)
                mid_to_slope[mid].append(k)

        for sti in slope_to_intercept.values():
            if len(sti) == 1:
                continue
            
            cnt = defaultdict(int)
            for b_val in sti:
                cnt[b_val] += 1
            
            total_sum = 0
            for count in cnt.values():
                ans += total_sum * count
                total_sum += count

        for mts in mid_to_slope.values():
            if len(mts) == 1:
                continue
            
            cnt = defaultdict(int)
            for k_val in mts:
                cnt[k_val] += 1
            
            total_sum = 0
            for count in cnt.values():
                ans -= total_sum * count
                total_sum += count
        
        return ans
```

```Java
class Solution {
    public int countTrapezoids(int[][] points) {
        int n = points.length;
        double inf = 1e9 + 7;
        Map<Double, List<Double>> slopeToIntercept = new HashMap<>();
        Map<Integer, List<Double>> midToSlope = new HashMap<>();
        int ans = 0;
        
        for (int i = 0; i < n; i++) {
            int x1 = points[i][0];
            int y1 = points[i][1];
            for (int j = i + 1; j < n; j++) {
                int x2 = points[j][0];
                int y2 = points[j][1];
                int dx = x1 - x2;
                int dy = y1 - y2;
                double k, b;
                
                if (x2 == x1) {
                    k = inf;
                    b = x1;
                } else {
                    k = 1.0 * (y2 - y1) / (x2 - x1);
                    b = 1.0 * (y1 * dx - x1 * dy) / dx;
                }
                if (k == -0.0) {
                    k = 0.0;
                }
                if (b == -0.0) {
                    b = 0.0;
                }
                int mid = (x1 + x2) * 10000 + (y1 + y2);
                slopeToIntercept.computeIfAbsent(k, key -> new ArrayList<>()).add(b);
                midToSlope.computeIfAbsent(mid, key -> new ArrayList<>()).add(k);
            }
        }
        
        for (List<Double> sti : slopeToIntercept.values()) {
            if (sti.size() == 1) {
                continue;
            }
            Map<Double, Integer> cnt = new TreeMap<>();
            for (double b : sti) {
                cnt.put(b, cnt.getOrDefault(b, 0) + 1);
            }
            int sum = 0;
            for (int count : cnt.values()) {
                ans += sum * count;
                sum += count;
            }
        }
        
        for (List<Double> mts : midToSlope.values()) {
            if (mts.size() == 1) {
                continue;
            }
            Map<Double, Integer> cnt = new TreeMap<>();
            for (double k : mts) {
                cnt.put(k, cnt.getOrDefault(k, 0) + 1);
            }
            int sum = 0;
            for (int count : cnt.values()) {
                ans -= sum * count;
                sum += count;
            }
        }
        
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountTrapezoids(int[][] points) {
        int n = points.Length;
        double inf = 1e9 + 7;
        Dictionary<double, List<double>> slopeToIntercept = new Dictionary<double, List<double>>();
        Dictionary<double, List<double>> midToSlope = new Dictionary<double, List<double>>();
        int ans = 0;
        
        for (int i = 0; i < n; i++) {
            int x1 = points[i][0], y1 = points[i][1];
            for (int j = i + 1; j < n; j++) {
                int x2 = points[j][0], y2 = points[j][1];
                int dx = x1 - x2;
                int dy = y1 - y2;
                
                double k, b;
                if (x2 == x1) {
                    k = inf;
                    b = x1;
                } else {
                    k = (double)(y2 - y1) / (x2 - x1);
                    b = (double)(y1 * dx - x1 * dy) / dx;
                }
                
                double mid = (x1 + x2) * 10000.0 + (y1 + y2);
                if (!slopeToIntercept.ContainsKey(k)) {
                    slopeToIntercept[k] = new List<double>();
                }
                if (!midToSlope.ContainsKey(mid)) {
                    midToSlope[mid] = new List<double>();
                }
                slopeToIntercept[k].Add(b);
                midToSlope[mid].Add(k);
            }
        }
        
        foreach (var sti in slopeToIntercept.Values) {
            if (sti.Count == 1) {
                continue;
            }
            Dictionary<double, int> cnt = new Dictionary<double, int>();
            foreach (double bVal in sti) {
                cnt[bVal] = cnt.GetValueOrDefault(bVal, 0) + 1;
            }
            int totalSum = 0;
            foreach (int count in cnt.Values) {
                ans += totalSum * count;
                totalSum += count;
            }
        }
        
        foreach (var mts in midToSlope.Values) {
            if (mts.Count == 1) {
                continue;
            }
            Dictionary<double, int> cnt = new Dictionary<double, int>();
            foreach (double kVal in mts) {
                cnt[kVal] = cnt.GetValueOrDefault(kVal, 0) + 1;
            }
            
            int totalSum = 0;
            foreach (int count in cnt.Values) {
                ans -= totalSum * count;
                totalSum += count;
            }
        }
        
        return ans;
    }
}
```

```Go
func countTrapezoids(points [][]int) int {
    n := len(points)
    inf := 1e9 + 7
    slopeToIntercept := make(map[float64][]float64)
    midToSlope := make(map[float64][]float64)
    ans := 0
    
    for i := 0; i < n; i++ {
        x1, y1 := points[i][0], points[i][1]
        for j := i + 1; j < n; j++ {
            x2, y2 := points[j][0], points[j][1]
            dx := x1 - x2
            dy := y1 - y2
            
            var k, b float64
            if x2 == x1 {
                k = inf
                b = float64(x1)
            } else {
                k = float64(y2-y1) / float64(x2-x1)
                b = float64(y1*dx - x1*dy) / float64(dx)
            }
            
            mid := float64((x1+x2)*10000 + (y1+y2))
            slopeToIntercept[k] = append(slopeToIntercept[k], b)
            midToSlope[mid] = append(midToSlope[mid], k)
        }
    }
    
    for _, sti := range slopeToIntercept {
        if len(sti) == 1 {
            continue
        }
        
        cnt := make(map[float64]int)
        for _, bVal := range sti {
            cnt[bVal]++
        }
        
        totalSum := 0
        for _, count := range cnt {
            ans += totalSum * count
            totalSum += count
        }
    }
    
    for _, mts := range midToSlope {
        if len(mts) == 1 {
            continue
        }
        
        cnt := make(map[float64]int)
        for _, kVal := range mts {
            cnt[kVal]++
        }
        
        totalSum := 0
        for _, count := range cnt {
            ans -= totalSum * count
            totalSum += count
        }
    }
    
    return ans
}
```

```JavaScript
var countTrapezoids = function(points) {
    const n = points.length;
    const inf = 1e9 + 7;
    const slopeToIntercept = new Map();
    const midToSlope = new Map();
    let ans = 0;
    
    for (let i = 0; i < n; i++) {
        const [x1, y1] = points[i];
        for (let j = i + 1; j < n; j++) {
            const [x2, y2] = points[j];
            const dx = x1 - x2;
            const dy = y1 - y2;
            
            let k, b;
            if (x2 === x1) {
                k = inf;
                b = x1;
            } else {
                k = (y2 - y1) / (x2 - x1);
                b = (y1 * dx - x1 * dy) / dx;
            }
            
            const mid = (x1 + x2) * 10000 + (y1 + y2);
            if (!slopeToIntercept.has(k)) {
                slopeToIntercept.set(k, []);
            }
            if (!midToSlope.has(mid)) {
                midToSlope.set(mid, []);
            }
            slopeToIntercept.get(k).push(b);
            midToSlope.get(mid).push(k);
        }
    }
    
    for (const sti of slopeToIntercept.values()) {
        if (sti.length === 1) {
            continue;
        }
        const cnt = new Map();
        for (const bVal of sti) {
            cnt.set(bVal, (cnt.get(bVal) || 0) + 1);
        }
        
        let totalSum = 0;
        for (const count of cnt.values()) {
            ans += totalSum * count;
            totalSum += count;
        }
    }
    
    for (const mts of midToSlope.values()) {
        if (mts.length === 1) {
            continue;
        }
        const cnt = new Map();
        for (const kVal of mts) {
            cnt.set(kVal, (cnt.get(kVal) || 0) + 1);
        }
        
        let totalSum = 0;
        for (const count of cnt.values()) {
            ans -= totalSum * count;
            totalSum += count;
        }
    }
    
    return ans;
};
```

```TypeScript
function countTrapezoids(points: number[][]): number {
    const n: number = points.length;
    const inf: number = 1e9 + 7;
    const slopeToIntercept: Map<number, number[]> = new Map();
    const midToSlope: Map<number, number[]> = new Map();
    let ans: number = 0;
    
    for (let i = 0; i < n; i++) {
        const [x1, y1] = points[i];
        for (let j = i + 1; j < n; j++) {
            const [x2, y2] = points[j];
            const dx = x1 - x2;
            const dy = y1 - y2;
            
            let k: number, b: number;
            if (x2 === x1) {
                k = inf;
                b = x1;
            } else {
                k = (y2 - y1) / (x2 - x1);
                b = (y1 * dx - x1 * dy) / dx;
            }
            
            const mid: number = (x1 + x2) * 10000 + (y1 + y2);
            if (!slopeToIntercept.has(k)) {
                slopeToIntercept.set(k, []);
            }
            if (!midToSlope.has(mid)) {
                midToSlope.set(mid, []);
            }
            slopeToIntercept.get(k)!.push(b);
            midToSlope.get(mid)!.push(k);
        }
    }
    
    for (const sti of slopeToIntercept.values()) {
        if (sti.length === 1) {
            continue;
        }
        const cnt: Map<number, number> = new Map();
        for (const bVal of sti) {
            cnt.set(bVal, (cnt.get(bVal) || 0) + 1);
        }
        
        let totalSum: number = 0;
        for (const count of cnt.values()) {
            ans += totalSum * count;
            totalSum += count;
        }
    }
    
    for (const mts of midToSlope.values()) {
        if (mts.length === 1) {
            continue;
        }
        const cnt: Map<number, number> = new Map();
        for (const kVal of mts) {
            cnt.set(kVal, (cnt.get(kVal) || 0) + 1);
        }
        
        let totalSum: number = 0;
        for (const count of cnt.values()) {
            ans -= totalSum * count;
            totalSum += count;
        }
    }
    
    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn count_trapezoids(points: Vec<Vec<i32>>) -> i32 {
        let n = points.len();
        let inf = 1e9 as i32;
        let mut slope_to_intercept: HashMap<String, Vec<String>> = HashMap::new();
        let mut mid_to_slope: HashMap<i64, Vec<String>> = HashMap::new();
        let mut ans = 0;
        
        for i in 0..n {
            let x1 = points[i][0];
            let y1 = points[i][1];
            for j in i + 1..n {
                let x2 = points[j][0];
                let y2 = points[j][1];
                let dx = x1 - x2;
                let dy = y1 - y2;
                
                let (k, b) = if x2 == x1 {
                    (inf.to_string(), x1.to_string())
                } else {
                    let mut k_val = (y2 - y1) as f64 / (x2 - x1) as f64;
                    let mut b_val = (y1 as i64 * dx as i64 - x1 as i64 * dy as i64) as f64 / dx as f64;
                    if (k_val == -0.0) {
                        k_val = 0.0;
                    }
                    if (b_val == -0.0) {
                        b_val = 0.0;
                    }
                    (format!("{:.10}", k_val), format!("{:.10}", b_val))
                };
                
                let mid = (x1 + x2) as i64 * 10000 + (y1 + y2) as i64;
                slope_to_intercept.entry(k.clone()).or_insert(Vec::new()).push(b.clone());
                mid_to_slope.entry(mid).or_insert(Vec::new()).push(k);
            }
        }
        
        for sti in slope_to_intercept.values() {
            if sti.len() == 1 {
                continue;
            }
            let mut cnt: HashMap<&String, i32> = HashMap::new();
            for b_val in sti {
                *cnt.entry(b_val).or_insert(0) += 1;
            }
            let mut total_sum = 0;
            for &count in cnt.values() {
                ans += total_sum * count;
                total_sum += count;
            }
        }
        
        for mts in mid_to_slope.values() {
            if mts.len() == 1 {
                continue;
            }
            
            let mut cnt: HashMap<&String, i32> = HashMap::new();
            for k_val in mts {
                *cnt.entry(k_val).or_insert(0) += 1;
            }
            
            let mut total_sum = 0;
            for &count in cnt.values() {
                ans -= total_sum * count;
                total_sum += count;
            }
        }
        
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 为 $points$ 的长度。值得一提的是，在最终计数的过程中，使用 $map$ 辅助计数，每一次操作时间复杂度为 $O(\log m)$，其中 $m$ 是当前斜率或中点对应的线段的个数，不妨设所有线段的斜率或中点相同，计数过程在最坏情况下时间复杂度会达到 $O(m2\log m)$，此时 $m=n$，但由于 $n$ 的范围较小，$\log n$ 几乎为常数，并且计数过程大多数情况是稀疏的，也就是相同斜率或中点的线段往往较少，因此时间复杂度主要集中于预处理线段的阶段，故为 $O(n^2)$。
- 空间复杂度：$O(n^2)$。
