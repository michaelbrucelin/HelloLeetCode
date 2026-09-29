### [分组得分最高的所有下标](https://leetcode.cn/problems/all-divisions-with-the-highest-score-of-a-binary-array/solutions/1240126/fen-zu-de-fen-zui-gao-de-suo-you-xia-bia-7pqp/?envType=problem-list-v2&envId=h15Gc5qm)

#### 方法一：一次遍历

**思路与算法**

如果我们根据下标 $i$ 将 $nums$ 拆分成两个数组，那么左半部分 $0$ 的个数即为：

$$\sum\limits_{k=0}^{i-1}(1-nums[i])$$

右半部分 $1$ 的个数即为：

$$\sum\limits_{k=i}^{n-1}nums[i]$$

总和即为：

$$\begin{array}{cl} & \sum\limits_{k=0}^{i-1}(1-nums[i])+\sum\limits_{k=i}^{n-1}nums[i] \\ \Leftrightarrow & \sum\limits_{k=0}^{i-1}(1-2\cdot nums[i])+\sum\limits_{k=0}^{n-1}nums[i] \tag 1\end{array}$$

由于我们希望得分最高，因此目标为最大化 $(1)$ 式的值。注意到 $\sum\limits_{k=0}^{n-1}nums[i]$ 是定值，那么目标等价于最大化 $\sum\limits_{k=0}^{i-1}(1-2\cdot nums[i])$：

> 当 $nums[i]=0$ 时，$1-2\cdot nums[i]=1$； $ $
> 当 $nums[i]=1$ 时，$1-2\cdot nums[i]=-1$；

因此我们只需要对数组进行一次遍历，并维护前缀和即可。前缀和的定义为：如果遇到 $0$ 就增加 $1$，否则减少 $1$。

对于当前遍历到的位置 $i$，如果前缀和大于历史最大值，那么就对历史最大值进行更新，并重置历史最大值对应的下标为 $i$；如果 $\sum\limits_{k=0}^{i-1}nums[i]$ 等于历史最大值，那么只需要将 $i$ 加入历史最大值的下标集合即可。

**细节**

当 $nums[i]=1$ 时，$1-2\cdot nums[i]=-1$，此时前缀和会减少，因此必定不会大于或等于历史最大值，我们可以省去比较操作。

**代码**

```C++
class Solution {
public:
    vector<int> maxScoreIndices(vector<int>& nums) {
        int n = nums.size();
        // best 为历史最大值
        int presum = 0, best = 0;
        // ans 为历史最大值的下标
        vector<int> ans = {0};
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 0) {
                ++presum;
                if (presum > best) {
                    best = presum;
                    ans = {i + 1};
                }
                else if (presum == best) {
                    ans.push_back(i + 1);
                }
            }
            else {
                --presum;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maxScoreIndices(self, nums: List[int]) -> List[int]:
        # best 为历史最大值
        presum = best = 0
        # ans 为历史最大值的下标
        ans = [0]

        for i, num in enumerate(nums):
            if num == 0:
                presum += 1
                if presum > best:
                    best = presum
                    ans = [i + 1]
                elif presum == best:
                    ans.append(i + 1)
            else:
                presum -= 1

        return ans
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
