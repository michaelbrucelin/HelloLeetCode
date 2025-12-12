### [统计用户被提及情况](https://leetcode.cn/problems/count-mentions-per-user/solutions/3851672/tong-ji-yong-hu-bei-ti-ji-qing-kuang-by-36og5/)

#### 方法一：排序后回放

**思路与算法**

我们首先对所有事件按照时间排序，对于时间相同的事件，应该将离线事件放在前面，因为按照题意，用户状态的改变会在所有相同时间发生的消息事件之前进行处理和同步。

排序后，我们按照时间顺序从前往后依次处理每个事件，我们可以用一个哈希表来记录每个用户的上线时间，并通过与当前时间比较来判断该用户是否在线。遍历时：

1. 对于消息事件，提及对象是 $ALL$ 和 $HERE$ 的情况比较好处理。而对于另外一种情况，我们需要解析包含多个指定 $id$ 的 $mentions\_string$，它由多个空格分割的 $idx$ 组成，其中 $x$ 是我们要解析出来的整数。对于大多数语言，我们可以将连续的数字拼接起来得到一个 $id$，当遇到字符串结尾或下个字符为空格时表示分割。而对于一些提供了字符串分割方法的语言，我们可以将字符串按照空格 $split$，然后去除每个条目的前缀，即可得到用户 $id$。
2. 对于离线事件，在哈希表中将指定用户的上线设置为 $60$ 个单位时间之后。

**代码**

```C++
class Solution {
public:
    vector<int> countMentions(int numberOfUsers, vector<vector<string>>& events) {
        vector<int> count(numberOfUsers);
        vector<int> next_online_time(numberOfUsers);
        sort(events.begin(), events.end(), [&](const vector<string> &lth, const vector<string> &rth) {
            int lth_timestamp = stoi(lth[1]);
            int rth_timestamp = stoi(rth[1]);
            if (lth_timestamp != rth_timestamp) {
                return lth_timestamp < rth_timestamp;
            }
            if (rth[0] == "OFFLINE") {
                return false;
            }
            return true;
        });
        
        for (auto&& event : events) {
            int cur_time = stoi(event[1]);
            if (event[0] == "MESSAGE") {
                if (event[2] == "ALL") {
                    for (int i = 0; i < numberOfUsers; i++) {
                        count[i]++;
                    }
                } else if (event[2] == "HERE") {
                    for (int i = 0; i < numberOfUsers; i++) {
                        if (next_online_time[i] <= cur_time) {
                            count[i]++;
                        }
                    }
                } else {
                    int idx = 0;
                    for (int i = 0; i < event[2].size(); i++) {
                        if (isdigit(event[2][i])) {
                            idx = idx * 10 + (event[2][i] - '0');
                        }
                        if (i + 1 == event[2].size() || event[2][i + 1] == ' ') {
                            count[idx]++;
                            idx = 0;
                        }
                    }
                }
            } else {
                int idx = stoi(event[2]);
                next_online_time[idx] = cur_time + 60;
            }
        }
        return count;
    }
};
```

```Python
class Solution:
    def countMentions(self, numberOfUsers: int, events: List[List[str]]) -> List[int]:
        events.sort(key=lambda e: (int(e[1]), e[0] == "MESSAGE"))
        count = [0] * numberOfUsers
        next_online_time = [0] * numberOfUsers
        for event in events:
            cur_time = int(event[1])
            if event[0] == "MESSAGE":
                if event[2] == "ALL":
                    for i in range(numberOfUsers):
                        count[i] += 1
                elif event[2] == "HERE":
                    for i, t in enumerate(next_online_time):
                        if t <= cur_time:
                            count[i] += 1
                else:
                    for idx in event[2].split():
                        count[int(idx[2:])] += 1
            else:
                next_online_time[int(event[2])] = cur_time + 60
        return count
```

```Rust
impl Solution {
    pub fn count_mentions(n: i32, mut events: Vec<Vec<String>>) -> Vec<i32> {
        let n = n as usize;
        events.sort_by(|a, b| {
            let ta = a[1].parse::<i32>().unwrap();
            let tb = b[1].parse::<i32>().unwrap();

            ta.cmp(&tb).then_with(|| {
                (a[0] != "OFFLINE").cmp(&(b[0] != "OFFLINE"))
            })
        });

        let mut count = vec![0; n];
        let mut next_online = vec![0; n];

        for e in events {
            let cur = e[1].parse::<i32>().unwrap();

            match e[0].as_str() {
                "MESSAGE" => match e[2].as_str() {
                    "ALL" => count.iter_mut().for_each(|x| *x += 1),
                    "HERE" => {
                        for i in 0..n {
                            if next_online[i] <= cur {
                                count[i] += 1;
                            }
                        }
                    }
                    other => {
                        for id in other.split_whitespace() {
                            let idx: usize = id[2..].parse().unwrap();
                            count[idx] += 1;
                        }
                    }
                },
                _ => {
                    let id: usize = e[2].parse().unwrap();
                    next_online[id] = cur + 60;
                }
            }
        }

        count
    }
}
```

