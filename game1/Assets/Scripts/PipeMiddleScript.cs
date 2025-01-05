using System;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicManager logicManager;
public AudioSource audioSource;
    private void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3 && other.enabled)
        {
            logicManager.UpdateScore(1);
            audioSource.Play();
        }
    }
}
