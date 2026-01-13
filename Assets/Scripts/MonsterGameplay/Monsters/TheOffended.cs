using UnityEngine;
using System.Collections;

public class TheOffended : Monster
{
    public TheOffendedSO theOffendedSO;

    protected override void Start()
    {
        // Call the start method of the parent class
        base.Start();

        // Assign the right monsterSO
        theOffendedSO = GameManager.Instance.MonsterRegistry.theOffendedSO;
        
        // Sprite assignation
        if (GameManager.Instance.MonsterApparitionSide == 0)
        {
            spriteRenderer.sprite = theOffendedSO.spriteLeft;            
        }
        else
        {
            spriteRenderer.sprite = theOffendedSO.spriteRight;
        }
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
    }

    public void ReinitializeTheOffended()
    {
        isHit = false;
    }

    protected override IEnumerator MonsterHit()
    {
        yield return StartCoroutine(MonsterHitReaction());

        // If we are in the tutorial, reinitialize the sprite after reaction
        if (!theOffendedSO.hasBeenEncountered && GameManager.Instance.MonsterApparitionSide == 0)
        {
            spriteRenderer.sprite = theOffendedSO.spriteLeft;
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else if (!theOffendedSO.hasBeenEncountered && GameManager.Instance.MonsterApparitionSide == 1)
        {
            spriteRenderer.sprite = theOffendedSO.spriteRight;        
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);    
        }

        MonsterGameManager.Instance.PlayerLose();
    }

    protected override IEnumerator MonsterTimeOut()
    {
        if (theOffendedSO.hasBeenEncountered)
        {
            yield return StartCoroutine(MonsterTimeOutReaction());

            MonsterGameManager.Instance.PlayerWin();
        }
        // If we are in the tutorial for this monster, he disappears later
        else
        {
            MonsterGameManager.Instance.PlayerWin();
            yield return null;
        }
    }

    public IEnumerator MonsterTimeOutReaction()
    {
        AudioManager.Instance.PlayMonsterRanAwaySFX();

        // Fade out
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * 3f;
            float alpha = Mathf.Clamp01(t);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }

    public IEnumerator MonsterHitReaction()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 4f;
            float alpha = Mathf.Lerp(0.2f, 1f, t);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        // Switch sprite
        spriteRenderer.sprite = theOffendedSO.spriteAngry;
        yield return new WaitForSeconds(0.5f);
    }
}
