### [[JAVA]0ms 超过100% 非暴力法 时间复杂度O(log(n))](https://leetcode.cn/problems/convert-integer-to-the-sum-of-two-no-zero-integers/solutions/509530/java0ms-chao-guo-100-fei-bao-li-fa-shi-j-okmq/)

看了一圈题解，大多都是暴力法，现将我的非暴力的方法记录如下：

注意观察，题中的示例有很强的引导作用

输入：n = 11 输出：[2,9]

输入：n = 10000 输出：[1,9999]

**即可以将n转化为 99..(各位都是9，称为数字A) + 另一个数（称为数字B） 的和。**

但是需要些额外的调整，比如输入为 1099 时 得到的两个数字为 999（数字A） + 100（数字B） 此时100中有两位为0

处理方式： **数字B中的0变为1，数字A中的对应位减去1**

代码如下：

```cpp
class Solution {
    public int[] getNoZeroIntegers(int n) {
        int [] res = new int[2];
        //n <= 10 时单独讨论一下
        if(n <= 10)
        {
            res[0] = 1;
            res[1] = n - 1;
            return res;
        }

        //求数字n的十进制长度
        int length = (int)Math.log10(n);

        //数字res[0]中每一位都是9,res[1]是与res[0]互补的数
        res[0] = (int)Math.pow(10, length) - 1;
        res[1] = n - res[0];

        //判断res[1]中十进制某一位是否为0
        int temp = res[1];
        int index = 1;

        while(temp > 0)
        {
            //如果res[1]某一位为0，则res[1]该位加上1，res[0]该位减去1
            if(temp % 10 == 0)
            {
                res[0] -= index;
                res[1] += index;
            }

            index *= 10;
            temp = temp / 10;
        }

        return res;
    }
}
```
