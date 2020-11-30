using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SnapScript2 : MonoBehaviour
{
    Plane groudPlane;
    Vector3 downPosition3D;
    Vector3 upPosition3D;

    public GameObject sphere;
    public float thurst = 3f;

    public Text countText;
    public Text winText;
    public Text pushText;

    private Rigidbody rb;
    private int count;

    float rayDistance;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        groudPlane = new Plane(Vector3.up, 0f);

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        pushText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //左クリックを押した時
        {
            downPosition3D = GetCursorPosition3D();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            upPosition3D = GetCursorPosition3D();

            if (downPosition3D != ray.origin && upPosition3D != ray.origin)
            {
                sphere.GetComponent<Rigidbody>().AddForce((downPosition3D - upPosition3D) * thurst, ForceMode.Impulse); //ボールを弾く
            }
        }
    }

    Vector3 GetCursorPosition3D()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//マウスカーソルから,カメラが向く方向へのレイ

        groudPlane.Raycast(ray, out rayDistance); //レイを飛ばす

        return ray.GetPoint(rayDistance);//Planeとレイがぶつかった点の座標を返す
    }





    //取ったボールをカウントする
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You Win!";
            pushText.text = "Right　Button Push";
        }
    }

}



