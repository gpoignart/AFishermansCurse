using UnityEngine;

[CreateAssetMenu(menuName = "Transition/EndDay")]
public class EndDaySO : TransitionSO
{
    public override void Initialize()
    {
        this.text = "Night falls...";
        this.duration = 3f;
    }
}
