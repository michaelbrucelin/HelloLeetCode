#### 双指针

使用双指针可以解决这个问题，下面简述一下步骤。

1. 如果字符串的长度为$1$，结果必然为$true$
2. 如果字符串的长度$>1$，那么有$4$种可能的字符串：
    1. 字符串$a$本身就是一个回文串
    2. 字符串$b$本身就是一个回文串
    3. 字符串$a_{prefix} + b_{suffix}$是一个回文串
    4. 字符串$b_{prefix} + a_{suffix}$是一个回文串
    5. 无论上述哪种可能，都可以使用首尾两个指针从中间向两边扩散来解决，这里选择从中间向两边扩散当然也可以从两边向中间逼近

##### 示例1

`a="xycbdbcaz", b="abyyyyyyx"`
**分析：** 这里字符串`a`从中间向两边扩散，得到最长的回文串是`cbdbc`，此时字符串`a`自身不是回文串，那么检查其后缀`az`与字符串`b`对应的前缀`ab`，不构成回文串，再检查其前缀`xy`与字符串`b`对应的后缀`yx`，发现构成回文串，所以结果为$true$。

##### 示例2

`a = "ulacfd", b = "jizalu"`
**分析：** 这里字符串`a`从中间向两边扩散，得到最长的回文串是`""`，此时字符串`a`自身不是回文串，那么检查其后缀`cfd`与字符串`b`对应的前缀`jiz`，不构成回文串，再检查其前缀`ula`与字符串`b`对应的后缀`alu`，发现构成回文串，所以结果为$true$。