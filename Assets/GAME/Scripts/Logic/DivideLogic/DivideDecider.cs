using System;
using UnityEngine;

[RequireComponent(typeof(DivideAbilityChecker))]
public class DivideDecider : MonoBehaviour
{
    private const float MaxChance = 100f;

    public event Action<DivideAbility, int> DivideAllowed;
    public event Action<DivideAbility> DivideCanceled;

    [Min(1f)]
    [SerializeField] private float _chanceReduceDivider = 2f;

    [Min(0f)]
    [SerializeField] private float _startDivideChance = 100f;

    [SerializeField] private bool _alwaysAllowDivide = false;

    private DivideAbilityChecker _divideAbilityChecker;

    private void Awake()
    {
        if (TryGetComponent(out DivideAbilityChecker divideAbilityChecker))
        {
            _divideAbilityChecker = divideAbilityChecker;
        }
    }

    private void OnEnable()
    {
        _divideAbilityChecker.AbilityFound += TryDivideObject;
    }

    private void OnDisable()
    {
        _divideAbilityChecker.AbilityFound -= TryDivideObject;
    }

    private void TryDivideObject(DivideAbility divideAbility)
    {
        int divideCount = divideAbility.GetDivideCount();

        if (_alwaysAllowDivide)
        {
            divideCount++;
            AllowDivide(divideAbility, divideCount);

            return;
        }

        float divideChance = _startDivideChance;
        
        for (int i = 0; i < divideCount; i++)
        {
            if (_chanceReduceDivider != 0)
            {
                divideChance /= _chanceReduceDivider;
            }
        }

        float randomValue = UnityEngine.Random.Range(0, MaxChance);

        if (randomValue <= divideChance)
        {
            divideCount++;
            AllowDivide(divideAbility, divideCount);
        }
        else
        {
            CancelDivide(divideAbility);
        }
    }

    private void AllowDivide(DivideAbility divideAbility, int divideCount)
    {
        DivideAllowed?.Invoke(divideAbility, divideCount);
    }

    private void CancelDivide(DivideAbility divideAbility)
    {
        DivideCanceled?.Invoke(divideAbility);
    }
}