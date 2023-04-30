#### [同向双指针（滑动窗口）Python/Java/C++/Go](https://leetcode.cn/problems/replace-the-substring-for-balanced-string/solutions/2108358/tong-xiang-shuang-zhi-zhen-hua-dong-chua-z7tu/)

根据题意，如果在待替换子串**之外**的任意字符的出现次数都超过 $m=\dfrac{n}{4}$，那么无论怎么替换，都无法使这个字符的出现次数等于 $m$。

反过来说，如果在待替换子串**之外**的任意字符的出现次数都不超过 $m$，那么可以通过替换，使 $s$ 为平衡字符串，即每个字符的出现次数均为 $m$。

这可以用同向双指针（长度不固定的滑动窗口）实现，具体原理可以看我的[【基础算法精讲】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1hd4y1r7Gq%2F)，看完你就掌握同向双指针啦（APP 用户需要分享到 wx 打开）。

对于本题，设子串的左右端点为 $left$ 和 $right$，枚举 $right$，如果子串**外**的任意字符的出现次数都不超过 $m$，则说明从 $left$ 到 $right$ 的这段子串可以是待替换子串，用其长度 $right−left+1$ 更新答案的最小值，并向右移动 $left$，缩小子串长度。

```python
class Solution:
    def balancedString(self, s: str) -> int:
        cnt, m = Counter(s), len(s) // 4
        if all(cnt[x] == m for x in "QWER"):  # 已经符合要求啦
            return 0
        ans, left = inf, 0
        for right, c in enumerate(s):  # 枚举子串右端点
            cnt[c] -= 1
            while all(cnt[x] <= m for x in "QWER"):
                ans = min(ans, right - left + 1)
                cnt[s[left]] += 1
                left += 1  # 缩小子串
        return ans
```

```java
class Solution {
    public int balancedString(String S) {
        var s = S.toCharArray();
        var cnt = new int['X']; // 也可以用哈希表，不过数组更快一些
        for (var c : s) ++cnt[c];
        int n = s.length, m = n / 4;
        if (cnt['Q'] == m && cnt['W'] == m && cnt['E'] == m && cnt['R'] == m)
            return 0; // 已经符合要求啦
        int ans = n, left = 0;
        for (int right = 0; right < n; right++) { // 枚举子串右端点
            --cnt[s[right]];
            while (cnt['Q'] <= m && cnt['W'] <= m && cnt['E'] <= m && cnt['R'] <= m) {
                ans = Math.min(ans, right - left + 1);
                ++cnt[s[left++]]; // 缩小子串
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int balancedString(string s) {
        int n = s.length(), m = n / 4, cnt['X']{}; // 也可以用哈希表，不过数组更快一些
        for (char c : s) ++cnt[c];
        if (cnt['Q'] == m && cnt['W'] == m && cnt['E'] == m && cnt['R'] == m)
            return 0; // 已经符合要求啦
        int ans = n, left = 0;
        for (int right = 0; right < n; right++) { // 枚举子串右端点
            --cnt[s[right]];
            while (cnt['Q'] <= m && cnt['W'] <= m && cnt['E'] <= m && cnt['R'] <= m) {
                ans = min(ans, right - left + 1);
                ++cnt[s[left++]]; // 缩小子串
            }
        }
        return ans;
    }
};
```

```go
func balancedString(s string) int {
    cnt, m := ['X']int{}, len(s)/4 // 也可以用哈希表，不过数组更快一些
    for _, c := range s {
        cnt[c]++
    }
    if cnt['Q'] == m && cnt['W'] == m && cnt['E'] == m && cnt['R'] == m {
        return 0 // 已经符合要求啦
    }
    ans, left := len(s), 0
    for right, c := range s { // 枚举子串右端点
        cnt[c]--
        for cnt['Q'] <= m && cnt['W'] <= m && cnt['E'] <= m && cnt['R'] <= m {
            ans = min(ans, right-left+1)
            cnt[s[left]]++
            left++ // 缩小子串
        }
    }
    return ans
}

func min(a, b int) int { if a > b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$O(nC)$，其中 $n$ 为 $s$ 的长度，$C=4$。
-   空间复杂度：$O(C)$。如果用哈希表实现，可以做到 $O(C)$。

#### 相似题目（同向双指针）

-   [3\. 无重复字符的最长子串](https://leetcode.cn/problems/longest-substring-without-repeating-characters/)，[题解](https://leetcode.cn/problems/longest-substring-without-repeating-characters/solutions/1959540/xia-biao-zong-suan-cuo-qing-kan-zhe-by-e-iaks/)
-   [209\. 长度最小的子数组](https://leetcode.cn/problems/minimum-size-subarray-sum/)，[题解](https://leetcode.cn/problems/minimum-size-subarray-sum/solutions/1959532/biao-ti-xia-biao-zong-suan-cuo-qing-kan-k81nh/)
-   [713\. 乘积小于 K 的子数组](https://leetcode.cn/problems/subarray-product-less-than-k/)，[题解](https://leetcode.cn/problems/subarray-product-less-than-k/solutions/1959538/xia-biao-zong-suan-cuo-qing-kan-zhe-by-e-jebq/)
