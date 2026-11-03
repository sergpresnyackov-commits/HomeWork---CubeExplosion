using UnityEngine;

[RequireComponent(typeof(DivideDecider))]
[RequireComponent(typeof(DivideSpawner))]
[RequireComponent(typeof(PaintHandler))]
[RequireComponent(typeof(ScalerHandler))]
[RequireComponent(typeof(ExplosionHandler))]
[RequireComponent(typeof(DeleteHandler))]
public class DivideManager : MonoBehaviour
{
    private DivideDecider _divideDecider;
    private DivideSpawner _divideSpawner;
    private PaintHandler _paintHandler;
    private ScalerHandler _scaleHandler;
    private ExplosionHandler _explosionHandler;
    private DeleteHandler _deleteHandler;

    private void Awake()
    {
        if (TryGetComponent(out DivideDecider divideDecider))
        {
            _divideDecider = divideDecider;
        }

        if (TryGetComponent(out DivideSpawner divideSpawner))
        {
            _divideSpawner = divideSpawner;
        }

        if (TryGetComponent(out PaintHandler paintHandler))
        {
            _paintHandler = paintHandler;
        }

        if (TryGetComponent(out ScalerHandler scalerHandler))
        {
            _scaleHandler = scalerHandler;
        }

        if (TryGetComponent(out ExplosionHandler explosionHandler))
        {
            _explosionHandler = explosionHandler;
        }

        if (TryGetComponent(out DeleteHandler deleteHandler))
        {
            _deleteHandler = deleteHandler;
        }
    }

    private void OnEnable()
    {
        _divideDecider.DivideCanceled += HandleParent;
        _divideSpawner.AllChildrenSpawned += HandleParent;
        _divideSpawner.ChildSpawned += HandleChild;
    }

    private void OnDisable()
    {
        _divideDecider.DivideCanceled -= HandleParent;
        _divideSpawner.AllChildrenSpawned -= HandleParent;
        _divideSpawner.ChildSpawned -= HandleChild;
    }

    private void HandleParent(DivideAbility divideAbility)
    {
        _deleteHandler.DeleteObject(divideAbility.gameObject);
    }

    private void HandleChild(DivideAbility divideAbility)
    {
        _paintHandler.PaintObject(divideAbility.gameObject);
        _scaleHandler.ScaleObject(divideAbility.gameObject);
        _explosionHandler.ExplodeObject(divideAbility.gameObject);
    }
}