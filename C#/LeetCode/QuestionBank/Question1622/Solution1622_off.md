### [奇妙序列](https://leetcode.cn/prob_lems/fancy-sequence/solutions/2477431/qi-mia_o-xu-lie-by-leetcode-solution-wt5d/)

#### 前言

我们可以将若干次 `addAll` 操作以及 `multAll` 操作「浓缩」成一次操作，记为二元组 $(a,b)$，表示将任意整数 $x$ 变为 $ax+b$：

- 初始时，$(a,b)=(1,0)$；
- 当我们遇到 `addAll(inc)` 操作时，将 $b$ 增加 $inc$；
- 当我们遇到 `multAll(m)` 操作时，将 $a$ 和 $b$ 都乘以 $m$。

我们用数组 $v$ 存储**原始序列**（即保存了每次 `append(val)` 操作中 `val` 的序列），并且使用两个数组 $a$ 和 $b$ 存储上述的二元组，其中 $(a_i,b_i)$ 表示**在 $v_i$ 被加入 $v$ 之前，所有的操作「浓缩」得到的结果**。

这样一来，当我们遇到 `getIndex(idx)` 操作时，我们考虑二元组 $(a_{idx},b_{idx})$ 以及 $(a_l,b_l)$：

- 在 $v_{idx}$ 被放入 $v$ 之前，所有的操作可以浓缩成 $(a_{idx},b_{idx})$；
- 到目前为止，所有的操作可以浓缩成 $(a_l,b_l)$。

因此，**我们对 $v_{idx}$ 进行的操作，就等价于将二元组 $(a_{idx},b_{idx})$ 变成 $(a_l,b_l)$ 的操作**，记为 $(a_o,b_o)$。也就是说

$$\begin{cases}a_{idx}\cdot a_o=a_l \\ b_{idx}\cdot a_o+b_o=b_l\end{cases}$$

那么 `getIndex(idx)` 操作的答案即为 $a_o\cdot v_{idx}+b_o$。

如何求解 $a_o$ 和 $b_o$ 呢？显然我们可以得到

$$\begin{cases}a_o=\dfrac{a_l}{a_{idx}} \\ b_o=b_l-b_{idx}\cdot\dfrac{a_l}{a_{idx}}\end{cases}$$

这样看似很合理，但我们需要注意的是，在不断地 `addAll` 操作以及 `multAll` 操作之后，$(a,b)$ 会变得非常大，超出了大部分语言中整型变量的表示范围。一种解决的方法是实现高精度运算，但这样代码编写起来会非常麻烦。而我们发现，题目描述中只需要将结果对 $10^9+7$ 取模返回即可，因此我们可以考虑使用「乘法逆元」解决这个问题。

#### 预备知识

设模数为 $m$（在本题中 $m=10^9+7$），对于一个整数 $a$，如果存在另一个整数 $a^{-1} (0<a^{-1}<m)$，满足

$$aa^{-1}\equiv 1 (\bmod  m)$$

成立，那么我们称 $a^{-1}$ 是 $a$ 的「乘法逆元」。

当 $a$ 是 $m$ 的倍数时，显然 $a^{-1}$ 不存在。而当 $a$ 不是 $m$ 的倍数时，根据上式可得

$$aa^{-1}=km+1,k\in N$$

整理得

$$a^{-1}\cdot a-k\cdot m=1$$

**若 $m$ 为质数**，根据「裴蜀定理」，$gcd(a,m)=1$，因此必存在整数 $a^{-1}$ 和 $k$ 使得上式成立。

如果 $(a_0^{-1},k_0)$ 是一组解，那么

$$(a_0^{-1}+cm,k_0+ca),c\in Z$$

都是上式的解。因此必然存在一组解中的 $a_0^{-1}$ 满足 $0<a_0^{-1}<m$，即为我们所求的 $a^{-1}$。

那么如何求出 $a^{-1}$ 呢？一种简单的方法是使用「费马小定理」，即

$$a^{m-1}\equiv 1 (\bmod  m)$$

那么有

$$\begin{array}{rcl}& & a^{m-1}a^{-1}\equiv a^{-1} (\bmod m) \\ & \Rightarrow & a^{m-2}aa^{-1}\equiv a^{-1} (\bmod m) \\ & \Rightarrow & a^{m-2}\equiv a^{-1} (\bmod m)\end{array}$$

因此，$a^{-1}$ 就等于 $a^{m-2}$ 对 $m$ 取模的结果。而计算 $a^{m-2}$ 的方法相对简单，我们可以使用「快速幂」，时间复杂度为 $O(\log m)$，具体可以参考 [50\. Pow(x, n) 的官方题解](https://leetcode-cn.com/prob_lems/powx-n/solution/powx-n-by-leetcode-solution/)。

乘法逆元可以使得我们在取模的意义下，化除法为乘法。例如当我们需要求出 $\dfrac{b}{a}$ 对 $m$ 取模的结果，那么可以使用乘法逆元

$$\dfrac{b}{a}\equiv b\cdot a^{-1} (\bmod  m)$$

帮助我们进行求解。由于**乘法在取模的意义下满足分配律**，即

$$(a\times b) \% m=((a \% m)\times (b \% m)) \% m$$

而除法在取模的意义下并不满足分配律。因此当 $a$ 和 $b$ 的求解过程中本身就包含取模运算时，我们仍然可以得到正确的 $\dfrac{b}{a}$ 对 $m$ 取模的结果。

#### 方法一：在遇到 `getIndex` 操作时使用乘法逆元

**思路与算法**

接着「前言」部分的求解结果

$$\begin{cases}a_o=\dfrac{a_l}{a_{idx}} \\ b_o=b_l-b_{idx}\cdot\dfrac{a_l}{a_{idx}}\end{cases}$$

我们可以使用乘法逆元，化除法为乘法，即

$$\begin{cases}a_o\equiv a_l\cdot a_{idx}^{-1}(\bmod m) \\ b_o\equiv b_l-b_{idx}\cdot a_l\cdot a_{idx}^{-1} (\bmod m)\end{cases}$$

这样 $a_o\cdot v_{idx}+b_o$ 对 $m$ 取模的结果即为答案。

**代码**

```C++
class Fancy {
private:
    static constexpr int mod = 1000000007;
    vector<int> v, a, b;

public:
    Fancy() {
        a.push_back(1);
        b.push_back(0);
    }

    // 快速幂
    int quickmul(int x, int y) {
        int ret = 1;
        int cur = x;
        while (y) {
            if (y & 1) {
                ret = (long long)ret * cur % mod;
            }
            cur = (long long)cur * cur % mod;
            y >>= 1;
        }
        return ret;
    }

    // 乘法逆元
    int inv(int x) {
        return quickmul(x, mod - 2);
    }

    void append(int val) {
        v.push_back(val);
        a.push_back(a.back());
        b.push_back(b.back());
    }

    void addAll(int inc) {
        b.back() = (b.back() + inc) % mod;
    }

    void multAll(int m) {
        a.back() = (long long)a.back() * m % mod;
        b.back() = (long long)b.back() * m % mod;
    }

    int getIndex(int idx) {
        if (idx >= v.size()) {
            return -1;
        }
        int ao = (long long)inv(a[idx]) * a.back() % mod;
        int bo = (b.back() - (long long)b[idx] * ao % mod + mod) % mod;
        int ans = ((long long)ao * v[idx] % mod + bo) % mod;
        return ans;
    }
};
```

```Java
class Fancy {
    static final int MOD = 1000000007;
    List<Integer> v;
    List<Integer> a;
    List<Integer> b;

    public Fancy() {
        v = new ArrayList<Integer>();
        a = new ArrayList<Integer>();
        b = new ArrayList<Integer>();
        a.add(1);
        b.add(0);
    }

    public void append(int val) {
        v.add(val);
        a.add(a.get(a.size() - 1));
        b.add(b.get(b.size() - 1));
    }

    public void addAll(int inc) {
        int bLastIndex = b.size() - 1;
        int bLast = b.get(bLastIndex);
        bLast = (bLast + inc) % MOD;
        b.set(bLastIndex, bLast);
    }

    public void multAll(int m) {
        int aLastIndex = a.size() - 1, bLastIndex = b.size() - 1;
        int aLast = (int) ((long) a.get(aLastIndex) * m % MOD);
        a.set(aLastIndex, aLast);
        int bLast = (int) ((long) b.get(bLastIndex) * m % MOD);
        b.set(bLastIndex, bLast);
    }

    public int getIndex(int idx) {
        if (idx >= v.size()) {
            return -1;
        }
        int ao = (int) ((long) inv(a.get(idx)) * a.get(a.size() - 1) % MOD);
        int bo = (int) (((long) b.get(b.size() - 1) - (long) b.get(idx) * ao % MOD + MOD) % MOD);
        int ans = (int) (((long) ao * v.get(idx) % MOD + bo) % MOD);
        return ans;
    }

    // 快速幂
    private int quickmul(int x, int y) {
        long ret = 1;
        long cur = x;
        while (y != 0) {
            if ((y & 1) != 0) {
                ret = ret * cur % MOD;
            }
            cur = cur * cur % MOD;
            y >>= 1;
        }
        return (int) ret;
    }

    // 乘法逆元
    private int inv(int x) {
        return quickmul(x, MOD - 2);
    }
}
```

```Python
class Fancy:

    def __init__(self):
        self.mod = 10**9 + 7
        self.v = list()
        self.a = [1]
        self.b = [0]

    # 快速幂
    def quickmul(self, x: int, y: int) -> int:
        return pow(x, y, self.mod)

    # 乘法逆元
    def inv(self, x: int) -> int:
        return self.quickmul(x, self.mod - 2)

    def append(self, val: int) -> None:
        self.v.append(val)
        self.a.append(self.a[-1])
        self.b.append(self.b[-1])

    def addAll(self, inc: int) -> None:
        self.b[-1] = (self.b[-1] + inc) % self.mod


    def multAll(self, m: int) -> None:
        self.a[-1] = self.a[-1] * m % self.mod
        self.b[-1] = self.b[-1] * m % self.mod

    def getIndex(self, idx: int) -> int:
        if idx >= len(self.v):
            return -1
        ao = self.inv(self.a[idx]) * self.a[-1]
        bo = self.b[-1] - self.b[idx] * ao
        ans = (ao * self.v[idx] + bo) % self.mod
        return ans
```

```CSharp
public class Fancy {
    const int MOD = 1000000007;
    List<int> v;
    List<int> a;
    List<int> b;

    public Fancy() {
        v = new List<int>();
        a = new List<int>();
        b = new List<int>();
        a.Add(1);
        b.Add(0);
    }

    public void Append(int val) {
        v.Add(val);
        a.Add(a[a.Count - 1]);
        b.Add(b[b.Count - 1]);
    }

    public void AddAll(int inc) {
        int lastIndex = b.Count - 1;
        int lastB = (b[lastIndex] + inc) % MOD;
        b[lastIndex] = lastB;
    }

    public void MultAll(int m) {
        int lastIndex = a.Count - 1;
        long lastA = ((long)a[lastIndex] * m) % MOD;
        a[lastIndex] = (int)lastA;

        long lastB = ((long)b[lastIndex] * m) % MOD;
        b[lastIndex] = (int)lastB;
    }

    public int GetIndex(int idx) {
        if (idx >= v.Count) {
            return -1;
        }

        long ao = ((long)Inv(a[idx]) * a[a.Count - 1]) % MOD;
        long bo = (b[b.Count - 1] - (long)b[idx] * ao % MOD + MOD) % MOD;
        long ans = (ao * v[idx] % MOD + bo) % MOD;
        return (int)ans;
    }

    // 快速幂
    private int QuickMul(int x, int y) {
        long ret = 1;
        long cur = x;
        while (y != 0) {
            if ((y & 1) != 0) {
                ret = ret * cur % MOD;
            }
            cur = cur * cur % MOD;
            y >>= 1;
        }
        return (int)ret;
    }

    // 乘法逆元
    private int Inv(int x) {
        return QuickMul(x, MOD - 2);
    }
}
```

```Go
const MOD = 1000000007

type Fancy struct {
    v []int
    a []int
    b []int
}

func Constructor() Fancy {
    return Fancy{
        v: []int{},
        a: []int{1},
        b: []int{0},
    }
}

func (this *Fancy) Append(val int) {
    this.v = append(this.v, val)
    this.a = append(this.a, this.a[len(this.a)-1])
    this.b = append(this.b, this.b[len(this.b)-1])
}

func (this *Fancy) AddAll(inc int) {
    lastIdx := len(this.b) - 1
    this.b[lastIdx] = (this.b[lastIdx] + inc) % MOD
}

func (this *Fancy) MultAll(m int) {
    lastIdx := len(this.a) - 1
    this.a[lastIdx] = (this.a[lastIdx] * m) % MOD
    this.b[lastIdx] = (this.b[lastIdx] * m) % MOD
}

func (this *Fancy) GetIndex(idx int) int {
    if idx >= len(this.v) {
        return -1
    }

    ao := (inv(this.a[idx]) * this.a[len(this.a)-1]) % MOD
    bo := (this.b[len(this.b)-1] - this.b[idx]*ao%MOD + MOD) % MOD
    ans := (ao*this.v[idx]%MOD + bo) % MOD
    return ans
}

// 快速幂
func quickMul(x, y int) int {
    ret := 1
    cur := x
    for y != 0 {
        if y&1 != 0 {
            ret = (ret * cur) % MOD
        }
        cur = (cur * cur) % MOD
        y >>= 1
    }
    return ret
}

// 乘法逆元
func inv(x int) int {
    return quickMul(x, MOD-2)
}
```

```C
#define MOD 1000000007

typedef struct {
    int* data;
    int size;
    int capacity;
} Vector;

Vector* vectorCreate() {
    Vector* vec = (Vector*)malloc(sizeof(Vector));
    vec->size = 0;
    vec->capacity = 16;
    vec->data = (int*)malloc(vec->capacity * sizeof(int));
    return vec;
}

void vectorPushBack(Vector* vec, int val) {
    if (vec->size >= vec->capacity) {
        vec->capacity *= 2;
        vec->data = (int*)realloc(vec->data, vec->capacity * sizeof(int));
    }
    vec->data[vec->size++] = val;
}

int vectorBack(Vector* vec) {
    if (vec->size == 0) return 0;
    return vec->data[vec->size - 1];
}

void vectorSetBack(Vector* vec, int val) {
    if (vec->size == 0) {
        vectorPushBack(vec, val);
    } else {
        vec->data[vec->size - 1] = val;
    }
}

int vectorAt(Vector* vec, int idx) {
    if (idx < 0 || idx >= vec->size) {
        return 0;
    }
    return vec->data[idx];
}

int vectorSize(Vector* vec) {
    return vec->size;
}

void vectorFree(Vector* vec) {
    free(vec->data);
    free(vec);
}

typedef struct {
    Vector* v;
    Vector* a;
    Vector* b;
} Fancy;

// 创建 Fancy 对象
Fancy* fancyCreate() {
    Fancy* obj = (Fancy*)malloc(sizeof(Fancy));
    obj->v = vectorCreate();
    obj->a = vectorCreate();
    obj->b = vectorCreate();
    // 初始化 a[0] = 1, b[0] = 0
    vectorPushBack(obj->a, 1);
    vectorPushBack(obj->b, 0);

    return obj;
}

// 快速幂
int quickMul(int x, int y) {
    long long ret = 1;
    long long cur = x;
    while (y) {
        if (y & 1) {
            ret = ret * cur % MOD;
        }
        cur = cur * cur % MOD;
        y >>= 1;
    }
    return (int)ret;
}

// 乘法逆元
int inv(int x) {
    return quickMul(x, MOD - 2);
}

// 添加值
void fancyAppend(Fancy* obj, int val) {
    if (!obj || !obj->v || !obj->a || !obj->b) {
        return;
    }
    vectorPushBack(obj->v, val);
    vectorPushBack(obj->a, vectorBack(obj->a));
    vectorPushBack(obj->b, vectorBack(obj->b));
}

// 增加所有值
void fancyAddAll(Fancy* obj, int inc) {
    if (!obj || !obj->b) {
        return;
    }
    if (vectorSize(obj->b) > 0) {
        int last = (vectorBack(obj->b) + inc) % MOD;
        vectorSetBack(obj->b, last);
    }
}

// 乘以所有值
void fancyMultAll(Fancy* obj, int m) {
    if (!obj || !obj->a || !obj->b) {
        return;
    }
    if (vectorSize(obj->a) > 0 && vectorSize(obj->b) > 0) {
        int a_last = (int)((long long)vectorBack(obj->a) * m % MOD);
        int b_last = (int)((long long)vectorBack(obj->b) * m % MOD);
        vectorSetBack(obj->a, a_last);
        vectorSetBack(obj->b, b_last);
    }
}

// 获取索引处的值
int fancyGetIndex(Fancy* obj, int idx) {
    if (!obj || !obj->v || !obj->a || !obj->b) {
        return -1;
    }
    if (idx >= vectorSize(obj->v)) {
        return -1;
    }

    long long ao = (long long)inv(vectorAt(obj->a, idx)) * vectorBack(obj->a) % MOD;
    long long bo = (vectorBack(obj->b) - (long long)vectorAt(obj->b, idx) * ao % MOD + MOD) % MOD;
    long long ans = (ao * vectorAt(obj->v, idx) % MOD + bo) % MOD;

    return (int)ans;
}

// 释放 Fancy 对象
void fancyFree(Fancy* obj) {
    if (!obj) {
        return;
    }
    if (obj->v) {
        vectorFree(obj->v);
    }
    if (obj->a) {
        vectorFree(obj->a);
    }
    if (obj->b) {
        vectorFree(obj->b);
    }
    free(obj);
}
```

```JavaScript
const MOD = 1000000007n;

var Fancy = function() {
    this.v = [];
    this.a = [1n];
    this.b = [0n];
};

Fancy.prototype.append = function(val) {
    this.v.push(BigInt(val));
    this.a.push(this.a[this.a.length - 1]);
    this.b.push(this.b[this.b.length - 1]);
};

Fancy.prototype.addAll = function(inc) {
    const lastIdx = this.b.length - 1;
    this.b[lastIdx] = (this.b[lastIdx] + BigInt(inc)) % MOD;
};

Fancy.prototype.multAll = function(m) {
    const lastIdx = this.a.length - 1;
    const mBigInt = BigInt(m);
    this.a[lastIdx] = (this.a[lastIdx] * mBigInt) % MOD;
    this.b[lastIdx] = (this.b[lastIdx] * mBigInt) % MOD;
};

// 快速幂（返回bigint）
Fancy.prototype.quickMul = function(x, y) {
    let ret = 1n;
    let cur = BigInt(x);
    let power = BigInt(y);
    while (power !== 0n) {
        if ((power & 1n) !== 0n) {
            ret = (ret * cur) % MOD;
        }
        cur = (cur * cur) % MOD;
        power >>= 1n;
    }
    return ret;
};

// 乘法逆元（返回bigint）
Fancy.prototype.inv = function(x) {
    return this.quickMul(x, MOD - 2n);
};

Fancy.prototype.getIndex = function(idx) {
    if (idx >= this.v.length) {
        return -1;
    }

    const ao = (this.inv(Number(this.a[idx])) * this.a[this.a.length - 1]) % MOD;
    const bo = (this.b[this.b.length - 1] - this.b[idx] * ao % MOD + MOD) % MOD;
    const ans = (ao * this.v[idx] % MOD + bo) % MOD;

    return Number(ans);
};
```

```TypeScript
const MOD = 1000000007n;

class Fancy {
    private v: bigint[];
    private a: bigint[];
    private b: bigint[];

    constructor() {
        this.v = [];
        this.a = [1n];
        this.b = [0n];
    }

    // 添加值
    append(val: number): void {
        this.v.push(BigInt(val));
        this.a.push(this.a[this.a.length - 1]);
        this.b.push(this.b[this.b.length - 1]);
    }

    // 增加所有值
    addAll(inc: number): void {
        const lastIdx = this.b.length - 1;
        this.b[lastIdx] = (this.b[lastIdx] + BigInt(inc)) % MOD;
    }

    // 乘以所有值
    multAll(m: number): void {
        const lastIdx = this.a.length - 1;
        const mBigInt = BigInt(m);
        this.a[lastIdx] = (this.a[lastIdx] * mBigInt) % MOD;
        this.b[lastIdx] = (this.b[lastIdx] * mBigInt) % MOD;
    }

    // 快速幂（使用bigint）
    private quickMul(x: bigint, y: bigint): bigint {
        let ret = 1n;
        let cur = x;
        let power = y;

        while (power !== 0n) {
            if ((power & 1n) !== 0n) {
                ret = (ret * cur) % MOD;
            }
            cur = (cur * cur) % MOD;
            power >>= 1n;
        }
        return ret;
    }

    // 乘法逆元（使用费马小定理）
    private inv(x: bigint): bigint {
        return this.quickMul(x, MOD - 2n);
    }

    // 获取索引处的值
    getIndex(idx: number): number {
        if (idx >= this.v.length) {
            return -1;
        }

        const ao = (this.inv(this.a[idx]) * this.a[this.a.length - 1]) % MOD;
        const bo = (this.b[this.b.length - 1] - this.b[idx] * ao % MOD + MOD) % MOD;
        const ans = (ao * this.v[idx] % MOD + bo) % MOD;
        return Number(ans);
    }
}
```

```Rust
const MOD: i64 = 1_000_000_007;

struct Fancy {
    v: Vec<i32>,
    a: Vec<i32>,
    b: Vec<i32>,
}

impl Fancy {
    fn new() -> Self {
        Fancy {
            v: Vec::new(),
            a: vec![1],
            b: vec![0],
        }
    }

    fn append(&mut self, val: i32) {
        self.v.push(val);
        self.a.push(*self.a.last().unwrap());
        self.b.push(*self.b.last().unwrap());
    }

    fn add_all(&mut self, inc: i32) {
        let last_idx = self.b.len() - 1;
        self.b[last_idx] = ((self.b[last_idx] as i64 + inc as i64) % MOD) as i32;
    }

    fn mult_all(&mut self, m: i32) {
        let last_idx = self.a.len() - 1;
        self.a[last_idx] = ((self.a[last_idx] as i64 * m as i64) % MOD) as i32;
        self.b[last_idx] = ((self.b[last_idx] as i64 * m as i64) % MOD) as i32;
    }

    fn get_index(&self, idx: i32) -> i32 {
        let idx = idx as usize;
        if idx >= self.v.len() {
            return -1;
        }

        let ao = ((Self::inv(self.a[idx] as i64) * self.a[self.a.len() - 1] as i64) % MOD) as i64;
        let bo = (self.b[self.b.len() - 1] as i64 - self.b[idx] as i64 * ao % MOD + MOD) % MOD;
        let ans = (ao * self.v[idx] as i64 % MOD + bo) % MOD;
        ans as i32
    }

    // 快速幂
    fn quick_mul(x: i64, y: i64) -> i64 {
        let mut ret = 1i64;
        let mut cur = x;
        let mut power = y;
        while power != 0 {
            if power & 1 != 0 {
                ret = (ret * cur) % MOD;
            }
            cur = (cur * cur) % MOD;
            power >>= 1;
        }
        ret
    }

    // 乘法逆元
    fn inv(x: i64) -> i64 {
        Self::quick_mul(x, MOD - 2)
    }
}
```

**复杂度分析**

- 时间复杂度：`getIndex(idx)` 操作的时间复杂度为 $O(\log m)$，其余操作的时间复杂度均为 $O(1)$。
- 空间复杂度：$O(n)$，其中 $n$ 是序列 $v$ 中最多包含的元素个数。

#### 方法二：在遇到 `append` 操作时使用乘法逆元

**思路与算法**

在「前言」部分中，我们提到了：**对 $v_{idx}$ 进行的操作，就等价于将二元组 $(a_{idx},b_{idx})$ 变成 $(a_l,b_l)$ 的操作**。实际上，我们并不需要解方程，直接使用

$$a_l\cdot\dfrac{v_{idx}-b_{idx}}{a_{idx}}+b_l$$

即可得到答案。然而这种方法在提出乘法逆元这一概念之前行不通的原因是，我们并不能保证 $v_{idx}-b_{idx}$ 一定是 $a_{idx}$ 的倍数。

> 至于在方法一中，为什么 $a_l$ 一定是 $a_{idx}$ 的倍数，留给读者进行思考。

这样即使我们实现了高精度运算，也可能会得到包含小数部分的结果，造成一系列误差。然而如果我们有了乘法逆元，就可以使用

$$a_l\cdot (v_{idx}-b_{idx})\cdot a_{idx}^{-1}+b_l$$

得到答案，这样所有的运算结果就都是整数了。此时，当我们遇到 `append(val)` 操作时，如果到目前为止所有的操作可以浓缩成 $(a_l^′,b_l^′)$，我们就将 $(val-b_l^′)\cdot a_l^{′-1}$ 代替 $val$ 放入 $v$。而当我们遇到 `getIndex(idx)` 操作时，就可以直接返回

$$a_l\cdot v_{idx}+b_l$$

作为答案。

**代码**

```C++
class Fancy {
private:
    static constexpr int mod = 1000000007;
    vector<int> v;
    int a, b;

public:
    Fancy(): a(1), b(0) {}

    // 快速幂
    int quickmul(int x, int y) {
        int ret = 1;
        int cur = x;
        while (y) {
            if (y & 1) {
                ret = (long long)ret * cur % mod;
            }
            cur = (long long)cur * cur % mod;
            y >>= 1;
        }
        return ret;
    }

    // 乘法逆元
    int inv(int x) {
        return quickmul(x, mod - 2);
    }

    void append(int val) {
        v.push_back((long long)((val - b + mod) % mod) * inv(a) % mod);
    }

    void addAll(int inc) {
        b = (b + inc) % mod;
    }

    void multAll(int m) {
        a = (long long)a * m % mod;
        b = (long long)b * m % mod;
    }

    int getIndex(int idx) {
        if (idx >= v.size()) {
            return -1;
        }
        int ans = ((long long)a * v[idx] % mod + b) % mod;
        return ans;
    }
};
```

```Java
class Fancy {
    static final int MOD = 1000000007;
    List<Integer> v;
    int a;
    int b;

    public Fancy() {
        v = new ArrayList<Integer>();
        a = 1;
        b = 0;
    }

    public void append(int val) {
        v.add((int) ((long) ((val - b + MOD) % MOD) * inv(a) % MOD));
    }

    public void addAll(int inc) {
        b = (b + inc) % MOD;
    }

    public void multAll(int m) {
        a = (int) (((long) a * m % MOD));
        b = (int) (((long) b * m % MOD));
    }

    public int getIndex(int idx) {
        if (idx >= v.size()) {
            return -1;
        }
        int ans = (int) (((long) a * v.get(idx) % MOD + b) % MOD);
        return ans;
    }

    // 快速幂
    private int quickmul(int x, int y) {
        long ret = 1;
        long cur = x;
        while (y != 0) {
            if ((y & 1) != 0) {
                ret = ret * cur % MOD;
            }
            cur = cur * cur % MOD;
            y >>= 1;
        }
        return (int) ret;
    }

    // 乘法逆元
    private int inv(int x) {
        return quickmul(x, MOD - 2);
    }
}
```

```Python
class Fancy:

    def __init__(self):
        self.mod = 10**9 + 7
        self.v = list()
        self.a = 1
        self.b = 0

    # 快速幂
    def quickmul(self, x: int, y: int) -> int:
        return pow(x, y, self.mod)

    # 乘法逆元
    def inv(self, x: int) -> int:
        return self.quickmul(x, self.mod - 2)

    def append(self, val: int) -> None:
        self.v.append((val - self.b) * self.inv(self.a) % self.mod)

    def addAll(self, inc: int) -> None:
        self.b = (self.b + inc) % self.mod

    def multAll(self, m: int) -> None:
        self.a = self.a * m % self.mod
        self.b = self.b * m % self.mod

    def getIndex(self, idx: int) -> int:
        if idx >= len(self.v):
            return -1
        return (self.a * self.v[idx] + self.b) % self.mod
```

```CSharp
public class Fancy {
    private const int MOD = 1000000007;
    private List<int> v;
    private int a;
    private int b;

    public Fancy() {
        v = new List<int>();
        a = 1;
        b = 0;
    }

    // 快速幂
    private int QuickMul(int x, int y) {
        long ret = 1;
        long cur = x;
        while (y != 0) {
            if ((y & 1) != 0) {
                ret = ret * cur % MOD;
            }
            cur = cur * cur % MOD;
            y >>= 1;
        }
        return (int)ret;
    }

    // 乘法逆元
    private int Inv(int x) {
        return QuickMul(x, MOD - 2);
    }

    public void Append(int val) {
        long adjustedVal = ((long)(val - b + MOD) % MOD) * Inv(a) % MOD;
        v.Add((int)adjustedVal);
    }

    public void AddAll(int inc) {
        b = (b + inc) % MOD;
    }

    public void MultAll(int m) {
        a = (int)((long)a * m % MOD);
        b = (int)((long)b * m % MOD);
    }

    public int GetIndex(int idx) {
        if (idx >= v.Count) {
            return -1;
        }
        int ans = (int)(((long)a * v[idx] % MOD + b) % MOD);
        return ans;
    }
}
```

```Go
const MOD = 1000000007

type Fancy struct {
    v []int
    a int
    b int
}

func Constructor() Fancy {
    return Fancy{
        v: []int{},
        a: 1,
        b: 0,
    }
}

// 快速幂
func (this *Fancy) quickMul(x, y int) int {
    ret := 1
    cur := x
    for y > 0 {
        if y&1 != 0 {
            ret = (ret * cur) % MOD
        }
        cur = (cur * cur) % MOD
        y >>= 1
    }
    return ret
}

// 乘法逆元
func (this *Fancy) inv(x int) int {
    return this.quickMul(x, MOD-2)
}

func (this *Fancy) Append(val int) {
    adjustedVal := ((val-this.b+MOD)%MOD) * this.inv(this.a) % MOD
    this.v = append(this.v, adjustedVal)
}

func (this *Fancy) AddAll(inc int) {
    this.b = (this.b + inc) % MOD
}

func (this *Fancy) MultAll(m int) {
    this.a = (this.a * m) % MOD
    this.b = (this.b * m) % MOD
}

func (this *Fancy) GetIndex(idx int) int {
    if idx >= len(this.v) {
        return -1
    }
    ans := (this.a*this.v[idx]%MOD + this.b) % MOD
    return ans
}
```

```JavaScript
const MOD = 1000000007n;

var Fancy = function() {
    this.v = [];
    this.a = 1n;
    this.b = 0n;
};

// 快速幂
Fancy.prototype.quickMul = function(x, y) {
    let ret = 1n;
    let cur = BigInt(x);
    let power = BigInt(y);
    while (power !== 0n) {
        if ((power & 1n) !== 0n) {
            ret = (ret * cur) % MOD;
        }
        cur = (cur * cur) % MOD;
        power >>= 1n;
    }
    return Number(ret);
};

// 乘法逆元
Fancy.prototype.inv = function(x) {
    return this.quickMul(x, MOD - 2n);
};

Fancy.prototype.append = function(val) {
    const adjustedVal = ((BigInt(val) - this.b + MOD) % MOD) * BigInt(this.inv(Number(this.a))) % MOD;
    this.v.push(Number(adjustedVal));
};

Fancy.prototype.addAll = function(inc) {
    this.b = (this.b + BigInt(inc)) % MOD;
};

Fancy.prototype.multAll = function(m) {
    this.a = (this.a * BigInt(m)) % MOD;
    this.b = (this.b * BigInt(m)) % MOD;
};

Fancy.prototype.getIndex = function(idx) {
    if (idx >= this.v.length) {
        return -1;
    }
    const ans = (this.a * BigInt(this.v[idx]) % MOD + this.b) % MOD;
    return Number(ans);
};
```

```TypeScript
const MOD = 1000000007n;

class Fancy {
    private v: number[];
    private a: bigint;
    private b: bigint;

    constructor() {
        this.v = [];
        this.a = 1n;
        this.b = 0n;
    }

    // 快速幂
    private quickMul(x: number, y: bigint): number {
        let ret = 1n;
        let cur = BigInt(x);
        let power = y;
        while (power !== 0n) {
            if ((power & 1n) !== 0n) {
                ret = (ret * cur) % MOD;
            }
            cur = (cur * cur) % MOD;
            power >>= 1n;
        }
        return Number(ret);
    }

    // 乘法逆元
    private inv(x: number): number {
        return this.quickMul(x, MOD - 2n);
    }

    append(val: number): void {
        const adjustedVal = ((BigInt(val) - this.b + MOD) % MOD) * BigInt(this.inv(Number(this.a))) % MOD;
        this.v.push(Number(adjustedVal));
    }

    addAll(inc: number): void {
        this.b = (this.b + BigInt(inc)) % MOD;
    }

    multAll(m: number): void {
        this.a = (this.a * BigInt(m)) % MOD;
        this.b = (this.b * BigInt(m)) % MOD;
    }

    getIndex(idx: number): number {
        if (idx >= this.v.length) {
            return -1;
        }
        const ans = (this.a * BigInt(this.v[idx]) % MOD + this.b) % MOD;
        return Number(ans);
    }
}
```

```Rust
const MOD: i64 = 1_000_000_007;

struct Fancy {
    v: Vec<i32>,
    a: i64,
    b: i64,
}

impl Fancy {
    fn new() -> Self {
        Fancy {
            v: Vec::new(),
            a: 1,
            b: 0,
        }
    }

    // 快速幂
    fn quick_mul(&self, x: i64, y: i64) -> i64 {
        let mut ret = 1;
        let mut cur = x;
        let mut power = y;
        while power != 0 {
            if power & 1 != 0 {
                ret = ret * cur % MOD;
            }
            cur = cur * cur % MOD;
            power >>= 1;
        }
        ret
    }

    // 乘法逆元
    fn inv(&self, x: i64) -> i64 {
        self.quick_mul(x, MOD - 2)
    }

    fn append(&mut self, val: i32) {
        let adjusted_val = ((val as i64 - self.b + MOD) % MOD) * self.inv(self.a) % MOD;
        self.v.push(adjusted_val as i32);
    }

    fn add_all(&mut self, inc: i32) {
        self.b = (self.b + inc as i64) % MOD;
    }

    fn mult_all(&mut self, m: i32) {
        let m = m as i64;
        self.a = self.a * m % MOD;
        self.b = self.b * m % MOD;
    }

    fn get_index(&self, idx: i32) -> i32 {
        let idx = idx as usize;
        if idx >= self.v.len() {
            return -1;
        }
        let ans = (self.a * self.v[idx] as i64 % MOD + self.b) % MOD;
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：`append(val)` 操作的时间复杂度为 $O(\log m)$，其余操作的时间复杂度均为 $O(1)$。
- 空间复杂度：$O(n)$，其中 $n$ 是序列 $v$ 中最多包含的元素个数。
