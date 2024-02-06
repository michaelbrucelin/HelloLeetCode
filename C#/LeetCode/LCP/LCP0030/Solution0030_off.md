### [魔塔游戏](https://leetcode.cn/problems/p0NxJO/solutions/2628589/mo-ta-you-xi-by-leetcode-solution-gkmj/)

#### 方法一：贪心 + 优先队列

##### 思路

我们按照原计划访问所有房间。当访问到第 $i$ 个房间时，如果生命值小于等于 $0$，那么我们必须要对房间顺序进行调整：

- 显然选择第 $i$ 个房间之后的房间是没有意义的，它并不会改变当前的生命值；
- 因此我们只能选择第 $i$ 个房间及之前的房间。对于所有可选的房间，无论将哪个房间调整至末尾，都不会改变最终的生命值（因为数组 $\textit{nums}$ 的和不会变化）。由于我们希望调整的次数最少，因此应当贪心地选择最小的那个 $\textit{nums}[j]$ 调整至末尾，使得当前的生命值尽可能高。

##### 算法

在遍历房间的过程中，如果 $\textit{nums}[i]$ 为负数，我们将其放入一个小根堆（优先队列）中。当计算完第 $i$ 个房间的生命值影响后，如果生命值小于等于 $0$，那么我们取出堆顶元素，表示将该房间调整至末尾，并将其补回生命值中。由于一定会从小根堆中取出一个小于等于 $\textit{nums}[i]$ 的值，因此调整完成后，生命值一定大于 $0$。

当所有房间遍历完成后，我们还需要将所有从堆中取出元素的和重新加入生命值，如果生命值小于等于 $0$，说明无解。

##### 代码

```c++
class Solution {
public:
    int magicTower(vector<int>& nums) {
        priority_queue<int, vector<int>, greater<int>> q;
        int ans = 0;
        long long hp = 1, delay = 0;
        for (int num: nums) {
            if (num < 0) {
                q.push(num);
            }
            hp += num;
            if (hp <= 0) {
                ++ans;
                delay += q.top();
                hp -= q.top();
                q.pop();
            }
        }
        hp += delay;
        return hp <= 0 ? -1 : ans;
    }
};
```

```java
class Solution {
    public int magicTower(int[] nums) {
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();
        int ans = 0;
        long hp = 1, delay = 0;
        for (int num : nums) {
            if (num < 0) {
                pq.offer(num);
            }
            hp += num;
            if (hp <= 0) {
                ++ans;
                int curr = pq.poll();
                delay += curr;
                hp -= curr;
            }
        }
        hp += delay;
        return hp <= 0 ? -1 : ans;
    }
}
```

```csharp
public class Solution {
    public int MagicTower(int[] nums) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        int ans = 0;
        long hp = 1, delay = 0;
        foreach (int num in nums) {
            if (num < 0) {
                pq.Enqueue(num, num);
            }
            hp += num;
            if (hp <= 0) {
                ++ans;
                int curr = pq.Dequeue();
                delay += curr;
                hp -= curr;
            }
        }
        hp += delay;
        return hp <= 0 ? -1 : ans;
    }
}
```

```python
class Solution:
    def magicTower(self, nums: List[int]) -> int:
        q = list()
        ans, hp, delay = 0, 1, 0
        for num in nums:
            if num < 0:
                heapq.heappush(q, num)
            hp += num
            if hp <= 0:
                ans += 1
                delay += q[0]
                hp -= heapq.heappop(q)
        hp += delay
        return -1 if hp <= 0 else ans
```

```go
type PriorityQueue struct {
    sort.IntSlice
}

func (pq *PriorityQueue) Less(i, j int) bool {
    return pq.IntSlice[i] < pq.IntSlice[j]
}

func (pq *PriorityQueue) Push(v interface{}) {
    pq.IntSlice = append(pq.IntSlice, v.(int))
}

func (pq *PriorityQueue) Pop() interface{} {
    arr := pq.IntSlice
    v := arr[len(arr) - 1]
    pq.IntSlice = arr[:len(arr) - 1]
    return v
}

func magicTower(nums []int) int {
    q := &PriorityQueue{}
    ans, hp, delay := 0, int64(1), int64(0)
    for _, num := range nums {
        if num < 0 {
            heap.Push(q, num)
        }
        hp += int64(num)
        if hp <= 0 {
            ans++
            delay += int64(q.IntSlice[0])
            hp -= int64(heap.Pop(q).(int))
        }
    }
    if hp + delay <= 0 {
        return -1
    }
    return ans
}
```

```c
void swap(int *nums, int i, int j) {
    int x = nums[i];
    nums[i] = nums[j];
    nums[j] = x;
}

void down(int *nums, int size, int i) {
    for (int k = 2 * i + 1; k < size; k = 2 * k + 1) {
        // 父节点 (k - 1) / 2，左子节点 k，右子节点 k + 1
        if (k + 1 < size && nums[k] > nums[k + 1]) {
            k++;
        }
        if (nums[k] > nums[(k - 1) / 2]) {
            break;
        }
        swap(nums, k, (k - 1) / 2);
    }
}

void push(int *nums, int size, int x) {
    nums[size] = x;
    for (int i = size; i > 0 && nums[(i - 1) / 2] > nums[i]; i = (i - 1) / 2) {
        swap(nums, i, (i - 1) / 2);
    }
}

int pop(int *nums, int size) {
    swap(nums, 0, size - 1);
    down(nums, size - 1, 0);
    return nums[size - 1];
}

int magicTower(int *nums, int numsSize){
    int *q = (int *)malloc(sizeof(int) * numsSize);
    int qn = 0;
    int ans = 0;
    long long hp = 1, delay = 0;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        if (num < 0) {
            push(q, qn, num);
            qn++;
        }
        hp += num;
        if (hp <= 0) {
            ans++;
            delay += q[0];
            hp -= pop(q, qn);
            qn--;
        }
    }
    free(q);
    return hp + delay <= 0 ? -1 : ans;
}
```

```javascript
var magicTower = function(nums) {
    const q = new MinPriorityQueue();
    let ans = 0;
    let hp = 1, delay = 0;
    for (const num of nums) {
        if (num < 0) {
            q.enqueue(num);
        }
        hp += num;
        if (hp <= 0) {
            ++ans;
            delay += q.front().element;
            hp -= q.front().element;
            q.dequeue();
        }
    }
    hp += delay;
    return hp <= 0 ? -1 : ans;
};
```

```typescript
function magicTower(nums: number[]): number {
    const q = new MinPriorityQueue();
    let ans = 0;
    let hp = 1, delay = 0;
    for (const num of nums) {
        if (num < 0) {
            q.enqueue(num);
        }
        hp += num;
        if (hp <= 0) {
            ++ans;
            delay += q.front().element;
            hp -= q.front().element;
            q.dequeue();
        }
    }
    hp += delay;
    return hp <= 0 ? -1 : ans;
};
```

#### 复杂度分析

- 时间复杂度：$O(n \log n)$。数组 $\textit{nums}$ 中的每个元素至多进入和退出优先队列各一次，每一次优先队列操作的时间复杂度为 $O(\log n)$。
- 空间复杂度：$O(n)$，即为优先队列需要的空间。
