#### [方法二：贪心](https://leetcode.cn/problems/remove-digit-from-number-to-maximize-result/solutions/1486072/yi-chu-zhi-ding-shu-zi-de-dao-de-zui-da-ikpqo/)

**提示 $1$**

按照以下策略移除数字可以使得最终结果最大：

1.  我们从左至右遍历 $number$，如果遍历到 $number[i] = digit$，且 $number[i] < number[i + 1]$（如果存在，下同），则我们删除该字符后得到的结果最大；
    
2.  如果遍历完成依旧不存在满足上一个条件的下标，则我们删除 $digit$ 出现的最后一个下标，此时删除该字符后得到的结果最大。
    

**提示 $1$ 解释**

我们可以以条件 $2$ 得到的数 $num$ 作为基准，并将其与其它可能得到的结果进行比较。

首先，如果移除的位数 $i$ 更靠前，移除后的结果与 $num$ 之差的**绝对值**一定更高。

其次，我们根据 $number[i]$ 与 $number[i + 1]$ 的大小关系分类讨论：

-   $number[i] < number[i + 1]$，此时删除后的结果一定大于 $num$，且**大于删除后面所有位置得到的结果**。
-   $number[i] = number[i + 1]$，此时删除 $number[i]$ 与删除 $number[i + 1]$ 得到的结果相同；
-   $number[i] > number[i + 1]$，此时删除后的结果一定小于 $num$，因此我们不能删除该元素。

综上，**提示 $1$** 中的方法一定可以使得最终结果最大。

**思路与算法**

我们可以根据 **提示 $1$** 找到最佳的删除下标。

具体地，我们从左至右遍历 为 $number$，并用 $last$ 记录最近遍历到的可以删除的下标。如果遍历到 $number[i] = digit$时，我们将 $last$ 更新为 $i$。如果还满足 $number[i] < number[i + 1]$，则我们返回删除该字符得到的结果作为答案。

如果遍历完成后仍未找到符合上述要求的下标，则我们删除 $last$ 下标对应的字符并返回。

**代码**

```cpp
class Solution {
public:
    string removeDigit(string number, char digit) {
        int n = number.size();
        int last = -1;   // 最后一个可删除的下标
        for (int i = 0; i < n; ++i) {
            if (number[i] == digit) {
                last = i;
                if (number[i] < number[i+1]){
                    string res = number.substr(0, i);
                res.append(number.substr(i + 1, n - i));
                return res;
                }
            }
        }
        string res = number.substr(0, last);
        res.append(number.substr(last + 1, n - last));
        return res;
    }
};
```

```python
class Solution:
    def removeDigit(self, number: str, digit: str) -> str:
        n = len(number)
        last = -1   # 最后一个可删除的下标
        for i in range(n):
            if number[i] == digit:
                last = i
                if i < n - 1 and number[i] < number[i+1]:
                    return number[:i] + number[i+1:]
        return number[:last] + number[last+1:]
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为 $number$ 的长度。即为寻找最佳移除位置和构造移除后字符串的时间复杂度。
-   空间复杂度：$O(n)$，即为生成移除后字符串时辅助字符串的空间开销。
