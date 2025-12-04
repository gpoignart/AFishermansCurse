using UnityEngine;

public class Fish : MonoBehaviour
{
    public FishType type;
    private SpriteRenderer sr;

    // Called each time a new game object fish is instanciated
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = type.color;
    }
}
