using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;
using SocketUtil;
public class ButtonClickPlay : MonoBehaviour
{
    // Start is called before the first frame update

    //public Transform[] grandFa;
    //private GameObject Timeline;
    private PlayableDirector[] director;
    private PlayableDirector currentdirector;
    private Double Time;
    float velo = 1;
    void Start()
    {

    }

    public void PlayDirector()
    {
        SocketClient client = new SocketClient(8888);
        client.StartClient();
        //BitConverter.ToDouble

        director = UnityEngine.Object.FindObjectsOfType<PlayableDirector>();
        currentdirector = director[0];
        currentdirector.time = client.Time;
        Debug.Log(currentdirector.duration);
        currentdirector.Play();


    }
    public void StopDirector()
    {
        currentdirector.Pause();
    }
    public void StopTheDirector()
    {
        currentdirector.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        //if (currentdirector != null)
        //{
        //  if (currentdirector.state == PlayState.Playing)
        //{
        //director = Object.FindObjectsOfType<PlayableDirector>();
        //currentdirector = director[0];
        //currentdirector.time += Time.unscaledDeltaTime * velo;

        //currentdirector.DeferredEvaluate();
            //}
       // }
    }
}
