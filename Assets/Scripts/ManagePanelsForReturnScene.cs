using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ManagePanelsForReturnScene : MonoBehaviour
{

    public bool isPlaying;

    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public GameObject VideoCanvas;

    public GameObject startPanel;
    public GameObject directionsPanel;
    public GameObject navigationPanel;
    public GameObject endPanel;

    

    void Awake()
    {
        videoPlayer = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
    }

    void Start()
    {

        
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = false;
        videoPlayer.gameObject.SetActive(false);

        VideoCanvas = GameObject.Find("Video Canvas");
        VideoCanvas.SetActive(false);



        videoPlayer.clip = videoClips[0];

        startPanel = GameObject.Find("Panel Start"); 
        directionsPanel = GameObject.Find("Panel Directions"); 
        navigationPanel = GameObject.Find("Panel Navigation"); 
        endPanel = GameObject.Find("Panel End");

        startPanel.SetActive(false);
        directionsPanel.SetActive(false);
        navigationPanel.SetActive(false);
        endPanel.SetActive(false);

        ShowNavigationPanel();

    }

  

    public void ShowDirectionsPanel()
    {
        startPanel.SetActive(false);
        playVideo(1);
        StartCoroutine(WaitForVideoEnd(2f));
        directionsPanel.SetActive(true);

    }

    public void ShowNavigationPanel()
    {
        directionsPanel.SetActive(false);
        endPanel.SetActive(false);
        playVideo(2);
        StartCoroutine(WaitForVideoEnd(3f));
        navigationPanel.SetActive(true);
    }

    public void ShowEndPanel()
    {
        navigationPanel.SetActive(false);
        playVideo(3);
        StartCoroutine(WaitForVideoEnd(1f));
        endPanel.SetActive(true);
    }

    void playVideo(int index)
    {
        VideoCanvas.SetActive(true);
        videoPlayer.gameObject.SetActive(true);

        videoPlayer.clip = videoClips[index];
        videoPlayer.Play();
    }

    IEnumerator WaitForVideoEnd(float delay)
    {
        yield return new WaitForSeconds(delay); // wait for the specified delay
        VideoCanvas.SetActive(false); // disable the game object
    }

}
