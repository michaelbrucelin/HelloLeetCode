#### [2108\. �ҳ������еĵ�һ�������ַ���](https://leetcode.cn/problems/find-first-palindromic-string-in-the-array/)

�Ѷȣ���

����һ���ַ������� `words` ���ҳ������������е� **��һ�������ַ���** ���������������Ҫ����ַ���������һ�� **���ַ���** `""` ��

**�����ַ���** �Ķ���Ϊ�����һ���ַ������Ŷ��ͷ��Ŷ�һ������ô���ַ�������һ�� **�����ַ���** ��

**ʾ�� 1��**

```
���룺words = ["abc","car","ada","racecar","cool"]
�����"ada"
���ͣ���һ�������ַ����� "ada" ��
ע�⣬"racecar" Ҳ�ǻ����ַ������������ǵ�һ����
```

**ʾ�� 2��**

```
���룺words = ["notapalindrome","racecar"]
�����"racecar"
���ͣ���һ��Ҳ��Ψһһ�������ַ����� "racecar" ��
```

**ʾ�� 3��**

```
���룺words = ["def","ghi"]
�����""
���ͣ������ڻ����ַ��������Է���һ�����ַ�����
```

**��ʾ��**

-   `1 <= words.length <= 100`
-   `1 <= words[i].length <= 100`
-   `words[i]` ����СдӢ����ĸ���