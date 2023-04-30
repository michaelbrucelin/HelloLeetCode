#### 贪心

本质上就是将`str1`中的字符按顺序插入到`str2`中。
不需要再考虑将`str2`中的字符按顺序插入到`str1`中，`{str2}{str1}{str2}{str1}{str2}`既是将`str1`中的字符按顺序插入到`str2`中，也是将`str2`中的字符按顺序插入到`str1`中。
**需要同时考虑将`str1`中的字符按顺序插入到`str2`中，与将`str2`中的字符按顺序插入到`str1`中**

##### 结论
假定结果是`result`，很容易得出下面的结论
1. `result.Length <= str1.Length + str2.Length`
2. `result.Length >= Max(str1.Length, str2.Length)`

##### 代码步骤
这里以`str1 = "cbbadddbc", str2 = "bccddbabbdbbdddc"`为例来说明
```C
1. 从前向后遍历str1中的每一个字符str1[i]，首先是str1[0] = c
2. 找到str2中第一个c的位置，并找出最长的子序列：
    bccddbab  bdbbdddc
     c   b b  adddbc
    这里为了快速在str2中找到下一个字符char的位置，或者快速知道后面没有字符char了，可以预处理str2中每一个字符的每一个位置Dictionary<char, List<int>>
3. 前面部分可以合并为bccddbab，后面的部分可以重新执行步骤2，注意第一部分是不可能匹配的，否则上一步会继续向后匹配
    b  dbbdd  dc
    a  d  dd  bc
4. 前面的部分可以合并为ba + dbbdd，后面的部分可以重新执行步骤2
    d  c
    b  c
5. 合并后的结果是db + c
6. 遍历str1[0]的最终结果是：bccddbab + ba + dbbdd + db + c
7. 继续遍历str1[1..-1]
```

还是以以`str1 = "cbbadddbc", str2 = "bccddbabbdbbdddc"`为例，这样说明更容易理解
```C
1. 初始化结果为空字符串""
2. 从前向后遍历str1中的每一个字符str1[i]
3. 首先是i=0，str1[0] = c
4. 将str1[0..i]之前的字符放到结果中
5. 
    - 找到str2中第一个c的位置
        - 将str2中c之前（含c）的字符放到结果中："bc"
    - str1下一个字符是b，找到str2中c之后第一个b的位置
        - 将str2中c之前（含b）的字符放到结果中："bccddb"
    - str1下一个字符是b，找到str2中b之后第一个b的位置
        - 将str2中b之前（含b）的字符放到结果中："bccddbab"
    - str1下一个字符是a，找到str2中b之后不存在a
        - 向结果中添加a                       "bccddbaba"
    - str1下一个字符是d，找到str2中b之后第一个d的位置
        - ... ...
    - ... ...
6. 如果str1到了结束位置，将str2剩余的部分添加到结果中
   如果str2到了结束位置，将str1剩余的部分添加到结果中
7. 回到步骤3，令i=1，再来一次
```
