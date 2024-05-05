### [前缀和](https://leetcode.cn/problems/defuse-the-bomb/solutions/1845161/by-ac_oier-osbg/)

根据题意 `code` 为循环数组，我们可以建立一个长度为 $2 \times n$ 的前缀和数组（为了方便，我们令前缀和数组下标从 $1$ 开始），利用前缀和数组来构建答案。

对于每一位 $ans[i - 1]$ 而言（其中 $i$ 的取值范围为 $[1, n]$），我们根据 `k` 值的正负情况来决定取自前缀和数组中的哪一段：

- 若有 $k < 0$：需要取位置 $i$ 前的 $-k$ 个数，为防止下越界标，先将位置 $i$ 往后进行 $n$ 个偏移（即位置 $i + n$），随后可知对应区间 $[i + n + k, i + n - 1]$，对应区间和为 $sum[i + n - 1] - sum[i + n + k - 1]$
- 若有 $k > 0$：需要取位置 $i$ 后的 $k$ 个数，对应前缀和数组下标 $[i + 1, i + k]$，对应区间和为 $sum[i + k] - sum[i]$

代码：

```java
class Solution {
    public int[] decrypt(int[] code, int k) {
        int n = code.length;
        int[] ans = new int[n];
        if (k == 0) return ans;
        int[] sum = new int[n * 2 + 10];
        for (int i = 1; i <= 2 * n; i++) sum[i] += sum[i - 1] + code[(i - 1) % n];
        for (int i = 1; i <= n; i++) {
            if (k < 0) ans[i - 1] = sum[i + n - 1] - sum[i + n + k - 1];
            else ans[i - 1] = sum[i + k] - sum[i];
        }
        return ans;
    }
}
```

```typescript
function decrypt(code: number[], k: number): number[] {
    const n = code.length
    const ans = new Array<number>(n).fill(0)
    if (k == 0) return ans
    const sum = new Array<number>(2 * n + 10).fill(0)
    for (let i = 1; i <= 2 * n; i++) sum[i] = sum[i - 1] + code[(i - 1) % n]
    for (let i = 1; i <= n; i++) {
        if (k < 0) ans[i - 1] = sum[i + n - 1] - sum[i + n + k - 1]
        else ans[i - 1] = sum[i + k] - sum[i]
    }
    return ans
};
```

```python
class Solution:
    def decrypt(self, code: List[int], k: int) -> List[int]:
        n = len(code)
        ans = [0] * n
        if k == 0:
            return ans
        sum = [0] * (2 * n + 10)
        for i in range(1, 2 * n + 1):
            sum[i] = sum[i - 1] + code[(i - 1) % n]
        for i in range(1, n + 1):
            ans[i - 1] = sum[i + n - 1] - sum[i + n + k - 1] if k < 0 else sum[i + k] - sum[i]
        return ans
```

- 时间复杂度：$O(n)$
- 空间复杂度：$O(n)$