```Java
class Solution {
    public int[] countMentions(int numberOfUsers, List<List<String>> events) {
        events.sort((a, b) -> {
            int timeA = Integer.parseInt(a.get(1));
            int timeB = Integer.parseInt(b.get(1));
            if (timeA != timeB) {
                return Integer.compare(timeA, timeB);
            }
            boolean aIsMessage = a.get(0).equals("MESSAGE");
            boolean bIsMessage = b.get(0).equals("MESSAGE");
            return Boolean.compare(aIsMessage, bIsMessage); 
        });
        
        int[] count = new int[numberOfUsers];
        int[] nextOnlineTime = new int[numberOfUsers];
        
        for (List<String> event : events) {
            int curTime = Integer.parseInt(event.get(1));
            String type = event.get(0);
            
            if (type.equals("MESSAGE")) {
                String target = event.get(2);
                if (target.equals("ALL")) {
                    for (int i = 0; i < numberOfUsers; i++) {
                        count[i]++;
                    }
                } else if (target.equals("HERE")) {
                    for (int i = 0; i < numberOfUsers; i++) {
                        if (nextOnlineTime[i] <= curTime) {
                            count[i]++;
                        }
                    }
                } else {
                    String[] users = target.split(" ");
                    for (String user : users) {
                        int idx = Integer.parseInt(user.substring(2));
                        count[idx]++;
                    }
                }
            } else {
                int idx = Integer.parseInt(event.get(2));
                nextOnlineTime[idx] = curTime + 60;
            }
        }
        
        return count;
    }
}
```

```CSharp
public class Solution {
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events) {
        var sortedEvents = events.OrderBy(e => int.Parse(e[1]))
                                .ThenBy(e => e[0] == "MESSAGE" ? 1 : 0)
                                .ToList();
        
        int[] count = new int[numberOfUsers];
        int[] nextOnlineTime = new int[numberOfUsers];
        
        foreach (var eventItem in sortedEvents) {
            int curTime = int.Parse(eventItem[1]);
            string type = eventItem[0];
            
            if (type == "MESSAGE") {
                string target = eventItem[2];
                if (target == "ALL") {
                    for (int i = 0; i < numberOfUsers; i++) {
                        count[i]++;
                    }
                } else if (target == "HERE") {
                    for (int i = 0; i < numberOfUsers; i++) {
                        if (nextOnlineTime[i] <= curTime) {
                            count[i]++;
                        }
                    }
                } else {
                    string[] users = target.Split(' ');
                    foreach (string user in users) {
                        int idx = int.Parse(user.Substring(2));
                        count[idx]++;
                    }
                }
            } else {
                int idx = int.Parse(eventItem[2]);
                nextOnlineTime[idx] = curTime + 60;
            }
        }
        
        return count;
    }
}
```

```Go
func countMentions(numberOfUsers int, events [][]string) []int {
    sort.Slice(events, func(i, j int) bool {
        timeA, _ := strconv.Atoi(events[i][1])
        timeB, _ := strconv.Atoi(events[j][1])
        if timeA != timeB {
            return timeA < timeB
        }
        return events[i][0] != "MESSAGE" && events[j][0] == "MESSAGE"
    })
    
    count := make([]int, numberOfUsers)
    nextOnlineTime := make([]int, numberOfUsers)
    
    for _, event := range events {
        curTime, _ := strconv.Atoi(event[1])
        eventType := event[0]
        
        if eventType == "MESSAGE" {
            target := event[2]
            switch target {
            case "ALL":
                for i := 0; i < numberOfUsers; i++ {
                    count[i]++
                }
            case "HERE":
                for i := 0; i < numberOfUsers; i++ {
                    if nextOnlineTime[i] <= curTime {
                        count[i]++
                    }
                }
            default:
                users := strings.Split(target, " ")
                for _, user := range users {
                    idx, _ := strconv.Atoi(user[2:])
                    count[idx]++
                }
            }
        } else {
            idx, _ := strconv.Atoi(event[2])
            nextOnlineTime[idx] = curTime + 60
        }
    }
    
    return count
}
```

