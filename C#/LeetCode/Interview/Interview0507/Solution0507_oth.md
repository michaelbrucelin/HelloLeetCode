### [程序员面试金典 5.7：配对交换（位运算）](https://leetcode.cn/problems/exchange-lcci/solutions/1529769/by-wo-yao-chu-qu-luan-shuo-khh7/)

#### 1、思路

用`10101010`（即`0xaa`）作为掩码提取奇数位，再用`01010101`（即`0x55`）作为掩码提取偶数位；

提取奇数位后向右移到偶数位的位置，提取偶数位后向左移到奇数位的位置，进行或运算即可。

#### 2、代码

```c++
class Solution {
public:
    int exchangeBits(int num) {
        return ((num & 0xaaaaaaaa) >> 1) | ((num & 0x55555555) << 1);
    }
};
```
