using UnityEngine;

public class kill_me : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hehehehheheheh");
        other.gameObject.GetComponent<PlayerController>().kill();
    }
}
