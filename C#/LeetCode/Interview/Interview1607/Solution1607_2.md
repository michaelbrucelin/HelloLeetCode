#### [����˼·](https://leetcode.cn/problems/maximum-lcci/solutions/299901/li-yong-shu-xue-si-wei-de-fang-fa-by-nhan/)

����ѧ�϶��������������ֵ��������ĵ�ʽ��

$$Max(a,b)=\dfrac{|a-b|+a+b}{2}$$

�������ǿ���ʹ�����µĴ�����У�����������Ҫע����ǣ���Ϊ�ڽ��мӼ��Ĺ��������ֿ��ܻ������������½�������������ǻ�Ӧ�ý�`int`ת��Ϊ`long`����`double`����ֹ���������ͨ���ڼ��������г��ԣ���Java��C��C++�е��ٶ�������������������ģ�����ռ�ÿռ�ܵ͡�

##### ������ھ���ֵ����������˵Դ�������бȽϷ������԰Ѿ���ֵ��Ϊƽ���ٿ���������ͼ

$$|a-b|=\sqrt{(a-b)^2}$$

```cpp
// ���ܴ�һ���ƽ���ٿ����ò��������������Ϊlong�޷�������ô������ֳ˻���������Ҫ����ת���double���͡�
Math.abs(c-d)

// �������������Ĳ��־Ϳ����ˡ�
(long) Math.sqrt( 1.0 * (c-d)*(c-d) )

// �����ύ��û�г��������һ��ǲ�����double��Խ����һЩӰ�죬��ô����Math.sqrt(1.0 * (c-d)*(c-d))����ټ�һ��С�����־Ϳ����ˣ���ֹ��Ϊ������������
// ����������˵��Ӱ��Ӧ�ò��ᷢ����������Ҳ����ң�������
```

�տ�Orange��λ��������ʱ�򣬷��־���ֵ����Ҳ��Ҳû�бȽϷ��š�һ��ľ���ֵ�����������ôд�ģ�

```cpp
// ֻ˵��long��
public static long abs(long a){
    return a > 0 ? a : -a;
}
```

���ҿ���λ�������ľ���ֵ��������ôд�ģ�

```cpp
long absolute(long a) {
    int flag = a >> 63;        // ����flag = 0������flag = -1
    return (flag ^ a) - flag;  // �κ�����0���ֵ���䣬�κ�����-1���ȼ��ڰ�λȡ��
}

/*
���ߣ�OrangeMan
���ӣ�https://leetcode-cn.com/problems/maximum-lcci/solution/cjian-ji-dai-ma-by-orangeman-22/
��Դ�����ۣ�LeetCode��
����Ȩ���������С���ҵת������ϵ���߻����Ȩ������ҵת����ע��������
*/
```

����һ���ܺõĲ����ȽϷ��ŵ�д��������Ҳ��Ҳֱ����ôд������ƽ���ٿ����ˡ�

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
