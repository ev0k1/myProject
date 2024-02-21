using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class VintRotate : MonoBehaviour
{
    [Header("Main Settings")]
    private Vector3 rotate = new Vector3(0,0,1);
    [SerializeField]private float speed;

    
    void FixedUpdate()
    {
        transform.eulerAngles += rotate * -speed * Time.fixedDeltaTime;
    }
}
