#### [383\. �����](https://leetcode.cn/problems/ransom-note/)

�Ѷȣ���

���������ַ�����`ransomNote` �� `magazine` ���ж� `ransomNote` �ܲ����� `magazine` ������ַ����ɡ�

������ԣ����� `true` �����򷵻� `false` ��

`magazine` �е�ÿ���ַ�ֻ���� `ransomNote` ��ʹ��һ�Ρ�

**ʾ�� 1��**

```
���룺ransomNote = "a", magazine = "b"
�����false
```

**ʾ�� 2��**

```
���룺ransomNote = "aa", magazine = "ab"
�����false
```

**ʾ�� 3��**

```
���룺ransomNote = "aa", magazine = "aab"
�����true
```

**��ʾ��**

-   `1 <= ransomNote.length, magazine.length <= 10^5`
-   `ransomNote` �� `magazine` ��СдӢ����ĸ���
