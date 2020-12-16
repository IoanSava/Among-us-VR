// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CameraWork.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in PUN Basics Tutorial to deal with the Camera work to follow the player
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------


using UnityEngine;


namespace Photon.Pun.Demo.PunBasics
{
    /// <summary>
    /// Camera work. Follow a target
    /// </summary>
    public class CameraWork : MonoBehaviour
    {
        #region Private Fields


        [Tooltip("The distance in the local x-z plane to the target")]
        [SerializeField]
        private float distance = 7.0f;


        [Tooltip("The height we want the camera to be above the target")]
        [SerializeField]
        private float height = 3.0f;
        


        // cached transform of the target
        Transform cameraTransform;
        private Transform neckTransform;

        // maintain a flag internally to reconnect if target is lost or camera is switched
        bool isFollowing;


        // Cache for camera offset
        Vector3 cameraOffset = Vector3.zero;


        #endregion
        
        #region MonoBehaviour Callbacks
        
        void LateUpdate()
        {
            // The transform target may not destroy on level load,
            // so we need to cover corner cases where the Main Camera is different everytime we load a new scene, and reconnect when that happens
            if (cameraTransform == null && isFollowing)
            {
                OnStartFollowing();
            }


            // only follow is explicitly declared
            if (isFollowing)
            {
                Follow();
            }
        }


        #endregion


        #region Public Methods


        /// <summary>
        /// Raises the start following event.
        /// Use this when you don't know at the time of editing what to follow, typically instances managed by the photon network.
        /// </summary>
        public void OnStartFollowing()
        {
            cameraTransform = Camera.main.transform;
            isFollowing = true;
            Follow();
        }


        #endregion


        #region Private Methods


        /// <summary>
        /// Follow the target smoothly
        /// </summary>
        void Follow()
        {
            cameraOffset.z = -distance;
            cameraOffset.y = height;
            
            cameraTransform.position = transform.position + transform.TransformVector(cameraOffset);
            cameraTransform.rotation = transform.rotation;
        }
        
        #endregion
    }
}