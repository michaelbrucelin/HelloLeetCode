### [统计打字方案数](https://leetcode.cn/problems/count-number-of-texts/solutions/1538660/tong-ji-da-zi-fang-an-shu-by-leetcode-so-714a/)

#### 方法一：动态规划

**思路与算法**

我们可以将字符串分解为多个部分，每个部分由相同的字符组成，且相邻两个部分的字符不一样。那么，根据乘法原理，构成文字信息的总方案数等于这些部分各自对应方案数的**乘积**。

而对于某个特定字符组成的子串，其方案数仅与**子串的长度**和**字符对应的字母种类数**有关。我们用 $dp_4[i]$ 表示连续 $i$ 个对应 $4$ 个字母的字符（即 $‘7’$ 或 $‘9’$）组成子串对应的方案数，用 $dp_3[i]$ 表示连续 $i$ 个对应 $3$ 个字母的字符（即其余字符）组成子串对应的方案数。

我们以 $dp_3[i]$ 为例构造转移方程。对于 $3$ 个字母的按键，对应字母字符串的末尾字符可能有三种情况，分别对应按 $1,2,3$ 次的情况。那么，我们可以得到如下的转移方程（为了方便起见，当 $i<0$ 时 $dp_3[i]=0$；当 $i=0$ 时，由于空字符串也是一种方案，因此 $dp_3[0]=1$，下同）：

$$dp_3[i]=（dp_3[i-1]+dp_3[i-2]+dp_3[i-3]）mod(10^9+7).$$

注意由于我们需要将结果对 $10^9+7$ 取余，因此我们可以提前对数组元素进行取模处理。

同理，对于 $4$ 个字母的按键，我们也可以类似地构造转移方程：

$$dp_4[i]=(dp_4[i-1]+dp_4[i-2]+dp_4[i-3]+dp_4[i-4]）mod(10^9+7).$$

我们用 $n$ 表示字符串 $pressedKeys$，为了方便计算，我们可以预处理并用数组保存 $[0,n]$ 闭区间内的 $dp_4$ 与 $dp_3$ 数组。随后，我们遍历字符串 $pressedKeys$ 计算总方案数。

具体地，我们用 $res$ 表示总方案数，$res$ 的初值为 $1$。随后，我们从左至右遍历字符串，并统计当前字符连续出现的次数 $cnt$。每当我们遍历到与前一个字符不一样的新字符，此时说明我们刚刚遍历完成长度为 $cnt$ 的相同字符子串，我们就根据前一个字符的数值将 $res$ 乘上对应的 $dp_4[cnt]$ 或 $dp_3[cnt]$ 并对 $10^9+7$ 取余。最终，我们还需要对最后一段相同字符组成的子串进行计算并更新 $res$。当上述操作完成后，我们返回 $res$ 作为答案。

**细节**

由于计算的中间值可能超过 $32$ 位有符号整数的上界，因此我们可以考虑用 $64$ 位整数保存 $res$ 以及 $dp_4$ 与 $dp_3$ 数组的元素。

**代码**

```C++
class Solution {
public:
    int countTexts(string pressedKeys) {
        int m = 1000000007;
        vector<long long> dp3 = {1, 1, 2, 4};   // 连续按多次 3 个字母按键对应的方案数
        vector<long long> dp4 = {1, 1, 2, 4};   // 连续按多次 4 个字母按键对应的方案数
        int n = pressedKeys.size();
        for (int i = 4; i < n + 1; ++i) {
            dp3.push_back((dp3[i-1] + dp3[i-2] + dp3[i-3]) % m);
            dp4.push_back((dp4[i-1] + dp4[i-2] + dp4[i-3] + dp4[i-4]) % m);
        }
        long long res = 1;   // 总方案数
        int cnt = 1;   // 当前字符连续出现的次数
        for (int i = 1; i < n; ++i) {
            if (pressedKeys[i] == pressedKeys[i-1]) {
                ++cnt;
            } else {
                // 对按键对应字符数量讨论并更新总方案数
                if (pressedKeys[i-1] == '7' || pressedKeys[i-1] == '9') {
                    res *= dp4[cnt];
                } else {
                    res *= dp3[cnt];
                }
                res %= m;
                cnt = 1;
            }
        }
        // 更新最后一段连续字符子串对应的方案数
        if (pressedKeys[n-1] == '7' || pressedKeys[n-1] == '9') {
            res *= dp4[cnt];
        } else {
            res *= dp3[cnt];
        }
        res %= m;
        return res;
    }
};
```

```Python
class Solution:
    def countTexts(self, pressedKeys: str) -> int:
        m = 10 ** 9 + 7
        dp3 = [1, 1, 2, 4]   # 连续按多次 3 个字母按键对应的方案数
        dp4 = [1, 1, 2, 4]   # 连续按多次 4 个字母按键对应的方案数
        n = len(pressedKeys)
        for i in range(4, n + 1):
            dp3.append((dp3[i-1] + dp3[i-2] + dp3[i-3]) % m)
            dp4.append((dp4[i-1] + dp4[i-2] + dp4[i-3] + dp4[i-4]) % m)
        res = 1   # 总方案数
        cnt = 1   # 当前字符连续出现的次数
        for i in range(1, n):
            if pressedKeys[i] == pressedKeys[i-1]:
                cnt += 1
            else:
                # 对按键对应字符数量讨论并更新总方案数
                if pressedKeys[i-1] in "79":
                    res *= dp4[cnt]
                else:
                    res *= dp3[cnt]
                res %= m
                cnt = 1
        # 更新最后一段连续字符子串对应的方案数
        if pressedKeys[-1] in "79":
            res *= dp4[cnt]
        else:
            res *= dp3[cnt]
        res %= m
        return res
```

```C
int countTexts(char* pressedKeys) {
    int m = 1000000007;
    int n = strlen(pressedKeys);
    long long dp3[100001] = {1, 1, 2, 4};   // 连续按多次 3 个字母按键对应的方案数
    long long dp4[100001] = {1, 1, 2, 4};   // 连续按多次 4 个字母按键对应的方案数
    for (int i = 4; i <= n; ++i) {
        dp3[i] = (dp3[i-1] + dp3[i-2] + dp3[i-3]) % m;
        dp4[i] = (dp4[i-1] + dp4[i-2] + dp4[i-3] + dp4[i-4]) % m;
    }
    long long res = 1;   // 总方案数
    int cnt = 1;   // 当前字符连续出现的次数
    for (int i = 1; i < n; ++i) {
        if (pressedKeys[i] == pressedKeys[i-1]) {
            ++cnt;
        } else {
            // 对按键对应字符数量讨论并更新总方案数
            if (pressedKeys[i-1] == '7' || pressedKeys[i-1] == '9') {
                res = (res * dp4[cnt]) % m;
            } else {
                res = (res * dp3[cnt]) % m;
            }
            cnt = 1;
        }
    }
    // 更新最后一段连续字符子串对应的方案数
    if (pressedKeys[n-1] == '7' || pressedKeys[n-1] == '9') {
        res = (res * dp4[cnt]) % m;
    } else {
        res = (res * dp3[cnt]) % m;
    }
    return res;
}
```

```Go
func countTexts(pressedKeys string) int {
    m := 1000000007
    n := len(pressedKeys)
    dp3 := []int{1, 1, 2, 4} // 连续按多次 3 个字母按键对应的方案数
    dp4 := []int{1, 1, 2, 4} // 连续按多次 4 个字母按键对应的方案数
    for i := 4; i <= n; i++ {
        dp3 = append(dp3, (dp3[i - 1] + dp3[i - 2] + dp3[i - 3]) % m)
        dp4 = append(dp4, (dp4[i - 1] + dp4[i - 2] + dp4[i - 3] + dp4[i - 4]) % m)
    }
    res := 1 // 总方案数
    cnt := 1 // 当前字符连续出现的次数
    for i := 1; i < n; i++ {
        if pressedKeys[i] == pressedKeys[i - 1] {
            cnt++
        } else {
            // 对按键对应字符数量讨论并更新总方案数
            if pressedKeys[i - 1] == '7' || pressedKeys[i - 1] == '9' {
                res = (res * dp4[cnt]) % m
            } else {
                res = (res * dp3[cnt]) % m
            }
            cnt = 1
        }
    }
    // 更新最后一段连续字符子串对应的方案数
    if pressedKeys[n - 1] == '7' || pressedKeys[n - 1] == '9' {
        res = (res * dp4[cnt]) % m
    } else {
        res = (res * dp3[cnt]) % m
    }
    return res
}
```

```Java
public class Solution {
    public int countTexts(String pressedKeys) {
        int m = 1000000007;
        int n = pressedKeys.length();
        List<Long> dp3 = new ArrayList<>(Arrays.asList(1L, 1L, 2L, 4L));   // 连续按多次 3 个字母按键对应的方案数
        List<Long> dp4 = new ArrayList<>(Arrays.asList(1L, 1L, 2L, 4L));   // 连续按多次 4 个字母按键对应的方案数
        for (int i = 4; i <= n; ++i) {
            dp3.add((dp3.get(i-1) + dp3.get(i-2) + dp3.get(i-3)) % m);
            dp4.add((dp4.get(i-1) + dp4.get(i-2) + dp4.get(i-3) + dp4.get(i-4)) % m);
        }
        long res = 1;   // 总方案数
        int cnt = 1;   // 当前字符连续出现的次数
        for (int i = 1; i < n; ++i) {
            if (pressedKeys.charAt(i) == pressedKeys.charAt(i-1)) {
                ++cnt;
            } else {
                // 对按键对应字符数量讨论并更新总方案数
                if (pressedKeys.charAt(i-1) == '7' || pressedKeys.charAt(i-1) == '9') {
                    res = (res * dp4.get(cnt)) % m;
                } else {
                    res = (res * dp3.get(cnt)) % m;
                }
                cnt = 1;
            }
        }
        // 更新最后一段连续字符子串对应的方案数
        if (pressedKeys.charAt(n-1) == '7' || pressedKeys.charAt(n-1) == '9') {
            res = (res * dp4.get(cnt)) % m;
        } else {
            res = (res * dp3.get(cnt)) % m;
        }
        return (int) res;
    }
}
```

```CSharp
using System;
using System.Collections.Generic;

public class Solution {
    public int CountTexts(string pressedKeys) {
        int m = 1000000007;
        int n = pressedKeys.Length;
        List<long> dp3 = new List<long> {1, 1, 2, 4};   // 连续按多次 3 个字母按键对应的方案数
        List<long> dp4 = new List<long> {1, 1, 2, 4};   // 连续按多次 4 个字母按键对应的方案数
        for (int i = 4; i <= n; ++i) {
            dp3.Add((dp3[i-1] + dp3[i-2] + dp3[i-3]) % m);
            dp4.Add((dp4[i-1] + dp4[i-2] + dp4[i-3] + dp4[i-4]) % m);
        }
        long res = 1;   // 总方案数
        int cnt = 1;   // 当前字符连续出现的次数
        for (int i = 1; i < n; ++i) {
            if (pressedKeys[i] == pressedKeys[i-1]) {
                ++cnt;
            } else {
                // 对按键对应字符数量讨论并更新总方案数
                if (pressedKeys[i-1] == '7' || pressedKeys[i-1] == '9') {
                    res = (res * dp4[cnt]) % m;
                } else {
                    res = (res * dp3[cnt]) % m;
                }
                cnt = 1;
            }
        }
        // 更新最后一段连续字符子串对应的方案数
        if (pressedKeys[n-1] == '7' || pressedKeys[n-1] == '9') {
            res = (res * dp4[cnt]) % m;
        } else {
            res = (res * dp3[cnt]) % m;
        }
        return (int) res;
    }
}
```

```JavaScript
var countTexts = function(pressedKeys) {
    const m = 1000000007;
    const n = pressedKeys.length;
    const dp3 = [1, 1, 2, 4]; // 连续按多次 3 个字母按键对应的方案数
    const dp4 = [1, 1, 2, 4]; // 连续按多次 4 个字母按键对应的方案数
    for (let i = 4; i <= n; i++) {
        dp3.push((dp3[i - 1] + dp3[i - 2] + dp3[i - 3]) % m);
        dp4.push((dp4[i - 1] + dp4[i - 2] + dp4[i - 3] + dp4[i - 4]) % m);
    }
    let res = BigInt(1); // 总方案数
    let cnt = 1; // 当前字符连续出现的次数
    for (let i = 1; i < n; i++) {
        if (pressedKeys[i] === pressedKeys[i - 1]) {
            cnt++;
        } else {
            // 对按键对应字符数量讨论并更新总方案数
            if (pressedKeys[i - 1] === '7' || pressedKeys[i - 1] === '9') {
                res = (res * BigInt(dp4[cnt])) % BigInt(m);
            } else {
                res = (res * BigInt(dp3[cnt])) % BigInt(m);
            }
            cnt = 1;
        }
    }
    // 更新最后一段连续字符子串对应的方案数
    if (pressedKeys[n - 1] === '7' || pressedKeys[n - 1] === '9') {
        res = (res * BigInt(dp4[cnt])) % BigInt(m);
    } else {
        res = (res * BigInt(dp3[cnt])) % BigInt(m);
    }
    return Number(res);
};
```

```TypeScript
function countTexts(pressedKeys: string): number {
    const m = 1000000007;
    const n = pressedKeys.length;
    const dp3: number[] = [1, 1, 2, 4]; // 连续按多次 3 个字母按键对应的方案数
    const dp4: number[] = [1, 1, 2, 4]; // 连续按多次 4 个字母按键对应的方案数
    for (let i = 4; i <= n; i++) {
        dp3.push((dp3[i - 1] + dp3[i - 2] + dp3[i - 3]) % m);
        dp4.push((dp4[i - 1] + dp4[i - 2] + dp4[i - 3] + dp4[i - 4]) % m);
    }
    let res = BigInt(1); // 总方案数
    let cnt = 1; // 当前字符连续出现的次数
    for (let i = 1; i < n; i++) {
        if (pressedKeys[i] === pressedKeys[i - 1]) {
            cnt++;
        } else {
            // 对按键对应字符数量讨论并更新总方案数
            if (pressedKeys[i - 1] === '7' || pressedKeys[i - 1] === '9') {
                res = (res * BigInt(dp4[cnt])) % BigInt(m);
            } else {
                res = (res * BigInt(dp3[cnt])) % BigInt(m);
            }
            cnt = 1;
        }
    }
    // 更新最后一段连续字符子串对应的方案数
    if (pressedKeys[n - 1] === '7' || pressedKeys[n - 1] === '9') {
        res = (res * BigInt(dp4[cnt])) % BigInt(m);
    } else {
        res = (res * BigInt(dp3[cnt])) % BigInt(m);
    }
    return Number(res);
}
```

```Rust
impl Solution {
    pub fn count_texts(pressed_keys: String) -> i32 {
        let m = 1000000007;
        let n = pressed_keys.len();
        let mut dp3 = vec![1, 1, 2, 4]; // 连续按多次 3 个字母按键对应的方案数
        let mut dp4 = vec![1, 1, 2, 4]; // 连续按多次 4 个字母按键对应的方案数
        for i in 4..=n {
            dp3.push((dp3[i - 1] + dp3[i - 2] + dp3[i - 3]) % m);
            dp4.push((dp4[i - 1] + dp4[i - 2] + dp4[i - 3] + dp4[i - 4]) % m);
        }
        let mut res = 1i64; // 总方案数
        let mut cnt = 1; // 当前字符连续出现的次数
        let pressed_keys: Vec<char> = pressed_keys.chars().collect();
        for i in 1..n {
            if pressed_keys[i] == pressed_keys[i - 1] {
                cnt += 1;
            } else {
                // 对按键对应字符数量讨论并更新总方案数
                if pressed_keys[i - 1] == '7' || pressed_keys[i - 1] == '9' {
                    res = (res * dp4[cnt]) % m as i64;
                } else {
                    res = (res * dp3[cnt]) % m as i64;
                }
                cnt = 1;
            }
        }
        // 更新最后一段连续字符子串对应的方案数
        if pressed_keys[n - 1] == '7' || pressed_keys[n - 1] == '9' {
            res = (res * dp4[cnt]) % m as i64;
        } else {
            res = (res * dp3[cnt]) % m as i64;
        }
        res as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $pressedKeys$ 的长度。即为预处理动态规划数组与遍历字符串计算方案数的时间复杂度。
- 空间复杂度：$O(n)$，即为动态规划数组的空间开销。
