#### [����һ������](https://leetcode.cn/problems/find-common-characters/solutions/445468/cha-zhao-chang-yong-zi-fu-by-leetcode-solution/)

**˼·���㷨**

������Ŀ��Ҫ������ַ� $c$ �������ַ����о������� $k$ �μ����ϣ���ô���մ�����Ҫ���� $k$ �� $c$����ˣ����ǿ���ʹ�� $minfreq[c]$ �洢�ַ� $c$ �������ַ����г��ִ�������Сֵ��

���ǿ������α���ÿһ���ַ����������Ǳ������ַ��� $s$ ʱ������ʹ�� $freq[c]$ ͳ�� $s$ ��ÿһ���ַ� $c$ ���ֵĴ�������ͳ�����֮�������ٽ�ÿһ�� $minfreq[c]$ ����Ϊ�䱾���� $freq[c]$ �Ľ�Сֵ������һ���������Ǳ����������ַ�����$minfreq[c]$ �ʹ洢���ַ� $c$ �������ַ����г��ִ�������Сֵ��

������Ŀ��֤�����е��ַ���ΪСд��ĸ��������ǿ����ó���Ϊ $26$ ������ֱ��ʾ $minfreq$ �Լ� $freq$��

�ڹ������յĴ�ʱ�����Ǳ������е�Сд��ĸ $c$������ $minfreq[c]$ �� $c$ ��ӽ������鼴�ɡ�

**����**

```cpp
class Solution {
public:
    vector<string> commonChars(vector<string>& words) {
        vector<int> minfreq(26, INT_MAX);
        vector<int> freq(26);
        for (const string& word: words) {
            fill(freq.begin(), freq.end(), 0);
            for (char ch: word) {
                ++freq[ch - 'a'];
            }
            for (int i = 0; i < 26; ++i) {
                minfreq[i] = min(minfreq[i], freq[i]);
            }
        }

        vector<string> ans;
        for (int i = 0; i < 26; ++i) {
            for (int j = 0; j < minfreq[i]; ++j) {
                ans.emplace_back(1, i + 'a');
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public List<String> commonChars(String[] words) {
        int[] minfreq = new int[26];
        Arrays.fill(minfreq, Integer.MAX_VALUE);
        for (String word : words) {
            int[] freq = new int[26];
            int length = word.length();
            for (int i = 0; i < length; ++i) {
                char ch = word.charAt(i);
                ++freq[ch - 'a'];
            }
            for (int i = 0; i < 26; ++i) {
                minfreq[i] = Math.min(minfreq[i], freq[i]);
            }
        }

        List<String> ans = new ArrayList<String>();
        for (int i = 0; i < 26; ++i) {
            for (int j = 0; j < minfreq[i]; ++j) {
                ans.add(String.valueOf((char) (i + 'a')));
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def commonChars(self, words: List[str]) -> List[str]:
        minfreq = [float("inf")] * 26
        for word in words:
            freq = [0] * 26
            for ch in word:
                freq[ord(ch) - ord("a")] += 1
            for i in range(26):
                minfreq[i] = min(minfreq[i], freq[i])
        
        ans = list()
        for i in range(26):
            ans.extend([chr(i + ord("a"))] * minfreq[i])
        return ans
```

```go
func commonChars(words []string) (ans []string) {
    minFreq := [26]int{}
    for i := range minFreq {
        minFreq[i] = math.MaxInt64
    }
    for _, word := range words {
        freq := [26]int{}
        for _, b := range word {
            freq[b-'a']++
        }
        for i, f := range freq[:] {
            if f < minFreq[i] {
                minFreq[i] = f
            }
        }
    }
    for i := byte(0); i < 26; i++ {
        for j := 0; j < minFreq[i]; j++ {
            ans = append(ans, string('a'+i))
        }
    }
    return
}
```

```c
char** commonChars(char** words, int wordsSize, int* returnSize) {
    int minfreq[26], freq[26];
    for (int i = 0; i < 26; ++i) {
        minfreq[i] = INT_MAX;
        freq[i] = 0;
    }
    for (int i = 0; i < wordsSize; ++i) {
        memset(freq, 0, sizeof(freq));
        int n = strlen(words[i]);
        for (int j = 0; j < n; ++j) {
            ++freq[words[i][j] - 'a'];
        }
        for (int j = 0; j < 26; ++j) {
            minfreq[j] = fmin(minfreq[j], freq[j]);
        }
    }

    int sum = 0;
    for (int i = 0; i < 26; ++i) {
        sum += minfreq[i];
    }

    char** ans = malloc(sizeof(char*) * sum);
    *returnSize = 0;
    for (int i = 0; i < 26; ++i) {
        for (int j = 0; j < minfreq[i]; ++j) {
            ans[*returnSize] = malloc(sizeof(char) * 2);
            ans[*returnSize][0] = i + 'a';
            ans[*returnSize][1] = 0;
            (*returnSize)++;
        }
    }
    return ans;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n(m+|\Sigma|))$������ $n$ ������ $A$ �ĳ��ȣ����ַ�������Ŀ����$m$ ���ַ�����ƽ�����ȣ�$\Sigma$ Ϊ�ַ������ڱ������ַ���Ϊ����Сд��ĸ��$|\Sigma|=26$��
    -   ���������ַ��������� $freq$ ��ʱ�临�Ӷ�Ϊ $O(nm)$��
    -   ʹ�� $freq$ ���� $minfreq$ ��ʱ�临�Ӷ�Ϊ $O(n|\Sigma|)$��
    -   �������մ𰸰������ַ��������ᳬ����̵��ַ������ȣ���˹������մ𰸵�ʱ�临�Ӷ�Ϊ $O(m+|\Sigma|)$����һ���ڽ���������С��ǰ���ߣ����Ժ��ԡ�
-   �ռ临�Ӷȣ�$O(|\Sigma|)$������ֻ����洢��֮��Ŀռ䡣����ʹ�������� $freq$ �� $minfreq$�����ǵĳ��Ⱦ�Ϊ $|\Sigma|$��
