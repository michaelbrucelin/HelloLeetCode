### [设计内存分配器](https://leetcode.cn/problems/design-memory-allocator/solutions/3078918/she-ji-nei-cun-fen-pei-qi-by-leetcode-so-djqx/)

#### 方法一：标记每个单元所属的 mID

**思路与算法**

我们可以使用一个长度为 $n$ 的数组 $memory$ 来标记所有内存单元的使用情况。初始时，每个元素的值为 $0$，表示未被分配（$mID$ 的范围是 $[1,1000]$）。

对于 $allocate(size, mID)$ 操作，我们遍历整个数组 $memory$，并且维护一个计数器 $count$。如果遍历到的元素值为 $0$，那么计数器加 $1$，否则计数器置零。当计数器的值达到 $size$ 时，我们就找到了第一个长度为 $size$ 的连续空闲内存单元。

对于 $freeMemory(mID)$ 操作，我们遍历整个数组 $memory$，如果遍历到元素的值为 $mID$，那么将其置 $0$，并将答案加 $1$。

**代码**

```C++
class Allocator {
public:
    Allocator(int n): n(n), memory(n) {}
    
    int allocate(int size, int mID) {
        int count = 0;
        for (int i = 0; i < n; ++i) {
            if (memory[i]) {
                count = 0;
            }
            else {
                ++count;
                if (count == size) {
                    for (int j = i - count + 1; j <= i; ++j) {
                        memory[j] = mID;
                    }
                    return i - count + 1;
                }
            }
        }
        return -1;
    }
    
    int freeMemory(int mID) {
        int count = 0;
        for (int i = 0; i < n; ++i) {
            if (memory[i] == mID) {
                ++count;
                memory[i] = 0;
            }
        }
        return count;
    }

private:
    int n;
    vector<int> memory;
};
```

```Python
class Allocator:

    def __init__(self, n: int):
        self.n = n
        self.memory = [0] * n

    def allocate(self, size: int, mID: int) -> int:
        count = 0
        for i in range(self.n):
            if self.memory[i]:
                count = 0
            else:
                count += 1
                if count == size:
                    for j in range(i - count + 1, i + 1):
                        self.memory[j] = mID
                    return i - count + 1
        return -1

    def freeMemory(self, mID: int) -> int:
        count = 0
        for i in range(self.n):
            if self.memory[i] == mID:
                count += 1
                self.memory[i] = 0
        return count
```

```Go
type Allocator struct {
    n int
    memory []int
}

func Constructor(n int) Allocator {
    return Allocator {
        n: n,
        memory: make([]int, n),
    }
}

func (this *Allocator) Allocate(size int, mID int) int {
    count := 0
    for i := 0; i < this.n; i++ {
        if this.memory[i] != 0 {
            count = 0
        } else {
            count++
            if count == size {
                for j := i - count + 1; j <= i; j++ {
                    this.memory[j] = mID
                }
                return i - count + 1
            }
        }
    }
    return -1
}


func (this *Allocator) FreeMemory(mID int) int {
    count := 0
    for i := 0; i < this.n; i++ {
        if this.memory[i] == mID {
            count++
            this.memory[i] = 0
        }
    }
    return count
}
```

```C
typedef struct {
    int n;
    int *memory;
} Allocator;

Allocator* allocatorCreate(int n) {
    Allocator *ret = (Allocator *)malloc(sizeof(Allocator));
    ret->n = n;
    ret->memory = (int *)malloc(n * sizeof(int));
    memset(ret->memory, 0, n * sizeof(int));
    return ret;
}

int allocatorAllocate(Allocator* obj, int size, int mID) {
    int count = 0;
    for (int i = 0; i < obj->n; ++i) {
        if (obj->memory[i]) {
            count = 0;
        } else {
            ++count;
            if (count == size) {
                for (int j = i - count + 1; j <= i; ++j) {
                    obj->memory[j] = mID;
                }
                return i - count + 1;
            }
        }
    }
    return -1;
}

int allocatorFreeMemory(Allocator* obj, int mID) {
    int count = 0;
    for (int i = 0; i < obj->n; ++i) {
        if (obj->memory[i] == mID) {
            ++count;
            obj->memory[i] = 0;
        }
    }
    return count;
}

void allocatorFree(Allocator* obj) {
    free(obj->memory);
    free(obj);
}
```

