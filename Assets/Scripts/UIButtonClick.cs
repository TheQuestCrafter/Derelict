using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class UIButtonClick : MonoBehaviour
{
    private EventSystem eventSystem;
    private string selectedHistory;
    private AudioSource selectedSound;

    private void Awake()
    {
        selectedSound = GetComponent<AudioSource>();
        eventSystem = FindObjectOfType<EventSystem>();
        selectedHistory = eventSystem.firstSelectedGameObject.name;
    }

    private void Update()
    {
        if(eventSystem.currentSelectedGameObject.name != selectedHistory)
        {
            Debug.Log("sound played");
            selectedSound.Play();
            selectedHistory = eventSystem.currentSelectedGameObject.name;
        }
    }
}
