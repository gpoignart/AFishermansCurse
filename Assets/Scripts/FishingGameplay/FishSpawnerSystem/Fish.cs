using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public FishSO fishSO;

    // Parameters
    private float lifeTimeMin = 10f;
    private float lifeTimeMax = 25f;
    private float fadeInDuration = 0.5f;
    private float fadeOutDuration = 0.5f;

    // Internal references
    private bool useLifeTime;
    private float lifeTime;
    private bool isAvailable; // Not available before the end of fade in, or after the beginning of fade out

    private SpriteRenderer spriteRenderer;

    public void StartFish(bool useLifeTime, bool useFadeIn)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fishSO.sprite;

        this.isAvailable = true;
        this.useLifeTime = useLifeTime;
        
        if (useLifeTime)
        {
            lifeTime = Random.Range(lifeTimeMin, lifeTimeMax);
            StartCoroutine(LifeRoutine());
        }

        if (useFadeIn)
        {
            isAvailable = false;
            StartCoroutine(FadeIn());
        }
    }

    public bool IsAvailable()
    {
        return isAvailable;
    }

    public void DisableLifeTimeRoutine()
    {
        useLifeTime = false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);

        if (useLifeTime)
        {
            StartCoroutine(FadeOutAndDestroy());
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        yield return StartCoroutine(FadeOut());
        Destroy(gameObject);
    }

    private IEnumerator FadeIn()
    {
        Color c = spriteRenderer.color;
        c.a = 0f;
        spriteRenderer.color = c;

        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            spriteRenderer.color = c;
            yield return null;
        }

        c.a = 1f;
        spriteRenderer.color = c;

        isAvailable = true;
    }

    private IEnumerator FadeOut()
    {
        isAvailable = false;

        Color c = spriteRenderer.color;
        float startAlpha = c.a;

        float t = 0f;
        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(startAlpha, 0f, t / fadeOutDuration);
            spriteRenderer.color = c;
            yield return null;
        }

        c.a = 0f;
        spriteRenderer.color = c;
    }
}
