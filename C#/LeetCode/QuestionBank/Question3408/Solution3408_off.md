### [设计任务管理器](https://leetcode.cn/problems/design-task-manager/solutions/3775224/she-ji-ren-wu-guan-li-qi-by-leetcode-sol-wibx/)

#### 方法一：优先队列 $+$ 哈希表

**思路与算法**

初始化：使用哈希表 $taskInfo$ 存储每个任务的最新信息（$priority$ 和 $userId$），同时放入最大堆 $heap$ 中，存储 $priority$ 和 $userId$，以便高效获取最高优先级的任务。有些语言没有最大堆，就用最小堆和负值代替。

添加任务：将任务信息存入 $taskInfo$ 并向 $heap$ 推送对应的 $priority$ 和 $userId$。

编辑任务：更新 $taskInfo$ 中任务的优先级，并向 $heap$ 中推送新的 $priority$ 和 $userId$（旧记录通过懒删除处理）。

删除任务：直接从 $taskInfo$ 中移除任务，$heap$ 中的旧记录将在后续操作中被跳过。

执行最高优先级任务：从 $heap$ 顶弹出任务，检查其是否在 $taskInfo$ 中存在且 $priority$ 匹配。若匹配则删除并返回 $userId$，否则继续弹出直到找到有效任务或堆空。

```Python
class TaskManager:

    def __init__(self, tasks: List[List[int]]):
        self.taskInfo = {}
        self.heap = []
        for userId, taskId, priority in tasks:
            self.taskInfo[taskId] = [priority, userId]
            heappush(self.heap, [-priority, -taskId])
        
    def add(self, userId: int, taskId: int, priority: int) -> None:
        self.taskInfo[taskId] = [priority, userId]
        heappush(self.heap, [-priority, -taskId])

    def edit(self, taskId: int, newPriority: int) -> None:
        self.taskInfo[taskId][0] = newPriority
        heappush(self.heap, [-newPriority, -taskId])

    def rmv(self, taskId: int) -> None:
        self.taskInfo.pop(taskId)

    def execTop(self) -> int:
        while self.heap:
            priority, taskId = heappop(self.heap)
            priority, taskId = -priority, -taskId
            if priority == self.taskInfo.get(taskId, [-1, -1])[0]:
                return self.taskInfo.pop(taskId)[1]
        return -1
```

```C++
class TaskManager {
private:
    unordered_map<int, pair<int, int>> taskInfo;
    priority_queue<pair<int, int>> heap;
    
public:
    TaskManager(vector<vector<int>> tasks) {
        for (auto& task : tasks) {
            int userId = task[0], taskId = task[1], priority = task[2];
            taskInfo[taskId] = {priority, userId};
            heap.emplace(priority, taskId);
        }
    }
    
    void add(int userId, int taskId, int priority) {
        taskInfo[taskId] = {priority, userId};
        heap.emplace(priority, taskId);
    }
    
    void edit(int taskId, int newPriority) {
        if (taskInfo.find(taskId) != taskInfo.end()) {
            taskInfo[taskId].first = newPriority;
            heap.emplace(newPriority, taskId);
        }
    }
    
    void rmv(int taskId) {
        taskInfo.erase(taskId);
    }
    
    int execTop() {
        while (!heap.empty()) {
            auto [priority, taskId] = heap.top();
            heap.pop();
            
            if (taskInfo.find(taskId) != taskInfo.end() && 
                taskInfo[taskId].first == priority) {
                int userId = taskInfo[taskId].second;
                taskInfo.erase(taskId);
                return userId;
            }
        }
        return -1;
    }
};
```

