using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bag _bag;

    public Bag Bag => _bag;

    public void StandOnScate()
    {
        Vector3 scateHight = new Vector3(0, 0.1f, 0);

        transform.position = transform.position + scateHight;
    }
}
