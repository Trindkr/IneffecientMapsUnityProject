using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMapScript : MonoBehaviour
{
    public float acceleration; 
    public float duration = 10.0f; // 10 seconds
    float minSize;
    float maxSize;
    
    float lastSmallestSize;
    float lastLargestSize;


    float countDown;
    float countUp;
    float scaleSmaller;
    float scaleLarger;


    public float radius = 2f;
    public float speed = 5f;

    private Vector3 centerPosition;

    // Start is called before the first frame update
    void Start()
    {
        //remove this
        acceleration = 1.0f; 
    
        countDown = 0.0f;
        countUp = 0.0f;

        minSize = 0.01f;
        maxSize = 0.4f;

        lastLargestSize = transform.localScale.y;

        centerPosition = transform.parent.position;

    }

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
        if(acceleration <= 0.0f && countDown < duration)
        {
            countUp = 0.0f; //reset
            countDown += Time.deltaTime;
            scaleSmaller = Mathf.Lerp(lastLargestSize, minSize, countDown/duration);
            transform.localScale = new Vector3(scaleSmaller, scaleSmaller, scaleSmaller); // shrink from startsize to minsize;
            lastSmallestSize = transform.localScale.y;
        }

        if(acceleration >= 10.0f) //TODO when acceloration part is done
        {
            countDown = 0.0f; //reset
            countUp += Time.deltaTime;
            scaleLarger = Mathf.Lerp(lastSmallestSize, maxSize, countUp/duration);
            transform.localScale = new Vector3(scaleLarger, scaleLarger, scaleLarger);
            lastLargestSize = transform.localScale.y;
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
