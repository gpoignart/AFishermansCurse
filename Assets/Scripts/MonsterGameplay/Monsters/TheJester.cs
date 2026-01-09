using UnityEngine;
using System.Collections;

public class TheJester : Monster
{
    public TheJesterSO theJesterSO;
    
    protected override void Start()
    {
        // Call the start method of the parent class
        base.Start();

        // Assign the right monsterSO
        theJesterSO = GameManager.Instance.MonsterRegistry.theJesterSO;

        // Sprite
        spriteRenderer.sprite = theJesterSO.normalSprite;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.05f);
    }

    protected override IEnumerator MonsterTimeOut()
    {
        MonsterGameManager.Instance.PlayerLose();
        yield return null;
    }

    protected override IEnumerator MonsterHit()
    {
        yield return StartCoroutine(MonsterHitReaction());
        
        // After the reaction
        MonsterGameManager.Instance.PlayerWin();
    }

    public IEnumerator MonsterHitReaction()
    {
        AudioManager.Instance.PlayMonsterRanAwaySFX();

        // Brighten eyes quickly
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 4f;
            float alpha = Mathf.Lerp(0.2f, 1f, t);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        // Switch sprite
        spriteRenderer.sprite = theJesterSO.caughtSprite;
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
