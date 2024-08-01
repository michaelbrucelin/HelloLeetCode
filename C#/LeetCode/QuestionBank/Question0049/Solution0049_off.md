### [字母异位词分组](https://leetcode.cn/problems/group-anagrams/solutions/520469/zi-mu-yi-wei-ci-fen-zu-by-leetcode-solut-gyoc/)

#### 知识速递

合理设计的哈希键能够有效地整合原始信息，找出对于解题有用的结果信息
常见哈希键设计：

- 在字符串和数组当中，当每个元素的顺序不重要时，可以使用排序后的字符串或数组作为键
- 如果只关心每个值的偏移量，例如第一个值的偏移量，则可以使用偏移量作为键
- 在树中，我们通常会用子树的序列化表述作为键

#### 前言

两个字符串互为字母异位词，当且仅当两个字符串包含的字母相同。同一组字母异位词中的字符串具备相同点，可以使用相同点作为一组字母异位词的标志，使用哈希表存储每一组字母异位词，哈希表的键为一组字母异位词的标志，哈希表的值为一组字母异位词列表。

遍历每个字符串，对于每个字符串，得到该字符串所在的一组字母异位词的标志，将当前字符串加入该组字母异位词的列表中。遍历全部字符串之后，哈希表中的每个键值对即为一组字母异位词。

以下的两种方法分别使用排序和计数作为哈希表的键。

#### 方法一：排序

由于互为字母异位词的两个字符串包含的字母相同，因此对两个字符串分别进行排序之后得到的字符串一定是相同的，故可以将排序之后的字符串作为哈希表的键。

```Java
class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {
        Map<String, List<String>> map = new HashMap<String, List<String>>();
        for (String str : strs) {
            char[] array = str.toCharArray();
            Arrays.sort(array);
            String key = new String(array);
            List<String> list = map.getOrDefault(key, new ArrayList<String>());
            list.add(str);
            map.put(key, list);
        }
        return new ArrayList<List<String>>(map.values());
    }
}
```

```JavaScript
var groupAnagrams = function(strs) {
    const map = new Map();
    for (let str of strs) {
        let array = Array.from(str);
        array.sort();
        let key = array.toString();
        let list = map.get(key) ? map.get(key) : new Array();
        list.push(str);
        map.set(key, list);
    }
    return Array.from(map.values());
};
```

```Go
func groupAnagrams(strs []string) [][]string {
    mp := map[string][]string{}
    for _, str := range strs {
        s := []byte(str)
        sort.Slice(s, func(i, j int) bool { return s[i] < s[j] })
        sortedStr := string(s)
        mp[sortedStr] = append(mp[sortedStr], str)
    }
    ans := make([][]string, 0, len(mp))
    for _, v := range mp {
        ans = append(ans, v)
    }
    return ans
}
```

```C++
class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {
        unordered_map<string, vector<string>> mp;
        for (string& str: strs) {
            string key = str;
            sort(key.begin(), key.end());
            mp[key].emplace_back(str);
        }
        vector<vector<string>> ans;
        for (auto it = mp.begin(); it != mp.end(); ++it) {
            ans.emplace_back(it->second);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        mp = collections.defaultdict(list)

        for st in strs:
            key = "".join(sorted(st))
            mp[key].append(st)
        
        return list(mp.values())
```

**复杂度分析**

- 时间复杂度：$O(nklogk)$，其中 $n$ 是 $strs$ 中的字符串的数量，$k$ 是 $strs$ 中的字符串的的最大长度。需要遍历 $n$ 个字符串，对于每个字符串，需要 $O(klogk)$ 的时间进行排序以及 $O(1)$ 的时间更新哈希表，因此总时间复杂度是 $O(nklogk)$。
- 空间复杂度：$O(nk)$，其中 $n$ 是 $strs$ 中的字符串的数量，$k$ 是 $strs$ 中的字符串的的最大长度。需要用哈希表存储全部字符串。

#### 方法二：计数

由于互为字母异位词的两个字符串包含的字母相同，因此两个字符串中的相同字母出现的次数一定是相同的，故可以将每个字母出现的次数使用字符串表示，作为哈希表的键。

