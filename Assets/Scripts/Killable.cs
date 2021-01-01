using Photon.Pun;
using UnityEngine;

public class Killable : MonoBehaviourPun
{
    void OnEnable()
    {
        Debug.Log($"{PhotonNetwork.LocalPlayer.CustomProperties["isImpostor"]} - can kill");
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("isImpostor"))
        {
            bool isImpostor = (bool)PhotonNetwork.LocalPlayer.CustomProperties["isImpostor"];
            if (isImpostor)
            {
                Debug.Log("Kill someone");
            }
        }
    }
}
