### [到目标字符串的最短距离](https://leetcode.cn/problems/shortest-distance-to-target-string-in-a-circular-array/solutions/3942987/dao-mu-biao-zi-fu-chuan-de-zui-duan-ju-c-0nso/)

#### 方法一：遍历

**思路与算法**

题目要求从 $startIndex$ 开始，可以用 $1$ 步移动到下一个或者前一个单词，需要返回到达目标字符串 $target$ 所需的最短距离。我们直接遍历字符串数组 $words$，找到与 $target$ 相同的字符串 $words[i]$，此时 $startIndex$ 到 $i$ 的最短距离为 $min(\vert i-startIndex\vert ,n-\vert i-startIndex\vert)$，其中 $n$ 表示字符串数组 $words$ 的长度，找到最小的最短距离即为答案。

**代码**

```C++
class Solution {
public:
    int closestTarget(vector<string>& words, string target, int startIndex) {
        int ans = words.size();
        int n = words.size();

        for (int i = 0; i < n; ++i) {
            if (words[i] == target) {
                int dist = abs(i - startIndex);
                ans = min(ans, min(dist, n - dist));
            }
        }

        return ans < n ? ans : -1;
    }
};
```

```Java
class Solution {
    public int closestTarget(String[] words, String target, int startIndex) {
        int ans = words.length;
        int n = words.length;

        for (int i = 0; i < n; ++i) {
            if (words[i].equals(target)) {
                int dist = Math.abs(i - startIndex);
                ans = Math.min(ans, Math.min(dist, n - dist));
            }
        }

        return ans < n ? ans : -1;
    }
}
```

```CSharp
public class Solution {
    public int ClosestTarget(string[] words, string target, int startIndex) {
        int ans = words.Length;
        int n = words.Length;

        for (int i = 0; i < n; ++i) {
            if (words[i] == target) {
                int dist = Math.Abs(i - startIndex);
                ans = Math.Min(ans, Math.Min(dist, n - dist));
            }
        }

        return ans < n ? ans : -1;
    }
}
```

```Go
func closestTarget(words []string, target string, startIndex int) int {
    ans := len(words)
    n := len(words)

    for i, word := range words {
        if word == target {
            dist := abs(i - startIndex)
            ans = min(ans, min(dist, n - dist))
        }
    }

    if ans < n {
        return ans
    }
    return -1
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```Python
class Solution:
    def closestTarget(self, words: List[str], target: str, startIndex: int) -> int:
        ans = n = len(words)
        for i, word in enumerate(words):
            if word == target:
                ans = min(ans, abs(i - startIndex), n - abs(i - startIndex))
        return ans if ans < n else -1
```

```C
int closestTarget(char** words, int wordsSize, char* target, int startIndex) {
    int ans = wordsSize;
    int n = wordsSize;

    for (int i = 0; i < wordsSize; ++i) {
        if (strcmp(words[i], target) == 0) {
            int dist = abs(i - startIndex);
            ans = fmin(ans, fmin(dist, n - dist));
        }
    }

    return ans < n ? ans : -1;
}
```

```JavaScript
var closestTarget = function(words, target, startIndex) {
    let ans = words.length;
    const n = words.length;

    for (let i = 0; i < n; ++i) {
        if (words[i] === target) {
            const dist = Math.abs(i - startIndex);
            ans = Math.min(ans, Math.min(dist, n - dist));
        }
    }

    return ans < n ? ans : -1;
};
```

```TypeScript
function closestTarget(words: string[], target: string, startIndex: number): number {
    let ans = words.length;
    const n = words.length;

    for (let i = 0; i < n; ++i) {
        if (words[i] === target) {
            const dist = Math.abs(i - startIndex);
            ans = Math.min(ans, Math.min(dist, n - dist));
        }
    }

    return ans < n ? ans : -1;
};
```

```Rust
impl Solution {
    pub fn closest_target(words: Vec<String>, target: String, start_index: i32) -> i32 {
        let n = words.len() as i32;
        let mut ans = n;
        let mut found = false;

        for (i, word) in words.iter().enumerate() {
            if word == &target {
                let dist = (i as i32 - start_index).abs();
                let distance = dist.min(n - dist);
                ans = ans.min(distance)
            }
        }

        if ans < n {
            ans
        } else {
            -1
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nL)$，其中 $n$ 表示给定数组 $words$ 的长度，$L$ 表示字符串 $target$ 的长度。遍历字符串需要 $O(n)$ 的时间，每次比较两个字符串是否相等，最多需要 $O(L)$ 的时间，因此总的时间复杂度为 $O(nL)$。
- 空间复杂度：$O(1)$。
