#### [û�����ף�һ��ͼ�붮����Python/Java/C++/Go��...](https://leetcode.cn/problems/minimum-swaps-to-make-strings-equal/solutions/2131832/mei-xiang-ming-bai-yi-zhang-tu-miao-dong-a6r1/)

![](./assets/img/Solution1247_3_01.png)

#### ����

**��**��Ϊʲô���ֽ������������ŵģ��費��Ҫ $s_1[i]=s_2[i]$ ����ĸ���룿

**��**�����ڲ�ͬ����ĸ�����������Ǿ������ڲ�������������ż��+ż���������ÿ�ν���������ʹ ddd ���������ǵ��β����ļ��ޣ���������+�����������ֻ���⽻����һ�ξ�ת������ż��+ż������������Ǳ�Ҫ�ġ��������ֽ����������������ÿ�ν���������Ҳ���� $s_1[i]=s_2[i]$ ����ĸ���롣

**��**��Ϊʲô����+��������һ�ξͱ����ż��+ż����

**��**������һ�κ�Ҫô $s_1$ �е� $x$ ��һ��$y$ ��һ�����ż��+ż����Ҫô $x$ ��һ��$y$ ��һ��Ҳ���ż��+ż����

```python
class Solution:
    def minimumSwap(self, s1: str, s2: str) -> int:
        cnt = Counter(x for x, y in zip(s1, s2) if x != y)
        d = cnt['x'] + cnt['y']
        return -1 if d % 2 else d // 2 + cnt['x'] % 2
```

```java
class Solution {
    public int minimumSwap(String s1, String s2) {
        int[] cnt = new int[2];
        for (int i = 0, n = s1.length(); i < n; ++i)
            if (s1.charAt(i) != s2.charAt(i))
                ++cnt[s1.charAt(i) % 2]; // x �� y ASCII ֵ�Ķ��������λ��ͬ
        int d = cnt[0] + cnt[1];
        return d % 2 != 0 ? -1 : d / 2 + cnt[0] % 2;
    }
}
```

```cpp
class Solution {
public:
    int minimumSwap(string s1, string s2) {
        int cnt[2]{};
        for (int i = 0, n = s1.length(); i < n; ++i)
            if (s1[i] != s2[i])
                ++cnt[s1[i] % 2]; // x �� y ASCII ֵ�Ķ��������λ��ͬ
        int d = cnt[0] + cnt[1];
        return d % 2 != 0 ? -1 : d / 2 + cnt[0] % 2;
    }
};
```

```go
func minimumSwap(s1, s2 string) int {
    cnt := [2]int{}
    for i, x := range s1 {
        if byte(x) != s2[i] {
            cnt[x%2]++ // 'x' �� 'y' ASCII ֵ�Ķ��������λ��ͬ
        }
    }
    d := cnt[0] + cnt[1]
    if d%2 > 0 {
        return -1
    }
    return d/2 + cnt[0]%2
}
```

#### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ $s_1$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(1)$�����õ����ɶ��������

#### ˼����

����ַ����г��������ַ���Ҫ��ô���أ�
