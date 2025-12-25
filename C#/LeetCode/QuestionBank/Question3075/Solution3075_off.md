### [幸福值最大化的选择方案](https://leetcode.cn/problems/maximize-happiness-of-selected-ch_ildren/solutions/3859787/xing-fu-zh_i-zui-da-hua-de-xuan-ze-fang-a-mrub/)

#### 方法一：排序 + 贪心

**思路与算法**

当我们选择一个孩子时，所有尚未被选中的孩子的幸福值将减少 $1$，但幸福值不会变为负数，因此我们直观感觉，应当将幸福值较小的孩子放在更后的轮次选中。

具体的证明如下：

首先，显然一定选择的是幸福值最大的 $k$ 个孩子。

其次，考虑两个孩子，在第 $i,j$ 轮被选中（轮次从 $0$ 开始编号，$i<j$），初始的幸福值分别是 $h_i,h_j$，如果交换他们被选中的顺序，那么：

- 其他所有孩子的幸福值不会受到影响；
- 交换前，两个孩子的幸福值之和为 $P=max(h_i-i,0)+max(h_j-j,0)$；
- 交换后，两个孩子的幸福值之和为 $Q=max(h_i-j,0)+max(h_j-i,0)$。

记 $u_+=max(u,0)$，当 $h_i<h_j$ 时，有：

$$\begin{array}{rcl}P-Q & = & (h_i-i)_++(h_j-j)_+-(h_i-j)_+-(h_j-i)_+ \\ & = & [(h_i-i)_+-(h_i-j)_+]-[(h_j-i)_+-(h_j-j)_+]\end{array}$$

考虑函数 $f(x)=[(x-i)_+-(x-j)_+]$，有：

$$f(x)=\begin{cases}0, & x<i \\ x-i, & i\le x<j \\ j-i, & x\ge j\end{cases}$$

因此 $f(x)$ 在 $R$ 上单调递增，即 $P-Q\le 0$，说明交换两个孩子的顺序可以使得最终的答案不会变差。这就说明，按照幸福值降序排序后再依次进行选择，可以使得选中的孩子幸福值之和最大。

**代码**

```C++
class Solution {
public:
    long long maximumHappinessSum(vector<int>& happiness, int k) {
        sort(happiness.begin(), happiness.end(), greater<int>());
        long long ans = 0;
        for (int i = 0; i < k; ++i) {
            ans += max(happiness[i] - i, 0);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maximumHappinessSum(self, happiness: List[int], k: int) -> int:
        happiness.sort(reverse=True)
        ans = 0
        for i in range(k):
            ans += max(happiness[i] - i, 0)
        return ans
```

```Java
class Solution {
    public long maximumHappinessSum(int[] happiness, int k) {
        Integer[] arr = Arrays.stream(happiness).boxed().toArray(Integer[]::new);
        Arrays.sort(arr, (a, b) -> b - a);
        long ans = 0;
        for (int i = 0; i < k; i++) {
            ans += Math.max(arr[i] - i, 0);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        Array.Sort(happiness);
        Array.Reverse(happiness);
        long ans = 0;
        for (int i = 0; i < k; i++) {
            ans += Math.Max(happiness[i] - i, 0);
        }
        return ans;
    }
}
```

```Go
func maximumHappinessSum(happiness []int, k int) int64 {
    sort.Slice(happiness, func(i, j int) bool {
        return happiness[i] > happiness[j]
    })
    
    var ans int64 = 0
    for i := 0; i < k; i++ {
        val := happiness[i] - i
        if val > 0 {
            ans += int64(val)
        }
    }
    return ans
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)b - *(int*)a);
}

long long maximumHappinessSum(int* happiness, int happinessSize, int k) {
    qsort(happiness, happinessSize, sizeof(int), compare);
    long long ans = 0;
    for (int i = 0; i < k; i++) {
        int val = happiness[i] - i;
        ans += val > 0 ? val : 0;
    }
    return ans;
}
```

```JavaScript
var maximumHappinessSum = function(happiness, k) {
    happiness.sort((a, b) => b - a);
    let ans = 0;
    for (let i = 0; i < k; i++) {
        ans += Math.max(happiness[i] - i, 0);
    }
    return ans;
};
```

```TypeScript
function maximumHappinessSum(happiness: number[], k: number): number {
    happiness.sort((a, b) => b - a);
    let ans = 0;
    for (let i = 0; i < k; i++) {
        ans += Math.max(happiness[i] - i, 0);
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn maximum_happiness_sum(happiness: Vec<i32>, k: i32) -> i64 {
        let mut happiness = happiness;
        happiness.sort_by(|a, b| b.cmp(a));
        
        let mut ans: i64 = 0;
        for i in 0..(k as usize) {
            let val = happiness[i] as i64 - i as i64;
            ans += val.max(0);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+k)$，其中排序需要的时间为 $O(n\log n)$，计算答案需要的时间为 $O(k)$。
- 空间复杂度：$O(\log n)$，空间复杂度取决于所用语言排序使用栈空间大小。
