using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentHearts;

    public Image[] hearts;       // drag your heart Images here
    public Sprite fullHeart;     // sprite for full heart
    public Sprite emptyHeart;    // sprite for empty heart

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        if (currentHearts < 0)
            currentHearts = 0;

        UpdateHeartsUI();

        if (currentHearts == 0)
        {
            Debug.Log("Player Died!");
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
