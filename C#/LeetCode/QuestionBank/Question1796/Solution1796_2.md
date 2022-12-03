#### [方法二：位运算](https://leetcode.cn/problems/second-largest-digit-in-a-string/solutions/2003417/by-lcbin-hgty/)

我们可以用一个整数 mask 来标识字符串中出现的数字，其中 mask 的第 i 位表示数字 i 是否出现过。

遍历字符串 s，如果当前字符是数字，我们将其转换为数字 v，将 mask 的第 v 个二进制位的值置为 1。

最后，我们从高位向低位遍历 mask，找到第二个为 1 的二进制位，其对应的数字即为第二大数字。如果不存在第二大数字，返回 −1。

```python
class Solution:
    def secondHighest(self, s: str) -> int:
        mask = reduce(or_, (1 << int(c) for c in s if c.isdigit()), 0)
        cnt = 0
        for i in range(9, -1, -1):
            if (mask >> i) & 1:
                cnt += 1
            if cnt == 2:
                return i
        return -1
```

```java
class Solution {
    public int secondHighest(String s) {
        int mask = 0;
        for (int i = 0; i < s.length(); ++i) {
            char c = s.charAt(i);
            if (Character.isDigit(c)) {
                mask |= 1 << (c - '0');
            }
        }
        for (int i = 9, cnt = 0; i >= 0; --i) {
            if (((mask >> i) & 1) == 1 && ++cnt == 2) {
                return i;
            }
        }
        return -1;
    }
}
```

```cpp
class Solution {
public:
    int secondHighest(string s) {
        int mask = 0;
        for (char& c : s) if (isdigit(c)) mask |= 1 << c - '0';
        for (int i = 9, cnt = 0; ~i; --i) if (mask >> i & 1 && ++cnt == 2) return i;
        return -1;
    }
};
```

```go
func secondHighest(s string) int {
	mask := 0
	for _, c := range s {
		if c >= '0' && c <= '9' {
			mask |= 1 << int(c-'0')
		}
	}
	for i, cnt := 9, 0; i >= 0; i-- {
		if mask>>i&1 == 1 {
			cnt++
			if cnt == 2 {
				return i
			}
		}
	}
	return -1
}
```

时间复杂度 O(n)，空间复杂度 O(1)。其中 n 为字符串 s 的长度。
