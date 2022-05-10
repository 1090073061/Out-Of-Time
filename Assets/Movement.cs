using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");                       
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;                   //direction is walk vector
        Vector3 direction2 = new Vector3(2 * horizontal, 0f, 2 * vertical).normalized;          //direction2 is run vector

        if (direction.magnitude < 0.1f)
        {
            Idle();           //if no WASD input
        }

        else if (direction.magnitude >= 0.1f && Input.GetKey(KeyCode.LeftShift))                                                //if WASD and Left Shift
        {
            float targetAngle = Mathf.Atan2(direction2.x, direction2.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            Run();
        }
        else                                                                                                                   //if only WASD          
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            Walk();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))            //Left click for combo animation
        {
            Combo();
        }
    }

    //ANIMATIONS

    private void Idle()
    {
        anim.SetFloat("Blend", 0f, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        anim.SetFloat("Blend", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Blend", 1f, 0.1f, Time.deltaTime);
    }

    private void Combo()
    {
        anim.SetTrigger("Attack");
    }
}
