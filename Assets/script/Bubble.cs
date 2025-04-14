using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Sprite[] sprites;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, sprites.Length);
        sr.sprite = sprites[randomIndex];

    }
}
        