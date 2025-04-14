using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    private GameObject currentBall;

    void Update()
    {
        // Kiểm tra khi người chơi nhấn Space và đang chạm quả cầu
        if (Input.GetKeyDown(KeyCode.Space) && currentBall != null)
        {
            Destroy(currentBall); // Xóa quả cầu
            currentBall = null;

            // TODO: Thêm hiệu ứng nổ ở đây nếu cần
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
        if (other.CompareTag("Bubble"))
        {
            if (currentBall == other.gameObject)
            {
                currentBall = null;
            }
        }
    }
}
