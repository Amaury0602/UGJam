using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        IShootable shootable = collision.GetComponent<IShootable>();
        if (shootable != null) shootable.GetShot();
    }
}
