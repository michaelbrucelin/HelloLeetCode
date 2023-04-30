#### [����һ����ѧ + �ݹ�](https://leetcode.cn/problems/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-lcof/solutions/176636/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-by-lee/)

**˼·**

��Ŀ�е�Ҫ����Ա���Ϊ������һ������Ϊ `n` �����У�ÿ������� `m` ��Ԫ�ز�ɾ������ô�������µ��ǵڼ���Ԫ�أ�

���������ѿ��ٸ����𰸡�����ͬʱҲҪ��������������ƺ��в��Ϊ��С�������Ǳ�ʣ��������֪������һ������ `n - 1` �����У����µ��ǵڼ���Ԫ�أ���ô���ǾͿ����ɴ˼��������Ϊ `n` �����еĴ𰸡�

**�㷨**

���ǽ��������⽨ģΪ���� `f(n, m)`���ú����ķ���ֵΪ�������µ�Ԫ�ص���š�

���ȣ�����Ϊ `n` �����л���ɾ���� `m % n` ��Ԫ�أ�Ȼ��ʣ��һ������Ϊ `n - 1` �����С���ô�����ǿ��Եݹ����� `f(n - 1, m)`���Ϳ���֪������ʣ�µ� `n - 1` ��Ԫ�أ����ջ����µڼ���Ԫ�أ��������Ϊ `x = f(n - 1, m)`��

��������ɾ���˵� `m % n` ��Ԫ�أ������еĳ��ȱ�Ϊ `n - 1`��������֪���� `f(n - 1, m)` ��Ӧ�Ĵ� `x` ֮������Ҳ�Ϳ���֪��������Ϊ `n` ���������һ��ɾ����Ԫ�أ�Ӧ���Ǵ� `m % n` ��ʼ���ĵ� `x` ��Ԫ�ء������ `f(n, m) = (m % n + x) % n = (m + x) % n`��

![](./assets/img/Solution0062_2_01.gif)

���ǵݹ���� `f(n, m), f(n - 1, m), f(n - 2, m), ...` ֱ���ݹ���յ� `f(1, m)`�������г���Ϊ `1` ʱ��һ��������Ψһ���Ǹ�Ԫ�أ����ı��Ϊ `0`��

����Ĵ���ʵ���������ĵݹ麯����

```cpp
class Solution {
    int f(int n, int m) {
        if (n == 1) {
            return 0;
        }
        int x = f(n - 1, m);
        return (m + x) % n;
    }
public:
    int lastRemaining(int n, int m) {
        return f(n, m);
    }
};
```

```java
class Solution {
    public int lastRemaining(int n, int m) {
        return f(n, m);
    }

    public int f(int n, int m) {
        if (n == 1) {
            return 0;
        }
        int x = f(n - 1, m);
        return (m + x) % n;
    }
}
```

```python
# Python Ĭ�ϵĵݹ���Ȳ�������Ҫ�ֶ�����
sys.setrecursionlimit(100000)

def f(n, m):
    if n == 0:
        return 0
    x = f(n - 1, m)
    return (m + x) % n

class Solution:
    def lastRemaining(self, n: int, m: int) -> int:
        return f(n, m)
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$����Ҫ���ĺ���ֵ�� $n$ ����
-   �ռ临�Ӷȣ�$O(n)$�������ĵݹ����Ϊ $n$����Ҫʹ�� $O(n)$ ��ջ�ռ䡣

#### [����������ѧ + ����](https://leetcode.cn/problems/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-lcof/solutions/176636/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-by-lee/)

**˼·���㷨**

����ĵݹ���Ը�дΪ����������ݹ�ʹ��ջ�ռ䡣

```cpp
class Solution {
public:
    int lastRemaining(int n, int m) {
        int f = 0;
        for (int i = 2; i != n + 1; ++i) {
            f = (m + f) % i;
        }
        return f;
    }
};
```

```java
class Solution {
    public int lastRemaining(int n, int m) {
        int f = 0;
        for (int i = 2; i != n + 1; ++i) {
            f = (m + f) % i;
        }
        return f;
    }
}
```

```python
class Solution:
    def lastRemaining(self, n: int, m: int) -> int:
        f = 0
        for i in range(2, n + 1):
            f = (m + f) % i
        return f
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$����Ҫ���ĺ���ֵ�� $n$ ����
-   �ռ临�Ӷȣ�$O(1)$��ֻʹ�ó�����������
