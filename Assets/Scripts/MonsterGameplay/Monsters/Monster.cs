using UnityEngine;
using System.Collections;

public abstract class Monster : MonoBehaviour
{
    // Internal references
    protected SpriteRenderer spriteRenderer; // Visibility protected to be accessible from the child class
    protected bool isHit; // Visibility protected to be accessible from the child class

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isHit = false;
    }

    // Called by the flashlight controller when hit the monster
    public void HitByFlashlight()
    {
        if (!isHit)
        {
            isHit = true;
            MonsterGameManager.Instance.StopMonsterTimer();
            StartCoroutine(PlayMonsterReaction());
            AudioManager.Instance.PlayMonsterRanAwaySFX();
        }
    }

    public IEnumerator PlayMonsterReaction()
    {
        yield return StartCoroutine(MonsterReaction()); // Wait the end of monster reaction
        MonsterGameManager.Instance.PlayerWin();
    }

    // Must be implemented by all childs
    protected abstract IEnumerator MonsterReaction();
}
