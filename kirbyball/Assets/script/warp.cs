using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    private GameObject cube;
    public warp trans;
    private Vector3 transVec;//移動先の座標を保存する場所

    public bool moveStatus;
 
    void Start()
    {
        //移動先の座標を取得する
        transVec = trans.transform.position;
        transVec.y += 0.5f;

        moveStatus = true;
    }
 

    void OnTriggerEnter(Collider other)
　　{
　　　　cube = GameObject.Find(other.name);
　　　　//自分が移動可能なとき移動する。
　　　　if (moveStatus)
　　　　{
　　　　　　//移動先は直後移動できないようにする。一旦離れないとワープできない。
　　　　　　trans.moveStatus = false;
          
          //cubeの座標に移動先のcubeの座標を代入する。
          cube.transform.position = transVec;

          Rigidbody rb = other.gameObject.GetComponent<Rigidbody>(); 
          rb.velocity = Vector3.zero;//ワープしたら加速度を0にする。
　　　　}
　　}

    void OnTriggerExit(Collider other)
　　{
　　　　//移動可能にする。
　　　　moveStatus = true;
　　}
//movestatusがtrueの時でないとワープすることができない。if文でtrueの時だけと設定しているため。
}