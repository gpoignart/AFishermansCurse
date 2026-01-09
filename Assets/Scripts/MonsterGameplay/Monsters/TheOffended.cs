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
        spriteRenderer.sprite = theOffendedSO.sprite;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.05f);
    }

    public void ReinitializeTheOffended()
    {
        isHit = false;
    }

    protected override IEnumerator MonsterHit()
    {
        MonsterGameManager.Instance.PlayerLose();
        yield return null;
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
}
