using UnityEngine;
using UnityEngine.SceneManagement; // dacă vrei să schimbi scene

public class Meniu4 : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Ai apăsat butonul!");
        // Exemplu: SceneManager.LoadScene("Scena1");  // ca să pornești nivelul
        SceneManager.LoadScene("Scena1");
    }
}
