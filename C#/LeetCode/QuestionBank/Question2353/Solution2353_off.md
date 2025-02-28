### [设计食物评分系统](https://leetcode.cn/problems/design-a-food-rating-system/solutions/3078910/she-ji-shi-wu-ping-fen-xi-tong-by-leetco-vk42/)

#### 方法一：平衡树

**思路**

题目要求我们实现一种数据结构，能够做到：

1. 维护每个食物名称对应的食物评分和烹饪方式
2. 查询烹饪方式对应的评分最高的食物名称

对于维护食物名称与评分、烹饪方式之间的对应关系，我们可以使用一个哈希表 $foodMap$ 维护。对于烹饪方式与评分最高的食物之间的对应关系，我们可以使用另一个哈希表 $ratingMap$ 嵌套一种支持自动排序的数据结构，如平衡树来实现。

**代码**

```Java
class FoodRatings {
    private Map<String, Pair<Integer, String>> foodMap;
    private Map<String, TreeSet<Pair<Integer, String>>> ratingMap;
    private int n;

    public FoodRatings(String[] foods, String[] cuisines, int[] ratings) {
        n = foods.length;
        foodMap = new HashMap<>();
        ratingMap = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String food = foods[i];
            String cuisine = cuisines[i];
            int rating = ratings[i];
            foodMap.put(food, new Pair<>(rating, cuisine));
            ratingMap.computeIfAbsent(cuisine, k -> new TreeSet<>((a, b) -> {
                if (!a.getKey().equals(b.getKey())) {
                    return a.getKey() - b.getKey();
                }
                return a.getValue().compareTo(b.getValue());
            })).add(new Pair<>(n - rating, food));
        }
    }
    
    public void changeRating(String food, int newRating) {
        Pair<Integer, String> pair = foodMap.get(food);
        int oldRating = pair.getKey();
        String cuisine = pair.getValue();
        ratingMap.get(cuisine).remove(new Pair<>(n - oldRating, food));
        ratingMap.get(cuisine).add(new Pair<>(n - newRating, food));
        foodMap.put(food, new Pair<>(newRating, cuisine));
    }
    
    public String highestRated(String cuisine) {
        return ratingMap.get(cuisine).first().getValue();
    }
}
```

```CSharp
public class FoodRatings {
    private Dictionary<string, Tuple<int, string>> foodMap;
    private Dictionary<string, SortedSet<Tuple<int, string>>> ratingMap;
    private int n;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings) {
        n = foods.Length;
        foodMap = new Dictionary<string, Tuple<int, string>>();
        ratingMap = new Dictionary<string, SortedSet<Tuple<int, string>>>();

        for (int i = 0; i < n; i++) {
            string food = foods[i];
            string cuisine = cuisines[i];
            int rating = ratings[i];
            foodMap[food] = Tuple.Create(rating, cuisine);
            if (!ratingMap.ContainsKey(cuisine)) {
                ratingMap[cuisine] = new SortedSet<Tuple<int, string>>(Comparer<Tuple<int, string>>.Create((a, b) => {
                    if (a.Item1 != b.Item1) {
                        return a.Item1.CompareTo(b.Item1);
                    }
                    return a.Item2.CompareTo(b.Item2);
                }));
            }
            ratingMap[cuisine].Add(Tuple.Create(n - rating, food));
        }
    }
    
    public void ChangeRating(string food, int newRating) {
        var pair = foodMap[food];
        int oldRating = pair.Item1;
        string cuisine = pair.Item2;
        ratingMap[cuisine].Remove(Tuple.Create(n - oldRating, food));
        ratingMap[cuisine].Add(Tuple.Create(n - newRating, food));
        foodMap[food] = Tuple.Create(newRating, cuisine);
    }
    
    public string HighestRated(string cuisine) {
        return ratingMap[cuisine].Min.Item2;
    }
}
```

```C++
class FoodRatings {
    unordered_map<string, pair<int, string>> foodMap;
    unordered_map<string, set<pair<int, string>>> ratingMap;
    int n;

public:
    FoodRatings(vector<string>& foods, vector<string>& cuisines, vector<int>& ratings) {
        n = foods.size();
        for (int i = 0; i < n; ++i) {
            auto &food = foods[i], &cuisine = cuisines[i];
            int rating = ratings[i];
            foodMap[food] = {rating, cuisine};
            ratingMap[cuisine].emplace(n - rating, food);
        }
    }

    void changeRating(string food, int newRating) {
        auto& [rating, cuisine] = foodMap[food];
        auto& s = ratingMap[cuisine];
        s.erase({n - rating, food});
        s.emplace(n - newRating, food);
        rating = newRating;
    }

    string highestRated(string cuisine) { 
        return ratingMap[cuisine].begin()->second; 
    }
};
```

```Python
class FoodRatings:
    def __init__(self, foods: List[str], cuisines: List[str], ratings: List[int]):
        self.foodMap = {}
        self.ratingMap = defaultdict(SortedList)
        self.n = len(foods)
        for i in range(self.n):
            food = foods[i]
            cuisine = cuisines[i]
            rating = ratings[i]
            self.foodMap[food] = (rating, cuisine)
            self.ratingMap[cuisine].add((self.n - rating, food))

    def changeRating(self, food: str, newRating: int) -> None:
        oldRating, cuisine = self.foodMap[food]
        self.ratingMap[cuisine].remove((self.n - oldRating, food))
        self.foodMap[food] = (newRating, cuisine)
        self.ratingMap[cuisine].add((self.n - newRating, food))

    def highestRated(self, cuisine: str) -> str:
        return self.ratingMap[cuisine][0][1]
```

```Rust
use std::collections::{HashMap, BTreeSet};

struct FoodRatings {
    food_map: HashMap<String, (i32, String)>,
    rating_map: HashMap<String, BTreeSet<(i32, String)>>,
    n: usize,
}

impl FoodRatings {

    fn new(foods: Vec<String>, cuisines: Vec<String>, ratings: Vec<i32>) -> Self {
        let n = foods.len();
        let mut food_map = HashMap::new();
        let mut rating_map = HashMap::new();

        for i in 0..n {
            let food = foods[i].clone();
            let cuisine = cuisines[i].clone();
            let rating = ratings[i];
            food_map.insert(food.clone(), (rating, cuisine.clone()));
            rating_map
                .entry(cuisine)
                .or_insert_with(BTreeSet::new)
                .insert((n as i32 - rating, food));
        }

        Self {
            food_map,
            rating_map,
            n,
        }
    }
    
    fn change_rating(&mut self, food: String, new_rating: i32) {
        if let Some((old_rating, cuisine)) = self.food_map.get(&food) {
            let old_rating = *old_rating;
            let cuisine = cuisine.clone();
            self.rating_map
                .get_mut(&cuisine)
                .unwrap()
                .remove(&(self.n as i32 - old_rating, food.clone()));
            self.rating_map
                .get_mut(&cuisine)
                .unwrap()
                .insert((self.n as i32 - new_rating, food.clone()));
            self.food_map.insert(food, (new_rating, cuisine));
        }
    }
    
    fn highest_rated(&self, cuisine: String) -> String {
        self.rating_map
            .get(&cuisine)
            .and_then(|set| set.iter().next())
            .map(|(_, food)| food.clone())
            .unwrap()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+m\log n)$，其中 $m$ 是 `changeRating` 的调用次数。初始化需要 $O(n\log n)$，每次插入平衡树需要 $O(\log n)$。
- 空间复杂度：$O(n)$，两个哈希表都需要 $O(n)$。

#### 方法二：懒删除堆

**思路**

支持自动排序的数据结构还有优先队列（堆）。与平衡树不同，堆不支持快速的随机删除与修改操作，因此为了维护堆顶数据的有效性，可以采用懒删除的方法，将维护操作推迟到查询时才进行。具体来说，对于两种操作：

- 对于 `changeRating` 操作，直接将记录添加到堆中，而不删除其过期的值；
- 对于 `highestRated` 操作，查看堆顶的食物评分与其实际值是否一致，如果不一致说明对应的元素值已经过期，直接弹出，否则堆顶就是答案。

**代码**

```Java
class FoodRatings {
    private Map<String, Pair<Integer, String>> foodMap;
    private Map<String, PriorityQueue<Pair<Integer, String>>> ratingMap;
    private int n;

