### [连续差相同的数字](https://leetcode.cn/problems/numbers-with-same-consecutive-differences/solutions/107798/lian-xu-chai-xiang-tong-de-shu-zi-by-leetcode-2/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：暴力法

让我们尝试着一个数字一个数字的构造答案。

除了第一个数字外，每个数字最多有两种选择。这意味着 $9$ 位的数字我们最多有 $9\times 2^8$ 的情况。该可能性足够小到可以使用暴力法去解决它。

**算法：**

一个 $N$ 位的数字可以看作 $N-1$ 位数字加上最后一个数字。如果 $N-1$ 位数字以数字 $d$ 结尾，则 $N$ 位数字将以 $d-K$ 或 $d+K$ 结尾（前提是这些数字在 $[0,9]$ 范围内）。我们将这些数字存储在 `Set` 中，以避免重复。

另外，我们应该注意前导 $0 --$ 只有 $1$ 位数字以 $0$ 开头。

```Python
class Solution(object):
    def numsSameConsecDiff(self, N, K):
        ans = {x for x in range(1, 10)}
        for _ in xrange(N-1):
            ans2 = set()
            for x in ans:
                d = x % 10
                if d - K >= 0:
                    ans2.add(10*x + d-K)
                if d + K <= 9:
                    ans2.add(10*x + d+K)
            ans = ans2

        if N == 1:
            ans.add(0)

        return list(ans)
```

```Java
class Solution {
    public int[] numsSameConsecDiff(int N, int K) {
        Set<Integer> cur = new HashSet();
        for (int i = 1; i <= 9; ++i)
            cur.add(i);

        for (int steps = 1; steps <= N-1; ++steps) {
            Set<Integer> cur2 = new HashSet();
            for (int x: cur) {
                int d = x % 10;
                if (d-K >= 0)
                    cur2.add(10*x + (d-K));
                if (d+K <= 9)
                    cur2.add(10*x + (d+K));
            }

            cur = cur2;
        }

        if (N == 1)
            cur.add(0);

        int[] ans = new int[cur.size()];
        int t = 0;
        for (int x: cur)
            ans[t++] = x;
        return ans;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(2^N)$。
- 空间复杂度：$O(2^N)$。