```Java
class TaskManager {
    private Map<Integer, int[]> taskInfo;
    private PriorityQueue<int[]> heap;
    
    public TaskManager(List<List<Integer>> tasks) {
        taskInfo = new HashMap<>();
        heap = new PriorityQueue<>((a, b) -> {
            if (a[0] != b[0]) {
                return b[0] - a[0];
            }
            return b[1] - a[1];
        });
        
        for (List<Integer> task : tasks) {
            int userId = task.get(0), taskId = task.get(1), priority = task.get(2);
            taskInfo.put(taskId, new int[]{priority, userId});
            heap.offer(new int[]{priority, taskId});
        }
    }
    
    public void add(int userId, int taskId, int priority) {
        taskInfo.put(taskId, new int[]{priority, userId});
        heap.offer(new int[]{priority, taskId});
    }
    
    public void edit(int taskId, int newPriority) {
        if (taskInfo.containsKey(taskId)) {
            taskInfo.get(taskId)[0] = newPriority;
            heap.offer(new int[]{newPriority, taskId});
        }
    }
    
    public void rmv(int taskId) {
        taskInfo.remove(taskId);
    }
    
    public int execTop() {
        while (!heap.isEmpty()) {
            int[] task = heap.poll();
            int priority = task[0], taskId = task[1];
            
            if (taskInfo.containsKey(taskId) && taskInfo.get(taskId)[0] == priority) {
                int userId = taskInfo.get(taskId)[1];
                taskInfo.remove(taskId);
                return userId;
            }
        }
        return -1;
    }
}
```

```CSharp
public class TaskManager {
    private Dictionary<int, int[]> taskInfo;
    private PriorityQueue<int[], int[]> heap;
    
    public TaskManager(IList<IList<int>> tasks) {
        taskInfo = new Dictionary<int, int[]>();
        heap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => {
            if (a[0] == b[0]) {
                return b[1].CompareTo(a[1]);
            }
            return b[0].CompareTo(a[0]);
        }));
        
        foreach (var task in tasks) {
            int userId = task[0], taskId = task[1], priority = task[2];
            taskInfo[taskId] = new int[] {priority, userId};
            heap.Enqueue(new int[] {priority, taskId}, new int[]{priority, taskId});
        }
    }
    
    public void Add(int userId, int taskId, int priority) {
        taskInfo[taskId] = new int[] {priority, userId};
        heap.Enqueue(new int[] {priority, taskId}, new int[]{priority, taskId});
    }
    
    public void Edit(int taskId, int newPriority) {
        if (taskInfo.ContainsKey(taskId)) {
            taskInfo[taskId][0] = newPriority;
            heap.Enqueue(new int[] {newPriority, taskId}, new int[]{newPriority, taskId});
        }
    }
    
    public void Rmv(int taskId) {
        taskInfo.Remove(taskId);
    }
    
    public int ExecTop() {
        while (heap.Count > 0) {
            var task = heap.Dequeue();
            int priority = task[0], taskId = task[1];
            if (taskInfo.TryGetValue(taskId, out var info) && info[0] == priority) {
                int userId = info[1];
                taskInfo.Remove(taskId);
                return userId;
            }
        }
        
        return -1;
    }
}
```

