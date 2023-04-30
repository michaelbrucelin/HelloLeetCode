#### 后缀字典

预处理`string[] words`为“后缀字典”，来加速每次输入新字符时的搜索。

以`["cd", "f", "kl", "cde", "cdef", "cdf", "ce"]`为例，构建为：
```json
{
    c: {
           d: {
                  \0: null
                  e: {
                         \0: null
                         f: {
                                \0: null
                         }
                  }
                  f: {
                         \0: null
                  }
           },
           e: {
                  \0: null
           }
    },
    f: {
           \0: null
    }
    k: {
           l: {
                  \0: null
           }
    }
}
```

下面描述怎样将`string[] words`预处理为上面形式的“后缀字典”，没找到怎样定义一个`Dictionary<char, Dictionary<char, Dictionary<char, ... ...>>>`这样的类似于嵌套递归的字典，这里直接定义一个`Dictionary<char, object>`来实现。

1. 创建一个空的“后缀字典”，`Dictionary<char, object> TailTree = new Dictionary<char, object>()`
2. 遍历`words`中的每一个`word`，并创建一个指针`ptr`指向`TailTree`
    - 这里有一个问题，就是是否应该提前把`words`去重复，这个主要取决于API中去重复时怎样实现的
3. 从后向前遍历`word`中的每一个字符`c, word[i]`
    - 如果`ptr`不包含`c`
        - 如果`c`是`word`的第`1`个字符，即`word[0]`，执行
            - `ptr.Add(c, new Dictionary<char, object>(){{'\0',null}})`
            - 回到步骤2，继续遍历下一个`word`
        - 如果`c`不是`word`的第`1`个字符，执行
            - `ptr.Add(c, new Dictionary<char, object>())`
            - `ptr = pre[c]`
            - 遍历下一个字符`word[i-1]`
    - 如果`ptr`包含`c`
         - 如果`c`是`word`的第`1`个字符，即`word[0]`
              - 如果`ptr[c]`不包含`'\0'`，`ptr[c].Add('\0',null)`
              - 如果`ptr[c]`包含`'\0'`，回到步骤2，继续遍历下一个`word`（存在重复的`word`）
         - 如果`c`不是`word`的第`1`个字符，执行
              - `ptr = pre[c]`
              - 遍历下一个字符`word[i-1]`

借助这个“后缀字典”，就可以快速的查询了。
