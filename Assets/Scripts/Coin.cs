using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _reward;

    public event Action<Coin> Taked;

    public int Reward => _reward;

    public void Take()
    {
        Taked?.Invoke(this);
        Destroy(gameObject);
    }
}
