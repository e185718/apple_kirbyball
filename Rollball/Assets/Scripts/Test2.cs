using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    Plane groundPlane;
    Vector3 downPosition3D;
    Vector3 upPosition3D;

    public Text numText; // 回数の UI

    public GameObject sphere;
    public float thrust = 3f;
    private int num; // 回数

    public GameObject line;
    private Vector3 firstpos;

    float rayDistance;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = line.transform;
        Vector3 pos = myTransform.position;
        firstpos = pos;
        groundPlane = new Plane(Vector3.up, 0f);
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = sphere.transform;
        Transform myTransform2 = line.transform;
        // 座標を取得
        Vector3 worldAngle = myTransform.eulerAngles;
        Vector3 pos = myTransform.position;
        Vector3 worldAngle2 = myTransform2.eulerAngles;
        Vector3 pos2 = myTransform2.position;
        // Rigidbody取得
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        //print(rb.velocity.magnitude);

        if (Input.GetMouseButtonDown(0)) // 左クリックを押した時
        {
            downPosition3D = GetCursorPosition3D();
            print(pos);
            print(pos2);
            var x = pos.x;
            var y = pos.y;
            var z = pos.z;
            line.transform.localPosition = new Vector3(x, y, z);
        }
        //else if (Input.GetMouseButton(0)) // 左クリックを押した時
        
        else if (Input.GetMouseButtonUp(0))
        {
            upPosition3D = GetCursorPosition3D();

            if (downPosition3D != ray.origin && upPosition3D != ray.origin)
            {
                sphere.GetComponent<Rigidbody>().AddForce((downPosition3D - upPosition3D) * thrust, ForceMode.Impulse); // ボールをはじく
                num = num + 1; //回数を加算
                               // UI の表示を更新します
                SetCountText();

                downPosition3D = GetCursorPosition3D();
                var x = firstpos.x;
                var y = firstpos.y;
                var z = firstpos.z;
                line.transform.localPosition = new Vector3(x, y, z);
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