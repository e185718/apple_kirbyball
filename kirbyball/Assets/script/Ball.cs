using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    void Update() {
 
        // transformを取得
        Transform Transform = this.transform;
 
        // 座標を取得
        Vector3 cube_tmp = Transform.position;

        if(cube_tmp.y  <= -10){
            SceneManager.LoadScene("Scenes/gameover");
        }
    }
    
}
