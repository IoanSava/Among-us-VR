using Photon.Pun;
using System.Collections;
using UnityEngine;
using VRTK;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Killable : MonoBehaviourPun
{
    public void OnEnable()
    {
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("isImpostor"))
        {
            bool isImpostor = (bool)PhotonNetwork.LocalPlayer.CustomProperties["isImpostor"];
            if (isImpostor)
            {
                PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "isKilling", true } });
                photonView.RPC("Kill", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    private void Kill()
    {
        if (!photonView.IsMine) { return; }
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "isDead", true } });
        DisableMovementAndRotation();
    }

    private void DisableMovementAndRotation()
    {
        SDK_InputSimulator inputSimulator = GameObject.Find("[VRSimulator_CameraRig]").GetComponent<SDK_InputSimulator>();
        inputSimulator.playerMoveMultiplier = 0;
        inputSimulator.playerRotationMultiplier = 0;
    }
}
