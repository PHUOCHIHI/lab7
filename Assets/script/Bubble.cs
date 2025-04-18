using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Sprite[] sprites;      // Bubble thường
    public Sprite bombSprite;     // Sprite bomb

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, sprites.Length);

        // Xác suất 20% là bomb
        bool isBomb = Random.value < 0.2f;

        if (isBomb && bombSprite != null)
        {
            sr.sprite = bombSprite;
            gameObject.name = "Bomb";

            // 💣 Destroy sau 5s nếu là bomb
            Destroy(gameObject, 5f);
        }
        else
        {
            sr.sprite = sprites[randomIndex];
            gameObject.name = "Bubble";
        }
    }
}
