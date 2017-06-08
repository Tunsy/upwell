using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitOnClick : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler{
    public AudioClip hoverSound;
    public AudioClip enterSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound)
            AudioSource.PlayClipAtPoint(hoverSound, Camera.main.transform.position, .5f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (enterSound)
            AudioSource.PlayClipAtPoint(enterSound, Camera.main.transform.position, .5f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}