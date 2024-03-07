### [找出字符串的可整除数组](https://leetcode.cn/problems/find-the-divisibility-array-of-a-string/solutions/2668264/zhao-chu-zi-fu-chuan-de-ke-zheng-chu-shu-pv8v/)

#### 方法一：模运算

##### 思路与算法

一个整数可表示为 $a \times 10 + b$：

$$(a \times 10 + b) \mod m = (a \mod m \times 10 + b) \mod m$$

所以我们可以按照上面的递推式，根据当前表示整数的余数，算出包含下一位字符所表示的整数的余数。

当余数为零时即为可整除数组，否则不是。最后返回结果即可。

##### 代码

```c++
class Solution {
public:
    vector<int> divisibilityArray(string word, int m) {
        vector<int> res;
        long long cur = 0;
        for (char& c : word) {
            cur = (cur * 10 + (c - '0')) % m;
            res.push_back(cur == 0 ? 1 : 0);
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] divisibilityArray(String word, int m) {
        int[] res = new int[word.length()];
        long cur = 0;
        for (int i = 0; i < word.length(); i++) {
            char c = word.charAt(i);
            cur = (cur * 10 + (c - '0')) % m;
            res[i] = (cur == 0) ? 1 : 0;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] DivisibilityArray(string word, int m) {
        int[] res = new int[word.Length];
        long cur = 0;
        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            cur = (cur * 10 + (c - '0')) % m;
            res[i] = (cur == 0) ? 1 : 0;
        }
        return res;
    }
}
```

```python
class Solution(object):
    def divisibilityArray(self, word, m):
        cur = 0
        res = []
        for c in word:
            cur = (cur * 10 + int(c)) % m
            res.append(1 if cur == 0 else 0)
        return res
```

```javascript
var divisibilityArray = function(word, m) {
    const res = [];
    let cur = 0;
    for (const c of word) {
        cur = (cur * 10 + (c.charCodeAt(0) - '0'.charCodeAt(0))) % m;
        res.push(cur === 0 ? 1 : 0);
    }
    return res;
};
```

```typescript
function divisibilityArray(word: string, m: number): number[] {
    const res = [];
    let cur = 0;
    for (const c of word) {
        cur = (cur * 10 + (c.charCodeAt(0) - '0'.charCodeAt(0))) % m;
        res.push(cur === 0 ? 1 : 0);
    }
    return res;
};
```

```go
func divisibilityArray(word string, m int) []int {
    res := make([]int, 0)
    cur := 0
    for _, c := range word {
        cur = (cur * 10 + int(c - '0')) % m
        if cur == 0 {
            res = append(res, 1)
        } else {
            res = append(res, 0)
        }
    }
    return res
}
```

```c
int* divisibilityArray(char * word, int m, int* returnSize){
    int n = strlen(word);
    int* res = (int*)malloc(n * sizeof(int));
    long long cur = 0;
    for (int i = 0; i < n; i++) {
        cur = (cur * 10 + (word[i] - '0')) % m;
        res[i] = (cur == 0) ? 1 : 0;
    }
    *returnSize = n;
    return res;
}
```

```rust
impl Solution {
    pub fn divisibility_array(word: String, m: i32) -> Vec<i32> {
        let mut cur: i64 = 0;
        let mut m64: i64 = m.into();
        let mut res = Vec::new();
        for c in word.chars() {
            cur = (cur * 10 + (c.to_digit(10).unwrap() as i64)) % m64;
            res.push(if cur == 0 { 1 } else { 0 });
        }
        res
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是输入字符串的长度。
- 空间复杂度：$O(1)$，不计算返回结果。
