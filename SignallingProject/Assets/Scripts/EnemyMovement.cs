using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private Vector3 _centrePoint;
    private float _angle;

    private void Start()
    {
        _centrePoint = transform.position;
    }

    private void Update()
    {
        _angle += _speed * Time.deltaTime;

        Vector3 offset = new Vector3(_radius * Mathf.Cos(_angle) * Mathf.Deg2Rad, _radius * Mathf.Sin(_angle) * Mathf.Deg2Rad, 0);
        transform.position = _centrePoint + offset;
    }
}
