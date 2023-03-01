using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMapScript : MonoBehaviour
{
    public float acceloration = 0.0f; //Defaults to 0, might need to change
    public float duration = 10.0f; // 10 seconds
    float startScaleSize = 0.4f;
    float minSize = 0.01f;
    float maxSize = 0.6f;
    
    float lastSmallestSize;


    float countDown;
    float countUp;
    float scaleSmaller;
    float scaleLarger;


    public float moveSpeed = 0.1f;
    public float radius = 1f;

    private Vector3 center;
    private Vector3 localPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
    
        countDown = 0.0f;
        countUp = 0.0f;

        center = transform.parent.position;
        localPosition = transform.localPosition;
        targetPosition = localPosition;    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.localScale.y <= minSize)
        {
            //What should happen when the map is at its smallest size?
            Debug.Log("Map is at its smallest size"); //remove this when done, otherwise it will spam the console (°ー°〃)
        }

        if (transform.localScale.y >= maxSize)
        {
            //What should happen when the map is at its largest size?
            Debug.Log("Map is at its largest size"); //remove this when done, otherwise it will spam the console (°ー°〃)
        }

        //acceloration = INSERT CODE HERE;
        if(acceloration <= 0.0f && countDown < duration)
        {
            countUp = 0.0f; //reset
            countDown += Time.deltaTime;
            scaleSmaller = Mathf.Lerp(startScaleSize, minSize, countDown/duration);
            transform.localScale = new Vector3(scaleSmaller, scaleSmaller, scaleSmaller); // shrink from startsize to minsize;
            lastSmallestSize = transform.localScale.y;
        }

        if(acceloration >= 10.0f) //TODO when acceloration part is done
        {
            countDown = 0.0f; //reset
            countUp += Time.deltaTime;
            scaleLarger = Mathf.Lerp(lastSmallestSize, maxSize, countUp/duration);
            transform.localScale = new Vector3(scaleLarger, scaleLarger, scaleLarger);
        }

        // Generate a random direction and move the target position along it
        Vector3 randomDirection = Random.insideUnitSphere;
        targetPosition += randomDirection * moveSpeed * Time.deltaTime;

        // Clamp the target position within the parent object
        Vector3 clampedPosition = targetPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -radius, radius);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -radius, radius);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -radius, radius);

        // Move the child object towards the clamped target position
        Vector3 newPosition = Vector3.MoveTowards(transform.localPosition, clampedPosition, moveSpeed * Time.deltaTime);
        transform.localPosition = newPosition;
       

        
    }

   

}
