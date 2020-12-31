using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform[] spawnPoints;
    public Transform[] teleportPoints;
    public Material[] playerColors;

    void Awake()
    {
        instance = this;
    }
}
