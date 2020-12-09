using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class Launcher : MonoBehaviourPunCallbacks
{
    string gameVersion="1";

    void Awake()
        {
            // #Critical
            // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }

    #region Public Methods
    void Start()
        {
            Debug.Log("asd");
            Connect();
        }
    
    public void Connect()
        {
            // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
{
    Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
}


public override void OnDisconnected(DisconnectCause cause)
{
    Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
}
}
