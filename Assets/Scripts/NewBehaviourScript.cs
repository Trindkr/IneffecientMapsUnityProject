using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rigid.AddForce(Input.acceleration);
    }
}

