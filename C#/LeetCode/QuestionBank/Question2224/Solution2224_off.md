#### [方法一：贪心](https://leetcode.cn/problems/minimum-number-of-operations-to-convert-time/solutions/1417995/zhuan-hua-shi-jian-xu-yao-de-zui-shao-ca-jzf4/)

**思路与算法**

为了方便计算，我们用整数 $time_1$ 与 $time_2$ 分别表示 $current$ 和 $correct$ 距离 $00:00$ 过去的分钟数，并用 $diff = time_2 - time_1$ 表示我们需要增加的分钟数。

由于我们希望增加操作的次数最少，同时对于 $[1, 5, 15, 60]$ 这四个增加的数量，每一个数都**可以整除它前面（如有）的所有元素**，因此**尽可能使用右边的操作**替代对应次数左边的操作一定会使得操作次数更少。

我们用 $res$ 来维护按照上述方案所需的操作数。同时，我们**从大到小**遍历单次操作可以增加的时间 $t$，则该操作可以进行的次数即为 $\lfloor diff / t \rfloor$（其中 $\lfloor \dots \rfloor$ 代表向下取整），我们将 $res$ 加上该数值，并修改操作结束后剩余的时间差，即 $diff = diff \bmod t$。最终，$res$ 即为最少操作次数，我们返回该数值作为答案。

**代码**

```cpp
class Solution {
public:
    int convertTime(string current, string correct) {
        int time1 = stoi(current.substr(0, 2)) * 60 + stoi(current.substr(3, 2));
        int time2 = stoi(correct.substr(0, 2)) * 60 + stoi(correct.substr(3, 2));
        int diff = time2 - time1;   // 需要增加的分钟数
        int res = 0;
        // 尽可能优先使用增加数值更大的操作
        vector<int> ops = {60, 15, 5, 1};
        for (int t: ops) {
            res += diff / t;
            diff %= t;
        }
        return res;
    }
};
```

```python
class Solution:
    def convertTime(self, current: str, correct: str) -> int:
        time1 = int(current[:2]) * 60 + int(current[3:])
        time2 = int(correct[:2]) * 60 + int(correct[3:])
        diff = time2 - time1   # 需要增加的分钟数
        res = 0
        # 尽可能优先使用增加数值更大的操作
        for t in [60, 15, 5, 1]:
            res += diff // t
            diff %= t
        return res
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
