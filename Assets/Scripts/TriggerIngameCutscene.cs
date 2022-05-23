using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerIngameCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            Debug.Log("this collided");
            _director.Play();
        }
    }
}
