using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IInteraction
{
    [SerializeField]
    private Slider enemyHealthbar;

    private const int maxHealth = 100;
    private int currentHealth = 0;

    private bool isShowingHealthbar = false;
    private void Awake()
    {
        currentHealth = maxHealth;
        RefreshHealthbar();
        enemyHealthbar.gameObject.SetActive(isShowingHealthbar);
    }

    public void Interact()
    {
        currentHealth = Mathf.Max(currentHealth - 10, 0);
        Debug.Log("Current Health: " + currentHealth);
        RefreshHealthbar();

        if (!isShowingHealthbar)
        {
            Debug.Log("Showing heaslthbar");
            StartCoroutine(ShowHealthbar());
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ShowHealthbar()
    {
        enemyHealthbar.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        isShowingHealthbar = false;
        enemyHealthbar.gameObject.SetActive(false);
    }

    public void OnSeen()
    {
    }

    public void OnStopSee()
    {
    }

    private void RefreshHealthbar()
    { 
        float value = (float)currentHealth / (float)maxHealth;
        Debug.Log(value);
        enemyHealthbar.value = value;
    }

}
