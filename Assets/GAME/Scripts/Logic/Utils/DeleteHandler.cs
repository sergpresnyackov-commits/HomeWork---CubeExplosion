using UnityEngine;

public class DeleteHandler : MonoBehaviour
{
    public void DeleteObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}