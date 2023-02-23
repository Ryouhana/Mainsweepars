using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sample20230113 : MonoBehaviour
{
     private void Start()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        // Update �Ɠ��l�ɁA�X�N���v�g���L���Ȍ����葱����
        while (true)
        {
            // 2�b�ԁAX���ɉ�]
            yield return Rotate(Vector3.right, 2);

            // 1�b�҂�
            yield return new WaitForSeconds(1);

            // 2�b�ԁAY���ɉ�]
            yield return Rotate(Vector3.up, 2);

            // 1�b�҂�
            yield return new WaitForSeconds(1);

            // 2�b�ԁAZ���ɉ�]
            yield return Rotate(Vector3.forward, 2);

            // 1�b�҂�
            //yield return new WaitForSeconds(1);
            // �N���b�N��҂�
           // yield return new WaitForClick();

        }
    }

    private IEnumerator Rotate(Vector3 axis, float duration)
    {
        for (var t = 0F; t < duration; t += Time.deltaTime)
        {
            transform.Rotate(axis, Space.World);
            yield return null;
        }
    }
}
