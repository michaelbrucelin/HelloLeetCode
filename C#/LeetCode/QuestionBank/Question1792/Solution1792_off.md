### [最大平均通过率](https://leetcode.cn/problems/maximum-average-pass-ratio/solutions/2118606/zui-da-ping-jun-tong-guo-lu-by-leetcode-dm7y3/)

#### 方法一：优先队列

**思路与算法**

由于班级总数不会变化，因此题目所求「最大化平均通过率」等价于「最大化总通过率」。设某个班级的人数为 $total$，其中通过考试的人数为 $pass$，那么给这个班级安排一个额外通过考试的学生，其通过率会增加：

$$\dfrac{pass+1}{total+1}-\dfrac{pass}{total}$$

我们会优先选择通过率增加量最大的班级，这样做的正确性在于给同一个班级不断地增加安排的学生数量时，其增加的通过率是单调递减的，即：

$$\dfrac{pass+2}{total+2}-\dfrac{pass+1}{total+1}<\dfrac{pass+1}{total+1}-\dfrac{pass}{total}$$

因此当以下条件满足时，班级 $j$ 比班级 $i$ 优先级更大：

$$\dfrac{pass_i+1}{total_i+1}-\dfrac{pass_i}{total_i}<\dfrac{pass_j+1}{total_j+1}-\dfrac{pass_j}{total_j}$$

化简后可得：

$$(total_j+1)\times (total_j)\times (total_i-pass_i)<(total_i+1)\times (total_i)\times (total_j-pass_j)$$

我们按照上述比较规则将每个班级放入优先队列中，进行 $extraStudents$ 次操作。每一次操作，我们取出优先队列的堆顶元素，令其 $pass$ 和 $total$ 分别加 $1$，然后再放回优先队列。

最后我们遍历优先队列的每一个班级，计算其平均通过率即可得到答案。

**代码**

```Python
class Entry:
    __slots__ = 'p', 't'

    def __init__(self, p: int, t: int):
        self.p = p
        self.t = t

    def __lt__(self, b: 'Entry') -> bool:
        return (self.t - self.p) * b.t * (b.t + 1) > (b.t - b.p) * self.t * (self.t + 1)

class Solution:
    def maxAverageRatio(self, classes: List[List[int]], extraStudents: int) -> float:
        h = [Entry(*c) for c in classes]
        heapify(h)
        for _ in range(extraStudents):
            heapreplace(h, Entry(h[0].p + 1, h[0].t + 1))
        return sum(e.p / e.t for e in h) / len(h)
```

```C++
class Solution {
public:
    struct Ratio {
        int pass, total;
        bool operator < (const Ratio& oth) const {
            return (long long) (oth.total + 1) * oth.total * (total - pass) < (long long) (total + 1) * total * (oth.total - oth.pass);
        }
    };

    double maxAverageRatio(vector<vector<int>>& classes, int extraStudents) {
        priority_queue<Ratio> q;
        for (auto &c : classes) {
            q.push({c[0], c[1]});
        }

        for (int i = 0; i < extraStudents; i++) {
            auto [pass, total] = q.top();
            q.pop();
            q.push({pass + 1, total + 1});
        }

        double res = 0;
        for (int i = 0; i < classes.size(); i++) {
            auto [pass, total] = q.top();
            q.pop();
            res += 1.0 * pass / total;
        }
        return res / classes.size();
    }
};
```

```Java
class Solution {
    public double maxAverageRatio(int[][] classes, int extraStudents) {
        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a, b) -> {
            long val1 = (long) (b[1] + 1) * b[1] * (a[1] - a[0]);
            long val2 = (long) (a[1] + 1) * a[1] * (b[1] - b[0]);
            if (val1 == val2) {
                return 0;
            }
            return val1 < val2 ? 1 : -1;
        });
        for (int[] c : classes) {
            pq.offer(new int[]{c[0], c[1]});
        }

        for (int i = 0; i < extraStudents; i++) {
            int[] arr = pq.poll();
            int pass = arr[0], total = arr[1];
            pq.offer(new int[]{pass + 1, total + 1});
        }

        double res = 0;
        for (int i = 0; i < classes.length; i++) {
            int[] arr = pq.poll();
            int pass = arr[0], total = arr[1];
            res += 1.0 * pass / total;
        }
        return res / classes.length;
    }
}
```

