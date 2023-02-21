#### [���鼯](https://leetcode.cn/problems/find-if-path-exists-in-graph/solutions/1316746/dai-ma-you-xiang-xi-zhu-shi-bing-cha-ji-p4t9f/)

CLRS���㷨���ۣ���21�¡�

-   ���ڲ��ཻ���ϵ����ݽṹ��
-   ���鼯��˼�����ڣ���һ����Ա���������������ϡ�

�ٸ���ǡ�������ӣ�

A������һ��������֯�����ֻ�����Լ�һ���ˣ�����B��C��D��...��̼��롣һ��ʼ����֯�����˶�Ҫ��ˣ���������̫���˺��鷳�����Ǵ������˵�����Ƕ�����A����A��Ϊ�ϴ�ɡ����Ǻ���A�ʹ�������֯��
![](./assets/img/Solution1971_6_01.png)

������ZҲͬ���Ĵ�����һ����֯��Y��X������̼��롣ͬ��ZҲ��Ϊ��֯�Ĵ���
![](./assets/img/Solution1971_6_02.png)

���ʴ��һ�����⣬����X��B�й�ϵ��

-   û�еģ��������ڴ��ڲ�ͬ����֯��A��Zû�й�ϵ��

�������һ����������֯��������֯�������鶼һ����������һ��������Ч�ʻ��������ΪA�Ǳ���֯�����Ƚ϶࣬����Z�����֯�����˶�ͬ����A���ϴ�
![](./assets/img/Solution1971_6_03.png)

�ǻ����ʴ��������⣬����X��B�й�ϵ��

-   �����ھͿ϶����˰���������֯�ϳ�һ���ˣ����������ϴ���A��

����ǲ��鼯��˼�롣

���鼯����������������MAKE-SET(x)��UNION(x, y)��FIND-SET(x)

-   MAKE-SET(x) : �������ϣ��൱�ڳ�ʼ���µ�Ԫ�أ�ÿ����Ԫ�صĸ��ڵ�һ��ʼ����ָ���Լ��ġ�
-   UNION(x, y) : ������x��y��������̬���Ϻϲ���һ���µļ��ϡ����ٶ������������ڲ���֮ǰ�ǲ��ཻ�ģ�
-   FIND-SET(x) : ���ذ���x�ļ��ϵĴ������ڵ㣩

MAKE-SET(x)

```cpp
// �������Ƕ�����ʼ��Ԫ�ظ���n�ģ�����д�ɶ�̬���ϣ�ÿ��makeSet���¼���һ��Ԫ��
int[] nodes;
public void makeSet(int n) {
    nodes = new int[n];
    for (int i = 0; i < n; i++) {
        // ÿ����Ԫ�صĸ��ڵ�һ��ʼ����ָ���Լ���
        nodes[i] = i;
    }
}
```

FIND-SET(x)

```cpp
public int findSet(int x) {
    // �����ʱ���ڵ�ָ���Լ���˵���Ѿ��Ǹ������
    if (nodes[x] == x) return x;
    // ���򣬸��ݸ��ڵ���������ң�ֱ���ҵ����ڵ�
    else return findSet(nodes[x]);
}
```

UNION(x, y)�����е�������ǻ���ͼ������ ��ô���磬F��B˵����������֯һ��ɣ���ʱF��֪������B���ϵĴ�����˭����B˵�Ǽ򵥣����������ϴ�H�����������ϴ�A��������OK�����ˣ�
![](./assets/img/Solution1971_6_04.png)

```cpp
public void union(int x, int y) {
    int xRoot = findSet(x), yRoot = findSet(y);
    // �ҵ����ڵ��x����y����������y����x��������������
    nodes[xRoot] = yRoot; // nodes[yRoot] = xRoot;
}
```

UNIONҲ���Լ���һ���Ż�������������Ȳ�ͬʱ�����С�Ľӵ���ȱȽ���ġ���Ϊ��������ʹ����ȼ����һ��Ҳ��·���Ż�
![](./assets/img/Solution1971_6_05.png)

�������һ�»�һ�¾Ͷ��ˣ�

-   �������������һ�����飬���ڱ�����ȡ�

```cpp
int[] nodes;
int[] depth;

public void makeSet(int n) {
    this.depth = new int[n];
    this.nodes = new int[n];
    for (int i = 0; i < n; i++) {
        nodes[i] = i;
        depth[i] = 1;
    }
}

public void union(int x, int y) {
    // ����Ҫ�ҵ��������ĸ��ڵ㣨���ϴ���
    int xRoot = findSet(x), yRoot = findSet(y);
    // �����ڵ㶼��ͬʱ��û�б�Ҫ����ִ�кϲ�
    if (xRoot == yRoot) return;
    // �ҵ��������ʱ������������һ�µģ���û��Ҫ�󣻷������ӵ���ȸ��������
    if (depth[xRoot] <= depth[yRoot]) nodes[xRoot] = yRoot;
    else nodes[yRoot] = xRoot;
    // �������Ҫ�Ƿ�������ӣ����ҽ�������������Ϊ��ͬ��㣩���һ������ȲŻ����
    if (depth[xRoot] == depth[yRoot]) depth[yRoot]++; // ��Ϊ����Ĭ�����һ��ʱ�ӵ�yRoot�ϣ�������yRoot++
    }
```

#### ·��ѹ��

�ع�ͷ�����ٿ�һ�º���FIND-SET������Ҫ��C�ĸ��ڵ㣬C���ҵ�B��B���ҵ�A��������������·һ�����ǲ��Ǻܺ�ʱ�� ����ʵ���ǿ����Ż�ֱ�Ӱ�Cָ��A����һ��Ҳ����·��ѹ������ֻ���ڸý�㱻���ҵ�ʱ��Ż�ѹ���� ![](./assets/img/Solution1971_6_06.png)

