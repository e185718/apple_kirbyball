using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;

    void Update() {

        // transformを取得
        Transform Transform = this.transform;

        // 座標を取得
        Vector3 cube_tmp = Transform.position;

        if(cube_tmp.y  <= -10){
            SceneManager.LoadScene("Scenes/gameover");
        }
    }
    private void FixedUpdate()
    {
        rb.velocity *= 0.9f;    // 毎フレーム速度を0.99倍する
    }


}
