### [最多的不重叠子字符串](https://leetcode.cn/problems/maximum-number-of-non-overlapping-substrings/solutions/339173/zui-duo-de-bu-zhong-die-zi-zi-fu-chuan-by-leetcode/)

#### 方法一：贪心

**思路与算法**

由于题目要求「如果一个子字符串包含字符 $c$，那么 $s$ 中所有 $c$ 字符都应该在这个子字符串中」，且我们要使最后的总长度尽可能的小，因此最多不会有超过字符集大小 $\sum$ 数量的子字符串。假设当前找到了包含字符 $a$ 的符合条件的最短字符串 $s[l_a,r_a]$，看起来 $s[l_a-1,r_a]$ 或者 $s[l_a,r_a+1]$ 也可能作为一个符合条件的字符串，但是我们要使最后的「长度和最小」，因此我们只需要关注包含每个字符的「最短字符串」即可。

解决问题的第一步是需要预处理出字符集中每个字符对应的最短字符串，由于字符集很小，我们可以暴力处理这一部分的答案。

我们先遍历字符串，确定字符 $c$ 第一次出现的位置 $l_c$ 和最后一次出现的位置 $r_c$，由于 $[l_c,r_c]$ 中间可能存在其他字符，因此为了满足题目的第二点要求，我们需要遍历 $[l_c,r_c]$ 中的所有字符，利用它们的左右端点来更新 $l_c$ 和 $r_c$，以保证「如果一个子字符串包含字符 $c$，那么 $s$ 中所有 $c$ 字符都应该在这个子字符串中」。

具体地，我们处理字符 $c$ 对应的区间时，初始化当前需要扫描的区间 $[l,r]=[l_c,r_c]$，并且初始化我们已经扫描的区间 $(n_l,n_r)=(l,l)$。为了方便，已扫描区间采取**开区间**的写法，初始状态为空区间。

我们逐一检查当前需要的扫描区间中还未检查的字符，直至已扫描区间完整包括当前需要扫描的区间为止，最终的结果 $[l,r]$ 就是一个合法区间。当我们检查到字符 $t$ 时：

- 如果 $l_t<l$，说明当前区间左边还有字符 $t$，因此必须将待扫描区间左端点扩展到 $l_t$；
- 如果 $r_t>r$，说明当前区间右边还有字符 $t$，因此必须将待扫描区间右端点扩展到 $r_t.$
- 对于每个字符 $c$，最多完整扫描一遍字符串 $s$，因此预处理的时间复杂度为 $O(n\sum )$。

> 我们其实可以只考虑将区间向右扩展，如果碰到区间需要向左扩展的情况，则可以直接放弃检查当前区间。为什么？
>
> - 假如我们正在处理字符 $c$ 对应的区间 $[l_c,r_c]$，当我们扫描至字符 $s[i]=t$ 时发现 $l_t<l_c$，此时待扫描区间需要向左扩张，此时需要扫描的区间变为了 $[l_t,r]$。注意，$r\ge r_c$，因为可能在发生过向右扩张的情况。
>     然而，由于我们一定已经/即将处理以字符 $t$ 对应的区间 $[l_t,r_t]$，且 $r_t\ge i$，因此以字符 $t$ 为处理起点时，至少会扫描区间 $[l_t,i]$，此时的待扫描区间 $[l,r]$ 一定满足 $l\le l_t, r^′\ge$ r,即包含区间 $[l_t,r]$。
>     因此以字符 $c$ 为处理起点的最终结果将在处理字符 $t$ 时考虑到。

> 当然，我们也可以采取更加暴力的写法：从左至右扫描当前区间，当区间需要扩展时，重新扫描更新后的区间。这种写法更简洁，并且也可以通过本题。

预处理结束后，我们得到了若干个合法区间，问题转化成了**从若干个合法区间中，选择最多个互不重叠的区间，在满足最多数量的前提下，选择总长度最小的方案**。特别地，按照上文所述的处理方法，合法区间满足以下特殊性质：

- 两个合法区间要么不相交，要么存在包含关系，不存在部分重叠的情况。也就是说对于任意两个区间[l_1,r_1]，$[l_2,r_2]$，不会出现类似 $l_1<l_2<r_1<r_2$ 的情况；
- 两个合法区间不会具有相同的右端点或者左端点。因为区间扩展的端点一定是任意一个字符第一次出现的位置或者最后一次出现的位置，这些位置显然不能为同一个下标。

