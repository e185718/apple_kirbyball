using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_speedup : MonoBehaviour
{
     void OnTriggerEnter(Collider other){
         //int i = 0;
        // while(i < 100){
         //    other.gameObject.GetComponent<Rigidbody>().transform.Translate(Vector3.right*0.1f);
        //     i++;
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,20),ForceMode.VelocityChange);
        }
}