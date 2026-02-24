### [数组中的第 $k$ 大的数字](https://leetcode.cn/problems/xx4gT2/solutions/1398893/shu-zu-zhong-de-di-k-da-de-shu-zi-by-lee-6doi/)

#### 前言

- 约定：假设这里数组的长度为 $n$。
- 题目分析：本题希望我们返回数组排序之后的倒数第 $k$ 个位置。

#### 方法一：基于快速排序的选择方法

**思路和算法**

我们可以用快速排序来解决这个问题，先对原数组排序，再返回倒数第 $k$ 个位置，这样平均时间复杂度是 $O(n\log n)$，但其实我们可以做的更快。

首先我们来回顾一下快速排序，这是一个典型的分治算法。我们对数组 $a[l\dots r]$ 做快速排序的过程是（参考《算法导论》）：

- **分解：** 将数组 $a[l\dots r]$ 「划分」成两个子数组 $a[l\dots$ q-1]、a[q+1\dots $r]$，使得 $a[l\dots q-1]$ 中的每个元素小于等于 $a[q]$，且 $a[q]$ 小于等于 $a[q+1\dots r]$ 中的每个元素。其中，计算下标 $q$ 也是「划分」过程的一部分。
- **解决：** 通过递归调用快速排序，对子数组 $a[l\dots q-1]$ 和 $a[q+1\dots r]$ 进行排序。
- **合并：** 因为子数组都是原址排序的，所以不需要进行合并操作，$a[l\dots r]$ 已经有序。
- 上文中提到的 **「划分」** 过程是：从子数组 $a[l\dots r]$ 中选择任意一个元素 $x$ 作为主元，**调整子数组的元素使得左边的元素都小于等于它，右边的元素都大于等于它，** x 的最终位置就是 $q$。

由此可以发现每次经过「划分」操作后，我们一定可以确定一个元素的最终位置，即 $x$ 的最终位置为 $q$，并且保证 $a[l\dots q-1]$ 中的每个元素小于等于 $a[q]$，且 $a[q]$ 小于等于 $a[q+1\dots r]$ 中的每个元素。**所以只要某次划分的 $q$ 为倒数第 $k$ 个下标的时候，我们就已经找到了答案。** 我们只关心这一点，至于 $a[l\dots q-1]$ 和 $a[q+1\dots r]$ 是否是有序的，我们不关心。

因此我们可以改进快速排序算法来解决这个问题：在分解的过程当中，我们会对子数组进行划分，如果划分得到的 $q$ 正好就是我们需要的下标，就直接返回 $a[q]$；否则，如果 $q$ 比目标下标小，就递归右子区间，否则递归左子区间。这样就可以把原来递归两个区间变成只递归一个区间，提高了时间效率。这就是「快速选择」算法。

我们知道快速排序的性能和「划分」出的子数组的长度密切相关。直观地理解如果每次规模为 $n$ 的问题我们都划分成 $1$ 和 $n-1$，每次递归的时候又向 $n-1$ 的集合中递归，这种情况是最坏的，时间代价是 $O(n2)$。我们可以引入随机化来加速这个过程，它的时间代价的期望是 $O(n)$，证明过程可以参考「《算法导论》9.2：期望为线性的选择算法」。

**代码**

```C++
class Solution {
public:
    int quickSelect(vector<int>& a, int l, int r, int index) {
        int q = randomPartition(a, l, r);
        if (q == index) {
            return a[q];
        } else {
            return q < index ? quickSelect(a, q + 1, r, index) : quickSelect(a, l, q - 1, index);
        }
    }

    inline int randomPartition(vector<int>& a, int l, int r) {
        int i = rand() % (r - l + 1) + l;
        swap(a[i], a[r]);
        return partition(a, l, r);
    }

    inline int partition(vector<int>& a, int l, int r) {
        int x = a[r], i = l - 1;
        for (int j = l; j < r; ++j) {
            if (a[j] <= x) {
                swap(a[++i], a[j]);
            }
        }
        swap(a[i + 1], a[r]);
        return i + 1;
    }

    int findKthLargest(vector<int>& nums, int k) {
        srand(time(0));
        return quickSelect(nums, 0, nums.size() - 1, nums.size() - k);
    }
};
```

