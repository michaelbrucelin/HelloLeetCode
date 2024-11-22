### [利用有序数组特性求解](https://leetcode.cn/problems/element-appearing-more-than-25-in-sorted-array/solutions/71711/li-yong-you-xu-shu-zu-te-xing-qiu-jie-by-user8300r/)

#### 解题思路

1. 求出 25% 对应的出现次数threshold
2. 遍历数组
3. 由于是有序数组，只需比较 当前位置 i 值和 i + threshold的值是否相等即可

#### 代码

```cpp
class Solution {
    public int findSpecialInteger(int[] arr) {
        int threshold = arr.length / 4;
        for (int i = 0; i < arr.length; i++) {
            if (arr[i + threshold] == arr[i]) {
                return arr[i];
            }
        }
        return 0;
    }
}
```
