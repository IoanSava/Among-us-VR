using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform[] spawnPoints;
    public Transform[] teleportPoints;

    void Awake()
    {
        instance = this;
    }
}
