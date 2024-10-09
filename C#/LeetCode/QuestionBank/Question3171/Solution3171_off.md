### [找到按位或最接近 K 的子数组](https://leetcode.cn/problems/find-subarray-with-bitwise-or-closest-to-k/solutions/2942313/zhao-dao-an-wei-huo-zui-jie-jin-k-de-zi-gianx/)

#### 方法一：枚举

**思路与算法**

题目给定一个数组 $nums$ 和一个整数 $k$。我们需要找到 $nums$ 的一个非空子数组，要求其所有元素的或运算结果与 $k$ 值尽可能接近。

根据或运算的性质，当我们固定子数组的右端点，不断地向左延伸左端点时，子数组或运算结果逐渐增加，并且结果种类数不超过 $log(max(nums))+1$ 种。因为或运算结果每次增加对应于二进制表示中某些位上由 $0$ 变为 $1$，因此增加的种类数受到数值范围的限制。

因此，我们从左到右遍历 $nums$，并在过程中记录每个二进制上的 $1$ 出现的最晚的位置。这些位置用于我们在延伸左端点时，遍历所有种类的或运算结果。具体的，我们用 $bits\_max\_pos[j]$ 来表示第 $j$ 个二进制为 $1$ 出现的最晚位置，在固定右端点后，将所有的二元组 $(bits\_max\_pos[j],j)$ 从大到小排序，然后依次遍历这些二元组。遍历时将或运算结果与 $2^j$ 做或运算，得到新的结果，并计算其与 $k$ 的差值。最终答案取所有差值的最小值。

需要注意的是，对于不同的 $j$，其 $bits\_max\_pos[j]$ 可能相同，在计算区间或运算结果时需要将它们都考虑到，因此这里需要双指针去更新或运算结果。

**代码**

```C++
class Solution {
public:
    int minimumDifference(vector<int>& nums, int k) {
        int n = nums.size();
        vector<int> bits_max_pos(31, -1);
        vector<pair<int, int>> pos_to_bit;
        int res = INT_MAX;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= 30; j++) {
                if (nums[i] >> j & 1) {
                    bits_max_pos[j] = i;
                }
            }
            pos_to_bit.clear();
            for (int j = 0; j <= 30; j++) {
                if (bits_max_pos[j] != -1) {
                    pos_to_bit.push_back(make_pair(bits_max_pos[j], j));
                }
            }
            sort(pos_to_bit.begin(), pos_to_bit.end(), greater<pair<int, int>>());
            int val = 0;
            for (int j = 0, p = 0; j < pos_to_bit.size(); ) {
                while (j < pos_to_bit.size() && pos_to_bit[j].first == pos_to_bit[p].first) {
                    val |= 1 << pos_to_bit[j].second;
                    j++;
                }
                res = min(res, abs(val - k));
                p = j;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int minimumDifference(int[] nums, int k) {
        int n = nums.length;
        int[] bitsMaxPos = new int[31];
        Arrays.fill(bitsMaxPos, -1);
        List<int[]> posToBit = new ArrayList<int[]>();
        int res = Integer.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= 30; j++) {
                if ((nums[i] >> j & 1) != 0) {
                    bitsMaxPos[j] = i;
                }
            }
            posToBit.clear();
            for (int j = 0; j <= 30; j++) {
                if (bitsMaxPos[j] != -1) {
                    posToBit.add(new int[]{bitsMaxPos[j], j});
                }
            }
            Collections.sort(posToBit, (a, b) -> a[0] != b[0] ? b[0] - a[0] : b[1] - a[1]);
            int val = 0;
            for (int j = 0, p = 0; j < posToBit.size(); ) {
                while (j < posToBit.size() && posToBit.get(j)[0] == posToBit.get(p)[0]) {
                    val |= 1 << posToBit.get(j)[1];
                    j++;
                }
                res = Math.min(res, Math.abs(val - k));
                p = j;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        int n = nums.Length;
        int[] bitsMaxPos = new int[31];
        Array.Fill(bitsMaxPos, -1);
        IList<Tuple<int, int>> posToBit = new List<Tuple<int, int>>();
        int res = int.MaxValue;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= 30; j++) {
                if ((nums[i] >> j & 1) != 0) {
                    bitsMaxPos[j] = i;
                }
            }
            posToBit.Clear();
            for (int j = 0; j <= 30; j++) {
                if (bitsMaxPos[j] != -1) {
                    posToBit.Add(new Tuple<int, int>(bitsMaxPos[j], j));
                }
            }
            ((List<Tuple<int, int>>) posToBit).Sort((a, b) => a.Item1 != b.Item1 ? b.Item1 - a.Item1 : b.Item2 - a.Item2);
            int val = 0;
            for (int j = 0, p = 0; j < posToBit.Count; ) {
                while (j < posToBit.Count && posToBit[j].Item1 == posToBit[p].Item1) {
                    val |= 1 << posToBit[j].Item2;
                    j++;
                }
                res = Math.Min(res, Math.Abs(val - k));
                p = j;
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def minimumDifference(self, nums: List[int], k: int) -> int:
        n = len(nums)
        bits_max_pos = [-1] * 31
        res = inf
        
        for i in range(n):
            for j in range(31):
                if nums[i] >> j & 1:
                    bits_max_pos[j] = i
            pos_to_bit = [(bits_max_pos[j], j) for j in range(31) if bits_max_pos[j] != -1]
            pos_to_bit.sort(reverse = True, key = lambda x: x[0])
            
            j, val = 0, 0
            while j < len(pos_to_bit):
                p = j
                while j < len(pos_to_bit) and pos_to_bit[j][0] == pos_to_bit[p][0]:
                    val |= 1 << pos_to_bit[j][1]
                    j += 1
                res = min(res, abs(val - k))
        
        return res
```

