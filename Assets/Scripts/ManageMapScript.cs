using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManageMapScript : MonoBehaviour
{

    public float shakeThreshold = 1.18f; // adjust this value to change the sensitivity of the shake detection
    public float shakeScaleUp = 4.5f; // adjust this value to change how much the object scales up
    public float shakeScaleDown = 0.1f; // adjust this value to change how much the object scales down
    public float shakeScaleTime = 5f; // adjust this value to change how long the object takes to scale up or down

    private Vector3 originalScale;
    private Vector3 targetScale;
    private Vector3 currentVelocity;
    private bool shaking;

    private Vector3 acceleration;
    private Vector3 accelerationSmoothDampVelocity;
    private float accelerationSmoothTime = 0.1f;



    public float radius = 2f;
    public float speed = 5f;

    private Vector3 centerPosition;


    // Start is called before the first frame update
    void Start()
    {
 

        originalScale = transform.localScale;
        targetScale = originalScale;
        acceleration = Input.acceleration;
  

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.localScale.y >= 0.395)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
         // smooth the acceleration value over time
        acceleration = Vector3.SmoothDamp(acceleration, Input.acceleration, ref accelerationSmoothDampVelocity, accelerationSmoothTime);

        // calculate the magnitude of the acceleration vector
        float accelerationMagnitude = acceleration.magnitude;

        // if the acceleration magnitude is greater than the threshold, start shaking and scale up the object over time
        if (accelerationMagnitude > shakeThreshold && !shaking)
        {
            
            shaking = true;
            targetScale = originalScale * shakeScaleUp;
            
        }

        // if the phone is not shaking, gradually shrink the object to a smaller size than its original size
        if (!shaking)
        {
            targetScale = originalScale * shakeScaleDown;
            if (transform.localScale.y <= 0.0115 )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }

        // gradually scale the object towards the target scale using SmoothDamp
        transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref currentVelocity, shakeScaleTime);
        
        // if the object has reached the target scale, stop shaking
        if (transform.localScale == targetScale)
        {
            shaking = false;
        }
    

        //update centerPosition
        centerPosition = transform.parent.position;
       
        float x = centerPosition.x + radius * Mathf.Cos(Time.time * speed);
        float y = centerPosition.y + radius * Mathf.Sin(Time.time * speed);
        float z = centerPosition.z;

        Vector3 newPosition = new Vector3(x, y, z);

        // Move the object towards the new position
        transform.position = newPosition;

       
    }
    
}
