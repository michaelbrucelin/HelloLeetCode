### [判断通过操作能否让字符串相等 II](https://leetcode.cn/problems/check-if-strings-can-be-made-equal-with-operations-ii/solutions/3935434/pan-duan-tong-guo-cao-zuo-neng-fou-rang-d0twb/)

#### 方法一：哈希表

**思路与算法**

本题是[「2839. 判断通过操作能否让字符串相等 I」](https://leetcode.cn/problems/check-if-strings-can-be-made-equal-with-operations-i/)的数据升级版，我们可以将前置题目中的分类讨论推广到更一般的情况。

由简单的代数知识可以得知，按照题目给定的交换规则交换字符，被交换的字符其下标的奇偶性一定相同。这实际上暗示了对于题目给定的字符串，其字符按下标的奇偶性，可以被划分成两个平行的集合，且同集合内的字符可以任意交换顺序。因此，实际上我们只需要验证 $s_1$ 与 $s_2$ 在偶数下标集合和奇数下标集合上，对应的字符集相等（即种类和数目完全一致）即可。

有多种方法统计字符集合并判断集合相等性。除去部分语言提供的便捷方案外，朴素的做法之一是在一轮循环中同时遍历 $s_1$ 和 $s_2$，对 $s_1$ 当前下标的字符在对应集合中的频次加一；而对于 $s_2$ 当前下标的字符，则在对应集合中的频次减一。最后检验两个集合上的元素，若全归零，则说明两个字符串的奇偶集合相同，反之则不相等。

**代码**

```C++
class Solution {
public:
    bool checkStrings(string s1, string s2) {
        if (s1.length() != s2.length()) {
            return false;
        }

        int counts[256] = {0};

        for (int i = 0; i < s1.length(); i++) {
            int offset = (i & 1) << 7;
            counts[offset + s1[i]]++;
            counts[offset + s2[i]]--;
        }

        for (int i = 0; i < 256; i++) {
            if (counts[i] != 0) {
                return false;
            }
        }

        return true;
    }
};
```

```C
bool checkStrings(char* s1, char* s2) {
    int len = strlen(s1);
    if (len != strlen(s2)) {
        return false;
    }

    int counts[256] = {0};

    for (int i = 0; i < len; i++) {
        int offset = (i & 1) << 7;
        counts[offset + s1[i]]++;
        counts[offset + s2[i]]--;
    }

    for (int i = 0; i < 256; i++) {
        if (counts[i] != 0) {
            return false;
        }
    }

    return true;
}
```

```Python
class Solution:
    def checkStrings(self, s1: str, s2: str) -> bool:
        return Counter(s1[::2]) == Counter(s2[::2]) and Counter(s1[1::2]) == Counter(
            s2[1::2]
        )
```

```Java
class Solution {
    public boolean checkStrings(String s1, String s2) {
        if (s1.length() != s2.length()) {
            return false;
        }

        int[] count1 = new int[256];
        int[] count2 = new int[256];

        for (int i = 0; i < s1.length(); i++) {
            int offset = (i & 1) << 7;
            count1[offset + s1.charAt(i)]++;
            count2[offset + s2.charAt(i)]++;
        }

        return Arrays.equals(count1, count2);
    }
}
```

```CSharp
public class Solution {
    public bool CheckStrings(string s1, string s2) {
        if (s1.Length != s2.Length) {
            return false;
        }

        int[] counts = new int[256];

        for (int i = 0; i < s1.Length; i++) {
            int offset = (i & 1) << 7;
            counts[offset + s1[i]]++;
            counts[offset + s2[i]]--;
        }

        foreach (int count in counts) {
            if (count != 0) {
                return false;
            }
        }

        return true;
    }
}
```

```JavaScript
var checkStrings = function(s1, s2) {
    if (s1.length !== s2.length) {
        return false;
    }

    const counts = new Int32Array(256);

    for (let i = 0; i < s1.length; i++) {
        const offset = (i & 1) << 7;
        counts[offset + s1.charCodeAt(i)]++;
        counts[offset + s2.charCodeAt(i)]--;
    }

    for (let i = 0; i < 256; i++) {
        if (counts[i] !== 0) {
            return false;
        }
    }

    return true;
};
```

```TypeScript
function checkStrings(s1: string, s2: string): boolean {
    if (s1.length !== s2.length) {
        return false;
    }

    const counts = new Int32Array(256);

    for (let i = 0; i < s1.length; i++) {
        const offset = (i & 1) << 7;
        counts[offset + s1.charCodeAt(i)]++;
        counts[offset + s2.charCodeAt(i)]--;
    }

    for (let i = 0; i < 256; i++) {
        if (counts[i] !== 0) {
            return false;
        }
    }

    return true;
}
```

```Go
func checkStrings(s1 string, s2 string) bool {
    if len(s1) != len(s2) {
        return false
    }

    var counts [256]int

    for i := 0; i < len(s1); i++ {
        offset := (i & 1) << 7
        counts[offset+int(s1[i])]++
        counts[offset+int(s2[i])]--
    }

    for _, count := range counts {
        if count != 0 {
            return false
        }
    }

    return true
}
```

```Rust
impl Solution {
    pub fn check_strings(s1: String, s2: String) -> bool {
        if s1.len() != s2.len() {
            return false;
        }

        let mut counts = [0; 256];
        let b1 = s1.as_bytes();
        let b2 = s2.as_bytes();

        for i in 0..b1.len() {
            let offset = (i & 1) << 7;
            counts[offset + b1[i] as usize] += 1;
            counts[offset + b2[i] as usize] -= 1;
        }

        counts.iter().all(|&count| count == 0)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s_1$ 或 $s_2$ 的长度。遍历字符串需要 $O(n)$ 的时间。
- 空间复杂度：$O(k)$，其中 $k$ 是字符串所含字符集的大小，统计字符数目的集合所需的空间是 $O(k)$。
