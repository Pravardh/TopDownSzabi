using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public event Action OnSeePlayer;
    public event Action OnStopSeePlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController controller))
        {
            OnSeePlayer?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController controller))
        {
            OnStopSeePlayer?.Invoke();
        }
    }

}
