#### [��������������ϣ](https://leetcode.cn/problems/longest-chunked-palindrome-decomposition/solutions/2219964/duan-shi-hui-wen-by-leetcode-solution-vanl/)

**˼·���㷨**

�ڡ�����һ����ʵ�ֹ����У����ǿ��Զ��ַ��� $text$ ���С�������ϣ��Ԥ���������ڶ����ַ����ж�ĳһ�����ȵ�ǰ��׺�Ƿ���ͬʱ�������� $O(1)$ ʱ��õ�ǰ��׺�Ĺ�ϣֵ�����жϡ�

**����**

```cpp
class Solution {
public:
    vector<long long> pre1, pre2;
    vector<long long> pow1, pow2;
    static constexpr int MOD1 = 1000000007;
    static constexpr int MOD2 = 1000000009;
    int Base1, Base2;

    void init(string& s) {
        mt19937 gen{random_device{}()};
        Base1 = uniform_int_distribution<int>(1e6, 1e7)(gen);
        Base2 = uniform_int_distribution<int>(1e6, 1e7)(gen);
        while (Base2 == Base1) {
            Base2 = uniform_int_distribution<int>(1e6, 1e7)(gen);
        }
        int n = s.size();
        pow1.resize(n);
        pow2.resize(n);
        pre1.resize(n + 1);
        pre2.resize(n + 1);
        pow1[0] = pow2[0] = 1;
        pre1[1] = pre2[1] = s[0];
        for (int i = 1; i < n; ++i) {
            pow1[i] = (pow1[i - 1] * Base1) % MOD1;
            pow2[i] = (pow2[i - 1] * Base2) % MOD2;
            pre1[i + 1] = (pre1[i] * Base1 + s[i]) % MOD1;
            pre2[i + 1] = (pre2[i] * Base2 + s[i]) % MOD2;
        }
    }

    pair<int, int> getHash(int l, int r) {
        return {(pre1[r + 1] - ((pre1[l] * pow1[r + 1 - l]) % MOD1) + MOD1) % MOD1, (pre2[r + 1] - ((pre2[l] * pow2[r + 1 - l]) % MOD2) + MOD2) % MOD2};
    }

    int longestDecomposition(string text) {
        init(text);
        int n = text.size();
        int res = 0;
        int l = 0, r = n - 1;
        while (l <= r) {
            int len = 1;
            while (l + len - 1 < r - len + 1) {
                if (getHash(l, l + len - 1) == getHash(r - len + 1, r)) {
                    res += 2;
                    break;
                }
                ++len;
            }
            if (l + len - 1 >= r - len + 1) {
                ++res;
            }
            l += len;
            r -= len;
        }
        return res;
    }
};
```

```java
class Solution {
    long[] pre1;
    long[] pre2;
    long[] pow1;
    long[] pow2;
    static final int MOD1 = 1000000007;
    static final int MOD2 = 1000000009;
    int base1, base2;
    Random random = new Random();

    public int longestDecomposition(String text) {
        init(text);
        int n = text.length();
        int res = 0;
        int l = 0, r = n - 1;
        while (l <= r) {
            int len = 1;
            while (l + len - 1 < r - len + 1) {
                if (Arrays.equals(getHash(l, l + len - 1), getHash(r - len + 1, r))) {
                    res += 2;
                    break;
                }
                ++len;
            }
            if (l + len - 1 >= r - len + 1) {
                ++res;
            }
            l += len;
            r -= len;
        }
        return res;
    }

    public void init(String s) {
        base1 = 1000000 + random.nextInt(9000000);
        base2 = 1000000 + random.nextInt(9000000);
        while (base2 == base1) {
            base2 = 1000000 + random.nextInt(9000000);
        }
        int n = s.length();
        pow1 = new long[n];
        pow2 = new long[n];
        pre1 = new long[n + 1];
        pre2 = new long[n + 1];
        pow1[0] = pow2[0] = 1;
        pre1[1] = pre2[1] = s.charAt(0);
        for (int i = 1; i < n; i ++) {
            pow1[i] = (pow1[i - 1] * base1) % MOD1;
            pow2[i] = (pow2[i - 1] * base2) % MOD2;
            pre1[i + 1] = (pre1[i] * base1 + s.charAt(i)) % MOD1;
            pre2[i + 1] = (pre2[i] * base2 + s.charAt(i)) % MOD2;
        }
    }

    public long[] getHash(int l, int r) {
        return new long[]{(pre1[r + 1] - ((pre1[l] * pow1[r + 1 - l]) % MOD1) + MOD1) % MOD1, (pre2[r + 1] - ((pre2[l] * pow2[r + 1 - l]) % MOD2) + MOD2) % MOD2};
    }
}
```

