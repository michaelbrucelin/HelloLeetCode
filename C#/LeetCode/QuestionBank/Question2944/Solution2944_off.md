### [购买水果需要的最少金币数](https://leetcode.cn/problems/minimum-number-of-coins-for-fruits/solutions/3046625/gou-mai-shui-guo-xu-yao-de-zui-shao-jin-f6rsy/)

#### 方法一：记忆化搜索

**思路**

首先我们将题目中的数组看成以 $0$ 开始的。这样题目的促销活动就变成了，如果购买了下标为 $i$ 的水果，就可以免费获得下标范围在 $[i+1,2 \times i+2]$ 之间的所有水果。这一步是可选的，并不影响最终的结果。

接下来我们一步步考虑，下标为 $0$ 的水果是必须购买的，不存在可以免费获得的情况。因此，我需要花费 $prices[0]$ 来购买，并且，我可以免费获得下标范围在 $[1,2]$ 之间的所有水果，然后必须去购买下标为 $3$ 的水果。我也可以再购买下标为 $1$ 的水果，这样我可以免费获得下标范围在 $[2,4]$ 之间的所有水果。不能保证哪种方式更便宜，需要都计算出来比较大小。我们发现上述的购买下标为 $0$ 的水果和购买下标为 $1$ 的水果是不同的子问题，我们可以将它抽象成不同的状态来分别计算。

定义函数 $dp$，参数是下标 $index$，表示求解购买从下标 $index$ 开始的所有水果需要花费的最少金币。首先，下标为 $index$ 的水果必须购买。接下来，赠送的水果我都可买可不买，分别计算各自的金币，求出最小值后返回结果。最终返回 $dp[0]$。注意到递归函数中有许多中间状态，我们利用记忆化递归的方式来降低时间复杂度。

**代码**

```Python
class Solution:
    def minimumCoins(self, prices: List[int]) -> int:

        @cache
        def dp(index: int) -> int:
            if 2 * index + 2 >= len(prices):
                return prices[index]
            return prices[index] + min(dp(i) for i in range(index + 1, 2 * index + 3))
        return dp(0)
```

```Java
class Solution {
    Map<Integer, Integer> memo = new HashMap<Integer, Integer>();
    int[] prices;

    public int minimumCoins(int[] prices) {
        this.prices = prices;
        return dp(0);
    }

    public int dp(int index) {
        if (2 * index + 2 >= prices.length) {
            return prices[index];
        }
        if (!memo.containsKey(index)) {
            int minValue = Integer.MAX_VALUE;
            for (int i = index + 1; i <= 2 * index + 2; i++) {
                minValue = Math.min(minValue, dp(i));
            }
            memo.put(index, prices[index] + minValue);
        }
        return memo.get(index);
    }
}
```

```CSharp
public class Solution {
    IDictionary<int, int> memo = new Dictionary<int, int>();
    int[] prices;

    public int MinimumCoins(int[] prices) {
        this.prices = prices;
        return DP(0);
    }

    public int DP(int index) {
        if (2 * index + 2 >= prices.Length) {
            return prices[index];
        }
        if (!memo.ContainsKey(index)) {
            int minValue = int.MaxValue;
            for (int i = index + 1; i <= 2 * index + 2; i++) {
                minValue = Math.Min(minValue, DP(i));
            }
            memo.Add(index, prices[index] + minValue);
        }
        return memo[index];
    }
}
```

```C++
class Solution {
public:
    int minimumCoins(vector<int>& prices) {
        unordered_map<int, int> memo;

        function<int(int)> dp = [&](int index) -> int {
            if (2 * index + 2 >= prices.size()) {
                return prices[index];
            }
            if (!memo.count(index)) {
                int minValue = INT_MAX;
                for (int i = index + 1; i <= 2 * index + 2; i++) {
                    minValue = min(minValue, dp(i));
                }
                memo[index] = prices[index] + minValue;
            }
            return memo[index];
        };

        return dp(0);
    }
};
```

```Go
func minimumCoins(prices []int) int {
    memo := make(map[int]int)

    var dp func(index int) int
    dp = func(index int) int {
        if 2 * index + 2 >= len(prices) {
            return prices[index]
        }
        if val, ok := memo[index]; ok {
            return val
        }
        minValue := math.MaxInt32
        for i := index + 1; i <= 2*index+2; i++ {
            minValue = min(minValue, dp(i))
        }
        memo[index] = prices[index] + minValue
        return memo[index]
    }

    return dp(0)
}
```

```C
int dp(int* prices, int pricesSize, int index, int* memo) {
    if (2 * index + 2 >= pricesSize) {
        return prices[index];
    }
    if (memo[index] == -1) {
        int minValue = INT_MAX;
        for (int i = index + 1; i <= 2 * index + 2; i++) {
            minValue = fmin(minValue, dp(prices, pricesSize, i, memo));
        }
        memo[index] = prices[index] + minValue;
    }
    return memo[index];
}

int minimumCoins(int* prices, int pricesSize) {
    int *memo = (int*)malloc(pricesSize * sizeof(int));
    for (int i = 0; i < pricesSize; i++) {
        memo[i] = -1;
    }
    return dp(prices, pricesSize, 0, memo);
}
```

