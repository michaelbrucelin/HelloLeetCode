### [设计浏览器历史记录](https://leetcode.cn/problems/design-browser-history/solutions/3071966/she-ji-liu-lan-qi-li-shi-ji-lu-by-leetco-ut18/)

#### 方法一：模拟

**思路与算法**

题目要求实现 $BrowserHistory$ 类，要求可以访问其他的网站 $url$，也可以在浏览历史中后退 $steps$ 步或前进 $steps$ 步。我们可以用动态数组 $urls$ 保存网页记录，用 $currIndex$ 指向当前访问网页在数组中的索引，当访问后退或者前进时，只需要移动索引 $currIndex$ 即可。具体实现如下：

- $BrowserHistory(string homepage)$：此时用 $homepage$ 初始化浏览器类。我们初始化动态数组 $urls$，且在 $urls$ 中添加元素 $homepage$，$currIndex$ 初始为 $0$；
- $void visit(string url)$：此时需要从当前页跳转访问 $url$ 对应的页面，并把浏览历史前进的记录全部删除。此时我们将索引 $currIndex$ 之后的记录从数组中全部删除，并在数组的末尾添加元素 $url$，并将 $currIndex$ 指向当前数组的末尾元素。
- $string back(int steps)$：此时需要在浏览历史中后退 $steps$ 步，由于移动不能超过已有的记录数目，即此时需要向左移动 $currIndex$，且最小不能超过 $0$，此时我们将 $currIndex$ 向左移动至 $max(currIndex - steps，0)$ 处即可；
- $string forward(int steps)$：在浏览历史中前进 $steps$ 步，由于移动不能超过已有的记录数目，即此时需要向右移动 $currIndex$，且最大不能超过 $urls$ 的长度，此时我们将 $currIndex$ 向右移动至 $min(currIndex + steps，len(urls) - 1)$ 处即可，其中 $len(urls)$ 表示数组 $urls$ 的长度；
    

**代码**

```C++
class BrowserHistory {
public:
    BrowserHistory(string homepage) {
        this->urls.push_back(homepage);
        this->currIndex = 0;
    }
    
    void visit(string url) {
        while (urls.size() > currIndex + 1) {
            urls.pop_back();
        }
        urls.push_back(url);
        this->currIndex++;
    }
    
    string back(int steps) {
        currIndex  = max(currIndex - steps, 0);
        return urls[currIndex];
    }
    
    string forward(int steps) {
        currIndex = min(currIndex + steps, int(urls.size() - 1));
        return urls[currIndex];
    }
private:
    vector<string> urls;
    int currIndex;
};
```

```Java
class BrowserHistory {
    private List<String> urls;
    private int currIndex;

    public BrowserHistory(String homepage) {
        this.urls = new ArrayList<>();
        this.urls.add(homepage);
        this.currIndex = 0;
    }
    
    public void visit(String url) {
        while (urls.size() > currIndex + 1) {
            urls.remove(urls.size() - 1);
        }
        urls.add(url);
        this.currIndex++;
    }
    
    public String back(int steps) {
        currIndex = Math.max(currIndex - steps, 0);
        return urls.get(currIndex);
    }
    
    public String forward(int steps) {
        currIndex = Math.min(currIndex + steps, urls.size() - 1);
        return urls.get(currIndex);
    }
}
```

```CSharp
public class BrowserHistory {
    private List<string> urls;
    private int currIndex;

    public BrowserHistory(string homepage) {
        this.urls = new List<string>();
        this.urls.Add(homepage);
        this.currIndex = 0;
    }
    
    public void Visit(string url) {
        while (urls.Count > currIndex + 1) {
            urls.RemoveAt(urls.Count - 1);
        }
        urls.Add(url);
        this.currIndex++;
    }
    
    public string Back(int steps) {
        currIndex = Math.Max(currIndex - steps, 0);
        return urls[currIndex];
    }
    
    public string Forward(int steps) {
        currIndex = Math.Min(currIndex + steps, urls.Count - 1);
        return urls[currIndex];
    }
}
```

```Go
type BrowserHistory struct {
    urls     []string
    currIndex int
}

func Constructor(homepage string) BrowserHistory {
    return BrowserHistory{
        urls:     []string{homepage},
        currIndex: 0,
    }
}

func (this *BrowserHistory) Visit(url string)  {
    for len(this.urls) > this.currIndex+1 {
        this.urls = this.urls[:this.currIndex + 1]
    }
    this.urls = append(this.urls, url)
    this.currIndex++
}

func (this *BrowserHistory) Back(steps int) string {
    this.currIndex = max(this.currIndex - steps, 0)
    return this.urls[this.currIndex]
}

func (this *BrowserHistory) Forward(steps int) string {
    this.currIndex = min(this.currIndex + steps, len(this.urls) - 1)
    return this.urls[this.currIndex]
}
```

