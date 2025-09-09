### [知道秘密的人数](https://leetcode.cn/problems/number-of-people-aware-of-a-secret/solutions/3771803/er-de-mi-shu-zu-zhong-cha-xun-fan-wei-ne-kbs4/)

#### 方法一：模拟 + 双端队列

**思路与算法**

我们可以直接根据题目描述进行模拟。

使用两个双端队列 $know$ 和 $share$，它们分别表示仅知道秘密（但不会分享）和会分享秘密的人。两个双端队列中的每个元素都是一个二元组 $(day,cnt)$，其中 $day$ 表示知晓秘密的时间，$cnt$ 表示在第 $day$ 天知晓秘密的总人数。

初始时，在第一天只有 $1$ 个人知道秘密，并且不会分享，因此 $know=[(1,1)]$，$share=[]$。

在第 $i (2\le i\le n)$ 天时：

1. 第 $i-delay$ 天知晓秘密的人，会开始分享秘密。因此，如果 $know$ 的首元素是 $(i-delay,cnt)$，那么将它移除，并加到 $share$ 的末尾；
2. 第 $i-forget$ 天知晓秘密的人，会忘记秘密。因此，如果 $share$ 的首元素是 $(i-forget,cnt)$，那么将它移除；
3. 所有会分享秘密的人，会给一个新的人分享秘密。因此，需要在 $know$ 的末尾添加 $(i,cnt)$，其中 $cnt$ 是 $share$ 中所有 $cnt$ 的总和。

上述 $1$ 和 $2$ 的时间复杂度都是 $O(1)$，而 $3$ 的时间复杂度是 $O(n)$，因为需要对 $share$ 进行一次遍历。虽然这样已经可以通过本题，但也可以将其优化成 $O(1)$。我们可以用两个变量 $know_{cnt}$ 和 $share_{cnt}$ 分别记录 $know$ 和 $share$ 中所有 $cnt$ 的总和，这样一来，上述的 $1$ 和 $2$ 的时间复杂度不会发生变化，而 $3$ 可以降低至 $O(1)$。

最终的答案即为 $know_{cnt}+share_{cnt}$。

**代码**

```C++
class Solution {
public:
    int peopleAwareOfSecret(int n, int delay, int forget) {
        deque<pair<int, int>> know, share;
        know.emplace_back(1, 1);
        int know_cnt = 1, share_cnt = 0;
        for (int i = 2; i <= n; ++i) {
            if (!know.empty() && know[0].first == i - delay) {
                know_cnt = (know_cnt - know[0].second + mod) % mod;
                share_cnt = (share_cnt + know[0].second) % mod;
                share.push_back(know[0]);
                know.pop_front();
            }
            if (!share.empty() && share[0].first == i - forget) {
                share_cnt = (share_cnt - share[0].second + mod) % mod;
                share.pop_front();
            }
            if (!share.empty()) {
                know_cnt = (know_cnt + share_cnt) % mod;
                know.emplace_back(i, share_cnt);
            }
        }
        return (know_cnt + share_cnt) % mod;
    }

private:
    static constexpr int mod = 1000000007;
};
```

```Python
class Solution:
    def peopleAwareOfSecret(self, n: int, delay: int, forget: int) -> int:
        know, share = deque([(1, 1)]), deque([])
        know_cnt, share_cnt = 1, 0
        for i in range(2, n + 1):
            if know and know[0][0] == i - delay:
                know_cnt -= know[0][1]
                share_cnt += know[0][1]
                share.append(know[0])
                know.popleft()
            if share and share[0][0] == i - forget:
                share_cnt -= share[0][1]
                share.popleft()
            if share:
                know_cnt += share_cnt
                know.append((i, share_cnt))
        return (know_cnt + share_cnt) % (10**9 + 7)
```

