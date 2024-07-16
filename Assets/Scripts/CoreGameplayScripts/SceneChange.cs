using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [SerializeField] float fadeOut;
    [SerializeField] float fadeIn;

    [SerializeField] CanvasGroup fader;

    enum SceneIdentifier
    {
        Level1, Level2
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOut(float time)
    {
        while (fader.alpha < 1.0f)
        {
            fader.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

    IEnumerator FadeIn(float time)
    {
        while (fader.alpha > 0f)
        {
            fader.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }
}
