using System;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public event Action<Vector3> MouseClicked;

    [SerializeField] private MouseButtons _mouseBtn;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)_mouseBtn))
        {
            MouseClicked?.Invoke(Input.mousePosition);
        }
    }

    private enum MouseButtons 
    {
        LeftMouseBtn = 0,
        RightMouseBtn = 1,
    }
}