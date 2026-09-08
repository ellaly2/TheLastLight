using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lantern : MonoBehaviour
{
    [SerializeField] private Light pointLight;
    [SerializeField] private float rayDistance = 20f; 
    [SerializeField] private LayerMask hittableLayers;

    [SerializeField] private InputActionReference attackAction;

    private float _timer = 0f;

    private void Awake()
    {
        attackAction.action.performed += Attack;
    }

    private void OnDestroy()
    {
        attackAction.action.performed -= Attack;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 5f)
        {
            pointLight.intensity -= 0.2f;
            _timer = 0f;
        }
    }
    
    public void Attack(InputAction.CallbackContext ctx)
    {
        // 1. Define the origin point and direction of the ray (Forward from this object)
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // 2. Create a variable to store information about what the ray hits
        RaycastHit hitInfo;

        // 3. Cast the ray
        if (Physics.Raycast(origin, direction, out hitInfo, rayDistance, hittableLayers))
        {
            // Successfully hit something!
            Debug.Log("Hit object: " + hitInfo.collider.name);
            IHaveHealth enemy = hitInfo.collider.gameObject.GetComponentInParent<IHaveHealth>();
            if (enemy != null)
            {
                enemy.ChangeHealth(-2);
                Debug.Log($"Enemy health {enemy.CurrentHealth}");
            }
        }
    }
    
}