```JavaScript
var minimumCoins = function(prices) {
    const memo = new Map();

    const dp = (index) => {
        if (2 * index + 2 >= prices.length) {
            return prices[index];
        }
        if (!memo.has(index)) {
            let minValue = Infinity;
            for (let i = index + 1; i <= 2 * index + 2; i++) {
                minValue = Math.min(minValue, dp(i));
            }
            memo.set(index, prices[index] + minValue);
        }
        return memo.get(index);
    };

    return dp(0);
};
```

```TypeScript
function minimumCoins(prices: number[]): number {
    const memo: Map<number, number> = new Map();

    const dp = (index: number): number => {
        if (2 * index + 2 >= prices.length) {
            return prices[index];
        }
        if (!memo.has(index)) {
            let minValue = Infinity;
            for (let i = index + 1; i <= 2 * index + 2; i++) {
                minValue = Math.min(minValue, dp(i));
            }
            memo.set(index, prices[index] + minValue);
        }
        return memo.get(index)!;
    };

    return dp(0);
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn minimum_coins(prices: Vec<i32>) -> i32 {
        let mut memo: HashMap<usize, i32> = HashMap::new();

        fn dp(prices: &Vec<i32>, memo: &mut HashMap<usize, i32>, index: usize) -> i32 {
            if 2 * index + 2 >= prices.len() {
                return prices[index];
            }
            if !memo.contains_key(&index) {
                let mut min_value = i32::MAX;
                for i in index + 1..=2 * index + 2 {
                    min_value = min_value.min(dp(prices, memo, i));
                }
                memo.insert(index, prices[index] + min_value);
            }
            *memo.get(&index).unwrap()
        }

        dp(&prices, &mut memo, 0)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $prices$ 的长度。动态规划共有 $O(n)$ 中状态，每种状态消耗 $O(n)$ 时间计算。
- 空间复杂度：$O(n)$。

#### 方法二：单调队列优化时间复杂度

**思路**

观察到上个题解代码中，求解每个状态都需要消耗 $O(n)$ 时间，这主要是消耗在了子数组求最小值的上。并且发现这个子数组的左端点和右端点都是随下标递增的，我们可以利用单调队列来快速求出最小值。设计单调队列时，我们仍然把下标小的元素放左边，下标大的元素放右边，值的大小从左往右则递减。我们需要倒序遍历下标，每次遍历一个下标时，先从右边删除下标不满足条件的元素，然后从右边取出最小值。加上当前的 $prices$ 之后，还需要将它从左边插入队列。为了保证队列是递减的，插之前需要将左端点大于当前金币的元素都删除。这样就能保证队列单调递减，右端点的元素是最小值。最后返回左端点的元素即可。

**代码**

```Python
class Solution:
    def minimumCoins(self, prices: List[int]) -> int:
        n = len(prices)
        q = deque([[n, 0]])
        for i in range(n - 1, -1, -1):
            while q[-1][0] >= 2 * i + 3:
                q.pop()
            cur = q[-1][1] + prices[i]
            while q[0][1] >= cur:
                q.popleft()
            q.appendleft([i, cur])
        return q[0][1]
```

```Java
class Solution {
    public int minimumCoins(int[] prices) {
        int n = prices.length;
        Deque<int[]> queue = new ArrayDeque<int[]>();
        queue.offerFirst(new int[]{n, 0});
        for (int i = n - 1; i >= 0; i--) {
            while (queue.peekLast()[0] >= 2 * i + 3) {
                queue.pollLast();
            }
            int cur = queue.peekLast()[1] + prices[i];
            while (queue.peekFirst()[1] >= cur) {
                queue.pollFirst();
            }
            queue.offerFirst(new int[]{i, cur});
        }
        return queue.peekFirst()[1];
    }
}
```

```CSharp
public class Solution {
    public int MinimumCoins(int[] prices) {
        int n = prices.Length;
        var queue = new LinkedList<int[]>();
        queue.AddFirst(new int[] {n, 0});
        for (int i = n - 1; i >= 0; i--) {
            while (queue.Last.Value[0] >= 2 * i + 3) {
                queue.RemoveLast();
            }
            int cur = queue.Last.Value[1] + prices[i];
            while (queue.First.Value[1] >= cur) {
                queue.RemoveFirst();
            }
            queue.AddFirst(new int[] { i, cur });
        }
        return queue.First.Value[1];
    }
}
```

```C++
class Solution {
public:
    int minimumCoins(vector<int>& prices) {
        int n = prices.size();
        deque<pair<int, int>> queue;
        queue.push_front({n, 0});
        for (int i = n - 1; i >= 0; i--) {
            while (!queue.empty() && queue.back().first >= 2 * i + 3) {
                queue.pop_back();
            }
            int cur = queue.back().second + prices[i];
            while (!queue.empty() && queue.front().second >= cur) {
                queue.pop_front();
            }
            queue.push_front({i, cur});
        }
        return queue.front().second;
    }
};
```

```Go
func minimumCoins(prices []int) int {
    n := len(prices)
    queue := [][2]int{{n, 0}}

    for i := n - 1; i >= 0; i-- {
        for len(queue) > 0 && queue[len(queue) - 1][0] >= 2 * i + 3 {
            queue = queue[:len(queue)-1]
        }
        cur := queue[len(queue) - 1][1] + prices[i]
        for len(queue) > 0 && queue[0][1] >= cur {
            queue = queue[1:]
        }
        queue = append([][2]int{{i, cur}}, queue...)
    }
    
    return queue[0][1]
}
```

```C
typedef struct {
    int index;
    int value;
} Pair;

