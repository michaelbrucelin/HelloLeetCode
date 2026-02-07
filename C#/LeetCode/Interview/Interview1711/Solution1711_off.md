### [单词距离](https://leetcode.cn/problems/find-closest-lcci/solutions/1501485/dan-ci-ju-chi-by-leetcode-solution-u96o/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：一次遍历

最直观的做法是遍历数组 $words$，对于数组中的每个 $word_1$，遍历数组 $words$ 找到每个 $word_2$ 并计算距离。该做法在最坏情况下的时间复杂度是 $O(n^2)$，需要优化。

为了降低时间复杂度，需要考虑其他的做法。从左到右遍历数组 $words$，当遍历到 $word_1$ 时，如果已经遍历的单词中存在 $word_2$，为了计算最短距离，应该取最后一个已经遍历到的 $word_2$ 所在的下标，计算和当前下标的距离。同理，当遍历到 $word_2$ 时，应该取最后一个已经遍历到的 $word_1$ 所在的下标，计算和当前下标的距离。

基于上述分析，可以遍历数组一次得到最短距离，将时间复杂度降低到 $O(n)$。

用 $index_1$ 和 $index_2$ 分别表示数组 $words$ 已经遍历的单词中的最后一个 $word_1$ 的下标和最后一个 $word_2$ 的下标，初始时 $index_1=index_2=-1$。遍历数组 $words$，当遇到 $word_1$ 或 $word_2$ 时，执行如下操作：

1. 如果遇到 $word_1$，则将 $index_1$ 更新为当前下标；如果遇到 $word_2$，则将 $index_2$ 更新为当前下标。
2. 如果 $index_1$ 和 $index_2$ 都非负，则计算两个下标的距离 $\vert index_1-index_2\vert $，并用该距离更新最短距离。

遍历结束之后即可得到 $word_1$ 和 $word_2$ 的最短距离。

```Python
class Solution:
    def findClosest(self, words: List[str], word1: str, word2: str) -> int:
        ans = len(words)
        index1, index2 = -1, -1
        for i, word in enumerate(words):
            if word == word1:
                index1 = i
            elif word == word2:
                index2 = i
            if index1 >= 0 and index2 >= 0:
                ans = min(ans, abs(index1 - index2))
        return ans
```

```Java
class Solution {
    public int findClosest(String[] words, String word1, String word2) {
        int length = words.length;
        int ans = length;
        int index1 = -1, index2 = -1;
        for (int i = 0; i < length; i++) {
            String word = words[i];
            if (word.equals(word1)) {
                index1 = i;
            } else if (word.equals(word2)) {
                index2 = i;
            }
            if (index1 >= 0 && index2 >= 0) {
                ans = Math.min(ans, Math.abs(index1 - index2));
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int FindClosest(string[] words, string word1, string word2) {
        int length = words.Length;
        int ans = length;
        int index1 = -1, index2 = -1;
        for (int i = 0; i < length; i++) {
            string word = words[i];
            if (word.Equals(word1)) {
                index1 = i;
            } else if (word.Equals(word2)) {
                index2 = i;
            }
            if (index1 >= 0 && index2 >= 0) {
                ans = Math.Min(ans, Math.Abs(index1 - index2));
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int findClosest(vector<string>& words, string word1, string word2) {
        int length = words.size();
        int ans = length;
        int index1 = -1, index2 = -1;
        for (int i = 0; i < length; i++) {
            string word = words[i];
            if (words[i] == word1) {
                index1 = i;
            } else if (words[i] == word2) {
                index2 = i;
            }
            if (index1 >= 0 && index2 >= 0) {
                ans = min(ans, abs(index1 - index2));
            }
        }
        return ans;
    }
};
```

```C
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int shortestDistance(char ** wordsDict, int wordsDictSize, char * word1, char * word2){
    int ans = wordsDictSize;
    int index1 = -1, index2 = -1;
    for (int i = 0; i < wordsDictSize; i++) {
        if (strcmp(wordsDict[i], word1) == 0) {
            index1 = i;
        } else if (strcmp(wordsDict[i], word2) == 0) {
            index2 = i;
        }
        if (index1 >= 0 && index2 >= 0) {
            ans = MIN(ans, abs(index1 - index2));
        }
    }
    return ans;
}
```

```JavaScript
var findClosest = function(words, word1, word2) {
    const length = words.length;
    let ans = length;
    let index1 = -1, index2 = -1;
    for (let i = 0; i < length; i++) {
        const word = words[i];
        if (word === word1) {
            index1 = i;
        } else if (word === word2) {
            index2 = i;
        }
        if (index1 >= 0 && index2 >= 0) {
            ans = Math.min(ans, Math.abs(index1 - index2));
        }
    }
    return ans;
};
```

```Go
func findClosest(words []string, word1, word2 string) int {
    ans := len(words)
    index1, index2 := -1, -1
    for i, word := range words {
        if word == word1 {
            index1 = i
        } else if word == word2 {
            index2 = i
        }
        if index1 >= 0 && index2 >= 0 {
            ans = min(ans, abs(index1-index2))
        }
    }
    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $words$ 的长度。需要遍历数组一次计算 $word_1$ 和 $word_2$ 的最短距离，每次更新下标和更新最短距离的时间都是 $O(1)$。这里将字符串的长度视为常数。
- 空间复杂度：$O(1)$。

#### 进阶问题

如果寻找过程在这个文件中会重复多次，而每次寻找的单词不同，则可以维护一个哈希表记录每个单词的下标列表。遍历一次文件，按照下标递增顺序得到每个单词在文件中出现的所有下标。在寻找单词时，只要得到两个单词的下标列表，使用双指针遍历两个下标链表，即可得到两个单词的最短距离。
