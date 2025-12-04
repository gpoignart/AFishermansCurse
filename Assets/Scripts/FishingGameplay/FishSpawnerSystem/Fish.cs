using UnityEngine;

public class Fish : MonoBehaviour
{
    public FishTypeSO type;
    private SpriteRenderer sr;

    // Called each time a new game object fish is instanciated
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = type.sprite;
        sr.color = type.color; // TO REMOVE when real sprite added
    }
}
