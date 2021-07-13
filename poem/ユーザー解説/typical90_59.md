DAG上での到達判定は頂点$u$から到達できるかという情報を$N$個保持しておけばDPで求めることができます。

よって、$O(N(N+M))$で前計算しておくことで到達可能かの判定ができます。これについての高速化を図ります。

C# の `System.Collections.BitArray` は内部的には $O(N/32)$ 程度の長さの `int[]` の配列で保持しています。

さらに、`BitArray` 同士の演算はSIMD最適化されているので、256bits演算ができるCPUでは $O(N/256)$ 程度で動作します。

このくらいの速度が出るならばTLEを回避できます。

以上については、C++ の `std::bitset` でも同様です。

しかし、$10^{10}$ bits $≒ 1.25$ GB なのですべてを保持するとMLEしてしまいます。

頂点の入次数が0の場合を特別扱いしてBitArrayを更新せずに結果を計算してあげるなどの手法を取ればMLEを回避できます。

- C++: https://atcoder.jp/contests/typical90/submissions/23202899
- C#: https://atcoder.jp/contests/typical90/submissions/23185897

他の方法として、C# の `BitArray` は長さが可変なのでこれを利用してMLEを回避することもできます。

$B_i =\{頂点iに到達できる頂点の集合\}$ を保持すると考えます。トポロジカルソートされたDAGなので、$B_i$には$i$より大きな頂点は含まれません。

よって、$B_i$ の $i$ 以降は常に `false` なので省略することができて、サイズは $i$ 程度に抑えられます。

DP で遷移先と OR 演算を行うときだけ $B_i$ を拡張することで、メモリサイズを $10^5 \times (10^5+1) / 2$ bits $≒ 625$ MB程度に抑えることができます。

C#: https://atcoder.jp/contests/typical90/submissions/23269208
