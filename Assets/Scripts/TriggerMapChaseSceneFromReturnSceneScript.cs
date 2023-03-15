using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerMapChaseSceneScript : MonoBehaviour
{
    public float rndmTime;
    // Start is called before the first frame update
    void Start()
    {
        rndmTime = Random.Range(5, 20); //Gives a random number between 5 and 20
    }

    // Update is called once per frame
    void Update()
    {
        rndmTime -= Time.deltaTime; 
        if (rndmTime <= 0.0f)
        {
            TriggerMapChaseScene();
        }
    }

    public void TriggerMapChaseScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
