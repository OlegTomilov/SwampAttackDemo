using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotgun : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    private float _timeOfLife  = 0.2f;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);

        _timeOfLife -= Time.deltaTime;
        if (_timeOfLife <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}
