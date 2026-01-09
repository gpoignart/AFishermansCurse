using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Monster/TheEyes")]
public class TheEyesSO : MonsterSO
{
    public Sprite eyesNormal; // default open eyes
    public Sprite eyesSquint; // squint eyes sprite

    public override void Initialize()
    {
        this.monsterName = "TheEyes";
        this.loseTime = 3f;
        this.isApparitionReversed = false;
        this.isWarningFake = false;
        this.hasBeenEncountered = false;
    }
}