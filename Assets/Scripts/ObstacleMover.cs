using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float period = 2f;
    private float _movementFactor;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if(period == 0f) return;
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        _movementFactor = (rawSinWave + 1f) / 2f;
        
        Vector3 offset = movementVector * _movementFactor;
        transform.position = _startPosition + offset;
    }
}
