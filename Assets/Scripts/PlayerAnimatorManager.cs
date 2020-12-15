using Photon.Pun;

public class PlayerAnimatorManager : MonoBehaviourPun
{
    void Start()
    {

    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
    }
}
