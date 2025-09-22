### [设计电影租借系统](https://leetcode.cn/problems/design-movie-rental-system/solutions/846541/she-ji-dian-ying-zu-jie-xi-tong-by-leetc-dv3z/)

#### 方法一：使用合适的数据结构

**提示 1**

对于一部电影，每个商店至多有一部它的拷贝，因此我们可以将 $(shop,movie)$ 这一二元组作为数组 $entries$ 中电影的唯一标识。

因此，我们可以使用一个哈希映射 $t\_price$ 存储所有的电影。对于哈希映射中的每一个键值对，键表示 $(shop,movie)$，值表示该电影的价格。

**提示 2**

我们可以考虑禁止修改 $t\_price$，即在任何情况下（例如 $rent$ 操作或者 $drop$ 操作），我们都不会去修改 $t\_price$ 本身。因此，我们需要两个额外的数据结构，一个存储未借出的电影 $t\_valid$，一个存储已借出的电影 $t\_rent$。

我们应该使用何种数据结构呢？

**提示 3**

对于未借出的电影，我们需要支持以下的三种操作：

- $search(movie)$ 操作，即给定 $movie$ 查找出最便宜的 $5$ 个 $shop$。因此，$t\_valid$ 最好「相对于 $movie$」是一个**有序的**数据结构。
 $  $ 我们可以考虑将 $t\_valid$ 设计成一个哈希映射，键表示 $movie$，值为一个有序集合（例如平衡树），存储了所有拥有 $movie$ 的 $shop$。由于在 $search$ 操作中，我们需要按照 $price$ 为第一关键字，$shop$ 为第二关键字返回结果，因此我们可以在有序集合中存储 $(price,shop)$ 这一二元组。
- $rent(shop, movie)$ 操作。我们只需要通过 $t\_price[(shop,movie)]$ 得到 $price$，从 $t\_valid[movie]$ 中删除 $(price,shop)$ 即可。
- $drop(shop, movie)$ 操作。我们只需要通过 $t\_price[(shop,movie)]$ 得到 $price$，将 $(price,shop)$ 加入 $t\_valid[movie]$ 即可。

对于已借出的电影，我们需要支持以下的三种操作：

- $report()$ 操作，即查找出最便宜的 $5$ 部电影。由于我们需要按照 $price$ 为第一关键字，$shop$ 为第二关键字，$movie$ 为第三关键字返回结果，因此我们同样可以使用一个有序集合表示 $t\_rent$，存储三元组 $(price,shop,movie)$。
- $rent(shop, movie)$ 操作。我们只需要通过 $t\_price[(shop,movie)]$ 得到 $price$，将 $(price,shop,movie)$ 加入 $t\_rent$ 即可。
- $drop(shop, movie)$ 操作。我们只需要通过 $t\_price[(shop,movie)]$ 得到 $price$，从 $t\_rent$ 中删除 $(price,shop,movie)$ 即可。

**思路与算法**

我们使用提示部分提及的数据结构 $t\_price$，$t\_valid$，$t\_rent$。

- 对于 $MovieRentingSystem(n, entries)$ 操作：我们遍历 $entries$ 中的 $(shop,movie,price)$，将 $(shop,movie)$ 作为键、price 作为值加入 $t\_price$，并且将 $(price,shop)$ 加入 $t\_valid[movie]$。
- 对于 $search(movie)$ 操作，我们遍历 $t\_valid[movie]$ 中不超过 $5$ 个 $(price,shop)$，并返回其中的 $shop$。
- 对于 $rent(shop, movie)$ 操作，我们通过 $t\_price[(shop,movie)]$ 得到 $price$，从 $t\_valid[movie]$ 中删除 $(price,shop)$，并且将 $(price,shop,movie)$ 加入 $t\_rent$。
- 对于 $drop(shop, movie)$ 操作，我们通过 $t\_price[(shop,movie)]$ 得到 $price$，将 $(price,shop)$ 加入 $t\_valid[movie]$，并且从 $t\_rent$ 中删除 $(price,shop,movie)$。
- 对于 $report()$ 操作，我们遍历 $t\_rent$ 中不超过 $5$ 个 $(price,shop,movie)$，并返回其中的 $(shop,movie)$。

**代码**

