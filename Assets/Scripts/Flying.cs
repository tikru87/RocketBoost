using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Flying : MonoBehaviour
{
    RocketFeatures rocketFeatures;
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustForce = 60f;
    [SerializeField] float rotationForce = 500f;
    public bool isThrusting = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rocketFeatures = GetComponent<RocketFeatures>();
    }

    private void OnEnable()
    {
        EnableControls();
    }

    private void EnableControls()
    {
        thrust.Enable();
        rotation.Enable();
    }

    public void DisableControls()
    {
        thrust.Disable();
        rotation.Disable();
    }

    void FixedUpdate()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (rocketFeatures.hasGas)
        {
            ProcessThrust();
            ProcessRotation();
        }
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.fixedDeltaTime);
            isThrusting = true;
        } 
        else
        {
            isThrusting = false;
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            if (rotationInput < 0)
            {
                ApplyRotation(rotationForce);
            }
            else if (rotationInput > 0)
            {
                ApplyRotation(-rotationForce);
            }
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
    }
}
