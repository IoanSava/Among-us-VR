using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float speed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
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
    }
}
