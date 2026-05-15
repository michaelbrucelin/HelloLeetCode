### [1117\. H2O 生成](https://leetcode.cn/problems/building-h2o/solutions/3939244/1117-h2o-sheng-cheng-by-stormsunshine-u2s4/?envType=problem-list-v2&envId=ySsxoJfz)

#### 前言

一个水分子（$H_2O$）由两个氢原子（$H$）和一个氧原子（$O$）构成。为了确保氢线程和氧线程可以正确地产生水分子，应确保所有线程的执行顺序是三个线程一组，每组包含两个氢线程和一个氧线程。

#### 解法一

##### 思路

维护变量 $stage$ 表示当前组已经执行的氢线程数。使用关键字 $synchronized$ 指定同步代码块，配合使用方法 $wait$ 和 $notifyAll$。

氢线程执行的方法 $hydrogen$ 的操作如下，所有操作都在同步代码块中。

1. 当 $stage=2$ 时，调用方法 $wait$，直到 $stage\ne 2$。
2. 释放氢原子。
3. 将 $stage$ 的值增加 $1$。
4. 调用方法 $notifyAll$。

氧线程执行的方法 $oxygen$ 的操作如下，所有操作都在同步代码块中。

1. 当 $stage=0$ 时，调用方法 $wait$，直到 $stage\ne 0$。
2. 释放氧原子。
3. 将 $stage$ 的值更新为 $0$。
4. 调用方法 $notifyAll$。

上述操作可以确保所有线程的执行顺序是三个线程一组，每组的前两个线程都是氢线程且后一个线程是氧线程。

##### 代码

```Java
class H2O {
    private static final int HYDROGEN = 0, OXYGEN = 2;
    private int stage;
    private Object lock;

    public H2O() {
        this.stage = HYDROGEN;
        this.lock = new Object();
    }

    public void hydrogen(Runnable releaseHydrogen) throws InterruptedException {
        synchronized (lock) {
            while (stage == OXYGEN) {
                lock.wait();
            }
            releaseHydrogen.run();
            stage++;
            lock.notifyAll();
        }
    }

    public void oxygen(Runnable releaseOxygen) throws InterruptedException {
        synchronized (lock) {
            while (stage != OXYGEN) {
                lock.wait();
            }
            releaseOxygen.run();
            stage = HYDROGEN;
            lock.notifyAll();
        }
    }
}
```

```CSharp
using System.Threading;

public class H2O {
    private const int HYDROGEN = 0, OXYGEN = 2;
    private int stage;
    private object lockObj;

    public H2O() {
        this.stage = HYDROGEN;
        this.lockObj = new object();
    }

    public void Hydrogen(Action releaseHydrogen) {
        lock (lockObj) {
            while (stage == OXYGEN) {
                Monitor.Wait(lockObj);
            }
            releaseHydrogen();
            stage++;
            Monitor.PulseAll(lockObj);
        }
    }

    public void Oxygen(Action releaseOxygen) {
        lock (lockObj) {
            while (stage != OXYGEN) {
                Monitor.Wait(lockObj);
            }
            releaseOxygen();
            stage = HYDROGEN;
            Monitor.PulseAll(lockObj);
        }
    }
}
```

#### 解法二

##### 思路

维护变量 $stage$ 表示当前组已经执行的氢线程数。使用条件变量（$Condition$）并与锁（$Lock$）绑定，可实现更精准的线程唤醒。

氢线程执行的方法 $hydrogen$ 的操作如下。

1. 将锁对象加锁。
2. 当 $stage=2$ 时，对条件变量调用方法 $await$，直到 $stage\ne 2$。
3. 释放氢原子。
4. 将 $stage$ 的值增加 $1$。
5. 对条件变量调用方法 $signalAll$。
6. 将锁对象解锁。

氧线程执行的方法 $oxygen$ 的操作如下。

1. 将锁对象加锁。
2. 当 $stage=0$ 时，对条件变量调用方法 $await$，直到 $stage\ne 0$。
3. 释放氧原子。
4. 将 $stage$ 的值更新为 $0$。
5. 对条件变量调用方法 $signalAll$。
6. 将锁对象解锁。

上述操作可以确保所有线程的执行顺序是三个线程一组，每组的前两个线程都是氢线程且后一个线程是氧线程。

##### 代码

