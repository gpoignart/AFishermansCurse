using UnityEngine;
using System.Collections;

public class TheEyes : MonoBehaviour
{
    public Sprite eyesNormal;   // default open eyes
    public Sprite eyesSquint;   // squint eyes sprite

    private SpriteRenderer sr;
    private bool isHit = false;

    private float idleAlpha = 0.25f;
    private float fullAlpha = 1f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Called when spawned
    public void Init(int side)
    {
        sr.sprite = eyesNormal;
        sr.color = new Color(1f, 1f, 1f, idleAlpha);
    }

    public void HitByFlashlight()
    {
        if (isHit) return;
        isHit = true;

        StartCoroutine(EyesReaction());
    }

    IEnumerator EyesReaction()
    {
       
        float t = 0f;
        float durationBrighten = 1f;

        while (t < durationBrighten)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(idleAlpha, fullAlpha, t / durationBrighten);
            sr.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        
        sr.sprite = eyesSquint;
        yield return new WaitForSeconds(2f); 

    
        float fadeT = 0f;
        float fadeDuration = 2f;

        while (fadeT < fadeDuration)
        {
            fadeT += Time.deltaTime;
            float alpha = Mathf.Lerp(fullAlpha, 0f, fadeT / fadeDuration);
            sr.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        sr.color = new Color(1f, 1f, 1f, 0f);

      
        MonsterGameManager.Instance.PlayerWin();

        Destroy(gameObject);
    }
}
