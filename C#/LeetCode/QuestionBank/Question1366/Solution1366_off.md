### [通过投票对团队排名](https://leetcode.cn/problems/rank-teams-by-votes/solutions/123922/tong-guo-tou-piao-dui-tuan-dui-pai-ming-by-leetcod/)

#### 方法一：排序

设参与排名的人数为 $n$（即数组 $votes$ 中任一字符串的长度），我们可以用一个哈希映射（HashMap）存储每一个人的排名情况。对于哈希映射中的每个键值对，键为一个在数组 $votes$ 中出现的大写英文字母，表示一个参与排名的人；值为一个长度为 $n$ 的数组 $rank$，表示这个人的排名情况，其中 $rank[i]$ 表示这个人排名为 $i$ 的次数。

我们遍历数组 $votes$ 中的每一个字符串并进行统计，就可以得到上述存储了每一个人排名情况的哈希映射。随后我们将这些键值对取出，并放入数组中进行排序。记每一个键值对为 $(vid,rank)$，根据题目要求，我们需要以 $rank$ 为第一关键字进行降序排序。在大部分语言中，我们是可以对变长的数组（例如 `C++` 中的 `vector`，`Python` 中的 `list`）直接进行比较排序的，比较的方式是从首部的元素开始，依次比较两个数组同一位置的元素的大小，若相等则继续比较下一位置，直至数组的尾部（此时长度较长的数组较大，若长度相同，则这两个数组同样大）。因此第一关键字可以直接进行比较。在 $rank$ 相等的情况下，我们需要以 $vid$ 为第二关键字进行升序排序。在 `C++` 中，我们可以自定义比较函数，完成多关键字的排序，而在 `Python` 中进行多关键字排序时，不同关键字的排序方式必须保持一致。我们可以将 $vid$ 从字符转换为对应的 `ASCII` 码，并用其相反数作为第二关键字，这样就与第一关键字保持一致，即都进行降序排序。

在排序完成后，我们将每一个键值对中的键 $vid$ 依次加入到答案字符串 $ans$ 中，即可得到最终的答案。

```Java
class Solution {
    public String rankTeams(String[] votes) {
        int n = votes.length;
        // 初始化哈希映射
        Map<Character, int[]> ranking = new HashMap<>();
        for (char vid : votes[0].toCharArray()) {
            ranking.put(vid, new int[votes[0].length()]);
        }
        // 遍历统计
        for (String vote : votes) {
            for (int i = 0; i < vote.length(); ++i) {
                ++ranking.get(vote.charAt(i))[i];
            }
        }

        // 取出所有的键值对
        List<Map.Entry<Character, int[]>> result = new ArrayList<>(ranking.entrySet());
        // 排序
        result.sort((a, b) -> {
            for (int i = 0; i < a.getValue().length; i++) {
                if (a.getValue()[i] != b.getValue()[i]) {
                    return b.getValue()[i] - a.getValue()[i];
                }
            }
            return a.getKey() - b.getKey();
        });

        StringBuilder ans = new StringBuilder();
        for (Map.Entry<Character, int[]> entry : result) {
            ans.append(entry.getKey());
        }
        return ans.toString();
    }
}
```

```CSharp
public class Solution {
    public string RankTeams(string[] votes) {
        int n = votes.Length;
        // 初始化哈希映射
        Dictionary<char, int[]> ranking = new Dictionary<char, int[]>();
        foreach (char vid in votes[0]) {
            ranking[vid] = new int[votes[0].Length];
        }
        // 遍历统计
        foreach (string vote in votes) {
            for (int i = 0; i < vote.Length; ++i) {
                ++ranking[vote[i]][i];
            }
        }
        // 取出所有的键值对
        var result = ranking.ToList();
        // 排序
        result.Sort((a, b) => {
            for (int i = 0; i < a.Value.Length; ++i) {
                if (a.Value[i] != b.Value[i]) {
                    return b.Value[i].CompareTo(a.Value[i]);
                }
            }
            return a.Key.CompareTo(b.Key);
        });
        return string.Concat(result.Select(r => r.Key));
    }
}
```

