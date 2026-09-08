using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float sphereRadius = 1.0f;
    [SerializeField] private float castDistance = 5.0f;

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTrigger enter");
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log($"Player detected");
        }
    }
}
