﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2180
{
    public class Test2180
    {
        public void Look4Rules()
        {
            Interface2180 solution = new Solution2180();

            for (int i = 1; i <= 1000; i++)
            {
                int result = solution.CountEven(i);
                if (result == (i >> 1))
                    Console.WriteLine($"{i / 100}\t{i / 10}\t{i}");
                else
                    Console.WriteLine($"{i / 100}\t{i / 10}\t{i}\t{result}");
            }
        }

        public void VerifyRules()
        {
            Interface2180 solution = new Solution2180();
            for (int i = 1; i <= 1000; i++)
            {
                int answer = solution.CountEven(i);
                int result = (((i / 100) & 1) == ((i / 10) & 1)) ? (i >> 1) : ((i - 1) >> 1);
                if (result != answer)
                    Console.WriteLine($"{i}\tresult:{result}, answer:{answer}");
            }
        }
    }
}

/*
0       0       1
0       0       2
0       0       3
0       0       4
0       0       5
0       0       6
0       0       7
0       0       8
0       0       9
0       1       10      4
0       1       11
0       1       12      5
0       1       13
0       1       14      6
0       1       15
0       1       16      7
0       1       17
0       1       18      8
0       1       19
0       2       20
0       2       21
0       2       22
0       2       23
0       2       24
0       2       25
0       2       26
0       2       27
0       2       28
0       2       29
0       3       30      14
0       3       31
0       3       32      15
0       3       33
0       3       34      16
0       3       35
0       3       36      17
0       3       37
0       3       38      18
0       3       39
0       4       40
0       4       41
0       4       42
0       4       43
0       4       44
0       4       45
0       4       46
0       4       47
0       4       48
0       4       49
0       5       50      24
0       5       51
0       5       52      25
0       5       53
0       5       54      26
0       5       55
0       5       56      27
0       5       57
0       5       58      28
0       5       59
0       6       60
0       6       61
0       6       62
0       6       63
0       6       64
0       6       65
0       6       66
0       6       67
0       6       68
0       6       69
0       7       70      34
0       7       71
0       7       72      35
0       7       73
0       7       74      36
0       7       75
0       7       76      37
0       7       77
0       7       78      38
0       7       79
0       8       80
0       8       81
0       8       82
0       8       83
0       8       84
0       8       85
0       8       86
0       8       87
0       8       88
0       8       89
0       9       90      44
0       9       91
0       9       92      45
0       9       93
0       9       94      46
0       9       95
0       9       96      47
0       9       97
0       9       98      48
0       9       99
1       10      100     49
1       10      101
1       10      102     50
1       10      103
1       10      104     51
1       10      105
1       10      106     52
1       10      107
1       10      108     53
1       10      109
1       11      110
1       11      111
1       11      112
1       11      113
1       11      114
1       11      115
1       11      116
1       11      117
1       11      118
1       11      119
1       12      120     59
1       12      121
1       12      122     60
1       12      123
1       12      124     61
1       12      125
1       12      126     62
1       12      127
1       12      128     63
1       12      129
1       13      130
1       13      131
1       13      132
1       13      133
1       13      134
1       13      135
1       13      136
1       13      137
1       13      138
1       13      139
1       14      140     69
1       14      141
1       14      142     70
1       14      143
1       14      144     71
1       14      145
1       14      146     72
1       14      147
1       14      148     73
1       14      149
1       15      150
1       15      151
1       15      152
1       15      153
1       15      154
1       15      155
1       15      156
1       15      157
1       15      158
1       15      159
1       16      160     79
1       16      161
1       16      162     80
1       16      163
1       16      164     81
1       16      165
1       16      166     82
1       16      167
1       16      168     83
1       16      169
1       17      170
1       17      171
1       17      172
1       17      173
1       17      174
1       17      175
1       17      176
1       17      177
1       17      178
1       17      179
1       18      180     89
1       18      181
1       18      182     90
1       18      183
1       18      184     91
1       18      185
1       18      186     92
1       18      187
1       18      188     93
1       18      189
1       19      190
1       19      191
1       19      192
1       19      193
1       19      194
1       19      195
1       19      196
1       19      197
1       19      198
1       19      199
2       20      200
2       20      201
2       20      202
2       20      203
2       20      204
2       20      205
2       20      206
2       20      207
2       20      208
2       20      209
2       21      210     104
2       21      211
2       21      212     105
2       21      213
2       21      214     106
2       21      215
2       21      216     107
2       21      217
2       21      218     108
2       21      219
2       22      220
2       22      221
2       22      222
2       22      223
2       22      224
2       22      225
2       22      226
2       22      227
2       22      228
2       22      229
2       23      230     114
2       23      231
2       23      232     115
2       23      233
2       23      234     116
2       23      235
2       23      236     117
2       23      237
2       23      238     118
2       23      239
2       24      240
2       24      241
2       24      242
2       24      243
2       24      244
2       24      245
2       24      246
2       24      247
2       24      248
2       24      249
2       25      250     124
2       25      251
2       25      252     125
2       25      253
2       25      254     126
2       25      255
2       25      256     127
2       25      257
2       25      258     128
2       25      259
2       26      260
2       26      261
2       26      262
2       26      263
2       26      264
2       26      265
2       26      266
2       26      267
2       26      268
2       26      269
2       27      270     134
2       27      271
2       27      272     135
2       27      273
2       27      274     136
2       27      275
2       27      276     137
2       27      277
2       27      278     138
2       27      279
2       28      280
2       28      281
2       28      282
2       28      283
2       28      284
2       28      285
2       28      286
2       28      287
2       28      288
2       28      289
2       29      290     144
2       29      291
2       29      292     145
2       29      293
2       29      294     146
2       29      295
2       29      296     147
2       29      297
2       29      298     148
2       29      299
3       30      300     149
3       30      301
3       30      302     150
3       30      303
3       30      304     151
3       30      305
3       30      306     152
3       30      307
3       30      308     153
3       30      309
3       31      310
3       31      311
3       31      312
3       31      313
3       31      314
3       31      315
3       31      316
3       31      317
3       31      318
3       31      319
3       32      320     159
3       32      321
3       32      322     160
3       32      323
3       32      324     161
3       32      325
3       32      326     162
3       32      327
3       32      328     163
3       32      329
3       33      330
3       33      331
3       33      332
3       33      333
3       33      334
3       33      335
3       33      336
3       33      337
3       33      338
3       33      339
3       34      340     169
3       34      341
3       34      342     170
3       34      343
3       34      344     171
3       34      345
3       34      346     172
3       34      347
3       34      348     173
3       34      349
3       35      350
3       35      351
3       35      352
3       35      353
3       35      354
3       35      355
3       35      356
3       35      357
3       35      358
3       35      359
3       36      360     179
3       36      361
3       36      362     180
3       36      363
3       36      364     181
3       36      365
3       36      366     182
3       36      367
3       36      368     183
3       36      369
3       37      370
3       37      371
3       37      372
3       37      373
3       37      374
3       37      375
3       37      376
3       37      377
3       37      378
3       37      379
3       38      380     189
3       38      381
3       38      382     190
3       38      383
3       38      384     191
3       38      385
3       38      386     192
3       38      387
3       38      388     193
3       38      389
3       39      390
3       39      391
3       39      392
3       39      393
3       39      394
3       39      395
3       39      396
3       39      397
3       39      398
3       39      399
4       40      400
4       40      401
4       40      402
4       40      403
4       40      404
4       40      405
4       40      406
4       40      407
4       40      408
4       40      409
4       41      410     204
4       41      411
4       41      412     205
4       41      413
4       41      414     206
4       41      415
4       41      416     207
4       41      417
4       41      418     208
4       41      419
4       42      420
4       42      421
4       42      422
4       42      423
4       42      424
4       42      425
4       42      426
4       42      427
4       42      428
4       42      429
4       43      430     214
4       43      431
4       43      432     215
4       43      433
4       43      434     216
4       43      435
4       43      436     217
4       43      437
4       43      438     218
4       43      439
4       44      440
4       44      441
4       44      442
4       44      443
4       44      444
4       44      445
4       44      446
4       44      447
4       44      448
4       44      449
4       45      450     224
4       45      451
4       45      452     225
4       45      453
4       45      454     226
4       45      455
4       45      456     227
4       45      457
4       45      458     228
4       45      459
4       46      460
4       46      461
4       46      462
4       46      463
4       46      464
4       46      465
4       46      466
4       46      467
4       46      468
4       46      469
4       47      470     234
4       47      471
4       47      472     235
4       47      473
4       47      474     236
4       47      475
4       47      476     237
4       47      477
4       47      478     238
4       47      479
4       48      480
4       48      481
4       48      482
4       48      483
4       48      484
4       48      485
4       48      486
4       48      487
4       48      488
4       48      489
4       49      490     244
4       49      491
4       49      492     245
4       49      493
4       49      494     246
4       49      495
4       49      496     247
4       49      497
4       49      498     248
4       49      499
5       50      500     249
5       50      501
5       50      502     250
5       50      503
5       50      504     251
5       50      505
5       50      506     252
5       50      507
5       50      508     253
5       50      509
5       51      510
5       51      511
5       51      512
5       51      513
5       51      514
5       51      515
5       51      516
5       51      517
5       51      518
5       51      519
5       52      520     259
5       52      521
5       52      522     260
5       52      523
5       52      524     261
5       52      525
5       52      526     262
5       52      527
5       52      528     263
5       52      529
5       53      530
5       53      531
5       53      532
5       53      533
5       53      534
5       53      535
5       53      536
5       53      537
5       53      538
5       53      539
5       54      540     269
5       54      541
5       54      542     270
5       54      543
5       54      544     271
5       54      545
5       54      546     272
5       54      547
5       54      548     273
5       54      549
5       55      550
5       55      551
5       55      552
5       55      553
5       55      554
5       55      555
5       55      556
5       55      557
5       55      558
5       55      559
5       56      560     279
5       56      561
5       56      562     280
5       56      563
5       56      564     281
5       56      565
5       56      566     282
5       56      567
5       56      568     283
5       56      569
5       57      570
5       57      571
5       57      572
5       57      573
5       57      574
5       57      575
5       57      576
5       57      577
5       57      578
5       57      579
5       58      580     289
5       58      581
5       58      582     290
5       58      583
5       58      584     291
5       58      585
5       58      586     292
5       58      587
5       58      588     293
5       58      589
5       59      590
5       59      591
5       59      592
5       59      593
5       59      594
5       59      595
5       59      596
5       59      597
5       59      598
5       59      599
6       60      600
6       60      601
6       60      602
6       60      603
6       60      604
6       60      605
6       60      606
6       60      607
6       60      608
6       60      609
6       61      610     304
6       61      611
6       61      612     305
6       61      613
6       61      614     306
6       61      615
6       61      616     307
6       61      617
6       61      618     308
6       61      619
6       62      620
6       62      621
6       62      622
6       62      623
6       62      624
6       62      625
6       62      626
6       62      627
6       62      628
6       62      629
6       63      630     314
6       63      631
6       63      632     315
6       63      633
6       63      634     316
6       63      635
6       63      636     317
6       63      637
6       63      638     318
6       63      639
6       64      640
6       64      641
6       64      642
6       64      643
6       64      644
6       64      645
6       64      646
6       64      647
6       64      648
6       64      649
6       65      650     324
6       65      651
6       65      652     325
6       65      653
6       65      654     326
6       65      655
6       65      656     327
6       65      657
6       65      658     328
6       65      659
6       66      660
6       66      661
6       66      662
6       66      663
6       66      664
6       66      665
6       66      666
6       66      667
6       66      668
6       66      669
6       67      670     334
6       67      671
6       67      672     335
6       67      673
6       67      674     336
6       67      675
6       67      676     337
6       67      677
6       67      678     338
6       67      679
6       68      680
6       68      681
6       68      682
6       68      683
6       68      684
6       68      685
6       68      686
6       68      687
6       68      688
6       68      689
6       69      690     344
6       69      691
6       69      692     345
6       69      693
6       69      694     346
6       69      695
6       69      696     347
6       69      697
6       69      698     348
6       69      699
7       70      700     349
7       70      701
7       70      702     350
7       70      703
7       70      704     351
7       70      705
7       70      706     352
7       70      707
7       70      708     353
7       70      709
7       71      710
7       71      711
7       71      712
7       71      713
7       71      714
7       71      715
7       71      716
7       71      717
7       71      718
7       71      719
7       72      720     359
7       72      721
7       72      722     360
7       72      723
7       72      724     361
7       72      725
7       72      726     362
7       72      727
7       72      728     363
7       72      729
7       73      730
7       73      731
7       73      732
7       73      733
7       73      734
7       73      735
7       73      736
7       73      737
7       73      738
7       73      739
7       74      740     369
7       74      741
7       74      742     370
7       74      743
7       74      744     371
7       74      745
7       74      746     372
7       74      747
7       74      748     373
7       74      749
7       75      750
7       75      751
7       75      752
7       75      753
7       75      754
7       75      755
7       75      756
7       75      757
7       75      758
7       75      759
7       76      760     379
7       76      761
7       76      762     380
7       76      763
7       76      764     381
7       76      765
7       76      766     382
7       76      767
7       76      768     383
7       76      769
7       77      770
7       77      771
7       77      772
7       77      773
7       77      774
7       77      775
7       77      776
7       77      777
7       77      778
7       77      779
7       78      780     389
7       78      781
7       78      782     390
7       78      783
7       78      784     391
7       78      785
7       78      786     392
7       78      787
7       78      788     393
7       78      789
7       79      790
7       79      791
7       79      792
7       79      793
7       79      794
7       79      795
7       79      796
7       79      797
7       79      798
7       79      799
8       80      800
8       80      801
8       80      802
8       80      803
8       80      804
8       80      805
8       80      806
8       80      807
8       80      808
8       80      809
8       81      810     404
8       81      811
8       81      812     405
8       81      813
8       81      814     406
8       81      815
8       81      816     407
8       81      817
8       81      818     408
8       81      819
8       82      820
8       82      821
8       82      822
8       82      823
8       82      824
8       82      825
8       82      826
8       82      827
8       82      828
8       82      829
8       83      830     414
8       83      831
8       83      832     415
8       83      833
8       83      834     416
8       83      835
8       83      836     417
8       83      837
8       83      838     418
8       83      839
8       84      840
8       84      841
8       84      842
8       84      843
8       84      844
8       84      845
8       84      846
8       84      847
8       84      848
8       84      849
8       85      850     424
8       85      851
8       85      852     425
8       85      853
8       85      854     426
8       85      855
8       85      856     427
8       85      857
8       85      858     428
8       85      859
8       86      860
8       86      861
8       86      862
8       86      863
8       86      864
8       86      865
8       86      866
8       86      867
8       86      868
8       86      869
8       87      870     434
8       87      871
8       87      872     435
8       87      873
8       87      874     436
8       87      875
8       87      876     437
8       87      877
8       87      878     438
8       87      879
8       88      880
8       88      881
8       88      882
8       88      883
8       88      884
8       88      885
8       88      886
8       88      887
8       88      888
8       88      889
8       89      890     444
8       89      891
8       89      892     445
8       89      893
8       89      894     446
8       89      895
8       89      896     447
8       89      897
8       89      898     448
8       89      899
9       90      900     449
9       90      901
9       90      902     450
9       90      903
9       90      904     451
9       90      905
9       90      906     452
9       90      907
9       90      908     453
9       90      909
9       91      910
9       91      911
9       91      912
9       91      913
9       91      914
9       91      915
9       91      916
9       91      917
9       91      918
9       91      919
9       92      920     459
9       92      921
9       92      922     460
9       92      923
9       92      924     461
9       92      925
9       92      926     462
9       92      927
9       92      928     463
9       92      929
9       93      930
9       93      931
9       93      932
9       93      933
9       93      934
9       93      935
9       93      936
9       93      937
9       93      938
9       93      939
9       94      940     469
9       94      941
9       94      942     470
9       94      943
9       94      944     471
9       94      945
9       94      946     472
9       94      947
9       94      948     473
9       94      949
9       95      950
9       95      951
9       95      952
9       95      953
9       95      954
9       95      955
9       95      956
9       95      957
9       95      958
9       95      959
9       96      960     479
9       96      961
9       96      962     480
9       96      963
9       96      964     481
9       96      965
9       96      966     482
9       96      967
9       96      968     483
9       96      969
9       97      970
9       97      971
9       97      972
9       97      973
9       97      974
9       97      975
9       97      976
9       97      977
9       97      978
9       97      979
9       98      980     489
9       98      981
9       98      982     490
9       98      983
9       98      984     491
9       98      985
9       98      986     492
9       98      987
9       98      988     493
9       98      989
9       99      990
9       99      991
9       99      992
9       99      993
9       99      994
9       99      995
9       99      996
9       99      997
9       99      998
9       99      999
10      100     1000    499
*/