由于字符串只包含小写字母，因此对于每个字符串，可以使用长度为 $26$ 的数组记录每个字母出现的次数。需要注意的是，在使用数组作为哈希表的键时，不同语言的支持程度不同，因此不同语言的实现方式也不同。

```Java
class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {
        Map<String, List<String>> map = new HashMap<String, List<String>>();
        for (String str : strs) {
            int[] counts = new int[26];
            int length = str.length();
            for (int i = 0; i < length; i++) {
                counts[str.charAt(i) - 'a']++;
            }
            // 将每个出现次数大于 0 的字母和出现次数按顺序拼接成字符串，作为哈希表的键
            StringBuffer sb = new StringBuffer();
            for (int i = 0; i < 26; i++) {
                if (counts[i] != 0) {
                    sb.append((char) ('a' + i));
                    sb.append(counts[i]);
                }
            }
            String key = sb.toString();
            List<String> list = map.getOrDefault(key, new ArrayList<String>());
            list.add(str);
            map.put(key, list);
        }
        return new ArrayList<List<String>>(map.values());
    }
}
```

```JavaScript
var groupAnagrams = function(strs) {
    const map = new Object();
    for (let s of strs) {
        const count = new Array(26).fill(0);
        for (let c of s) {
            count[c.charCodeAt() - 'a'.charCodeAt()]++;
        }
        map[count] ? map[count].push(s) : map[count] = [s];
    }
    return Object.values(map);
};
```

```Go
func groupAnagrams(strs []string) [][]string {
    mp := map[[26]int][]string{}
    for _, str := range strs {
        cnt := [26]int{}
        for _, b := range str {
            cnt[b-'a']++
        }
        mp[cnt] = append(mp[cnt], str)
    }
    ans := make([][]string, 0, len(mp))
    for _, v := range mp {
        ans = append(ans, v)
    }
    return ans
}
```

```C++
class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {
        // 自定义对 array<int, 26> 类型的哈希函数
        auto arrayHash = [fn = hash<int>{}] (const array<int, 26>& arr) -> size_t {
            return accumulate(arr.begin(), arr.end(), 0u, [&](size_t acc, int num) {
                return (acc << 1) ^ fn(num);
            });
        };

        unordered_map<array<int, 26>, vector<string>, decltype(arrayHash)> mp(0, arrayHash);
        for (string& str: strs) {
            array<int, 26> counts{};
            int length = str.length();
            for (int i = 0; i < length; ++i) {
                counts[str[i] - 'a'] ++;
            }
            mp[counts].emplace_back(str);
        }
        vector<vector<string>> ans;
        for (auto it = mp.begin(); it != mp.end(); ++it) {
            ans.emplace_back(it->second);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        mp = collections.defaultdict(list)

        for st in strs:
            counts = [0] * 26
            for ch in st:
                counts[ord(ch) - ord("a")] += 1
            # 需要将 list 转换成 tuple 才能进行哈希
            mp[tuple(counts)].append(st)
        
        return list(mp.values())
```

**复杂度分析**

- 时间复杂度：$O(n(k+\vert\sum\vert))$，其中 $n$ 是 $strs$ 中的字符串的数量，$k$ 是 $strs$ 中的字符串的的最大长度，$\sum$ 是字符集，在本题中字符集为所有小写字母，$\vert\sum\vert\=26$。需要遍历 $n$ 个字符串，对于每个字符串，需要 $O(k)$ 的时间计算每个字母出现的次数，$O(\vert\sum\vert)$ 的时间生成哈希表的键，以及 $O(1)$ 的时间更新哈希表，因此总时间复杂度是 $O(n(k+\vert\sum\vert))$。
- 空间复杂度：$O(n(k+\vert\sum\vert))$，其中 $n$ 是 $strs$ 中的字符串的数量，$k$ 是 $strs$ 中的字符串的最大长度，$\sum$ 是字符集，在本题中字符集为所有小写字母，$\vert\sum\vert\=26$。需要用哈希表存储全部字符串，而记录每个字符串中每个字母出现次数的数组需要的空间为 $O(\vert\sum\vert)$，在渐进意义下小于 $O(n(k+\vert\sum\vert))$，可以忽略不计。
