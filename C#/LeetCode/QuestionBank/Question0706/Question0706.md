#### [706\. ��ƹ�ϣӳ��](https://leetcode.cn/problems/design-hashmap/)

�Ѷȣ���

��ʹ���κ��ڽ��Ĺ�ϣ������һ����ϣӳ�䣨HashMap����

ʵ�� `MyHashMap` �ࣺ

-   `MyHashMap()` �ÿ�ӳ���ʼ������
-   `void put(int key, int value)` �� HashMap ����һ����ֵ�� `(key, value)` ����� `key` �Ѿ�������ӳ���У���������Ӧ��ֵ `value` ��
-   `int get(int key)` �����ض��� `key` ��ӳ��� `value` �����ӳ���в����� `key` ��ӳ�䣬���� `-1` ��
-   `void remove(key)` ���ӳ���д��� `key` ��ӳ�䣬���Ƴ� `key` ��������Ӧ�� `value` ��

**ʾ����**

```
���룺
["MyHashMap", "put", "put", "get", "get", "put", "get", "remove", "get"]
[[], [1, 1], [2, 2], [1], [3], [2, 1], [2], [2], [2]]
�����
[null, null, null, 1, -1, null, 1, null, -1]

���ͣ�
MyHashMap myHashMap = new MyHashMap();
myHashMap.put(1, 1);  // myHashMap ����Ϊ [[1,1]]
myHashMap.put(2, 2);  // myHashMap ����Ϊ [[1,1], [2,2]]
myHashMap.get(1);     // ���� 1 ��myHashMap ����Ϊ [[1,1], [2,2]]
myHashMap.get(3);     // ���� -1��δ�ҵ�����myHashMap ����Ϊ [[1,1], [2,2]]
myHashMap.put(2, 1);  // myHashMap ����Ϊ [[1,1], [2,1]]���������е�ֵ��
myHashMap.get(2);     // ���� 1 ��myHashMap ����Ϊ [[1,1], [2,1]]
myHashMap.remove(2);  // ɾ����Ϊ 2 �����ݣ�myHashMap ����Ϊ [[1,1]]
myHashMap.get(2);     // ���� -1��δ�ҵ�����myHashMap ����Ϊ [[1,1]]
```

**��ʾ��**

-   `0 <= key, value <= 10^6`
-   ������ `10^4` �� `put`��`get` �� `remove` ����
