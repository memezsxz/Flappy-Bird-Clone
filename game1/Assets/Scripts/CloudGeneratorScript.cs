using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject endPoint;
    [SerializeField] private GameObject[] cloudPrefab;
    [SerializeField] private float spawnInterval;
    private Vector3 _startPos;
    private float _ebdPosX;
    private float _halfScreenHeight;
    private float _halfScreenWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = transform.position;
        _startPos.z = endPoint.transform.position.z;
        _ebdPosX = endPoint.transform.position.x;
        _halfScreenHeight = Camera.main.orthographicSize; // 15
        _halfScreenWidth = Camera.main.aspect * _halfScreenHeight;
        Prewarm();
        // InvokeRepeating(nameof(AttemptSpawn), 0, spawnIntreval);
        StartCoroutine(SpawnCoroutine());
    }
    
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            AttemptSpawn();
            yield return new WaitForSecondsRealtime(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

     void SpawnCloud(Vector3 startPos)
    {
        int index = Random.Range(0, cloudPrefab.Length);
        GameObject cloud = Instantiate(cloudPrefab[index]);
        startPos.y = Random.Range(-(_halfScreenHeight ), (_halfScreenHeight));
        float scale = Random.Range(0.8f, 1.2f);
        cloud.transform.position = startPos;
        cloud.transform.localScale = new Vector3(scale, scale, cloud.transform.localScale.z);
        cloud.GetComponent<CloudScript>().StartFloating(Random.Range(1.5f, 2.0f), _ebdPosX);
    }

     void AttemptSpawn()
    {
        // we can do checking here before calling the spawn
        SpawnCloud(_startPos);
    }

    void Prewarm()
    {
        for (int i = 0; i < 11; i++)
        {
            Vector3 startPos = _startPos;
            startPos.x  = Random.Range(-(_halfScreenWidth), (_halfScreenWidth));
            SpawnCloud(startPos);
        }
    }
}
