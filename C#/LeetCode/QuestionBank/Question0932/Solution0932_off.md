### [漂亮数组](https://leetcode.cn/problems/beautiful-array/solutions/18740/piao-liang-shu-zu-by-leetcode/)

#### 方法一：分治

**分析**

首先我们可以发现一个不错的性质，如果某个数组 $[a_1,a_2,\dots ,a_n]$ 是漂亮的，那么对这个数组进行仿射变换，得到的新数组 $[ka_1+b,ka_2+b,\dots ,ka_n+b]$ 也是漂亮的（其中 $k\ne 0$）。那么我们就有了一个想法：将数组分成两部分 `left` 和 `right`，分别求出一个漂亮的数组，然后将它们进行仿射变换，使得不存在满足下面条件的三元组：

- `A[k] * 2 = A[i] + A[j], i < k < j`；
- `A[i]` 来自 `left` 部分，`A[j]` 来自 `right` 部分。

可以发现，等式 `A[k] * 2 = A[i] + A[j]` 的左侧是一个偶数，右侧的两个元素分别来自两个部分。要想等式恒不成立，一个简单的办法就是让 `left` 部分的数都是奇数，`right` 部分的数都是偶数。

因此我们将所有的奇数放在 `left` 部分，所有的偶数放在 `right` 部分，这样可以保证等式恒不成立。对于 `[1..N]` 的排列，`left` 部分包括 `(N + 1) / 2` 个奇数，`right` 部分包括 `N / 2` 个偶数。对于 `left` 部分，我们进行 `k = 1/2, b = 1/2` 的仿射变换，把这些奇数一一映射到不超过 `(N + 1) / 2` 的整数。对于 `right` 部分，我们进行 `k = 1/2, b = 0` 的仿射变换，把这些偶数一一映射到不超过 `N / 2` 的整数。经过映射，`left` 和 `right` 部分变成了和原问题一样，但规模减少一半的子问题，这样就可以使用分治算法解决了。

**算法**

在 `[1..N]` 中有 `(N + 1) / 2` 个奇数和 `N / 2` 个偶数。我们将其分治成两个子问题，其中一个为不超过 `(N + 1) / 2` 的整数，并映射到所有的奇数；另一个为不超过 `N / 2` 的整数，并映射到所有的偶数。

```Java
class Solution {
    Map<Integer, int[]> memo;
    public int[] beautifulArray(int N) {
        memo = new HashMap();
        return f(N);
    }

    public int[] f(int N) {
        if (memo.containsKey(N))
            return memo.get(N);

        int[] ans = new int[N];
        if (N == 1) {
            ans[0] = 1;
        } else {
            int t = 0;
            for (int x: f((N+1)/2))  // odds
                ans[t++] = 2*x - 1;
            for (int x: f(N/2))  // evens
                ans[t++] = 2*x;
        }
        memo.put(N, ans);
        return ans;
    }
}
```

```Python
class Solution:
    def beautifulArray(self, N):
        memo = {1: [1]}
        def f(N):
            if N not in memo:
                odds = f((N+1)/2)
                evens = f(N/2)
                memo[N] = [2*x-1 for x in odds] + [2*x for x in evens]
            return memo[N]
        return f(N)
```

**复杂度分析**

- 时间复杂度：$O(N\log N)$，代码中的函数 `f` 执行的次数为 $O(\log N)$，每次执行的时间复杂度为 $O(N)$。
- 空间复杂度：$O(N\log N)$。
