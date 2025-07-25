using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found.");
        }
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the player.");
        }
    }

    void FixedUpdate()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; 
        rb.MovePosition(mouseWorldPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance != null && GameManager.instance.isGameActive && collision.gameObject.CompareTag("Wall"))
        {
            GameManager.instance.IncrementCollision();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StartZone"))
        {
            GameManager.instance.StartGame();
            Debug.Log("Game Started!");
        }

        else if (other.gameObject.CompareTag("EndZone"))
        {

            if (GameManager.instance != null && GameManager.instance.isGameActive)
            {
                GameManager.instance.EndGame();
                Debug.Log("You reached the end!");
            }
        }
    }
}