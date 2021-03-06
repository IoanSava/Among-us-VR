﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        #region Public Properties
        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefab;
        public static GameManager gm;
        #endregion

        #region Photon Callbacks


        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }


        #endregion

        #region Public Methods

        private Transform GetSpawnPoint()
        {
            int randomNumber = Random.Range(0, GameController.instance.spawnPoints.Length);
            return GameController.instance.spawnPoints[randomNumber];
        }

        private Material GetPlayerColor()
        {
            int randomNumber = Random.Range(0, GameController.instance.playerColors.Length);
            return GameController.instance.playerColors[randomNumber];
        }

        public void Start()
        {
            if (playerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                if (PlayerManager.LocalPlayerInstance == null)
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    Transform spawnPoint = GetSpawnPoint();
                    playerPrefab.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = GetPlayerColor();
                    PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity, 0);
                }
                else
                {
                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion

        #region Photon Callbacks

        // here we set nicknames, player model color
        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting
            // PhotonVoiceNetwork.Instance.Client.OpChangeGroups(new byte[0], BitConverter.GetBytes(int.Parse(PhotonNetwork.CurrentRoom.Name)));

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
            }
        }


        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
            }
        }


        #endregion
    }
}