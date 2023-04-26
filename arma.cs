using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class arma : MonoBehaviour
{
    [SerializeField] public GameObject bullet;

    public Camera playercamera;
    public Transform origemtiro;
    public float gunrange = 50f;
    public float firerate = 0.2f;
    public float laserduration = 0.05f;

    LineRenderer laserline;
    float FireTimer;

    // Start is called before the first frame update
    void Awake()
    {
        laserline = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FireTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && FireTimer > firerate)
        {
            FireTimer = 0;
            laserline.SetPosition(0, origemtiro.position);
            Vector3 rayOrigin = playercamera.ViewportToWorldPoint(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, playercamera.transform.forward, out hit, gunrange))
            {
                laserline.SetPosition(1, hit.point);
                bullet = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
                bullet.transform.position += bullet.transform.forward / 1000;
            }
            else
            { 
                laserline.SetPosition(1, rayOrigin + (playercamera.transform.forward * gunrange));
            }
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        laserline.enabled = true;
        yield return new WaitForSeconds(laserduration);
        laserline.enabled = false;
    }
}
