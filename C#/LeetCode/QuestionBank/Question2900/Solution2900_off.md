### [最长相邻不相等子序列 I](https://leetcode.cn/problems/longest-unequal-adjacent-groups-subsequence-i/solutions/3669621/zui-chang-xiang-lin-bu-xiang-deng-zi-xu-8vlf3/)

#### 方法一： 动态规划

**思路与算法**

题目要求找到 $groups$ 中**最长子序列**，该子序列中满足前后相邻元素不同。我们可以采用动态规划，设 $dp[i]$ 表示以 $i$ 为结尾的**最长子序列**的长度，此时我们可以知道序列中 $i$ 之前的元素如果为 $j$，此时一定满足 $groups[i] = groups[j],j<i$，此时如果第 $i$ 个字符串添加到第 $j$ 个字符串之后则此时 $dp[i]=dp[j]+1$，此时我们可以得到动态规划递推公式如下：

$$dp[i]=max(dp[i],dp[j]+1) \quad if \quad groups[i] =groups[j]$$

由此对于索引 $i$，我们可以枚举 $i$ 之前的所有索引，即可求得以 $i$ 为结尾的**最长子序列**的长度，此时即可找到整个数组中的**最长子序列**。为了方便计算，我们用 $prev[i]$ 记载**最长子序列**中索引 $i$ 的前一个元素 $j$。当我们找到**最长子序列**的结尾索引 $i$ 时，沿着 $i$ 往前即可找到整个序列的索引，并将每个索引对应的字符串加入到数组中，然后对整个数组反转后的结果即为答案。

**代码**

```C++
class Solution {
public:
    vector<string> getLongestSubsequence(vector<string>& words, vector<int>& groups) {
        int n = words.size();
        vector<int> dp(n, 1);
        vector<int> prev(n, -1);
        int maxLen = 1, endIndex = 0;

        for (int i = 1; i < n; i++) {
            int bestLen = 1;
            int bestPrev = -1;
            for (int j = i - 1; j >= 0; j--) {
                if (groups[i] != groups[j] && dp[j] + 1 > bestLen) {
                    bestLen = dp[j] + 1;
                    bestPrev = j;
                }
            }
            dp[i] = bestLen;
            prev[i] = bestPrev;
            if (dp[i] > maxLen) {
                maxLen = dp[i];
                endIndex = i;
            }
        }

        vector<string> res;
        for (int i = endIndex; i != -1; i = prev[i]) {
            res.emplace_back(words[i]);
        }
        reverse(res.begin(), res.end());
        return res;
    }
};
```

```Java
class Solution {
    public List<String> getLongestSubsequence(String[] words, int[] groups) {
        int n = words.length;
        int[] dp = new int[n];
        int[] prev = new int[n];
        int maxLen = 1, endIndex = 0;

        for (int i = 0; i < n; i++) {
            dp[i] = 1;
            prev[i] = -1;
        }
        for (int i = 1; i < n; i++) {
            int bestLen = 1;
            int bestPrev = -1;
            for (int j = i - 1; j >= 0; j--) {
                if (groups[i] != groups[j] && dp[j] + 1 > bestLen) {
                    bestLen = dp[j] + 1;
                    bestPrev = j;
                }
            }
            dp[i] = bestLen;
            prev[i] = bestPrev;
            if (dp[i] > maxLen) {
                maxLen = dp[i];
                endIndex = i;
            }
        }

        List<String> res = new ArrayList<>();
        for (int i = endIndex; i != -1; i = prev[i]) {
            res.add(words[i]);
        }
        Collections.reverse(res);
        return res;
    }
}
```

```CSharp
public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        int n = words.Length;
        int[] dp = new int[n];
        int[] prev = new int[n];
        int maxLen = 1, endIndex = 0;

        for (int i = 0; i < n; i++) {
            dp[i] = 1;
            prev[i] = -1;
        }
        for (int i = 1; i < n; i++) {
            int bestLen = 1;
            int bestPrev = -1;
            for (int j = i - 1; j >= 0; j--) {
                if (groups[i] != groups[j] && dp[j] + 1 > bestLen) {
                    bestLen = dp[j] + 1;
                    bestPrev = j;
                }
            }
            dp[i] = bestLen;
            prev[i] = bestPrev;
            if (dp[i] > maxLen) {
                maxLen = dp[i];
                endIndex = i;
            }
        }

        List<string> res = new List<string>();
        for (int i = endIndex; i != -1; i = prev[i]) {
            res.Add(words[i]);
        }
        res.Reverse();
        return res;
    }
}
```

```Python
class Solution:
    def getLongestSubsequence(self, words: List[str], groups: List[int]) -> List[str]:
        n = len(words)
        dp = [1] * n
        prev = [-1] * n
        max_len, end_index = 1, 0

        for i in range(1, n):
            best_len, best_prev = 1, -1
            for j in range(i - 1, -1, -1):
                if groups[i] != groups[j] and dp[j] + 1 > best_len:
                    best_len, best_prev = dp[j] + 1, j
            dp[i] = best_len
            prev[i] = best_prev
            if dp[i] > max_len:
                max_len, end_index = dp[i], i

        res = []
        i = end_index
        while i != -1:
            res.append(words[i])
            i = prev[i]
        return res[::-1]
```

