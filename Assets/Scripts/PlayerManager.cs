using Photon.Pun;
using UnityEngine;
using VRTK.Examples.Archery;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;

    private void AttachVRTK()
    {
        Vector3 currentPosition = transform.position;
        GameObject cameraRig = GameObject.Find("[VRSimulator_CameraRig]");
        cameraRig.transform.position = currentPosition;

        var boxCollider = gameObject.GetComponent<BoxCollider>();
        var newBoxCollider = cameraRig.AddComponent<BoxCollider>();
        newBoxCollider.center = boxCollider.center;
        newBoxCollider.size = boxCollider.size;
        Destroy(boxCollider);
        
        var followComponent = gameObject.GetComponent<Follow>();
        followComponent.enabled = true;
        followComponent.target = cameraRig.transform;
    }

    void Start()
    {
        if (photonView.IsMine)
        {
            AttachVRTK();
        } 
        else 
            Debug.Log("Not my camera"); 
            
    }

    void Awake()
    {
        // #Important
        // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
        if (photonView.IsMine)
        {
            LocalPlayerInstance = gameObject;
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(gameObject);
    }

#if UNITY_5_4_OR_NEWER
    public override void OnDisable()
    {
        // Always call the base to remove callbacks
        base.OnDisable();
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }
#endif

#if !UNITY_5_4_OR_NEWER
    /// <summary>See CalledOnLevelWasLoaded. Outdated in Unity 5.4.</summary>
    void OnLevelWasLoaded(int level)
    {
        this.CalledOnLevelWasLoaded(level);
    }
#endif

    void CalledOnLevelWasLoaded(int level)
    {
        // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
        if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
        {
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }

#if UNITY_5_4_OR_NEWER
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode loadingMode)
    {
        CalledOnLevelWasLoaded(scene.buildIndex);
    }
#endif
}
