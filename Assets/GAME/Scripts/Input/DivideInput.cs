using UnityEngine;

public class DivideInput : MonoBehaviour
{
    [SerializeField] private MouseInput _divideInput;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)_divideInput))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.TryGetComponent<DivideObject>(out DivideObject divideObject))
                {
                    divideObject.Divide();
                }
            }
        }
    }

    private enum MouseInput 
    {
        LeftMouseBtn,
        RightMouseBtn,
    }
}