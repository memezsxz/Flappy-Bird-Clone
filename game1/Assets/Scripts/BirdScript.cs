using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapStrength;
    public LogicManager logic;
    public bool isAlive = true;
    public AudioSource audio;
    public Animator WingAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Bob The Bird";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveUP();
    }

    void moveUP()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive )
        {
            rb.linearVelocity =  Vector2.up * flapStrength;
        }
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        WingAnimator.enabled = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
        audio.enabled = true;
        audio.Play();
        GetComponent<CircleCollider2D>().enabled = false;
        logic.gameOver();
        isAlive = false;
    }
}