```Java
class Solution {
    private static final int MOD = 1000000007;
    
    public int peopleAwareOfSecret(int n, int delay, int forget) {
        Deque<int[]> know = new LinkedList<>();
        Deque<int[]> share = new LinkedList<>();
        know.add(new int[]{1, 1});
        int knowCnt = 1, shareCnt = 0;
        
        for (int i = 2; i <= n; i++) {
            if (!know.isEmpty() && know.peekFirst()[0] == i - delay) {
                int[] first = know.pollFirst();
                knowCnt = (knowCnt - first[1] + MOD) % MOD;
                shareCnt = (shareCnt + first[1]) % MOD;
                share.add(first);
            }
            if (!share.isEmpty() && share.peekFirst()[0] == i - forget) {
                int[] first = share.pollFirst();
                shareCnt = (shareCnt - first[1] + MOD) % MOD;
            }
            if (!share.isEmpty()) {
                knowCnt = (knowCnt + shareCnt) % MOD;
                know.add(new int[]{i, shareCnt});
            }
        }
        return (knowCnt + shareCnt) % MOD;
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1000000007;
    
    public int PeopleAwareOfSecret(int n, int delay, int forget) {
        LinkedList<int[]> know = new LinkedList<int[]>();
        LinkedList<int[]> share = new LinkedList<int[]>();
        know.AddLast(new int[]{1, 1});
        int knowCnt = 1, shareCnt = 0;
        
        for (int i = 2; i <= n; i++) {
            if (know.First != null && know.First.Value[0] == i - delay) {
                int[] first = know.First.Value;
                know.RemoveFirst();
                knowCnt = (knowCnt - first[1] + MOD) % MOD;
                shareCnt = (shareCnt + first[1]) % MOD;
                share.AddLast(first);
            }
            if (share.First != null && share.First.Value[0] == i - forget) {
                int[] first = share.First.Value;
                share.RemoveFirst();
                shareCnt = (shareCnt - first[1] + MOD) % MOD;
            }
            if (share.First != null) {
                knowCnt = (knowCnt + shareCnt) % MOD;
                know.AddLast(new int[]{i, shareCnt});
            }
        }
        return (knowCnt + shareCnt) % MOD;
    }
}
```

```Go
const MOD = 1000000007

type Pair struct {
    day   int
    count int
}

func peopleAwareOfSecret(n int, delay int, forget int) int {
    know := make([]Pair, 0)
    share := make([]Pair, 0)
    know = append(know, Pair{1, 1})
    knowCnt, shareCnt := 1, 0

    for i := 2; i <= n; i++ {
        if len(know) > 0 && know[0].day == i-delay {
            first := know[0]
            know = know[1:]
            knowCnt = (knowCnt - first.count + MOD) % MOD
            shareCnt = (shareCnt + first.count) % MOD
            share = append(share, first)
        }
        if len(share) > 0 && share[0].day == i-forget {
            first := share[0]
            share = share[1:]
            shareCnt = (shareCnt - first.count + MOD) % MOD
        }
        if len(share) > 0 {
            knowCnt = (knowCnt + shareCnt) % MOD
            know = append(know, Pair{i, shareCnt})
        }
    }
    return (knowCnt + shareCnt) % MOD
}
```

```C
#define MOD 1000000007

typedef struct {
    int day;
    int count;
} Pair;

typedef struct {
    Pair* data;
    int front;
    int rear;
    int capacity;
} Queue;

Queue* createQueue(int capacity) {
    Queue* queue = (Queue*)malloc(sizeof(Queue));
    queue->data = (Pair*)malloc(capacity * sizeof(Pair));
    queue->front = 0;
    queue->rear = -1;
    queue->capacity = capacity;
    return queue;
}

int isEmpty(Queue* queue) {
    return queue->rear < queue->front;
}

void enqueue(Queue* queue, Pair item) {
    if (queue->rear == queue->capacity - 1) {
        queue->capacity *= 2;
        queue->data = (Pair*)realloc(queue->data, queue->capacity * sizeof(Pair));
    }
    queue->data[++queue->rear] = item;
}

Pair dequeue(Queue* queue) {
    return queue->data[queue->front++];
}

Pair peek(Queue* queue) {
    return queue->data[queue->front];
}

void freeQueue(Queue *queue) {
    free(queue->data);
    free(queue);
}

int peopleAwareOfSecret(int n, int delay, int forget) {
    Queue* know = createQueue(n);
    Queue* share = createQueue(n);
    
    Pair initial = {1, 1};
    enqueue(know, initial);
    int knowCnt = 1, shareCnt = 0;
    for (int i = 2; i <= n; i++) {
        if (!isEmpty(know) && peek(know).day == i - delay) {
            Pair first = dequeue(know);
            knowCnt = (knowCnt - first.count + MOD) % MOD;
            shareCnt = (shareCnt + first.count) % MOD;
            enqueue(share, first);
        }
        if (!isEmpty(share) && peek(share).day == i - forget) {
            Pair first = dequeue(share);
            shareCnt = (shareCnt - first.count + MOD) % MOD;
        }
        if (!isEmpty(share)) {
            knowCnt = (knowCnt + shareCnt) % MOD;
            Pair newPair = {i, shareCnt};
            enqueue(know, newPair);
        }
    }
    
    freeQueue(know);
    freeQueue(share);

    return (knowCnt + shareCnt) % MOD;
}
```

