### [1116\. 打印零与奇偶数](https://leetcode.cn/problems/print-zero-even-odd/solutions/3933220/1116-da-yin-ling-yu-qi-ou-shu-by-stormsu-5v3s/?envType=problem-list-v2&envId=ySsxoJfz)

#### 前言

这道题要求根据输入的正整数 $n$，在三个线程共用一个实例的情况下将 $0$ 和从 $1$ 到 $n$ 的整数依次输出。为了实现该输出顺序，应从小到大遍历 $1\le i\le n$ 的每个整数 $i$，根据如下顺序调用各线程。

- 当 $i$ 是奇数时，线程 $A$ 先调用方法 $zero$，线程 $C$ 后调用方法 $odd$。
- 当 $i$ 是偶数时，线程 $A$ 先调用方法 $zero$，线程 $B$ 后调用方法 $even$。

由于线程 $A$ 需要对 $1$ 到 $n$ 的所有整数都调用，线程 $B$ 和 $C$ 需要分别对 $1$ 到 $n$ 的所有偶数和奇数调用，因此方法 zero、even 和 $odd$ 中的循环分别如下。

- 方法 $zero$ 的循环变量是范围 $[1,n]$ 中的所有整数，初始值是 $1$。
- 方法 $even$ 的循环变量是范围 $[1,n]$ 中的所有偶数，初始值是 $2$。
- 方法 $odd$ 的循环变量是范围 $[1,n]$ 中的所有奇数，初始值是 $1$。

对于 $1$ 到 $n$ 的每个整数，需要确保先调用方法 $zero$，后调用方法 $odd$ 或 $even$。

以下解法讲解在每一轮循环中如何确保多个线程调用方法的执行顺序。

#### 解法一

##### 思路

维护变量 $stage$ 表示当前允许执行的方法对应的奇偶性，维护变量 $isZero$ 表示当前允许执行的方法是打印零的方法还是打印非零的方法。为了确保两个变量的值对所有线程都立即可见，应将两个变量设定为 $volatile$。

##### 代码

```Java
class ZeroEvenOdd {
    private static final int ODD = 1, EVEN = 2;
    private int n;
    private volatile int stage;
    private volatile boolean isZero;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stage = ODD;
        this.isZero = true;
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            while (!isZero) {
                Thread.yield();
            }
            printNumber.accept(0);
            isZero = false;
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            while (stage != EVEN || isZero) {
                Thread.yield();
            }
            printNumber.accept(i);
            stage = ODD;
            isZero = true;
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            while (stage != ODD || isZero) {
                Thread.yield();
            }
            printNumber.accept(i);
            stage = EVEN;
            isZero = true;
        }
    }
}
```

```CSharp
using System.Threading;

public class ZeroEvenOdd {
    private const int ODD = 1, EVEN = 2;
    private int n;
    private volatile int stage;
    private volatile bool isZero;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stage = ODD;
        this.isZero = true;
    }

    public void Zero(Action<int> printNumber) {
        for (int i = 1; i <= n; i++) {
            while (!isZero) {
                Thread.Yield();
            }
            printNumber(0);
            isZero = false;
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            while (stage != EVEN || isZero) {
                Thread.Yield();
            }
            printNumber(i);
            stage = ODD;
            isZero = true;
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            while (stage != ODD || isZero) {
                Thread.Yield();
            }
            printNumber(i);
            stage = EVEN;
            isZero = true;
        }
    }
}
```

```Python
class ZeroEvenOdd:
    ODD, EVEN = 1, 2

    def __init__(self, n):
        self.n = n
        self.stage = self.ODD
        self.isZero = True

    def zero(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1):
            while not self.isZero:
                time.sleep(0)
            printNumber(0)
            self.isZero = False

    def even(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(2, self.n + 1, 2):
            while self.stage != self.EVEN or self.isZero:
                time.sleep(0)
            printNumber(i)
            self.stage = self.ODD
            self.isZero = True

    def odd(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1, 2):
            while self.stage != self.ODD or self.isZero:
                time.sleep(0)
            printNumber(i)
            self.stage = self.EVEN
            self.isZero = True
```

```C
static const int ODD = 1, EVEN = 2;

typedef struct {
    int n;
    volatile int stage;
    volatile bool isZero;
} ZeroEvenOdd;

void printNumber(int x);

ZeroEvenOdd* zeroEvenOddCreate(int n) {
    ZeroEvenOdd* obj = (ZeroEvenOdd*) malloc(sizeof(ZeroEvenOdd));
    obj->n = n;
    obj->stage = ODD;
    obj->isZero = true;
    return obj;
}

void zero(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i++) {
        while (!obj->isZero) {
            sched_yield();
        }
        printNumber(0);
        obj->isZero = false;
    }
}

void even(ZeroEvenOdd* obj) {
    for (int i = 2; i <= obj->n; i += 2) {
        while (obj->stage != EVEN || obj->isZero) {
            sched_yield();
        }
        printNumber(i);
        obj->stage = ODD;
        obj->isZero = true;
    }
}

void odd(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i += 2) {
        while (obj->stage != ODD || obj->isZero) {
            sched_yield();
        }
        printNumber(i);
        obj->stage = EVEN;
        obj->isZero = true;
    }
}

void zeroEvenOddFree(ZeroEvenOdd* obj) {
    free(obj);
}
```

#### 解法二

##### 思路

维护变量 $stageAndZero$ 表示如下两个值。

1. 当前允许执行的方法对应的奇偶性。
2. 当前允许执行的方法是打印零的方法还是打印非零的方法。

将变量 $stageAndZero$ 设定为原子类 $AtomicInteger$，可保证状态更新的可见性。

##### 代码

```Java
class ZeroEvenOdd {
    private static final int ODD = 1, EVEN = 2;
    private static final int TRUE = 1, FALSE = 0;
    private int n;
    private AtomicInteger stageAndZero;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stageAndZero = new AtomicInteger((ODD << 1) + TRUE);
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            while (!checkZero()) {
                Thread.yield();
            }
            printNumber.accept(0);
            setZero(FALSE);
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            while (!checkStageAndZero(EVEN, FALSE)) {
                Thread.yield();
            }
            printNumber.accept(i);
            setStageAndZero(ODD, TRUE);
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            while (!checkStageAndZero(ODD, FALSE)) {
                Thread.yield();
            }
            printNumber.accept(i);
            setStageAndZero(EVEN, TRUE);
        }
    }

    private boolean checkZero() {
        return (stageAndZero.get() & 1) == TRUE;
    }

    private boolean checkStageAndZero(int targetStage, int targetZero) {
        int val = stageAndZero.get();
        return ((val >> 1) == targetStage) && ((val & 1) == targetZero);
    }

    private void setZero(int targetZero) {
        stageAndZero.set((stageAndZero.get() & ~1) + targetZero);
    }

    private void setStageAndZero(int targetStage, int targetZero) {
        stageAndZero.set((targetStage << 1) + targetZero);
    }
}
```

