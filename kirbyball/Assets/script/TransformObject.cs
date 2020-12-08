using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TransformObject : MonoBehaviour
{
    Rigidbody rigidbody;
    void Start() {
        rigidbody = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        this.rigidbody.velocity = new Vector3(1f, 0, 0);
    }
}
