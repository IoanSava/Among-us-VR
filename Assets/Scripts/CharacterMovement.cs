using UnityEngine;
using Photon.Pun;

public class CharacterMovement : MonoBehaviourPun
{
    Rigidbody rigidBody;
    [SerializeField] float speed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
<<<<<<< HEAD
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
<<<<<<< HEAD
        Vector3 moveBy = transform.right * z * -1 + transform.forward * x;
        rigidBody.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
=======
        Vector3 moveBy = transform.right * x + transform.forward * z;
        rigidBody.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
>>>>>>> 871a754... merged with character_movements
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }
=======
		if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) {
        	float x = Input.GetAxisRaw("Horizontal");
        	float z = Input.GetAxisRaw("Vertical");
        	Vector3 moveBy = transform.right * x + transform.forward * z;
        	rigidBody.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

 	       if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
     	   {
      	      GetComponent<Animator>().SetBool("isMoving", true);
      	  	}
      	  	else
       	 	{
            	GetComponent<Animator>().SetBool("isMoving", false);
        	}
		}
>>>>>>> 42b2f74... added photonview
    }
}
