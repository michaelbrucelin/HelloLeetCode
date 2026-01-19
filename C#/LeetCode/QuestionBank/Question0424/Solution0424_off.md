### [替换后的最长重复字符](https://leetcode.cn/problems/longest-repeating-character-replacement/solutions/586933/ti-huan-hou-de-zui-chang-zhong-fu-zi-fu-n6aza/)

#### 方法一：双指针

我们可以枚举字符串中的每一个位置作为右端点，然后找到其最远的左端点的位置，满足该区间内除了出现次数最多的那一类字符之外，剩余的字符（即非最长重复字符）数量不超过 $k$ 个。

这样我们可以想到使用双指针维护这些区间，每次右指针右移，如果区间仍然满足条件，那么左指针不移动，否则左指针至多右移一格，保证区间长度不减小。

虽然这样的操作会导致部分区间不符合条件，即该区间内非最长重复字符超过了 $k$ 个。但是这样的区间也同样不可能对答案产生贡献。当我们右指针移动到尽头，左右指针对应的区间的长度必然对应一个长度最大的符合条件的区间。

实际代码中，由于字符串中仅包含大写字母，我们可以使用一个长度为 $26$ 的数组维护每一个字符的出现次数。每次区间右移，我们更新右移位置的字符出现的次数，然后尝试用它更新重复字符出现次数的历史最大值，最后我们使用该最大值计算出区间内非最长重复字符的数量，以此判断左指针是否需要右移即可。

**代码**

官解的Java代码解释

```Java
class Solution {
        public int characterReplacement(String s, int k) {
            int[] num = new int[26];
            int n = s.length();
            int maxn = 0;
            //left:左边界，用于滑动时减去头部或者计算长度
            //right:右边界，用于加上划窗尾巴或者计算长度
            int left = 0, right = 0;
            while (right < n) {
                int indexR = s.charAt(right) - 'A';
                num[indexR]++;
                //求窗口中曾出现某字母的最大次数
                //计算某字母出现在某窗口中的最大次数，窗口长度只能增大或者不变（注意后面left指针只移动了0-1次）
                //这样做的意义：我们求的是最长，如果找不到更长的维持长度不变返回结果不受影响
                maxn = Math.max(maxn, num[indexR]);
               
                //长度len=right-left+1,以下简称len
                //len-字母出现最大次数>替换数目 => len>字母出现最大次数+替换数目
                //分析一下，替换数目是不变的=k,字母出现最大次数是可能变化的，因此，只有字母出现最大次数增加的情况，len才能拿到最大值
                //又不满足条件的情况下，left和right一起移动,len不变的
                if (right - left + 1 - maxn > k) {
                    //这里要减的，因为left越过该点，会对最大值有影响
                    num[s.charAt(left) - 'A']--;
                    left++;
                }
                //走完这里的时候，其实right会多走一步
                right++;
            }
            //因为right多走一步，结果为(right-1)-left+1==right-left
            return right - left;
        }
}
```

```C++
class Solution {
public:
    int characterReplacement(string s, int k) {
        vector<int> num(26);
        int n = s.length();
        int maxn = 0;
        int left = 0, right = 0;
        while (right < n) {
            num[s[right] - 'A']++;
            maxn = max(maxn, num[s[right] - 'A']);
            if (right - left + 1 - maxn > k) {
                num[s[left] - 'A']--;
                left++;
            }
            right++;
        }
        return right - left;
    }
};
```

```Java
class Solution {
    public int characterReplacement(String s, int k) {
        int[] num = new int[26];
        int n = s.length();
        int maxn = 0;
        int left = 0, right = 0;
        while (right < n) {
            num[s.charAt(right) - 'A']++;
            maxn = Math.max(maxn, num[s.charAt(right) - 'A']);
            if (right - left + 1 - maxn > k) {
                num[s.charAt(left) - 'A']--;
                left++;
            }
            right++;
        }
        return right - left;
    }
}
```

```Go
func characterReplacement(s string, k int) int {
    cnt := [26]int{}
    maxCnt, left := 0, 0
    for right, ch := range s {
        cnt[ch-'A']++
        maxCnt = max(maxCnt, cnt[ch-'A'])
        if right-left+1-maxCnt > k {
            cnt[s[left]-'A']--
            left++
        }
    }
    return len(s) - left
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```

```C
int characterReplacement(char* s, int k) {
    int num[26];
    memset(num, 0, sizeof(num));
    int n = strlen(s);
    int maxn = 0;
    int left = 0, right = 0;
    while (right < n) {
        num[s[right] - 'A']++;
        maxn = fmax(maxn, num[s[right] - 'A']);
        if (right - left + 1 - maxn > k) {
            num[s[left] - 'A']--;
            left++;
        }
        right++;
    }
    return right - left;
}
```

```Python
class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        num = [0] * 26
        n = len(s)
        maxn = left = right = 0

        while right < n:
            num[ord(s[right]) - ord("A")] += 1
            maxn = max(maxn, num[ord(s[right]) - ord("A")])
            if right - left + 1 - maxn > k:
                num[ord(s[left]) - ord("A")] -= 1
                left += 1
            right += 1

        return right - left
```

```JavaScript
var characterReplacement = function(s, k) {
    const num = new Array(26).fill(0);
    const n = s.length;
    let maxn = 0, left = 0, right = 0;

    while (right < n) {
        num[s[right].charCodeAt() - 'A'.charCodeAt()]++;
        maxn = Math.max(maxn, num[s[right].charCodeAt() - 'A'.charCodeAt()])
        if (right - left + 1 - maxn > k) {
            num[s[left].charCodeAt() - 'A'.charCodeAt()]--;
            left++;
        }
        right++;
    }
    return right - left;
};
```

**时间复杂度**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串的长度。我们至多只需要遍历该字符串一次。
- 空间复杂度：$O(\vert \sum \vert)$，其中 $\vert \sum \vert$ 是字符集的大小。我们需要存储每个大写英文字母的出现次数。