```csharp
public class Solution {
    long[] pre1;
    long[] pre2;
    long[] pow1;
    long[] pow2;
    const int MOD1 = 1000000007;
    const int MOD2 = 1000000009;
    int base1, base2;
    Random random = new Random();

    public int LongestDecomposition(string text) {
        Init(text);
        int n = text.Length;
        int res = 0;
        int l = 0, r = n - 1;
        while (l <= r) {
            int len = 1;
            while (l + len - 1 < r - len + 1) {
                if (Enumerable.SequenceEqual(GetHash(l, l + len - 1), GetHash(r - len + 1, r))) {
                    res += 2;
                    break;
                }
                ++len;
            }
            if (l + len - 1 >= r - len + 1) {
                ++res;
            }
            l += len;
            r -= len;
        }
        return res;
    }

    public void Init(String s) {
        base1 = 1000000 + random.Next(9000000);
        base2 = 1000000 + random.Next(9000000);
        while (base2 == base1) {
            base2 = 1000000 + random.Next(9000000);
        }
        int n = s.Length;
        pow1 = new long[n];
        pow2 = new long[n];
        pre1 = new long[n + 1];
        pre2 = new long[n + 1];
        pow1[0] = pow2[0] = 1;
        pre1[1] = pre2[1] = s[0];
        for (int i = 1; i < n; i ++) {
            pow1[i] = (pow1[i - 1] * base1) % MOD1;
            pow2[i] = (pow2[i - 1] * base2) % MOD2;
            pre1[i + 1] = (pre1[i] * base1 + s[i]) % MOD1;
            pre2[i + 1] = (pre2[i] * base2 + s[i]) % MOD2;
        }
    }

    public long[] GetHash(int l, int r) {
        return new long[]{(pre1[r + 1] - ((pre1[l] * pow1[r + 1 - l]) % MOD1) + MOD1) % MOD1, (pre2[r + 1] - ((pre2[l] * pow2[r + 1 - l]) % MOD2) + MOD2) % MOD2};
    }
}
```

```c
static int MOD1 = 1000000007;
static int MOD2 = 1000000009;

void init(const char *s, int n, long long *pre1, long long *pre2, long long *pow1, long long *pow2) {
    srand(time(NULL));
    int Base1 = 1000000 + rand() % 9000000;
    int Base2 = 1000000 + rand() % 9000000;
    while (Base2 == Base1) {
        Base2 = 1000000 + rand() % 9000000;
    }
    pow1[0] = pow2[0] = 1;
    pre1[0] = pre2[0] = 0;
    pre1[1] = pre2[1] = s[0];
    for (int i = 1; i < n; ++i) {
        pow1[i] = (pow1[i - 1] * Base1) % MOD1;
        pow2[i] = (pow2[i - 1] * Base2) % MOD2;
        pre1[i + 1] = (pre1[i] * Base1 + s[i]) % MOD1;
        pre2[i + 1] = (pre2[i] * Base2 + s[i]) % MOD2;
    }
}

long long getHash(int l, int r, long long *pre1, long long *pre2, long long *pow1, long long *pow2) {
    int x = (pre1[r + 1] - ((pre1[l] * pow1[r + 1 - l]) % MOD1) + MOD1) % MOD1;
    int y = (pre2[r + 1] - ((pre2[l] * pow2[r + 1 - l]) % MOD2) + MOD2) % MOD2;
    return (long long) x << 32 | y;
}

int longestDecomposition(char * text) {
    int n = strlen(text);
    long long pre1[n + 1], pre2[n + 1];
    long long pow1[n], pow2[n];
    init(text, n, pre1, pre2, pow1, pow2);
    int res = 0;
    int l = 0, r = n - 1;
    while (l <= r) {
        int len = 1;
        while (l + len - 1 < r - len + 1) {
            if (getHash(l, l + len - 1, pre1, pre2, pow1, pow2) == getHash(r - len + 1, r, pre1, pre2, pow1, pow2)) {
                res += 2;
                break;
            }
            ++len;
        }
        if (l + len - 1 >= r - len + 1) {
            ++res;
        }
        l += len;
        r -= len;
    }
    return res;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�ַ��� $text$ �ĳ��ȣ�Ԥ�����ַ�����ϣ��ʱ�临�Ӷ�Ϊ $O(n)$��˫ָ���ʱ�临�Ӷ�Ϊ $O(n)$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ Ϊ�ַ��� $text$ �ĳ��ȣ���ҪΪԤ�����ַ�����ϣ�Ŀռ俪����
