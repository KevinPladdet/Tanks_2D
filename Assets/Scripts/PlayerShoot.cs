using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;

    private bool isShooting;

    public Transform shootPos;
    public GameObject bullet;
    public Transform tankVisual;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        int direction()
        {
            if(tankVisual.forward.z < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isShooting = true;

        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.transform.rotation = new Quaternion(0, 0, tankVisual.transform.rotation.z,0);
        newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * tankVisual.up * Time.deltaTime;

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }


}
