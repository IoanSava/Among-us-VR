using UnityEngine;
using Photon.Pun;

public class CharacterMovement : MonoBehaviourPun
{
    void Update()
    {
        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
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
