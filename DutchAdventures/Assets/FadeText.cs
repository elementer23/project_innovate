using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FadeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public TextMeshProUGUI textTarget;
    public float speed = 1f;
    // private float _t = 0f;

    void Update()
    {
    }

    public void fadeIn()
    {
        // _t += Time.deltaTime * speed;
        // textTarget.alpha = Mathf.PingPong(_t, 1f);
        StartCoroutine(FadeTextToFullAlpha(textTarget));
    }

    public void fadeOut()
    {
        StartCoroutine(FadeTextToZeroAlpha(textTarget));
    }

    IEnumerator FadeTextToFullAlpha(TextMeshProUGUI text)
    {
        while (textTarget.alpha < 1.0f)
        {
            textTarget.alpha = textTarget.alpha + (Time.deltaTime / speed);
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("LanguageMenu", LoadSceneMode.Single);
    }

    IEnumerator FadeTextToZeroAlpha(TextMeshProUGUI text)
    {
        while (textTarget.alpha > 0.0f)
        {
            textTarget.alpha = textTarget.alpha - (Time.deltaTime / speed);
            yield return null;
        }

    }
}
