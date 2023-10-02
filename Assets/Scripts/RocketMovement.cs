using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float thrustSpeed = 1000f;
    [SerializeField] private float rotateSpeed = 50f;
    
    // [SerializeField] private AudioClip thrustSFX;
    
    private GameControls _controls;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    private void Awake()
    {
        _controls = new GameControls();
        _controls.Rocket.Enable();

        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.OnRocketCrashed += DisableMovement;
        GameManager.OnRocketFinished += DisableMovement;
    }

    private void Update()
    {
        if(!GameManager.Instance.IsGamePlaying()) return;
        ThrustPerformed();
        RotatePerformed();
    }

    private void ThrustPerformed()
    {
        if (_controls.Rocket.Thrust.IsPressed() && Fuel.Instance.GetCurrentFuelCapacity() > 0f)
        {
            Fuel.OnThrustPerformed?.Invoke();
            _rigidbody.AddRelativeForce(Vector3.up * (thrustSpeed * Time.deltaTime));
        }
        
    }

    private void RotatePerformed()
    {
        _rigidbody.freezeRotation = true;
        
        if (_controls.Rocket.Rotate.IsPressed())
        {
            float inputValue = _controls.Rocket.Rotate.ReadValue<float>();
            float velocity = inputValue * rotateSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0f, 0f, velocity));
        }
        
        _rigidbody.freezeRotation = false; 
    }

    private void DisableMovement()
    {
        _controls.Dispose();
    }
}