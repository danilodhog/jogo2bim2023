using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetMouseButtonDown(0))
            Awake();
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
