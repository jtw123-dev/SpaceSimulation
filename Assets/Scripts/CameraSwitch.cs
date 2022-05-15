using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject _internalCamera;
    [SerializeField] GameObject _externalCamera;
    private bool _cameraSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) &&_cameraSwitch ==false)
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
    }

    
}
