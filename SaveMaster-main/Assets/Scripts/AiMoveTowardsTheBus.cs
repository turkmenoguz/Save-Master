using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMoveTowardsTheBus : MonoBehaviour
{
    //for following ai behind the player.
    Transform busPosition = default;

    bool isGoingBus = false;

    float step = 15f;

    childControl ChildControl = default;

    float borderForMoveTowardsTheBus = -4f;

    private void Start()
    {
        busPosition = GameObject.FindGameObjectWithTag("bus").transform;

        ChildControl = GetComponent<childControl>();
    }
    
    private void LateUpdate()
    {
        if(isGoingBus || transform.position.x < borderForMoveTowardsTheBus)
        {
                if (ChildControl != null)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.zero;

                    ChildControl.enabled = false;

                    transform.LookAt(busPosition);

                    isGoingBus = true;
                }

                transform.position = Vector3.MoveTowards(transform.position, 
                    busPosition.position, step* Time.deltaTime);    
        }
    }
}
