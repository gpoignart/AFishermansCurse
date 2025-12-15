using UnityEngine;

[CreateAssetMenu(menuName = "Transition/EndRecipeBookEvent")]
public class EndRecipeBookEventSO : TransitionSO
{
    public override void Initialize()
    {
        this.text = "The night has finally passed...\nYou obtained the recipe book. You can consult and use it in your inventory.";
        this.duration = 4f;
    }
}
