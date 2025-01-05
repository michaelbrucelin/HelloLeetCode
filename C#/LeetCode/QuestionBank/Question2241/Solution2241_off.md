### [设计一个 ATM 机器](https://leetcode.cn/problems/design-an-atm-machine/solutions/1485677/she-ji-yi-ge-atm-ji-qi-by-leetcode-solut-etxe/)

#### 方法一：维护每种钞票的剩余数目

**思路与算法**

首先我们尝试分析各个方法对应的需求：

- 对于 $deposit()$ 方法，我们需要更新每张钞票的数目；
- 对于 $withdraw()$ 方法，我们需要模拟机器从高面额至低面额尝试取钱的过程，判断是否可行，并尝试更新每张钞票的数目，以及返回取出各种面额钞票的数目。

我们可以用一个数组 $cnt$ 来维护每种钞票的剩余数目，同时用数组 $value$ 来维护 $cnt$ 数组对应下标钞票的面额。为了方便起见，我们需要让 $value$ 数组保持升序。

那么，对于 $deposit()$ 方法，我们只需要遍历输入数组，并将每个元素的值加在 $cnt$ 中的对应元素上即可。

而对于 $withdraw()$ 方法，我们需要倒序（即从高面额至低面额）遍历 $cnt$ 数组，并模拟取钱操作。

