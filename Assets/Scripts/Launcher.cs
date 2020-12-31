using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class Launcher : MonoBehaviourPunCallbacks
{
    string gameVersion = "2";

    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 5;
    private bool isConnectedMaster = false;
    private bool isConnecting;

    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    #region Public Methods
    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            Debug.Log("Is connected");
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }
    #endregion

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        isConnectedMaster = true;
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogFormat("Test Log: PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the arena ");

            // #Critical
            // Load the Room Level.
            PhotonNetwork.LoadLevel("AmongUsVR");
        }
    }

    public void CreateRoom()
    {
        if (isConnectedMaster)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
            //PhotonVoiceNetwork.Instance.Client.OpChangeGroups(new byte[0], BitConverter.GetBytes(roomId));
        }
        else
        {
            Debug.Log("Create Room Failed");
        }
    }

    public void JoinRandomRoom()
    {
        if (isConnectedMaster)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            Debug.Log("Join Random Room Failed");
        }
    }
}
