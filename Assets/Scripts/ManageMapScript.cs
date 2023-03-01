using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMapScript : MonoBehaviour
{
    public float acceloration = 0.0f; //Defaults to 0, might need to change
    public float duration = 10.0f; // 10 seconds
    float startScaleSize = 300.0f;
    float minSize = 10.0f;
    float maxSize = 350.0f;
    
    float lastSmallestSize;


    float countDown;
    float countUp;
    float scaleSmaller;
    float scaleLarger;


    public float speed = 2f; // The speed at which the object will move
    public float range = 5f; // The range within which the object will move

    private Vector3 targetPosition; // The position the object is flying towards

    // Start is called before the first frame update
    void Start()
    {
        countDown = 0.0f;
        countUp = 0.0f;

        targetPosition = transform.position + Random.insideUnitSphere * range;
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

        // If the object has reached its target position, set a new random target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = transform.position + Random.insideUnitSphere * range;
        }

        // Move the object towards its target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
       
    }
}
