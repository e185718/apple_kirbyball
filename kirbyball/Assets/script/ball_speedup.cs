using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_speedup : MonoBehaviour
{
     void OnTriggerEnter(Collider other){
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,10),ForceMode.VelocityChange);
    }
}