using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController_Rock : MonoBehaviour
{

    Animator animator;
    int isAlertHash;
    int inProximityHash;

    Rigidbody rb;
    public GameObject Rock;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isAlertHash = Animator.StringToHash("isAlert");
        inProximityHash = Animator.StringToHash("inProximity");

        rb = transform.root.GetComponent<Rigidbody>();

        Rock = GameObject.Find("/Rock");

    }

    // Update is called once per frame
    void Update()
    {
        //  MOVEMENT 

        //Boolean parameters for movement
        bool _isAlert = animator.GetBool(isAlertHash);
        bool _inProximity = animator.GetBool(inProximityHash);
        bool checkAlert = Rock.GetComponent<EnemyAI>().GetComponent<EnemyAI>().isAlert;
        bool checkProximity = Rock.GetComponent<EnemyAI>().GetComponent<EnemyAI>().inProximity;
        //Check the parameters for movement and play animation
        if (rb.velocity.x != 0)
        {
            animator.SetBool("isAlert", true);
        }

        if (rb.velocity.x == 0)
        {
            animator.SetBool("isAlert", false);
        }


        if (!_inProximity && checkProximity)
        {
            animator.SetBool("inProximity", true);
        }

        if (_inProximity && !checkProximity)
        {
            animator.SetBool("inProximity", false);
        }
    }
}
