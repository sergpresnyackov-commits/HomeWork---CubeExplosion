using System;
using UnityEngine;

[RequireComponent(typeof(MouseInput))]
public class RaycastHandler : MonoBehaviour
{
    public event Action<RaycastHit> RaycastCreated;

    private MouseInput _inputHandler;

    private Ray _ray;

    private void Awake()
    {
        if (TryGetComponent(out MouseInput inputHandler))
        {
            _inputHandler = inputHandler;
        }
    }

    private void OnEnable()
    {
        _inputHandler.MouseClicked += CreateRaycast;
    }

    private void OnDisable()
    {
        _inputHandler.MouseClicked -= CreateRaycast;
    }

    private void CreateRaycast(Vector3 position)
    {
        _ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
        {
            RaycastCreated?.Invoke(hit);
        }
    }
}