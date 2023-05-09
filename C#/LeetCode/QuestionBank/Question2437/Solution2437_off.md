#### [方法一：回溯](https://leetcode.cn/problems/number-of-valid-clock-times/solutions/2261803/you-xiao-shi-jian-de-shu-mu-by-leetcode-j7gqz/)

**思路与算法**

由于字符串 $time$ 中的 $'?'$ 可以被 $'0'$ 到 $'9'$ 中的任意字符替换，则依次尝试将字符串中的每个 $'?'$ 替换为 $'0'$ 到 $'9'$ 后，并检测该时间的合法性即可，此时合法的时间需要满足如下:

-   $"00" \le hh \le "23"$；
-   $"00" \le mm \le "59"$； 统计合法的时间数目并返回即可。

**代码**

```cpp
class Solution {
public:
    bool check(const string &time) {
        int hh = stoi(time);
        int mm = stoi(time.substr(3));
        if (hh < 24 && mm < 60) {
            return true;
        } else {
            return false;
        }
    }

    int countTime(string time) {
        int res = 0;
        function<void(int)> dfs = [&](int pos) {
            if (pos == time.size()) {
                if (check(time)) {
                    res++;
                }
                return;
            }
            if (time[pos] == '?') {
                for (int i = 0; i <= 9; i++) {
                    time[pos] = '0' + i;
                    dfs(pos + 1);
                    time[pos] = '?';
                }
            } else {
                dfs(pos + 1);
            }
        };
        dfs(0);
        return res;
    }
};
```

```java
class Solution {
    int res = 0;

    public int countTime(String time) {
        char[] arr = time.toCharArray();
        dfs(arr, 0);
        return res;
    }

    public void dfs(char[] arr, int pos) {
        if (pos == arr.length) {
            if (check(arr)) {
                res++;
            }
            return;
        }
        if (arr[pos] == '?') {
            for (int i = 0; i <= 9; i++) {
                arr[pos] = (char) ('0' + i);
                dfs(arr, pos + 1);
                arr[pos] = '?';
            }
        } else {
            dfs(arr, pos + 1);
        }
    }

    public boolean check(char[] arr) {
        int hh = (arr[0] - '0') * 10 + arr[1] - '0';
        int mm = (arr[3] - '0') * 10 + arr[4] - '0';
        return hh < 24 && mm < 60;
    }
}
```

```csharp
public class Solution {
    int res = 0;

    public int CountTime(string time) {
        char[] arr = time.ToCharArray();
        DFS(arr, 0);
        return res;
    }

    public void DFS(char[] arr, int pos) {
        if (pos == arr.Length) {
            if (Check(arr)) {
                res++;
            }
            return;
        }
        if (arr[pos] == '?') {
            for (int i = 0; i <= 9; i++) {
                arr[pos] = (char) ('0' + i);
                DFS(arr, pos + 1);
                arr[pos] = '?';
            }
        } else {
            DFS(arr, pos + 1);
        }
    }

    public bool Check(char[] arr) {
        int hh = (arr[0] - '0') * 10 + arr[1] - '0';
        int mm = (arr[3] - '0') * 10 + arr[4] - '0';
        return hh < 24 && mm < 60;
    }
}
```

```c
bool check(const char *time) {
    int hh = atoi(time);
    int mm = atoi(time + 3);
    if (hh < 24 && mm < 60) {
        return true;
    } else {
        return false;
    }
}

void dfs(char *time, int pos, int *res) {
    if (time[pos] == '\0') {
        if (check(time)) {
            (*res)++;
        }
        return;
    }
    if (time[pos] == '?') {
        for (int i = 0; i <= 9; i++) {
            time[pos] = '0' + i;
            dfs(time, pos + 1, res);
            time[pos] = '?';
        }
    } else {
        dfs(time, pos + 1, res);
    }
}

int countTime(char * time){
    int res = 0;
    dfs(time, 0, &res);
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(|\Sigma|^4)$，其中 $|\Sigma|$ 表示字符集的大小，在此字符 $|\Sigma| = 10$。我们依次枚举 $'?'$ 所有替换数字的方案，最多替换替换 $4$ 个 $'?'$，因此时间复杂度为 $O(|\Sigma|^4)$。
-   空间复杂度：$O(1)$。由于题目给定数目的现在，递归深度最多为 $4$，因此空间复杂度为 $O(1)$。
