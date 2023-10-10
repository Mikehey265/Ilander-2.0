using System;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public static Action OnGravityModified;

    [SerializeField] private ParticleSystem boostParticles;
    [SerializeField] private float thrustSpeed = 1000f;
    [SerializeField] private float rotateSpeed = 50f;
    [SerializeField] private Light boosterLight;
    
    private GameControls _controls;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _controls = new GameControls();
        _controls.Rocket.Enable();

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameManager.OnRocketCrashed += DisableMovement;
        GameManager.OnRocketFinished += DisableMovement;
    }

    private void OnEnable()
    {
        OnGravityModified += SwitchGravity;
    }

    private void OnDisable()
    {
        OnGravityModified -= SwitchGravity;
    }

    private void FixedUpdate()
    {
        boosterLight.enabled = false;
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
            boostParticles.Play();
            boosterLight.enabled = true;
        }
        else
        {
            boostParticles.Stop();   
        }
    }

    private void RotatePerformed()
    {
        if (_controls.Rocket.Rotate.IsPressed())
        {
            float inputValue = _controls.Rocket.Rotate.ReadValue<float>();
            float velocity = inputValue * rotateSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0f, 0f, velocity));
        }
    }

    private void DisableMovement()
    {
        _controls.Dispose();
    }

    private void SwitchGravity()
    {
        _rigidbody.useGravity = !_rigidbody.useGravity;
    }
}
