using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Monster/TheJester")]
public class TheJesterSO : MonsterSO
{
    public Sprite normalSprite;
    public Sprite caughtSprite;

    public override void Initialize()
    {
        this.monsterName = "TheJester";
        this.loseTime = 4.5f;
        this.isApparitionReversed = true;
        this.isWarningFake = true;
        this.hasBeenEncountered = false;
    }
}