```C++
class Solution {
public:
    string rankTeams(vector<string>& votes) {
        int n = votes.size();
        // 初始化哈希映射
        unordered_map<char, vector<int>> ranking;
        for (char vid: votes[0]) {
            ranking[vid].resize(votes[0].size());
        }
        // 遍历统计
        for (const string& vote: votes) {
            for (int i = 0; i < vote.size(); ++i) {
                ++ranking[vote[i]][i];
            }
        }
        
        // 取出所有的键值对
        using PCV = pair<char, vector<int>>;
        vector<PCV> result(ranking.begin(), ranking.end());
        // 排序
        sort(result.begin(), result.end(), [](const PCV& l, const PCV& r) {
            return l.second > r.second || (l.second == r.second && l.first < r.first);
        });
        string ans;
        for (auto& [vid, rank]: result) {
            ans += vid;
        }
        return ans;
    }
};
```

```Go
func rankTeams(votes []string) string {
    // 初始化哈希映射
    ranking := make(map[byte][]int)
    for i := 0; i < len(votes[0]); i++ {
        ranking[votes[0][i]] = make([]int, len(votes[0]))
    }
    // 遍历统计
    for _, vote := range votes {
        for i := 0; i < len(vote); i++ {
            ranking[vote[i]][i]++
        }
    }

    // 取出所有的键值对
    result := make([]struct {
        vid  byte
        rank []int
    }, 0, len(ranking))
    for k, v := range ranking {
        result = append(result, struct {
            vid  byte
            rank []int
        }{k, v})
    }
    // 排序
    sort.Slice(result, func(i, j int) bool {
        for k := 0; k < len(result[i].rank); k++ {
            if result[i].rank[k] != result[j].rank[k] {
                return result[i].rank[k] > result[j].rank[k]
            }
        }
        return result[i].vid < result[j].vid
    })
    ans := make([]byte, 0, len(result))
    for _, r := range result {
        ans = append(ans, r.vid)
    }
    return string(ans)
}
```

```Python
class Solution:
    def rankTeams(self, votes: List[str]) -> str:
        n = len(votes[0])
        # 初始化哈希映射
        ranking = collections.defaultdict(lambda: [0] * n)
        # 遍历统计
        for vote in votes:
            for i, vid in enumerate(vote):
                ranking[vid][i] += 1
        
        # 取出所有的键值对
        result = list(ranking.items())
        # 排序
        result.sort(key=lambda x: (x[1], -ord(x[0])), reverse=True)
        return "".join([vid for vid, rank in result])
```

```C
typedef struct {
    char vid;
    int *rank;
    int rankSize;
    int valid;
} Team;

int cmp(const void *a, const void *b) {
    Team *t1 = (Team *)a;
    Team *t2 = (Team *)b;
    if (t1->valid != t1->valid) {
        return t2->valid - t1->valid;
    }
    for (int i = 0; i < t1->rankSize; ++i) {
        if (t1->rank[i] != t2->rank[i]) {
            return t2->rank[i] - t1->rank[i];
        }
    }
    return t1->vid - t2->vid;
}

char* rankTeams(char** votes, int votesSize) {
    int len = strlen(votes[0]);
    int **ranking = malloc(26 * sizeof(int *));
    int valid[26] = {0};
    for (int i = 0; i < 26; ++i) {
        ranking[i] = calloc(len, sizeof(int));
    }
    // 遍历统计
    for (int i = 0; i < votesSize; ++i) {
        for (int j = 0; j < len; ++j) {
            ranking[votes[i][j] - 'A'][j]++;
            valid[votes[i][j] - 'A'] = 1;
        }
    }
    Team result[26];
    for (int i = 0; i < 26; ++i) {
        result[i].vid = 'A' + i;
        result[i].rank = ranking[i];
        result[i].rankSize = len;
        result[i].valid = valid[i];
    }
    qsort(result, 26, sizeof(Team), cmp);
    char *ans = calloc(len + 1, sizeof(char));
    for (int i = 0; i < len; ++i) {
        ans[i] = result[i].vid;
    }
    ans[len] = '\0';
    for (int i = 0; i < 26; ++i) {
        free(ranking[i]);
    }
    free(ranking);

    return ans;
}
```

