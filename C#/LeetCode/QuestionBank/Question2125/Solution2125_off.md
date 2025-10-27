### [银行中的激光束数量](https://leetcode.cn/problems/number-of-laser-beams-in-a-bank/solutions/1190217/yin-xing-zhong-de-ji-guang-shu-shu-liang-ad02/)

#### 方法一：直接计数

**思路与算法**

根据题目的要求，对于两个不同的行 $r_1$ 和 $r_2 (r_1<r_2)$，如果它们恰好是相邻的两行（即 $r_1+1=r_2$），或者它们之间的所有行都全为 $0$，那么第 $r_1$ 行的任意一个安全设备与第 $r_2$ 行的任意一个安全设备之间都有激光束。

因此，我们只需要统计每一行的安全设备个数，记为 $cnt$，以及上一个不全为 $0$ 的行的安全设备个数，记为 $last$。那么 $cnt\times last$ 即为激光束的个数。我们对所有的行进行遍历，维护 $cnt$ 和 $last$ 并对 $cnt\times last$ 进行累加，即可得到激光束的总数量。

**代码**

```C++
class Solution {
public:
    int numberOfBeams(vector<string>& bank) {
        int last = 0, ans = 0;
        for (const string& line: bank) {
            int cnt = count_if(line.begin(), line.end(), [](char ch) {return ch == '1';});
            if (cnt != 0) {
                ans += last * cnt;
                last = cnt;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def numberOfBeams(self, bank: List[str]) -> int:
        last = ans = 0
        for line in bank:
            cnt = line.count("1")
            if cnt != 0:
                ans += last * cnt
                last = cnt
        return ans
```

```Java
class Solution {
    public int numberOfBeams(String[] bank) {
        int last = 0, ans = 0;
        for (String line : bank) {
            int cnt = (int) line.chars().filter(ch -> ch == '1').count();
            if (cnt != 0) {
                ans += last * cnt;
                last = cnt;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfBeams(string[] bank) {
        int last = 0, ans = 0;
        foreach (string line in bank) {
            int cnt = line.Count(ch => ch == '1');
            if (cnt != 0) {
                ans += last * cnt;
                last = cnt;
            }
        }
        return ans;
    }
}
```

```Go
func numberOfBeams(bank []string) int {
    last, ans := 0, 0
    for _, line := range bank {
        cnt := strings.Count(line, "1")
        if cnt != 0 {
            ans += last * cnt
            last = cnt
        }
    }
    return ans
}
```

```C
int numberOfBeams(char** bank, int bankSize) {
    int last = 0, ans = 0;
    for (int i = 0; i < bankSize; i++) {
        int cnt = 0;
        for (int j = 0; bank[i][j] != '\0'; j++) {
            if (bank[i][j] == '1') {
                cnt++;
            }
        }
        if (cnt != 0) {
            ans += last * cnt;
            last = cnt;
        }
    }
    return ans;
}
```

```JavaScript
var numberOfBeams = function(bank) {
    let last = 0, ans = 0;
    for (const line of bank) {
        const cnt = (line.match(/1/g) || []).length;
        if (cnt !== 0) {
            ans += last * cnt;
            last = cnt;
        }
    }
    return ans;
};
```

```TypeScript
function numberOfBeams(bank: string[]): number {
    let last = 0, ans = 0;
    for (const line of bank) {
        const cnt = (line.match(/1/g) || []).length;
        if (cnt !== 0) {
            ans += last * cnt;
            last = cnt;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_beams(bank: Vec<String>) -> i32 {
        let mut last = 0;
        let mut ans = 0;
        for line in bank {
            let cnt = line.chars().filter(|&c| c == '1').count() as i32;
            if cnt != 0 {
                ans += last * cnt;
                last = cnt;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$。
- 空间复杂度：$O(1)$。
