### [从魔法师身上吸取的最大能量](https://leetcode.cn/problems/taking-maximum-energy-from-the-mystic-dungeon/solutions/3796799/cong-mo-fa-shi-shen-shang-xi-qu-de-zui-d-xkjs/)

#### 方法一：逆序遍历

**思路与算法**

根据题意可知，每次从数组 $energy$ 任意起点 $i$ 处开始后，则立即传送到 $i+k$，此时遍历的下标则为：$[i,i+2k,i+3k,\dots ]$，直到到达数组的末尾。最直接的方法，可以直接枚举所有的起点，此时需要枚举 $n$ 次，但我们可以换一种思路，枚举所有路径的终点 $i$，此时逆序遍历路径即为：$[i,i-k,i-2k,\dots ]$，此时枚举路径中前缀即为：

$$\begin{array}{l}
[i] \\ [i,i-k] \\ [i,i-k,i-2k] \\ [i,i-k,i-2k,i-3k] \\ \dots
\end{array}$$

通过观察可知，逆序路径中所有的前缀和即为所有**可能吸收的能量**，我们找到最大值返回即可。

我们依次枚举终点为 $i$，此时 $i$ 的取值范围为: $[n-k,n-1]$，其中 $n$ 表示给定数组 $energy$ 的长度，遍历的同时累加元素和 $sum$，找到最大值即为答案。

**代码**

```C++
class Solution {
public:
    int maximumEnergy(vector<int>& energy, int k) {
        int n = energy.size(), ans = INT_MIN;
        for (int i = n - k; i < n; i++) {
            int sum = 0;
            for (int j = i; j >= 0; j -= k) {
                sum += energy[j];
                ans = max(ans, sum);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maximumEnergy(int[] energy, int k) {
        int n = energy.length;
        int ans = Integer.MIN_VALUE;
        for (int i = n - k; i < n; i++) {
            int sum = 0;
            for (int j = i; j >= 0; j -= k) {
                sum += energy[j];
                ans = Math.max(ans, sum);
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaximumEnergy(int[] energy, int k) {
        int n = energy.Length;
        int ans = int.MinValue;
        for (int i = n - k; i < n; i++) {
            int sum = 0;
            for (int j = i; j >= 0; j -= k) {
                sum += energy[j];
                if (sum > ans) ans = sum;
            }
        }
        return ans;
    }
}
```

```Go
func maximumEnergy(energy []int, k int) int {
    n := len(energy)
    ans := -1 << 31
    
    for i := n - k; i < n; i++ {
        sum := 0
        for j := i; j >= 0; j -= k {
            sum += energy[j]
            ans = max(ans, sum)
        }
    }
    return ans
}
```

```Python
class Solution:
    def maximumEnergy(self, energy: List[int], k: int) -> int:
        n = len(energy)
        ans = -inf
        
        for i in range(n - k, n):
            total = 0
            j = i
            while j >= 0:
                total += energy[j]
                ans = max(ans, total)
                j -= k
        
        return ans
```

```C
int maximumEnergy(int* energy, int energySize, int k) {
    int n = energySize;
    int ans = INT_MIN;
    
    for (int i = n - k; i < n; i++) {
        int sum = 0;
        for (int j = i; j >= 0; j -= k) {
            sum += energy[j];
            if (sum > ans) {
                ans = sum;
            }
        }
    }
    return ans;
}
```

```JavaScript
var maximumEnergy = function(energy, k) {
    const n = energy.length;
    let ans = -Number.MAX_SAFE_INTEGER;
    
    for (let i = n - k; i < n; i++) {
        let sum = 0;
        for (let j = i; j >= 0; j -= k) {
            sum += energy[j];
            ans = Math.max(ans, sum);
        }
    }
    return ans;
};
```

```TypeScript
function maximumEnergy(energy: number[], k: number): number {
    const n = energy.length;
    let ans = -Number.MAX_SAFE_INTEGER;
    
    for (let i = n - k; i < n; i++) {
        let sum = 0;
        for (let j = i; j >= 0; j -= k) {
            sum += energy[j];
            ans = Math.max(ans, sum);
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn maximum_energy(energy: Vec<i32>, k: i32) -> i32 {
        let n = energy.len();
        let k_usize = k as usize;
        let mut ans = i32::MIN;
        
        for i in (n - k_usize)..n {
            let mut sum = 0;
            let mut j = i;
            while j < n {
                sum += energy[j];
                if sum > ans {
                    ans = sum;
                }
                if j < k_usize {
                    break;
                }
                j -= k_usize;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组 $energy$ 的长度。数组中每个元素刚好被遍历一次。
- 空间复杂度：$O(1)$。
