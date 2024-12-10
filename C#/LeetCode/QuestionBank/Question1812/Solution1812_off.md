### [判断国际象棋棋盘中一个格子的颜色](https://leetcode.cn/problems/determine-color-of-a-chessboard-square/solutions/2009904/pan-duan-guo-ji-xiang-qi-qi-pan-zhong-yi-8dv4/)

#### 方法一：数学

**思路**

经过观察可以发现，从左下角开始，棋盘的行数和列数（均从 $1$ 开始计数）之和如果为奇数，则为白色格子，如果和为偶数，则为黑色格子。可以根据这个结论判断格子颜色。

**代码**

```Python
class Solution:
    def squareIsWhite(self, coordinates: str) -> bool:
        return (ord(coordinates[0]) - ord('a') + 1 + int(coordinates[1])) % 2 == 1
```

```Java
class Solution {
    public boolean squareIsWhite(String coordinates) {
        return ((coordinates.charAt(0) - 'a' + 1) + (coordinates.charAt(1) - '0')) % 2 == 1;
    }
}
```

```CSharp
public class Solution {
    public bool SquareIsWhite(string coordinates) {
        return ((coordinates[0] - 'a' + 1) + (coordinates[1] - '0')) % 2 == 1;
    }
}
```

```C++
class Solution {
public:
    bool squareIsWhite(string coordinates) {
        return ((coordinates[0] - 'a' + 1) + (coordinates[1] - '0')) % 2 == 1;
    }
};
```

```C
bool squareIsWhite(char * coordinates){
    return ((coordinates[0] - 'a' + 1) + (coordinates[1] - '0')) % 2 == 1;
}
```

```JavaScript
var squareIsWhite = function(coordinates) {
    return ((coordinates[0].charCodeAt() - 'a'.charCodeAt() + 1) + (coordinates[1].charCodeAt() - '0'.charCodeAt())) % 2 === 1;
};
```

```Go
func squareIsWhite(coordinates string) bool {
    return ((coordinates[0]-'a'+1)+(coordinates[1]-'0'))%2 == 1
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。仅使用常数时间。
- 空间复杂度：$O(1)$。仅使用常数空间。
