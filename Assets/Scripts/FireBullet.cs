using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    private bool _canFire = true;
    private GameObject _bullet;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && _canFire)
        {
            _canFire = false;
            StartCoroutine(LimitFiring());
            Debug.Log("F");
            SpawnBullet();
        }
    }

    public void SpawnBullet()
    {
        if (_canFire)
        {
            _canFire = false;
            StartCoroutine(LimitFiring());
            Vector3 startingPosition = new Vector3(transform.position.x, transform.position.y + .777f, transform.position.z);
            _bullet = Instantiate(bulletPrefab, startingPosition + transform.forward * 3f, transform.rotation, transform.parent);
            StartCoroutine(DestroyBullet(_bullet));
        }
    }

    IEnumerator LimitFiring()
    {
        yield return new WaitForSeconds(.5f);
        _canFire = true;
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        Destroy(bullet);
    }

}
