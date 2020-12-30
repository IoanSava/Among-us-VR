using UnityEngine;

public class UseNotebook : MonoBehaviour
{
    private void Start()
    {
        TeleportPlayersToCafeteria();
    }

    private Transform GetTeleportPoint()
    {
        int randomNumber = Random.Range(0, GameController.instance.teleportPoints.Length);
        return GameController.instance.teleportPoints[randomNumber];
    }

    public void TeleportPlayersToCafeteria()
    {
        Debug.Log("Start game");
        GameObject.Find("[VRSimulator_CameraRig]").transform.position = GetTeleportPoint().position;
    }
}