```Java
class Allocator {
    private int n;
    private int[] memory;

    public Allocator(int n) {
        this.n = n;
        this.memory = new int[n];
    }

    public int allocate(int size, int mID) {
        int count = 0;
        for (int i = 0; i < n; ++i) {
            if (memory[i] != 0) {
                count = 0;
            } else {
                ++count;
                if (count == size) {
                    for (int j = i - count + 1; j <= i; ++j) {
                        memory[j] = mID;
                    }
                    return i - count + 1;
                }
            }
        }
        return -1;
    }

    public int freeMemory(int mID) {
        int count = 0;
        for (int i = 0; i < n; ++i) {
            if (memory[i] == mID) {
                ++count;
                memory[i] = 0;
            }
        }
        return count;
    }
}
```

```CSharp
public class Allocator {
    private int n;
    private int[] memory;

    public Allocator(int n) {
        this.n = n;
        this.memory = new int[n];
    }

    public int Allocate(int size, int mID) {
        int count = 0;
        for (int i = 0; i < n; ++i) {
            if (memory[i] != 0) {
                count = 0;
            } else {
                ++count;
                if (count == size) {
                    for (int j = i - count + 1; j <= i; ++j) {
                        memory[j] = mID;
                    }
                    return i - count + 1;
                }
            }
        }
        return -1;
    }

    public int FreeMemory(int mID) {
        int count = 0;
        for (int i = 0; i < n; ++i) {
            if (memory[i] == mID) {
                ++count;
                memory[i] = 0;
            }
        }
        return count;
    }
}
```

```JavaScript
var Allocator = function(n) {
    this.n = n;
    this.memory = new Array(n).fill(0);
};

Allocator.prototype.allocate = function(size, mID) {
    let count = 0;
    for (let i = 0; i < this.n; ++i) {
        if (this.memory[i] !== 0) {
            count = 0;
        } else {
            ++count;
            if (count === size) {
                for (let j = i - count + 1; j <= i; ++j) {
                    this.memory[j] = mID;
                }
                return i - count + 1;
            }
        }
    }
    return -1;
};

Allocator.prototype.freeMemory = function(mID) {
    let count = 0;
    for (let i = 0; i < this.n; ++i) {
        if (this.memory[i] === mID) {
            ++count;
            this.memory[i] = 0;
        }
    }
    return count;
};

```

```TypeScript
class Allocator {
    private n: number;
    private memory: number[];

    constructor(n: number) {
        this.n = n;
        this.memory = new Array(n).fill(0);
    }

    allocate(size: number, mID: number): number {
        let count = 0;
        for (let i = 0; i < this.n; ++i) {
            if (this.memory[i] !== 0) {
                count = 0;
            } else {
                ++count;
                if (count === size) {
                    for (let j = i - count + 1; j <= i; ++j) {
                        this.memory[j] = mID;
                    }
                    return i - count + 1;
                }
            }
        }
        return -1;
    }

    freeMemory(mID: number): number {
        let count = 0;
        for (let i = 0; i < this.n; ++i) {
            if (this.memory[i] === mID) {
                ++count;
                this.memory[i] = 0;
            }
        }
        return count;
    }
}
```

```Rust
struct Allocator {
    n: usize,
    memory: Vec<i32>,
}

impl Allocator {
    fn new(n: i32) -> Self {
        Allocator {
            n: n as usize,
            memory: vec![0; n as usize],
        }
    }
    
    fn allocate(&mut self, size: i32, m_id: i32) -> i32 {
        let mut count = 0;
        for i in 0..self.n {
            if self.memory[i] != 0 {
                count = 0;
            } else {
                count += 1;
                if count == size {
                    for j in (i as i32 - count + 1)..=i as i32 {
                        self.memory[j as usize] = m_id;
                    }
                    return i as i32 - count + 1;
                }
            }
        }
        -1
    }
    
    fn free_memory(&mut self, m_id: i32) -> i32 {
        let mut count = 0;
        for i in 0..self.n {
            if self.memory[i] == m_id {
                count += 1;
                self.memory[i] = 0;
            }
        }
        count
    }
}
```

**复杂度分析**

- 时间复杂度：
  - 初始化的时间复杂度为 $O(n)$，需要初始化长度为 $n$ 的数组 $memory$；
  - $allocate(size, mID)$ 的时间复杂度为 $O(n)$；
  - $freeMemory(mID)$ 的时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，即为数组 $memory$ 需要使用的空间。$allocate(size, mID)$ 和 $freeMemory(mID)$ 均只需要 $O(1)$ 的额外空间。
