using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMapScript : MonoBehaviour
{
    public float acceloration = 0.0f; //Defaults to 0, might need to change
    public float duration = 10.0f; // 10 seconds
    float startScaleSize = 300.0f;
    float minSize = 10.0f;
    float counter;
    float scale;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0.0f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.localScale.y <= minSize)
        {
            //What should happen when the map is at its smallest size?
            Debug.Log("Map is at its smallest size");
            break;
        }

        //acceloration = INSERT CODE HERE;
        if(acceloration <= 0.0f && counter < duration)
        {
            counter += Time.deltaTime;
            scale = Mathf.Lerp(startScaleSize, minSize, counter/duration);
            transform.localScale = new Vector3(scale, scale, scale); // shrink from startsize to minsize;
        }
        //else if(acceloration > ????) //TODO when acceloration part is done
        // {
        //     counter = 0.0f;
        //     transform.localScale = new Vector3(Mathf.Lerp(transform.localScale, startScaleSize, counter/duration), Mathf.Lerp(transform.localScale, startScaleSize, counter/duration), Mathf.Lerp(transform.localScale, startScaleSize, counter/duration)); // grow from current size to startsize;
        // }
       
    }
}
