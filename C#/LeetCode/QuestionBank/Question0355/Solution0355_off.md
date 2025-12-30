### [设计推特](https://leetcode.cn/problems/design-twitter/solutions/199331/she-ji-tui-te-by-leetcode-solution/)

#### 方法一：哈希表 + 链表

**思路和算法**

根据题意我们知道，对于每个推特用户，我们需要存储他关注的用户 `Id`，以及自己发的推文 `Id` 的集合，为了使每个操作的复杂度尽可能的低，我们需要根据操作来决定存储这些信息的数据结构。注意，由于题目中没有说明用户的 `Id` 是否连续，所以我们需要用一个以用户 `Id` 为索引的哈希表来存储用户的信息。

对于操作 `3` 和操作 `4`，我们只需要用一个哈希表存储，即可实现插入和删除的时间复杂度都为 $O(1)$。

对于操作 `1` 和操作 `2`，由于操作 `2` 要知道此用户关注的人和用户自己发出的最近十条推文，因此我们可以考虑对每个用户用链表存储发送的推文。每次创建推文的时候我们在链表头插入，这样能保证链表里存储的推文的时间是从最近到最久的。那么对于操作 `2`，问题其实就等价于有若干个有序的链表，我们需要找到它们合起来最近的十条推文。由于链表里存储的数据都是有序的，所以我们将这些链表进行线性归并即可得到最近的十条推文。这个操作与 [23\. 合并K个排序链表](https://leetcode-cn.com/problems/merge-k-sorted-lists/) 基本等同。

![](./assets/img/Solution0355.png)

如果我们直接照搬「合并K个排序链表」的解法来进行合并，那么无疑会造成空间的部分浪费，因为这个题目不要求你展示用户的所有推文，所以我们只要动态维护用户的链表，存储最近的 `recentMax` 个推文 `Id` 即可（题目中的 `recentMax` 为 `10`）。那么对于操作 `1`，当发现链表的节点数等于 `recentMax` 时，我们按题意删除链表末尾的元素，再插入最新的推文 `Id`。对于操作 `2`，在两个链表进行线性归并的时候，只要已合并的数量等于 `recentMax`，代表已经找到这两个链表合起来后最近的 `recentMax` 条推文，直接结束合并即可。

```C++
class Twitter {
    struct Node {
        // 哈希表存储关注人的 Id
        unordered_set<int> followee;
        // 用链表存储 tweetId
        list<int> tweet;
    };
    // getNewsFeed 检索的推文的上限以及 tweetId 的时间戳
    int recentMax, time;
    // tweetId 对应发送的时间
    unordered_map<int, int> tweetTime;
    // 每个用户存储的信息
    unordered_map<int, Node> user;
public:
    Twitter() {
        time = 0;
        recentMax = 10;
        user.clear();
    }

    // 初始化
    void init(int userId) {
        user[userId].followee.clear();
        user[userId].tweet.clear();
    }

    void postTweet(int userId, int tweetId) {
        if (user.find(userId) == user.end()) {
            init(userId);
        }
        // 达到限制，剔除链表末尾元素
        if (user[userId].tweet.size() == recentMax) {
            user[userId].tweet.pop_back();
        }
        user[userId].tweet.push_front(tweetId);
        tweetTime[tweetId] = ++time;
    }

    vector<int> getNewsFeed(int userId) {
        vector<int> ans; ans.clear();
        for (list<int>::iterator it = user[userId].tweet.begin(); it != user[userId].tweet.end(); ++it) {
            ans.emplace_back(*it);
        }
        for (int followeeId: user[userId].followee) {
            if (followeeId == userId) continue; // 可能出现自己关注自己的情况
            vector<int> res; res.clear();
            list<int>::iterator it = user[followeeId].tweet.begin();
            int i = 0;
            // 线性归并
            while (i < (int)ans.size() && it != user[followeeId].tweet.end()) {
                if (tweetTime[(*it)] > tweetTime[ans[i]]) {
                    res.emplace_back(*it);
                    ++it;
                } else {
                    res.emplace_back(ans[i]);
                    ++i;
                }
                // 已经找到这两个链表合起来后最近的 recentMax 条推文
                if ((int)res.size() == recentMax) break;
            }
            for (; i < (int)ans.size() && (int)res.size() < recentMax; ++i) res.emplace_back(ans[i]);
            for (; it != user[followeeId].tweet.end() && (int)res.size() < recentMax; ++it) res.emplace_back(*it);
            ans.assign(res.begin(),res.end());
        }
        return ans;
    }

    void follow(int followerId, int followeeId) {
        if (user.find(followerId) == user.end()) {
            init(followerId);
        }
        if (user.find(followeeId) == user.end()) {
            init(followeeId);
        }
        user[followerId].followee.insert(followeeId);
    }

    void unfollow(int followerId, int followeeId) {
        user[followerId].followee.erase(followeeId);
    }
};
```

```Java
class Twitter {
    private class Node {
        // 哈希表存储关注人的 Id
        Set<Integer> followee;
        // 用链表存储 tweetId
        LinkedList<Integer> tweet;

        Node() {
            followee = new HashSet<Integer>();
            tweet = new LinkedList<Integer>();
        }
    }

    // getNewsFeed 检索的推文的上限以及 tweetId 的时间戳
    private int recentMax, time;
    // tweetId 对应发送的时间
    private Map<Integer, Integer> tweetTime;
    // 每个用户存储的信息
    private Map<Integer, Node> user;

    public Twitter() {
        time = 0;
        recentMax = 10;
        tweetTime = new HashMap<Integer, Integer>();
        user = new HashMap<Integer, Node>();
    }

    // 初始化
    public void init(int userId) {
        user.put(userId, new Node());
    }

    public void postTweet(int userId, int tweetId) {
        if (!user.containsKey(userId)) {
            init(userId);
        }
        // 达到限制，剔除链表末尾元素
        if (user.get(userId).tweet.size() == recentMax) {
            user.get(userId).tweet.remove(recentMax - 1);
        }
        user.get(userId).tweet.addFirst(tweetId);
        tweetTime.put(tweetId, ++time);
    }

    public List<Integer> getNewsFeed(int userId) {
        LinkedList<Integer> ans = new LinkedList<Integer>();
        for (int it : user.getOrDefault(userId, new Node()).tweet) {
            ans.addLast(it);
        }
        for (int followeeId : user.getOrDefault(userId, new Node()).followee) {
            if (followeeId == userId) { // 可能出现自己关注自己的情况
                continue;
            }
            LinkedList<Integer> res = new LinkedList<Integer>();
            int tweetSize = user.get(followeeId).tweet.size();
            Iterator<Integer> it = user.get(followeeId).tweet.iterator();
            int i = 0;
            int j = 0;
            int curr = -1;
            // 线性归并
            if (j < tweetSize) {
                curr = it.next();
                while (i < ans.size() && j < tweetSize) {
                    if (tweetTime.get(curr) > tweetTime.get(ans.get(i))) {
                        res.addLast(curr);
                        ++j;
                        if (it.hasNext()) {
                            curr = it.next();
                        }
                    } else {
                        res.addLast(ans.get(i));
                        ++i;
                    }
                    // 已经找到这两个链表合起来后最近的 recentMax 条推文
                    if (res.size() == recentMax) {
                        break;
                    }
                }
            }
            for (; i < ans.size() && res.size() < recentMax; ++i) {
                res.addLast(ans.get(i));
            }
            if (j < tweetSize && res.size() < recentMax) {
                res.addLast(curr);
                for (; it.hasNext() && res.size() < recentMax;) {
                    res.addLast(it.next());
                }
            }
            ans = new LinkedList<Integer>(res);
        }
        return ans;
    }

    public void follow(int followerId, int followeeId) {
        if (!user.containsKey(followerId)) {
            init(followerId);
        }
        if (!user.containsKey(followeeId)) {
            init(followeeId);
        }
        user.get(followerId).followee.add(followeeId);
    }

    public void unfollow(int followerId, int followeeId) {
        user.getOrDefault(followerId, new Node()).followee.remove(followeeId);
    }
}
```

```Python
class Twitter:

    class Node:
        def __init__(self):
            self.followee = set()
            self.tweet = list()

    def __init__(self):
        self.time = 0
        self.recentMax = 10
        self.tweetTime = dict()
        self.user = dict()

    def postTweet(self, userId: int, tweetId: int) -> None:
        if userId not in self.user:
            self.user[userId] = Twitter.Node()
        self.user[userId].tweet.append(tweetId)
        self.time += 1
        self.tweetTime[tweetId] = self.time

    def getNewsFeed(self, userId: int) -> List[int]:
        if userId not in self.user:
            return list()
        ans = self.user[userId].tweet[-10:][::-1]
        for followeeId in self.user[userId].followee:
            if followeeId in self.user:
                opt = self.user[followeeId].tweet[-10:][::-1]
                i, j, combined = 0, 0, list()
                while i < len(ans) and j < len(opt):
                    if self.tweetTime[ans[i]] > self.tweetTime[opt[j]]:
                        combined.append(ans[i])
                        i += 1
                    else:
                        combined.append(opt[j])
                        j += 1
                combined.extend(ans[i:])
                combined.extend(opt[j:])
                ans = combined[:10]
        return ans

    def follow(self, followerId: int, followeeId: int) -> None:
        if followerId != followeeId:
            if followerId not in self.user:
                self.user[followerId] = Twitter.Node()
            self.user[followerId].followee.add(followeeId)

    def unfollow(self, followerId: int, followeeId: int) -> None:
        if followerId != followeeId:
            if followerId in self.user:
                self.user[followerId].followee.discard(followeeId)
```

**复杂度分析**

- 时间复杂度：
  - 操作 `1`： $O(1)$，链表的插入删除为 $O(1)$ 的复杂度。
  - 操作 `2`： $O(recentMax\times num)$，其中 `recentMax = 10`， `num` 为用户关注的人加上自己的数量和。因为链表里最多存储 `recentMax` 个节点，因此每次合并两个链表最多比较 `recentMax` 次后能得到两个链表最近的 `recentMax` 个推文，一共需要合并 `num` 次，因此总时间复杂度为 $O(recentMax\times num)$。
  - 操作 `3`： $O(1)$，哈希表插入为 $O(1)$ 的复杂度。
  - 操作 `4`： $O(1)$，哈希表插入为 $O(1)$ 的复杂度。
- 空间复杂度：$O(recentMax\times tot)$，其中 `recentMax = 10`，`tot` 为推特总用户数。即对于每个用户我们不会存储超过 `recentMax` 个推特 `Id`，所以空间上限为 $O(recentMax\times tot)$。