```cpp
    /**
     * FIND-SET(x) : �ҵ����x���ڼ����еĴ����൱����������ĸ��ڵ㣩
     * �������� <= 2 ����union��ʱ����ܵ���3��
     */
    public int findSet(int x) {
        // ֱ�ӰѸü������нڵ�ӵ����ڵ�����, ��ƽ, ��ʱ�����Ϊ2
        if (nodes[x] != x)
            nodes[x] = findSet(nodes[x]);
        return nodes[x];
    }
```

-   �ⲽ����Ҳ�����Ż���һ��

```cpp
public int findSet(int x) {
    return x == nodes[x] ? x : (nodes[x] = findSet(nodes[x]));
}
```

����·��ѹ�������ǵĺ���UNION�Ͳ���Ҫ����������

```cpp
public int findSet(int x) {
    // ����Ҫ�ҵ��������ĸ��ڵ㣨���ϴ���
    int xRoot = findSet(x), yRoot = findSet(y);
    // �����ڵ㶼��ͬʱ��û�б�Ҫ����ִ�кϲ�
    if (xRoot == yRoot) return;
    // ��·��ѹ����, ������ȸ�������, ֱ�ӽӵ����ڵ���
    nodes[xRoot] = yRoot;
    count--;
}
```

#### ���鼯ģ��

```java
public class DisjointSet {
    // �����Ϣ��node[i]��ֵ��ʾ�� i �����ĵĸ���㣨����Ԫ�ش���
    int[] nodes;
    // ��¼�ж��ٸ������ļ���
    int count;
    //ʹ��·��ѹ����, ���Բ��ø�������

    // ��ʼ�� : �൱��MAKE-SET(x)
    public DisjointSet(int x) {
        this.count = x;
        this.nodes = new int[x];
        for (int i = 0; i < x; i++)
            // ��ʼ��ʱ��ÿ����㶼�����Լ�Ϊ�������ϣ�����
            nodes[i] = i;
    }

    /**
     * UNION(x, y) : �������й�ϵ�ļ��Ͻ��ϲ���һ���¼��ϣ��൱��˵һ�����ӵ���һ����
     */
    public void union(int x, int y) {
        // ����Ҫ�ҵ��������ĸ��ڵ㣨���ϴ���
        int xRoot = findSet(x), yRoot = findSet(y);
        // �����ڵ㶼��ͬʱ��û�б�Ҫ����ִ�кϲ�
        if (xRoot == yRoot) return;
        // ��·��ѹ����, ������ȸ�������, ֱ�ӽӵ����ڵ���
        nodes[xRoot] = yRoot;
        count--;
    }

    /**
     * FIND-SET(x) : �ҵ����x���ڼ����еĴ����൱����������ĸ��ڵ㣩
     * �������� <= 2 ����union��ʱ����ܵ���3��
     */
    public int findSet(int x) {
        // ֱ�ӰѸü������нڵ�ӵ����ڵ�����, ��ƽ, ��ʱ�����Ϊ2
        if (nodes[x] != x)
            nodes[x] = findSet(nodes[x]);
        return nodes[x];
    }

    public int getCount() {
        return this.count;
    }

    public boolean isConnected(int x, int y) {
        return findSet(x) == findSet(y);
    }
}
```

#### �������

```java
class Solution {
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        DisjointSet djs = new DisjointSet(n);
        for (int[] edge : edges) 
            djs.union(edge[0], edge[1]);
        return djs.isConnected(source, destination);
    }
}

public class DisjointSet {
    // �����Ϣ��node[i]��ֵ��ʾ�� i �����ĵĸ���㣨����Ԫ�ش���
    int[] nodes;
    // ��¼�ж��ٸ������ļ���
    int count;
    //ʹ��·��ѹ����, ���Բ��ø�������

    // ��ʼ�� : �൱��MAKE-SET(x)
    public DisjointSet(int x) {
        this.count = x;
        this.nodes = new int[x];
        for (int i = 0; i < x; i++)
            // ��ʼ��ʱ��ÿ����㶼�����Լ�Ϊ�������ϣ�����
            nodes[i] = i;
    }

    /**
     * UNION(x, y) : �������й�ϵ�ļ��Ͻ��ϲ���һ���¼��ϣ��൱��˵һ�����ӵ���һ����
     */
    public void union(int x, int y) {
        // ����Ҫ�ҵ��������ĸ��ڵ㣨���ϴ���
        int xRoot = findSet(x), yRoot = findSet(y);
        // �����ڵ㶼��ͬʱ��û�б�Ҫ����ִ�кϲ�
        if (xRoot == yRoot) return;
        // ��·��ѹ����, ������ȸ�������, ֱ�ӽӵ����ڵ���
        nodes[xRoot] = yRoot;
        count--;
    }

    /**
     * FIND-SET(x) : �ҵ����x���ڼ����еĴ����൱����������ĸ��ڵ㣩
     * �������� <= 2 ����union��ʱ����ܵ���3��
     */
    public int findSet(int x) {
        // ֱ�ӰѸü������нڵ�ӵ����ڵ�����, ��ƽ, ��ʱ�����Ϊ2
        if (nodes[x] != x)
            nodes[x] = findSet(nodes[x]);
        return nodes[x];
    }

    public int getCount() {
        return this.count;
    }

    public boolean isConnected(int x, int y) {
        return findSet(x) == findSet(y);
    }
}
```
