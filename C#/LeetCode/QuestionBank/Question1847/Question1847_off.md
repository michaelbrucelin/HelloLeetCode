### [最近的房间](https://leetcode.cn/problems/closest-room/solutions/754916/zui-jin-de-fang-jian-by-leetcode-solutio-9ylf/)

#### 方法一：离线算法

**提示 1**

如果我们可以将给定的房间和询问重新排序，那么是否可以使得问题更加容易解决？

**提示 2**

我们可以将房间以及询问都看成一个「事件」，如果我们将这些「事件」按照大小（房间的 $size$ 或者询问的 $minSize$）进行降序排序，那么：

- 如果我们遇到一个表示房间的「事件」，那么可以将该房间的 $roomId$ 加入某一「数据结构」中；
- 如果我们遇到一个表示询问的「事件」，那么需要在「数据结构」中寻找与 $preferred$ 最接近的 $roomId$。

**提示 3**

你能想出一种合适的「数据结构」吗？

**思路与算法**

我们使用「有序集合」作为提示中的「数据结构」。

根据提示 2，我们将每一个房间以及询问对应一个「事件」，放入数组中进行降序排序。随后我们遍历这些「事件」：

- 如果我们遇到一个表示房间的「事件」，那么将该该房间的 $roomId$ 加入「有序集合」中；
- 如果我们遇到一个表示询问的「事件」，那么答案即为「有序集合」中与询问的 $preferred$ 最接近的那个 $roomId$。在大部分语言的「有序集合」的 $API$ 中，提供了例如「在有序集合中查找最小的大于等于 $x$ 的元素」或者「在有序集合中查找最小的严格大于 $x$ 的元素」，我们可以利用这些 $API$ 找出「有序集合」中与 $preferred$ 最接近的两个元素，其中一个小于 $preferred$，另一个大于等于 $preferred$。通过比较这两个元素，我们即可得到该询问对应的答案。

**细节**

如果不同类型的「事件」的位置相同，那么我们应当按照先处理表示房间的「事件」，再处理表示询问的「事件」，这是因为房间的 $size$ 只要大于等于询问的 $minSize$ 就是满足要求的。

**代码**

```C++
struct Event {
    // 事件的类型，0 表示房间，1 表示询问
    int type;
    // 房间的 size 或者询问的 minSize
    int size;
    // 房间的 roomId 或者询问的 preferred
    int id;
    // 房间在数组 room 中的原始编号或者询问在数组 queries 中的原始编号
    int origin;
    
    Event(int _type, int _size, int _id, int _origin): type(_type), size(_size), id(_id), origin(_origin) {}
    
    // 自定义比较函数，按照事件的 size 降序排序
    // 如果 size 相同，优先考虑房间
    bool operator< (const Event& that) const {
        return size > that.size || (size == that.size && type < that.type);
    }
};

class Solution {
public:
    vector<int> closestRoom(vector<vector<int>>& rooms, vector<vector<int>>& queries) {
        int m = rooms.size();
        int n = queries.size();
        
        vector<Event> events;
        for (int i = 0; i < m; ++i) {
            // 房间事件
            events.emplace_back(0, rooms[i][1], rooms[i][0], i);
        }
        for (int i = 0; i < n; ++i) {
            // 询问事件
            events.emplace_back(1, queries[i][1], queries[i][0], i);
        }

        sort(events.begin(), events.end());
        vector<int> ans(n, -1);
        // 存储房间 roomId 的有序集合
        set<int> valid;
        for (const auto& event: events) {
            if (event.type == 0) {
                // 房间事件，将 roomId 加入有序集合
                valid.insert(event.id);
            }
            else {
                // 询问事件
                int dist = INT_MAX;
                // 查找最小的大于等于 preferred 的元素
                auto it = valid.lower_bound(event.id);
                if (it != valid.end() && *it - event.id < dist) {
                    dist = *it - event.id;
                    ans[event.origin] = *it;
                }
                if (it != valid.begin()) {
                    // 查找最大的严格小于 preferred 的元素
                    it = prev(it);
                    if (event.id - *it <= dist) {
                        dist = event.id - *it;
                        ans[event.origin] = *it;
                    }
                }
            }
        }
        
        return ans;
    }
};
```

