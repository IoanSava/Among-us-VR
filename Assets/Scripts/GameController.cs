using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform[] spawnPoints;

    void Start()
    {
        instance = this;
    }
}
