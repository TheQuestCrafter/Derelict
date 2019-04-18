using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [Tooltip("A prefab to be spawned in the menu based upon the object collected.")]
    [SerializeField]
    private GameObject inventoryMenuTogglePrefab;

    [Tooltip("The parent for toggles.")]
    [SerializeField]
    private Transform inventoryListParent;

    [Tooltip("Place to display name of selected menu item.")]
    [SerializeField]
    private Text itemLabelText;

    [Tooltip("Place to display the description of selected menu item.")]
    [SerializeField]
    private Text itemDescriptionText;
    
    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private FPSController fPSController;
    private AudioSource audioSource;
    private ToggleGroup toggleGroup;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventoryMenu instance.");
            return instance;
        }
        private set { instance = value; }
    }

    private bool IsVisible => canvasGroup.alpha > 0;

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        fPSController.SetLockPlayer(true);
        audioSource.Play();
    }

    public void ExitMenu()
    {
        HideMenu();
    }

    /// <summary>
    /// Instatiates a new inventoryMenuItemToggle prefab and adds it the menu
    /// </summary>
    /// <param name="inventoryObjToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuTogglePrefab, inventoryListParent);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjToAdd;
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        fPSController.SetLockPlayer(false);
        audioSource.Play();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("ShowInventory"))
            if (IsVisible == true)
                HideMenu();
            else
                ShowMenu();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There are multiple instances of InventoryMenu in your scene.");
        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GetComponent<AudioSource>();
        fPSController = (FPSController)FindObjectOfType<FPSController>();
    }

    private void Start()
    {
        HideMenu();
        StartCoroutine(WaitForAudioClip());
    }

    private IEnumerator WaitForAudioClip()
    {
        float originalVolume = audioSource.volume;
        audioSource.volume = 0;
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.volume = originalVolume;
    }
    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        itemDescriptionText.text = inventoryObjectThatWasSelected.Description;
    }

    //Event handler for Toggle Selected.
    #region
    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
    }
    #endregion
}
