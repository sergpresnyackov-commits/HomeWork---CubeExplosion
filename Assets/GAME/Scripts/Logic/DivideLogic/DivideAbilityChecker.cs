using System;
using UnityEngine;

[RequireComponent(typeof(RaycastHandler))]
public class DivideAbilityChecker : MonoBehaviour
{
    public event Action<DivideAbility> AbilityFound;

    private RaycastHandler _raycaster;

    private void Awake()
    {
        if (TryGetComponent(out RaycastHandler raycaster))
        {
            _raycaster = raycaster;
        }
    }

    private void OnEnable()
    {
        _raycaster.RaycastCreated += CheckHit;
    }

    private void OnDisable()
    {
        _raycaster.RaycastCreated -= CheckHit;
    }

    private void CheckHit(RaycastHit raycastHit)
    {
        if (raycastHit.collider.TryGetComponent(out DivideAbility divideAbility))
        {
            AbilityFound?.Invoke(divideAbility);
        }
    }
}