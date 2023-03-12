using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private float _speed = 5f;
    private float _vanishTime = 3f;
    private float _damage;

    public void Launch(Vector3 direction, float damage)
    {
        GetComponent<Rigidbody>().velocity = direction * _speed;
        _damage = damage;
        StartCoroutine(Vanish());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            enemy.GetDamage(_damage);

        Destroy(gameObject);
    }

    private IEnumerator Vanish()
    {
        while (_vanishTime > 0)
        {
            _vanishTime -= Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
