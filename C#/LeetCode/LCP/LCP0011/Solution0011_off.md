### [期望个数统计 期望计算与证明](https://leetcode.cn/problems/qi-wang-ge-shu-tong-ji/solutions/224888/qi-wang-ge-shu-tong-ji-qi-wang-ji-suan-yu-zheng-mi/)

#### 题意概述：

对于一个排好序的序列，对相同的数字随机打乱顺序后期望有多少个数字保持原位置不变。

#### 题解

经过分析，我们发现不同能力值的简历是不会互相影响的，所以问题可以简化为有一个长度为 $n$ 的的数组，将里面的元素按照全排列随机排序后，问有多少个元素还在原位。设这个随机变量为 $X$，并且设 $X_i$ 是第 $i$ 个元素还在原位的 0-1 变量，即如果第 $i$ 个元素还在原位，$X_i = 1$，否则 $X_i = 0$。每一个元素随机排序后还在原位的概率是 $\frac{1}{n}$。

由期望的可加性，我们可以得到

$$E(X) = E(X_0 + X_1 + \cdots + X_{n - 1}) = \sum_{0 \leq i < n}E(X_i) = \frac{1}{n} * n = 1$$

我们发现$E(X)$跟数组元素的长度**无关**，所以我们只需要求这个数组中的不同数字的个数即可。

#### 方法一

排序 + 除重

```c++
class Solution {
public:
    int expectNumber(vector<int>& scores) {
        sort(scores.begin(), scores.end());
        return unique(scores.begin(), scores.end()) - scores.begin();
    }
};
```

##### 复杂度分析

- 时间复杂度：$O(N \log N)$，其中 $N$ 是数组的大小。
- 空间复杂度：$O(N)$。

#### 方法二

哈希表

```python
class Solution:
    def expectNumber(self, scores: List[int]) -> int:
        return len(set(scores))
```

##### 复杂度分析

- 时间复杂度：$O(N)$，其中 $N$ 是数组的大小。
- 空间复杂度：$O(N)$。
