using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Pullshot;
    public GameObject cameracontroller;
    private int count = 0;
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        if (count == 0)
        {
            Pullshot.gameObject.SetActive(false);
            cameracontroller.gameObject.SetActive(true);
            count = count + 1;
        }
        else
        {
            Pullshot.gameObject.SetActive(true);
            cameracontroller.gameObject.SetActive(false);
            count = 0;
        }
        Debug.Log("押された!");  // ログを出力
    }
}