```Python
class Event:
    """
    op: 事件的类型，0 表示房间，1 表示询问
    size: 房间的 size 或者询问的 minSize
    idx: 房间的 roomId 或者询问的 preferred
    origin: 房间在数组 room 中的原始编号或者询问在数组 queries 中的原始编号
    """
    def __init__(self, op: int, size: int, idx: int, origin: int):
        self.op = op
        self.size = size
        self.idx = idx
        self.origin = origin

    """
    自定义比较函数，按照事件的 size 降序排序
    如果 size 相同，优先考虑房间
    """
    def __lt__(self, other: "Event") -> bool:
        return self.size > other.size or (self.size == other.size and self.op < other.op)

class Solution:
    def closestRoom(self, rooms: List[List[int]], queries: List[List[int]]) -> List[int]:
        n = len(queries)

        events = list()
        for i, (roomId, size) in enumerate(rooms):
            # 房间事件
            events.append(Event(0, size, roomId, i))

        for i, (minSize, preferred) in enumerate(queries):
            # 询问事件
            events.append(Event(1, preferred, minSize, i))

        events.sort()

        ans = [-1] * n
        # 存储房间 roomId 的有序集合
        # 需要导入 sortedcontainers 库
        valid = sortedcontainers.SortedList()
        for event in events:
            if event.op == 0:
                # 房间事件，将 roomId 加入有序集合
                valid.add(event.idx)
            else:
                # 询问事件
                dist = float("inf")
                # 查找最小的大于等于 preferred 的元素
                x = valid.bisect_left(event.idx)
                if x != len(valid) and valid[x] - event.idx < dist:
                    dist = valid[x] - event.idx
                    ans[event.origin] = valid[x]
                if x != 0:
                    # 查找最大的严格小于 preferred 的元素
                    x -= 1
                    if event.idx - valid[x] <= dist:
                        dist = event.idx - valid[x]
                        ans[event.origin] = valid[x]
            
        return ans
```

```Java
class Event implements Comparable<Event> {
    int type, size, id, origin;

    public Event(int type, int size, int id, int origin) {
        this.type = type;
        this.size = size;
        this.id = id;
        this.origin = origin;
    }

    @Override
    public int compareTo(Event that) {
        // 自定义比较函数，按照事件的 size 降序排序
        // 如果 size 相同，优先考虑房间
        if (this.size != that.size) {
            return Integer.compare(that.size, this.size);
        } else {
            return Integer.compare(this.type, that.type);
        }
    }
}

class Solution {
    public int[] closestRoom(int[][] rooms, int[][] queries) {
        int m = rooms.length;
        int n = queries.length;

        // 创建事件列表，存储房间和询问事件
        List<Event> events = new ArrayList<>();
        for (int i = 0; i < m; ++i) {
            // 房间事件
            events.add(new Event(0, rooms[i][1], rooms[i][0], i));
        }
        for (int i = 0; i < n; ++i) {
            // 询问事件
            events.add(new Event(1, queries[i][1], queries[i][0], i));
        }
        // 对事件列表进行排序
        Collections.sort(events);
        int[] ans = new int[n];
        Arrays.fill(ans, -1);
        // 使用 TreeSet 存储房间 roomId 的有序集合
        TreeSet<Integer> valid = new TreeSet<>();

        for (Event event : events) {
            if (event.type == 0) {
                // 房间事件，将 roomId 加入有序集合
                valid.add(event.id);
            } else {
                // 询问事件，查找最近的房间
                Integer higher = valid.ceiling(event.id);
                Integer lower = valid.floor(event.id);
                int dist = Integer.MAX_VALUE;

                // 查找最小的大于等于 preferred 的元素
                if (higher != null && higher - event.id < dist) {
                    dist = higher - event.id;
                    ans[event.origin] = higher;
                }
                // 查找最大的严格小于 preferred 的元素
                if (lower != null && event.id - lower <= dist) {
                    ans[event.origin] = lower;
                }
            }
        }

        return ans;
    }
}
```

