using UnityEngine;

public class sample2 : MonoBehaviour
{
    
    void Start()
    {
        // # 多次元配列の初期化子
        // 配列初期化子は次元毎に { } を入れ子にして多重化できる
        // `new 要素型[要素数, 要素数] { { 要素1, 要素2, }, { ... }, ... }`
        // var iAry = new int[2, 3] { { 10, 20, 30 } { 100, 200, 300 } };
        // 上の初期化の場合
        // iAry[0, 0] = 10; iAry[0, 1] = 20; iAry[0, 2] = 30;
        // iAry[1, 0] = 100; iAry[1, 1] = 200; iAry[1, 2] = 300;
        // と同義
        var iAry = new int[2, 3]
        {
            { 10, 20, 30 },
            { 100, 200, 300 }
        };
        Debug.Log($"[0, 0]={iAry[0, 0]}, [0, 1]={iAry[0, 1]}, [0, 2]={iAry[0, 2]}");
        Debug.Log($"[1, 0]={iAry[1, 0]}, [1, 1]={iAry[1, 1]}, [1, 2]={iAry[1, 2]}");
    }
}