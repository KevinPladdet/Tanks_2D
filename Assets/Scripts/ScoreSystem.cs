using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int ScoreLeft;
    public int ScoreRight;

    public TextMeshProUGUI ScoreLeftText;
    public TextMeshProUGUI ScoreRightText;

    private static ScoreSystem _instance;

    public static ScoreSystem Instance { get { return _instance; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        ScoreLeftText.text = ScoreLeft.ToString();
        ScoreRightText.text = ScoreRight.ToString();
    }
}
