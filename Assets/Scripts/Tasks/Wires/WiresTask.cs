using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresTask : MonoBehaviour
{

    public List<Color> _wireColors = new List<Color>();
    public List<Wire> _leftWires = new List<Wire>();
    public List<Wire> _rightWires = new List<Wire>();

    private List<Color> _availableColors;
    private List<int> _availableLeftWiresIndex;
    private List<int> _availableRightWiresIndex;

    public Wire CurrentDraggedWire;
    public Wire CurrentHoveredWire;
    public bool IsTaskCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        _availableColors = new List<Color>(_wireColors);
        _availableLeftWiresIndex = new List<int>();
        _availableRightWiresIndex = new List<int>();

        for(int i = 0; i < _leftWires.Count; i++)
            _availableLeftWiresIndex.Add(i);
        for (int i = 0; i < _rightWires.Count; i++)
            _availableRightWiresIndex.Add(i);

        while (_availableColors.Count > 0 && _availableLeftWiresIndex.Count > 0 &&
               _availableRightWiresIndex.Count > 0)
        {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftWireIndex = Random.Range(0, _availableLeftWiresIndex.Count);
            int pickedRightWireIndex = Random.Range(0, _availableRightWiresIndex.Count);

            _leftWires[_availableLeftWiresIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            _rightWires[_availableRightWiresIndex[pickedRightWireIndex]].SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableLeftWiresIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWiresIndex.RemoveAt(pickedRightWireIndex);
        }

        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion()
    {
        while (!IsTaskCompleted)
        {
            int connectedWires = 0;
            for (int i = 0; i < _rightWires.Count; i++)
            {
                if (_rightWires[i].IsConnected)
                    connectedWires++;
            }

            if (connectedWires >= _rightWires.Count)
            {
                Debug.Log("TASK COMPLETED!");
            }
            else
            {
                Debug.Log("ONGOING TASK...");
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