```Java
class H2O {
    private static final int HYDROGEN = 0, OXYGEN = 2;
    private int stage;
    private Lock lock;
    private Condition condition;

    public H2O() {
        this.stage = HYDROGEN;
        this.lock = new ReentrantLock();
        this.condition = lock.newCondition();
    }

    public void hydrogen(Runnable releaseHydrogen) throws InterruptedException {
        lock.lock();
        try {
            while (stage == OXYGEN) {
                condition.await();
            }
            releaseHydrogen.run();
            stage++;
            condition.signalAll();
        } finally {
            lock.unlock();
        }
    }

    public void oxygen(Runnable releaseOxygen) throws InterruptedException {
        lock.lock();
        try {
            while (stage != OXYGEN) {
                condition.await();
            }
            releaseOxygen.run();
            stage = HYDROGEN;
            condition.signalAll();
        } finally {
            lock.unlock();
        }
    }
}
```

```C++
class H2O {
private:
    static constexpr int HYDROGEN = 0, OXYGEN = 2;
    int stage;
    mutex mtx;
    condition_variable cv;

public:
    H2O() {
        this->stage = HYDROGEN;
    }

    void hydrogen(function<void()> releaseHydrogen) {
        unique_lock<mutex> lock(mtx);
        while (stage == OXYGEN) {
            cv.wait(lock);
        }
        releaseHydrogen();
        stage++;
        cv.notify_all();
    }

    void oxygen(function<void()> releaseOxygen) {
        unique_lock<mutex> lock(mtx);
        while (stage != OXYGEN) {
            cv.wait(lock);
        }
        releaseOxygen();
        stage = HYDROGEN;
        cv.notify_all();
    }
};
```

```Python
import threading

class H2O:
    HYDROGEN, OXYGEN = 0, 2

    def __init__(self):
        self.stage = self.HYDROGEN
        self.cond = threading.Condition()

    def hydrogen(self, releaseHydrogen: 'Callable[[], None]') -> None:
        with self.cond:
            while self.stage == self.OXYGEN:
                self.cond.wait()
            releaseHydrogen()
            self.stage += 1
            self.cond.notify_all()

    def oxygen(self, releaseOxygen: 'Callable[[], None]') -> None:
        with self.cond:
            while self.stage != self.OXYGEN:
                self.cond.wait()
            releaseOxygen()
            self.stage = self.HYDROGEN
            self.cond.notify_all()
```

```C
#include <stdatomic.h>

static const int HYDROGEN = 0, OXYGEN = 2;

typedef struct {
    int stage;
    pthread_mutex_t mutex;
    pthread_cond_t cond;
} H2O;

void releaseHydrogen();

void releaseOxygen();

H2O* h2oCreate() {
    H2O* obj = (H2O*) malloc(sizeof(H2O));
    obj->stage = HYDROGEN;
    pthread_mutex_init(&obj->mutex, NULL);
    pthread_cond_init(&obj->cond, NULL);
    return obj;
}

void hydrogen(H2O* obj) {
    pthread_mutex_lock(&obj->mutex);
    while (obj->stage == OXYGEN) {
        pthread_cond_wait(&obj->cond, &obj->mutex);
    }
    releaseHydrogen();
    obj->stage++;
    pthread_cond_broadcast(&obj->cond);
    pthread_mutex_unlock(&obj->mutex);
}

void oxygen(H2O* obj) {
    pthread_mutex_lock(&obj->mutex);
    while (obj->stage != OXYGEN) {
        pthread_cond_wait(&obj->cond, &obj->mutex);
    }
    releaseOxygen();
    obj->stage = HYDROGEN;
    pthread_cond_broadcast(&obj->cond);
    pthread_mutex_unlock(&obj->mutex);
}

void h2oFree(H2O* obj) {
    free(obj);
}
```

```Go
const (
    HYDROGEN = 0
    OXYGEN = 2
)

type H2O struct {
    stage  int
    mu     sync.Mutex
    cond   *sync.Cond
}

func NewH2O() *H2O {
    h := &H2O{stage: HYDROGEN}
    h.cond = sync.NewCond(&h.mu)
    return h
}

func (h *H2O) Hydrogen(releaseHydrogen func()) {
    h.mu.Lock()
    for h.stage == OXYGEN {
        h.cond.Wait()
    }
    releaseHydrogen()
    h.stage++
    h.cond.Broadcast()
    h.mu.Unlock()
}

func (h *H2O) Oxygen(releaseOxygen func()) {
    h.mu.Lock()
    for h.stage != OXYGEN {
        h.cond.Wait()
    }
    releaseOxygen()
    h.stage = HYDROGEN
    h.cond.Broadcast()
    h.mu.Unlock()
}
```

