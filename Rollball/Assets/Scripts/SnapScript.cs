using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScript : MonoBehaviour
{
    Plane groundPlane;
    Vector3 downPosition3D;
    Vector3 upPosition3D;

    public Text numText; // 回数の UI

    public GameObject sphere;
    public float thrust = 3f;
    private int num; // 回数

    float rayDistance;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        groundPlane = new Plane(Vector3.up, 0f);
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Rigidbody取得
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        //print(rb.velocity.magnitude);
        if (rb.velocity.magnitude == 0.00000)
        {
            if (Input.GetMouseButtonDown(0)) // 左クリックを押した時
            {
                downPosition3D = GetCursorPosition3D();
            }
            else if (Input.GetMouseButtonUp(0)) // 左クリックを離した時
            {
                upPosition3D = GetCursorPosition3D();

                if (downPosition3D != ray.origin && upPosition3D != ray.origin)
                {
                    sphere.GetComponent<Rigidbody>().AddForce((downPosition3D - upPosition3D) * thrust, ForceMode.Impulse); // ボールをはじく
                    num = num + 1; //回数を加算
                    // UI の表示を更新します
                    SetCountText();
                }
            }
        }

    }

    Vector3 GetCursorPosition3D()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // マウスカーソルから、カメラが向く方へのレイ
        groundPlane.Raycast(ray, out rayDistance); // レイを飛ばす

        return ray.GetPoint(rayDistance); // Planeとレイがぶつかった点の座標を返す

    }
    // UI の表示を更新する
    void SetCountText()
    {
        // 回数の表示を更新
        numText.text = "num: " + num.ToString();
    }

}