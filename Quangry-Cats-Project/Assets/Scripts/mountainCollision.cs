using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mountainCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter collision");
        Debug.Log(collision.gameObject.tag);
    }
}
