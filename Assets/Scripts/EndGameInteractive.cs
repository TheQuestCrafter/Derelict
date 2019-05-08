using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameInteractive : InteractiveObject
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Image fadeOut;

    [SerializeField]
    private Text text;

    [SerializeField]
    private string finalText;

    [SerializeField]
    private float timerAdded = 10;

    [SerializeField]
    private float totalTimer;

    private bool endingGame = false;

    protected override void Awake()
    {
        text = canvas.GetComponentInChildren<Text>();
        fadeOut = canvas.GetComponentInChildren<Image>();
        fadeOut.canvasRenderer.SetAlpha(0.01f);
        text.canvasRenderer.SetAlpha(0.01f);
        base.Awake();
    }

    public override void InteractWith()
    {
        text.text = finalText;
        canvas.gameObject.SetActive(true);
        fadeOut.CrossFadeAlpha(1, 2, false);
        text.CrossFadeAlpha(1, 2, false );
        totalTimer = Time.time + timerAdded;
        endingGame = true;
        base.InteractWith();
    }

    private void Update()
    {
        if(endingGame && Time.time >= totalTimer)
            SceneManager.LoadScene(0);
    }
}
