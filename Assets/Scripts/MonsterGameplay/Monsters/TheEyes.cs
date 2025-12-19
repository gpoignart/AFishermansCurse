using UnityEngine;
using System.Collections;

public class TheEyes : Monster
{
    public TheEyesSO theEyesSO;
    
    protected override void Start()
    {
        // Call the start method of the parent class
        base.Start();

        // Assign the right monsterSO
        theEyesSO = GameManager.Instance.MonsterRegistry.theEyesSO;

        // Eyes appear immediately but very faint
        spriteRenderer.sprite = theEyesSO.eyesNormal;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.05f);
    }

    // Implement TheEyes monster reaction
    protected override IEnumerator MonsterReaction()
    {
        // Brighten eyes quickly
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 4f;
            float alpha = Mathf.Lerp(0.2f, 1f, t);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        // Switch sprite → squint eyes
        spriteRenderer.sprite = theEyesSO.eyesSquint;
        yield return new WaitForSeconds(0.5f);

        // Fade out
        t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * 3f;
            float alpha = Mathf.Clamp01(t);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }
}
