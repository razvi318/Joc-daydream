using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public void kill()
    {
        transform.position = new Vector3(-7.19f, -1.71f, -1f);
    }


    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Health & Sacrifice")]
    public int health = 5;
    public GameObject bloodPlatformPrefab; // setează în Inspector

    private Rigidbody2D rb;
    private float hInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Citește input-ul pe orizontală
        hInput = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) hInput -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) hInput += 1f;

        // Săritură (dacă e aproape pe sol, după velocitate)
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.linearVelocity.y) < 0.1f && Physics2D.Raycast(transform.position, Vector2.down, 1f))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    void FixedUpdate()
    {
        // Aplică mișcarea fizic
        rb.linearVelocity = new Vector2(hInput * moveSpeed, rb.linearVelocity.y);
    }

    void TrySacrifice()
    {
        if (health > 1 && bloodPlatformPrefab != null)
        {
            health--;
            Vector3 spawnPos = transform.position + Vector3.down * 1f;
            Instantiate(bloodPlatformPrefab, spawnPos, Quaternion.identity);
            Debug.Log("Sacrificed! Health left: " + health);
        }
        else
        {
            Debug.Log("Not enough health to sacrifice!");
        }
    }
}