因此我们可以贪心选取区间。我们只需要将得到的区间按右端点升序排序，然后从前往后遍历如果当前区间与已经选择的区间不重叠，就选择它，否则跳过。贪心的正确性，请读者参考「[435\. 无重叠区间](https://leetcode.cn/problems/non-overlapping-intervals/description/)」的官方解法中的方法二。

需要指出，对于一般的情况（即区间不具有上述特殊性质，可能存在部分重叠），上述贪心方法只能够得到最多的不重叠区间，无法保证总长度最小。

例如，如果有 $2$ 个待选择的合法区间：$[[1,5],[4,6]]$，此时要想使得最终选择的区间不重叠，我们只能保留 $1$ 个区间。按照右端点升序会优先选择区间 $[1,5]$，但区间 $[4,6]$ 的长度更短。

根据本题中候选区间具有的特殊性质，当两个区间$[l_1,r_1]$，$[l_2,r_2]$发生重叠时，一定符合一个区间被另一个区间包含的情况。假如 $r_1<r_2$（由于第 $2$ 个特殊性质，这里不可能取等号），那么一定有$l_2<l_1<r_1<r_2$。也就是说，右端点更小的区间不仅结束得更早，而且长度也更短。因此，右端点更小的区间一定更短，在保证区间数量最多的前提下，不会增加总长度。

```Python
class Solution:
    def maxNumOfSubstrings(self, s: str) -> List[str]:
        pos = defaultdict(list)  # 记录每个字符的第一次和最后一次出现位置

        for i, ch in enumerate(s):
            if ch not in pos:
                pos[ch] = [i, i]
            else:
                pos[ch][1] = i

        valid = []  # 所有合法的区间

        for c, (l_c, r_c) in pos.items():
            l, r = l_c, r_c

            nl = nr = l

            while nl >= l or nr <= r:
                i = nl if nl >= l else nr

                l_t, r_t = pos[s[i]] # 当前处理的是字符 s[i]

                if l_t < l: # 当前区间左侧还有该字符，需要向左扩展
                    l = l_t

                if r_t > r: # 当前区间右侧还有该字符，需要向右扩展
                    r = r_t

                if i == nl: # 当前处理的是左指针
                    nl -= 1

                if i == nr: # 当前处理的是右指针
                    nr += 1

            valid.append([l, r])

        # 按右端点升序排序
        valid.sort(key=lambda x: x[1])

        # 贪心选择互不重叠的区间
        ans = []
        end = -1

        for left, right in valid:
            if left > end:
                ans.append(s[left:right + 1])
                end = right

        return ans
```

```C++
class Solution {
public:
    vector<string> maxNumOfSubstrings(string s) {
        // 记录每个字符的第一次和最后一次出现位置
        unordered_map<char, pair<int, int>> pos;

        for (int i = 0; i < s.length(); i++) {
            char ch = s[i];
            if (pos.find(ch) == pos.end()) {
                pos[ch] = {i, i};
            } else {
                pos[ch].second = i;
            }
        }

        // 所有合法的区间
        vector<pair<int, int>> valid;

        for (auto& [c, range] : pos) {
            int l = range.first, r = range.second;
            int nl = l, nr = l;

            while (nl >= l || nr <= r) {
                int i = (nl >= l) ? nl : nr;

                // 当前处理的是字符 s[i]
                int l_t = pos[s[i]].first;
                int r_t = pos[s[i]].second;

                // 当前区间左侧还有该字符，需要向左扩展
                if (l_t < l) {
                    l = l_t;
                }

                // 当前区间右侧还有该字符，需要向右扩展
                if (r_t > r) {
                    r = r_t;
                }

                // 当前处理的是左指针
                if (i == nl) {
                    nl--;
                }

                // 当前处理的是右指针
                if (i == nr) {
                    nr++;
                }
            }

            valid.push_back({l, r});
        }

        // 按右端点升序排序
        sort(valid.begin(), valid.end(),
             [](const pair<int, int>& a, const pair<int, int>& b) {
                 return a.second < b.second;
             });

        // 贪心选择互不重叠的区间
        vector<string> ans;
        int end = -1;

        for (auto& [left, right] : valid) {
            if (left > end) {
                ans.push_back(s.substr(left, right - left + 1));
                end = right;
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public List<String> maxNumOfSubstrings(String s) {
        // 记录每个字符的第一次和最后一次出现位置
        Map<Character, int[]> pos = new HashMap<>();

        for (int i = 0; i < s.length(); i++) {
            char ch = s.charAt(i);
            if (!pos.containsKey(ch)) {
                pos.put(ch, new int[]{i, i});
            } else {
                pos.get(ch)[1] = i;
            }
        }

        // 所有合法的区间
        List<int[]> valid = new ArrayList<>();

        for (Map.Entry<Character, int[]> entry : pos.entrySet()) {
            int[] range = entry.getValue();
            int l = range[0], r = range[1];
            int nl = l, nr = l;

            while (nl >= l || nr <= r) {
                int i = (nl >= l) ? nl : nr;

                // 当前处理的是字符 s[i]
                int[] currentRange = pos.get(s.charAt(i));
                int l_t = currentRange[0];
                int r_t = currentRange[1];

                // 当前区间左侧还有该字符，需要向左扩展
                if (l_t < l) {
                    l = l_t;
                }

                // 当前区间右侧还有该字符，需要向右扩展
                if (r_t > r) {
                    r = r_t;
                }

                // 当前处理的是左指针
                if (i == nl) {
                    nl--;
                }

                // 当前处理的是右指针
                if (i == nr) {
                    nr++;
                }
            }

            valid.add(new int[]{l, r});
        }

        // 按右端点升序排序
        valid.sort((a, b) -> a[1] - b[1]);

        // 贪心选择互不重叠的区间
        List<String> ans = new ArrayList<>();
        int end = -1;

        for (int[] interval : valid) {
            int left = interval[0];
            int right = interval[1];

            if (left > end) {
                ans.add(s.substring(left, right + 1));
                end = right;
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<string> MaxNumOfSubstrings(string s) {
        // 记录每个字符的第一次和最后一次出现位置
        Dictionary<char, int[]> pos = new Dictionary<char, int[]>();

        for (int i = 0; i < s.Length; i++) {
            char ch = s[i];
            if (!pos.ContainsKey(ch)) {
                pos[ch] = new int[]{i, i};
            } else {
                pos[ch][1] = i;
            }
        }

        // 所有合法的区间
        List<int[]> valid = new List<int[]>();

        foreach (var kvp in pos) {
            int[] range = kvp.Value;
            int l = range[0], r = range[1];
            int nl = l, nr = l;

            while (nl >= l || nr <= r) {
                int i = (nl >= l) ? nl : nr;

                // 当前处理的是字符 s[i]
                int[] currentRange = pos[s[i]];
                int l_t = currentRange[0];
                int r_t = currentRange[1];

                // 当前区间左侧还有该字符，需要向左扩展
                if (l_t < l) {
                    l = l_t;
                }

                // 当前区间右侧还有该字符，需要向右扩展
                if (r_t > r) {
                    r = r_t;
                }

                // 当前处理的是左指针
                if (i == nl) {
                    nl--;
                }

                // 当前处理的是右指针
                if (i == nr) {
                    nr++;
                }
            }

            valid.Add(new int[]{l, r});
        }

        // 按右端点升序排序
        valid.Sort((a, b) => a[1] - b[1]);

        // 贪心选择互不重叠的区间
        List<string> ans = new List<string>();
        int end = -1;

        foreach (int[] interval in valid) {
            int left = interval[0];
            int right = interval[1];

            if (left > end) {
                ans.Add(s.Substring(left, right - left + 1));
                end = right;
            }
        }

        return ans;
    }
}
```

```Go
func maxNumOfSubstrings(s string) []string {
    // 记录每个字符的第一次和最后一次出现位置
    pos := make(map[byte][]int)

    for i := 0; i < len(s); i++ {
        ch := s[i]
        if _, exists := pos[ch]; !exists {
            pos[ch] = []int{i, i}
        } else {
            pos[ch][1] = i
        }
    }

    // 所有合法的区间
    type Interval struct {
        left, right int
    }
    valid := []Interval{}

    for _, range_ := range pos {
        l, r := range_[0], range_[1]
        nl, nr := l, l

        for nl >= l || nr <= r {
            i := nl
            if nl < l {
                i = nr
            }

            // 当前处理的是字符 s[i]
            l_t := pos[s[i]][0]
            r_t := pos[s[i]][1]

            // 当前区间左侧还有该字符，需要向左扩展
            if l_t < l {
                l = l_t
            }

            // 当前区间右侧还有该字符，需要向右扩展
            if r_t > r {
                r = r_t
            }

            // 当前处理的是左指针
            if i == nl {
                nl--
            }

            // 当前处理的是右指针
            if i == nr {
                nr++
            }
        }

        valid = append(valid, Interval{l, r})
    }

    // 按右端点升序排序
    sort.Slice(valid, func(i, j int) bool {
        return valid[i].right < valid[j].right
    })

    // 贪心选择互不重叠的区间
    ans := []string{}
    end := -1

    for _, interval := range valid {
        if interval.left > end {
            ans = append(ans, s[interval.left:interval.right+1])
            end = interval.right
        }
    }

    return ans
}
```

```C
typedef struct {
    int left;
    int right;
} Interval;

int compare(const void* a, const void* b) {
    Interval* intervalA = (Interval*)a;
    Interval* intervalB = (Interval*)b;
    return intervalA->right - intervalB->right;
}

char ** maxNumOfSubstrings(char * s, int* returnSize) {
    // 记录每个字符的第一次和最后一次出现位置
    int pos[26][2];
    bool exists[26] = {false};
    int len = strlen(s);

    for (int i = 0; i < len; i++) {
        int idx = s[i] - 'a';
        if (!exists[idx]) {
            pos[idx][0] = pos[idx][1] = i;
            exists[idx] = true;
        } else {
            pos[idx][1] = i;
        }
    }

    // 所有合法的区间
    Interval* valid = (Interval*)malloc(26 * sizeof(Interval));
    int validSize = 0;

    for (int c = 0; c < 26; c++) {
        if (!exists[c]) continue;

        int l = pos[c][0], r = pos[c][1];
        int nl = l, nr = l;

        while (nl >= l || nr <= r) {
            int i = (nl >= l) ? nl : nr;
            int idx = s[i] - 'a';

            // 当前处理的是字符 s[i]
            int l_t = pos[idx][0];
            int r_t = pos[idx][1];

            // 当前区间左侧还有该字符，需要向左扩展
            if (l_t < l) {
                l = l_t;
            }

            // 当前区间右侧还有该字符，需要向右扩展
            if (r_t > r) {
                r = r_t;
            }

            // 当前处理的是左指针
            if (i == nl) {
                nl--;
            }

            // 当前处理的是右指针
            if (i == nr) {
                nr++;
            }
        }

        valid[validSize].left = l;
        valid[validSize].right = r;
        validSize++;
    }

    // 按右端点升序排序
    qsort(valid, validSize, sizeof(Interval), compare);

    // 贪心选择互不重叠的区间
    char** ans = (char**)malloc(validSize * sizeof(char*));
    *returnSize = 0;
    int end = -1;

    for (int i = 0; i < validSize; i++) {
        int left = valid[i].left;
        int right = valid[i].right;

        if (left > end) {
            int substrLen = right - left + 1;
            ans[*returnSize] = (char*)malloc((substrLen + 1) * sizeof(char));
            strncpy(ans[*returnSize], s + left, substrLen);
            ans[*returnSize][substrLen] = '\0';
            (*returnSize)++;
            end = right;
        }
    }

    free(valid);

    return ans;
}
```

```JavaScript
var maxNumOfSubstrings = function(s) {
    // 记录每个字符的第一次和最后一次出现位置
    const pos = new Map();

    for (let i = 0; i < s.length; i++) {
        const ch = s[i];
        if (!pos.has(ch)) {
            pos.set(ch, [i, i]);
        } else {
            pos.get(ch)[1] = i;
        }
    }

    // 所有合法的区间
    const valid = [];

    for (const [c, range] of pos) {
        let l = range[0], r = range[1];
        let nl = l, nr = l;

        while (nl >= l || nr <= r) {
            const i = (nl >= l) ? nl : nr;

            // 当前处理的是字符 s[i]
            const l_t = pos.get(s[i])[0];
            const r_t = pos.get(s[i])[1];

            // 当前区间左侧还有该字符，需要向左扩展
            if (l_t < l) {
                l = l_t;
            }

            // 当前区间右侧还有该字符，需要向右扩展
            if (r_t > r) {
                r = r_t;
            }

            // 当前处理的是左指针
            if (i === nl) {
                nl--;
            }

            // 当前处理的是右指针
            if (i === nr) {
                nr++;
            }
        }

        valid.push([l, r]);
    }

    // 按右端点升序排序
    valid.sort((a, b) => a[1] - b[1]);

    // 贪心选择互不重叠的区间
    const ans = [];
    let end = -1;

    for (const [left, right] of valid) {
        if (left > end) {
            ans.push(s.substring(left, right + 1));
            end = right;
        }
    }

    return ans;
};
```

```TypeScript
function maxNumOfSubstrings(s: string): string[] {
    // 记录每个字符的第一次和最后一次出现位置
    const pos = new Map<string, [number, number]>();

    for (let i = 0; i < s.length; i++) {
        const ch = s[i];
        if (!pos.has(ch)) {
            pos.set(ch, [i, i]);
        } else {
            pos.get(ch)![1] = i;
        }
    }

    // 所有合法的区间
    const valid: [number, number][] = [];

    for (const [c, range] of pos) {
        let l = range[0], r = range[1];
        let nl = l, nr = l;

        while (nl >= l || nr <= r) {
            const i = (nl >= l) ? nl : nr;

            // 当前处理的是字符 s[i]
            const l_t = pos.get(s[i])![0];
            const r_t = pos.get(s[i])![1];

            // 当前区间左侧还有该字符，需要向左扩展
            if (l_t < l) {
                l = l_t;
            }

            // 当前区间右侧还有该字符，需要向右扩展
            if (r_t > r) {
                r = r_t;
            }

            // 当前处理的是左指针
            if (i === nl) {
                nl--;
            }

            // 当前处理的是右指针
            if (i === nr) {
                nr++;
            }
        }

        valid.push([l, r]);
    }

    // 按右端点升序排序
    valid.sort((a, b) => a[1] - b[1]);

    // 贪心选择互不重叠的区间
    const ans: string[] = [];
    let end = -1;

    for (const [left, right] of valid) {
        if (left > end) {
            ans.push(s.substring(left, right + 1));
            end = right;
        }
    }

    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn max_num_of_substrings(s: String) -> Vec<String> {
        // 记录每个字符的第一次和最后一次出现位置
        let bytes = s.as_bytes();
        let mut pos: HashMap<u8, (usize, usize)> = HashMap::new();

        for (i, &ch) in bytes.iter().enumerate() {
            if !pos.contains_key(&ch) {
                pos.insert(ch, (i, i));
            } else {
                pos.get_mut(&ch).unwrap().1 = i;
            }
        }

        // 所有合法的区间
        let mut valid: Vec<(usize, usize)> = Vec::new();

        for &(l_c, r_c) in pos.values() {
            let mut l = l_c;
            let mut r = r_c;
            let mut nl = l as i32;
            let mut nr = l as i32;

            while nl >= l as i32 || nr <= r as i32 {
                let i = if nl >= l as i32 { nl as usize } else { nr as usize };

                // 当前处理的是字符 s[i]
                let current_char = bytes[i];
                let &(l_t, r_t) = pos.get(&current_char).unwrap();

                // 当前区间左侧还有该字符，需要向左扩展
                if l_t < l {
                    l = l_t;
                }

                // 当前区间右侧还有该字符，需要向右扩展
                if r_t > r {
                    r = r_t;
                }

                // 当前处理的是左指针
                if i as i32 == nl {
                    nl -= 1;
                }

                // 当前处理的是右指针
                if i as i32 == nr {
                    nr += 1;
                }
            }

            valid.push((l, r));
        }

        // 按右端点升序排序
        valid.sort_by(|a, b| a.1.cmp(&b.1));

        // 贪心选择互不重叠的区间
        let mut ans: Vec<String> = Vec::new();
        let mut end: i32 = -1;

        for (left, right) in valid {
            if left as i32 > end {
                // 使用字节切片，避免多次字符访问
                ans.push(String::from_utf8(bytes[left..right + 1].to_vec()).unwrap());
                end = right as i32;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\sum +\sum \log \sum)$，其中 $n$ 表示字符串的长度，$\sum$ 表示字符串字符集的大小。预处理每个区间的左右端点需要 $O(n\sum)$ 的时间，贪心选取需要 $O(\sum \log \sum +\sum)$ 的时间，因此总时间复杂度为 $O(n\sum +\sum \log \sum)$。
- 空间复杂度：$O(\sum)$。我们需要 $O(\sum)$ 大小的空间来记录每个字符被包含的区间的左右端点。
