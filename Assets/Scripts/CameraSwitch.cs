using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject _internalCamera;
    [SerializeField] GameObject _externalCamera;
    [SerializeField] PlayableDirector _director;
    private bool _cameraSwitch;
    [SerializeField]private float _timeToSwitch=5;
    private GameObject _cameraVolumep;
    private bool _cutsceneCanStart =true;


    private void Start()
    {
        StartCoroutine("WaitToStart");
        Debug.Log("Hi");
    }

    // Update is called once per frame
    void Update()
    {
        _timeToSwitch -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && _cameraSwitch == false)
        {
            _cameraSwitch = true;
            _internalCamera.SetActive(false);
            _externalCamera.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.R) && _cameraSwitch == true)
        {
            _cameraSwitch = false;
            _internalCamera.SetActive(true);
            _externalCamera.SetActive(false);
        }


        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            if (_cutsceneCanStart == true)
            {
                return;
            }
            else
            {
                _timeToSwitch = 5;
                _director.Stop();
                GameObject.Find("CameraVolume").SetActive(false);
            }
               
        }     

        if (Input.anyKeyDown ==false && _timeToSwitch <= 0  ) 
        {
            if (_cutsceneCanStart == true)
            {
                return;
            }

            else
            {
                _director.Play();
            }
                
        }
       
       else if (Input.anyKeyDown ==true ||Input.anyKey==true)
        {
            _timeToSwitch = 5;
            _director.Stop();      
            GameObject.Find("CameraVolume").SetActive(false);        
        }    
    }       

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(2);
        _cutsceneCanStart = false;
    }
}