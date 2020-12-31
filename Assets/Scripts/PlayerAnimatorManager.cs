using Photon.Pun;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviourPun
{
    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("isDead"))
            {
                Animator.SetBool("isDead", true);
            }
            else
            {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");
                if (x != 0 || y != 0)
                {
                    Animator.SetBool("isMoving", true);
                }
                else
                {
                    Animator.SetBool("isMoving", false);
                }
            }
        }
    }
}

