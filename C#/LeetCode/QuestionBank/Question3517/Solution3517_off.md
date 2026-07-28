### [最小回文排列 I](https://leetcode.cn/problems/smallest-palindromic-rearrangement-i/solutions/4000591/zui-xiao-hui-wen-pai-lie-i-by-leetcode-s-w50b/)

#### 方法一：排序

**思路与算法**

题目要求的是将回文串 $s$ 重排后，能得到的字典序最小的回文排列。由于回文串中心对称，且原串已经是回文串，故不管怎么重排，关于对称点左右两侧的字符构成的多重集仍和原串 $s$ 的保持完全一致。因此只要确定左半部分的排列，右半部分的排列是唯一确定的，并且无法交换左右两侧的不同字符，也无法在 $s$ 为奇数长度时将中心字符换出。

要证明这个结论，只需要回答：是否不存在这样的交换方式，使得左右两侧的字符多重集一致，却与原串的不同？

使用反证法，假设存在一种合法的回文重排方式，使得新回文串 $s^′$ 的左半部分字符多重集与原回文串 $s$ 的左半部分不同。既然多重集不同，必然存在至少一个字符 $c$，它在 $s^′$ 左半部分的出现次数 $k^′$，不等于它在 $s$ 左半部分的出现次数 $k$（即 $k^′\ne k$）。根据回文串中心对称的性质，除了可能的中心位置外，任何字符在回文串中的总出现次数必然是其在左半部分出现次数的 $2$ 倍。此时分两种情况讨论：

1. $s$ 长度为偶数时，没有中心字符。字符 $c$ 在 $s^′$ 中的总频数为 $2k^′$。但因为 $s^′$ 仅仅是 $s$ 的重排，字符 $c$ 的总频数必须守恒，即等于原串中的 $2k$。于是有 $2k^′=2k$，直接推出 $k^′=k$，与假设矛盾。
2. $s$ 长度为奇数时，有且只有一个字符在中心位置，其频次为奇数。
  - 若字符 $c$ 在 $s^′$ 中未占据中心位置：它的总频数为 $2k^′$。如果 $c$ 在原串 $s$ 中也不是中心字符，则原总频数为 $2k$，得出 $2k^′=2k$，矛盾；如果 $c$ 在原串 $s$ 中是中心字符，则原总频数为 $2k+1$，得出 $2k^′=2k+1$，奇偶性不符，矛盾。
  - 若字符 $c$ 在 $s^′$ 中占据了中心位置：它的总频数为 $2k^′+1$。同理，若 $c$ 在原串 $s$ 中不是中心字符，得出 $2k^′+1=2k$，奇偶性不符，矛盾；若 $c$ 在原串中也是中心字符，得出 $2k^′+1=2k+1$，依然推出 $k^′=k$，矛盾。

故原命题得证，此时我们可以只处理 $s$ 的前半段。要保证字典序最小，只需按字典序将 $s$ 的前半段排序，再构造出逆序的后半段即可。

**代码**

```C++
class Solution {
public:
    string smallestPalindrome(string s) {
        int len = s.length();
        int partition = len / 2;

        sort(s.begin(), s.begin() + partition);

        for (int i = 0; i < partition; ++i) {
            s[len - 1 - i] = s[i];
        }

        return s;
    }
};
```

```Go
func smallestPalindrome(s string) string {
	partition := len(s) / 2

	res := []byte(s)
	slices.Sort(res[:partition])

	for i := 0; i < partition; i++ {
		res[len(s)-1-i] = res[i]
	}

	return string(res)
}
```

```Python
class Solution:
    def smallestPalindrome(self, s: str) -> str:
        partition = len(s) // 2

        base = sorted(s[:partition])
        mid = [s[partition]] if len(s) % 2 == 1 else []
        reversed_base = base[::-1]

        return "".join(base + mid + reversed_base)

```

```Java
class Solution {
    public String smallestPalindrome(String s) {
        int len = s.length();
        int partition = len / 2;

        char[] chars = s.toCharArray();
        Arrays.sort(chars, 0, partition);

        for (int i = 0; i < partition; i++) {
            chars[len - 1 - i] = chars[i];
        }

        return new String(chars);
    }
}
```

```TypeScript
function smallestPalindrome(s: string): string {
    const partition = Math.floor(s.length / 2);

    const base = s.substring(0, partition).split("").toSorted();
    const mid = s.length % 2 === 1 ? s[partition] : "";
    const reversed = base.toReversed();

    return base.concat(mid, reversed).join("");
};
```