```CSharp
using System.Threading;

public class ZeroEvenOdd {
    private const int ODD = 1, EVEN = 2;
    private const int TRUE = 1, FALSE = 0;
    private int n;
    private int stageAndZero;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stageAndZero = (ODD << 1) + TRUE;
    }

    public void Zero(Action<int> printNumber) {
        for (int i = 1; i <= n; i++) {
            while (!CheckZero()) {
                Thread.Yield();
            }
            printNumber(0);
            SetZero(FALSE);
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            while (!CheckStageAndZero(EVEN, FALSE)) {
                Thread.Yield();
            }
            printNumber(i);
            SetStageAndZero(ODD, TRUE);
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            while (!CheckStageAndZero(ODD, FALSE)) {
                Thread.Yield();
            }
            printNumber(i);
            SetStageAndZero(EVEN, TRUE);
        }
    }

    private bool CheckZero() {
        return (Interlocked.CompareExchange(ref stageAndZero, 0, 0) & 1) == TRUE;
    }

    private bool CheckStageAndZero(int targetStage, int targetZero) {
        int val = Interlocked.CompareExchange(ref stageAndZero, 0, 0);
        return ((val >> 1) == targetStage) && ((val & 1) == targetZero);
    }

    private void SetZero(int targetZero) {
        Interlocked.Exchange(ref stageAndZero, (Interlocked.CompareExchange(ref stageAndZero, 0, 0) & ~1) + targetZero);
    }

    private void SetStageAndZero(int targetStage, int targetZero) {
        Interlocked.Exchange(ref stageAndZero, (targetStage << 1) + targetZero);
    }
}
```

```C++
class ZeroEvenOdd {
private:
    static constexpr int ODD = 1, EVEN = 2;
    static constexpr int TRUE = 1, FALSE = 0;
    int n;
    atomic<int> stageAndZero;

public:
    ZeroEvenOdd(int n) {
        this->n = n;
        this->stageAndZero.store((ODD << 1) + TRUE);
    }

    void zero(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i++) {
            while (!checkZero()) {
                this_thread::yield();
            }
            printNumber(0);
            setZero(FALSE);
        }
    }

    void even(function<void(int)> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            while (!checkStageAndZero(EVEN, FALSE)) {
                this_thread::yield();
            }
            printNumber(i);
            setStageAndZero(ODD, TRUE);
        }
    }

    void odd(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            while (!checkStageAndZero(ODD, FALSE)) {
                this_thread::yield();
            }
            printNumber(i);
            setStageAndZero(EVEN, TRUE);
        }
    }

private:
    bool checkZero() {
        return (stageAndZero.load() & 1) == TRUE;
    }

    bool checkStageAndZero(int targetStage, int targetZero) {
        int val = stageAndZero.load();
        return ((val >> 1) == targetStage) && ((val & 1) == targetZero);
    }

    void setZero(int targetZero) {
        stageAndZero.store((stageAndZero.load() & ~1) + targetZero);
    }

    void setStageAndZero(int targetStage, int targetZero) {
        stageAndZero.store((targetStage << 1) + targetZero);
    }
};
```

```C
#include <stdatomic.h>

static const int ODD = 1, EVEN = 2;
static const int TRUE_VAL = 1, FALSE_VAL = 0;

typedef struct {
    int n;
    _Atomic int stageAndZero;
} ZeroEvenOdd;

void printNumber(int x);

ZeroEvenOdd* zeroEvenOddCreate(int n) {
    ZeroEvenOdd* obj = (ZeroEvenOdd*) malloc(sizeof(ZeroEvenOdd));
    obj->n = n;
    atomic_init(&obj->stageAndZero, (ODD << 1) + TRUE_VAL);
    return obj;
}

bool checkZero(_Atomic int* stageAndZero) {
    return (atomic_load(stageAndZero) & 1) == TRUE_VAL;
}

bool checkStageAndZero(_Atomic int* stageAndZero, int targetStage, int targetZero) {
    int val = atomic_load(stageAndZero);
    return ((val >> 1) == targetStage) && ((val & 1) == targetZero);
}

void setZero(_Atomic int* stageAndZero, int targetZero) {
    atomic_store(stageAndZero, (atomic_load(stageAndZero) & ~1) + targetZero);
}

void setStageAndZero(_Atomic int* stageAndZero, int targetStage, int targetZero) {
    atomic_store(stageAndZero, (targetStage << 1) + targetZero);
}

void zero(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i++) {
        while (!checkZero(&obj->stageAndZero)) {
            sched_yield();
        }
        printNumber(0);
        setZero(&obj->stageAndZero, FALSE_VAL);
    }
}

void even(ZeroEvenOdd* obj) {
    for (int i = 2; i <= obj->n; i += 2) {
        while (!checkStageAndZero(&obj->stageAndZero, EVEN, FALSE_VAL)) {
            sched_yield();
        }
        printNumber(i);
        setStageAndZero(&obj->stageAndZero, ODD, TRUE_VAL);
    }
}

void odd(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i += 2) {
        while (!checkStageAndZero(&obj->stageAndZero, ODD, FALSE_VAL)) {
            sched_yield();
        }
        printNumber(i);
        setStageAndZero(&obj->stageAndZero, EVEN, TRUE_VAL);
    }
}

void zeroEvenOddFree(ZeroEvenOdd* obj) {
    free(obj);
}
```

