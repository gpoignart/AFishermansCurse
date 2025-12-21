using UnityEngine;

[CreateAssetMenu(menuName = "Transition/EndNight")]
public class EndNightSO : TransitionSO
{
    public override void Initialize()
    {
        this.text = "Day finally breaks...";
        this.duration = 3f;
    }
}