```C
typedef struct {
    char type[8];
    int timestamp;
    char target[512];
} Event;

int compareEvents(const void* a, const void* b) {
    Event* e1 = (Event*)a;
    Event* e2 = (Event*)b;
    if (e1->timestamp != e2->timestamp) {
        return e1->timestamp - e2->timestamp;
    }

    return strcmp(e1->type, "OFFLINE") == 0 ? -1 : 1;
}

int* countMentions(int numberOfUsers, char*** events, int eventsSize, int* eventsColSize, int* returnSize) {
    Event* eventArr = (Event*)calloc(eventsSize, sizeof(Event));
    for (int i = 0; i < eventsSize; i++) {
        strcpy(eventArr[i].type, events[i][0]);
        eventArr[i].timestamp = atoi(events[i][1]);
        strcpy(eventArr[i].target, events[i][2]);
    }
    
    qsort(eventArr, eventsSize, sizeof(Event), compareEvents);
    int* count = (int*)calloc(numberOfUsers, sizeof(int));
    int* nextOnlineTime = (int*)calloc(numberOfUsers, sizeof(int));
    
    for (int i = 0; i < eventsSize; i++) {
        int curTime = eventArr[i].timestamp;
        char* type = eventArr[i].type;
        char* target = eventArr[i].target;
        if (strcmp(type, "MESSAGE") == 0) {
            if (strcmp(target, "ALL") == 0) {
                for (int j = 0; j < numberOfUsers; j++) {
                    count[j]++;
                }
            } else if (strcmp(target, "HERE") == 0) {
                for (int j = 0; j < numberOfUsers; j++) {
                    if (nextOnlineTime[j] <= curTime) {
                        count[j]++;
                    }
                }
            } else {
                char* token = strtok(target, " ");
                while (token != NULL) {
                    int idx = atoi(token + 2);
                    count[idx]++;
                    token = strtok(NULL, " ");
                }
            }
        } else {
            int idx = atoi(target);
            nextOnlineTime[idx] = curTime + 60;
        }
    }
    
    free(eventArr);
    free(nextOnlineTime);
    *returnSize = numberOfUsers;
    return count;
}
```

```JavaScript
var countMentions = function(numberOfUsers, events) {
    events.sort((a, b) => {
        const timeA = parseInt(a[1]);
        const timeB = parseInt(b[1]);
        if (timeA !== timeB) {
            return timeA - timeB;
        }
        return (b[0] === "MESSAGE" ? 0 : 1) - (a[0] === "MESSAGE" ? 0 : 1);
    });
    
    const count = new Array(numberOfUsers).fill(0);
    const nextOnlineTime = new Array(numberOfUsers).fill(0);
    
    for (const event of events) {
        const curTime = parseInt(event[1]);
        const type = event[0];
        
        if (type === "MESSAGE") {
            const target = event[2];
            if (target === "ALL") {
                for (let i = 0; i < numberOfUsers; i++) {
                    count[i]++;
                }
            } else if (target === "HERE") {
                for (let i = 0; i < numberOfUsers; i++) {
                    if (nextOnlineTime[i] <= curTime) {
                        count[i]++;
                    }
                }
            } else {
                const users = target.split(' ');
                for (const user of users) {
                    const idx = parseInt(user.substring(2));
                    count[idx]++;
                }
            }
        } else {
            const idx = parseInt(event[2]);
            nextOnlineTime[idx] = curTime + 60;
        }
    }
    
    return count;
};
```

```TypeScript
function countMentions(numberOfUsers: number, events: string[][]): number[] {
    events.sort((a: string[], b: string[]): number => {
        const timeA: number = parseInt(a[1]);
        const timeB: number = parseInt(b[1]);
        if (timeA !== timeB) {
            return timeA - timeB;
        }
        return (b[0] === "MESSAGE" ? 0 : 1) - (a[0] === "MESSAGE" ? 0 : 1);
    });
    
    const count: number[] = new Array(numberOfUsers).fill(0);
    const nextOnlineTime: number[] = new Array(numberOfUsers).fill(0);
    
    for (const event of events) {
        const curTime: number = parseInt(event[1]);
        const type: string = event[0];
        
        if (type === "MESSAGE") {
            const target: string = event[2];
            if (target === "ALL") {
                for (let i = 0; i < numberOfUsers; i++) {
                    count[i]++;
                }
            } else if (target === "HERE") {
                for (let i = 0; i < numberOfUsers; i++) {
                    if (nextOnlineTime[i] <= curTime) {
                        count[i]++;
                    }
                }
            } else {
                const users: string[] = target.split(' ');
                for (const user of users) {
                    const idx: number = parseInt(user.substring(2));
                    count[idx]++;
                }
            }
        } else {
            const idx: number = parseInt(event[2]);
            nextOnlineTime[idx] = curTime + 60;
        }
    }
    
    return count;
}
```

**复杂度分析**

- 时间复杂度：$O(nm+m\log m\log t)$。其中 $n$ 是 $numberOfUsers$，$m$ 是 $events$ 的长度，$t$ 是最大时间戳。对 $events$ 排序的时间复杂度是 $O(m\log m\log t)$，时间戳解析的时间复杂度是 $O(\log t)$。遍历每个事件，并处理的时间复杂度为 $O(nm)$。
- 空间复杂度：$O(n)$。