    public FoodRatings(String[] foods, String[] cuisines, int[] ratings) {
        n = foods.length;
        foodMap = new HashMap<>();
        ratingMap = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String food = foods[i];
            String cuisine = cuisines[i];
            int rating = ratings[i];
            foodMap.put(food, new Pair<>(rating, cuisine));
            ratingMap.computeIfAbsent(cuisine, k -> new PriorityQueue<>((a, b) -> {
                if (!a.getKey().equals(b.getKey())) {
                    return a.getKey() - b.getKey();
                }
                return a.getValue().compareTo(b.getValue());
            })).add(new Pair<>(n - rating, food));
        }
    }
    
    public void changeRating(String food, int newRating) {
        Pair<Integer, String> pair = foodMap.get(food);
        String cuisine = pair.getValue();
        ratingMap.get(cuisine).add(new Pair<>(n - newRating, food));
        foodMap.put(food, new Pair<>(newRating, cuisine));
    }
    
    public String highestRated(String cuisine) {
        PriorityQueue<Pair<Integer, String>> q = ratingMap.get(cuisine);
        while (!q.isEmpty()) {
            Pair<Integer, String> top = q.peek();
            String food = top.getValue();
            if (n - top.getKey() == foodMap.get(food).getKey()) {
                return food;
            }
            q.poll();
        }
        return "";
    }
}
```

```CSharp
public class FoodRatings {
    private Dictionary<string, (int Rating, string Cuisine)> foodMap;
    private Dictionary<string, PriorityQueue<(string Food, int Rating), (int Rating, string Food)>> ratingMap;
    private int n;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings) {
        n = foods.Length;
        foodMap = new Dictionary<string, (int Rating, string Cuisine)>();
        ratingMap = new Dictionary<string, PriorityQueue<(string Food, int Rating), (int Rating, string Food)>>();

        for (int i = 0; i < n; i++) {
            string food = foods[i];
            string cuisine = cuisines[i];
            int rating = ratings[i];
            foodMap[food] = (rating, cuisine);
            if (!ratingMap.ContainsKey(cuisine)) {
                ratingMap[cuisine] = new PriorityQueue<(string Food, int Rating), (int Rating, string Food)>(
                    Comparer<(int Rating, string Food)>.Create((a, b) => {
                        if (a.Rating != b.Rating) {
                            return b.Rating.CompareTo(a.Rating);
                        }
                        return a.Food.CompareTo(b.Food);
                    })
                );
            }
            ratingMap[cuisine].Enqueue((food, rating), (rating, food));
        }
    }
    
    public void ChangeRating(string food, int newRating) {
        var (oldRating, cuisine) = foodMap[food];
        ratingMap[cuisine].Enqueue((food, newRating), (newRating, food));
        foodMap[food] = (newRating, cuisine);
    }
    
    public string HighestRated(string cuisine) {
        var q = ratingMap[cuisine];
        while (q.Count > 0) {
            var top = q.Peek();
            string food = top.Food;
            int rating = top.Rating;
            if (foodMap[food].Rating == rating) {
                return food;
            }
            q.Dequeue();
        }

        return "";
    }
}
```

```C++
class FoodRatings {
    unordered_map<string, pair<int, string>> foodMap;
    unordered_map<string, priority_queue<pair<int, string>, vector<pair<int, string>>, greater<>>> ratingMap;
    int n;

public:
    FoodRatings(vector<string>& foods, vector<string>& cuisines,
                vector<int>& ratings) {
        n = foods.size();
        for (int i = 0; i < n; ++i) {
            auto &food = foods[i], &cuisine = cuisines[i];
            int rating = ratings[i];
            foodMap[food] = {rating, cuisine};
            ratingMap[cuisine].emplace(n - rating, food);
        }
    }

    void changeRating(string food, int newRating) {
        auto& [rating, cuisine] = foodMap[food];
        ratingMap[cuisine].emplace(n - newRating, food);
        rating = newRating;
    }

    string highestRated(string cuisine) {
        auto& q = ratingMap[cuisine];
        auto& [rating, food] = q.top();
        while (n - rating != foodMap[food].first) {
            q.pop();
        }
        return q.top().second;
    }
};
```

```Go
type FoodRatings struct {
    foodMap   map[string]struct {
        rating  int
        cuisine string
    }
    ratingMap map[string]*PriorityQueue
    n         int
}

func Constructor(foods []string, cuisines []string, ratings []int) FoodRatings {
    n := len(foods)
    foodMap := make(map[string]struct {
        rating  int
        cuisine string
    })
    ratingMap := make(map[string]*PriorityQueue)

    for i := 0; i < n; i++ {
        food := foods[i]
        cuisine := cuisines[i]
        rating := ratings[i]
        foodMap[food] = struct {
            rating  int
            cuisine string
        } {rating, cuisine}
        if ratingMap[cuisine] == nil {
            ratingMap[cuisine] = &PriorityQueue{}
        }
        heap.Push(ratingMap[cuisine], Pair{n - rating, food})
    }

    return FoodRatings{
        foodMap:   foodMap,
        ratingMap: ratingMap,
        n:         n,
    }
}

func (this *FoodRatings) ChangeRating(food string, newRating int)  {
    entry := this.foodMap[food]
    cuisine := entry.cuisine
    heap.Push(this.ratingMap[cuisine], Pair{this.n - newRating, food})
    entry.rating = newRating
    this.foodMap[food] = entry
}

func (this *FoodRatings) HighestRated(cuisine string) string {
    pq := this.ratingMap[cuisine]
    for pq.Len() > 0 {
        top := (*pq)[0]
        if this.n-top.rating == this.foodMap[top.food].rating {
            return top.food
        }
        heap.Pop(pq)
    }
    return ""
}

type Pair struct {
    rating int
    food   string
}

type PriorityQueue []Pair

func (pq PriorityQueue) Len() int { 
    return len(pq) 
}

func (pq PriorityQueue) Less(i, j int) bool {
     if pq[i].rating == pq[j].rating {
        return pq[i].food < pq[j].food
     }
     return pq[i].rating < pq[j].rating
}

func (pq PriorityQueue) Swap(i, j int) {
    pq[i], pq[j] = pq[j], pq[i]
}

func (pq *PriorityQueue) Push(x interface{}) {
    *pq = append(*pq, x.(Pair))
}

func (pq *PriorityQueue) Pop() interface{} {
    old := *pq
    n := len(old)
    item := old[n - 1]
    *pq = old[0 : n - 1]
    return item
}
```

```Python
class FoodRatings:
    def __init__(self, foods: List[str], cuisines: List[str], ratings: List[int]):
        self.food_map = {}
        self.rating_map = {}
        self.n = len(foods)

        for i in range(self.n):
            food = foods[i]
            cuisine = cuisines[i]
            rating = ratings[i]
            self.food_map[food] = (rating, cuisine)
            if cuisine not in self.rating_map:
                self.rating_map[cuisine] = []
            heapq.heappush(self.rating_map[cuisine], (self.n - rating, food))

    def changeRating(self, food: str, newRating: int) -> None:
        rating, cuisine = self.food_map[food]
        heapq.heappush(self.rating_map[cuisine], (self.n - newRating, food))
        self.food_map[food] = (newRating, cuisine)

    def highestRated(self, cuisine: str) -> str:
        while self.rating_map[cuisine]:
            rating, food = self.rating_map[cuisine][0]
            if self.n - rating == self.food_map[food][0]:
                return food
            heapq.heappop(self.rating_map[cuisine])
        return ""
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int ratings;
    char *value;
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

Element *createElement(int ratings, char *value) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->ratings = ratings;
    obj->value = value;
    return obj;
}

