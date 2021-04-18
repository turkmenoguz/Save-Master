using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerborder : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

     void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 0f, Mathf.Clamp(transform.position.z, minZ, maxZ)); 
    }

}