```Java
class Solution {
    Random random = new Random();

    public int findKthLargest(int[] nums, int k) {
        return quickSelect(nums, 0, nums.length - 1, nums.length - k);
    }

    public int quickSelect(int[] a, int l, int r, int index) {
        int q = randomPartition(a, l, r);
        if (q == index) {
            return a[q];
        } else {
            return q < index ? quickSelect(a, q + 1, r, index) : quickSelect(a, l, q - 1, index);
        }
    }

    public int randomPartition(int[] a, int l, int r) {
        int i = random.nextInt(r - l + 1) + l;
        swap(a, i, r);
        return partition(a, l, r);
    }

    public int partition(int[] a, int l, int r) {
        int x = a[r], i = l - 1;
        for (int j = l; j < r; ++j) {
            if (a[j] <= x) {
                swap(a, ++i, j);
            }
        }
        swap(a, i + 1, r);
        return i + 1;
    }

    public void swap(int[] a, int i, int j) {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }
}
```

```C
inline int partition(int* a, int l, int r) {
    int x = a[r], i = l - 1;
    for (int j = l; j < r; ++j) {
        if (a[j] <= x) {
            int t = a[++i];
            a[i] = a[j], a[j] = t;
        }
    }
    int t = a[i + 1];
    a[i + 1] = a[r], a[r] = t;
    return i + 1;
}

inline int randomPartition(int* a, int l, int r) {
    int i = rand() % (r - l + 1) + l;
    int t = a[i];
    a[i] = a[r], a[r] = t;
    return partition(a, l, r);
}

int quickSelect(int* a, int l, int r, int index) {
    int q = randomPartition(a, l, r);
    if (q == index) {
        return a[q];
    } else {
        return q < index ? quickSelect(a, q + 1, r, index)
                         : quickSelect(a, l, q - 1, index);
    }
}

int findKthLargest(int* nums, int numsSize, int k) {
    srand(time(0));
    return quickSelect(nums, 0, numsSize - 1, numsSize - k);
}
```

```Go
func findKthLargest(nums []int, k int) int {
    rand.Seed(time.Now().UnixNano())
    return quickSelect(nums, 0, len(nums)-1, len(nums)-k)
}

func quickSelect(a []int, l, r, index int) int {
    q := randomPartition(a, l, r)
    if q == index {
        return a[q]
    } else if q < index {
        return quickSelect(a, q + 1, r, index)
    }
    return quickSelect(a, l, q - 1, index)
}

func randomPartition(a []int, l, r int) int {
    i := rand.Int() % (r - l + 1) + l
    a[i], a[r] = a[r], a[i]
    return partition(a, l, r)
}

func partition(a []int, l, r int) int {
    x := a[r]
    i := l - 1
    for j := l; j < r; j++ {
        if a[j] <= x {
            i++
            a[i], a[j] = a[j], a[i]
        }
    }
    a[i+1], a[r] = a[r], a[i+1]
    return i + 1
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，如上文所述，证明过程可以参考「《算法导论》9.2：期望为线性的选择算法」。
- 空间复杂度：$O(\log n)$，递归使用栈空间的空间代价的期望为 $O(\log n)$。

#### 方法二：基于堆排序的选择方法

**思路和算法**

我们也可以使用堆排序来解决这个问题——建立一个大根堆，做 $k-1$ 次删除操作后堆顶元素就是我们要找的答案。在很多语言中，都有优先队列或者堆的的容器可以直接使用，但是在面试中，面试官更倾向于让更面试者自己实现一个堆。所以建议读者掌握这里大根堆的实现方法，在这道题中尤其要搞懂「建堆」、「调整」和「删除」的过程。

**友情提醒：「堆排」在很多大公司的面试中都很常见，不了解的同学建议参考《算法导论》或者大家的数据结构教材，一定要学会这个知识点哦！\^\_\^**

![](./assets/img/Solution0076_off_2_01.png)
![](./assets/img/Solution0076_off_2_02.png)
![](./assets/img/Solution0076_off_2_03.png)
![](./assets/img/Solution0076_off_2_04.png)
![](./assets/img/Solution0076_off_2_05.png)
![](./assets/img/Solution0076_off_2_06.png)
![](./assets/img/Solution0076_off_2_07.png)
![](./assets/img/Solution0076_off_2_08.png)
![](./assets/img/Solution0076_off_2_09.png)
![](./assets/img/Solution0076_off_2_10.png)
![](./assets/img/Solution0076_off_2_11.png)
![](./assets/img/Solution0076_off_2_12.png)
![](./assets/img/Solution0076_off_2_13.png)
![](./assets/img/Solution0076_off_2_14.png)
![](./assets/img/Solution0076_off_2_15.png)
![](./assets/img/Solution0076_off_2_16.png)
![](./assets/img/Solution0076_off_2_17.png)
![](./assets/img/Solution0076_off_2_18.png)
![](./assets/img/Solution0076_off_2_19.png)
![](./assets/img/Solution0076_off_2_20.png)

**代码**

```C++
class Solution {
public:
    void maxHeapify(vector<int>& a, int i, int heapSize) {
        int l = i * 2 + 1, r = i * 2 + 2, largest = i;
        if (l < heapSize && a[l] > a[largest]) {
            largest = l;
        }
        if (r < heapSize && a[r] > a[largest]) {
            largest = r;
        }
        if (largest != i) {
            swap(a[i], a[largest]);
            maxHeapify(a, largest, heapSize);
        }
    }

