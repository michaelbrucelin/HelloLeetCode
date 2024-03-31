### [[Python3/Java/C++/Go/TypeScript] 一题一解：栈（清晰题解）](https://leetcode.cn/problems/verify-preorder-serialization-of-a-binary-tree/solutions/2716508/python3javacgotypescript-yi-ti-yi-jie-zh-mqy9/)

### 方法一：栈

我们将字符串 `preorder` 按逗号分割成数组，然后遍历数组，如果遇到了连续两个 `'#'`，并且第三个元素不是 `'#'`，那么就将这三个元素替换成一个 `'#'`，这个过程一直持续到数组遍历结束。

最后，判断数组长度是否为 $1$，且数组唯一的元素是否为 `'#'` 即可。

```python
class Solution:
    def isValidSerialization(self, preorder: str) -> bool:
        stk = []
        for c in preorder.split(","):
            stk.append(c)
            while len(stk) > 2 and stk[-1] == stk[-2] == "#" and stk[-3] != "#":
                stk = stk[:-3]
                stk.append("#")
        return len(stk) == 1 and stk[0] == "#"
```

```java
class Solution {
    public boolean isValidSerialization(String preorder) {
        List<String> stk = new ArrayList<>();
        for (String s : preorder.split(",")) {
            stk.add(s);
            while (stk.size() >= 3 && stk.get(stk.size() - 1).equals("#")
                && stk.get(stk.size() - 2).equals("#") && !stk.get(stk.size() - 3).equals("#")) {
                stk.remove(stk.size() - 1);
                stk.remove(stk.size() - 1);
                stk.remove(stk.size() - 1);
                stk.add("#");
            }
        }
        return stk.size() == 1 && stk.get(0).equals("#");
    }
}
```

```c++
class Solution {
public:
    bool isValidSerialization(string preorder) {
        vector<string> stk;
        stringstream ss(preorder);
        string s;
        while (getline(ss, s, ',')) {
            stk.push_back(s);
            while (stk.size() >= 3 && stk[stk.size() - 1] == "#" && stk[stk.size() - 2] == "#" && stk[stk.size() - 3] != "#") {
                stk.pop_back();
                stk.pop_back();
                stk.pop_back();
                stk.push_back("#");
            }
        }
        return stk.size() == 1 && stk[0] == "#";
    }
};
```

```go
func isValidSerialization(preorder string) bool {
    stk := []string{}
    for _, s := range strings.Split(preorder, ",") {
        stk = append(stk, s)
        for len(stk) >= 3 && stk[len(stk)-1] == "#" && stk[len(stk)-2] == "#" && stk[len(stk)-3] != "#" {
            stk = stk[:len(stk)-3]
            stk = append(stk, "#")
        }
    }
    return len(stk) == 1 && stk[0] == "#"
}
```

```typescript
function isValidSerialization(preorder: string): boolean {
    const stk: string[] = [];
    for (const s of preorder.split(',')) {
        stk.push(s);
        while (stk.length >= 3 && stk.at(-1) === '#' && stk.at(-2) === '#' && stk.at(-3) !== '#') {
            stk.splice(-3, 3, '#');
        }
    }
    return stk.length === 1 && stk[0] === '#';
}
```

时间复杂度 $O(n)$，空间复杂度 $O(n)$。其中 $n$ 为字符串 `preorder` 的长度。
