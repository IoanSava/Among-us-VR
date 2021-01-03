using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

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
            if (!Animator.GetBool("isDead"))
            {
                if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("isDead"))
                {
                    Animator.SetBool("isDead", true);
                }
                else
                if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("isKilling") && (bool)PhotonNetwork.LocalPlayer.CustomProperties["isKilling"])
                {
                    PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "isKilling", false } });
                    Animator.SetBool("isKilling", true);
                }
                else
                {
                    float x = Input.GetAxis("Horizontal");
                    float y = Input.GetAxis("Vertical");
                    if (x != 0 || y != 0)
                    {
                        Animator.SetBool("isMoving", true);
                        Animator.SetBool("isKilling", false);
                    }
                    else
                    {
                        Animator.SetBool("isMoving", false);
                    }
                }
            }
        }
    }
}

