using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BulletDieRed : MonoBehaviour
{
    public GameObject diePEffect;

    public GameObject TankGreen;
    public float dieTime;

    public GameObject canvas;
    public GameObject VictoryScreenGreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
        TankGreen = GameObject.FindGameObjectWithTag("TankGreen2");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        VictoryScreenGreen = GameObject.FindGameObjectWithTag("YouWonGreen");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name != "Tank Green")
        {

        }
        else
        {
            canvas.GetComponent<ScoreSystem>().ScoreRight++;
            StopAllCoroutines();
            Destroy(TankGreen);
            VictoryScreenGreen.GetComponent<TextMeshProUGUI>().enabled = true;
            StartCoroutine(ResetTime());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    IEnumerator ResetTime()
    {
        Debug.Log("it works");
        yield return new WaitForSeconds(3);
        Debug.Log("it works2");
        SceneManager.LoadScene("Tanks 2D");
    }

    void Die()
    {
        if (diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