    void buildMaxHeap(vector<int>& a, int heapSize) {
        for (int i = heapSize / 2; i >= 0; --i) {
            maxHeapify(a, i, heapSize);
        }
    }

    int findKthLargest(vector<int>& nums, int k) {
        int heapSize = nums.size();
        buildMaxHeap(nums, heapSize);
        for (int i = nums.size() - 1; i >= nums.size() - k + 1; --i) {
            swap(nums[0], nums[i]);
            --heapSize;
            maxHeapify(nums, 0, heapSize);
        }
        return nums[0];
    }
};
```

```Java
class Solution {
    public int findKthLargest(int[] nums, int k) {
        int heapSize = nums.length;
        buildMaxHeap(nums, heapSize);
        for (int i = nums.length - 1; i >= nums.length - k + 1; --i) {
            swap(nums, 0, i);
            --heapSize;
            maxHeapify(nums, 0, heapSize);
        }
        return nums[0];
    }

    public void buildMaxHeap(int[] a, int heapSize) {
        for (int i = heapSize / 2; i >= 0; --i) {
            maxHeapify(a, i, heapSize);
        }
    }

    public void maxHeapify(int[] a, int i, int heapSize) {
        int l = i * 2 + 1, r = i * 2 + 2, largest = i;
        if (l < heapSize && a[l] > a[largest]) {
            largest = l;
        }
        if (r < heapSize && a[r] > a[largest]) {
            largest = r;
        }
        if (largest != i) {
            swap(a, i, largest);
            maxHeapify(a, largest, heapSize);
        }
    }

    public void swap(int[] a, int i, int j) {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }
}
```

```C
void maxHeapify(int* a, int i, int heapSize) {
    int l = i * 2 + 1, r = i * 2 + 2, largest = i;
    if (l < heapSize && a[l] > a[largest]) {
        largest = l;
    }
    if (r < heapSize && a[r] > a[largest]) {
        largest = r;
    }
    if (largest != i) {
        int t = a[i];
        a[i] = a[largest], a[largest] = t;
        maxHeapify(a, largest, heapSize);
    }
}

void buildMaxHeap(int* a, int heapSize) {
    for (int i = heapSize / 2; i >= 0; --i) {
        maxHeapify(a, i, heapSize);
    }
}

int findKthLargest(int* nums, int numsSize, int k) {
    int heapSize = numsSize;
    buildMaxHeap(nums, heapSize);
    for (int i = numsSize - 1; i >= numsSize - k + 1; --i) {
        int t = nums[0];
        nums[0] = nums[i], nums[i] = t;
        --heapSize;
        maxHeapify(nums, 0, heapSize);
    }
    return nums[0];
}
```

```Go
func findKthLargest(nums []int, k int) int {
    heapSize := len(nums)
    buildMaxHeap(nums, heapSize)
    for i := len(nums) - 1; i >= len(nums) - k + 1; i-- {
        nums[0], nums[i] = nums[i], nums[0]
        heapSize--
        maxHeapify(nums, 0, heapSize)
    }
    return nums[0]
}

func buildMaxHeap(a []int, heapSize int) {
    for i := heapSize/2; i >= 0; i-- {
        maxHeapify(a, i, heapSize)
    }
}

func maxHeapify(a []int, i, heapSize int) {
    l, r, largest := i * 2 + 1, i * 2 + 2, i
    if l < heapSize && a[l] > a[largest] {
        largest = l
    }
    if r < heapSize && a[r] > a[largest] {
        largest = r
    }
    if largest != i {
        a[i], a[largest] = a[largest], a[i]
        maxHeapify(a, largest, heapSize)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，建堆的时间代价是 $O(n)$，删除的总代价是 $O(k\log n)$，因为 $k<n$，故渐进时间复杂为 $O(n+k\log n)=O(n\log n)$。
- 空间复杂度：$O(\log n)$，即递归使用栈空间的空间代价。
