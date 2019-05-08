using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuEventSystem : MonoBehaviour
{
    private EventSystem eventSystem;

    [Tooltip("Main menu starting button in the event system.")]
    [SerializeField]
    private GameObject mainPanelStarter;

    [Tooltip("Credit menu starting button in the event system.")]
    [SerializeField]
    private GameObject creditsPanelStarter;

    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField]
    private GameObject creditPanel;

    private string currentPanel;
    private string panelHistory;

    private void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();
    }

    private void Update()
    {
        CheckPanel();
    }

    private void CheckPanel()
    {
        if (creditPanel.activeSelf == true)
            currentPanel = creditPanel.name;
        else if (mainMenuPanel.activeSelf == true)
            currentPanel = mainMenuPanel.name;

        if (currentPanel != panelHistory)
        {
            if (currentPanel == creditPanel.name)
                eventSystem.SetSelectedGameObject(creditsPanelStarter);
            else if (currentPanel == mainMenuPanel.name)
                eventSystem.SetSelectedGameObject(mainPanelStarter);
            panelHistory = currentPanel;
        }
    }
}
