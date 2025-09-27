using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
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
        if (Input.GetKey(KeyCode.A)) hInput -= 1f;
        if (Input.GetKey(KeyCode.D)) hInput += 1f;

        // Săritură (dacă e aproape pe sol, după velocitate)
        if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Sacrificiu: creează platformă și scade viața
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrySacrifice();
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
