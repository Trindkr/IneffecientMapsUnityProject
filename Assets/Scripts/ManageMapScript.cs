using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManageMapScript : MonoBehaviour
{
    //public float test = 1f;

    public float duration = 5.0f; // 10 seconds
    float minSize;
    float maxSize;
    
    float lastSmallestSize;
    float lastLargestSize;

     public float shakeThreshold = 1.15f; // adjust this value to change the sensitivity of the shake detection
    public float shakeScaleUp = 4f; // adjust this value to change how much the object scales up
    public float shakeScaleDown = 0.1f; // adjust this value to change how much the object scales down
    public float shakeScaleTime = 5f; // adjust this value to change how long the object takes to scale up or down

    private Vector3 originalScale;
    private Vector3 targetScale;
    private Vector3 currentVelocity;
    private bool shaking;

    private Vector3 acceleration;
    private Vector3 accelerationSmoothDampVelocity;
    private float accelerationSmoothTime = 0.1f;


    float countDown;
    float countUp;
    float scaleSmaller;
    float scaleLarger;


    public float radius = 2f;
    public float speed = 5f;

    private Vector3 centerPosition;

    public TextMeshProUGUI accelerometerInputField;
    public TextMeshProUGUI scaleInputField;

    // Start is called before the first frame update
    void Start()
    {
        countDown = 0.0f;
        countUp = 0.0f;

        minSize = 0.01f;
        maxSize = 0.4f;

        lastLargestSize = transform.localScale.y;

        centerPosition = transform.parent.position;

        originalScale = transform.localScale;
        targetScale = originalScale;
        acceleration = Input.acceleration;
  

    }

    // Update is called once per frame
    void LateUpdate()
    {

        // if (acceleration > shakeThreshold && !shaking)
        // {
        //     countUp = 0.0f; //reset
        //     countDown += Time.deltaTime;
        //     scaleSmaller = Mathf.Lerp(lastLargestSize, minSize, countDown/duration);
        //     transform.localScale = new Vector3(scaleSmaller, scaleSmaller, scaleSmaller); // shrink from startsize to minsize;
        //     lastSmallestSize = transform.localScale.y;
           
        // }
        // else
        // {
        //     countDown = 0.0f; //reset
        //     countUp += Time.deltaTime;
        //     scaleLarger = Mathf.Lerp(lastSmallestSize, maxSize, countUp/duration);
        //     transform.localScale = new Vector3(scaleLarger, scaleLarger, scaleLarger);
        //     lastLargestSize = transform.localScale.y;
        // }

         // smooth the acceleration value over time
        acceleration = Vector3.SmoothDamp(acceleration, Input.acceleration, ref accelerationSmoothDampVelocity, accelerationSmoothTime);

        // calculate the magnitude of the acceleration vector
        float accelerationMagnitude = acceleration.magnitude;

        // if the acceleration magnitude is greater than the threshold, start shaking and scale up the object over time
        if (accelerationMagnitude > shakeThreshold && !shaking)
        {
            shaking = true;
            targetScale = originalScale * shakeScaleUp;
            if (transform.localScale.y >= 0.39)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        // if the phone is not shaking, gradually shrink the object to a smaller size than its original size
        if (!shaking)
        {
            targetScale = originalScale * shakeScaleDown;
            if (transform.localScale.y <= 0.011 )
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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

        accelerometerInputField.text = "Accelerometer: " + accelerationMagnitude.ToString();
        scaleInputField.text = "Scale: " + transform.localScale.y.ToString();
       
    }

    

    
  
}