```Go
const (
    ODD = 1
    EVEN = 2
    TRUE = 1
    FALSE = 0
)

type ZeroEvenOdd struct {
    n            int
    stageAndZero atomic.Int32
}

func NewZeroEvenOdd(n int) *ZeroEvenOdd {
    zeo := &ZeroEvenOdd{n: n}
    zeo.stageAndZero.Store((ODD << 1) + TRUE)
    return zeo
}

func (z *ZeroEvenOdd) Zero(printNumber func(int)) {
    for i := 1; i <= z.n; i++ {
        for !z.CheckZero() {
            runtime.Gosched()
        }
        printNumber(0)
        z.SetZero(FALSE)
    }
}

func (z *ZeroEvenOdd) Even(printNumber func(int)) {
    for i := 2; i <= z.n; i += 2 {
        for !z.CheckStageAndZero(EVEN, FALSE) {
            runtime.Gosched()
        }
        printNumber(i)
        z.SetStageAndZero(ODD, TRUE)
    }
}

func (z *ZeroEvenOdd) Odd(printNumber func(int)) {
    for i := 1; i <= z.n; i += 2 {
        for !z.CheckStageAndZero(ODD, FALSE) {
            runtime.Gosched()
        }
        printNumber(i)
        z.SetStageAndZero(EVEN, TRUE)
    }
}

func (z *ZeroEvenOdd) CheckZero() bool {
    return (z.stageAndZero.Load() & 1) == TRUE
}

func (z *ZeroEvenOdd) CheckStageAndZero(targetStage int32, targetZero int32) bool {
    val := z.stageAndZero.Load()
    return ((val >> 1) == targetStage) && ((val & 1) == targetZero)
}

func (z *ZeroEvenOdd) SetZero(targetZero int32) {
    z.stageAndZero.Store((z.stageAndZero.Load() & ^1) + targetZero)
}

func (z *ZeroEvenOdd) SetStageAndZero(targetStage int32, targetZero int32) {
    z.stageAndZero.Store((targetStage << 1) + targetZero)
}
```

```Rust
use std::sync::atomic::{AtomicI32, Ordering};

const ODD: i32 = 1;
const EVEN: i32 = 2;
const TRUE: i32 = 1;
const FALSE: i32 = 0;

struct ZeroEvenOdd {
    n: i32,
    stage_and_zero: AtomicI32,
}

impl ZeroEvenOdd {
    fn new(n: i32) -> Self {

        ZeroEvenOdd {
            n,
            stage_and_zero: AtomicI32::new((ODD << 1) + TRUE),
        }
    }

    fn zero<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        for _ in 1..=self.n {
            while !self.check_zero() {
                thread::yield_now();
            }
            print_number(0);
            self.set_zero(FALSE);
        }
    }

    fn even<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        let mut i = 2;
        while i <= self.n {
            while !self.check_stage_and_zero(EVEN, FALSE) {
                thread::yield_now();
            }
            print_number(i);
            self.set_stage_and_zero(ODD, TRUE);
            i += 2;
        }
    }

    fn odd<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        let mut i = 1;
        while i <= self.n {
            while !self.check_stage_and_zero(ODD, FALSE) {
                thread::yield_now();
            }
            print_number(i);
            self.set_stage_and_zero(EVEN, TRUE);
            i += 2;
        }
    }

    fn check_zero(&self) -> bool {
        (self.stage_and_zero.load(Ordering::Relaxed) & 1) == TRUE
    }

    fn check_stage_and_zero(&self, target_stage: i32, target_zero: i32) -> bool {
        let val = self.stage_and_zero.load(Ordering::Relaxed);
        ((val >> 1) == target_stage) && ((val & 1) == target_zero)
    }

    fn set_zero(&self, target_zero: i32) {
        self.stage_and_zero
            .fetch_update(Ordering::Relaxed, Ordering::Relaxed, |val| {
                Some((val & !1) + target_zero)
            })
            .ok();
    }

    fn set_stage_and_zero(&self, target_stage: i32, target_zero: i32) {
        self.stage_and_zero
            .store((target_stage << 1) + target_zero, Ordering::Relaxed);
    }
}
```

#### 解法三

##### 思路

维护变量 $stage$ 表示当前允许执行的方法对应的奇偶性，维护变量 $isZero$ 表示当前允许执行的方法是打印零的方法还是打印非零的方法。使用关键字 $synchronized$ 指定同步代码块，配合使用方法 $wait$ 和 $notifyAll$。

##### 代码

```Java
class ZeroEvenOdd {
    private static final int ODD = 1, EVEN = 2;
    private int n;
    private int stage;
    private boolean isZero;
    private Object lock;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stage = ODD;
        this.isZero = true;
        this.lock = new Object();
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            synchronized (lock) {
                while (!isZero) {
                    lock.wait();
                }
                printNumber.accept(0);
                isZero = false;
                lock.notifyAll();
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            synchronized (lock) {
                while (stage != EVEN || isZero) {
                    lock.wait();
                }
                printNumber.accept(i);
                stage = ODD;
                isZero = true;
                lock.notifyAll();
            }
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            synchronized (lock) {
                while (stage != ODD || isZero) {
                    lock.wait();
                }
                printNumber.accept(i);
                stage = EVEN;
                isZero = true;
                lock.notifyAll();
            }
        }
    }
}
```

```CSharp
using System.Threading;

public class ZeroEvenOdd {
    private const int ODD = 1, EVEN = 2;
    private int n;
    private int stage;
    private bool isZero;
    private object lockObj;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stage = ODD;
        this.isZero = true;
        this.lockObj = new object();
    }

    public void Zero(Action<int> printNumber) {
        for (int i = 1; i <= n; i++) {
            lock (lockObj) {
                while (!isZero) {
                    Monitor.Wait(lockObj);
                }
                printNumber(0);
                isZero = false;
                Monitor.PulseAll(lockObj);
            }
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            lock (lockObj) {
                while (stage != EVEN || isZero) {
                    Monitor.Wait(lockObj);
                }
                printNumber(i);
                stage = ODD;
                isZero = true;
                Monitor.PulseAll(lockObj);
            }
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            lock (lockObj) {
                while (stage != ODD || isZero) {
                    Monitor.Wait(lockObj);
                }
                printNumber(i);
                stage = EVEN;
                isZero = true;
                Monitor.PulseAll(lockObj);
            }
        }
    }
}
```

#### 解法四

##### 思路

维护变量 $stage$ 表示当前允许执行的方法对应的奇偶性，维护变量 $isZero$ 表示当前允许执行的方法是打印零的方法还是打印非零的方法。使用条件变量（$Condition$）并与锁（$Lock$）绑定，可实现更精准的线程唤醒。

##### 代码

```Java
class ZeroEvenOdd {
    private static final int ODD = 1, EVEN = 2;
    private int n;
    private int stage;
    private boolean isZero;
    private Lock lock;
    private Condition condition;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stage = ODD;
        this.isZero = true;
        this.lock = new ReentrantLock();
        this.condition = lock.newCondition();
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            lock.lock();
            try {
                while (!isZero) {
                    condition.await();
                }
                printNumber.accept(0);
                isZero = false;
                condition.signalAll();
            } finally {
                lock.unlock();
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            lock.lock();
            try {
                while (stage != EVEN || isZero) {
                    condition.await();
                }
                printNumber.accept(i);
                stage = ODD;
                isZero = true;
                condition.signalAll();
            } finally {
                lock.unlock();
            }
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            lock.lock();
            try {
                while (stage != ODD || isZero) {
                    condition.await();
                }
                printNumber.accept(i);
                stage = EVEN;
                isZero = true;
                condition.signalAll();
            } finally {
                lock.unlock();
            }
        }
    }
}
```

