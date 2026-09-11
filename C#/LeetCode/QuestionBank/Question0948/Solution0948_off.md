### [令牌放置](https://leetcode.cn/problems/bag-of-tokens/solutions/15987/ling-pai-fang-zhi-by-leetcode/)

#### 方法一：贪心

**思路**

如果让我们来玩令牌放置这个游戏，在让令牌正面朝上的时候，肯定要去找能量最小的令牌。同样的，在让令牌反面朝上的时候，肯定要去找能量最大的令牌。

**算法**

只要还有能量，就一直让令牌正面朝上，直到没有能量的时候，让一个令牌反面朝上从而获得能量继续之前的操作。

一定要小心处理边界条件，不然很有可能会写出错误的答案。这里要牢牢记住，在有能量时候，只能让令牌正面朝上，直到能量不够用了才能让令牌反面朝上。

最终答案一定是在一次让令牌正常朝上操作之后产生的（永远不可能在让令牌反面朝上操作之后产生）

```Java
class Solution {
    public int bagOfTokensScore(int[] tokens, int P) {
        Arrays.sort(tokens);
        int lo = 0, hi = tokens.length - 1;
        int points = 0, ans = 0;
        while (lo <= hi && (P >= tokens[lo] || points > 0)) {
            while (lo <= hi && P >= tokens[lo]) {
                P -= tokens[lo++];
                points++;
            }

            ans = Math.max(ans, points);
            if (lo <= hi && points > 0) {
                P += tokens[hi--];
                points--;
            }
        }

        return ans;
    }
}
```

```Python
class Solution(object):
    def bagOfTokensScore(self, tokens, P):
        tokens.sort()
        deque = collections.deque(tokens)
        ans = bns = 0
        while deque and (P >= deque[0] or bns):
            while deque and P >= deque[0]:
                P -= deque.popleft()
                bns += 1
            ans = max(ans, bns)

            if deque and bns:
                P += deque.pop()
                bns -= 1

        return ans
```

**复杂度分析**

- 时间复杂度：$O(N\log N)$，其中 $N$ 是 `tokens` 的大小。
- 空间复杂度：$O(N)$。
