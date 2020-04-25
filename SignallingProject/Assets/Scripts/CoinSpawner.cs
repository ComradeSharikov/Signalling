using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _spawnTime;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            _currentPoint = Random.Range(0, _points.Length);

            Transform target = _points[_currentPoint];
            Instantiate(_coin, target.position, Quaternion.identity);
            
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
