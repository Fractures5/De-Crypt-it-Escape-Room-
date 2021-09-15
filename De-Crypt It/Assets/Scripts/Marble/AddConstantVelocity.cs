using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddConstantVelocity : MonoBehaviour
{
    [SerializeField]// allows to change in the editor.
    Vector3 v3Force;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity += new Vector3(0.001f, 0, 0);
    }
}
