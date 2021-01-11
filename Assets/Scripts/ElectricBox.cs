using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ElectricBox : MonoBehaviour
{
    public GameObject Task;

    void OnEnable()
    {
        Debug.Log("Touched Electric Box");
        Task.SetActive(true);
    }
}
