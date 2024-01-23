### [O(n) 一次遍历（Python/Java/C++/Go）](https://leetcode.cn/problems/count-elements-with-maximum-frequency/solutions/2603738/on-yi-ci-bian-li-pythonjavacgo-by-endles-0jye/)

[视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1zt4y1R7Tc%2F)

遍历 $nums$，同时用哈希表统计每个元素的出现次数，并维护出现次数的最大值 $maxCnt$：

- 如果出现次数 $c > maxCnt$，那么更新 $maxCnt=c$，答案 $ans = c$。
- 如果出现次数 $c = maxCnt$，那么答案增加 $c$。

```python
class Solution:
    def maxFrequencyElements(self, nums: List[int]) -> int:
        ans = max_cnt = 0
        cnt = Counter()
        for x in nums:
            cnt[x] += 1
            c = cnt[x]
            if c > max_cnt:
                max_cnt = ans = c
            elif c == max_cnt:
                ans += c
        return ans
```

```java
class Solution {
    public int maxFrequencyElements(int[] nums) {
        int ans = 0, maxCnt = 0;
        HashMap<Integer, Integer> cnt = new HashMap<>();
        for (int x : nums) {
            int c = cnt.merge(x, 1, Integer::sum);
            if (c > maxCnt) {
                maxCnt = ans = c;
            } else if (c == maxCnt) {
                ans += c;
            }
        }
        return ans;
    }
}
```

```c++
class Solution {
public:
    int maxFrequencyElements(vector<int> &nums) {
        int ans = 0, maxCnt = 0;
        unordered_map<int, int> cnt;
        for (int x : nums) {
            int c = ++cnt[x];
            if (c > maxCnt) {
                maxCnt = ans = c;
            } else if (c == maxCnt) {
                ans += c;
            }
        }
        return ans;
    }
};
```

```go
func maxFrequencyElements(nums []int) (ans int) {
    maxCnt := 0
    cnt := map[int]int{}
    for _, x := range nums {
        cnt[x]++
        c := cnt[x]
        if c > maxCnt {
            maxCnt = c
            ans = c
        } else if c == maxCnt {
            ans += c
        }
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $nums$ 的长度。
- 空间复杂度：$\mathcal{O}(n)$。

[2023 下半年周赛题目总结](https://leetcode.cn/circle/discuss/lUu0KB/)
