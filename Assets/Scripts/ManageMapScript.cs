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


    public float moveSpeed = 2.0f;
    public float borderSize = 50.0f;
    Camera mainCamera;

    private Vector3 targetPosition; // The position the object is flying towards

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        countDown = 0.0f;
        countUp = 0.0f;

        targetPosition = GetRandomPositionWithinBorder();
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
            targetPosition = GetRandomPositionWithinBorder();
        }

        // Move the object towards its target position
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        float distanceToCamera = Vector3.Distance(transform.position, mainCamera.transform.position);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = mainCamera.transform.position + (transform.position - mainCamera.transform.position).normalized * distanceToCamera;
       
    }

     Vector3 GetRandomPositionWithinBorder()
    {
        // Get a random point within the border by using Random.insideUnitSphere
        Vector3 randomPoint = Random.insideUnitSphere * borderSize;

        // Make sure the random point is within the border by clamping it to the border's bounds
        randomPoint.x = Mathf.Clamp(randomPoint.x, -borderSize, borderSize);
        randomPoint.y = Mathf.Clamp(randomPoint.y, -borderSize, borderSize);
        randomPoint.z = Mathf.Clamp(randomPoint.z, -borderSize, borderSize);

        // Set the random point's height to match the object's current height
        randomPoint.y = transform.position.y;

        return randomPoint;
    }

}
