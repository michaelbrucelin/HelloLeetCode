### [字符串元音游戏](https://leetcode.cn/problems/vowels-game-in-a-string/solutions/3768699/zi-fu-chuan-yuan-yin-you-xi-by-leetcode-szex1/)

#### 方法一：贪心

**思路与算法**

由于**小红**每次移除含有**奇数**个元音字符非空子字符串，**小明**每次移除含有**偶数**个元音字符的非空子字符串，且小红与小明均采取**最优策略**，此时我们分类讨论如下：

- 若 $s$ 中没有元音字符，则**小红**在第一回合无法操作，一定输掉游戏；
- 若 $s$ 中有至少一个元音字符，那么无论总数是奇数还是偶数，小红都可以通过最优策略保证胜利；
    - 假如 $s$ 中含有**奇数**个元音字母，此时由于小红先手，第一个回合即可移除整个字符串 $s$，**小红** 赢得游戏；
    - 假如 $s$ 中含有**偶数**个元音字母，此时由于小红先手，其在第一个回合移除**奇数**个元音字符，第二回合**小明**移除**偶数**个元音字符，此时剩余**奇数**个元音字符，接下来的回合中小红移除所有字符赢得游戏；

因此我们只需检查字符串中是否存在元音字符即可。

**代码**

```C++
class Solution {
public:
    bool doesAliceWin(string s) {
        return ranges::any_of(s, [](char c) {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        });
    }
};
```

```Java
class Solution {
    public boolean doesAliceWin(String s) {
        return s.chars().anyMatch(c -> {return "aeiou".indexOf(c) != -1;});
    }
}
```

```CSharp
public class Solution {
    public bool DoesAliceWin(string s) {
        return s.Any(c => "aeiou".Contains(c));
    }
}
```

```Go
func doesAliceWin(s string) bool {
    return strings.ContainsAny(s, "aeiou")
}
```

```Python
class Solution:
    def doesAliceWin(self, s: str) -> bool:
        return any(c in "aeiou" for c in s)
```

```C
bool doesAliceWin(char* s) {
    return strpbrk(s, "aeiou") != NULL;
}
```

```JavaScript
var doesAliceWin = function(s) {
    return [...s].some(c => 'aeiou'.includes(c));
};
```

```TypeScript
function doesAliceWin(s: string): boolean {
    return [...s].some(c => 'aeiou'.includes(c));
};
```

```Rust
impl Solution {
    pub fn does_alice_win(s: String) -> bool {
        s.chars().any(|c| matches!(c, 'a' | 'e' | 'i' | 'o' | 'u'))
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，$n$ 表示给定字符串的长度。只需检测字符串 $s$ 中是否含有元音字母即可，遍历字符串需要的时间为 $O(n)$。
- 空间复杂度：$O(1)$。
