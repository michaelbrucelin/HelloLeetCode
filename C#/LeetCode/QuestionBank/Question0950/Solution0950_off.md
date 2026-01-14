### [按递增顺序显示卡牌](https://leetcode.cn/problems/reveal-cards-in-increasing-order/solutions/15988/an-di-zeng-shun-xu-xian-shi-qia-pai-by-leetcode/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一： 模拟法

**思路和算法**

直接模拟从牌组中取牌的过程就可以了。举个例子，如果从牌组中以 `[0, 2, 4, ...]` 的顺序取牌，我们只需要把最小的牌放在下标为 `0` 的地方，第二小的牌放在下标为 `1` 的地方，第三小的牌放在下标为 `4` 的地方，依次类推即可。

```Java
class Solution {
    public int[] deckRevealedIncreasing(int[] deck) {
        int N = deck.length;
        Deque<Integer> index = new LinkedList();
        for (int i = 0; i < N; ++i)
            index.add(i);

        int[] ans = new int[N];
        Arrays.sort(deck);
        for (int card: deck) {
            ans[index.pollFirst()] = card;
            if (!index.isEmpty())
                index.add(index.pollFirst());
        }

        return ans;
    }
}
```

```Python
class Solution(object):
    def deckRevealedIncreasing(self, deck):
        N = len(deck)
        index = collections.deque(range(N))
        ans = [None] * N

        for card in sorted(deck):
            ans[index.popleft()] = card
            if index:
                index.append(index.popleft())

        return ans
```

**复杂度分析**

- 时间复杂度：$ O(N\log N)$，其中 $N$ 是牌组的大小。
- 空间复杂度：$ O(N)$。
