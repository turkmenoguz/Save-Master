using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick variableJoystick;
    public Rigidbody rb;
    Vector3 direction = Vector3.zero;

    float xBoundry = 15f;
    float yBoundry = 15f;

    AnimationController animationController;

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
    }


    private void Update()
    {
        Boundaries();
    }

    public void FixedUpdate()
    { 
           direction = Vector3.right * variableJoystick.Vertical + Vector3.back * variableJoystick.Horizontal;

           transform.LookAt(transform.position + direction.normalized);

            transform.position += direction * Time.fixedDeltaTime * speed;

            animationController.SetSpeed(speed);
      
    }
    void Boundaries()
    {

        if (!XBoundariesCheck() && !ZBoundariesCheck())
        {
            direction = Vector3.right * variableJoystick.Vertical + Vector3.back * variableJoystick.Horizontal;
            return;
        }
        else if (ZBoundariesCheck())
        {
            direction = Vector3.right * variableJoystick.Vertical;
            return;
        }
        else if (XBoundariesCheck())
        {
            direction = Vector3.back * variableJoystick.Horizontal;
            return;
        }
        else
        {
            direction = Vector3.zero;
            return;
        }
    }

    bool XBoundariesCheck()
    {
        if(transform.position.x > 15 || transform.position.x < -15)
        {
            return true;
        }else
        {
            return false;
        }
    }
    bool ZBoundariesCheck()
    {
        if (transform.position.z > 15 || transform.position.z < -15)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}