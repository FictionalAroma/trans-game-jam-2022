using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 150;
    [SerializeField] int currentHealth;
    public int CurrnetBal { get { return currentHealth; } }

    [SerializeField] TextMeshProUGUI balanceText;
    private void Awake()
    {
        currentHealth = startingHealth;
        UpdateDisplay();
    }
    public void GainHealth(int amount)
    {
        currentHealth += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void RemoveHealth(int amount)
    {
        currentHealth -= Mathf.Abs(amount);
        UpdateDisplay();
        if (currentHealth < 0)
        {
            ReloadScene();
        }
    }
    void UpdateDisplay()
    {
        balanceText.text = "Health: " + currentHealth;
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