#### 解法三

##### 思路

使用信号量（$Semaphore$）可以控制当前允许执行的方法。方法 $hydrogen$ 和 $oxygen$ 各对应一个信号量，初始时方法 $hydrogen$ 对应的信号量有 $2$ 个许可，方法 $oxygen$ 对应的信号量有 $0$ 个许可。

氢线程执行的方法 $hydrogen$ 的操作如下。

1. 方法 $hydrogen$ 对应的信号量获取 $1$ 个许可，如果没有许可则被阻塞。
2. 释放氢原子。
3. 方法 $oxygen$ 对应的信号量释放 $1$ 个许可。

氧线程执行的方法 $oxygen$ 的操作如下。

1. 方法 $oxygen$ 对应的信号量获取 $2$ 个许可，如果没有许可则被阻塞。
2. 释放氧原子。
3. 方法 $hydrogen$ 对应的信号量释放 $1$ 个许可。

上述操作可以达到如下效果。

1. 确保所有线程的执行顺序是三个线程一组，每组的前两个线程都是氢线程且后一个线程是氧线程。由于初始时方法 $hydrogen$ 对应的信号量有 $2$ 个许可，方法 $oxygen$ 对应的信号量有 $0$ 个许可，每次执行方法 $oxygen$ 时对应的信号量获取 $2$ 个许可，因此一定是方法 $hydrogen$ 执行 $2$ 次，释放 $2$ 个许可之后才会执行方法 $oxygen$。
2. 每组的两个氢线程之间不存在依赖，因此可以并行执行。

##### 代码

```Java
class H2O {
    private static final int HYDROGEN_BOUND = 2, OXYGEN_BOUND = 1;
    private Semaphore semaphoreHydrogen;
    private Semaphore semaphoreOxygen;

    public H2O() {
        this.semaphoreHydrogen = new Semaphore(HYDROGEN_BOUND);
        this.semaphoreOxygen = new Semaphore(0);
    }

    public void hydrogen(Runnable releaseHydrogen) throws InterruptedException {
        semaphoreHydrogen.acquire(OXYGEN_BOUND);
        releaseHydrogen.run();
        semaphoreOxygen.release(OXYGEN_BOUND);
    }

    public void oxygen(Runnable releaseOxygen) throws InterruptedException {
        semaphoreOxygen.acquire(HYDROGEN_BOUND);
        releaseOxygen.run();
        semaphoreHydrogen.release(HYDROGEN_BOUND);
    }
}
```

```CSharp
using System.Threading;

public class H2O {
    private const int HYDROGEN_BOUND = 2, OXYGEN_BOUND = 1;
    private SemaphoreSlim semaphoreHydrogen;
    private SemaphoreSlim semaphoreOxygen;

    public H2O() {
        this.semaphoreHydrogen = new SemaphoreSlim(HYDROGEN_BOUND, HYDROGEN_BOUND);
        this.semaphoreOxygen = new SemaphoreSlim(0, HYDROGEN_BOUND);
    }

    public void Hydrogen(Action releaseHydrogen) {
        semaphoreHydrogen.Wait();
        releaseHydrogen();
        if (semaphoreHydrogen.CurrentCount == 0) {
            semaphoreOxygen.Release(OXYGEN_BOUND);
        }
    }

    public void Oxygen(Action releaseOxygen) {
        semaphoreOxygen.Wait();
        releaseOxygen();
        semaphoreHydrogen.Release(HYDROGEN_BOUND);
    }
}
```

```C++
class H2O {
private:
    static constexpr int HYDROGEN_BOUND = 2, OXYGEN_BOUND = 1;
    int stage;
    counting_semaphore<HYDROGEN_BOUND> semaphoreHydrogen{HYDROGEN_BOUND};
    counting_semaphore<HYDROGEN_BOUND> semaphoreOxygen{0};

public:
    H2O() {
        this->stage = 0;
    }

    void hydrogen(function<void()> releaseHydrogen) {
        semaphoreHydrogen.acquire();
        releaseHydrogen();
        stage++;
        if (stage == HYDROGEN_BOUND) {
            semaphoreOxygen.release(OXYGEN_BOUND);
            stage = 0;
        }
    }

    void oxygen(function<void()> releaseOxygen) {
        semaphoreOxygen.acquire();
        releaseOxygen();
        semaphoreHydrogen.release(HYDROGEN_BOUND);
    }
};
```

