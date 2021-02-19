using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGarbage : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(transform.parent.forward * -speed * Time.deltaTime);
        transform.Rotate(new Vector3(15, 30, 45) * rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(transform.gameObject);
    }
}