```Go
type TaskManager struct {
    taskInfo map[int][2]int
    heap     *PriorityQueue
}

func Constructor(tasks [][]int) TaskManager {
    tm := TaskManager{
        taskInfo: make(map[int][2]int),
        heap:     &PriorityQueue{},
    }
    heap.Init(tm.heap)
    
    for _, task := range tasks {
        userId, taskId, priority := task[0], task[1], task[2]
        tm.taskInfo[taskId] = [2]int{priority, userId}
        heap.Push(tm.heap, Task{priority: priority, taskId: taskId})
    }
    return tm
}

func (this *TaskManager) Add(userId int, taskId int, priority int)  {
    this.taskInfo[taskId] = [2]int{priority, userId}
    heap.Push(this.heap, Task{priority: priority, taskId: taskId})
}

func (this *TaskManager) Edit(taskId int, newPriority int)  {
    if info, exists := this.taskInfo[taskId]; exists {
        info[0] = newPriority
        this.taskInfo[taskId] = info
        heap.Push(this.heap, Task{priority: newPriority, taskId: taskId})
    }
}

func (this *TaskManager) Rmv(taskId int)  {
    delete(this.taskInfo, taskId)
}

func (this *TaskManager) ExecTop() int {
    for this.heap.Len() > 0 {
        task := heap.Pop(this.heap).(Task)
        priority, taskId := task.priority, task.taskId
        if info, exists := this.taskInfo[taskId]; exists && info[0] == priority {
            userId := info[1]
            delete(this.taskInfo, taskId)
            return userId
        }
    }
    return -1
}

type Task struct {
    priority int
    taskId   int
}

type PriorityQueue []Task

func (pq PriorityQueue) Len() int { 
    return len(pq) 
}

func (pq PriorityQueue) Less(i, j int) bool {
    if pq[i].priority != pq[j].priority {
        return pq[i].priority > pq[j].priority
    }
    return pq[i].taskId > pq[j].taskId
}

func (pq PriorityQueue) Swap(i, j int) { 
    pq[i], pq[j] = pq[j], pq[i] 
}

func (pq *PriorityQueue) Push(x interface{}) { 
    *pq = append(*pq, x.(Task)) 
}

func (pq *PriorityQueue) Pop() interface{} {
    old := *pq
    n := len(old)
    item := old[n - 1]
    *pq = old[0 : n - 1]
    return item
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int priority;
    int taskId;
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;


static bool less(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    if (e1->priority == e2->priority) {
        return e1->taskId < e2->taskId;
    }
    return e1->priority < e2->priority;
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

typedef struct Pair {
    int priority;
    int userId;
} Pair;

typedef struct {
    int key;
    Pair val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, Pair val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, Pair val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

Pair* hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return &pEntry->val;
}

void hashEraseItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    if (pEntry != NULL) {
        HASH_DEL(*obj, pEntry);
        free(pEntry);     
    } 
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

typedef struct {
    HashItem *taskInfo;
    PriorityQueue *heap;
} TaskManager;


TaskManager* taskManagerCreate(int** tasks, int tasksSize, int* tasksColSize) {
    TaskManager *obj = (TaskManager *)malloc(sizeof(TaskManager));
    obj->taskInfo = NULL;
    obj->heap = createPriorityQueue(less);
    for (int i = 0; i < tasksSize; i++) {
        int userId = tasks[i][0], taskId = tasks[i][1], priority = tasks[i][2];
        Pair val = {priority, userId};
        hashAddItem(&obj->taskInfo, taskId, val);
        Element e = {priority, taskId};
        enQueue(obj->heap, &e);
    }
    return obj;
}

void taskManagerAdd(TaskManager* obj, int userId, int taskId, int priority) {
    Pair val = {priority, userId};
    hashAddItem(&obj->taskInfo, taskId, val);
    Element e = {priority, taskId};
    enQueue(obj->heap, &e);
}

void taskManagerEdit(TaskManager* obj, int taskId, int newPriority) {
    if (hashFindItem(&obj->taskInfo, taskId)) {
        Pair *p = hashGetItem(&obj->taskInfo, taskId);
        Pair val = {newPriority, p->userId};
        hashSetItem(&obj->taskInfo, taskId, val);
        Element e = {newPriority, taskId};
        enQueue(obj->heap, &e);
    }
}

void taskManagerRmv(TaskManager* obj, int taskId) {
    hashEraseItem(&obj->taskInfo, taskId);
}

int taskManagerExecTop(TaskManager* obj) {
    while (!isEmpty(obj->heap)) {
        Element *p = front(obj->heap);
        int priority = p->priority;
        int taskId = p->taskId;      
        deQueue(obj->heap);
        if (hashFindItem(&obj->taskInfo, taskId) && hashGetItem(&obj->taskInfo, taskId)->priority == priority) {
            int userId = hashGetItem(&obj->taskInfo, taskId)->userId;
            hashEraseItem(&obj->taskInfo, taskId);
            return userId;
        }
    }
    return -1;
}

void taskManagerFree(TaskManager* obj) {
    freeQueue(obj->heap);
    hashFree(&obj->taskInfo);
    free(obj);
}
```

```JavaScript
var TaskManager = function(tasks) {
    this.taskInfo = new Map();
    this.heap = new PriorityQueue((a, b) => {
        if (a[0] === b[0]) {
            return a[1] > b[1] ? -1 : 1;
        }
        return a[0] > b[0] ? -1 : 1;
    });

    for (const [userId, taskId, priority] of tasks) {
        this.taskInfo.set(taskId, [priority, userId]);
        this.heap.enqueue([priority, taskId]);
    }
};

TaskManager.prototype.add = function(userId, taskId, priority) {
    this.taskInfo.set(taskId, [priority, userId]);
    this.heap.enqueue([priority, taskId]);
};

TaskManager.prototype.edit = function(taskId, newPriority) {
    if (this.taskInfo.has(taskId)) {
        const [priority, userId] = this.taskInfo.get(taskId);
        this.taskInfo.delete(taskId);
        this.taskInfo.set(taskId, [newPriority, userId]);
        this.heap.enqueue([newPriority, taskId]);
    }
};

TaskManager.prototype.rmv = function(taskId) {
    this.taskInfo.delete(taskId);
};

TaskManager.prototype.execTop = function() {
    while (!this.heap.isEmpty()) {
        const [priority, taskId] = this.heap.dequeue();        
        if (this.taskInfo.has(taskId) && this.taskInfo.get(taskId)[0] == priority) {
            const userId = this.taskInfo.get(taskId)[1];
            this.taskInfo.delete(taskId);
            return userId;
        }
    }
    return -1;
};
```

