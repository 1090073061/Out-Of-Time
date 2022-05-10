using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMove))]
public class PlayerInput : MonoBehaviour
{
    public PlayerMove moveController;
    public float runSpeed = 40f;
    //public Animator animator;
    //[SerializeField] private Transform m_GroundCheck;
    private string cave = "Cave_Map";
    private string forest = "Forest";
    private string sky = "Sky_Map";
    private string finish = "End";

    float horizontalMove = 0;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        //moveController = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            //animator.SetBool("isJumping", true);
        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        //animator.SetBool("isJumping", false);
        //Debug.Log("Landed");
    }

    public void OnCrouching(bool isCrouching)
    {
        //animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        //Move Character
        moveController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;


    }
    void OnTriggerEnter(Collider other) 
	{
		
		if (other.gameObject.CompareTag ("Cave"))
		{
			SceneManager.LoadScene(cave);

		}
		if(other.gameObject.CompareTag("Forest"))
		{
			SceneManager.LoadScene(forest);

		}
        if(other.gameObject.CompareTag("Sky"))
		{
			SceneManager.LoadScene(sky);

		}
        if(other.gameObject.CompareTag("Finish"))
		{
			SceneManager.LoadScene(finish);

		}
	}
}
