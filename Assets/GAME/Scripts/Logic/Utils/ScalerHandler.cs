using UnityEngine;

public class ScalerHandler : MonoBehaviour
{
    [SerializeField] private float _scaleMultiplier = 0.5f;

    public void ScaleObject(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Transform transform))
        {
            transform.localScale *= _scaleMultiplier;
        }
    }
}