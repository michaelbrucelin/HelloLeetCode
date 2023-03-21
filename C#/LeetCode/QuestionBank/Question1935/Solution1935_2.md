#### [����һ������ + ��ϣ��](https://leetcode.cn/problems/maximum-number-of-words-you-can-type/solutions/883398/ke-yi-shu-ru-de-zui-da-dan-ci-shu-by-lee-5dpc/)

**˼·���㷨**

���ǿ��Ա����ַ��� $text$ ͳ�ƿ�����ȫ����ĵ�����Ŀ��

Ϊ�˷����ж�ĳ���ַ��Ƿ�ɱ����룬�����ù�ϣ����ά����Ϊ�𻵶��޷�������ַ���ͬʱ���������벼������ $flag$ ����ʾ��ǰ�ַ�����Ӧ�ĵ����Ƿ���Ա���ȫ���롣$flag$ ��ֵΪ $true$����ȡֵΪ $true$ ʱ����ǰ���ʿɱ���ȫ���룬��ȡֵΪ $false$ ʱ�򲻿��ԡ�

�ڱ����ַ���ʱ�����ݵ�ǰ�ַ��Ĳ�ͬ���������������

-   ��ǰ�ַ�Ϊ�ո񣬴�ʱ������һ�������Ѿ������������ʱ $flag$ Ϊ $true$ �������һ�����ʿ��Ա���ȫ���룬������Ҫ��������ȫ����ĵ�����Ŀ���� $1$���������⣬���ǻ���Ҫ�� $flag$ ����Ϊ��ֵ $true$��
-   ��ǰ�ַ�Ϊ��ĸ�Ҳ��ɱ����룬��ô��ǰ�ַ����ڵ��ʲ��ɱ���ȫ���롣������Ҫ�� $flag$ ��Ϊ $false$��
-   ��ǰ�ַ�Ϊ��ĸ�ҿɱ����룬��ʱ��������κβ�����

ע���ڱ������������ǻ�Ҫ��� $flag$ ���ж����һ�������Ƿ�ɱ���ȫ���벢���¿�����ȫ����ĵ�����Ŀ�����գ����Ƿ��ظ���Ŀ��Ϊ�𰸡�

**����**

```cpp
class Solution {
public:
    int canBeTypedWords(string text, string brokenLetters) {
        unordered_set<char> broken;   // �޷�������ַ�����
        for (char ch: brokenLetters){
            broken.insert(ch);
        }
        int res = 0;   // ������ȫ����ĵ�����Ŀ
        bool flag = true;   // ��ǰ�ַ����ڵ����Ƿ�ɱ���ȫ����
        for (char ch: text){
            if (ch == ' '){
                // ��ǰ�ַ�Ϊ�ո񣬼����һ������״̬��������Ŀ����ʼ�� flag
                if (flag){
                    ++res;
                }
                flag = true;
            }
            else if (broken.count(ch)){
                // ��ǰ�ַ����ɱ����룬���ڵ����޷�����ȫ���룬���� flag
                flag = false;
            }
        }
        // �ж����һ������״̬��������Ŀ
        if (flag){
            ++res;
        }
        return res;
    }
};
```

```python
class Solution:
    def canBeTypedWords(self, text: str, brokenLetters: str) -> int:
        broken = set(brokenLetters)   # �޷�������ַ�����
        res = 0   # ������ȫ����ĵ�����Ŀ
        flag = True   # ��ǰ�ַ����ڵ����Ƿ�ɱ���ȫ����
        for ch in text:
            if ch == ' ':
                # ��ǰ�ַ�Ϊ�ո񣬼����һ������״̬��������Ŀ����ʼ�� flag
                if flag:
                    res += 1
                flag = True
            elif ch in broken:
                # ��ǰ�ַ����ɱ����룬���ڵ����޷�����ȫ���룬���� flag
                flag = False
        # �ж����һ������״̬��������Ŀ
        if flag:
            res += 1
        return res
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + m)$������ $n$ Ϊ $text$ �ĳ��ȣ� $m$ Ϊ�޷������ַ�����Ŀ��ά���޷������ַ���ϣ���ϵ�ʱ�临�Ӷ�Ϊ $O(m)$������ $text$ ���������ȫ���뵥����Ŀ��ʱ�临�Ӷ�Ϊ $O(n)$��
-   �ռ临�Ӷȣ�$O(1)$��
