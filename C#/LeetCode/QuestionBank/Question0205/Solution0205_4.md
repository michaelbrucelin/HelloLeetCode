#### 题解

```python
class Solution:
    def isIsomorphic(self, s: str, t: str) -> bool:
        return [*map(s.index, s)] == [*map(t.index, t)]
```

-   同构代表两个字符串中每个位置上字符在自身第一次出现的索引相同

#### 细节补充

-   str 类型数据拥有内置函数 index，输入一个子字符串，可以返回子字符串在 str 中第一次出现的索引，若不存在则报错
-   map(函数，可迭代对象) 将会对（参数2：可迭代对象）中的每个元素运用（参数1：函数）并将结果按顺序储存在一个迭代器中，返回这个迭代器
-   使用 `[*……]` 可对对象解包，本题中 `[*map……]` 等效于 `list(map……)`
