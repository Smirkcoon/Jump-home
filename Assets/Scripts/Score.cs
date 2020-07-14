using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform Player;
    private Text ScoreT;
    private int maxHight;
    // Start is called before the first frame update
    void Start()
    {
        ScoreT = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHight < Player.position.y -7)
        {
            maxHight = Mathf.RoundToInt(Player.position.y) -7;
            ScoreT.text = maxHight.ToString();
        }
    }
}
