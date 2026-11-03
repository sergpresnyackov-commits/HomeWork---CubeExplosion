using UnityEngine;

public class PaintHandler : MonoBehaviour
{
    [SerializeField] private Color _nextColor = Color.red;

    [SerializeField] private bool _randomizeColor = true;

    public void PaintObject(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Renderer renderer))
        {
            if (_randomizeColor)
            {
                renderer.material.color = Random.ColorHSV();
            }
            else
            {
                renderer.material.color = _nextColor;
            }
        }
    }
}