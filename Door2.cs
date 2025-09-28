using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour
{
    public string nextSceneName; // setezi numele scenei în Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scena3");
        }
    }
}
