using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;        //Vector3 to add to the starting position of an obstacle
    [SerializeField] private float period = 2f;     //amount of time before sine wave repeats itself
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

        const float turn = Mathf.PI * 2;     //const value of turn that equals 2 time PI = 6.283
        float rawSinWave = Mathf.Sin(cycles * turn);     //going from -1 to 1

        _movementFactor = (rawSinWave + 1f) / 2f;       //recalculated to going from 0 to 1
        
        Vector3 offset = movementVector * _movementFactor;
        transform.position = _startPosition + offset;
    }
}
