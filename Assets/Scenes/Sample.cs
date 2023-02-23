using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField]
    private Vector3[] _rotations;



    private GameObject[] _cubes;

    void Start()
    {
        _cubes = new GameObject[_rotations.Length];
        for (var i = 0; i < _cubes.Length; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(-4 + i * 2, 0, 0);
            
            _cubes[i] = cube;
            
        }
    }

    private void Update()
    {
        /*  foreach ( var cube in _cubes)
          {
              cube.transform.Rotate(0, 500, 0);
          }*/
        // 奇数番号と偶数番号で回転の向きを変える
        /* for (var i = 0; i < _cubes.Length; i++)
         {
             var cube = _cubes[i];
             if (i % 2 == 0)
             {
                 cube.transform.Rotate(0, 1, 0);
             }
             else
             {
                 cube.transform.Rotate(0, -1, 0);
             }
         }*/
        for (var i = 0; i < _cubes.Length; i++)
        {
            var cube = _cubes[i];
            var rot = _rotations[i]; // 実行中に編集されるとエラー出るかも
            cube.transform.Rotate(rot);
        }

    }
    // Start is called before the first frame update
    /*  void Start()
      {
          *//*  // # 配列
            // 同じ型のデータを複数並べたもの
            // 配列が持つ個別のデータの事を要素という

            // ## 配列宣言
            // 要素型[] 変数名；
            int[] iAry; // 例えば int 型の配列

            // 配列型の変数初期値は null （中身がない）
            // なので初期化（実体化）しなければ使えない

            // ## 配列インスタンスの生成
            // new 要素型[要素数]
             iAry = new int[3]; // 例えば int 型配列生成

            // 配列の場合も型推論は有効
            // var iAry = new int[3]; // ok
            // ## 配列の要素へのアクセス
            // 配列は先頭を 0 とする番号で要素にアクセスする
            // 要素へのアクセスは配列型変数に [ ] 演算子を使う

            // 配列の各要素に値を代入する
            iAry[0] = 10;
            iAry[1] = 20;
            iAry[2] = 30;

            // 配列の各要素の値を取り出す
            Debug.Log($"iAry[0]={iAry[0]}");
            Debug.Log($"iAry[0]={iAry[1]}");
            Debug.Log($"iAry[0]={iAry[2]}");
    */
    /*       // # 配列初期化子
           // 配列は生成と同時に各要素の値を初期化できる
           // `new 要素型[要素数] { 要素1, 要素2, 要素3, ... }`
           // var iAry = new int[3] { 10, 20, 30 };
           // iAry[0] = 10; iAry[1] = 20; iAry[2] = 30; と同義

           // ## 要素数は初期する値の数は一致しなければならない
           // 初期化子の要素が要素数に対して少なくても多くてもダメ
           // var iAry = new int[3] { 10, 20 }; // エラー
           // var iAry = new int[3] { 10, 20, 30, 40 }; // エラー

           // ## 初期化子を持つ場合、要素数を省略可能
           // var iAry = new int[] { 10, 20, 30 };

           // ## 初期化子を持つ場合、要素型も省略可能
           var iAry = new[] { 10, 20, 30 };

           Debug.Log($"iAry[0]={iAry[0]}");
           Debug.Log($"iAry[1]={iAry[1]}");
           Debug.Log($"iAry[2]={iAry[2]}");

   */
    /*   // # 配列と反復処理
       // 配列の先頭からすべての要素を取り出す・検索するなど
       // 配列あるところに繰り返し文あり

       // ## 標準的な for 文による配列処理
       var iAry = new int[] { 10, 20, 30 };
       var len = iAry.Length; // 配列の要素数を取得する
       for (var i = 0; i < len; i++)
       {
           Debug.Log($"iAry[{i}]={iAry[i]}");
       }

       // ## foreach 文
       // 配列的なデータを先頭から順に要素を取り出す繰り返し文
       // 配列のインデックス管理が不要ならこっちを使う
       // `foreach(要素型 変数名 in 配列) 文;`
       foreach (var i in iAry)
       {
           Debug.Log($"foreach i={i}");
       }*//*
   }*/
}
