using System;
using UnityEngine;

[RequireComponent(typeof(DivideDecider))]
public class DivideSpawner : MonoBehaviour
{
    public event Action<DivideAbility> ChildSpawned;
    public event Action<DivideAbility> AllChildrenSpawned;

    [SerializeField] private int _minChildrenToSpawn = 2;
    [SerializeField] private int _maxChildrenToSpawn = 6;

    private DivideDecider _divideDecider;

    private void Awake()
    {
        if (TryGetComponent(out DivideDecider divideDecider))
        {
            _divideDecider = divideDecider;
        }
    }

    private void OnEnable()
    {
        _divideDecider.DivideAllowed += SpawnChildren;
    }

    private void OnDisable()
    {
        _divideDecider.DivideAllowed -= SpawnChildren;
    }

    private void SpawnChildren(DivideAbility parent, int divideCount)
    {
        int randomValue = UnityEngine.Random.Range(_minChildrenToSpawn, _maxChildrenToSpawn + 1);

        for (int i = 0; i < randomValue; i++)
        {
            DivideAbility child = Instantiate(parent);

            child.Init(divideCount);

            ChildSpawned?.Invoke(child);
        }

        AllChildrenSpawned?.Invoke(parent);
    }
}