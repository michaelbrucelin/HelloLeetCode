#### [方法二：后缀数组](https://leetcode.cn/problems/largest-merge-of-two-strings/solutions/2030226/gou-zao-zi-dian-xu-zui-da-de-he-bing-zi-g6az1/?orderBy=most_votes)

**思路与算法**

后缀数组的计算过程较为复杂，后缀数组利用了倍增的思想来比较两个后缀的大小，详细资料可以参考「[后缀数组简介](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fstring%2Fsa%2F)」以及 「[Suffix Array](https://leetcode.cn/link/?target=http%3A%2F%2Fse.moevm.info%2Flib%2Fexe%2Ffetch.php%2Fcourses%3Aalgorithms_building_and_analysis%3Aalgorithmic_challenges_2_suffix_array.pdf)」，在此不再展开描述，本题中计算后缀数组时用字符 $'*'$ 标识字符串的结尾。

此种与方法一同样的思路，我们在比较两个字符串 $word_1,word_2$ 的后缀时，直接利用后缀数组来比较两个后缀的字典序大小。在两个 $word_1$ 与 $word_2$ 的中间添加一个字符 $‘@’$ 来表示 $word_1$ 的结尾，$‘@’$ 比所有的英文字母都小，且比字符串的末尾 $‘*’$ 要大。设字符串 $word_1,word_2$ 的长度分别为 $m,n$，我们计算出合并后的字符串 $str$ 的后缀排名 $rank$，则 $word_1$ 中的第 $i$ 个后缀对应着 $str$ 的第 $i$ 个后缀，$word_2$ 中的第 $j$ 个后缀对应着 $str$ 的第 $m + 1 + j$ 个后缀。进行合并时我们可以直接比较两个字符串的后缀排序，每次选取后缀较大的进行合并即可。

**代码**

```cpp
vector<int> sortCharacters(const string & text) {
    int n = text.size();
    vector<int> count(128), order(n);
    for (auto c : text) {
        count[c]++;
    }    
    for (int i = 1; i < 128; i++) {
        count[i] += count[i - 1];
    }
    for (int i = n - 1; i >= 0; i--) {
        count[text[i]]--;
        order[count[text[i]]] = i;
    }
    return order;
}

vector<int> computeCharClasses(const string & text, vector<int> & order) {
    int n = text.size();
    vector<int> res(n, 0);
    res[order[0]] = 0;
    for (int i = 1; i < n; i++) {
        if (text[order[i]] != text[order[i - 1]]) {
            res[order[i]] = res[order[i - 1]] + 1;
        } else {
            res[order[i]] = res[order[i - 1]];
        }
    }
    return res;
}

vector<int> sortDoubled(const string & text, int len, vector<int> & order, vector<int> & classfiy) {
    int n = text.size();
    vector<int> count(n), newOrder(n);
    for (int i = 0; i < n; i++) {
        count[classfiy[i]]++;
    }
    for (int i = 1; i < n; i++) {
        count[i] += count[i - 1];
    }
    for (int i = n - 1; i >= 0; i--) {
        int start = (order[i] - len + n) % n;
        int cl = classfiy[start];
        count[cl]--;
        newOrder[count[cl]] = start;
    }
    return newOrder;
}

vector<int> updateClasses(vector<int> & newOrder, vector<int> & classfiy, int len) {
    int n = newOrder.size();
    vector<int> newClassfiy(n, 0);
    newClassfiy[newOrder[0]] = 0;
    for (int i = 1; i < n; i++) {
        int curr = newOrder[i];
        int prev = newOrder[i - 1];
        int mid = curr + len;
        int midPrev = (prev + len) % n;
        if (classfiy[curr] != classfiy[prev] || classfiy[mid] != classfiy[midPrev]) {
             newClassfiy[curr] = newClassfiy[prev] + 1;
        } else {
             newClassfiy[curr] = newClassfiy[prev];
        }
    }
    return newClassfiy;
}

vector<int> buildSuffixArray(const string& text) {
    vector<int> order = sortCharacters(text);
    vector<int> classfiy = computeCharClasses(text, order);
    int len = 1;
    int n = text.size();
    for (int i = 1; i < n; i <<= 1) {
        order = sortDoubled(text, i, order, classfiy);
        classfiy = updateClasses(order, classfiy, i);
    }
    return order;
}

class Solution {
public:
    string largestMerge(string word1, string word2) {
        int m = word1.size(), n = word2.size();
        string str = word1 + "@" + word2 + "*";
        vector<int> suffixArray = buildSuffixArray(str); 
        vector<int> rank(m + n + 2);
        for (int i = 0; i < m + n + 2; i++) {
            rank[suffixArray[i]] = i;
        }

        string merge;
        int i = 0, j = 0;
        while (i < m || j < n) {
            if (i < m && rank[i] > rank[m + 1 + j]) {
                merge.push_back(word1[i++]);
            } else {
                merge.push_back(word2[j++]);
            }
        }
        return merge;
    }
};
```

```java
class Solution {
    public String largestMerge(String word1, String word2) {
        int m = word1.length(), n = word2.length();
        String str = word1 + "@" + word2 + "*";
        int[] suffixArray = buildSuffixArray(str); 
        int[] rank = new int[m + n + 2];
        for (int i = 0; i < m + n + 2; i++) {
            rank[suffixArray[i]] = i;
        }

        StringBuilder merge = new StringBuilder();
        int i = 0, j = 0;
        while (i < m || j < n) {
            if (i < m && rank[i] > rank[m + 1 + j]) {
                merge.append(word1.charAt(i));
                i++;
            } else {
                merge.append(word2.charAt(j));
                j++;
            }
        }
        return merge.toString();
    }

    public int[] buildSuffixArray(String text) {
        int[] order = sortCharacters(text);
        int[] classfiy = computeCharClasses(text, order);
        int len = 1;
        int n = text.length();
        for (int i = 1; i < n; i <<= 1) {
            order = sortDoubled(text, i, order, classfiy);
            classfiy = updateClasses(order, classfiy, i);
        }
        return order;
    }

    public int[] sortCharacters(String text) {
        int n = text.length();
        int[] count = new int[128];
        int[] order = new int[n];
        for (int i = 0; i < n; i++) {
            char c = text.charAt(i);
            count[c]++;
        }    
        for (int i = 1; i < 128; i++) {
            count[i] += count[i - 1];
        }
        for (int i = n - 1; i >= 0; i--) {
            count[text.charAt(i)]--;
            order[count[text.charAt(i)]] = i;
        }
        return order;
    }

    public int[] computeCharClasses(String text, int[] order) {
        int n = text.length();
        int[] res = new int[n];
        res[order[0]] = 0;
        for (int i = 1; i < n; i++) {
            if (text.charAt(order[i]) != text.charAt(order[i - 1])) {
                res[order[i]] = res[order[i - 1]] + 1;
            } else {
                res[order[i]] = res[order[i - 1]];
            }
        }
        return res;
    }

    public int[] sortDoubled(String text, int len, int[]  order, int[] classfiy) {
        int n = text.length();
        int[] count = new int[n];
        int[] newOrder = new int[n];
        for (int i = 0; i < n; i++) {
            count[classfiy[i]]++;
        }
        for (int i = 1; i < n; i++) {
            count[i] += count[i - 1];
        }
        for (int i = n - 1; i >= 0; i--) {
            int start = (order[i] - len + n) % n;
            int cl = classfiy[start];
            count[cl]--;
            newOrder[count[cl]] = start;
        }
        return newOrder;
    }

    public int[] updateClasses(int[] newOrder, int[] classfiy, int len) {
        int n = newOrder.length;
        int[] newClassfiy = new int[n];
        newClassfiy[newOrder[0]] = 0;
        for (int i = 1; i < n; i++) {
            int curr = newOrder[i];
            int prev = newOrder[i - 1];
            int mid = curr + len;
            int midPrev = (prev + len) % n;
            if (classfiy[curr] != classfiy[prev] || classfiy[mid] != classfiy[midPrev]) {
                newClassfiy[curr] = newClassfiy[prev] + 1;
            } else {
                newClassfiy[curr] = newClassfiy[prev];
            }
        }
        return newClassfiy;
    }
}
```

```c#
public class Solution {
    public string LargestMerge(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        String str = word1 + "@" + word2 + "*";
        int[] suffixArray = BuildSuffixArray(str); 
        int[] rank = new int[m + n + 2];
        for (int idx = 0; idx < m + n + 2; idx++) {
            rank[suffixArray[idx]] = idx;
        }

        StringBuilder merge = new StringBuilder();
        int i = 0, j = 0;
        while (i < m || j < n) {
            if (i < m && rank[i] > rank[m + 1 + j]) {
                merge.Append(word1[i]);
                i++;
            } else {
                merge.Append(word2[j]);
                j++;
            }
        }
        return merge.ToString();
    }

    public int[] BuildSuffixArray(String text) {
        int[] order = CortCharacters(text);
        int[] classfiy = ComputeCharClasses(text, order);
        int len = 1;
        int n = text.Length;
        for (int i = 1; i < n; i <<= 1) {
            order = SortDoubled(text, i, order, classfiy);
            classfiy = UpdateClasses(order, classfiy, i);
        }
        return order;
    }

    public int[] CortCharacters(String text) {
        int n = text.Length;
        int[] count = new int[128];
        int[] order = new int[n];
        for (int i = 0; i < n; i++) {
            char c = text[i];
            count[c]++;
        }    
        for (int i = 1; i < 128; i++) {
            count[i] += count[i - 1];
        }
        for (int i = n - 1; i >= 0; i--) {
            count[text[i]]--;
            order[count[text[i]]] = i;
        }
        return order;
    }

    public int[] ComputeCharClasses(String text, int[] order) {
        int n = text.Length;
        int[] res = new int[n];
        res[order[0]] = 0;
        for (int i = 1; i < n; i++) {
            if (text[order[i]] != text[order[i - 1]]) {
                res[order[i]] = res[order[i - 1]] + 1;
            } else {
                res[order[i]] = res[order[i - 1]];
            }
        }
        return res;
    }

    public int[] SortDoubled(String text, int len, int[]  order, int[] classfiy) {
        int n = text.Length;
        int[] count = new int[n];
        int[] newOrder = new int[n];
        for (int i = 0; i < n; i++) {
            count[classfiy[i]]++;
        }
        for (int i = 1; i < n; i++) {
            count[i] += count[i - 1];
        }
        for (int i = n - 1; i >= 0; i--) {
            int start = (order[i] - len + n) % n;
            int cl = classfiy[start];
            count[cl]--;
            newOrder[count[cl]] = start;
        }
        return newOrder;
    }

    public int[] UpdateClasses(int[] newOrder, int[] classfiy, int len) {
        int n = newOrder.Length;
        int[] newClassfiy = new int[n];
        newClassfiy[newOrder[0]] = 0;
        for (int i = 1; i < n; i++) {
            int curr = newOrder[i];
            int prev = newOrder[i - 1];
            int mid = curr + len;
            int midPrev = (prev + len) % n;
            if (classfiy[curr] != classfiy[prev] || classfiy[mid] != classfiy[midPrev]) {
                newClassfiy[curr] = newClassfiy[prev] + 1;
            } else {
                newClassfiy[curr] = newClassfiy[prev];
            }
        }
        return newClassfiy;
    }
}
```

```c
void sortCharacters(const char *text, int *order) {
    int n = strlen(text);
    int count[128];
    memset(count, 0, sizeof(count));
    for (int i = 0; text[i] != '\0'; i++) {
        count[text[i]]++;
    }    
    for (int i = 1; i < 128; i++) {
        count[i] += count[i - 1];
    }
    for (int i = n - 1; i >= 0; i--) {
        count[text[i]]--;
        order[count[text[i]]] = i;
    }
}

void computeCharClasses(const char *text, const int* order, int *classfiy) {
    int n = strlen(text);
    classfiy[order[0]] = 0;
    for (int i = 1; i < n; i++) {
        if (text[order[i]] != text[order[i - 1]]) {
            classfiy[order[i]] = classfiy[order[i - 1]] + 1;
        } else {
            classfiy[order[i]] = classfiy[order[i - 1]];
        }
    }
}

void sortDoubled(const char *text, int len, const int *order, const int *classfiy, int *newOrder) {
    int n = strlen(text);
    int count[n];
    memset(count, 0, sizeof(count));
    for (int i = 0; i < n; i++) {
        count[classfiy[i]]++;
    }
    for (int i = 1; i < n; i++) {
        count[i] += count[i - 1];
    }
    for (int i = n - 1; i >= 0; i--) {
        int start = (order[i] - len + n) % n;
        int cl = classfiy[start];
        count[cl]--;
        newOrder[count[cl]] = start;
    }
}

void updateClasses(const int *newOrder, int n, int *classfiy, int len, int *newClassfiy) {
    newClassfiy[newOrder[0]] = 0;
    for (int i = 1; i < n; i++) {
        int curr = newOrder[i];
        int prev = newOrder[i - 1];
        int mid = curr + len;
        int midPrev = (prev + len) % n;
        if (classfiy[curr] != classfiy[prev] || classfiy[mid] != classfiy[midPrev]) {
             newClassfiy[curr] = newClassfiy[prev] + 1;
        } else {
             newClassfiy[curr] = newClassfiy[prev];
        }
    }
}

int  *buildSuffixArray(const char *text) {
    int n = strlen(text);
    int *order = (int *)malloc(sizeof(int) * n); 
    int classfiy[n], newOrder[n], newClassfiy[n];
    sortCharacters(text, order);
    computeCharClasses(text, order, classfiy);    
    for (int i = 1; i < n; i <<= 1) {
        sortDoubled(text, i, order, classfiy, newOrder);
        updateClasses(newOrder, n, classfiy, i, newClassfiy);
        memcpy(order, newOrder, sizeof(int) * n);
        memcpy(classfiy, newClassfiy, sizeof(int) * n);
    }
    return order;
}

char * largestMerge(char * word1, char * word2) {
    int m = strlen(word1), n = strlen(word2);
    char str[m + n + 3];
    sprintf(str, "%s@%s*", word1, word2);
    int *suffixArray = buildSuffixArray(str); 
    int rank[m + n + 2];
    for (int i = 0; i < m + n + 2; i++) {
        rank[suffixArray[i]] = i;
    }
    free(suffixArray);

    char *merge = (char *)malloc(sizeof(char) * (m + n + 1));
    int i = 0, j = 0, pos = 0; 
    while (i < m || j < n) {
        if (i < m && rank[i] > rank[m + 1 + j]) {
            merge[pos] = word1[i];
            pos++, i++;
        } else {
            merge[pos] = word2[j];
            pos++, j++;
        }
    }
    merge[pos] = '\0';
    return merge;
}
```

**复杂度分析**

-   时间复杂度：$O(|\Sigma| + (m + n) \times \log (m + n))$，其中 $m, n$ 表示字符串 $word_1$ 与 $word_2$ 的长度，$|\Sigma|$ 表示字符集的大小，在此 $|\Sigma|$ 取 $128$。时间复杂度主要取决于后缀数组的计算与字符串的遍历，其中后缀数组的计算需要的时间复杂度为 $O(|\Sigma| + (m + n) \times \log (m + n))$，我们通过后缀数组计算出每个后缀的排序需要的时间复杂度为 $O(m + n)$，遍历两个字符串并通过比较后缀的大小来进行合并需要的时间复杂度为 $O(m + n)$，因此总的时间复杂度为 $O(|\Sigma| + (m + n) \times \log (m + n))$。
-   空间复杂度：$O(m + n)$。计算后缀数组时需要存放临时的字符串以及后缀排序，需要的空间均为 $O(m + n)$，因此总的空间复杂度为 $O(m + n)$。