```C++
class ZeroEvenOdd {
private:
    static constexpr int ODD = 1, EVEN = 2;
    int n;
    int stage;
    bool isZero;
    mutex mtx;
    condition_variable cv;

public:
    ZeroEvenOdd(int n) {
        this->n = n;
        this->stage = ODD;
        this->isZero = true;
    }

    void zero(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i++) {
            unique_lock<mutex> lock(mtx);
            while (!isZero) {
                cv.wait(lock);
            }
            printNumber(0);
            isZero = false;
            cv.notify_all();
        }
    }

    void even(function<void(int)> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            unique_lock<mutex> lock(mtx);
            while (stage != EVEN || isZero) {
                cv.wait(lock);
            }
            printNumber(i);
            stage = ODD;
            isZero = true;
            cv.notify_all();
        }
    }

    void odd(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            unique_lock<mutex> lock(mtx);
            while (stage != ODD || isZero) {
                cv.wait(lock);
            }
            printNumber(i);
            stage = EVEN;
            isZero = true;
            cv.notify_all();
        }
    }
};
```

```Python
import threading

class ZeroEvenOdd:
    ODD, EVEN = 1, 2

    def __init__(self, n):
        self.n = n
        self.stage = self.ODD
        self.isZero = True
        self.cond = threading.Condition()

    def zero(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1):
            with self.cond:
                while not self.isZero:
                    self.cond.wait()
                printNumber(0)
                self.isZero = False
                self.cond.notify_all()

    def even(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(2, self.n + 1, 2):
            with self.cond:
                while self.stage != self.EVEN or self.isZero:
                    self.cond.wait()
                printNumber(i)
                self.stage = self.ODD
                self.isZero = True
                self.cond.notify_all()

    def odd(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1, 2):
            with self.cond:
                while self.stage != self.ODD or self.isZero:
                    self.cond.wait()
                printNumber(i)
                self.stage = self.EVEN
                self.isZero = True
                self.cond.notify_all()
```

```C
#include <stdatomic.h>

static const int ODD = 1, EVEN = 2;

typedef struct {
    int n;
    int stage;
    bool isZero;
    pthread_mutex_t mutex;
    pthread_cond_t cond;
} ZeroEvenOdd;

void printNumber(int x);

ZeroEvenOdd* zeroEvenOddCreate(int n) {
    ZeroEvenOdd* obj = (ZeroEvenOdd*) malloc(sizeof(ZeroEvenOdd));
    obj->n = n;
    obj->stage = ODD;
    obj->isZero = true;
    pthread_mutex_init(&obj->mutex, NULL);
    pthread_cond_init(&obj->cond, NULL);
    return obj;
}

void zero(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i++) {
        pthread_mutex_lock(&obj->mutex);
        while (!obj->isZero) {
            pthread_cond_wait(&obj->cond, &obj->mutex);
        }
        printNumber(0);
        obj->isZero = false;
        pthread_cond_broadcast(&obj->cond);
        pthread_mutex_unlock(&obj->mutex);
    }
}

void even(ZeroEvenOdd* obj) {
    for (int i = 2; i <= obj->n; i += 2) {
        pthread_mutex_lock(&obj->mutex);
        while (obj->stage != EVEN || obj->isZero) {
            pthread_cond_wait(&obj->cond, &obj->mutex);
        }
        printNumber(i);
        obj->stage = ODD;
        obj->isZero = true;
        pthread_cond_broadcast(&obj->cond);
        pthread_mutex_unlock(&obj->mutex);
    }
}

void odd(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i += 2) {
        pthread_mutex_lock(&obj->mutex);
        while (obj->stage != ODD || obj->isZero) {
            pthread_cond_wait(&obj->cond, &obj->mutex);
        }
        printNumber(i);
        obj->stage = EVEN;
        obj->isZero = true;
        pthread_cond_broadcast(&obj->cond);
        pthread_mutex_unlock(&obj->mutex);
    }
}

void zeroEvenOddFree(ZeroEvenOdd* obj) {
    free(obj);
}
```

```Go
const (
    ODD = 1
    EVEN = 2
)

type ZeroEvenOdd struct {
    n      int
    stage  int
    isZero bool
    mu     sync.Mutex
    cond   *sync.Cond
}

func NewZeroEvenOdd(n int) *ZeroEvenOdd {
    zeo := &ZeroEvenOdd{
        n: n,
        stage: ODD,
        isZero: true,
    }
    zeo.cond = sync.NewCond(&zeo.mu)
    return zeo
}

func (z *ZeroEvenOdd) Zero(printNumber func(int)) {
    for i := 1; i <= z.n; i++ {
        z.mu.Lock()
        for !z.isZero {
            z.cond.Wait()
        }
        printNumber(0)
        z.isZero = false
        z.cond.Broadcast()
        z.mu.Unlock()
    }
}

func (z *ZeroEvenOdd) Even(printNumber func(int)) {
    for i := 2; i <= z.n; i += 2 {
        z.mu.Lock()
        for z.stage != EVEN || z.isZero {
            z.cond.Wait()
        }
        printNumber(i)
        z.stage = ODD
        z.isZero = true
        z.cond.Broadcast()
        z.mu.Unlock()
    }
}

func (z *ZeroEvenOdd) Odd(printNumber func(int)) {
    for i := 1; i <= z.n; i += 2 {
        z.mu.Lock()
        for z.stage != ODD || z.isZero {
            z.cond.Wait()
        }
        printNumber(i)
        z.stage = EVEN
        z.isZero = true
        z.cond.Broadcast()
        z.mu.Unlock()
    }
}
```

