using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Coin> _prefabs;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _offsetY;
    [SerializeField] private int _count;

    private Dictionary<Transform, Coin> _coins;

    private void OnValidate()
    {
        if(_count >= _points.Count || _count <= 0)
        {
            _count = 1;
        }
    }

    private void Awake()
    {
        _coins = new Dictionary<Transform, Coin>();
    }

    private void Start()
    {
        for(int i = 0; i < _count; i++)
        {
            SpawnCoin(GetCoinPrefab());
        }
    }

    private Coin GetCoinPrefab()
    {
        return _prefabs[Random.Range(0, _prefabs.Count)];
    }

    private void SpawnCoin(Coin prefab)
    {
        Transform point = _points[Random.Range(0, _points.Count)];
        _points.Remove(point);
        Coin coin = Instantiate(prefab, point);
        coin.transform.position = point.position + new Vector3(0, _offsetY, 0);
        _coins.Add(point, coin);
        coin.Taked += OnTakedCoin;
    }

    private void OnTakedCoin(Coin coin)
    {
        coin.Taked -= OnTakedCoin;
        SpawnCoin(GetCoinPrefab());

        Transform point = null; // надо придумать что-то получше

        foreach(var transformCoin in _coins)
        {
            if(transformCoin.Value == coin)
            {
                point = transformCoin.Key;
                _points.Add(point);
            }
        }

        _coins.Remove(point);
    }
}
