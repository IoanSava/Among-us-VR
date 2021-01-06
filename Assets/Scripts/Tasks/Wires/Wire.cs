using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour,  IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool IsLeftWire;
    public Color CustomColor;
    public bool IsConnected = false;

    private Image _image;
    private LineRenderer _lineRenderer;
    private Canvas _canvas;
    private bool _isDragStarted = false;
    private WiresTask _wiresTask;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wiresTask = GetComponentInParent<WiresTask>();
    }

    public void SetColor(Color color)
    {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        CustomColor = color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos);

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            // Hide the line if not dragging, but not if connected
            if (!IsConnected)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(
            transform as RectTransform,
            Input.mousePosition,
            _canvas.worldCamera);

        if (isHovered)
        {
            _wiresTask.CurrentHoveredWire = this;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // needed for drag but not used
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsLeftWire) { return; }
        // If it is connected, do not draw more lines
        if (IsConnected) { return; }

        _isDragStarted = true;
        _wiresTask.CurrentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wiresTask.CurrentHoveredWire != null)
        {
            if (_wiresTask.CurrentHoveredWire.CustomColor == CustomColor && !_wiresTask.CurrentHoveredWire.IsLeftWire)
            {
                IsConnected = true;
                // Set that is connected on the right wire as well
                _wiresTask.CurrentHoveredWire.IsConnected = true;
            }
        }

        _isDragStarted = false;
        _wiresTask.CurrentDraggedWire = null;
    }
}
