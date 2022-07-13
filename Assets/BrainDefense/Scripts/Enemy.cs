using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int healthRewardToPlayer = 25;
    [SerializeField] int damageToPlayerHealth = 25;
    [SerializeField] int maxHealth = 5;
    [Tooltip("Adds amount to maxHealth upon enemy death")]
    [SerializeField] int difficltyRamp = 1;
    int currnetHealth = 0;

    PlayerHealth bank;
    void OnEnable()
    {
        currnetHealth = maxHealth;
    }
    void Start()
    {
        bank = FindObjectOfType<PlayerHealth>();
    }
    private void OnParticleCollision(GameObject other)
    {
        currnetHealth--;
        if (currnetHealth < 1)
        {
            gameObject.SetActive(false);
            maxHealth += difficltyRamp;
            RewardGold();
        }
    }
    public void RewardGold()
    {
        if (bank == null) return;
        bank.GainHealth(healthRewardToPlayer);
    }
    public void StealGold()
    {
        if (bank == null) return;
        bank.RemoveHealth(healthRewardToPlayer);
    }
}
