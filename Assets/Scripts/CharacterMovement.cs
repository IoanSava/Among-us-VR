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
        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            Vector3 moveBy = transform.right * z * -1 + transform.forward * x;
            rigidBody.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                GetComponent<Animator>().SetBool("isMoving", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isMoving", false);
            }
        }
    }
}
