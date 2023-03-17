#### [方法一：枚举 + 暴力](https://leetcode.cn/problems/he-wei-sde-lian-xu-zheng-shu-xu-lie-lcof/solutions/128296/mian-shi-ti-57-ii-he-wei-sde-lian-xu-zheng-shu-x-2/)

枚举每个正整数为起点，判断以它为起点的序列和 $sum$ 是否等于 $target$ 即可，由于题目要求序列长度至少大于 $2$，所以枚举的上界为 $\lfloor\frac{target}{2}\rfloor$。

```cpp
class Solution {
public:
    vector<vector<int>> findContinuousSequence(int target) {
        vector<vector<int>> vec;
        vector<int> res;
        int sum = 0, limit = (target - 1) / 2; // (target - 1) / 2 等效于 target / 2 下取整
        for (int i = 1; i <= limit; ++i) {
            for (int j = i;; ++j) {
                sum += j;
                if (sum > target) {
                    sum = 0;
                    break;
                } else if (sum == target) {
                    res.clear();
                    for (int k = i; k <= j; ++k) {
                        res.emplace_back(k);
                    }
                    vec.emplace_back(res);
                    sum = 0;
                    break;
                }
            }
        }
        return vec;
    }
};
```

```java
class Solution {
    public int[][] findContinuousSequence(int target) {
        List<int[]> vec = new ArrayList<int[]>();
        int sum = 0, limit = (target - 1) / 2; // (target - 1) / 2 等效于 target / 2 下取整
        for (int i = 1; i <= limit; ++i) {
            for (int j = i;; ++j) {
                sum += j;
                if (sum > target) {
                    sum = 0;
                    break;
                } else if (sum == target) {
                    int[] res = new int[j - i + 1];
                    for (int k = i; k <= j; ++k) {
                        res[k - i] = k;
                    }
                    vec.add(res);
                    sum = 0;
                    break;
                }
            }
        }
        return vec.toArray(new int[vec.size()][]);
    }
}
```

**复杂度分析**

-   时间复杂度：外层需要枚举 $\lfloor\frac{target}{2}\rfloor$ 次，内层判断最多不会超过 $O(\sqrt{target})$ 的时间复杂度，因为我们考虑从 $1$ 开始累加到 $\sqrt{target}$ ，由求和公式可以得

$$\frac{(1+\sqrt{target}) \times \sqrt{target}}{2}=target+\frac{\sqrt{target}}{2}> target$$

而如果累加到 $\sqrt{target}-1$ ，由求和公式可以得

$$\frac{(1+\sqrt{target}-1) \times (\sqrt{target}-1)}{2}=target-\frac{\sqrt{target}}{2}< target$$

所以最多累加到 $\sqrt{target}$ ，而以后从 $2,3,\cdots$ 开始的数累加的长度必然也不会超过 $O(\sqrt{target})$ 的时间复杂度。最后总时间复杂度为内外层循环复杂度相乘，即 $O(target\sqrt{target})$

-   空间复杂度：$O(1)$ ，除了答案数组只需要常数的空间存放若干变量。
