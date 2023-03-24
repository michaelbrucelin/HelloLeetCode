#### [解题思路](https://leetcode.cn/problems/maximum-lcci/solutions/299901/li-yong-shu-xue-si-wei-de-fang-fa-by-nhan/)

在数学上对于两个数的最大值，有下面的等式：

$$Max(a,b)=\dfrac{|a-b|+a+b}{2}$$

所以我们可以使用以下的代码进行，不过我们需要注意的是，因为在进行加减的过程中数字可能会过大溢出，导致结果错误，所以我们还应该将`int`转话为`long`或者`double`来防止溢出。不过通过在几种语言中尝试，在Java，C，C++中的速度与其他语言相比是最快的，不过占用空间很低。

##### 如果对于绝对值函数有疑问说源码里面有比较符，可以把绝对值改为平方再开方。如下图

$$|a-b|=\sqrt{(a-b)^2}$$

```cpp
// 可能大家会有平方再开方得不到结果，那是因为long无法计算这么大的数字乘积，所以需要把它转变成double类型。
Math.abs(c-d)

// 用下面代替上面的部分就可以了。
(long) Math.sqrt( 1.0 * (c-d)*(c-d) )

// 我在提交后没有出错，如果大家还是不放心double会对结果有一些影响，那么就在Math.sqrt(1.0 * (c-d)*(c-d))结果再加一个小数部分就可以了，防止因为浮动产生错误
// 不过，上面说的影响应该不会发生（发生了也别怪我，哈哈）
```

刚看Orange这位大哥的题解的时候，发现绝对值函数也可也没有比较符号。一般的绝对值函数大概是这么写的：

```cpp
// 只说明long的
public static long abs(long a){
    return a > 0 ? a : -a;
}
```

但我看那位大哥的题解的绝对值函数是这么写的：

```cpp
long absolute(long a) {
    int flag = a >> 63;        // 正数flag = 0，负数flag = -1
    return (flag ^ a) - flag;  // 任何数与0异或值不变，任何数与-1异或等价于按位取反
}

/*
作者：OrangeMan
链接：https://leetcode-cn.com/problems/maximum-lcci/solution/cjian-ji-dai-ma-by-orangeman-22/
来源：力扣（LeetCode）
著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
*/
```

这是一个很好的不带比较符号的写法。所以也可也直接这么写，不用平方再开方了。

```java
class Solution {
    public int maximum(int a, int b) {
        // double c = a;
        // double d = b;
        // int res = (int) ((Math.abs(c-d) + c + d)/2);
        // return res;

        long c = a;
        long d = b;
        int res = (int) ((Math.abs(c-d) + c + d)/2);
        return res;
    }
}
```

```javascript
/**
 * @param {number} a
 * @param {number} b
 * @return {number}
 */
var maximum = function(a, b) {          
    return ((Math.abs(a-b) + a + b)/2);
};
```

```python
import math
class Solution:
    def maximum(self, a: int, b: int) -> int:
        return int((math.fabs(a-b) + a + b)/2)
```

```c
#include<math.h>

int maximum(int a, int b){
// double c = a;
        // double d = b;
        // int res = (int) ((Math.abs(c-d) + c + d)/2);
        // return res;

        long c = a;
        long d = b;
        int res = (int) ((fabs(c-d) + c + d)/2);
        return res;
}
```

```cpp
#include<math.h>

class Solution {
public:
    int maximum(int a, int b) {
        // double c = a;
        // double d = b;
        // int res = (int) ((Math.abs(c-d) + c + d)/2);
        // return res;

        long c = a;
        long d = b;
        int res = (int) ((fabs(c-d) + c + d)/2);
        return res;
    }
};
```

```php
class Solution {

    /**
     * @param Integer $a
     * @param Integer $b
     * @return Integer
     */
    function maximum($a, $b) {
        return ((abs($a-$b) + $a + $b)/2);
    }
}
```