```Python
class BrowserHistory:
    def __init__(self, homepage: str):
        self.urls = [homepage]
        self.currIndex = 0

    def visit(self, url: str) -> None:
        while len(self.urls) > self.currIndex + 1:
            self.urls.pop()
        self.urls.append(url)
        self.currIndex += 1

    def back(self, steps: int) -> str:
        self.currIndex = max(self.currIndex - steps, 0)
        return self.urls[self.currIndex]

    def forward(self, steps: int) -> str:
        self.currIndex = min(self.currIndex + steps, len(self.urls) - 1)
        return self.urls[self.currIndex]
```

```C
typedef struct {
    char** urls;
    int capacity;
    int size;
    int currIndex;
} BrowserHistory;

BrowserHistory* browserHistoryCreate(char* homepage) {
    BrowserHistory* obj = (BrowserHistory*)malloc(sizeof(BrowserHistory));
    obj->capacity = 64;
    obj->size = 1;
    obj->currIndex = 0;
    obj->urls = (char**)malloc(obj->capacity * sizeof(char*));
    obj->urls[0] = strdup(homepage);
    return obj;
}

void browserHistoryVisit(BrowserHistory* obj, char* url) {
    while (obj->size > obj->currIndex + 1) {
        free(obj->urls[obj->size - 1]);
        obj->size--;
    }
    if (obj->size == obj->capacity) {
        obj->capacity *= 2;
        obj->urls = (char**)realloc(obj->urls, obj->capacity * sizeof(char*));
    }
    obj->urls[obj->size] = strdup(url);
    obj->size++;
    obj->currIndex++;
}

char* browserHistoryBack(BrowserHistory* obj, int steps) {
    obj->currIndex = fmax(obj->currIndex - steps, 0);
    return obj->urls[obj->currIndex];
}

char* browserHistoryForward(BrowserHistory* obj, int steps) {
    obj->currIndex = fmin(obj->currIndex + steps, obj->size - 1);
    return obj->urls[obj->currIndex];
}

void browserHistoryFree(BrowserHistory* obj) {
    for (int i = 0; i < obj->size; i++) {
        free(obj->urls[i]);
    }
    free(obj->urls);
    free(obj);
}
```

```JavaScript
var BrowserHistory = function(homepage) {
    this.urls = [homepage];
    this.currIndex = 0;
};

BrowserHistory.prototype.visit = function(url) {
    this.urls = this.urls.slice(0, this.currIndex + 1);
    this.urls.push(url);
    this.currIndex++;
};

BrowserHistory.prototype.back = function(steps) {
    this.currIndex = Math.max(this.currIndex - steps, 0);
    return this.urls[this.currIndex];
};

BrowserHistory.prototype.forward = function(steps) {
    this.currIndex = Math.min(this.currIndex + steps, this.urls.length - 1);
    return this.urls[this.currIndex];
};
```

```TypeScript
class BrowserHistory {
    private urls: string[];
    private currIndex: number;

    constructor(homepage: string) {
        this.urls = [homepage];
        this.currIndex = 0;
    }

    visit(url: string): void {
        this.urls = this.urls.slice(0, this.currIndex + 1);
        this.urls.push(url);
        this.currIndex++;
    }

    back(steps: number): string {
        this.currIndex = Math.max(this.currIndex - steps, 0);
        return this.urls[this.currIndex];
    }

    forward(steps: number): string {
        this.currIndex = Math.min(this.currIndex + steps, this.urls.length - 1);
        return this.urls[this.currIndex];
    }
}
```

```Rust
use std::cmp::{max, min};

struct BrowserHistory {
    urls: Vec<String>,
    curr_index: usize,
}

impl BrowserHistory {
    fn new(homepage: String) -> Self {
        BrowserHistory {
            urls: vec![homepage],
            curr_index: 0,
        }
    }
    
    fn visit(&mut self, url: String) {
        self.urls.truncate(self.curr_index + 1);
        self.urls.push(url);
        self.curr_index += 1;
    }
    
    fn back(&mut self, steps: i32) -> String {
        self.curr_index = max(self.curr_index as i32 - steps, 0) as usize;
        return self.urls[self.curr_index].clone();
    }
    
    fn forward(&mut self, steps: i32) -> String {
        self.curr_index = std::cmp::min(self.curr_index + steps as usize, self.urls.len() - 1);
        return self.urls[self.curr_index].clone();
    }
}
```

**复杂度分析**

- 时间复杂度：调用 $visit$ 执行的时间复杂度 为 $O(n)$，$n$ 表示执行 $visit$ 的调用次数，调用 $back$ 和 $forward$ 需要的时间复杂度为 $O(1)$。由于网页记录最多有 $n$ 个，删除网页记录需要的时间最多为 $O(n)$。
- 空间复杂度：$O(n)$，$n$ 表示执行 $visit$ 的调用次数。由于需要保存每次访问的网页记录，最多需要保存 $n$ 次记录，因此需要的空间为 $O(n)$。
