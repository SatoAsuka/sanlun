using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image FlashImage;
    public float time;
    public Color FlashColor;

    private Color DefaultColor;
    private void Start()
    {
        DefaultColor = FlashImage.color;
    }
    public void FlashScreen()
    {
        StartCoroutine(Flash());
    }
    IEnumerator Flash()
    {
        FlashImage.color = FlashColor;
        yield return new WaitForSeconds(time);
        FlashImage.color = DefaultColor;
    }


}
