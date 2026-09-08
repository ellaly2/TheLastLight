using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private Light pointLight;
    private float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 5f)
        {
            pointLight.intensity -= 0.2f;
            _timer = 0f;
        }
    }
}