```Rust
use std::sync::Condvar;

const ODD: i32 = 1;
const EVEN: i32 = 2;

struct ZeroEvenOdd {
    n: i32,
    state: Mutex<SharedState>,
    cond: Condvar,
}

struct SharedState {
    stage: i32,
    is_zero: bool,
}

impl ZeroEvenOdd {
    fn new(n: i32) -> Self {
        ZeroEvenOdd {
            n,
            state: Mutex::new(SharedState { stage: ODD, is_zero: true }),
            cond: Condvar::new(),
        }
    }

    fn zero<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        for _ in 1..=self.n {
            let mut state = self.state.lock().unwrap();
            while !state.is_zero {
                state = self.cond.wait(state).unwrap();
            }
            print_number(0);
            state.is_zero = false;
            self.cond.notify_all();
        }
    }

    fn even<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        let mut i = 2;
        while i <= self.n {
            let mut state = self.state.lock().unwrap();
            while state.stage != EVEN || state.is_zero {
                state = self.cond.wait(state).unwrap();
            }
            print_number(i);
            state.stage = ODD;
            state.is_zero = true;
            self.cond.notify_all();
            i += 2;
        }
    }

    fn odd<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        let mut i = 1;
        while i <= self.n {
            let mut state = self.state.lock().unwrap();
            while state.stage != ODD || state.is_zero {
                state = self.cond.wait(state).unwrap();
            }
            print_number(i);
            state.stage = EVEN;
            state.is_zero = true;
            self.cond.notify_all();
            i += 2;
        }
    }
}
```

#### 解法五

##### 思路

使用信号量（$Semaphore$）可以控制当前允许执行的方法。方法 zero、even 和 $odd$ 各对应一个信号量，只有允许执行的方法有一个许可，其余方法都没有许可。

对于 $1\le i\le n$ 的每个整数 $i$，当 $i$ 是奇数时执行方法 $zero$ 和 $odd$，当 $i$ 是偶数时执行方法 $zero$ 和 $even$，每个方法的执行流程如下。

1. 当前方法对应的信号量获取一个许可，如果没有许可则被阻塞。
2. 当前信号量获取一个许可之后，执行当前方法。
3. 下一个待执行的方法对应的信号量释放一个许可。

##### 代码

```Java
class ZeroEvenOdd {
    private int n;
    private Semaphore semaphoreZero;
    private Semaphore semaphoreEven;
    private Semaphore semaphoreOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.semaphoreZero = new Semaphore(1);
        this.semaphoreEven = new Semaphore(0);
        this.semaphoreOdd = new Semaphore(0);
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            semaphoreZero.acquire();
            printNumber.accept(0);
            if (i % 2 == 0) {
                semaphoreEven.release();
            } else {
                semaphoreOdd.release();
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            semaphoreEven.acquire();
            printNumber.accept(i);
            semaphoreZero.release();
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            semaphoreOdd.acquire();
            printNumber.accept(i);
            semaphoreZero.release();
        }
    }
}
```

```CSharp
using System.Threading;

public class ZeroEvenOdd {
    private int n;
    private SemaphoreSlim semaphoreZero;
    private SemaphoreSlim semaphoreEven;
    private SemaphoreSlim semaphoreOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.semaphoreZero = new SemaphoreSlim(1, 1);
        this.semaphoreEven = new SemaphoreSlim(0, 1);
        this.semaphoreOdd = new SemaphoreSlim(0, 1);
    }

    public void Zero(Action<int> printNumber) {
        for (int i = 1; i <= n; i++) {
            semaphoreZero.Wait();
            printNumber(0);
            if (i % 2 == 0) {
                semaphoreEven.Release();
            } else {
                semaphoreOdd.Release();
            }
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            semaphoreEven.Wait();
            printNumber(i);
            semaphoreZero.Release();
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            semaphoreOdd.Wait();
            printNumber(i);
            semaphoreZero.Release();
        }
    }
}
```

```C++
class ZeroEvenOdd {
private:
    int n;
    binary_semaphore semaphoreZero{1};
    binary_semaphore semaphoreEven{0};
    binary_semaphore semaphoreOdd{0};

public:
    ZeroEvenOdd(int n) {
        this->n = n;
    }

    void zero(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i++) {
            semaphoreZero.acquire();
            printNumber(0);
            if (!(i % 2)) {
                semaphoreEven.release();
            } else {
                semaphoreOdd.release();
            }
        }
    }

    void even(function<void(int)> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            semaphoreEven.acquire();
            printNumber(i);
            semaphoreZero.release();
        }
    }

    void odd(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            semaphoreOdd.acquire();
            printNumber(i);
            semaphoreZero.release();
        }
    }
};
```

```Python
import threading

class ZeroEvenOdd:
    def __init__(self, n):
        self.n = n
        self.semaphoreZero = threading.Semaphore(1)
        self.semaphoreEven = threading.Semaphore(0)
        self.semaphoreOdd = threading.Semaphore(0)

    def zero(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1):
            self.semaphoreZero.acquire()
            printNumber(0)
            if not i % 2:
                self.semaphoreEven.release()
            else:
                self.semaphoreOdd.release()

    def even(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(2, self.n + 1, 2):
            self.semaphoreEven.acquire()
            printNumber(i)
            self.semaphoreZero.release()

    def odd(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1, 2):
            self.semaphoreOdd.acquire()
            printNumber(i)
            self.semaphoreZero.release()
```

```C
typedef struct {
    int n;
    sem_t semaphoreZero;
    sem_t semaphoreEven;
    sem_t semaphoreOdd;
} ZeroEvenOdd;

void printNumber(int x);

ZeroEvenOdd* zeroEvenOddCreate(int n) {
    ZeroEvenOdd* obj = (ZeroEvenOdd*) malloc(sizeof(ZeroEvenOdd));
    obj->n = n;
    sem_init(&obj->semaphoreZero, 0, 1);
    sem_init(&obj->semaphoreEven, 0, 0);
    sem_init(&obj->semaphoreOdd, 0, 0);
    return obj;
}

void zero(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i++) {
        sem_wait(&obj->semaphoreZero);
        printNumber(0);
        if (!(i % 2)) {
            sem_post(&obj->semaphoreEven);
        } else {
            sem_post(&obj->semaphoreOdd);
        }
    }
}

void even(ZeroEvenOdd* obj) {
    for (int i = 2; i <= obj->n; i += 2) {
        sem_wait(&obj->semaphoreEven);
        printNumber(i);
        sem_post(&obj->semaphoreZero);
    }
}

void odd(ZeroEvenOdd* obj) {
    for (int i = 1; i <= obj->n; i += 2) {
        sem_wait(&obj->semaphoreOdd);
        printNumber(i);
        sem_post(&obj->semaphoreZero);
    }
}

void zeroEvenOddFree(ZeroEvenOdd* obj) {
    sem_destroy(&obj->semaphoreZero);
    sem_destroy(&obj->semaphoreEven);
    sem_destroy(&obj->semaphoreOdd);
    free(obj);
}
```

```Go
type ZeroEvenOdd struct {
    n             int
    semaphoreZero chan struct{}
    semaphoreEven chan struct{}
    semaphoreOdd  chan struct{}
}

func NewZeroEvenOdd(n int) *ZeroEvenOdd {
    zeo := &ZeroEvenOdd{
        n:             n,
        semaphoreZero: make(chan struct{}, 1),
        semaphoreEven: make(chan struct{}, 1),
        semaphoreOdd:  make(chan struct{}, 1),
    }
    zeo.semaphoreZero <- struct{}{}
    return zeo
}

func (z *ZeroEvenOdd) Zero(printNumber func(int)) {
    for i := 1; i <= z.n; i++ {
        <-z.semaphoreZero
        printNumber(0)
        if i % 2 == 0 {
            z.semaphoreEven <- struct{}{}
        } else {
            z.semaphoreOdd <- struct{}{}
        }
    }
}

func (z *ZeroEvenOdd) Even(printNumber func(int)) {
    for i := 2; i <= z.n; i += 2 {
        <-z.semaphoreEven
        printNumber(i)
        z.semaphoreZero <- struct{}{}
    }
}

func (z *ZeroEvenOdd) Odd(printNumber func(int)) {
    for i := 1; i <= z.n; i += 2 {
        <-z.semaphoreOdd
        printNumber(i)
        z.semaphoreZero <- struct{}{}
    }
}
```

```Rust
use std::sync::Condvar;

struct Semaphore {
    mutex: Mutex<i32>,
    condvar: Condvar,
}

impl Semaphore {
    fn new(count: i32) -> Self {
        Semaphore {
            mutex: Mutex::new(count),
            condvar: Condvar::new(),
        }
    }

    fn acquire(&self) {
        let mut count = self.mutex.lock().unwrap();
        while *count == 0 {
            count = self.condvar.wait(count).unwrap();
        }
        *count -= 1;
    }

    fn release(&self) {
        let mut count = self.mutex.lock().unwrap();
        *count += 1;
        self.condvar.notify_one();
    }
}

struct ZeroEvenOdd {
    n: i32,
    semaphore_zero: Semaphore,
    semaphore_even: Semaphore,
    semaphore_odd: Semaphore,
}

impl ZeroEvenOdd {
    fn new(n: i32) -> Self {
        ZeroEvenOdd {
            n,
            semaphore_zero: Semaphore::new(1),
            semaphore_even: Semaphore::new(0),
            semaphore_odd: Semaphore::new(0),
        }
    }

    fn zero<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        for i in 1..=self.n {
            self.semaphore_zero.acquire();
            print_number(0);
            if i % 2 == 0 {
                self.semaphore_even.release();
            } else {
                self.semaphore_odd.release();
            }
        }
    }

    fn even<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        let mut i = 2;
        while i <= self.n {
            self.semaphore_even.acquire();
            print_number(i);
            self.semaphore_zero.release();
            i += 2;
        }
    }

    fn odd<F>(&self, print_number: F)
    where
        F: Fn(i32),
    {
        let mut i = 1;
        while i <= self.n {
            self.semaphore_odd.acquire();
            print_number(i);
            self.semaphore_zero.release();
            i += 2;
        }
    }
}
```

#### 解法六

#### 思路

使用倒计时门闩（$CountDownLatch$）可以控制当前允许执行的方法。只有在上一个方法执行结束时，当前方法才能执行。

##### 代码

```Java
class ZeroEvenOdd {
    private int n;
    private CountDownLatch[] countDownLatchZero;
    private CountDownLatch[] countDownLatchEven;
    private CountDownLatch[] countDownLatchOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.countDownLatchZero = new CountDownLatch[n + 1];
        this.countDownLatchEven = new CountDownLatch[n + 1];
        this.countDownLatchOdd = new CountDownLatch[n + 1];
        for (int i = 1; i <= n; i++) {
            countDownLatchZero[i] = i == 1 ? new CountDownLatch(0) : new CountDownLatch(1);
            if (i % 2 == 0) {
                countDownLatchEven[i] = new CountDownLatch(1);
            } else {
                countDownLatchOdd[i] = new CountDownLatch(1);
            }
        }
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            countDownLatchZero[i].await();
            printNumber.accept(0);
            if (i % 2 == 0) {
                countDownLatchEven[i].countDown();
            } else {
                countDownLatchOdd[i].countDown();
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            countDownLatchEven[i].await();
            printNumber.accept(i);
            if (i < n) {
                countDownLatchZero[i + 1].countDown();
            }
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            countDownLatchOdd[i].await();
            printNumber.accept(i);
            if (i < n) {
                countDownLatchZero[i + 1].countDown();
            }
        }
    }
}
```

```CSharp
using System.Threading;

public class ZeroEvenOdd {
    private int n;
    private CountdownEvent[] countdownEventZero;
    private CountdownEvent[] countdownEventEven;
    private CountdownEvent[] countdownEventOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.countdownEventZero = new CountdownEvent[n + 1];
        this.countdownEventEven = new CountdownEvent[n + 1];
        this.countdownEventOdd = new CountdownEvent[n + 1];
        for (int i = 1; i <= n; i++) {
            countdownEventZero[i] = i == 1 ? new CountdownEvent(0) : new CountdownEvent(1);
            if (i % 2 == 0) {
                countdownEventEven[i] = new CountdownEvent(1);
            } else {
                countdownEventOdd[i] = new CountdownEvent(1);
            }
        }
    }

    public void Zero(Action<int> printNumber) {
        for (int i = 1; i <= n; i++) {
            countdownEventZero[i].Wait();
            printNumber(0);
            if (i % 2 == 0) {
                countdownEventEven[i].Signal();
            } else {
                countdownEventOdd[i].Signal();
            }
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            countdownEventEven[i].Wait();
            printNumber(i);
            if (i < n) {
                countdownEventZero[i + 1].Signal();
            }
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            countdownEventOdd[i].Wait();
            printNumber(i);
            if (i < n) {
                countdownEventZero[i + 1].Signal();
            }
        }
    }
}
```

```Python
import threading

class ZeroEvenOdd:
    def __init__(self, n):
        self.n = n
        self.eventZero = []
        self.eventEven = []
        self.eventOdd = []
        for i in range(n + 1):
            self.eventZero.append(threading.Event())
            self.eventEven.append(threading.Event())
            self.eventOdd.append(threading.Event())
        self.eventZero[1].set()

    def zero(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1):
            self.eventZero[i].wait()
            printNumber(0)
            if not i % 2:
                self.eventEven[i].set()
            else:
                self.eventOdd[i].set()

    def even(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(2, self.n + 1, 2):
            self.eventEven[i].wait()
            printNumber(i)
            if i < self.n:
                self.eventZero[i + 1].set()

    def odd(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1, 2):
            self.eventOdd[i].wait()
            printNumber(i)
            if i < self.n:
                self.eventZero[i + 1].set()
```

#### 解法七

##### 思路

使用循环屏障（$CyclicBarrier$）可以控制当前允许执行的方法。只有在上一个方法执行结束时，当前方法才能执行。

##### 代码

```Java
class ZeroEvenOdd {
    private static final int ODD = 1, EVEN = 2;
    private int n;
    private int stage;
    private boolean isZero;
    private CyclicBarrier cyclicBarrier;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stage = ODD;
        this.isZero = true;
        this.cyclicBarrier = new CyclicBarrier(2);
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            while (!isZero) {
                Thread.yield();
            }
            printNumber.accept(0);
            isZero = false;
            try {
                cyclicBarrier.await();
            } catch (BrokenBarrierException e) {
                Thread.currentThread().interrupt();
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            while (stage != EVEN || isZero) {
                Thread.yield();
            }
            printNumber.accept(i);
            stage = ODD;
            isZero = true;
            try {
                cyclicBarrier.await();
            } catch (BrokenBarrierException e) {
                Thread.currentThread().interrupt();
            }
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            while (stage != ODD || isZero) {
                Thread.yield();
            }
            printNumber.accept(i);
            stage = EVEN;
            isZero = true;
            try {
                cyclicBarrier.await();
            } catch (BrokenBarrierException e) {
                Thread.currentThread().interrupt();
            }
        }
    }
}
```

#### 解法八

##### 思路

使用锁支持（$LockSupport$）可以实现以线程为单位的阻塞与唤醒方法，方法 $LockSupport.park$ 将当前线程阻塞，方法 $LockSupport.unpark$ 将指定线程唤醒。

锁支持使用许可（$permit$）的概念实现线程的阻塞和唤醒，每个线程最多只有一个许可。

##### 代码

```Java
class ZeroEvenOdd {
    private static final int ZERO = 0, ODD = 1, EVEN = 2;
    private int n;
    private int stage;
    private boolean isZero;
    private Map<Integer, Thread> threads;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.stage = ODD;
        this.isZero = true;
        this.threads = new HashMap<Integer, Thread>();
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        threads.put(ZERO, Thread.currentThread());
        for (int i = 1; i <= n; i++) {
            while (!isZero) {
                LockSupport.park();
            }
            printNumber.accept(0);
            isZero = false;
            if (i % 2 == 0) {
                LockSupport.unpark(threads.get(EVEN));
            } else {
                LockSupport.unpark(threads.get(ODD));
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        threads.put(EVEN, Thread.currentThread());
        for (int i = 2; i <= n; i += 2) {
            while (stage != EVEN || isZero) {
                LockSupport.park();
            }
            printNumber.accept(i);
            stage = ODD;
            isZero = true;
            LockSupport.unpark(threads.get(ZERO));
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        threads.put(ODD, Thread.currentThread());
        for (int i = 1; i <= n; i += 2) {
            while (stage != ODD || isZero) {
                LockSupport.park();
            }
            printNumber.accept(i);
            stage = EVEN;
            isZero = true;
            LockSupport.unpark(threads.get(ZERO));
        }
    }
}
```

#### 解法九

##### 思路

使用可完成的异步任务（$CompletableFuture$）可以支持异步任务的依赖组合，通过方法 $get$ 或 $join$ 等待前一个任务完成的信号，然后执行当前任务并触发下一个信号。

##### 代码

```Java
class ZeroEvenOdd {
    private int n;
    private CompletableFuture<Void>[] completableFutureZero;
    private CompletableFuture<Void>[] completableFutureEven;
    private CompletableFuture<Void>[] completableFutureOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.completableFutureZero = new CompletableFuture[n + 1];
        this.completableFutureEven = new CompletableFuture[n + 1];
        this.completableFutureOdd = new CompletableFuture[n + 1];
        for (int i = 1; i <= n; i++) {
            completableFutureZero[i] = new CompletableFuture<Void>();
            completableFutureEven[i] = new CompletableFuture<Void>();
            completableFutureOdd[i] = new CompletableFuture<Void>();
        }
        completableFutureZero[1].complete(null);
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i++) {
            try {
                completableFutureZero[i].get();
            } catch (ExecutionException e) {
                Thread.currentThread().interrupt();
                return;
            }
            printNumber.accept(0);
            if (i % 2 == 0) {
                completableFutureEven[i].complete(null);
            } else {
                completableFutureOdd[i].complete(null);
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            try {
                completableFutureEven[i].get();
            } catch (ExecutionException e) {
                Thread.currentThread().interrupt();
                return;
            }
            printNumber.accept(i);
            if (i < n) {
                completableFutureZero[i + 1].complete(null);
            }
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            try {
                completableFutureOdd[i].get();
            } catch (ExecutionException e) {
                Thread.currentThread().interrupt();
                return;
            }
            printNumber.accept(i);
            if (i < n) {
                completableFutureZero[i + 1].complete(null);
            }
        }
    }
}
```

```CSharp
using System.Threading.Tasks;

public class ZeroEvenOdd {
    private int n;
    private TaskCompletionSource<object>[] taskCompletionSourceZero;
    private TaskCompletionSource<object>[] taskCompletionSourceEven;
    private TaskCompletionSource<object>[] taskCompletionSourceOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.taskCompletionSourceZero = new TaskCompletionSource<object>[n + 1];
        this.taskCompletionSourceEven = new TaskCompletionSource<object>[n + 1];
        this.taskCompletionSourceOdd = new TaskCompletionSource<object>[n + 1];
        for (int i = 1; i <= n; i++) {
            taskCompletionSourceZero[i] = new TaskCompletionSource<object>();
            taskCompletionSourceEven[i] = new TaskCompletionSource<object>();
            taskCompletionSourceOdd[i] = new TaskCompletionSource<object>();
        }
        taskCompletionSourceZero[1].SetResult(null);
    }

    public void Zero(Action<int> printNumber) {
        for (int i = 1; i <= n; i++) {
            taskCompletionSourceZero[i].Task.Wait();
            printNumber(0);
            if (i % 2 == 0) {
                taskCompletionSourceEven[i].SetResult(null);
            } else {
                taskCompletionSourceOdd[i].SetResult(null);
            }
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            taskCompletionSourceEven[i].Task.Wait();
            printNumber(i);
            if (i < n) {
                taskCompletionSourceZero[i + 1].SetResult(null);
            }
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            taskCompletionSourceOdd[i].Task.Wait();
            printNumber(i);
            if (i < n) {
                taskCompletionSourceZero[i + 1].SetResult(null);
            }
        }
    }
}
```