```Go
func maxAverageRatio(classes [][]int, extraStudents int) (ans float64) {
    h := hp(classes)
    heap.Init(&h)
    for ; extraStudents > 0; extraStudents-- {
        h[0][0]++
        h[0][1]++
        heap.Fix(&h, 0)
    }
    for _, c := range h {
        ans += float64(c[0]) / float64(c[1])
    }
    return ans / float64(len(classes))
}

type hp [][]int
func (h hp) Len() int { return len(h) }
func (h hp) Less(i, j int) bool { a, b := h[i], h[j]; return (a[1]-a[0])*b[1]*(b[1]+1) > (b[1]-b[0])*a[1]*(a[1]+1) }
func (h hp) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (hp) Push(interface{})     {}
func (hp) Pop() (_ interface{}) { return }
```

```CSharp
public class Solution {
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
        var pq = new PriorityQueue<int[], double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));
        foreach (var c in classes) {
            double priority = GetPriority(c);
            pq.Enqueue(c, priority);
        }
        for (; extraStudents > 0; extraStudents--) {
            var current = pq.Dequeue();
            current[0]++;
            current[1]++;
            double newPriority = GetPriority(current);
            pq.Enqueue(current, newPriority);
        }
        double res = 0;
        while (pq.Count > 0) {
            var c = pq.Dequeue();
            res += (double)c[0] / c[1];
        }
        
        return res / classes.Length;
    }
    
    private double GetPriority(int[] c) {
        int pass = c[0];
        int total = c[1];
        return (double)(total - pass) / (total * (total + 1L));
    }
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data[2];
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

Element *createElement(int x, int y) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->data[0] = x;
    obj->data[1] = y;
    return obj;
}

static bool greater(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    long long val1 = (long long) (e2->data[1] + 1) * e2->data[1] * (e1->data[1] - e1->data[0]);
    long long val2 = (long long) (e1->data[1] + 1) * e1->data[1] * (e2->data[1] - e2->data[0]);
    return val1 < val2;
}

static void memswap(void *m1, void *m2, size_t size){
    unsigned char *a = (unsigned char*)m1;
    unsigned char *b = (unsigned char*)m2;
    while (size--) {
        *b ^= *a ^= *b ^= *a;
        a++;
        b++;
    }
}

static void swap(Element *arr, int i, int j) {
    memswap(&arr[i], &arr[j], sizeof(Element));
}

static void down(Element *arr, int size, int i, compare cmpFunc) {
    for (int k = 2 * i + 1; k < size; k = 2 * k + 1) {
        if (k + 1 < size && cmpFunc(&arr[k], &arr[k + 1])) {
            k++;
        }
        if (cmpFunc(&arr[k], &arr[(k - 1) / 2])) {
            break;
        }
        swap(arr, k, (k - 1) / 2);
    }
}

PriorityQueue *createPriorityQueue(compare cmpFunc) {
    PriorityQueue *obj = (PriorityQueue *)malloc(sizeof(PriorityQueue));
    obj->capacity = MIN_QUEUE_SIZE;
    obj->arr = (Element *)malloc(sizeof(Element) * obj->capacity);
    obj->queueSize = 0;
    obj->lessFunc = cmpFunc;
    return obj;
}

void heapfiy(PriorityQueue *obj) {
    for (int i = obj->queueSize / 2 - 1; i >= 0; i--) {
        down(obj->arr, obj->queueSize, i, obj->lessFunc);
    }
}

void enQueue(PriorityQueue *obj, Element *e) {
    // we need to alloc more space, just twice space size
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        obj->arr = realloc(obj->arr, sizeof(Element) * obj->capacity);
    }
    memcpy(&obj->arr[obj->queueSize], e, sizeof(Element));
    for (int i = obj->queueSize; i > 0 && obj->lessFunc(&obj->arr[(i - 1) / 2], &obj->arr[i]); i = (i - 1) / 2) {
        swap(obj->arr, i, (i - 1) / 2);
    }
    obj->queueSize++;
}

Element* deQueue(PriorityQueue *obj) {
    swap(obj->arr, 0, obj->queueSize - 1);
    down(obj->arr, obj->queueSize - 1, 0, obj->lessFunc);
    Element *e =  &obj->arr[obj->queueSize - 1];
    obj->queueSize--;
    return e;
}

bool isEmpty(const PriorityQueue *obj) {
    return obj->queueSize == 0;
}

Element* front(const PriorityQueue *obj) {
    if (obj->queueSize == 0) {
        return NULL;
    } else {
        return &obj->arr[0];
    }
}

void clear(PriorityQueue *obj) {
    obj->queueSize = 0;
}

int size(const PriorityQueue *obj) {
    return obj->queueSize;
}

void freeQueue(PriorityQueue *obj) {
    free(obj->arr);
    free(obj);
}

double maxAverageRatio(int** classes, int classesSize, int* classesColSize, int extraStudents) {
    PriorityQueue *pq = createPriorityQueue(greater);
    Element e;
    for (int i = 0; i < classesSize; i++) {
        e.data[0] = classes[i][0];
        e.data[1] = classes[i][1];
        enQueue(pq, &e);
    }

    for (int i = 0; i < extraStudents; i++) {
        Element *p = front(pq);
        int pass = p->data[0], total = p->data[1];
        deQueue(pq);
        e.data[0] = pass + 1;
        e.data[1] = total + 1;
        enQueue(pq, &e);
    }

    double res = 0;
    for (int i = 0; i < classesSize; i++) {
        Element *p = front(pq);
        int pass = p->data[0], total = p->data[1];
        deQueue(pq);
        res += 1.0 * pass / total;
    }
    return res / classesSize;
}
```

