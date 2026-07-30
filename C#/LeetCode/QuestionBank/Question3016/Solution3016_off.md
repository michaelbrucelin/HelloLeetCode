### [输入单词需要的最少按键次数 II](https://leetcode.cn/problems/minimum-number-of-pushes-to-type-word-ii/solutions/4000046/shu-ru-dan-ci-xu-yao-de-zui-shao-an-jian-dm72/)

#### 方法一：贪心

**思路与算法**

我们有 $8$ 个按键，每个按键上第 $k$ 个字母需要按 $k$ 次。由于字母可以重复出现，每个字母的贡献等于其按键次数乘以出现次数。为了使总按键次数最少，出现次数越多的字母应当分配到按键次数越少的位置。

因此，我们先统计每个字母的出现次数，将出现次数按从大到小排序。排序后，第 $i$ 个字母（$i$ 从 $0$ 开始计数）出现的次数为 $freq[i]$，对应的按键次数为 $\lfloor\dfrac{i}{8}\rfloor +1$，贡献为 $(\lfloor\dfrac{i}{8}\rfloor +1)\times freq[i]$，累加即为答案。

**代码**

```C++
class Solution {
public:
    int minimumPushes(string word) {
        vector<int> freq(26);
        for (char c : word) {
            ++freq[c - 'a'];
        }
        sort(freq.begin(), freq.end(), greater<int>());
        int ans = 0;
        for (int i = 0; i < 26 && freq[i] > 0; ++i) {
            ans += (i / 8 + 1) * freq[i];
        }
        return ans;
    }
};
```

```Python
class Solution:
    def minimumPushes(self, word: str) -> int:
        freq = sorted(Counter(word).values(), reverse=True)
        ans = 0
        for i, x in enumerate(freq):
            ans += (i // 8 + 1) * x
        return ans
```

```Java
class Solution {
    public int minimumPushes(String word) {
        int[] freq = new int[26];
        for (char c : word.toCharArray()) {
            freq[c - 'a']++;
        }
        Integer[] freqBoxed = Arrays.stream(freq).boxed().toArray(Integer[]::new);
        Arrays.sort(freqBoxed, Collections.reverseOrder());
        int ans = 0;
        for (int i = 0; i < 26 && freqBoxed[i] > 0; i++) {
            ans += (i / 8 + 1) * freqBoxed[i];
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinimumPushes(string word) {
        int[] freq = new int[26];
        foreach (char c in word) {
            freq[c - 'a']++;
        }
        Array.Sort(freq, (a, b) => b.CompareTo(a));
        int ans = 0;
        for (int i = 0; i < 26 && freq[i] > 0; i++) {
            ans += (i / 8 + 1) * freq[i];
        }
        return ans;
    }
}
```

```Go
func minimumPushes(word string) int {
    freq := make([]int, 26)
    for _, c := range word {
        freq[c-'a']++
    }
    sort.Slice(freq, func(i, j int) bool {
        return freq[i] > freq[j]
    })
    ans := 0
    for i := 0; i < 26 && freq[i] > 0; i++ {
        ans += (i/8 + 1) * freq[i]
    }
    return ans
}
```

```C
int cmp(const void* a, const void* b) {
    return *(int*)b - *(int*)a;
}

int minimumPushes(char* word) {
    int freq[26] = {0};
    for (int i = 0; word[i] != '\0'; i++) {
        freq[word[i] - 'a']++;
    }
    qsort(freq, 26, sizeof(int), cmp);
    int ans = 0;
    for (int i = 0; i < 26 && freq[i] > 0; i++) {
        ans += (i / 8 + 1) * freq[i];
    }
    return ans;
}
```

```JavaScript
var minimumPushes = function(word) {
    const freq = new Array(26).fill(0);
    for (const c of word) {
        freq[c.charCodeAt(0) - 97]++;
    }
    freq.sort((a, b) => b - a);
    let ans = 0;
    for (let i = 0; i < 26 && freq[i] > 0; i++) {
        ans += (Math.floor(i / 8) + 1) * freq[i];
    }
    return ans;
}
```

```TypeScript
function minimumPushes(word: string): number {
    const freq: number[] = new Array(26).fill(0);
    for (const c of word) {
        freq[c.charCodeAt(0) - 97]++;
    }
    freq.sort((a, b) => b - a);
    let ans: number = 0;
    for (let i = 0; i < 26 && freq[i] > 0; i++) {
        ans += (Math.floor(i / 8) + 1) * freq[i];
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn minimum_pushes(word: String) -> i32 {
        let mut freq = vec![0; 26];
        for c in word.chars() {
            freq[(c as u8 - b'a') as usize] += 1;
        }
        freq.sort_by(|a, b| b.cmp(a));
        let mut ans = 0;
        for i in 0..26 {
            if freq[i] == 0 {
                break;
            }
            ans += (i / 8 + 1) as i32 * freq[i];
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+\vert \sum \vert \log \vert \sum \vert)$，其中 $n$ 是字符串 $word$ 的长度，$\sum $ 是字符集，在本题中 $word$ 只包含小写字母，$\vert \sum \vert =26$。统计频率的时间为 $O(n)$，排序需要的时间为 $O(\vert \sum \vert \log \vert \sum \vert)$。
- 空间复杂度：$O(\vert \sum \vert)$，即为频率数组需要使用的空间。
