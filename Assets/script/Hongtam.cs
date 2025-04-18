using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArrowController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject targetBubble = null;

    void Update()
    {
        // Di chuyển bằng phím
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, y, 0).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        // Xoay theo hướng di chuyển nếu có input
        if (moveDir != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }

        // Nếu đang chạm bubble và bấm Space → chỉ xoá nếu KHÔNG phải bomb
        if (Input.GetKeyDown(KeyCode.Space) && targetBubble != null)
        {
            if (!targetBubble.name.Contains("Bomb"))
            {
                Destroy(targetBubble); // chỉ xoá nếu không phải bomb
            }
            else
            {
                Debug.Log("Không thể phá bomb bằng Space!");
            }

            targetBubble = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Nếu chạm bomb → thua
        if (other.gameObject.name.Contains("Bomb"))
        {
            Debug.Log("Trúng bomb! Game Over!");
            Destroy(gameObject);               // Xoá mũi tên
            StartCoroutine(RestartScene());    // Bắt đầu reset sau delay
        }
        else if (other.CompareTag("Bubble"))
        {
            targetBubble = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bubble") && other.gameObject == targetBubble)
        {
            targetBubble = null;
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
