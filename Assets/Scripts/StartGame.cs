using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class StartGame : MonoBehaviourPun
{
    void OnEnable()
    {
        TeleportPlayersToCafeteria();
    }

    private Transform GetTeleportPoint()
    {
        int randomNumber = Random.Range(0, GameController.instance.teleportPoints.Length);
        return GameController.instance.teleportPoints[randomNumber];
    }

    private int GetImpostorIndex()
    {
        return Random.Range(0, PhotonNetwork.CurrentRoom.Players.Count);
    }

    [PunRPC]
    private void AssignRole(int impostorIndex)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber - 1 == impostorIndex)
        {
            PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "isImpostor", true } });
        }
        else
        {
            PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "isImpostor", false } });
        }
    }

    [PunRPC]
    private void Teleport()
    {
        GameObject.Find("[VRSimulator_CameraRig]").transform.position = GetTeleportPoint().position;
    }

    public void TeleportPlayersToCafeteria()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Start game");
            photonView.RPC("AssignRole", RpcTarget.All, GetImpostorIndex());
            photonView.RPC("Teleport", RpcTarget.All);
        }
    }
}
