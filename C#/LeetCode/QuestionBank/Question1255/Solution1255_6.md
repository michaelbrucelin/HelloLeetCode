#### [˼·���������ֽⷨ������ & λѹ��...](https://leetcode.cn/problems/maximum-score-words-formed-by-letters/solutions/43615/si-lu-qing-xi-shuang-jie-fa-hui-su-wei-ya-suo-by-x/)

ͨ���Ķ���Ŀ���Ƿ��֣�������Ҫ�ӵ��ʱ�`words`��ѡ�����ɸ�����ʹ���յĵ÷���ߡ����ѡ�񵥴��أ�����û��ʲô���ɣ���������Ҳ����ֻ��ö�����еĿ��������Ҳ����ö�����еĵ�����ϡ�һ����ö�����п������������һ���Ӿͱĳ���`����`�ǲ��ǣ��������ǡ����ﻹ�ṩ��һ�ֽⷨ`λѹ��`��

#### [����](https://leetcode.cn/problems/maximum-score-words-formed-by-letters/solutions/43615/si-lu-qing-xi-shuang-jie-fa-hui-su-wei-ya-suo-by-x/)

-   ���ڵ��ʱ��е�ÿ�������޷Ǿ����������ѡ���߲�ѡ��
-   �����Ǿ�Ҫ�������ʱ��е����е��ʣ�����ÿ�����ʼ����ѡ�Ͳ�ѡ��������ĵ÷֣������ȡ�÷ֽϴ��ѡ�񼴿ɡ�
-   ��Ȼ����Ŀ��������Ҫ�󣬾�����ĸ��`letters`�е�ÿ���������ֻ��ʹ��һ�Ρ�
-   �������Ǿ���Ҫ��һ����ϣ��`m`������ÿ����ĸ�ĸ�����ÿ�õ�һ���ַ�����Ӧ�ļ�ֵ��Ҫ��1��

```cpp
int maxScoreWords(vector<string>& words, vector<char>& letters, vector<int>& score) {
    vector<int> m(26);//ʹ������ģ���ϣ��
    // ��ʼ����ĸ��
    for (char c : letters) {
        m[c-'a']++;
    }
    return backtrack(0, m, words, letters, score);
}
```

```cpp
/**
*  index��ʾ��ǰ���ʵ�����
*/
int backtrack(int index, vector<int> m, vector<string>& words, vector<char>& letters, vector<int>& score) {
    if (index >= words.size()) {
        return 0;
    }
    //����һ����ĸ��ĸ���t
    vector<int> t(m);
    //���ѡ��ǰ���ʵĵ÷�ret
    int ret = spell(words[index], t, letters, score);
    //ע�����ﴫ�����ĸ���Ǳ�spell�����ı��ı�t
    int leftret = ret == 0 ? 0 : ret + backtrack(index+1, t, words, letters, score);
    //���ﴫ�����ĸ����û�б��ı��m
    int rightret = backtrack(index+1, m, words, letters, score);
    //����ѡ����߲�ѡ�÷ֽϴ���
    return max(leftret, rightret);
}
```

```cpp
//ע��������ĸ������Ƕ�t������
int spell(string word, vector<int>& t, vector<char>& letters, vector<int>& score) {
    int ret = 0;
    for (char c : word) {
        //��ĸ�����Ѿ�û�и���ĸ�ˣ�ֱ�ӷ���0
        if (t[c-'a'] == 0) {
            return 0;
        }
        ret += score[c-'a'];
        t[c-'a']--;
    }
    return ret;
}
```

��û�з��ֺ���Զ������Ĳ������ǵģ������ʹ���˶�������ģ�͡�������ʱ���ȥˢˢ�����⣬��������ܶ���Ҫʹ�õݹ���㷨�кܴ�İ�����

#### [λѹ��](https://leetcode.cn/problems/maximum-score-words-formed-by-letters/solutions/43615/si-lu-qing-xi-shuang-jie-fa-hui-su-wei-ya-suo-by-x/)

λѹ��˼·��ʵҲ�ͻ������ƣ�ֻ�����ǽ����еĿ������ѹ����һ��32λ`int`���͵ı���`i`�������档

-   32λ�����ƣ���1λ��Ӧ���ʱ��еĵ�һ������`words[0]`��ѡ��״̬
-   ��2λ��Ӧ���ʱ��еĵڶ�������`words[1]`��ѡ��״̬
-   ......
-   ������Ϊ0����ѡ�񵥴ʱ��ж�Ӧ�ĵ��ʣ�1����ѡ���Ӧ�ĵ��ʡ�

```cpp
int maxScoreWords(vector<string>& words, vector<char>& letters, vector<int>& score) {
    int ret = 0;
    //��ʼ����ĸ��m
    vector<int> m(26, 0);
    for (char ch : letters) {
        m[ch-'a']++;
    }
    //һ����all��ô�������
    int all = (1 << words.size());
    //ͨ��i����+1��ö���������
    for (int i = 0; i < all; i++) {
        ret = max(ret, oneStateRet(words, letters, score, m, i));
    }
    return ret;
}
```

```cpp
/**
*����ĳһ������µĵ÷�
*/
int oneStateRet(vector<string>& words, vector<char>& letters, vector<int>& score, vector<int> m, int state) {
    //��������µĵ÷ֳ�ʼ��Ϊ0
    int ret = 0;
    for (int i = 0; i < words.size(); i++) {
        //�ж�����������Ƿ�ѡ���˵���words[i]
        if (state & ( 1 << i)) {
            for (char ch : words[i]) {
                //��ĸ�����Ѿ�û�иõ����ˣ�ֱ�ӷ���0
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
