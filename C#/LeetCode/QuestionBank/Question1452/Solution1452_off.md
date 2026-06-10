### [收藏清单](https://leetcode.cn/problems/people-whose-list-of-favorite-companies-is-not-a-subset-of-another-list/solutions/2477537/shou-cang-qing-dan-by-leetcode-solution-5c24/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：模拟

**思路**

记收藏清单的个数为 $n$，每张清单上最大公司数量为 $m$，公司名称的长度最大为 $s$。

我们可以枚举所有的收藏清单，然后检查当前的清单是否是其他清单中某一个清单的子集。所以这个问题的关键就在于——我们如何检查清单 $x$ 是否是清单 $y$ 的子集呢？我们可以把 $y$ 中所有的元素存入一个哈希表中，时间代价为 $O(m\times s)$，然后查询 $x$ 中的每个元素是否出现在 $y$ 中，单次查询的时间代价是 $O(s)$，所以查询的总时间代价也是 $O(m\times s)$。这样我们就可以在 $O(m\times s)$ 的时间内判断一个集合是否是另一个的子集。对于每个清单，我们要做 $n-1$ 次这样的判断，于是每个清单所需要的时间代价是 $O(n\times m\times s)$。我们需要遍历所有清单，总时间代价是 $O(n^2\times m\times s)$。

**考虑如何优化时间复杂度呢？** 我们可以通过字符串哈希的办法对公司的名字进行编码，这样我们只需要把一个整数加入哈希表中，查询的时候也是查询一个整数，这样单次修改和查询的时间代价从 $O(s)$ 变成了 $O(1)$，总时间代价变成了 $O(n^2\times m+n\times m\times s)$。这里的代码给出没有优化的版本，优化的版本留给读者自己实现。

**代码**

```C++
class Solution {
public:
    unordered_set <string> s[100 + 5];
    vector<int> peopleIndexes(vector<vector<string>>& favoriteCompanies) {
        int n = favoriteCompanies.size();
        vector <int> ans;

        for (int i = 0; i < n; ++i) {
            for (const auto &com: favoriteCompanies[i]) {
                s[i].insert(com);
            }
        }

        auto check = [=] (int x, int y) -> bool {
            for (const auto &com: favoriteCompanies[x]) {
                if (s[y].find(com) == s[y].end()) {
                    return false;
                }
            }
            return true;
        };

        for (int i = 0; i < n; ++i) {
            bool isSub = false;
            for (int j = 0; j < n; ++j) {
                if (i == j) {
                    continue;
                }
                isSub |= check(i, j);
            }
            if (!isSub) {
                ans.push_back(i);
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    Set<String>[] s = new Set[105];

    public List<Integer> peopleIndexes(List<List<String>> favoriteCompanies) {
        for (int i = 0; i < 105; ++i) {
            s[i] = new HashSet<String>();
        }
        int n = favoriteCompanies.size();
        List<Integer> ans = new ArrayList<Integer>();

        for (int i = 0; i < n; ++i) {
            for (String com : favoriteCompanies.get(i)) {
                s[i].add(com);
            }
        }

        for (int i = 0; i < n; ++i) {
            boolean isSub = false;
            for (int j = 0; j < n; ++j) {
                if (i == j) {
                    continue;
                }
                isSub |= check(favoriteCompanies, i, j);
            }
            if (!isSub) {
                ans.add(i);
            }
        }

        return ans;
    }

    public boolean check(List<List<String>> favoriteCompanies, int x, int y) {
        for (String com : favoriteCompanies.get(x)) {
            if (!s[y].contains(com)) {
                return false;
            }
        }
        return true;
    }
}
```

**复杂度**

- 时间复杂度：如上文中分析，这里的渐进时间复杂度为 $O(n^2\times m\times s)$。
- 空间复杂度：这里开了 $n$ 个哈希表，每张哈希表中最大放 $m$ 个字符串，每个字符串长度为 $s$，故渐进空间复杂度为 $O(n\times m\times s)$。
