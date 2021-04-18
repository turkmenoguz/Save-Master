using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class AiController : MonoBehaviour
{
    Rigidbody aiRb = default;

    Vector3 aiVelocityDirection = Vector3.zero;

    [SerializeField]
    float zAngleHandler = 0f;
    [SerializeField]
    float xSpeedHandler = 0f;
    [SerializeField]
    GameObject particleDieEffect = default;

    Animator animator=default;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();

        aiRb = GetComponent<Rigidbody>();       
    }

    void Start()
    {
        if (transform.localPosition.z == 0)
        {
            zAngleHandler = Random.Range(0f, -xSpeedHandler * 0.5f);
        }
        else
        {
            zAngleHandler = Random.Range(0f, xSpeedHandler * 0.5f);
        }

        aiVelocityDirection = new Vector3(-xSpeedHandler, 0, zAngleHandler);

        aiRb.velocity = aiVelocityDirection; 
        
        transform.LookAt((transform.position + aiVelocityDirection.normalized)); 
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("left") || other.gameObject.CompareTag("right"))
        {
            gameObject.tag = "DeadChild";
            animator.SetBool("Die",true);

            aiRb.isKinematic = true;
            Invoke("ParticleEffect", 2.9f);

            Destroy(gameObject,3f);
        }
        if (other.gameObject.CompareTag("bus"))
        {
            Destroy(gameObject);
        }
    }
    void ParticleEffect()
    {
        GameObject particle = Instantiate(particleDieEffect, transform.position, Quaternion.identity);
        Destroy(particle, 3f);
    }
}