```Go
func minimumDifference(nums []int, k int) int {
    n := len(nums)
    bitsMaxPos := make([]int, 31)
    for i := range bitsMaxPos {
        bitsMaxPos[i] = -1
    }

    res := math.MaxInt
    for i := 0; i < n; i++ {
        for j := 0; j <= 30; j++ {
            if nums[i]>>j & 1 == 1 {
                bitsMaxPos[j] = i
            }
        }
        
        posToBit := make([][2]int, 0)
        for j := 0; j <= 30; j++ {
            if bitsMaxPos[j] != -1 {
                posToBit = append(posToBit, [2]int{bitsMaxPos[j], j})
            }
        }
        sort.Slice(posToBit, func(a, b int) bool {
            return posToBit[a][0] > posToBit[b][0]
        })
        
        val := 0
        for j, p := 0, 0; j < len(posToBit); p = j {
            for j < len(posToBit) && posToBit[j][0] == posToBit[p][0] {
                val |= 1 << posToBit[j][1]
                j++
            }
            res = min(res, int(math.Abs(float64(val - k))))
        }
    }
    return res
}
```

```C
static int cmp(const void *a, const void *b) {
    return ((int*)b)[0] - ((int *)a)[0];
}

int minimumDifference(int* nums, int numsSize, int k) {
    int bits_max_pos[31];
    for (int i = 0; i < 31; i++) {
        bits_max_pos[i] = -1;
    }

    int res = INT_MAX;
    for (int i = 0; i < numsSize; i++) {
        for (int j = 0; j <= 30; j++) {
            if (nums[i] >> j & 1) {
                bits_max_pos[j] = i;
            }
        }
    
        int pos_to_bit[31][2];
        int size = 0;
        for (int j = 0; j <= 30; j++) {
            if (bits_max_pos[j] != -1) {
                pos_to_bit[size][0] = bits_max_pos[j];
                pos_to_bit[size][1] = j;
                size++;
            }
        }
        
        qsort(pos_to_bit, size, sizeof(pos_to_bit[0]), cmp); 
        int val = 0;
        for (int j = 0, p = 0; j < size; p = j) {
            while (j < size && pos_to_bit[j][0] == pos_to_bit[p][0]) {
                val |= 1 << pos_to_bit[j][1];
                j++;
            }
            res = fmin(res, abs(val - k));
        }
    }
    return res;
}
```

