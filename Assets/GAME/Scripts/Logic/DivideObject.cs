using UnityEngine;

public class DivideObject : MonoBehaviour
{
    [SerializeField] private float _divideChance;
    [Space]
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionOffset;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionUpwardModifier;

    private const float MaxProcent = 100f;
    private const float ChanceReduceMultiplier = 2f;
    private const float ScaleReduceMultiplier = 2f;
    private const int MinChildrenCount = 2;
    private const int MaxChildrenCount = 6;

    public void Divide()
    {
        float chance = Random.Range(0, MaxProcent);

        if (chance <= _divideChance)
        {
            _divideChance /= ChanceReduceMultiplier;

            GameObject prefab = this.gameObject;

            int divideCount = Random.Range(MinChildrenCount, MaxChildrenCount + 1);

            for (int i = 0; i < divideCount; i++)
            {
                GameObject createdObject = Instantiate(prefab);

                createdObject.GetComponent<Transform>().localScale /= ScaleReduceMultiplier;

                createdObject.GetComponent<Renderer>().material.color = Random.ColorHSV();

                Rigidbody rigidbody = createdObject.GetComponent<Rigidbody>();

                float randomX = Random.Range(-_explosionOffset, _explosionOffset);
                float randomY = Random.Range(-_explosionOffset, _explosionOffset);
                float randomZ = Random.Range(-_explosionOffset, _explosionOffset);

                Vector3 offsetVector = new Vector3(randomX, randomY, randomZ);

                rigidbody.AddExplosionForce(_explosionForce, transform.position + offsetVector, _explosionRadius, _explosionUpwardModifier, ForceMode.Impulse);
            }

            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}