```JavaScript
var rankTeams = function(votes) {
    const n = votes.length;
    const ranking = {};
    // 初始化哈希映射
    for (const vid of votes[0]) {
        ranking[vid] = Array(votes[0].length).fill(0);
    }
    // 遍历统计
    for (const vote of votes) {
        for (let i = 0; i < vote.length; ++i) {
            ranking[vote[i]][i]++;
        }
    }

    // 取出所有的键值对
    const result = Object.entries(ranking);
    // 排序
    result.sort((a, b) => {
        for (let i = 0; i < a[1].length; i++) {
            if (a[1][i] !== b[1][i]) {
                return b[1][i] - a[1][i];
            }
        }
        return a[0].localeCompare(b[0]);
    });
    return result.map(([vid]) => vid).join('');
};
```

```TypeScript
function rankTeams(votes: string[]): string {
    const n = votes.length;
    const ranking: { [key: string]: number[] } = {};
    // 初始化哈希映射
    for (const vid of votes[0]) {
        ranking[vid] = new Array(votes[0].length).fill(0);
    }
    // 遍历统计
    for (const vote of votes) {
        for (let i = 0; i < vote.length; ++i) {
            ranking[vote[i]][i]++;
        }
    }
    // 取出所有的键值对
    const result = Object.entries(ranking);
    // 排序
    result.sort((a, b) => {
        for (let i = 0; i < a[1].length; i++) {
            if (a[1][i] !== b[1][i]) {
                return b[1][i] - a[1][i];
            }
        }
        return a[0].localeCompare(b[0]);
    });
    return result.map(([vid]) => vid).join('');
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn rank_teams(votes: Vec<String>) -> String {
        let n = votes.len();
        // 初始化哈希映射
        let mut ranking: HashMap<char, Vec<i32>> = HashMap::new();
        for vid in votes[0].chars() {
            ranking.entry(vid).or_insert(vec![0; votes[0].len()]);
        }
        // 遍历统计
        for vote in votes {
            for (i, c) in vote.chars().enumerate() {
                if let Some(rank) = ranking.get_mut(&c) {
                    rank[i] += 1;
                }
            }
        }
        // 取出所有的键值对
        let mut result: Vec<(char, Vec<i32>)> = ranking.into_iter().collect();
        // 排序
        result.sort_by(|a, b| {
            for i in 0..a.1.len() {
                if a.1[i] != b.1[i] {
                    return b.1[i].cmp(&a.1[i]);
                }
            }
            a.0.cmp(&b.0)
        });

        // 构建结果字符串
        let mut ans = String::new();
        for (vid, _) in result {
            ans.push(vid);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(NK+N^2logN)$，其中 $N$ 是数组 $votes$ 中每一个字符串的长度（参与排名的人数），$K$ 是数组 $votes$ 的长度（参与投票的人数）。「遍历统计」的时间复杂度为 $O(NK)$，「排序」的时间复杂度为 $O(N^2logN)$（其中 $O(NlogN)$ 为排序本身的时间，还需要额外的比较两个键值对大小的 $O(N)$ 时间），建立最终答案字符串的时间复杂度为 $O(N)$，因此总时间复杂度为 $O(NK+N^2logN)$。
- 空间复杂度：$O(N^2)$。哈希映射中键值对的数量为 $N$，每个键使用 $O(1)$ 的空间，每个值使用 $O(N)$ 的空间，空间复杂度为 $O(N^2)$。存储排序的结果同样需要使用 $O(N^2)$ 的空间，因此总空间复杂度为 $O(N^2)$。
