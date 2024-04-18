### [库存管理 III](https://leetcode.cn/problems/zui-xiao-de-kge-shu-lcof/solutions/159342/zui-xiao-de-kge-shu-by-leetcode-solution/)

#### 方法一：排序

##### 思路和算法

对原数组从小到大排序后取出前 $cnt$ 个数即可。

##### 代码

```c++
class Solution {
public:
    vector<int> inventoryManagement(vector<int>& stock, int cnt) {
        vector<int> vec(cnt, 0);
        sort(stock.begin(), stock.end());
        for (int i = 0; i < cnt; ++i) {
            vec[i] = stock[i];
        }
        return vec;
    }
};
```

```java
class Solution {
    public int[] inventoryManagement(int[] stock, int cnt) {
        int[] vec = new int[cnt];
        stockays.sort(stock);
        for (int i = 0; i < cnt; ++i) {
            vec[i] = stock[i];
        }
        return vec;
    }
}
```

```python
class Solution:
    def inventoryManagement(self, stock: List[int], cnt: int) -> List[int]:
        stock.sort()
        return stock[:cnt]
```

##### 复杂度分析

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 `stock` 的长度。算法的时间复杂度即排序的时间复杂度。
- 空间复杂度：$O(\log n)$，排序所需额外的空间复杂度为 $O(\log n)$。

#### 方法二：堆

##### 思路和算法

我们用一个大根堆实时维护数组的前 $cnt$ 小值。首先将前 $cnt$ 个数插入大根堆中，随后从第 $cnt+1$ 个数开始遍历，如果当前遍历到的数比大根堆的堆顶的数要小，就把堆顶的数弹出，再插入当前遍历到的数。最后将大根堆里的数存入数组返回即可。在下面的代码中，由于 C++ 语言中的堆（即优先队列）为大根堆，我们可以这么做。而 Python 语言中的堆为小根堆，因此我们要对数组中所有的数取其相反数，才能使用小根堆维护前 $cnt$ 小值。

##### 代码

```c++
class Solution {
public:
    vector<int> inventoryManagement(vector<int>& stock, int cnt) {
        vector<int> vec(cnt, 0);
        if (cnt == 0) { // 排除 0 的情况
            return vec;
        }
        priority_queue<int> Q;
        for (int i = 0; i < cnt; ++i) {
            Q.push(stock[i]);
        }
        for (int i = cnt; i < (int)stock.size(); ++i) {
            if (Q.top() > stock[i]) {
                Q.pop();
                Q.push(stock[i]);
            }
        }
        for (int i = 0; i < cnt; ++i) {
            vec[i] = Q.top();
            Q.pop();
        }
        return vec;
    }
};
```

```java
class Solution {
    public int[] inventoryManagement(int[] stock, int cnt) {
        int[] vec = new int[cnt];
        if (cnt == 0) { // 排除 0 的情况
            return vec;
        }
        PriorityQueue<Integer> queue = new PriorityQueue<Integer>(new Comparator<Integer>() {
            public int compare(Integer num1, Integer num2) {
                return num2 - num1;
            }
        });
        for (int i = 0; i < cnt; ++i) {
            queue.offer(stock[i]);
        }
        for (int i = cnt; i < stock.length; ++i) {
            if (queue.peek() > stock[i]) {
                queue.poll();
                queue.offer(stock[i]);
            }
        }
        for (int i = 0; i < cnt; ++i) {
            vec[i] = queue.poll();
        }
        return vec;
    }
}
```

```python
class Solution:
    def inventoryManagement(self, stock: List[int], cnt: int) -> List[int]:
        if cnt == 0:
            return list()

        hp = [-x for x in stock[:cnt]]
        heapq.heapify(hp)
        for i in range(cnt, len(stock)):
            if -hp[0] > stock[i]:
                heapq.heappop(hp)
                heapq.heappush(hp, -stock[i])
        ans = [-x for x in hp]
        return ans
```

##### 复杂度分析

- 时间复杂度：$O(n\log cnt)$，其中 $n$ 是数组 `stock` 的长度。由于大根堆实时维护前 $cnt$ 小值，所以插入删除都是 $O(\log cnt)$ 的时间复杂度，最坏情况下数组里 $n$ 个数都会插入，所以一共需要 $O(n\log cnt)$ 的时间复杂度。
- 空间复杂度：$O(cnt)$，因为大根堆里最多 $cnt$ 个数。

#### 方法三：快排思想

##### 思路和算法

我们可以借鉴快速排序的思想。我们知道快排的划分函数每次执行完后都能将数组分成两个部分，小于等于分界值 `pivot` 的元素的都会被放到数组的左边，大于的都会被放到数组的右边，然后返回分界值的下标。与快速排序不同的是，快速排序会根据分界值的下标递归处理划分的两侧，而这里我们只处理划分的一边。

我们定义函数 `randomized_selected(stock, l, r, cnt)` 表示划分数组 `stock` 的 `[l,r]` 部分，使前 `cnt` 小的数在数组的左侧，在函数里我们调用快排的划分函数，假设划分函数返回的下标是 `pos`（表示分界值 `pivot` 最终在数组中的位置），即 `pivot` 是数组中第 `pos - l + 1` 小的数，那么一共会有三种情况：