typedef struct Node {
    Pair data;
    struct Node *prev;
    struct Node *next;
} Node;

typedef struct {
    Node *head;
    Node *tail;
    int queueSize;
} Dequeue;

Node* createNode(int index, int value) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->data.index = index;
    obj->data.value = value;
    obj->prev = NULL;
    obj->next = NULL;
    return obj;
}

Dequeue *createDequeue() {
    Dequeue *obj = (Dequeue *)malloc(sizeof(Dequeue));
    obj->head = NULL;
    obj->tail = NULL;
    obj->queueSize = 0;
    return obj;
}

int isEmpty(Dequeue* q) {
    return q->queueSize == 0;
}

void pushFront(Dequeue* q, int index, int value) {
    Node *obj = createNode(index, value);
    if (isEmpty(q)) {
        q->head = q->tail = obj;
    } else {
        obj->next = q->head;
        q->head->prev = obj;
        q->head = obj;
    }
    q->queueSize++;
}

void popFront(Dequeue* q) {
    if (!isEmpty(q)) {
        q->head = q->head->next;
        if (q->head != NULL) {
            free(q->head->prev);
            q->head->prev = NULL;
        }
        q->queueSize--;
    }
}

void pushBack(Dequeue* q, int index, int value) {
    Node *obj = createNode(index, value);
    if (isEmpty(q)) {
        q->head = q->tail = obj;
    } else {
        q->tail->next = obj;
        obj->prev = q->tail;
        q->tail = obj;
    }
    q->queueSize++;
}

void popBack(Dequeue* q) {
    if (!isEmpty(q)) {
        q->tail = q->tail->prev;
        if (q->tail != NULL) {
            free(q->tail->next);
            q->tail->next = NULL;
        }
        q->queueSize--;
    }
}

Pair peekFirst(Dequeue *q) {
    return q->head->data;
}

Pair peekLast(Dequeue *q) {
    return q->tail->data;
}

void freeDequeue(Dequeue* q) {
    while (q->head->next) {
        Node *node = q->head;
        q->head = q->head->next;
        free(node);
    }
    free(q);
}

int minimumCoins(int* prices, int pricesSize) {
    Dequeue* queue = createDequeue();
    pushFront(queue, pricesSize, 0);
    for (int i = pricesSize - 1; i >= 0; i--) {
        while (!isEmpty(queue) && peekLast(queue).index >= 2 * i + 3) {
            popBack(queue);
        }
        int cur = peekLast(queue).value + prices[i];
        while (!isEmpty(queue) && peekFirst(queue).value >= cur) {
            popFront(queue);
        }
        pushFront(queue, i, cur);
    }
    int result = peekFirst(queue).value;
    freeDequeue(queue);
    return result;
}
```

```JavaScript
var minimumCoins = function(prices) {
    const n = prices.length;
    const queue = [];
    queue.push([n, 0]);
    for (let i = n - 1; i >= 0; i--) {
        while (queue[queue.length - 1][0] >= 2 * i + 3) {
            queue.pop();
        }
        let cur = queue[queue.length - 1][1] + prices[i];
        while (queue[0][1] >= cur) {
            queue.shift();
        }
        queue.unshift([i, cur]);
    }
    return queue[0][1];
};
```

```TypeScript
function minimumCoins(prices: number[]): number {
    const n = prices.length;
    const queue: [number, number][] = [];
    queue.push([n, 0]);
    for (let i = n - 1; i >= 0; i--) {
        while (queue[queue.length - 1][0] >= 2 * i + 3) {
            queue.pop();
        }
        let cur = queue[queue.length - 1][1] + prices[i];
        while (queue[0][1] >= cur) {
            queue.shift();
        }
        queue.unshift([i, cur]);
    }
    return queue[0][1];
};
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn minimum_coins(prices: Vec<i32>) -> i32 {
        let n = prices.len();
        let mut queue: VecDeque<(usize, i32)> = VecDeque::new();
        queue.push_front((n, 0));
        for i in (0..n).rev() {
            while let Some(&(last_index, _)) = queue.back() {
                if last_index >= 2 * i + 3 {
                    queue.pop_back();
                } else {
                    break;
                }
            }
            let cur = queue.back().unwrap().1 + prices[i];
            while let Some(&(first_index, first_value)) = queue.front() {
                if first_value >= cur {
                    queue.pop_front();
                } else {
                    break;
                }
            }
            queue.push_front((i, cur));
        }
        queue.front().unwrap().1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $prices$ 的长度。每个元素只会被插入单调队列一次。
- 空间复杂度：$O(n)$。
