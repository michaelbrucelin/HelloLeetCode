#### [����һ��̰��](https://leetcode.cn/problems/minimum-swaps-to-make-strings-equal/solutions/2130292/jiao-huan-zi-fu-shi-de-zi-fu-chuan-xiang-6b1u/)

**˼·**

ͬʱ���������ַ������Ƚ���ͬ�±��£������ַ������ַ��������ͬ������±���ַ�����Ҫ���н������������ͬ���������������һ�� $s_1[i]$ Ϊ $'x'$��$s_2[i]$ Ϊ $'y'$���� $xy$ ��ʾ����������ֵĴ�������һ������� $s_1[i]$ Ϊ $'y'$��$s_2[i]$ Ϊ $'x'$���� $yx$ ��ʾ����������ֵĴ�����������Ҫͨ�����ٴ����Ľ�����ʹ�� $xy$ �� $yx$ ��Ϊ $0$�������ķ��������֣�

-   ʾ�� 1������ͨ��һ�ν�����ʹ�� $xy$ **��** $yx$ ��ֵ���� $2$��
-   ʾ�� 2������ͨ�����ν�����ʹ�� $xy$ **��** $yx$ ��ֵ������ $1$��

Ϊ��ʹ�þ������ٵĽ�����������Ҫ������˳���ǣ�

1.  ��һ�ֽ�����ʽ����Ч�ʣ�Ӧ�þ����ܲ��õ�һ�ֽ�����ʽ��
2.  �����δ��ʹ $xy$ �� $yx$ ��Ϊ $0$����Ӧ�ò��õڶ��ֽ�����ʽ��
3.  ��� $xy$ �� $yx$ ��Ϊ $1$�������ͨ�����εڶ��ֽ�������ʹ�� $xy$ �� $yx$ ��Ϊ $0$��������ʹ $xy$ �� $yx$ ��Ϊ $0$������Ҳ����Ԥ���жϣ���� $xy$ �� $yx$ ֮��Ϊ��������û�з����ܹ�ʹ���ַ�����ȡ�

**����**

```python
class Solution:
    def minimumSwap(self, s1: str, s2: str) -> int:
        xy, yx = 0, 0
        n = len(s1)
        for a, b in zip(s1, s2):
            if a == 'x' and b == 'y':
                xy += 1
            if a == 'y' and b == 'x':
                yx += 1
        if (xy + yx) % 2 == 1:
            return -1
        return xy // 2 + yx // 2 + xy % 2 + yx % 2
```

```java
class Solution {
    public int minimumSwap(String s1, String s2) {
        int xy = 0, yx = 0;
        int n = s1.length();
        for (int i = 0; i < n; i++) {
            char a = s1.charAt(i), b = s2.charAt(i);
            if (a == 'x' && b == 'y') {
                xy++;
            }
            if (a == 'y' && b == 'x') {
                yx++;
            }
        }
        if ((xy + yx) % 2 == 1) {
            return -1;
        }
        return xy / 2 + yx / 2 + xy % 2 + yx % 2;
    }
}
```

```csharp
public class Solution {
    public int MinimumSwap(string s1, string s2) {
        int xy = 0, yx = 0;
        int n = s1.Length;
        for (int i = 0; i < n; i++) {
            char a = s1[i], b = s2[i];
            if (a == 'x' && b == 'y') {
                xy++;
            }
            if (a == 'y' && b == 'x') {
                yx++;
            }
        }
        if ((xy + yx) % 2 == 1) {
            return -1;
        }
        return xy / 2 + yx / 2 + xy % 2 + yx % 2;
    }
}
```

```cpp
class Solution {
public:
    int minimumSwap(string s1, string s2) {
        int xy = 0, yx = 0;
        int n = s1.size();
        for (int i = 0; i < n; i++) {
            char a = s1[i], b = s2[i];
            if (a == 'x' and b == 'y') {
                xy++;
            }
            if (a == 'y' and b == 'x') {
                yx++;
            }
        }
        if ((xy + yx) % 2 == 1) {
            return -1;
        }
        return xy / 2 + yx / 2 + xy % 2 + yx % 2;
    }
};
```

```c
int minimumSwap(char * s1, char * s2) {
    int xy = 0, yx = 0;
    int n = strlen(s1);
    for (int i = 0; i < n; i++) {
        char a = s1[i], b = s2[i];
        if (a == 'x' && b == 'y') {
            xy++;
        }
        if (a == 'y' && b == 'x') {
            yx++;
        }
    }
    if ((xy + yx) % 2 == 1) {
        return -1;
    }
    return xy / 2 + yx / 2 + xy % 2 + yx % 2;
}
```

```javascript
var minimumSwap = function(s1, s2) {
    let xy = 0, yx = 0;
    const n = s1.length;
    for (let i = 0; i < n; i++) {
        const a = s1[i], b = s2[i];
        if (a === 'x' && b === 'y') {
            xy++;
        }
        if (a === 'y' && b === 'x') {
            yx++;
        }
    }
    if ((xy + yx) % 2 === 1) {
        return -1;
    }
    return Math.floor(xy / 2) + Math.floor(yx / 2) + xy % 2 + yx % 2;
};
```

```go
func minimumSwap(s1 string, s2 string) int {
    xy, yx := 0, 0
    n := len(s1)
    for i := 0; i < n; i++ {
        a, b := s1[i], s2[i]
        if a == 'x' && b == 'y' {
            xy++
        }
        if a == 'y' && b == 'x' {
            yx++
        }
    }
    if (xy+yx)%2 == 1 {
        return -1
    }
    return xy/2 + yx/2 + xy%2 + yx%2
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ���ַ����ĳ��ȡ���Ҫ���������ַ���һ�顣
-   �ռ临�Ӷȣ�$O(1)$��ֻ��Ҫ�����ռ䡣