```JavaScript
var peopleAwareOfSecret = function(n, delay, forget) {
    const MOD = 1000000007;
    const know = new Deque();
    const share = new Deque();
    know.pushBack({day: 1, count: 1});
    let knowCnt = 1, shareCnt = 0;
    
    for (let i = 2; i <= n; i++) {
        if (!know.isEmpty() && know.front().day === i - delay) {
            const first = know.popFront();
            knowCnt = (knowCnt - first.count + MOD) % MOD;
            shareCnt = (shareCnt + first.count) % MOD;
            share.pushBack(first);
        }
        if (!share.isEmpty() && share.front().day === i - forget) {
            const first = share.popFront();
            shareCnt = (shareCnt - first.count + MOD) % MOD;
        }
        if (!share.isEmpty()) {
            knowCnt = (knowCnt + shareCnt) % MOD;
            know.pushBack({day: i, count: shareCnt});
        }
    }
    return (knowCnt + shareCnt) % MOD;
};
```

```TypeScript
function peopleAwareOfSecret(n: number, delay: number, forget: number): number {
    const MOD = 1000000007;
    const know = new Deque<number[]>();
    const share = new Deque<number[]>();
    know.pushBack([1, 1]);
    let knowCnt = 1, shareCnt = 0;
    
    for (let i = 2; i <= n; i++) {
        if (!know.isEmpty() && know.front()[0] === i - delay) {
            const first = know.popFront();
            knowCnt = (knowCnt - first[1] + MOD) % MOD;
            shareCnt = (shareCnt + first[1]) % MOD;
            share.pushBack(first);
        }
        if (!share.isEmpty() && share.front()[0] === i - forget) {
            const first = share.popFront();
            shareCnt = (shareCnt - first[1] + MOD) % MOD;
        }
        if (!share.isEmpty()) {
            knowCnt = (knowCnt + shareCnt) % MOD;
            know.pushBack([i, shareCnt]);
        }
    }
    return (knowCnt + shareCnt) % MOD;
};
```

```Rust
use std::collections::VecDeque;

const MOD: i32 = 1000000007;

impl Solution {
    pub fn people_aware_of_secret(n: i32, delay: i32, forget: i32) -> i32 {
        let n = n as usize;
        let delay = delay as usize;
        let forget = forget as usize;
        
        let mut know: VecDeque<(usize, i32)> = VecDeque::new();
        let mut share: VecDeque<(usize, i32)> = VecDeque::new();
        know.push_back((1, 1));
        let mut know_cnt = 1;
        let mut share_cnt = 0;
        
        for i in 2..=n {
            if let Some(&(day, count)) = know.front() {
                if day == i - delay {
                    let (day, count) = know.pop_front().unwrap();
                    know_cnt = (know_cnt - count + MOD) % MOD;
                    share_cnt = (share_cnt + count) % MOD;
                    share.push_back((day, count));
                }
            }
            
            if let Some(&(day, count)) = share.front() {
                if day == i - forget {
                    let (_, count) = share.pop_front().unwrap();
                    share_cnt = (share_cnt - count + MOD) % MOD;
                }
            }
            
            if !share.is_empty() {
                know_cnt = (know_cnt + share_cnt) % MOD;
                know.push_back((i, share_cnt));
            }
        }
        
        (know_cnt + share_cnt) % MOD
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(n)$。
