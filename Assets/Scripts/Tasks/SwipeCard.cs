using UnityEngine;

public class SwipeCard : MonoBehaviour
{
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                     _canvas.transform as RectTransform,
                     Input.mousePosition,
                     _canvas.worldCamera,
                     out Vector2 pos);
            transform.position = _canvas.transform.TransformPoint(pos);
        }
    }
}