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

    // Will be called by the flashlight controller
    public virtual void HitByFlashlight()
    {
        if (isHit) return;

        isHit = true;
        MonsterGameManager.Instance.StopMonsterTimer();
        StartCoroutine(MonsterHit());
    }

    // Will be called by the game manager
    public void FlashlightTimeOut()
    {
        MonsterGameManager.Instance.StopMonsterTimer();
        StartCoroutine(MonsterTimeOut());
    }

    // Must be implemented by all child
    protected abstract IEnumerator MonsterHit();

    // Must be implemented by all child
    protected abstract IEnumerator MonsterTimeOut();
}
