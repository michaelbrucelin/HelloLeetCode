### [和为零的N个唯一整数](https://leetcode.cn/problems/find-n-unique-integers-sum-up-to-zero/solutions/101790/he-wei-ling-de-nge-wei-yi-zheng-shu-by-leetcode-so/)

#### 方法一：构造

我们可以先把最小的 $\lfloor \frac{n}{2} \rfloor$ 个正整数与它们的相反数放入数组中，此时它们的和为 $0$，然后：

- 当 `n` 为偶数时，数组已经满足要求；
- 当 `n` 为奇数时，我们再将 `0` 放入数组；

这样，这 `n` 个数就互不相同，并且和为 $0$，即我们得到了一个满足要求的数组。

```C++
class Solution {
public:
    vector<int> sumZero(int n) {
        vector<int> ans;
        for (int i = 1; i <= n / 2; ++i) {
            ans.push_back(i);
            ans.push_back(-i);
        }
        if (n % 2 == 1) {
            ans.push_back(0);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def sumZero(self, n: int) -> List[int]:
        ans = []
        for i in range(1, n // 2 + 1):
            ans.append(i)
            ans.append(-i)
        if n % 2 == 1:
            ans.append(0)
        return ans
```

**复杂度分析**

- 时间复杂度：$O(N)$。
- 空间复杂度：$O(1)$，除了存储答案的数组 `ans` 之外，额外的空间复杂度是 $O(1)$。
