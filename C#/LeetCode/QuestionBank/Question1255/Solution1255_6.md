#### [思路清晰，两种解法：回溯 & 位压缩...](https://leetcode.cn/problems/maximum-score-words-formed-by-letters/solutions/43615/si-lu-qing-xi-shuang-jie-fa-hui-su-wei-ya-suo-by-x/)

通过阅读题目我们发现，我们需要从单词表`words`中选择若干个单词使最终的得分最高。如何选择单词呢？这里没有什么技巧，测试用例也不大，只能枚举所有的可能情况，也就是枚举所有的单词组合。一听到枚举所有可能情况，脑中一下子就蹦出了`回溯`是不是？反正我是。这里还提供另一种解法`位压缩`。

#### [回溯](https://leetcode.cn/problems/maximum-score-words-formed-by-letters/solutions/43615/si-lu-qing-xi-shuang-jie-fa-hui-su-wei-ya-suo-by-x/)

-   对于单词表中的每个单词无非就两种情况，选或者不选！
-   那我们就要遍历单词表中的所有单词，对于每个单词计算出选和不选两种情况的得分，最后再取得分较大的选择即可。
-   当然，题目还有其它要求，就是字母表`letters`中的每个单词最多只能使用一次。
-   所以我们就需要用一个哈希表`m`来保存每个字母的个数，每用掉一个字符，相应的键值就要减1。

```cpp
int maxScoreWords(vector<string>& words, vector<char>& letters, vector<int>& score) {
    vector<int> m(26);//使用向量模拟哈希表
    // 初始化字母表
    for (char c : letters) {
        m[c-'a']++;
    }
    return backtrack(0, m, words, letters, score);
}
```

```cpp
/**
*  index表示当前单词的索引
*/
int backtrack(int index, vector<int> m, vector<string>& words, vector<char>& letters, vector<int>& score) {
    if (index >= words.size()) {
        return 0;
    }
    //生成一个字母表的副本t
    vector<int> t(m);
    //获得选择当前单词的得分ret
    int ret = spell(words[index], t, letters, score);
    //注意这里传入的字母表是被spell函数改变后的表t
    int leftret = ret == 0 ? 0 : ret + backtrack(index+1, t, words, letters, score);
    //这里传入的字母表是没有被改变的m
    int rightret = backtrack(index+1, m, words, letters, score);
    //返回选择或者不选得分较大者
    return max(leftret, rightret);
}
```

```cpp
//注意这里字母表传入的是对t的引用
int spell(string word, vector<int>& t, vector<char>& letters, vector<int>& score) {
    int ret = 0;
    for (char c : word) {
        //字母表中已经没有该字母了，直接返回0
        if (t[c-'a'] == 0) {
            return 0;
        }
        ret += score[c-'a'];
        t[c-'a']--;
    }
    return ret;
}
```

有没有发现很像对二叉树的操作，是的，这就是使用了二叉树的模型。所以有时间多去刷刷树的题，会对你理解很多需要使用递归的算法有很大的帮助！

#### [位压缩](https://leetcode.cn/problems/maximum-score-words-formed-by-letters/solutions/43615/si-lu-qing-xi-shuang-jie-fa-hui-su-wei-ya-suo-by-x/)

位压缩思路其实也和回溯类似，只不过是将所有的可能情况压缩到一个32位`int`类型的变量`i`中来保存。

-   32位二进制，第1位对应单词表中的第一个单词`words[0]`的选择状态
-   第2位对应单词表中的第二个单词`words[1]`的选择状态
-   ......
-   二进制为0代表不选择单词表中对应的单词，1代表选择对应的单词。

```cpp
int maxScoreWords(vector<string>& words, vector<char>& letters, vector<int>& score) {
    int ret = 0;
    //初始化字母表m
    vector<int> m(26, 0);
    for (char ch : letters) {
        m[ch-'a']++;
    }
    //一共有all这么多种情况
    int all = (1 << words.size());
    //通过i不断+1来枚举所有情况
    for (int i = 0; i < all; i++) {
        ret = max(ret, oneStateRet(words, letters, score, m, i));
    }
    return ret;
}
```

```cpp
/**
*返回某一种情况下的得分
*/
int oneStateRet(vector<string>& words, vector<char>& letters, vector<int>& score, vector<int> m, int state) {
    //这种情况下的得分初始化为0
    int ret = 0;
    for (int i = 0; i < words.size(); i++) {
        //判断这种情况下是否选择了单词words[i]
        if (state & ( 1 << i)) {
            for (char ch : words[i]) {
                //字母表中已经没有该单词了，直接返回0
                if (m[ch-'a'] == 0) {
                    return 0;
                }
                ret += score[ch-'a'];
                m[ch-'a']--;
            }
        }
    }
    return ret;
}
```