```Python
import threading

class H2O:
    HYDROGEN_BOUND, OXYGEN_BOUND = 2, 1

    def __init__(self):
        self.semaphoreHydrogen = threading.Semaphore(self.HYDROGEN_BOUND)
        self.semaphoreOxygen = threading.Semaphore(0)
        self.stage = 0

    def hydrogen(self, releaseHydrogen: 'Callable[[], None]') -> None:
        self.semaphoreHydrogen.acquire()
        releaseHydrogen()
        self.stage += 1
        if self.stage == self.HYDROGEN_BOUND:
            self.semaphoreOxygen.release(self.OXYGEN_BOUND)
            self.stage = 0

    def oxygen(self, releaseOxygen: 'Callable[[], None]') -> None:
        self.semaphoreOxygen.acquire()
        releaseOxygen()
        self.semaphoreHydrogen.release(self.HYDROGEN_BOUND)
```

```C
const int HYDROGEN_BOUND = 2, OXYGEN_BOUND = 1;

typedef struct {
    sem_t semaphoreHydrogen;
    sem_t semaphoreOxygen;
    int stage;
} H2O;

void releaseHydrogen();

void releaseOxygen();

H2O* h2oCreate() {
    H2O* obj = (H2O*) malloc(sizeof(H2O));
    sem_init(&obj->semaphoreHydrogen, 0, HYDROGEN_BOUND);
    sem_init(&obj->semaphoreOxygen, 0, 0);
    obj->stage = 0;
    return obj;
}

void hydrogen(H2O* obj) {
    sem_wait(&obj->semaphoreHydrogen);
    releaseHydrogen();
    obj->stage++;
    if (obj->stage == HYDROGEN_BOUND) {
        sem_post(&obj->semaphoreOxygen);
        obj->stage = 0;
    }
}

void oxygen(H2O* obj) {
    sem_wait(&obj->semaphoreOxygen);
    releaseOxygen();
    for (int i = 0; i < HYDROGEN_BOUND; i++) {
        sem_post(&obj->semaphoreHydrogen);
    }
}

void h2oFree(H2O* obj) {
    sem_destroy(&obj->semaphoreHydrogen);
    sem_destroy(&obj->semaphoreOxygen);
    free(obj);
}
```

```Go
const (
    HYDROGEN_BOUND = 2
    OXYGEN_BOUND = 1
)

type H2O struct {
    semaphoreHydrogen chan struct{}
    semaphoreOxygen   chan struct{}
    stage             int
}

func NewH2O() *H2O {
    h := &H2O{
        semaphoreHydrogen: make(chan struct{}, 2),
        semaphoreOxygen:   make(chan struct{}, 1),
        stage:             0,
    }
    for i := 0; i < HYDROGEN_BOUND; i++ {
        h.semaphoreHydrogen <- struct{}{}
    }
    return h
}

func (h *H2O) Hydrogen(releaseHydrogen func()) {
    <-h.semaphoreHydrogen
    releaseHydrogen()
    h.stage++
    if h.stage == HYDROGEN_BOUND {
        h.semaphoreOxygen <- struct{}{}
        h.stage = 0
    }
}

func (h *H2O) Oxygen(releaseOxygen func()) {
    <-h.semaphoreOxygen
    releaseOxygen()
    for i := 0; i < HYDROGEN_BOUND; i++ {
        h.semaphoreHydrogen <- struct{}{}
    }
}
```

#### 解法四

##### 思路

使用两个信号量（$Semaphore$）和一个循环屏障（$CyclicBarrier$）可以控制氢线程和氧线程的执行顺序，确保所有线程的执行顺序是三个线程一组，每组包含两个氢线程和一个氧线程。信号量和循环屏障的初始化如下。

- 方法 $hydrogen$ 和 $oxygen$ 各对应一个信号量，初始时方法 $hydrogen$ 对应的信号量有 $2$ 个许可，方法 $oxygen$ 对应的信号量有 $1$ 个许可，分别对应水分子中的 $2$ 个氢原子和 $1$ 个氧原子。
- 循环屏障的参与线程的个数是 $3$。

氢线程执行的方法 $hydrogen$ 的操作如下。

1. 方法 $hydrogen$ 对应的信号量获取 $1$ 个许可，如果没有许可则被阻塞。
2. 释放氢原子。
3. 对循环屏障调用方法 $await$ 表示到达屏障。
4. 方法 $hydrogen$ 对应的信号量释放 $1$ 个许可。

氧线程执行的方法 $oxygen$ 的操作如下。

1. 方法 $oxygen$ 对应的信号量获取 $1$ 个许可，如果没有许可则被阻塞。
2. 释放氧原子。
3. 对循环屏障调用方法 $await$ 表示到达屏障。
4. 方法 $oxygen$ 对应的信号量释放 $1$ 个许可。

上述操作可以达到如下效果。

1. 由于循环屏障的参与线程的个数是 $3$，因此可以确保所有线程的执行顺序是三个线程一组。
2. 两个信号量限制了每组的三个线程是两个氢线程和一个氧线程。
3. 每组的三个线程之间不存在依赖，因此可以并行执行。在确保每组的三个线程是两个氢线程和一个氧线程的情况下，每组的三个线程的执行顺序可以是任意的。和只使用信号量相比，使用信号量和循环屏障可以支持组内的更高并发。

##### 代码

```Java
class H2O {
    private static final int HYDROGEN_BOUND = 2, OXYGEN_BOUND = 1, TOTAL_BOUND = 3;
    private Semaphore semaphoreHydrogen;
    private Semaphore semaphoreOxygen;
    private CyclicBarrier cyclicBarrier;

    public H2O() {
        this.semaphoreHydrogen = new Semaphore(HYDROGEN_BOUND);
        this.semaphoreOxygen = new Semaphore(OXYGEN_BOUND);
        this.cyclicBarrier = new CyclicBarrier(TOTAL_BOUND);
    }

    public void hydrogen(Runnable releaseHydrogen) throws InterruptedException {
        semaphoreHydrogen.acquire();
        releaseHydrogen.run();
        try {
            cyclicBarrier.await();
        } catch (BrokenBarrierException e) {
            Thread.currentThread().interrupt();
        }
        semaphoreHydrogen.release();
    }

    public void oxygen(Runnable releaseOxygen) throws InterruptedException {
        semaphoreOxygen.acquire();
        releaseOxygen.run();
        try {
            cyclicBarrier.await();
        } catch (BrokenBarrierException e) {
            Thread.currentThread().interrupt();
        }
        semaphoreOxygen.release();
    }
}
```

#### 解法五

##### 思路

使用阻塞队列（$BlockingQueue$）和原子类 $AtomicInteger$ 可以控制当前允许执行的方法。需要维护如下信息。

- 两个阻塞队列，分别为 $hydrogen$ 队列和 $oxygen$ 队列，其中 $hydrogen$ 队列的容量是 $2$，oxygen 队列的容量是 $1$。
- 原子类变量 $stage$，表示当前组已经执行的线程数，初始时 $stage=0$。

氢线程执行的方法 $hydrogen$ 的操作如下。

1. 将一个元素添加到队列 $hydrogen$。
2. 释放氢原子。
3. 将 $stage$ 的值增加 $1$。更新 $stage$ 之后，如果 $stage=3$，则产生一个完整水分子，将 $stage$ 的值更新为 $0$，将两个队列清空。

氧线程执行的方法 $oxygen$ 的操作如下。

1. 将一个元素添加到队列 $oxygen$。
2. 释放氧原子。
3. 将 $stage$ 的值增加 $1$。更新 $stage$ 之后，如果 $stage=3$，则产生一个完整水分子，将 $stage$ 的值更新为 $0$，将两个队列清空。

上述操作可以达到如下效果。

1. 由于每次调用方法 $hydrogen$ 或方法 $oxygen$ 时都会将 $stage$ 的值增加 $1$，因此当 $stage$ 的值变成 $3$ 时将 $stage$ 的值更新为 $0$ 并将两个队列清空，可以确保所有线程的执行顺序是三个线程一组。
2. 两个阻塞队列限制了每组的三个线程是两个氢线程和一个氧线程。
3. 和使用循环屏障相似，使用阻塞队列时，每组的三个线程之间不存在依赖，因此可以并行执行，且每组的三个线程的执行顺序可以是任意的。