```Go
func getLongestSubsequence(words []string, groups []int) []string {
    n := len(words)
    dp := make([]int, n)
    prev := make([]int, n)
    maxLen, endIndex := 1, 0

    for i := 0; i < n; i++ {
        dp[i] = 1
        prev[i] = -1
    }
    for i := 1; i < n; i++ {
        bestLen, bestPrev := 1, -1
        for j := i - 1; j >= 0; j-- {
            if groups[i] != groups[j] && dp[j] + 1 > bestLen {
                bestLen, bestPrev = dp[j] + 1, j
            }
        }
        dp[i] = bestLen
        prev[i] = bestPrev
        if dp[i] > maxLen {
            maxLen, endIndex = dp[i], i
        }
    }

    res := make([]string, 0)
    for i := endIndex; i != -1; i = prev[i] {
        res = append(res, words[i])
    }
    reverse(res)
    return res
}

func reverse(s []string) {
    for i, j := 0, len(s) - 1; i < j; i, j = i + 1, j - 1 {
        s[i], s[j] = s[j], s[i]
    }
}
```

```C
char** getLongestSubsequence(char** words, int wordsSize, int* groups, int groupsSize, int* returnSize) {
    int* dp = (int*)malloc(wordsSize * sizeof(int));
    int* prev = (int*)malloc(wordsSize * sizeof(int));
    int maxLen = 1, endIndex = 0;

    for (int i = 0; i < wordsSize; i++) {
        dp[i] = 1;
        prev[i] = -1;
    }
    for (int i = 1; i < wordsSize; i++) {
        int bestLen = 1;
        int bestPrev = -1;
        for (int j = i - 1; j >= 0; j--) {
            if (groups[i] != groups[j] && dp[j] + 1 > bestLen) {
                bestLen = dp[j] + 1;
                bestPrev = j;
            }
        }
        dp[i] = bestLen;
        prev[i] = bestPrev;
        if (dp[i] > maxLen) {
            maxLen = dp[i];
            endIndex = i;
        }
    }

    char** res = (char**)malloc(maxLen * sizeof(char*));
    int pos = 0;
    for (int i = endIndex; i != -1; i = prev[i]) {
        res[pos++] = words[i];
    }
    for (int i = 0; i < pos / 2; i++) {
        char* temp = res[i];
        res[i] = res[pos - 1 - i];
        res[pos - 1 - i] = temp;
    }
    *returnSize = pos;
    free(dp);
    free(prev);
    return res;
}
```

```JavaScript
var getLongestSubsequence = function(words, groups) {
    const n = words.length;
    const dp = new Array(n).fill(1);
    const prev = new Array(n).fill(-1);
    let maxLen = 1, endIndex = 0;

    for (let i = 1; i < n; i++) {
        let bestLen = 1;
        let bestPrev = -1;
        for (let j = i - 1; j >= 0; j--) {
            if (groups[i] !== groups[j] && dp[j] + 1 > bestLen) {
                bestLen = dp[j] + 1;
                bestPrev = j;
            }
        }
        dp[i] = bestLen;
        prev[i] = bestPrev;
        if (dp[i] > maxLen) {
            maxLen = dp[i];
            endIndex = i;
        }
    }

    const res = [];
    for (let i = endIndex; i !== -1; i = prev[i]) {
        res.push(words[i]);
    }
    return res.reverse();
};
```

```TypeScript
function getLongestSubsequence(words: string[], groups: number[]): string[] {
    const n = words.length;
    const dp: number[] = new Array(n).fill(1);
    const prev: number[] = new Array(n).fill(-1);
    let maxLen = 1, endIndex = 0;

    for (let i = 1; i < n; i++) {
        let bestLen = 1;
        let bestPrev = -1;
        for (let j = i - 1; j >= 0; j--) {
            if (groups[i] !== groups[j] && dp[j] + 1 > bestLen) {
                bestLen = dp[j] + 1;
                bestPrev = j;
            }
        }
        dp[i] = bestLen;
        prev[i] = bestPrev;
        if (dp[i] > maxLen) {
            maxLen = dp[i];
            endIndex = i;
        }
    }

    const res: string[] = [];
    for (let i = endIndex; i !== -1; i = prev[i]) {
        res.push(words[i]);
    }
    return res.reverse();
};
```

