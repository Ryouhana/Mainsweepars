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
        // Update と同様に、スクリプトが有効な限り回り続ける
        while (true)
        {
            // 2秒間、X軸に回転
            yield return Rotate(Vector3.right, 2);

            // 1秒待つ
            yield return new WaitForSeconds(1);

            // 2秒間、Y軸に回転
            yield return Rotate(Vector3.up, 2);

            // 1秒待つ
            yield return new WaitForSeconds(1);

            // 2秒間、Z軸に回転
            yield return Rotate(Vector3.forward, 2);

            // 1秒待つ
            //yield return new WaitForSeconds(1);
            // クリックを待つ
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