```JavaScript
var maxAverageRatio = function(classes, extraStudents) {
    const pq = new PriorityQueue((a, b) => {
        const val1 = (b[1] + 1) * b[1] * (a[1] - a[0]);
        const val2 = (a[1] + 1) * a[1] * (b[1] - b[0]);
        return val1 < val2 ? 1 : -1;
    });

    for (const c of classes) {
        pq.enqueue([c[0], c[1]]);
    }

    for (let i = 0; i < extraStudents; i++) {
        const arr = pq.dequeue();
        const pass = arr[0], total = arr[1];
        pq.enqueue([pass + 1, total + 1]);
    }

    let res = 0;
    const count = classes.length;
    while (!pq.isEmpty()) {
        const arr = pq.dequeue();
        const pass = arr[0], total = arr[1];
        res += pass / total;
    }
    return res / count;
};
```

```TypeScript
function maxAverageRatio(classes: number[][], extraStudents: number): number {
    const pq = new PriorityQueue((a, b) => {
        const val1 = (b[1] + 1) * b[1] * (a[1] - a[0]);
        const val2 = (a[1] + 1) * a[1] * (b[1] - b[0]);
        return val1 < val2 ? 1 : -1;
    });

    for (const c of classes) {
        pq.enqueue([c[0], c[1]]);
    }

    for (let i = 0; i < extraStudents; i++) {
        const arr = pq.dequeue();
        const pass = arr[0], total = arr[1];
        pq.enqueue([pass + 1, total + 1]);
    }

    let res = 0;
    const count = classes.length;
    while (!pq.isEmpty()) {
        const arr = pq.dequeue();
        const pass = arr[0], total = arr[1];
        res += pass / total;
    }
    return res / count;
};
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Ordering;

#[derive(PartialEq, Debug)]
struct ClassRatio {
    pass: i64,
    total: i64,
}

impl Eq for ClassRatio {}

impl PartialOrd for ClassRatio {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        let val1 = (other.total + 1)  * other.total  * (self.total - self.pass) ;
        let val2 = (self.total + 1)  * self.total  * (other.total - other.pass) ;
        val1.partial_cmp(&val2)
    }
}

impl Ord for ClassRatio {
    fn cmp(&self, other: &Self) -> Ordering {
        let val1 = (other.total + 1)  * other.total  * (self.total - self.pass) ;
        let val2 = (self.total + 1)  * self.total  * (other.total - other.pass) ;
        val1.cmp(&val2)
    }
}

impl Solution {
    pub fn max_average_ratio(classes: Vec<Vec<i32>>, extra_students: i32) -> f64 {
        let mut heap = BinaryHeap::new();
        for c in &classes {
            heap.push(ClassRatio {
                pass: c[0] as i64,
                total: c[1] as i64,
            });
        }

        for _ in 0..extra_students {
            if let Some(mut class) = heap.pop() {
                class.pass += 1;
                class.total += 1;
                heap.push(class);
            }
        }

        let mut res = 0.0;
        let count = classes.len() as f64;
        while let Some(class) = heap.pop() {
            res += class.pass as f64 / class.total as f64;
        }
        res / count
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+m)\log n)$ 或 $O(n+m\log n)$，其中 $n$ 为 $classes$ 的长度，$m$ 等于 $extraStudents$。每次从优先队列中取出或者放入元素的时间复杂度为 $O(\log n)$，共需操作 $O(n+m)$ 次，故总复杂度为 $O((n+m)\log n)$。堆化写法的时间复杂度为 $O(n+m\log n)$。
- 空间复杂度：$O(n)$ 或 $O(1)$。使用优先队列需要用到 $O(n)$ 的空间，但若直接在 $classes$ 上原地堆化，则可以做到 $O(1)$ 额外空间。
