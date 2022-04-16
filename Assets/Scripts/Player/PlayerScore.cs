using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int CountScore { get; private set; }

    public event Action<int> SetedScore;

    private void Awake()
    {
        CountScore = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            CountScore += coin.Reward;
            coin.Take();
            SetedScore?.Invoke(CountScore);
        }
    }
}
