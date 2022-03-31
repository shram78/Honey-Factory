using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CollectorHoneyBrick _collectorHoneyBrick;

    public CollectorHoneyBrick CollectorHoneyBrick => _collectorHoneyBrick;
}
