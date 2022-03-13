using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
    [Header("Car settings")]

    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;

    //Local variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    //Components
    Rigidbody2D carRigidbody2D;

    //Awake is called when the script instance is being loaded
    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Frame-rate independent for physics calculations
    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();

    }

    void ApplyEngineForce()
    {
        if (accelerationInput == 0)
         carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);



        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);

    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);


        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        carRigidbody2D.MoveRotation(rotationAngle);


    }
    public void SetInputVector(Vector2 inputVector)
    {
    steeringInput = inputVector.x;
    accelerationInput = inputVector.y;
    
    }





}
