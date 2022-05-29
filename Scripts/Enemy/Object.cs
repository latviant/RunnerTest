using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
        }

        Die();
    }


    private void Die()
    {
        gameObject.SetActive(false);
    }
}
