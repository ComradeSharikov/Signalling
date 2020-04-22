using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy _enemy;
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
            Transform target = _points[_currentPoint];
            Instantiate(_enemy, target.position, Quaternion.identity);
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
