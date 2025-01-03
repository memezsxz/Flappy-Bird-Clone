using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public int spawnRate = 3;
    private float _timer;
    public float heightOffset = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePipe();
    }

    void UpdatePipe()
    {
        if (_timer < spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _timer = 0;
        }
    }

    void SpawnPipe()
    {
        float lowestY = transform.position.y - heightOffset;
        float highestY = transform.position.y + heightOffset;
        
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestY, highestY) , 0), transform.rotation);
    }
}