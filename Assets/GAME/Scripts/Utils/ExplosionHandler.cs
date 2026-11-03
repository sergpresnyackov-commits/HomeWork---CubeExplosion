using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _offset = 1f;
    [SerializeField] private float _force = 1f;
    [SerializeField] private float _upwardModifier = 1f;

    public void ExplodeObject(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            float randomX = Random.Range(-_offset, _offset);
            float randomY = Random.Range(-_offset, _offset);
            float randomZ = Random.Range(-_offset, _offset);

            Vector3 offsetVector = new Vector3(randomX, randomY, randomZ);

            rigidbody.AddExplosionForce(_force, transform.position + offsetVector, _radius, _upwardModifier, ForceMode.Impulse);
        }
    }
}