static bool less(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    if (e1->ratings == e2->ratings) {
        return strcmp(e1->value, e2->value) > 0;
    }
    return e1->ratings > e2->ratings;
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
    // we need to alloc more space, just twice space size
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

typedef struct {
    char *key;
    Element val;
    UT_hash_handle hh;
} HashFoodItem; 

HashFoodItem *hashFindFoodItem(HashFoodItem **obj, char* key) {
    HashFoodItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddFoodItem(HashFoodItem **obj, char* key, int rating, char *cuisine) {
    if (hashFindFoodItem(obj, key)) {
        return false;
    }
    HashFoodItem *pEntry = (HashFoodItem *)malloc(sizeof(HashFoodItem));
    pEntry->key = key;
    pEntry->val.ratings = rating;
    pEntry->val.value = cuisine;
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

bool hashSetFoodItem(HashFoodItem **obj, char* key, Element val) {
    HashFoodItem *pEntry = hashFindFoodItem(obj, key);
    if (!pEntry) {
        hashAddFoodItem(obj, key, val.ratings, val.value);
    } else {
        pEntry->val = val;
    }
    return true;
}

Element hashGetFoodItem(HashFoodItem **obj, char* key) {
    HashFoodItem *pEntry = hashFindFoodItem(obj, key);
    return pEntry->val;
}

void hashFoodFree(HashFoodItem **obj) {
    HashFoodItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

typedef struct {
    char *key;
    PriorityQueue *val;
    UT_hash_handle hh;
} HashRatingItem; 

HashRatingItem *hashFindRatingItem(HashRatingItem **obj, char* key) {
    HashRatingItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddRatingItem(HashRatingItem **obj, char* key, int rating, char *food) {
    HashRatingItem *pEntry = hashFindRatingItem(obj, key);
    if (!pEntry) {
        pEntry = (HashRatingItem *)malloc(sizeof(HashRatingItem));
        pEntry->key = key;
        pEntry->val = createPriorityQueue(less);
        HASH_ADD_STR(*obj, key, pEntry);
    }
    Element e = {rating, food};
    enQueue(pEntry->val, &e);
    return true;
}

PriorityQueue* hashGetRatingItem(HashRatingItem **obj, char* key) {
    HashRatingItem *pEntry = hashFindRatingItem(obj, key);
    return pEntry->val;
}

void hashRatingFree(HashRatingItem **obj) {
    HashRatingItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        freeQueue(curr->val);
        free(curr);
    }
}

typedef struct {
    HashFoodItem *foodMap;
    HashRatingItem *ratingMap;
    int n;
} FoodRatings;

FoodRatings* foodRatingsCreate(char** foods, int foodsSize, char** cuisines, int cuisinesSize, int* ratings, int ratingsSize) {
    FoodRatings *obj = (FoodRatings *)malloc(sizeof(FoodRatings));
    obj->n = foodsSize;
    obj->foodMap = NULL;
    obj->ratingMap = NULL;
    Element e;
    for (int i = 0; i < foodsSize; ++i) {
        char *food = foods[i], *cuisine = cuisines[i];
        int rating = ratings[i];
        hashAddFoodItem(&obj->foodMap, food, rating, cuisine);
        hashAddRatingItem(&obj->ratingMap, cuisine, obj->n - rating, food);
    }
    return obj;
}

void foodRatingsChangeRating(FoodRatings* obj, char* food, int newRating) {
    Element e = hashGetFoodItem(&obj->foodMap, food);
    int rating = e.ratings;
    char *cuisine = e.value;
    hashAddRatingItem(&obj->ratingMap, cuisine, obj->n - newRating, food);
    e.ratings = newRating;
    hashSetFoodItem(&obj->foodMap, food, e);
}

char* foodRatingsHighestRated(FoodRatings* obj, char* cuisine) {
    PriorityQueue *q = hashGetRatingItem(&obj->ratingMap, cuisine);
    while (!isEmpty(q)) {
        int rating = front(q)->ratings;
        char *food = front(q)->value;
        if (obj->n - rating == hashGetFoodItem(&obj->foodMap, food).ratings) {
            return food;
        }
        deQueue(q);
    }
    return "";
}

void foodRatingsFree(FoodRatings* obj) {
    hashFoodFree(&obj->foodMap);
    hashRatingFree(&obj->ratingMap);
    free(obj);
}
```

```JavaScript
var FoodRatings = function(foods, cuisines, ratings) {
    this.foodMap = new Map();
    this.ratingMap = new Map();
    this.n = foods.length;

    for (let i = 0; i < this.n; i++) {
        const food = foods[i];
        const cuisine = cuisines[i];
        const rating = ratings[i];
        this.foodMap.set(food, {rating, cuisine});
        if (!this.ratingMap.has(cuisine)) {
            this.ratingMap.set(cuisine, new PriorityQueue({
            compare: (e1, e2) => {
                if (e1[0] === e2[0]) {
                    return e1[1] > e2[1] ? 1 : -1;
                }
                return e1[0] > e2[0] ? 1 : -1;
            }}));
        }
        this.ratingMap.get(cuisine).enqueue([this.n - rating, food]);
    }
};

FoodRatings.prototype.changeRating = function(food, newRating) {
    const { cuisine } = this.foodMap.get(food);
    this.ratingMap.get(cuisine).enqueue([this.n - newRating, food]);
    this.foodMap.set(food, {rating: newRating, cuisine});
};

FoodRatings.prototype.highestRated = function(cuisine) {
    const heap = this.ratingMap.get(cuisine);
    while (!heap.isEmpty()) {
        const [rating, food] = heap.front();
        if (this.n - rating === this.foodMap.get(food).rating) {
            return food;
        }
        heap.dequeue();
    }
    return "";
};
```

```TypeScript
type FoodInfo = {
    rating: number;
    cuisine: string;
};

class FoodRatings {
    private foodMap: Map<string, FoodInfo>;
    private ratingMap;
    private n: number;

    constructor(foods: string[], cuisines: string[], ratings: number[]) {
        this.foodMap = new Map<string, FoodInfo>();
        this.ratingMap = new Map();
        this.n = foods.length;

        for (let i = 0; i < this.n; i++) {
            const food = foods[i];
            const cuisine = cuisines[i];
            const rating = ratings[i];
            this.foodMap.set(food, { rating, cuisine });

            if (!this.ratingMap.has(cuisine)) {
                this.ratingMap.set(cuisine, new PriorityQueue({
                    compare: (e1, e2) => {
                        if (e1[0] === e2[0]) {
                            return e1[1] > e2[1] ? 1 : -1;
                        }
                        return e1[0] > e2[0] ? 1 : -1;
                    }
                }));
            }
            this.ratingMap.get(cuisine)!.enqueue([this.n - rating, food]);
        }
    }

    changeRating(food: string, newRating: number): void {
        const { cuisine } = this.foodMap.get(food)!;
        this.ratingMap.get(cuisine)!.enqueue([this.n - newRating, food]);
        this.foodMap.set(food, { rating: newRating, cuisine });
    }

    highestRated(cuisine: string): string {
        const heap = this.ratingMap.get(cuisine)!;
        while (!heap.isEmpty()) {
            const [rating, food] = heap.front()!;
            if (this.n - rating === this.foodMap.get(food)!.rating) {
                return food;
            }
            heap.dequeue();
        }
        return "";
    }
}
```

```Rust
use std::collections::{BinaryHeap, HashMap};
use std::cmp::Ordering;

#[derive(Debug, Eq, PartialEq)]
struct Pair(i32, String);

impl PartialOrd for Pair {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

impl Ord for Pair {
    fn cmp(&self, other: &Self) -> Ordering {
        other.0.cmp(&self.0).then_with(|| other.1.cmp(&self.1))
    }
}

#[derive(Debug)]
struct FoodRatings {
    food_map: HashMap<String, (i32, String)>,
    rating_map: HashMap<String, BinaryHeap<Pair>>,
    n: i32,
}

impl FoodRatings {
    fn new(foods: Vec<String>, cuisines: Vec<String>, ratings: Vec<i32>) -> Self {
        let n = foods.len() as i32;
        let mut food_map = HashMap::new();
        let mut rating_map = HashMap::new();

        for i in 0..foods.len() {
            let food = foods[i].clone();
            let cuisine = cuisines[i].clone();
            let rating = ratings[i];
            food_map.insert(food.clone(), (rating, cuisine.clone()));
            rating_map
                .entry(cuisine.clone())
                .or_insert_with(BinaryHeap::new)
                .push(Pair(n - rating, food.clone()));
        }

        FoodRatings {
            food_map,
            rating_map,
            n,
        }
    }
    
    fn change_rating(&mut self, food: String, new_rating: i32) {
        if let Some((old_rating, cuisine)) = self.food_map.get_mut(&food) {
            *old_rating = new_rating;
            self.rating_map
                .get_mut(cuisine)
                .unwrap()
                .push(Pair(self.n - new_rating, food.clone()));
        }
    }
    
    fn highest_rated(&mut self, cuisine: String) -> String {
        if let Some(heap) = self.rating_map.get_mut(&cuisine) {
            while let Some(&ref item) = heap.peek() {
                let rating = &item.0;
                let food = &item.1;
                if self.n - rating == self.food_map[food].0 {
                    return food.clone();
                }
                heap.pop();
            }
        }
        String::new()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+m\log (m+n))$，其中 $m$ 是 `changeRating` 的调用次数。初始化需要 $O(n\log n)$，每次插入堆需要 $O(\log (m+n))$。
- 空间复杂度：$O(m+n)$，堆最多需要 $O(m+n)$ 的空间。
