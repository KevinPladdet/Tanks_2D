using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{

    public PlayerShoot script;
    public PlayerShootRed scripttwo;

    public GameObject SpeedPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        
        SpeedPowerUp = GameObject.FindGameObjectWithTag("SpeedTag");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Object.Destroy(SpeedPowerUp);
    }

    // I need to make it so that if the red tank picks it up he gets the speed boost

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        //Object.Destroy(SpeedPowerUp);
        //script.shootSpeed = 12000;
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TankGreen2"))
        {
            Object.Destroy(SpeedPowerUp);
            script.shootSpeed = 1200;
        }
        if (other.gameObject.CompareTag("TankRed2"))
        {
            Object.Destroy(SpeedPowerUp);
            scripttwo.shootSpeed = 1200;
        }
    }
}