```JavaScript
var smallestPalindrome = function(s) {
    const partition = Math.floor(s.length / 2);

    const base = s.substring(0, partition).split("").toSorted();
    const mid = s.length % 2 === 1 ? s[partition] : "";
    const reversed = base.toReversed();

    return base.join("") + mid + reversed.join("");
};
```

```CSharp
public class Solution {
    public string SmallestPalindrome(string s) {
        return string.Create(s.Length, s, (span, str) => {
            int partition = str.Length / 2;

            str.AsSpan().CopyTo(span);
            span.Slice(0, partition).Sort();

            for (int i = 0; i < partition; i++) {
                span[span.Length - 1 - i] = span[i];
            }
        });
    }
}
```

```C
int cmp_char(const void* a, const void* b) {
    if (*(const char*)a < *(const char*)b) {
        return -1;
    }
    return *(const char*)a > *(const char*)b;
}

char* smallestPalindrome(const char* s) {
    int len = strlen(s);
    int partition = len / 2;

    char* res = (char*)malloc((len + 1) * sizeof(char));
    strcpy(res, s);
    qsort(res, partition, sizeof(char), cmp_char);

    for (int i = 0; i < partition; i++) {
        res[len - 1 - i] = res[i];
    }

    return res;
}
```

```Rust
impl Solution {
    pub fn smallest_palindrome(s: String) -> String {
        let len = s.len();
        let partition = len / 2;

        let mut res = s.into_bytes();
        res[..partition].sort_unstable();

        for i in 0..partition {
            res[len - 1 - i] = res[i];
        }

        String::from_utf8(res).unwrap()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $s$ 的长度。主导复杂度的操作是排序，平均复杂度为 $O(n\log n)$。
- 空间复杂度：$O(n)$ 或 $O(\log n)$。取决于语言实现，若为原地修改字符串，只需要排序算法所需的额外 $O(\log n)$ 辅助空间；若字符串为不可变的数据结构，则字符串切片需要额外的 $O(n)$ 的辅助空间。

#### 方法二：计数排序

**思路与算法**

考虑优化方法一的执行效率。观察到待排序元素为普通 $ASCII$ 字符，其集合离散且很小，故可以采用简化的桶排序思想，即计数排序来优化算法。

直接以字符的编码值为键，遍历字符串统计频次，再按序扫描所有的键即可完成排序。

**代码**

```C++
class Solution {
public:
    string smallestPalindrome(string s) {
        int n = s.length();
        int bucket[26] = {0};

        for (int i = 0; i < n / 2; i++) {
            bucket[s[i] - 'a']++;
        }

        int left = 0;
        int right = n - 1;

        for (int i = 0; i < 26; i++) {
            while (bucket[i] > 0) {
                char c = i + 'a';
                s[left++] = c;
                s[right--] = c;
                bucket[i]--;
            }
        }

        return s;
    }
};
```

```Go
func smallestPalindrome(s string) string {
	partition := len(s) / 2
	bucket := make([]int, 26)

	for i := 0; i < partition; i++ {
		bucket[s[i]-'a'] += 1
	}

	var leftBuilder strings.Builder
	for i := 0; i < 26; i++ {
		if bucket[i] > 0 {
			leftBuilder.WriteString(strings.Repeat(string(rune(i+'a')), bucket[i]))
		}
	}
	left := leftBuilder.String()

	mid := ""
	if len(s)%2 != 0 {
		mid = string(s[partition])
	}

	rightBytes := []byte(left)
	for i, j := 0, len(rightBytes)-1; i < j; i, j = i+1, j-1 {
		rightBytes[i], rightBytes[j] = rightBytes[j], rightBytes[i]
	}
	right := string(rightBytes)

	return left + mid + right
}
```

```Python
class Solution:
    def smallestPalindrome(self, s: str) -> str:
        partition = len(s) // 2
        bucket = [0] * 26

        for i in range(partition):
            bucket[ord(s[i]) - 97] += 1

        left = "".join([chr(i + 97) * bucket[i] for i in range(26) if bucket[i] > 0])

        mid = s[partition] if len(s) % 2 != 0 else ""
        right = left[::-1]

        return left + mid + right

```

```Java
class Solution {
    public String smallestPalindrome(String s) {
        int partition = s.length() / 2;
        int[] bucket = new int[26];

        for (int i = 0; i < partition; i++) {
            bucket[s.charAt(i) - 'a'] += 1;
        }

        StringBuilder left = new StringBuilder();
        for (int i = 0; i < 26; i++) {
            if (bucket[i] > 0) {
                left.append(String.valueOf((char) (i + 'a')).repeat(bucket[i]));
            }
        }

        String mid = s.length() % 2 != 0 ? String.valueOf(s.charAt(partition)) : "";
        String right = new StringBuilder(left).reverse().toString();

        return left.toString() + mid + right;
    }
}
```

```TypeScript
function smallestPalindrome(s: string): string {
    const partition = Math.floor(s.length / 2);
    const bucket = new Int32Array(26);

    for (let i = 0; i < partition; i++) {
        bucket[s.charCodeAt(i) - 97] += 1;
    }

    let left = "", right = "";
    for (let i = 0; i < 26; i++) {
        if (bucket[i] > 0) {
            left += String.fromCharCode(i + 97).repeat(bucket[i]);
            right = String.fromCharCode(i + 97).repeat(bucket[i]) + right;
        }
    }

    const mid = s.length % 2 !== 0 ? s[partition] : "";

    return left + mid + right;
}
```

```JavaScript
var smallestPalindrome = function (s) {
    const partition = Math.floor(s.length / 2);
    const bucket = new Int32Array(26);

    for (let i = 0; i < partition; i++) {
        bucket[s.charCodeAt(i) - 97] += 1;
    }

    let left = "";
    let right = "";
    for (let i = 0; i < 26; i++) {
        if (bucket[i] > 0) {
            left += String.fromCharCode(i + 97).repeat(bucket[i]);
            right = String.fromCharCode(i + 97).repeat(bucket[i]) + right;
        }
    }

    const mid = s.length % 2 !== 0 ? s[partition] : "";

    return left + mid + right;
};
```

```CSharp
public class Solution {
    public string SmallestPalindrome(string s) {
        int n = s.Length;
        int[] bucket = new int[26];

        for (int i = 0; i < n / 2; i++) {
            bucket[s[i] - 'a']++;
        }

        char[] res = new char[n];
        int left = 0;
        int right = n - 1;

        for (int i = 0; i < 26; i++) {
            while (bucket[i] > 0) {
                char c = (char)(i + 'a');
                res[left++] = c;
                res[right--] = c;
                bucket[i]--;
            }
        }

        if (n % 2 != 0) {
            res[left] = s[n / 2];
        }

        return new string(res);
    }
}
```

```C
char* smallestPalindrome(const char* s) {
    int len = strlen(s);
    int partition = len / 2;
    int bucket[26] = {0};

    for (int i = 0; i < partition; i++) {
        bucket[s[i] - 'a'] += 1;
    }

    char* res = (char*)malloc(len + 1);
    int idx = 0;

    for (int i = 0; i < 26; i++) {
        if (bucket[i] > 0) {
            for (int j = 0; j < bucket[i]; j++) {
                res[idx++] = (char)(i + 'a');
            }
        }
    }

    if (len % 2 != 0) {
        res[idx++] = s[partition];
    }

    for (int i = partition - 1; i >= 0; i--) {
        res[idx++] = res[i];
    }
    res[len] = '\0';

    return res;
}
```

```rust
impl Solution {
    pub fn smallest_palindrome(s: String) -> String {
        let bytes = s.as_bytes();
        let partition = bytes.len() / 2;
        let mut bucket = [0; 26];

        for i in 0..partition {
            bucket[(bytes[i] - b'a') as usize] += 1;
        }

        let mut left = String::new();
        for i in 0..26 {
            if bucket[i] > 0 {
                left.push_str(&((i as u8 + b'a') as char).to_string().repeat(bucket[i]));
            }
        }

        let mid = if bytes.len() % 2 != 0 {
            (bytes[partition] as char).to_string()
        } else {
            String::new()
        };

        let right: String = left.chars().rev().collect();

        left + &mid + &right
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+\vert \sum \vert)$，其中 $n$ 是 $s$ 的长度，$\vert \sum \vert$ 是字符集的大小。统计频次和逆序拼接均需要 $O(n)$；构造串需要遍历字符集，用时为 $O(\vert \sum \vert)$。
- 空间复杂度：$O(\vert \sum \vert)$。只需分配 $O(\vert \sum \vert)$ 的空间给辅助数组 $bucket$ 用于排序。