```TypeScript
class TaskManager {
    private taskInfo: Map<number, [number, number]>;
    private heap: PriorityQueue<[number, number]>;

    constructor(tasks: number[][]) {
        this.taskInfo = new Map();
        this.heap = new PriorityQueue<[number, number]>((a: [number, number], b: [number, number]) => {
            if (a[0] === b[0]) {
                return a[1] > b[1] ? -1 : 1;
            }
            return a[0] > b[0] ? -1 : 1;
        });
        for (const [userId, taskId, priority] of tasks) {
            this.taskInfo.set(taskId, [priority, userId]);
            this.heap.enqueue([priority, taskId]);
        }
    }

    add(userId: number, taskId: number, priority: number): void {
        this.taskInfo.set(taskId, [priority, userId]);
        this.heap.enqueue([priority, taskId]);
    }

    edit(taskId: number, newPriority: number): void {
        if (this.taskInfo.has(taskId)) {
            const [priority, userId] = this.taskInfo.get(taskId)!;
            this.taskInfo.delete(taskId);
            this.taskInfo.set(taskId, [newPriority, userId]);
            this.heap.enqueue([newPriority, taskId]);
        }
    }

    rmv(taskId: number): void {
        this.taskInfo.delete(taskId);
    }

    execTop(): number {
        while (!this.heap.isEmpty()) {
            const [priority, taskId] = this.heap.dequeue();
            if (this.taskInfo.has(taskId) && this.taskInfo.get(taskId)![0] === priority) {
                const userId = this.taskInfo.get(taskId)![1];
                this.taskInfo.delete(taskId);
                return userId;
            }
        }
        return -1;
    }
}
```

```Rust
use std::collections::{BinaryHeap, HashMap};
use std::cmp::Ordering;

#[derive(Eq, PartialEq)]
struct Task {
    priority: i32,
    task_id: i32,
}

impl Ord for Task {
    fn cmp(&self, other: &Self) -> Ordering {
        self.priority.cmp(&other.priority)
            .then_with(|| self.task_id.cmp(&other.task_id))
    }
}

impl PartialOrd for Task {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

struct TaskManager {
    task_info: HashMap<i32, (i32, i32)>,
    heap: BinaryHeap<Task>,
}

impl TaskManager {
    fn new(tasks: Vec<Vec<i32>>) -> Self {
        let mut task_info = HashMap::new();
        let mut heap = BinaryHeap::new();
        
        for task in tasks {
            let user_id = task[0];
            let task_id = task[1];
            let priority = task[2];
            
            task_info.insert(task_id, (priority, user_id));
            heap.push(Task { priority, task_id });
        }
        
        Self { task_info, heap }
    }
    
    fn add(&mut self, user_id: i32, task_id: i32, priority: i32) {
        self.task_info.insert(task_id, (priority, user_id));
        self.heap.push(Task { priority, task_id });
    }
    
    fn edit(&mut self, task_id: i32, new_priority: i32) {
        if let Some(info) = self.task_info.get_mut(&task_id) {
            info.0 = new_priority;
            self.heap.push(Task { priority: new_priority, task_id });
        }
    }
    
    fn rmv(&mut self, task_id: i32) {
        self.task_info.remove(&task_id);
    }
    
    fn exec_top(&mut self) -> i32 {
        while let Some(task) = self.heap.pop() {
            if let Some(&(priority, user_id)) = self.task_info.get(&task.task_id) {
                if priority == task.priority {
                    self.task_info.remove(&task.task_id);
                    return user_id;
                }
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：令 $n$ 为初始化时 $tasks$ 的长度，$m$ 为后续操作的次数。初始化消耗 $O(n\times logn)$，add 消耗 $O(log(n+m))$，edit 消耗 $O(log(n+m))$，rmv 消耗 $O(1))$，execTop 均摊消耗 $O(log(n+m))$。
- 空间复杂度：$O(n+m)$。
