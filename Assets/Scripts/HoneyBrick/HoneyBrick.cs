using UnityEngine;

public class HoneyBrick : MonoBehaviour
{
    BoxCollider boxCollider;
    private float _elapsedTime = 0;
    private float _delayAfterSpawn = 1f;

    private void OnEnable()
    {
        boxCollider = GetComponent<BoxCollider>(); 

        boxCollider.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _delayAfterSpawn)
        {
            boxCollider.enabled = true;

           // _elapsedTime = 0;
        }
    }
}