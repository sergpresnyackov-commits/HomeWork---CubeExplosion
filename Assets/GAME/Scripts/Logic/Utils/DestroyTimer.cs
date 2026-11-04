using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float _delay;

    private void Start()
    {
        Destroy(gameObject, _delay);
    }
}