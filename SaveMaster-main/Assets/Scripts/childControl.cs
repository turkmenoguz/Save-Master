using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childControl : MonoBehaviour
{
    private Transform head;

    [SerializeField]
    float speed;
    [Range(0.0f, 1.0f)]
    public float overTime = 0.5f;

    [SerializeField]
    GameObject particleDieEffect = default;

    bool canMove = true;

    Animator animator = default;

    private Vector3 movementVelocity;

    void Start()
    {
        animator = GetComponent<Animator>();

        head = GameObject.FindGameObjectWithTag("FollowPoint").gameObject.transform;
    }

    private void FixedUpdate()
    {
        Mover();
    }

    void Mover()
    {
        if (canMove)
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, overTime);

            transform.LookAt(head.transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("left") || collision.gameObject.CompareTag("right"))
        {
            canMove = false;

            gameObject.tag = "DeadChild";

            animator.SetBool("Die", true);
            GetComponent<Rigidbody>().isKinematic = true;
            gameObject.layer = 11;

            Invoke("ParticleEffect", 2.9f);
            Destroy(gameObject, 3f);
        }
    }

    void ParticleEffect()
    {
        print("a");
        GameObject particle = Instantiate(particleDieEffect, transform.position, Quaternion.identity);
        Destroy(particle, 3f);
    }

}
