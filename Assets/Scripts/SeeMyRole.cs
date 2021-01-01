using Photon.Pun;
using UnityEngine;

public class SeeMyRole : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName} is impostor: {PhotonNetwork.LocalPlayer.CustomProperties["isImpostor"]}");
    }
}