- 如果 `pos - l + 1 == cnt`，表示 `pivot` 就是第 $cnt$ 小的数，直接返回即可；
- 如果 `pos - l + 1 < cnt`，表示第 $cnt$ 小的数在 `pivot` 的右侧，因此递归调用 `randomized_selected(stock, pos + 1, r, cnt - (pos - l + 1))`；
- 如果 `pos - l + 1 > cnt`，表示第 $cnt$ 小的数在 `pivot` 的左侧，递归调用 `randomized_selected(stock, l, pos - 1, cnt)`。

函数递归入口为 `randomized_selected(stock, 0, stock.length - 1, cnt)`。在函数返回后，将前 `cnt` 个数放入答案数组返回即可。

##### 代码

```c++
class Solution {
    int partition(vector<int>& nums, int l, int r) {
        int pivot = nums[r];
        int i = l - 1;
        for (int j = l; j <= r - 1; ++j) {
            if (nums[j] <= pivot) {
                i = i + 1;
                swap(nums[i], nums[j]);
            }
        }
        swap(nums[i + 1], nums[r]);
        return i + 1;
    }

    // 基于随机的划分
    int randomized_partition(vector<int>& nums, int l, int r) {
        int i = rand() % (r - l + 1) + l;
        swap(nums[r], nums[i]);
        return partition(nums, l, r);
    }

    void randomized_selected(vector<int>& stock, int l, int r, int cnt) {
        if (l >= r) {
            return;
        }
        int pos = randomized_partition(stock, l, r);
        int num = pos - l + 1;
        if (cnt == num) {
            return;
        } else if (cnt < num) {
            randomized_selected(stock, l, pos - 1, cnt);
        } else {
            randomized_selected(stock, pos + 1, r, cnt - num);
        }
    }

public:
    vector<int> inventoryManagement(vector<int>& stock, int cnt) {
        srand((unsigned)time(NULL));
        randomized_selected(stock, 0, (int)stock.size() - 1, cnt);
        vector<int> vec;
        for (int i = 0; i < cnt; ++i) {
            vec.push_back(stock[i]);
        }
        return vec;
    }
};
```

```java
class Solution {
    public int[] inventoryManagement(int[] stock, int cnt) {
        randomizedSelected(stock, 0, stock.length - 1, cnt);
        int[] vec = new int[cnt];
        for (int i = 0; i < cnt; ++i) {
            vec[i] = stock[i];
        }
        return vec;
    }

    private void randomizedSelected(int[] stock, int l, int r, int cnt) {
        if (l >= r) {
            return;
        }
        int pos = randomizedPartition(stock, l, r);
        int num = pos - l + 1;
        if (cnt == num) {
            return;
        } else if (cnt < num) {
            randomizedSelected(stock, l, pos - 1, cnt);
        } else {
            randomizedSelected(stock, pos + 1, r, cnt - num);
        }
    }

    // 基于随机的划分
    private int randomizedPartition(int[] nums, int l, int r) {
        int i = new Random().nextInt(r - l + 1) + l;
        swap(nums, r, i);
        return partition(nums, l, r);
    }

    private int partition(int[] nums, int l, int r) {
        int pivot = nums[r];
        int i = l - 1;
        for (int j = l; j <= r - 1; ++j) {
            if (nums[j] <= pivot) {
                i = i + 1;
                swap(nums, i, j);
            }
        }
        swap(nums, i + 1, r);
        return i + 1;
    }

    private void swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
```

```python
class Solution:
    def partition(self, nums, l, r):
        pivot = nums[r]
        i = l - 1
        for j in range(l, r):
            if nums[j] <= pivot:
                i += 1
                nums[i], nums[j] = nums[j], nums[i]
        nums[i + 1], nums[r] = nums[r], nums[i + 1]
        return i + 1

    def randomized_partition(self, nums, l, r):
        i = random.randint(l, r)
        nums[r], nums[i] = nums[i], nums[r]
        return self.partition(nums, l, r)

    def randomized_selected(self, stock, l, r, cnt):
        pos = self.randomized_partition(stock, l, r)
        num = pos - l + 1
        if cnt < num:
            self.randomized_selected(stock, l, pos - 1, cnt)
        elif cnt > num:
            self.randomized_selected(stock, pos + 1, r, cnt - num)

    def inventoryManagement(self, stock: List[int], cnt: int) -> List[int]:
        if cnt == 0:
            return list()
        self.randomized_selected(stock, 0, len(stock) - 1, cnt)
        return stock[:cnt]
```

##### 复杂度分析

- 时间复杂度：期望为 $O(n)$，由于证明过程很繁琐，所以不在这里展开讲。具体证明可以参考《算法导论》第 9 章第 2 小节。
    最坏情况下的时间复杂度为 $O(n^2)$。情况最差时，每次的划分点都是最大值或最小值，一共需要划分 $n - 1$ 次，而一次划分需要线性的时间复杂度，所以最坏情况下时间复杂度为 $O(n^2)$。
- 空间复杂度：期望为 $O(\log n)$，递归调用的期望深度为 $O(\log n)$，每层需要的空间为 $O(1)$，只有常数个变量。
    最坏情况下的空间复杂度为 $O(n)$。最坏情况下需要划分 $n$ 次，即 randomized_selected 函数递归调用最深 $n - 1$ 层，而每层由于需要 $O(1)$ 的空间，所以一共需要 $O(n)$ 的空间复杂度。