```C++
class MovieRentingSystem {
private:
    // 需要自行实现 pair<int, int> 的哈希函数
    static constexpr auto pairHash = [fn = hash<int>()](const pair<int, int>& o) {return (fn(o.first) << 16) ^ fn(o.second);};
    unordered_map<pair<int, int>, int, decltype(pairHash)> t_price{0, pairHash};

    unordered_map<int, set<pair<int, int>>> t_valid;

    set<tuple<int, int, int>> t_rent;

public:
    MovieRentingSystem(int n, vector<vector<int>>& entries) {
        for (const auto& entry: entries) {
            t_price[{entry[0], entry[1]}] = entry[2];
            t_valid[entry[1]].emplace(entry[2], entry[0]);
        }
    }
    
    vector<int> search(int movie) {
        if (!t_valid.count(movie)) {
            return {};
        }
        
        vector<int> ret;
        auto it = t_valid[movie].begin();
        for (int i = 0; i < 5 && it != t_valid[movie].end(); ++i, ++it) {
            ret.push_back(it->second);
        }
        return ret;
    }
    
    void rent(int shop, int movie) {
        int price = t_price[{shop, movie}];
        t_valid[movie].erase({price, shop});
        t_rent.emplace(price, shop, movie);
    }
    
    void drop(int shop, int movie) {
        int price = t_price[{shop, movie}];
        t_valid[movie].emplace(price, shop);
        t_rent.erase({price, shop, movie});
    }
    
    vector<vector<int>> report() {
        vector<vector<int>> ret;
        auto it = t_rent.begin();
        for (int i = 0; i < 5 && it != t_rent.end(); ++i, ++it) {
            ret.emplace_back(initializer_list<int>{get<1>(*it), get<2>(*it)});
        }
        return ret;
    }
};
```

```Python
class MovieRentingSystem:

    def __init__(self, n: int, entries: List[List[int]]):
        self.t_price = dict()
        self.t_valid = defaultdict(sortedcontainers.SortedList)
        self.t_rent = sortedcontainers.SortedList()
        
        for shop, movie, price in entries:
            self.t_price[(shop, movie)] = price
            self.t_valid[movie].add((price, shop))

    def search(self, movie: int) -> List[int]:
        t_valid_ = self.t_valid
        
        if movie not in t_valid_:
            return []
        
        return [shop for (price, shop) in t_valid_[movie][:5]]
        
    def rent(self, shop: int, movie: int) -> None:
        price = self.t_price[(shop, movie)]
        self.t_valid[movie].discard((price, shop))
        self.t_rent.add((price, shop, movie))

    def drop(self, shop: int, movie: int) -> None:
        price = self.t_price[(shop, movie)]
        self.t_valid[movie].add((price, shop))
        self.t_rent.discard((price, shop, movie))

    def report(self) -> List[List[int]]:
        return [(shop, movie) for price, shop, movie in self.t_rent[:5]]
```

```Java
class Pair {
    int first, second;
    Pair(int first, int second) {
        this.first = first;
        this.second = second;
    }
    
    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        Pair pair = (Pair) o;
        return first == pair.first && second == pair.second;
    }
    
    @Override
    public int hashCode() {
        return (first << 16) ^ second;
    }
}

class Triple implements Comparable<Triple> {
    int price, shop, movie;
    Triple(int price, int shop, int movie) {
        this.price = price;
        this.shop = shop;
        this.movie = movie;
    }
    
    @Override
    public int compareTo(Triple o) {
        if (price != o.price) {
            return Integer.compare(price, o.price);
        }
        if (shop != o.shop) {
            return Integer.compare(shop, o.shop);
        }
        return Integer.compare(movie, o.movie);
    }
}

class MovieRentingSystem {
    private Map<Pair, Integer> tPrice = new HashMap<>();
    private Map<Integer, TreeSet<Pair>> tValid = new HashMap<>();
    private TreeSet<Triple> tRent = new TreeSet<>();

    public MovieRentingSystem(int n, int[][] entries) {
        for (int[] entry : entries) {
            Pair p = new Pair(entry[0], entry[1]);
            tPrice.put(p, entry[2]);
            tValid.computeIfAbsent(entry[1], k -> new TreeSet<>(
                (a, b) -> a.first != b.first ? Integer.compare(a.first, b.first) 
                                             : Integer.compare(a.second, b.second)
            )).add(new Pair(entry[2], entry[0]));
        }
    }
    
    public List<Integer> search(int movie) {
        if (!tValid.containsKey(movie)) {
            return Collections.emptyList();
        }
        return tValid.get(movie).stream()
            .limit(5)
            .map(p -> p.second)
            .collect(Collectors.toList());
    }
    
    public void rent(int shop, int movie) {
        int price = tPrice.get(new Pair(shop, movie));
        tValid.get(movie).remove(new Pair(price, shop));
        tRent.add(new Triple(price, shop, movie));
    }
    
    public void drop(int shop, int movie) {
        int price = tPrice.get(new Pair(shop, movie));
        tValid.get(movie).add(new Pair(price, shop));
        tRent.remove(new Triple(price, shop, movie));
    }
    
    public List<List<Integer>> report() {
        return tRent.stream()
            .limit(5)
            .map(t -> Arrays.asList(t.shop, t.movie))
            .collect(Collectors.toList());
    }
}
```

```CSharp
struct Pair : IEquatable<Pair> {
    public int First { get; }
    public int Second { get; }
    
    public Pair(int first, int second) {
        First = first;
        Second = second;
    }
    
    public bool Equals(Pair other) => First == other.First && Second == other.Second;
    public override bool Equals(object obj) => obj is Pair other && Equals(other);
    public override int GetHashCode() => (First << 16) ^ Second;
}

public class MovieRentingSystem {
    private Dictionary<Pair, int> tPrice = new Dictionary<Pair, int>();
    private Dictionary<int, SortedSet<Pair>> tValid = new Dictionary<int, SortedSet<Pair>>();
    private SortedSet<(int price, int shop, int movie)> tRent = new SortedSet<(int, int, int)>();
    
    public MovieRentingSystem(int n, int[][] entries) {
        foreach (var entry in entries) {
            var p = new Pair(entry[0], entry[1]);
            tPrice[p] = entry[2];
            if (!tValid.ContainsKey(entry[1])) {
                tValid[entry[1]] = new SortedSet<Pair>(Comparer<Pair>.Create((a, b) => 
                    a.First != b.First ? a.First.CompareTo(b.First) : a.Second.CompareTo(b.Second)));
            }
            tValid[entry[1]].Add(new Pair(entry[2], entry[0]));
        }
    }
    
    public IList<int> Search(int movie) {
        if (!tValid.ContainsKey(movie)) {
            return new List<int>();
        }
        return tValid[movie].Take(5).Select(p => p.Second).ToList();
    }
    
    public void Rent(int shop, int movie) {
        var p = new Pair(shop, movie);
        int price = tPrice[p];
        tValid[movie].Remove(new Pair(price, shop));
        tRent.Add((price, shop, movie));
    }
    
    public void Drop(int shop, int movie) {
        var p = new Pair(shop, movie);
        int price = tPrice[p];
        tValid[movie].Add(new Pair(price, shop));
        tRent.Remove((price, shop, movie));
    }
    
    public IList<IList<int>> Report() {
        return tRent.Take(5).Select(t => new List<int> { t.shop, t.movie }).ToList<IList<int>>();
    }
}
```

```Rust
use std::collections::{HashMap, BTreeSet};
use std::cmp::Ordering;

#[derive(Debug, Clone, Copy, PartialEq, Eq, Hash, PartialOrd, Ord)]
struct Pair {
    first: i32,
    second: i32,
}

impl Pair {
    fn new(first: i32, second: i32) -> Self {
        Pair { first, second }
    }
}

#[derive(Debug, Clone, Copy, PartialEq, Eq, PartialOrd, Ord)]
struct Triple {
    price: i32,
    shop: i32,
    movie: i32,
}

impl Triple {
    fn new(price: i32, shop: i32, movie: i32) -> Self {
        Triple { price, shop, movie }
    }
}

struct MovieRentingSystem {
    t_price: HashMap<Pair, i32>,
    t_valid: HashMap<i32, BTreeSet<Pair>>,
    t_rent: BTreeSet<Triple>,
}

impl MovieRentingSystem {
    fn new(n: i32, entries: Vec<Vec<i32>>) -> Self {
        let mut t_price = HashMap::new();
        let mut t_valid = HashMap::new();
        
        for entry in entries {
            let shop = entry[0];
            let movie = entry[1];
            let price = entry[2];
            t_price.insert(Pair::new(shop, movie), price);
            t_valid.entry(movie)
                .or_insert_with(BTreeSet::new)
                .insert(Pair::new(price, shop));
        }
        
        MovieRentingSystem {
            t_price,
            t_valid,
            t_rent: BTreeSet::new(),
        }
    }
    
    fn search(&self, movie: i32) -> Vec<i32> {
        self.t_valid.get(&movie)
            .map_or_else(Vec::new, |set| {
                set.iter()
                    .take(5)
                    .map(|p| p.second)
                    .collect()
            })
    }
    
    fn rent(&mut self, shop: i32, movie: i32) {
        let price = self.t_price[&Pair::new(shop, movie)];
        self.t_valid.get_mut(&movie).unwrap().remove(&Pair::new(price, shop));
        self.t_rent.insert(Triple::new(price, shop, movie));
    }
    
    fn drop(&mut self, shop: i32, movie: i32) {
        let price = self.t_price[&Pair::new(shop, movie)];
        self.t_valid.get_mut(&movie).unwrap().insert(Pair::new(price, shop));
        self.t_rent.remove(&Triple::new(price, shop, movie));
    }
    
    fn report(&self) -> Vec<Vec<i32>> {
        self.t_rent.iter()
            .take(5)
            .map(|t| vec![t.shop, t.movie])
            .collect()
    }
}
```

**复杂度分析**

- 时间复杂度：
  - $MovieRentingSystem(n, entries)$ 操作：$O(n\log n)$。
  - $search(movie)$ 操作：$O(\log n)$。
  - $rent(shop, movie)$ 操作：$O(\log n)$。
  - $drop(shop, movie)$ 操作：$O(\log n)$。
  - $report()$ 操作：$O(\log n)$。
- 空间复杂度：$O(n)$。