具体而言，我们用数组 $res$ 表示（如果可行）取出各种钞票的数目，同时倒序遍历 $cnt$ 数组，并更新还需要取的金额数目 $amount$。当遍历到下标 $i$ 时，我们首先计算该面额钞票需要取出的数量 $res[i]$。对应钞票的数量不能多余取款机中该种钞票的数量，且总面额不能高于还需取出的金额数目。因此我们有 $res[i]=min(cnt[i], \lfloor amount/min(value[i] \rfloor)$（其中 $\lfloor \dots \rfloor$ 代表向下取整）。同时，我们需要对应地将 $amount$ 减去 $res[i] \times value[i]$。

当遍历完成后，如果 $amount=0$，即代表可以进行该取出操作，我们将 $cnt$ 数组地每个元素减去 $res$ 数组的对应元素，并返回 $res$ 作为答案；而如果 $amount > 0$，则说明无法进行取出操作，我们应当不进行任何操作，直接返回 $[-1]$。

**细节**

在操作过程中，$cnt$ 数组的元素数值有可能超过 $32$ 位有符号整数的上限，因此对于 C++ 等语言，我们需要用 $64$ 位整数存储每种钞票的剩余数目。

**代码**

```C++
class ATM {
private:
    vector<long long> cnt;   // 每张钞票剩余数量
    vector<long long> value;   // 每张钞票面额
    
public:
    ATM() {
        cnt = {0, 0, 0, 0, 0};
        value = {20, 50, 100, 200, 500};
    }
    
    void deposit(vector<int> banknotesCount) {
        for (int i = 0; i < 5; ++i) {
            cnt[i] += banknotesCount[i];
        }
    }
    
    vector<int> withdraw(int amount) {
        vector<int> res(5);
        // 模拟尝试取出钞票的过程
        for (int i = 4; i >= 0; --i) {
            res[i] = min(cnt[i], amount / value[i]);
            amount -= res[i] * value[i];
        }
        if (amount) {
            // 无法完成该操作
            return {-1};
        } else {
            // 可以完成该操作
            for (int i = 0; i < 5; ++i) {
                cnt[i] -= res[i];
            }
            return res;
        }
    }
};
```

```Python
class ATM:

    def __init__(self):
        self.cnt = [0] * 5   # 每张钞票剩余数量
        self.value = [20, 50, 100, 200, 500]   # 每张钞票面额


    def deposit(self, banknotesCount: List[int]) -> None:
        for i in range(5):
            self.cnt[i] += banknotesCount[i]


    def withdraw(self, amount: int) -> List[int]:
        res = [0] * 5
        # 模拟尝试取出钞票的过程
        for i in range(4, -1, -1):
            res[i] = min(self.cnt[i], amount // self.value[i])
            amount -= res[i] * self.value[i]
        if amount:
            # 无法完成该操作
            return [-1]
        else:
            # 可以完成该操作
            for i in range(5):
                self.cnt[i] -= res[i]
            return res
```

```Go
type ATM struct {
    cnt []int64   // 每张钞票剩余数量
    value []int64 // 每张钞票面额
}

func Constructor() ATM {
    return ATM {
        cnt: make([]int64, 5),
        value: []int64 {
            20, 50, 100, 200, 500,
        },
    }
}

func (this *ATM) Deposit(banknotesCount []int)  {
    for i := 0; i < 5; i++ {
        this.cnt[i] += int64(banknotesCount[i])
    }
}

func (this *ATM) Withdraw(amount int) []int {
    res := make([]int, 5)
    // 模拟尝试取出钞票的过程
    for i := 4; i >= 0; i-- {
        res[i] = int(min(this.cnt[i], int64(amount) / this.value[i]))
        amount -= res[i] * int(this.value[i])
    }
    if amount > 0 {
        // 无法完成该操作
        return []int{-1}
    }
    // 可以完成该操作
    for i := 0; i < 5; i++ {
        this.cnt[i] -= int64(res[i])
    }
    return res
}
```

```C
typedef struct {
    long long cnt[5];   // 每张钞票剩余数量
    long long value[5]; // 每张钞票面额
} ATM;

ATM* aTMCreate() {
    ATM *atm = (ATM *)malloc(sizeof(ATM));
    memset(atm, 0, sizeof(ATM));
    atm->value[0] = 20;
    atm->value[1] = 50;
    atm->value[2] = 100;
    atm->value[3] = 200;
    atm->value[4] = 500;
    return atm;
}

void aTMDeposit(ATM* obj, int* banknotesCount, int banknotesCountSize) {
    for (int i = 0; i < 5; ++i) {
        obj->cnt[i] += banknotesCount[i];
    }
}

int* aTMWithdraw(ATM* obj, int amount, int* retSize) {
    int *res = malloc(sizeof(int) * 5);
    *retSize = 5;
    // 模拟尝试取出钞票的过程
    for (int i = 4; i >= 0; --i) {
        res[i] = fmin(obj->cnt[i], amount / obj->value[i]);
        amount -= res[i] * obj->value[i];
    }
    if (amount) {
        // 无法完成该操作
        res = malloc(sizeof(int));
        *retSize = 1;
        res[0] = -1;
        return res;
    } else {
        // 可以完成该操作
        for (int i = 0; i < 5; ++i) {
            obj->cnt[i] -= res[i];
        }
        return res;
    }
}

void aTMFree(ATM* obj) {
    free(obj);
}
```

```Java
class ATM {
    private long[] cnt;   // 每张钞票剩余数量
    private long[] value; // 每张钞票面额

    public ATM() {
        cnt = new long[]{0, 0, 0, 0, 0};
        value = new long[]{20, 50, 100, 200, 500};
    }

    public void deposit(int[] banknotesCount) {
        for (int i = 0; i < 5; ++i) {
            cnt[i] += banknotesCount[i];
        }
    }

    public int[] withdraw(int amount) {
        int[] res = new int[5];
        // 模拟尝试取出钞票的过程
        for (int i = 4; i >= 0; --i) {
            res[i] = (int) Math.min(cnt[i], amount / value[i]);
            amount -= res[i] * value[i];
        }
        if (amount > 0) {
            // 无法完成该操作
            return new int[]{-1};
        } else {
            // 可以完成该操作
            for (int i = 0; i < 5; ++i) {
                cnt[i] -= res[i];
            }
            return res;
        }
    }
}
```

```CSharp
public class ATM {
    private long[] cnt;   // 每张钞票剩余数量
    private long[] value;   // 每张钞票面额

    public ATM() {
        cnt = new long[]{0, 0, 0, 0, 0};
        value = new long[]{20, 50, 100, 200, 500};
    }

    public void Deposit(int[] banknotesCount) {
        for (int i = 0; i < 5; ++i) {
            cnt[i] += banknotesCount[i];
        }
    }

    public int[] Withdraw(int amount) {
        int[] res = new int[5];
        // 模拟尝试取出钞票的过程
        for (int i = 4; i >= 0; --i) {
            res[i] = (int)Math.Min(cnt[i], amount / value[i]);
            amount -= res[i] * (int)value[i];
        }
        if (amount > 0) {
            // 无法完成该操作
            return new int[]{-1};
        } else {
            // 可以完成该操作
            for (int i = 0; i < 5; ++i) {
                cnt[i] -= res[i];
            }
            return res;
        }
    }
}
```

```JavaScript
var ATM = function() {
    this.cnt = [0, 0, 0, 0, 0]; // 每张钞票剩余数量
    this.value = [20, 50, 100, 200, 500]; // 每张钞票面额
};

ATM.prototype.deposit = function(banknotesCount) {
    for (let i = 0; i < 5; ++i) {
        this.cnt[i] += banknotesCount[i];
    }
};

ATM.prototype.withdraw = function(amount) {
    let res = new Array(5).fill(0);
    // 模拟尝试取出钞票的过程
    for (let i = 4; i >= 0; --i) {
        res[i] = Math.min(this.cnt[i], Math.floor(amount / this.value[i]));
        amount -= res[i] * this.value[i];
    }
    if (amount > 0) {
        // 无法完成该操作
        return [-1];
    } else {
        // 可以完成该操作
        for (let i = 0; i < 5; ++i) {
            this.cnt[i] -= res[i];
        }
        return res;
    }
};
```

```TypeScript
class ATM {
    private cnt: number[];   // 每张钞票剩余数量
    private value: number[]; // 每张钞票面额

    constructor() {
        this.cnt = [0, 0, 0, 0, 0];
        this.value = [20, 50, 100, 200, 500];
    }

    deposit(banknotesCount: number[]): void {
        for (let i = 0; i < 5; ++i) {
            this.cnt[i] += banknotesCount[i];
        }
    }

    withdraw(amount: number): number[] {
        let res: number[] = new Array(5).fill(0);
        // 模拟尝试取出钞票的过程
        for (let i = 4; i >= 0; --i) {
            res[i] = Math.min(this.cnt[i], Math.floor(amount / this.value[i]));
            amount -= res[i] * this.value[i];
        }
        if (amount > 0) {
            // 无法完成该操作
            return [-1];
        } else {
            // 可以完成该操作
            for (let i = 0; i < 5; ++i) {
                this.cnt[i] -= res[i];
            }
            return res;
        }
    }
}
```

```Rust
struct ATM {
    cnt: Vec<i64>,   // 每张钞票剩余数量
    value: Vec<i64>,   // 每张钞票面额
}

impl ATM {
    fn new() -> Self {
        ATM {
            cnt: vec![0, 0, 0, 0, 0],
            value: vec![20, 50, 100, 200, 500],
        }
    }
    
    fn deposit(&mut self, banknotes_count: Vec<i32>) {
        for i in 0..5 {
            self.cnt[i] += banknotes_count[i] as i64;
        }
    }
    
    fn withdraw(&mut self, mut amount: i32) -> Vec<i32> {
        let mut res = vec![0; 5];
        // 模拟尝试取出钞票的过程
        for i in (0..5).rev() {
            res[i] = std::cmp::min(self.cnt[i], amount as i64 / self.value[i]) as i32;
            amount -= res[i] * self.value[i] as i32;
        }
        if amount > 0 {
            // 无法完成该操作
            vec![-1]
        } else {
            // 可以完成该操作
            for i in 0..5 {
                self.cnt[i] -= res[i] as i64;
            }
            res
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk)$，其中 $n$ 为 $withdraw()$ 和 $deposit()$ 操作的次数，$k=5$ 为不同面值钞票的数量。每一次 $withdraw()$ 或 $deposit()$ 操作的时间复杂度为 $O(k)$。
- 空间复杂度：$O(k)$，即为存储每种钞票面额和剩余数量数组的空间开销。
