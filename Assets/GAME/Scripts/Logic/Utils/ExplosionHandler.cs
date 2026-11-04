using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    private const float ForceKoefficient = 1f;

    [SerializeField] private float _radius = 10f;
    [SerializeField] private float _offset = 1f;
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _upwardsModifier = 2f;

    private Vector3 parentPosiiton;
    private Collider[] _hits;
    private HashSet<Rigidbody> _affectedRigidbodies;
    private Rigidbody _currentRigidbody;
    private Vector3 _direction;
    private float _distance;
    private float _fallOff;

    public void ExplodeObject(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Transform transform))
        {
            parentPosiiton = transform.position;
        }
        else
        {
            return;
        }

        _hits = Physics.OverlapSphere(parentPosiiton, _radius);
        _affectedRigidbodies = new HashSet<Rigidbody>();

        foreach (Collider hit in _hits)
        {
            _currentRigidbody = hit.attachedRigidbody;

            if (_currentRigidbody == null || _affectedRigidbodies.Contains(_currentRigidbody))
            {
                continue;
            }

            _affectedRigidbodies.Add(_currentRigidbody);

            _direction = _currentRigidbody.position - parentPosiiton;
            _distance = _direction.magnitude;

            if (_distance <= Mathf.Epsilon)
            {
                continue;
            }

            _fallOff = ForceKoefficient - _distance / _radius;

            _currentRigidbody.AddExplosionForce(_force * _fallOff, parentPosiiton, _radius, _upwardsModifier, ForceMode.Impulse);
        }
    }
}