using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TriggerIngameCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private bool _finalCutScene;

    private void Update()
    {
        if (_finalCutScene == true && _director.time > 10)
        {
            Debug.Log("This is true");
            _director.Pause();
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            Debug.Log("this collided");
            _director.Play();
        }
    }

    
}