```JavaScript
var minimumDifference = function(nums, k) {
    const n = nums.length;
    const bitsMaxPos = new Array(31).fill(-1);
    let res = Number.MAX_SAFE_INTEGER;

    for (let i = 0; i < n; i++) {
        for (let j = 0; j <= 30; j++) {
            if (nums[i] >> j & 1) {
                bitsMaxPos[j] = i;
            }
        }
        
        const posToBit = [];
        for (let j = 0; j <= 30; j++) {
            if (bitsMaxPos[j] !== -1) {
                posToBit.push([bitsMaxPos[j], j]);
            }
        }
        
        posToBit.sort((a, b) => b[0] - a[0]);
        let val = 0, j = 0;
        for (let j = 0, p = 0; j < posToBit.length; p = j) {
            while (j < posToBit.length && posToBit[j][0] === posToBit[p][0]) {
                val |= 1 << posToBit[j][1];
                j++;
            }
            res = Math.min(res, Math.abs(val - k));
        }
    }
    return res;
};
```

```TypeScript
function minimumDifference(nums: number[], k: number): number {
    const n = nums.length;
    const bitsMaxPos = new Array(31).fill(-1);
    let res = Number.MAX_SAFE_INTEGER;

    for (let i = 0; i < n; i++) {
        for (let j = 0; j <= 30; j++) {
            if (nums[i] >> j & 1) {
                bitsMaxPos[j] = i;
            }
        }
        const posToBit: [number, number][] = [];
        for (let j = 0; j <= 30; j++) {
            if (bitsMaxPos[j] !== -1) {
                posToBit.push([bitsMaxPos[j], j]);
            }
        }   
        posToBit.sort((a, b) => b[0] - a[0]);
        let val = 0;
        for (let j = 0, p = 0; j < posToBit.length; p = j) {
            while (j < posToBit.length && posToBit[j][0] === posToBit[p][0]) {
                val |= 1 << posToBit[j][1];
                j++;
            }
            res = Math.min(res, Math.abs(val - k));
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn minimum_difference(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let mut bits_max_pos = vec![-1; 31];
        let mut res = i32::MAX;

        for i in 0..n {
            for j in 0..=30 {
                if nums[i] >> j & 1 == 1 {
                    bits_max_pos[j] = i as i32;
                }
            }
            
            let mut pos_to_bit = Vec::new();
            for j in 0..=30 {
                if bits_max_pos[j] != -1 {
                    pos_to_bit.push((bits_max_pos[j], j as i32));
                }
            }
            pos_to_bit.sort_by(|a, b| b.0.cmp(&a.0));
            let mut val = 0;
            let mut j = 0;
            while j < pos_to_bit.len() {
                let p = j;
                while j < pos_to_bit.len() && pos_to_bit[j].0 == pos_to_bit[p].0 {
                    val |= 1 << pos_to_bit[j].1;
                    j += 1;
                }
                res = std::cmp::min(res, (val - k).abs());
            }
        }
        res
    }
}
```

```Cangjie
import std.collection.*
import std.sort.*
import std.math.*

class Solution {
    func minimumDifference(nums: Array<Int64>, k: Int64): Int64 {
        let n = nums.size
        let bits_max_pos = Array<Int>(31, { _ => -1 })
        let pos_to_bit = ArrayList<(Int, Int)>()
        var res = Int.Max
        for (i in 0..n) {
            for (j in 0..=30) {
                if ((nums[i] >> j & 1) == 1) {
                    bits_max_pos[j] = i
                }
            }
            pos_to_bit.clear()
            for (j in 0..=30) {
                if (bits_max_pos[j] != -1) {
                    pos_to_bit.append((bits_max_pos[j], j))
                }
            }
            pos_to_bit.sortBy(stable: true){ x: (Int, Int), y: (Int, Int) =>
                if (x[0] == y[0]) {
                    if(x[1] < y[1]){
                        return Ordering.GT
                    } else if(x[1] > y[1]){
                        return Ordering.LT
                    } else{
                        return Ordering.EQ
                    }
                } else if (x[0] < y[0]){
                    return Ordering.GT
                } else {
                    return Ordering.LT
                }
            }
            var val = 0
            var j = 0
            while (j < pos_to_bit.size) {
                let p = j
                while (j < pos_to_bit.size && pos_to_bit[j][0] == pos_to_bit[p][0]) {
                    val |= 1 << pos_to_bit[j][1]
                    j++
                }
                res = min(res, abs(val - k))
            }
        }
        return res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogNloglogN)$, 其中 $n$ 是 $nums$ 的长度, $N$ 为 $nums$ 中的最大值。每次固定右端点后需要对所有的二元组进行排序，排序的复杂度为 $logNloglogN$，因此总体时间复杂度为 $O(nlogNloglogN)$。
- 空间复杂度：$O(logN)$。