##### 代码

```Java
class H2O {
    private static final int HYDROGEN_BOUND = 2, OXYGEN_BOUND = 1, TOTAL_BOUND = 3;
    private AtomicInteger stage;
    private BlockingQueue<Integer> blockingQueueHydrogen;
    private BlockingQueue<Integer> blockingQueueOxygen;

    public H2O() {
        this.stage = new AtomicInteger(0);
        this.blockingQueueHydrogen = new ArrayBlockingQueue<Integer>(HYDROGEN_BOUND);
        this.blockingQueueOxygen = new ArrayBlockingQueue<Integer>(OXYGEN_BOUND);
    }

    public void hydrogen(Runnable releaseHydrogen) throws InterruptedException {
        blockingQueueHydrogen.put(1);
        releaseHydrogen.run();
        if (stage.incrementAndGet() == TOTAL_BOUND) {
            reset();
        }
    }

    public void oxygen(Runnable releaseOxygen) throws InterruptedException {
        blockingQueueOxygen.put(1);
        releaseOxygen.run();
        if (stage.incrementAndGet() == TOTAL_BOUND) {
            reset();
        }
    }

    private void reset() throws InterruptedException {
        stage.set(0);
        for (int i = 0; i < HYDROGEN_BOUND; i++) {
            blockingQueueHydrogen.take();
        }
        for (int i = 0; i < OXYGEN_BOUND; i++) {
            blockingQueueOxygen.take();
        }
    }
}
```

```CSharp
using System.Collections.Concurrent;
using System.Threading;

public class H2O {
    private const int HYDROGEN_BOUND = 2, OXYGEN_BOUND = 1, TOTAL_BOUND = 3;
    private int stage;
    private BlockingCollection<int> blockingQueueHydrogen;
    private BlockingCollection<int> blockingQueueOxygen;

    public H2O() {
        this.stage = 0;
        this.blockingQueueHydrogen = new BlockingCollection<int>(2);
        this.blockingQueueOxygen = new BlockingCollection<int>(1);
    }

    public void Hydrogen(Action releaseHydrogen) {
        blockingQueueHydrogen.Add(1);
        releaseHydrogen();
        if (Interlocked.Increment(ref stage) == TOTAL_BOUND) {
            Reset();
        }
    }

    public void Oxygen(Action releaseOxygen) {
        blockingQueueOxygen.Add(1);
        releaseOxygen();
        if (Interlocked.Increment(ref stage) == TOTAL_BOUND) {
            Reset();
        }
    }

    private void Reset() {
        Interlocked.Exchange(ref stage, 0);
        for (int i = 0; i < HYDROGEN_BOUND; i++) {
            blockingQueueHydrogen.Take();
        }
        for (int i = 0; i < OXYGEN_BOUND; i++) {
            blockingQueueOxygen.Take();
        }
    }
}
```

```Python
import queue
import threading

class H2O:
    HYDROGEN_BOUND, OXYGEN_BOUND, TOTAL_BOUND = 2, 1, 3

    def __init__(self):
        self.stage = 0
        self.lock = threading.Lock()
        self.blockingQueueHydrogen = queue.Queue(maxsize=self.HYDROGEN_BOUND)
        self.blockingQueueOxygen = queue.Queue(maxsize=self.OXYGEN_BOUND)

    def hydrogen(self, releaseHydrogen: 'Callable[[], None]') -> None:
        self.blockingQueueHydrogen.put(1)
        releaseHydrogen()
        with self.lock:
            self.stage += 1
            if self.stage == self.TOTAL_BOUND:
                self._reset()

    def oxygen(self, releaseOxygen: 'Callable[[], None]') -> None:
        self.blockingQueueOxygen.put(1)
        releaseOxygen()
        with self.lock:
            self.stage += 1
            if self.stage == self.TOTAL_BOUND:
                self._reset()

    def _reset(self) -> None:
        self.stage = 0
        for _ in range(self.HYDROGEN_BOUND):
            self.blockingQueueHydrogen.get()
        for _ in range(self.OXYGEN_BOUND):
            self.blockingQueueOxygen.get()
```
