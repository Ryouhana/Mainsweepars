using UnityEngine;

public class sample2 : MonoBehaviour
{
    
    void Start()
    {
        // # �������z��̏������q
        // �z�񏉊����q�͎������� { } �����q�ɂ��đ��d���ł���
        // `new �v�f�^[�v�f��, �v�f��] { { �v�f1, �v�f2, }, { ... }, ... }`
        // var iAry = new int[2, 3] { { 10, 20, 30 } { 100, 200, 300 } };
        // ��̏������̏ꍇ
        // iAry[0, 0] = 10; iAry[0, 1] = 20; iAry[0, 2] = 30;
        // iAry[1, 0] = 100; iAry[1, 1] = 200; iAry[1, 2] = 300;
        // �Ɠ��`
        var iAry = new int[2, 3]
        {
            { 10, 20, 30 },
            { 100, 200, 300 }
        };
        Debug.Log($"[0, 0]={iAry[0, 0]}, [0, 1]={iAry[0, 1]}, [0, 2]={iAry[0, 2]}");
        Debug.Log($"[1, 0]={iAry[1, 0]}, [1, 1]={iAry[1, 1]}, [1, 2]={iAry[1, 2]}");
    }
}