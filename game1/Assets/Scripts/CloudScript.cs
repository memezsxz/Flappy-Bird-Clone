using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private float _endPosX;
    private float _speed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _endPosX)
        {
            Destroy(gameObject);
            return;
        }
        
        transform.Translate((Vector3.left * Time.unscaledDeltaTime) * _speed);
    }
    
    public void StartFloating(float speed, float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }

}
