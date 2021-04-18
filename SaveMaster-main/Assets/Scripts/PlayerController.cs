
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float smoothTime = 0.1f;
    [SerializeField]
    float joystickSpeed = 30f;

    float speed = 0f;

    Vector3 direction = Vector3.zero;

    public Transform bodyObject;

    bool myShouldMove = true;

    Rigidbody body = default;

    public FloatingJoystick variableJoystick;

    AnimationController animationController;
    CrushController crushController;

    private void Awake()
    {
        crushController = GetComponent<CrushController>();

        animationController = GetComponent<AnimationController>();

        body = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        myShouldMove = crushController.shouldMove;

        WalkControl();

        animationController.SetSpeed(speed);
    }

    private void FixedUpdate()
    {
        MovingContwithJoystick();
    }

    void MovingContwithJoystick()
    {
        if (myShouldMove)
        {
            direction = (Vector3.right * variableJoystick.Vertical + Vector3.back * variableJoystick.Horizontal)
                * Time.fixedDeltaTime * joystickSpeed;

            transform.LookAt(transform.position + direction.normalized);

            body.velocity = direction;
        }
    }
    void WalkControl()
    {
        if (direction.magnitude > 0.05f)
        {
            speed = 2f;
        }
        else
        {
            speed = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Child"))
        {
            Vector3 currentPos = transform.position;
            Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
            Destroy(other.gameObject);
        }
    }
}
