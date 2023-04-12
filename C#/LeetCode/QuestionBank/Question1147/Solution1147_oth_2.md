#### [贪心法正确性的详细证明](https://leetcode.cn/problems/longest-chunked-palindrome-decomposition/solutions/444948/tan-xin-fa-zheng-que-xing-de-xiang-xi-zheng-ming-b/)

本题贪心解法的思路是找到最短的相等前后缀，将字符串拆分为[前缀，中间字符串，后缀][前缀，中间字符串，后缀][前缀，中间字符串，后缀]的形式，则答案为2+中间字符串的回文段数2 + 中间字符串的回文段数2+中间字符串的回文段数。从而我们可以递归的求解本题，采用朴素的字符串匹配时最坏时间复杂度为O(n2)O(n^2)O(n2)。

关于算法的正确性，国际版中给出了[证明](https://leetcode.com/problems/longest-chunked-palindrome-decomposition/discuss/350560/JavaC%2B%2BPython-Easy-Greedy-with-Prove)。这里对Lee的证明进行翻译，并对第二种情况做出补充。

#### 情况一：短前缀的长度小于等于长前缀长度的一半

这里直接使用Lee给出的图示: ![img1.png](https://pic.leetcode-cn.com/1602566279-uIBczW-img1.png)

-   长前缀$B1$与长后缀$B2$，$B1=B2$
-   短前缀$R1$与短后缀$R4$，$R1=R4$

由于短前缀的长度小于等于长前缀长度的一半，$B1$可以分成三个部分B1=[R1,Mid,R2]B1=[R1, Mid, R2]B1\=[R1,Mid,R2]，同理B2=[R3,Mid,R4]B2=[R3, Mid, R4]B2\=[R3,Mid,R4]（MidMidMid可以是空串），其中len(R1)=len(R2)len(R1)=len(R2)len(R1)\=len(R2), len(R3)=len(R4)len(R3)=len(R4)len(R3)\=len(R4)。 根据条件，B1=B2⇒R1=R3B1=B2\\rArr R1=R3B1\=B2⇒R1\=R3，又因为$R1=R4$，故R1=R2=R3=R4R1=R2=R3=R4R1\=R2\=R3\=R4。

从而我们可以将(B1,B2)(B1, B2)(B1,B2)分解为3个新的回文段组合(R1,R4),(Mid,Mid),(R2,R3)(R1,R4), (Mid, Mid), (R2, R3)(R1,R4),(Mid,Mid),(R2,R3)，总段数增加了4段（若Mid为空串则只增加2段），因而此时选择短前缀优于选择长前缀，贪心算法成立。

#### 情况二：短前缀的长度大于长前缀长度的一半

此时的情况如下图所示： ![img2.png](https://pic.leetcode-cn.com/1602566288-YnKAZl-img2.png)

此时，由于len(R1)>len(B1)/2len(R1)>len(B1) / 2len(R1)\>len(B1)/2，我们仅能将B1,B2B1,B2B1,B2分解为两段，B1=[R1,Y1],B2=[Y2,R2]B1=[R1, Y1], B2=[Y2, R2]B1\=[R1,Y1],B2\=[Y2,R2]。注意到此时Y1=Y2Y1=Y2Y1\=Y2不总是成立的（至于何时成立，下面我们会提到）。例如，B1=B2=abababa,R1=R2=ababaB1=B2=abababa,R1=R2=ababaB1\=B2\=abababa,R1\=R2\=ababa，此时Y1=ba,Y2=ab,Y1≠Y2Y1=ba,Y2=ab,Y1\\neq Y2Y1\=ba,Y2\=ab,Y1\=Y2。但是我们能够证明，我们可以将$B1$分解为一个前缀aaa加上nnn个Y1Y1Y1（xxx可能为空串）的形式，并将$B2$分解为nnn个Y2Y2Y2加上后缀bbb的形式，其中n=⌊len(B1)len(Y1)⌋n=\\lfloor \\frac{len(B1)}{len(Y1)} \\rfloorn\=⌊len(Y1)len(B1)⌋。同时我们可以证明该分解下a=ba=ba\=b进而可以将B1,B2B1,B2B1,B2分解为[a,Mid,b][a, Mid, b][a,Mid,b]的形式，由于a=ba=ba\=b，此时我们可以再次将长前缀B1,B2B1,B2B1,B2分解为3段，与情况一等价。

下面我们在PPT中给出构造过程：

![](https://pic.leetcode-cn.com/1602567297-MhpSsE-%E5%B9%BB%E7%81%AF%E7%89%878.PNG)![](https://pic.leetcode-cn.com/1602566636-PwaUhY-%E5%B9%BB%E7%81%AF%E7%89%879.PNG)![](https://pic.leetcode-cn.com/1602566646-QTWkLr-%E5%B9%BB%E7%81%AF%E7%89%8710.PNG)![](https://pic.leetcode-cn.com/1602566654-eMkXyP-%E5%B9%BB%E7%81%AF%E7%89%8711.PNG)![](https://pic.leetcode-cn.com/1602566662-OBGrnv-%E5%B9%BB%E7%81%AF%E7%89%8712.PNG)![](https://pic.leetcode-cn.com/1602566674-iUljGB-%E5%B9%BB%E7%81%AF%E7%89%8713.PNG)![](https://pic.leetcode-cn.com/1602566681-ubuUkG-%E5%B9%BB%E7%81%AF%E7%89%8714.PNG)![](https://pic.leetcode-cn.com/1602567498-DpIEof-%E5%B9%BB%E7%81%AF%E7%89%8715.PNG)
