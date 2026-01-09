using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Monster/TheOffended")]
public class TheOffendedSO : MonsterSO
{
    public Sprite sprite;

    public override void Initialize()
    {
        this.monsterName = "TheOffended";
        this.loseTime = 5f;
        this.isApparitionReversed = false;
        this.isWarningFake = false;
        this.hasBeenEncountered = false;
    }
}