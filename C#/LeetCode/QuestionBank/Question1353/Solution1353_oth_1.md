### [扫描算法+贪心](https://leetcode.cn/problems/maximum-number-of-events-that-can-be-attended/solutions/98119/sao-miao-suan-fa-tan-xin-by-lucifer1004/)

这是一道典型的扫描算法题。由于每个时间点最多参加一个会议，我们可以从$1$开始遍历所有时间。

对于每一个时间点，所有在当前时间及之前时间开始，并且在当前时间还未结束的会议都是可参加的。显然，在所有可参加的会议中，选择结束时间最早的会议是最优的，因为其他会议还有更多的机会可以去参加。

怎样动态获得当前结束时间最早的会议呢？我们可以使用一个小根堆记录所有当前可参加会议的结束时间。在每一个时间点，我们首先将当前时间点开始的会议加入小根堆，再把当前已经结束的会议移除出小根堆（因为已经无法参加了），然后从剩下的会议中选择一个结束时间最早的去参加。

为了快速获得当前时间点开始的会议，我们以$O(N)$时间预处理得到每个时间点开始的会议的序号。

算法总的时间复杂度为$O(T\log N)$（这里的$T$为时间范围）。

参考代码

```cpp
const int MAX = 1e5 + 1;

class Solution {
public:
    int maxEvents(vector<vector<int>>& events) {
        vector<vector<int>> left(MAX);
        for (int i = 0; i < events.size(); ++i)
            left[events[i][0]].emplace_back(i);
        
        int ans = 0;
        priority_queue<int, vector<int>, greater<>> pq;
        for (int i = 1; i < MAX; ++i) {
            for (int j : left[i])
                pq.push(events[j][1]);
            while (!pq.empty() && pq.top() < i)
                pq.pop();
            if (!pq.empty()) {
                pq.pop();
                ans++;
            }
        }
        return ans;
    }
};
```
