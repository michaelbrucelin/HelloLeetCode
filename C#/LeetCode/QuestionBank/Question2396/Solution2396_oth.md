### [数学证明](https://leetcode.cn/problems/strictly-palindromic-number/solutions/1798736/shu-xue-zheng-ming-by-endlesscheng-8ozj/?envType=problem-list-v2&envId=ySsxoJfz)

本题 [视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1na41137jv) 已出炉，欢迎点赞三连，在评论区分享你对这场双周赛的看法~

---

上联：[return true](https://leetcode.cn/problems/stone-game/)

下联：[return false](https://leetcode.cn/problems/strictly-palindromic-number/)

横批：脑筋急转弯

---

在题目的条件下，答案一定为 `false`，证明如下：

根据带余除法，$n=qb+r$，其中 $0\le r<b$。

取 $b=n-2$，那么当 $n>4$ 时，上式的 $q=1$，r=2，也就是说 $n$ 在 $n-2$ 进制下的数值为 $12$，不是回文数。

而对于 $n=4$，在 $b=2$ 进制下的数值为 $100$，也不是回文数。

因此直接返回 `false` 即可。

```Python
class Solution:
    def isStrictlyPalindromic(self, n: int) -> bool:
        return False
```

```Go
func isStrictlyPalindromic(int) bool {
    return false
}
```
