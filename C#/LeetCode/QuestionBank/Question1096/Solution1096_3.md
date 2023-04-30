#### [��������ջ](https://leetcode.cn/problems/brace-expansion-ii/solutions/2150290/hua-gua-hao-zhan-kai-ii-by-leetcode-solu-1s1y/)

**˼·���㷨**

�������Ŀ�еı��ʽ���й�ϵ��������ͣ�����ӿ������������ô����������ʽ�Ĺ��̿�������������׺���ʽ�Ĺ��̣����磺$\{a,b\}\{c,\{d,e\}\}$ ���Կ����� $\{a,b\} \times \{c + \{d + e\}\}$��

�������׺���ʽһ�����ڱ������ʽ�Ĺ�����������Ҫ�õ�����ջ��һ�������������������Ӻźͳ˺ţ��Լ�������ţ�����һ��������������󣨼����ϣ���

�ڱ�������һ�����������Ҫ�������ǳ˺���Ҫ�����Լ�����ӣ����ǰ��յ�ǰ�ַ����������ж�ǰ���Ƿ���Ҫ��ӳ˺ţ�

1.  �����ǰ�ַ��� $��\{��$������ǰ���� $"\}"$ ����СдӢ����ĸʱ����Ҫ��ӳ˺����㡣
2.  �����ǰ�ַ���Сд��ĸ������ǰ���� $"\}"$ ������СдӢ����ĸʱ����Ҫ��ӳ˺����㡣
3.  �����ǰ�ַ��� $","$ ����ǰ��һ������Ҫ��ӳ˺����㡣
4.  �����ǰ�ַ��� $"\}"$����ǰ��һ������Ҫ��ӳ˺����㡣

��ˣ�ֻ�е�ǰ�ַ��� $��\{��$ ����Сд��ĸʱ������Ҫ�����Ƿ���ǰ����ӳ˺š�

���������Ƿ����������ȼ������⣬�ڱ�����ֻ�漰�ӷ��ͳ˷��������㡣���һ�����ʽͬʱ�в��к���ӣ�������Ӧ���ȼ�����ӵĽ�����ټ��㲢�еĽ������ˣ��˷������ȼ�Ҫ���ڼӷ���

���ˣ����ǿ��԰�������������������ʽ��ֵ��

1.  ������� $","$�������ж������ջ���Ƿ��ǳ˺ţ�����ǳ˺�����Ҫ�ȼ���˷���ֱ��ջ�����ǳ˺�Ϊֹ���ٽ��Ӻŷ��������ջ�С�
2.  ������� $��\{��$�������ж��Ƿ���Ҫ��ӳ˺ţ��ٽ� $\{$ ���������ջ��
3.  ������� $"\}"$���򲻶ϵص��������ջ������������Ӧ�ļ��㣬ֱ��ջ��Ϊ������Ϊֹ��
4.  �������Сд��ĸ�������ж��Ƿ���Ҫ��ӳ˺ţ��ٹ���һ��ֻ������ǰСд��ĸ���ַ������ϣ����뼯��ջ�С�

�����������̱�����һ��֮��������Ŀ�����ı��ʽ����������û�д����ţ����� $\{a,b\}\{c,\{d,e\}\}$����������ջ�п�����Ȼ��Ԫ�أ�������Ҫ���ν����ǵ��������м��㡣���գ�����ջջ��Ԫ�ؼ�Ϊ�𰸡�

����չʾ���� $\{a,b\}\{c,\{d,e\}\}$ Ϊ������ȫ���̣�

![](./assets/img/Question1096_3_01.png)
![](./assets/img/Question1096_3_02.png)
![](./assets/img/Question1096_3_03.png)
![](./assets/img/Question1096_3_04.png)
![](./assets/img/Question1096_3_05.png)
![](./assets/img/Question1096_3_06.png)
![](./assets/img/Question1096_3_07.png)
![](./assets/img/Question1096_3_08.png)
![](./assets/img/Question1096_3_09.png)
![](./assets/img/Question1096_3_10.png)
![](./assets/img/Question1096_3_11.png)
![](./assets/img/Question1096_3_12.png)
![](./assets/img/Question1096_3_13.png)
![](./assets/img/Question1096_3_14.png)
![](./assets/img/Question1096_3_15.png)

**����**

```cpp
class Solution {
public:
    vector<string> braceExpansionII(string expression) {
        vector<char> op;
        vector<set<string>> stk;

        // ����ջ��������������м���
        auto ope = [&]() {
            int l = stk.size() - 2, r = stk.size() - 1;
            if (op.back() == '+') {
                stk[l].merge(stk[r]);
            } else {
                set<string> tmp;
                for (auto &left : stk[l]) {
                    for (auto &right : stk[r]) {
                        tmp.insert(left + right);
                    }
                }
                stk[l] = move(tmp);
            }
            op.pop_back();
            stk.pop_back();
        };

        for (int i = 0; i < expression.size(); i++) {
            if (expression[i] == ',') {
                // ���ϵص���ջ���������ֱ��ջΪ�ջ���ջ����Ϊ�˺�
                while (op.size() && op.back() == '*') {
                    ope();
                }
                op.push_back('+');
            } else if (expression[i] == '{') {
                // �����ж��Ƿ���Ҫ��ӳ˺ţ��ٽ� { ��ӵ������ջ��
                if (i > 0 && (expression[i - 1] == '}' || isalpha(expression[i - 1]))) {
                    op.push_back('*');
                }
                op.push_back('{');
            } else if (expression[i] == '}') {
                // ���ϵص���ջ���������ֱ��ջ��Ϊ {
                while (op.size() && op.back() != '{') {
                    ope();
                }
                op.pop_back();
            } else {
                // �����ж��Ƿ���Ҫ��ӳ˺ţ��ٽ��¹���ļ�����ӵ�����ջ��
                if (i > 0 && (expression[i - 1] == '}' || isalpha(expression[i - 1]))) {
                    op.push_back('*');
                }
                stk.push_back({string(1, expression[i])});
            }
        }
        
        while (op.size()) {
            ope();
        }
        return {stk.back().begin(), stk.back().end()};
    }
};
```

```java
class Solution {
    public List<String> braceExpansionII(String expression) {
        Deque<Character> op = new ArrayDeque<Character>();
        List<Set<String>> stk = new ArrayList<Set<String>>();

        for (int i = 0; i < expression.length(); i++) {
            if (expression.charAt(i) == ',') {
                // ���ϵص���ջ���������ֱ��ջΪ�ջ���ջ����Ϊ�˺�
                while (!op.isEmpty() && op.peek() == '*') {
                    ope(op, stk);
                }
                op.push('+');
            } else if (expression.charAt(i) == '{') {
                // �����ж��Ƿ���Ҫ��ӳ˺ţ��ٽ� { ��ӵ������ջ��
                if (i > 0 && (expression.charAt(i - 1) == '}' || Character.isLetter(expression.charAt(i - 1)))) {
                    op.push('*');
                }
                op.push('{');
            } else if (expression.charAt(i) == '}') {
                // ���ϵص���ջ���������ֱ��ջ��Ϊ {
                while (!op.isEmpty() && op.peek() != '{') {
                    ope(op, stk);
                }
                op.pop();
            } else {
                // �����ж��Ƿ���Ҫ��ӳ˺ţ��ٽ��¹���ļ�����ӵ�����ջ��
                if (i > 0 && (expression.charAt(i - 1) == '}' || Character.isLetter(expression.charAt(i - 1)))) {
                    op.push('*');
                }
                StringBuilder sb = new StringBuilder();
                sb.append(expression.charAt(i));
                stk.add(new TreeSet<String>() {{
                    add(sb.toString());
                }});
            }
        }
        
        while (!op.isEmpty()) {
            ope(op, stk);
        }
        return new ArrayList<String>(stk.get(stk.size() - 1));
    }

    // ����ջ��������������м���
    public void ope(Deque<Character> op, List<Set<String>> stk) {
        int l = stk.size() - 2, r = stk.size() - 1;
        if (op.peek() == '+') {
            stk.get(l).addAll(stk.get(r));
        } else {
            Set<String> tmp = new TreeSet<String>();
            for (String left : stk.get(l)) {
                for (String right : stk.get(r)) {
                    tmp.add(left + right);
                }
            }
            stk.set(l, tmp);
        }
        op.pop();
        stk.remove(stk.size() - 1);
    }
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n\log n)$������ $n$ �� $expression$ �ĳ��ȡ����� $expression$ ֻ�����һ�Σ�ʱ�临�Ӷ�Ϊ $O(n)$�����Ϻϲ��Լ���������ʱ�临�Ӷ�Ϊ $O(n\log n)$������ܵ�ʱ�临�Ӷ�Ϊ $O(n \log n)$��
-   �ռ临�Ӷȣ�$O(n)$���������õ�������ջ�����Ƕ�����������ʱ��Ԫ�ظ��������� $O(n)$������ $n$ ��Ԫ�صļ��ϵ�ʱ�临�Ӷ�Ϊ $O(n)$������ܵĿռ临�Ӷ�Ϊ $O(n)$��
