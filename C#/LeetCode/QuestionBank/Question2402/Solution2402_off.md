### [会议室 III](https://leetcode.cn/problems/meeting-rooms-iii/solutions/3864315/hui-yi-shi-iii-by-leetcode-solution-8pao/)

#### 方法一：优先队列 + 模拟

**思路与算法**

根据题意，会议需要按照原开始时间进行分配会议室，因此将 $meetings$ 按照开始时间从小到大进行排序。我们对会议室的分配进行模拟，使用两个优先队列（最小堆）$availRooms$ 和 $usedRooms$，其中：

- $availRooms$ 保存当前处于未占用状态的会议室，按照编号升序，方便获取编号最小的房间。
- $usedRooms$ 保存当前处于占用状态的会议室，按照结束时间升序，方便获取会议最早结束的会议室。

初始时当前时间 $curTime=0$，我们遍历所有会议 $meetings$，令当前遍历的会议为 $meeting$：

- 如果会议 $meeting$ 的开始时间比 $curTime$ 要大，那么将当前 $curTime$ 推进到该会议的开始时间。
- 如果当前没有可用的会议室，且当前时间 $curTime$ 比最早结束的会议室的结束时间要小，那么我们需要将当前时间推进到最早结束的会议室的结束时间。
- 我们不断地从 $usedRooms$ 中获取结束时间小于等于当前时间 $curTime$ 的会议，并将它重新放回 $availRooms$ 中。
- 对于当前会议 $meeting$，我们从 $availRooms$ 中获取当前可用的编号最小的会议室 $room$，并分配给会议 $meeting$，并将会议室 $room$ 的举办会议数目加一。同时 $room$ 被会议 $meeting$ 的占用结束时间为当前时间 $curTime$ 加上该会议的持续时间，将 $room$ 放入 $usedRooms$ 中。

遍历结束后，我们取举办会议数目最多的会议室作为结果。

**代码**

```C++
class Solution {
public:
    int mostBooked(int n, vector<vector<int>>& meetings) {
        sort(meetings.begin(), meetings.end(), [](const vector<int>& v1, const vector<int>& v2) -> bool {
            return v1[0] < v2[0];
        });
        priority_queue<int, vector<int>, greater<int>> availRooms;
        for (int i = 0; i < n; i++) {
            availRooms.push(i);
        }
        priority_queue<pair<long long, int>, vector<pair<long long, int>>, greater<>> usedRooms;
        vector<int> usedCount(n);
        long long curTime = 0;
        for (const auto& meeting : meetings) {
            curTime = max(curTime, static_cast<long long>(meeting[0]));
            if (availRooms.empty()) {
                curTime = max(curTime, usedRooms.top().first);
            }
            while (!usedRooms.empty() && usedRooms.top().first <= curTime) {
                availRooms.push(usedRooms.top().second);
                usedRooms.pop();
            }
            int room = availRooms.top();
            availRooms.pop();
            usedCount[room]++;
            usedRooms.push({curTime + meeting[1] - meeting[0], room});
        }
        int room = 0;
        for (int i = 0; i < n; i++) {
            if (usedCount[i] > usedCount[room]) {
                room = i;
            }
        }
        return room;
    }
};
```

```Go
type RoomHeap []int
func (h RoomHeap) Len() int           { return len(h) }
func (h RoomHeap) Less(i, j int) bool { return h[i] < h[j] }
func (h RoomHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *RoomHeap) Push(x interface{}) { *h = append(*h, x.(int)) }
func (h *RoomHeap) Pop() interface{} {
    old := *h
    x := old[len(old) - 1]
    *h = old[: len(old) - 1]
    return x
}

type UsedRoom struct{ endTime, room int }
type UsedHeap []UsedRoom
func (h UsedHeap) Len() int           { return len(h) }
func (h UsedHeap) Less(i, j int) bool {
    if h[i].endTime == h[j].endTime {
        return h[i].room < h[j].room
    }
    return h[i].endTime < h[j].endTime
}
func (h UsedHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *UsedHeap) Push(x interface{}) { *h = append(*h, x.(UsedRoom)) }
func (h *UsedHeap) Pop() interface{} {
    old := *h
    x := old[len(old) - 1]
    *h = old[: len(old) - 1]
    return x
}

func mostBooked(n int, meetings [][]int) int {
    sort.Slice(meetings, func(i, j int) bool { return meetings[i][0] < meetings[j][0] })
    availRooms := &RoomHeap{}
    for i := 0; i < n; i++ {
        *availRooms = append(*availRooms, i)
    }
    heap.Init(availRooms)
    usedRooms := &UsedHeap{}
    heap.Init(usedRooms)
    usedCount := make([]int, n)
    curTime := 0
    for _, meeting := range meetings {
        if curTime < meeting[0] {
            curTime = meeting[0]
        }
        for usedRooms.Len() > 0 && (*usedRooms)[0].endTime <= curTime {
            heap.Push(availRooms, heap.Pop(usedRooms).(UsedRoom).room)
        }
        if availRooms.Len() == 0 {
            curTime = (*usedRooms)[0].endTime
            for usedRooms.Len() > 0 && (*usedRooms)[0].endTime <= curTime {
                heap.Push(availRooms, heap.Pop(usedRooms).(UsedRoom).room)
            }
        }
        room := heap.Pop(availRooms).(int)
        usedCount[room]++
        heap.Push(usedRooms, UsedRoom{curTime + meeting[1] - meeting[0], room})
    }
    ans := 0
    for i := 1; i < n; i++ {
        if usedCount[i] > usedCount[ans] {
            ans = i
        }
    }
    return ans
}
```

```Python
class Solution:
    def mostBooked(self, n: int, meetings: list[list[int]]) -> int:
        meetings.sort()
        avail_rooms = list(range(n))
        heapq.heapify(avail_rooms)
        used_rooms = []
        used_count = [0] * n
        cur_time = 0
        for start, end in meetings:
            cur_time = max(cur_time, start)
            while used_rooms and used_rooms[0][0] <= cur_time:
                _, room = heapq.heappop(used_rooms)
                heapq.heappush(avail_rooms, room)
            if not avail_rooms:
                cur_time = used_rooms[0][0]
                while used_rooms and used_rooms[0][0] <= cur_time:
                    _, room = heapq.heappop(used_rooms)
                    heapq.heappush(avail_rooms, room)
            room = heapq.heappop(avail_rooms)
            used_count[room] += 1
            heapq.heappush(used_rooms, (cur_time + end - start, room))
        return max(range(n), key=lambda i: used_count[i])
```

```Java
class Solution {
    public int mostBooked(int n, int[][] meetings) {
        Arrays.sort(meetings, Comparator.comparingInt(a -> a[0]));
        PriorityQueue<Integer> availRooms = new PriorityQueue<>();
        for (int i = 0; i < n; i++) {
            availRooms.offer(i);
        }
        PriorityQueue<long[]> usedRooms = new PriorityQueue<>(Comparator.comparingLong(a -> a[0]));
        int[] usedCount = new int[n];
        long curTime = 0;
        for (int[] meeting : meetings) {
            curTime = Math.max(curTime, meeting[0]);
            while (!usedRooms.isEmpty() && usedRooms.peek()[0] <= curTime) {
                availRooms.offer((int)usedRooms.poll()[1]);
            }
            if (availRooms.isEmpty()) {
                curTime = usedRooms.peek()[0];
                while (!usedRooms.isEmpty() && usedRooms.peek()[0] <= curTime) {
                    availRooms.offer((int)usedRooms.poll()[1]);
                }
            }
            int room = availRooms.poll();
            usedCount[room]++;
            usedRooms.offer(new long[]{curTime + meeting[1] - meeting[0], room});
        }
        int ans = 0;
        for (int i = 1; i < n; i++) {
            if (usedCount[i] > usedCount[ans]) ans = i;
        }
        return ans;
    }
}
```

```TypeScript
function mostBooked(n: number, meetings: number[][]): number {
    meetings.sort((a, b) => a[0] - b[0]);
    const availRooms = new MinPriorityQueue<number>({ compare: (a, b) => a - b });
    for (let i = 0; i < n; i++) {
        availRooms.enqueue(i);
    }
    const usedRooms = new MinPriorityQueue<[number, number]>({
        compare: (a, b) => a[0] === b[0] ? a[1] - b[1] : a[0] - b[0]
    });
    const usedCount = Array(n).fill(0);
    let curTime = 0;
    for (const [start, end] of meetings) {
        curTime = Math.max(curTime, start);
        while (!usedRooms.isEmpty() && usedRooms.front()[0] <= curTime) {
            availRooms.enqueue(usedRooms.dequeue()[1]);
        }
        if (availRooms.isEmpty()) {
            curTime = usedRooms.front()[0];
            while (!usedRooms.isEmpty() && usedRooms.front()[0] <= curTime) {
                availRooms.enqueue(usedRooms.dequeue()[1]);
            }
        }
        const room = availRooms.dequeue();
        usedCount[room]++;
        usedRooms.enqueue([curTime + end - start, room]);
    }
    let ans = 0;
    for (let i = 1; i < n; i++) {
        if (usedCount[i] > usedCount[ans]) {
            ans = i;
        }
    }
    return ans;
}
```

```JavaScript
function mostBooked(n, meetings) {
    meetings.sort((a, b) => a[0] - b[0]);
    const availRooms = new MinPriorityQueue({ compare: (a, b) => a - b });
    for (let i = 0; i < n; i++) {
        availRooms.enqueue(i);
    }
    const usedRooms = new MinPriorityQueue({
        compare: (a, b) => a[0] === b[0] ? a[1] - b[1] : a[0] - b[0]
    });
    const usedCount = Array(n).fill(0);
    let curTime = 0;
    for (const [start, end] of meetings) {
        curTime = Math.max(curTime, start);
        while (!usedRooms.isEmpty() && usedRooms.front()[0] <= curTime) {
            availRooms.enqueue(usedRooms.dequeue()[1]);
        }
        if (availRooms.isEmpty()) {
            curTime = usedRooms.front()[0];
            while (!usedRooms.isEmpty() && usedRooms.front()[0] <= curTime) {
                availRooms.enqueue(usedRooms.dequeue()[1]);
            }
        }
        const room = availRooms.dequeue();
        usedCount[room]++;
        usedRooms.enqueue([curTime + end - start, room]);
    }
    let ans = 0;
    for (let i = 1; i < n; i++) {
        if (usedCount[i] > usedCount[ans]) {
            ans = i;
        }
    }
    return ans;
}
```

```CSharp
public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        var availRooms = new SortedSet<int>();
        for (int i = 0; i < n; i++) {
            availRooms.Add(i);
        }
        var usedRooms = new PriorityQueue<(long, int), long>();
        int[] usedCount = new int[n];
        long curTime = 0;
        foreach (var meeting in meetings) {
            curTime = Math.Max(curTime, meeting[0]);
            while (usedRooms.Count > 0 && usedRooms.Peek().Item1 <= curTime) {
                availRooms.Add(usedRooms.Dequeue().Item2);
            }
            if (availRooms.Count == 0) {
                curTime = usedRooms.Peek().Item1;
                while (usedRooms.Count > 0 && usedRooms.Peek().Item1 <= curTime) {
                    availRooms.Add(usedRooms.Dequeue().Item2);
                }
            }
            int room = availRooms.Min;
            availRooms.Remove(room);
            usedCount[room]++;
            usedRooms.Enqueue((curTime + meeting[1] - meeting[0], room), curTime + meeting[1] - meeting[0]);
        }
        int ans = 0;
        for (int i = 1; i < n; i++) {
            if (usedCount[i] > usedCount[ans]) {
                ans = i;
            }
        }
        return ans;
    }
}
```

```C
typedef int (*CmpFunc)(const void*, const void*);

typedef struct {
    void* data;
    int size;
    int cap;
    int elemSize;
    CmpFunc cmp;
} MinHeap;

MinHeap* heapCreate(int cap, int elemSize, CmpFunc cmp) {
    MinHeap* h = (MinHeap*)malloc(sizeof(MinHeap));
    h->data = malloc(cap * elemSize);
    h->size = 0;
    h->cap = cap;
    h->elemSize = elemSize;
    h->cmp = cmp;
    return h;
}

void heapSwap(MinHeap* h, int i, int j) {
    char tmp[64];
    char* a = (char*)h->data + i * h->elemSize;
    char* b = (char*)h->data + j * h->elemSize;
    memcpy(tmp, a, h->elemSize);
    memcpy(a, b, h->elemSize);
    memcpy(b, tmp, h->elemSize);
}

void heapPush(MinHeap* h, void* elem) {
    memcpy((char*)h->data + h->size * h->elemSize, elem, h->elemSize);
    int i = h->size++;
    while (i > 0) {
        int p = (i - 1) / 2;
        if (h->cmp((char*)h->data + i * h->elemSize, (char*)h->data + p * h->elemSize) >= 0) {
            break;
        }
        heapSwap(h, i, p);
        i = p;
    }
}

void heapPop(MinHeap* h, void* out) {
    memcpy(out, h->data, h->elemSize);
    h->size--;
    memcpy(h->data, (char*)h->data + h->size * h->elemSize, h->elemSize);
    int i = 0;
    while (1) {
        int l = i * 2 + 1, r = i * 2 + 2, minIdx = i;
        if (l < h->size && h->cmp((char*)h->data + l * h->elemSize, (char*)h->data + minIdx * h->elemSize) < 0) {
            minIdx = l;
        }
        if (r < h->size && h->cmp((char*)h->data + r * h->elemSize, (char*)h->data + minIdx * h->elemSize) < 0) {
            minIdx = r;
        }
        if (minIdx == i) {
            break;
        }
        heapSwap(h, i, minIdx);
        i = minIdx;
    }
}

void* heapTop(MinHeap* h) {
    return h->data;
}

int heapEmpty(MinHeap* h) {
    return h->size == 0;
}

void heapFree(MinHeap* h) {
    free(h->data);
    free(h);
}

typedef struct {
    long long endTime;
    int room;
} UsedRoom;

int cmpInt(const void* a, const void* b) {
    return *(int*)a - *(int*)b;
}

int cmpUsedRoom(const void* a, const void* b) {
    const UsedRoom* ua = (const UsedRoom*)a;
    const UsedRoom* ub = (const UsedRoom*)b;
    if (ua->endTime != ub->endTime) {
        return ua->endTime < ub->endTime ? -1 : 1;
    }
    return ua->room - ub->room;
}

int cmpMeeting(const void* a, const void* b) {
    int* aa = *(int**)a;
    int* bb = *(int**)b;
    return aa[0] - bb[0];
}

int mostBooked(int n, int** meetings, int meetingsSize, int* meetingsColSize) {
    qsort(meetings, meetingsSize, sizeof(int*), cmpMeeting);

    MinHeap* availRooms = heapCreate(n, sizeof(int), cmpInt);
    for (int i = 0; i < n; i++) {
        heapPush(availRooms, &i);
    }

    MinHeap* usedRooms = heapCreate(meetingsSize, sizeof(UsedRoom), cmpUsedRoom);
    int *usedCount = (int*)calloc(n, sizeof(int));
    long long curTime = 0;

    for (int idx = 0; idx < meetingsSize; idx++) {
        int start = meetings[idx][0], end = meetings[idx][1];
        curTime = curTime > start ? curTime : start;
        UsedRoom ur;
        while (!heapEmpty(usedRooms) && ((UsedRoom*)heapTop(usedRooms))->endTime <= curTime) {
            heapPop(usedRooms, &ur);
            heapPush(availRooms, &ur.room);
        }
        if (heapEmpty(availRooms)) {
            curTime = ((UsedRoom*)heapTop(usedRooms))->endTime;
            while (!heapEmpty(usedRooms) && ((UsedRoom*)heapTop(usedRooms))->endTime <= curTime) {
                heapPop(usedRooms, &ur);
                heapPush(availRooms, &ur.room);
            }
        }
        int room;
        heapPop(availRooms, &room);
        usedCount[room]++;
        ur.endTime = curTime + end - start;
        ur.room = room;
        heapPush(usedRooms, &ur);
    }
    int ans = 0;
    for (int i = 1; i < n; i++) {
        if (usedCount[i] > usedCount[ans]) {
            ans = i;
        }
    }
    heapFree(availRooms);
    heapFree(usedRooms);
    free(usedCount);
    return ans;
}
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn most_booked(n: i32, mut meetings: Vec<Vec<i32>>) -> i32 {
        meetings.sort_unstable_by_key(|v| v[0]);
        let n = n as usize;
        let mut avail_rooms = BinaryHeap::new();
        for i in 0..n {
            avail_rooms.push(Reverse(i));
        }
        let mut used_rooms = BinaryHeap::new();
        let mut used_count = vec![0; n];
        let mut cur_time = 0i64;
        for meeting in meetings {
            cur_time = cur_time.max(meeting[0] as i64);
            while let Some(&Reverse((end_time, room))) = used_rooms.peek() {
                if end_time <= cur_time {
                    avail_rooms.push(Reverse(room));
                    used_rooms.pop();
                } else {
                    break;
                }
            }
            if avail_rooms.is_empty() {
                cur_time = used_rooms.peek().unwrap().0.0;
                while let Some(&Reverse((end_time, room))) = used_rooms.peek() {
                    if end_time <= cur_time {
                        avail_rooms.push(Reverse(room));
                        used_rooms.pop();
                    } else {
                        break;
                    }
                }
            }
            let Reverse(room) = avail_rooms.pop().unwrap();
            used_count[room] += 1;
            used_rooms.push(Reverse((cur_time + (meeting[1] - meeting[0]) as i64, room)));
        }
        let mut ans = 0;
        for i in 1..n {
            if used_count[i] > used_count[ans] {
                ans = i;
            }
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+m\log m+m\log n)$，其中 $n$ 是会议室的数目，$m$ 是会议的数目。$meetings$ 排序需要 $O(m\log m)$，availRooms 初始化需要 $O(n\log n)$，主循环需要 $O(m\log n)$。
- 空间复杂度：$O(n+\log m)$。排序需要栈空间 $O(\log m)$，优先队列需要 $O(n)$。