```Rust
impl Solution {
    pub fn get_longest_subsequence(words: Vec<String>, groups: Vec<i32>) -> Vec<String> {
        let n = words.len();
        let mut dp = vec![1; n];
        let mut prev = vec![-1; n];
        let mut max_len = 1;
        let mut end_index = 0;

        for i in 1..n {
            let mut best_len = 1;
            let mut best_prev = -1;
            for j in (0..i).rev() {
                if groups[i] != groups[j] && dp[j] + 1 > best_len {
                    best_len = dp[j] + 1;
                    best_prev = j as i32;
                }
            }
            dp[i] = best_len;
            prev[i] = best_prev;
            if dp[i] > max_len {
                max_len = dp[i];
                end_index = i;
            }
        }

        let mut res = Vec::new();
        let mut i = end_index as i32;
        while i != -1 {
            res.push(words[i as usize].clone());
            i = prev[i as usize];
        }
        res.reverse();
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 表示给定数组的长度。找到以索引 $i$ 为结尾的**最长子序列**的长度需要的时间为 $O(n)$，求出以每个索引为结尾的**最长子序列**长度此时需要的时间为 $O(n^2)$。
- 空间复杂度：$O(n)$。其中 $n$ 表示给定数组的长度。需要存储以每个索引为结尾的最长子序列长度，一共需要的空间为 $O(n)$。

#### 方法二： 贪心

**思路与算法**

题目要求找到 $groups$ 中**最长子序列**，该子序列中满足前后相邻元素不同。由于给定的数组 $groups$ 的元素只有 $0$ 和 $1$，此时我们只需要把数组中相邻元素相同的部分去掉，剩余的元素即为最长且不相邻的子序列。比如给定的示例 $[0,0,0,1,1,1,0,1,0,1,1,1]$，此时按照连续相同的元素进行划分为: $[[0,0,0],[1,1,1],[0],[1],[0],[1,1,1]]$，由于需要保障相邻元素不同，此时每一段相同的元素只有选取一个下标，为了保证子序列尽量长，此时每个连续相同的段都必须选择一个下标即可，同时从 $words$ 中将对应的字符串加入答案即可。

为了方便计算，此时每一个连续相同段只取最左侧的下标或者最右侧的下标即可。比如给定的数组下标分段为：

$$[[0,1,2],[3,4,5],[6],[7],[8],[9,10,11]]$$

此时我们可选择每段最左侧的下标或者最右侧的下标分别为如下：

$$[0,3,6,7,8,9] \\\\ [2,5,6,7,8,11]$$

本题解中选择每段最左侧的下标，并将该下标对应的字符串加入答案。

**代码**

```C++
class Solution {
public:
    vector<string> getLongestSubsequence(vector<string>& words, vector<int>& groups) {
        vector<string> ans;
        int n = words.size();
        for (int i = 0; i < n; i++) {
            if (i == 0 || groups[i] != groups[i - 1]) {
                ans.emplace_back(words[i]);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<String> getLongestSubsequence(String[] words, int[] groups) {
        List<String> ans = new ArrayList<>();
        int n = words.length;
        for (int i = 0; i < n; i++) {
            if (i == 0 || groups[i] != groups[i - 1]) {
                ans.add(words[i]);
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        List<string> ans = new List<string>();
        int n = words.Length;
        for (int i = 0; i < n; i++) {
            if (i == 0 || groups[i] != groups[i - 1]) {
                ans.Add(words[i]);
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def getLongestSubsequence(self, words: List[str], groups: List[int]) -> List[str]:
        return [words[0]] + [words[i] for i in range(1, len(groups)) if groups[i] != groups[i - 1]]
```

```Go
func getLongestSubsequence(words []string, groups []int) []string {
    var ans []string
    n := len(words)
    for i := 0; i < n; i++ {
        if i == 0 || groups[i] != groups[i-1] {
            ans = append(ans, words[i])
        }
    }
    return ans
}
```

```C
char** getLongestSubsequence(char** words, int wordsSize, int* groups, int groupsSize, int* returnSize) {
    char** ans = (char**)malloc(wordsSize * sizeof(char*));
    int pos = 0;
    for (int i = 0; i < wordsSize; i++) {
        if (i == 0 || groups[i] != groups[i - 1]) {
            ans[pos++] = words[i];
        }
    }
    *returnSize = pos;
    return ans;
}
```

```JavaScript
var getLongestSubsequence = function(words, groups) {
    let ans = [];
    let n = words.length;
    for (let i = 0; i < n; i++) {
        if (i === 0 || groups[i] !== groups[i - 1]) {
            ans.push(words[i]);
        }
    }
    return ans;
};
```

```TypeScript
function getLongestSubsequence(words: string[], groups: number[]): string[] {
    let ans: string[] = [];
    let n = words.length;
    for (let i = 0; i < n; i++) {
        if (i === 0 || groups[i] !== groups[i - 1]) {
            ans.push(words[i]);
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn get_longest_subsequence(words: Vec<String>, groups: Vec<i32>) -> Vec<String> {
        let mut ans = Vec::new();
        let n = words.len();
        for i in 0..n {
            if i == 0 || groups[i] != groups[i - 1] {
                ans.push(words[i].clone());
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。只需遍历数组一遍即可。
- 空间复杂度：$O(1)$。除返回值以外，不需要额外的空间。
