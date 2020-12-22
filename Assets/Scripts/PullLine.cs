using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullLine : MonoBehaviour
{
    Plane groundPlane;
    Vector3 downPosition3D;
    Vector3 upPosition3D;
    Vector3 Position3D;


    public Text numText; // 回数の UI
    public Text numText2; // 回数の UI
    public Text loseText; // 負けの UI

    public GameObject sphere;
    public float thrust = 3f;
    public float remain = 6;
    private int num = 0; // 回数
    float distance; //距離
    private float max = 5f; // 制限
    private float mini = -5f;
    public LineRenderer line;

    float rayDistance;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        groundPlane = new Plane(Vector3.up, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        // Rigidbody取得
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        //print(rb.velocity.magnitude);
        Vector3 pos = sphere.transform.position;
        print(rb.IsSleeping());
        if (rb.IsSleeping())
        { 
            // UI の表示を更新します
            SetCountText2();

            if (Input.GetMouseButtonDown(0))
            {
                print(numText2.enabled);
                downPosition3D = GetCursorPosition3D();
            }
            else if (Input.GetMouseButton(0))
            {
                numText2.enabled = false;
                Position3D = GetCursorPosition3D();
                distance = Vector3.Distance(downPosition3D, Position3D);
                Vector3 oppopos1 = pos - Position3D + downPosition3D;
                Vector3 oppopos2 = pos - downPosition3D + downPosition3D;
                Vector3 oppopos = oppopos1;

                line.positionCount = 2;
                line.SetPosition(0, oppopos);
                line.SetPosition(1, oppopos2);
                if (distance < 1)
                {
                    line.positionCount = 0;
                }

            }

            else if (Input.GetMouseButtonUp(0))
            {
                numText2.enabled = false;
                upPosition3D = GetCursorPosition3D();

                if (downPosition3D != ray.origin && upPosition3D != ray.origin)
                {
                 
                    Vector3 v = new Vector3(1.0f, 0.0f, 1.0f);
                    Vector3 force = downPosition3D - Position3D;
                    print(distance);
                    //矢印を戻しやすくする。
                    if (distance < 1)
                    {
                        force = new Vector3(0.0f, 0.0f, 0.0f);
                    }
                    Vector3 force2 = new Vector3(Mathf.Clamp(force.x, mini, max), 0, Mathf.Clamp(force.z, mini, max));
                    print(force2);
                    sphere.GetComponent<Rigidbody>().AddForce((force) * thrust, ForceMode.Impulse); // ボールをはじく
                    line.positionCount = 0;
                    if (force != Vector3.zero)
                    {
                        num = num + 1; //回数を加算
                        remain = remain - 1;
                    }
                    // UI の表示を更新します
                    SetCountText();
                }
            }
        }
        else
        {
            print("動いてる");
            numText2.enabled = false;
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

    void SetCountText2()
    {
        if (remain == 0)
        {
            loseText.enabled = true;
            loseText.text = "You Lose!!";
        }
        else
        {
            // 回数の表示を更新
            loseText.enabled = false;
            numText2.enabled = true;
            numText2.text = "残り" + remain.ToString() + "回";
        }

    }

}