using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BulletDie : MonoBehaviour
{
    public GameObject diePEffect;

    public GameObject TankRed;
    public float dieTime;

    public GameObject canvas;
    public GameObject VictoryScreenRed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
        TankRed = GameObject.FindGameObjectWithTag("TankRed2");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        VictoryScreenRed = GameObject.FindGameObjectWithTag("YouWonRed");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Tank Red")
        {
            
        }
        else 
        {
            canvas.GetComponent<ScoreSystem>().ScoreLeft++;
            StopAllCoroutines();
            Destroy(TankRed);
            VictoryScreenRed.GetComponent<TextMeshProUGUI>().enabled = true;
            StartCoroutine(ResetTime());
        }
    }

  

    IEnumerator ResetTime()
    {
        Debug.Log("it works");
        yield return new WaitForSeconds(3);
        Debug.Log("it works2");
        SceneManager.LoadScene("Tanks 2D");
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }


    void Die()
    {
        if(diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
