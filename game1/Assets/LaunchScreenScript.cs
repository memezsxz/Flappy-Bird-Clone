using TMPro;
using UnityEngine;

public class LaunchScreenScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
