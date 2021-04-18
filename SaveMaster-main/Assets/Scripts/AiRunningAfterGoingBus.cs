using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRunningAfterGoingBus : MonoBehaviour
{
    //first ai 
    Transform busPosition = default;

    bool isGoingBus = false;

    float step = 15f;

    float borderForMoveTowardsTheBus = -4f;
    [SerializeField]
    Material[] followingAiMaterial = default;

    private void Start()
    {
        busPosition = GameObject.FindGameObjectWithTag("bus").transform;
    }

    private void LateUpdate()
    {
        if (isGoingBus || transform.position.x < borderForMoveTowardsTheBus)
        {
            if ( Mathf.Abs(transform.position.z)<47)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;

                GetComponentInChildren<SkinnedMeshRenderer>().materials = followingAiMaterial;

                transform.LookAt(busPosition);

                isGoingBus = true;
            }

            transform.position = Vector3.MoveTowards(transform.position,
                busPosition.position, step * Time.deltaTime);
        }
    }
}
