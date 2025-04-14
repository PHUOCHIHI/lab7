using UnityEngine;

public class Hongtam : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject currentBall;

    void Update()
    {
        // Di chuyển hồng tâm
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime);

        // Bắn quả cầu nếu đang chạm và nhấn Space
        if (Input.GetKeyDown(KeyCode.Space) && currentBall != null)
        {
            Destroy(currentBall);
            currentBall = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            currentBall = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bubble") && other.gameObject == currentBall)
        {
            currentBall = null;
        }
    }
}