```C++
class ZeroEvenOdd {
private:
    int n;
    vector<promise<void>> promiseZero;
    vector<promise<void>> promiseEven;
    vector<promise<void>> promiseOdd;

public:
    ZeroEvenOdd(int n) {
        this->n = n;
        this->promiseZero.resize(n + 1);
        this->promiseEven.resize(n + 1);
        this->promiseOdd.resize(n + 1);
        promiseZero[1].set_value();
    }

    void zero(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i++) {
            promiseZero[i].get_future().wait();
            printNumber(0);
            if (!(i % 2)) {
                promiseEven[i].set_value();
            } else {
                promiseOdd[i].set_value();
            }
        }
    }

    void even(function<void(int)> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            promiseEven[i].get_future().wait();
            printNumber(i);
            if (i < n) {
                promiseZero[i + 1].set_value();
            }
        }
    }

    void odd(function<void(int)> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            promiseOdd[i].get_future().wait();
            printNumber(i);
            if (i < n) {
                promiseZero[i + 1].set_value();
            }
        }
    }
};
```

#### 解法十

##### 思路

使用阻塞队列（$BlockingQueue$）可以控制当前允许执行的方法。创建三个阻塞队列，分别为队列 zero、队列 $even$ 和队列 $odd$，分别对应方法 zero、方法 $even$ 和方法 $odd$，三个阻塞队列的容量都是 $1$。以下执行流程中，在阻塞队列中添加和取出元素时都需要考虑阻塞的情况：当添加元素时，如果阻塞队列没有剩余容量，则应等待直到阻塞队列有剩余容量；当取出元素时，如果阻塞队列为空，则应等待直到阻塞队列有元素。

执行方法 $zero$ 时，首先将 $1$ 添加到队列 $zero$，确保在循环开始之前队列 $zero$ 中恰好有一个元素。

对于 $1\le i\le n$ 的每个整数 $i$，执行到特定方法时，执行流程如下。

1. 将对应的阻塞队列的队首元素取出。
2. 打印特定整数。对于方法 $zero$，打印整数 $0$；对于方法 $even$ 和 $odd$，打印整数 $i$。
3. 将下一个需要打印的整数添加到下一个待执行方法对应的阻塞队列。具体做法如下。
    - 对于方法 $zero$，如果 $i$ 是偶数则将 $i$ 添加到队列 $even$，如果 $i$ 是奇数则将 $i$ 添加到队列 $odd$。
    - 对于方法 $even$ 和 $odd$，将 $i+1$ 添加到队列 $zero$。

阻塞队列的正确性理由如下。

1. 打印前的从阻塞队列中取出元素操作，其目的是判断当前方法是否可执行，当前方法对应的阻塞队列可以取出元素等价于当前方法未被阻塞。
2. 打印后的向阻塞队列添加元素操作，其目的是将下一个待执行的方法的状态更新为未被阻塞。

##### 代码

```Java
class ZeroEvenOdd {
    private int n;
    private BlockingQueue<Integer> blockingQueueZero;
    private BlockingQueue<Integer> blockingQueueEven;
    private BlockingQueue<Integer> blockingQueueOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.blockingQueueZero = new ArrayBlockingQueue<Integer>(1);
        this.blockingQueueEven = new ArrayBlockingQueue<Integer>(1);
        this.blockingQueueOdd = new ArrayBlockingQueue<Integer>(1);
    }

    public void zero(IntConsumer printNumber) throws InterruptedException {
        blockingQueueZero.put(1);
        for (int i = 1; i <= n; i++) {
            blockingQueueZero.take();
            printNumber.accept(0);
            if (i % 2 == 0) {
                blockingQueueEven.put(i);
            } else {
                blockingQueueOdd.put(i);
            }
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            blockingQueueEven.take();
            printNumber.accept(i);
            blockingQueueZero.put(i + 1);
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            blockingQueueOdd.take();
            printNumber.accept(i);
            blockingQueueZero.put(i + 1);
        }
    }
}
```

```CSharp
using System.Collections.Concurrent;

public class ZeroEvenOdd {
    private int n;
    private BlockingCollection<int> blockingQueueZero;
    private BlockingCollection<int> blockingQueueEven;
    private BlockingCollection<int> blockingQueueOdd;

    public ZeroEvenOdd(int n) {
        this.n = n;
        this.blockingQueueZero = new BlockingCollection<int>(1);
        this.blockingQueueEven = new BlockingCollection<int>(1);
        this.blockingQueueOdd = new BlockingCollection<int>(1);
    }

    public void Zero(Action<int> printNumber) {
        blockingQueueZero.Add(1);
        for (int i = 1; i <= n; i++) {
            blockingQueueZero.Take();
            printNumber(0);
            if (i % 2 == 0) {
                blockingQueueEven.Add(i);
            } else {
                blockingQueueOdd.Add(i);
            }
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i += 2) {
            blockingQueueEven.Take();
            printNumber(i);
            blockingQueueZero.Add(i + 1);
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i += 2) {
            blockingQueueOdd.Take();
            printNumber(i);
            blockingQueueZero.Add(i + 1);
        }
    }
}
```

```Python
import queue

class ZeroEvenOdd:
    def __init__(self, n):
        self.n = n
        self.blockingQueueZero = queue.Queue(1)
        self.blockingQueueEven = queue.Queue(1)
        self.blockingQueueOdd = queue.Queue(1)

    def zero(self, printNumber: 'Callable[[int], None]') -> None:
        self.blockingQueueZero.put(1)
        for i in range(1, self.n + 1):
            self.blockingQueueZero.get()
            printNumber(0)
            if not i % 2:
                self.blockingQueueEven.put(i)
            else:
                self.blockingQueueOdd.put(i)

    def even(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(2, self.n + 1, 2):
            self.blockingQueueEven.get()
            printNumber(i)
            self.blockingQueueZero.put(i + 1)

    def odd(self, printNumber: 'Callable[[int], None]') -> None:
        for i in range(1, self.n + 1, 2):
            self.blockingQueueOdd.get()
            printNumber(i)
            self.blockingQueueZero.put(i + 1)
```
