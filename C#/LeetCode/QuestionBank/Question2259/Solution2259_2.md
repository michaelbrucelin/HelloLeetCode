#### [方法一：枚举移除下标](https://leetcode.cn/problems/remove-digit-from-number-to-maximize-result/solutions/1486072/yi-chu-zhi-ding-shu-zi-de-dao-de-zui-da-ikpqo/)

**思路与算法**

我们可以遍历 $number$ 寻找所有可以移除的下标。同时我们用字符串 $res$ 记录可以得到的最大结果。$res$ 初始为空字符串。每当我们找到 $number[i] = digit$ 的下标 $i$，我们构造移除下标 $i$ 后的字符串 $tmp$。由于移除下标后字符串的长度一定相等，因此**字典序的大小关系等于对应数值的大小关系**。同时由于空字符串在字典序中小于任何非空字符串，我们只需要令 $res$ 等于 $res$ 与 $tmp$ 的较大值即可。最终，我们返回 $res$ 作为答案。

**代码**

```cpp
class Solution {
public:
    string removeDigit(string number, char digit) {
        int n = number.size();
        string res;   // 可以得到的最大结果
        for (int i = 0; i < n; ++i) {
            if (number[i] == digit) {
                string tmp = number.substr(0, i);
                tmp.append(number.substr(i + 1, n - i));
                res = max(res, tmp);
            }
        }
        return res;
    }
};
```

```python
class Solution:
    def removeDigit(self, number: str, digit: str) -> str:
        n = len(number)
        res = ""   # 可以得到的最大结果
        for i in range(n):
            if number[i] == digit:
                tmp = number[:i] + number[i+1:]
                res = max(res, tmp)
        return res
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 为 $number$ 的长度。我们至多需要移除 $O(n)$ 次字符串，每次生成移除后字符串并比较的时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$，即为生成移除后字符串时辅助字符串的空间开销。