```CSharp
// 定义事件类，实现 IComparable 接口用于排序
class Event : IComparable<Event> {
    public int Type, Size, Id, Origin;
    public Event(int type, int size, int id, int origin) {
        // 初始化事件的类型、size、id 和 origin
        Type = type;
        Size = size;
        Id = id;
        Origin = origin;
    }

    public int CompareTo(Event that) {
        // 自定义比较函数，按照事件的 size 降序排序
        // 如果 size 相同，优先考虑房间
        if (this.Size != that.Size) {
            return that.Size.CompareTo(this.Size);
        } else {
            return this.Type.CompareTo(that.Type);
        }
    }
}

public class Solution {
    public int[] ClosestRoom(int[][] rooms, int[][] queries) {
        int m = rooms.Length;
        int n = queries.Length;

        // 创建事件列表，存储房间和询问事件
        List<Event> events = new List<Event>();
        for (int i = 0; i < m; ++i) {
            // 房间事件
            events.Add(new Event(0, rooms[i][1], rooms[i][0], i));
        }
        for (int i = 0; i < n; ++i) {
            // 询问事件
            events.Add(new Event(1, queries[i][1], queries[i][0], i));
        }

        // 对事件列表进行排序
        events.Sort();
        int[] ans = new int[n];
        Array.Fill(ans, -1);
        // 使用 SortedSet 存储房间 roomId 的有序集合
        SortedSet<int> valid = new SortedSet<int>();
        foreach (var ev in events) {
            if (ev.Type == 0) {
                // 房间事件，将 roomId 加入有序集合
                valid.Add(ev.Id);
            } else {
                // 询问事件，查找最近的房间
                int dist = int.MaxValue;
                var ceiling = valid.GetViewBetween(ev.Id, int.MaxValue).Min;
                if (ceiling != default && ceiling - ev.Id < dist) {
                    dist = ceiling - ev.Id;
                    ans[ev.Origin] = ceiling;
                }
                var floor = valid.GetViewBetween(0, ev.Id).Max;
                if (floor != default && ev.Id - floor <= dist) {
                    ans[ev.Origin] = floor;
                }
            }
        }

        return ans;
    }
}
```

```Rust
use std::collections::BTreeSet;

#[derive(Debug)]
struct Event {
    // 事件的类型，0 表示房间，1 表示询问
    event_type: i32,
    // 房间的 size 或者询问的 minSize
    size: i32,
    // 房间的 roomId 或者询问的 preferred
    id: i32,
    // 房间在数组 room 中的原始编号或者询问在数组 queries 中的原始编号
    origin: usize,
}

impl Event {
    fn new(event_type: i32, size: i32, id: i32, origin: usize) -> Self {
        Event {
            event_type,
            size,
            id,
            origin,
        }
    }
}


// 自定义比较函数，按照事件的 size 降序排序
// 如果 size 相同，优先考虑房间
impl PartialEq for Event {
    fn eq(&self, other: &Self) -> bool {
        self.size == other.size && self.event_type == other.event_type
    }
}

impl Eq for Event {}

impl PartialOrd for Event {
    fn partial_cmp(&self, other: &Self) -> Option<std::cmp::Ordering> {
        Some(self.cmp(other))
    }
}

impl Ord for Event {
    fn cmp(&self, other: &Self) -> std::cmp::Ordering {
        other
            .size
            .cmp(&self.size)
            .then(self.event_type.cmp(&other.event_type))
    }
}


impl Solution {
    pub fn closest_room(rooms: Vec<Vec<i32>>, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let mut events = Vec::new();
        for (i, room) in rooms.iter().enumerate() {
            // 房间事件
            events.push(Event::new(0, room[1], room[0], i));
        }
        for (i, query) in queries.iter().enumerate() {
            // 询问事件
            events.push(Event::new(1, query[1], query[0], i));
        }

        // 对事件进行排序
        events.sort();
        // 用于存储房间的 roomId 的有序集合
        let mut valid_rooms = BTreeSet::new();
        let mut ans = vec![-1; queries.len()];
        for event in events {
            if event.event_type == 0 {
                // 房间事件，将 roomId 加入有序集合
                valid_rooms.insert(event.id);
            } else {
                // 询问事件
                let mut dist = i32::MAX;
                // 查找大于等于 preferred 的最小房间
                if let Some(&ceiling) = valid_rooms.range(event.id..).next() {
                    if ceiling - event.id < dist {
                        dist = ceiling - event.id;
                        ans[event.origin] = ceiling;
                    }
                }

                // 查找小于 preferred 的最大房间
                if let Some(&floor) = valid_rooms.range(..event.id).next_back() {
                    if event.id - floor <= dist {
                        ans[event.origin] = floor;
                    }
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+q)log(n+q))$，其中 $n$ 是数组 $rooms$ 的长度，$q$ 是数组 $queries$ 的长度。「事件」的数量为 $n+q=O(n+q)$，因此需要 $O((n+q)log(n+q))$ 的时间进行排序。在这之后，我们需要 $O(n+q)$ 的时间对事件进行遍历，而对有序集合进行操作的单次时间复杂度为 $O(logn)$，总时间复杂度为 $O((n+q)logn)$，在渐进意义下小于前者，可以忽略。
- 空间复杂度：$O(n+q)$。我们需要 $O(n+q)$ 的空间存储「事件」，以及 $O(n)$ 的空间分配给有序集合，因此总空间复杂度为 $O(n+q)$。
