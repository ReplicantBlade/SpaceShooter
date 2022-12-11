using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpaceObject : MonoBehaviour
{
    public enum Type
    {
        Asteroid,
        HealthPoint,
        Bullet,
        Fuel
    }

    // Start is called before the first frame update
    void Awake()
    {
        var type = new Type();
        switch (type)
        {
            case Type.Asteroid:
                break;
            case Type.HealthPoint:
                break;
            case Type.Bullet:
                break;
            case Type.Fuel:
                break;
            default:
                break;
        }

        //transform.GetComponent<Rigidbody2D>().AddForce(transform.parent.up.normalized * Random.Range(20 ,50));
    }
}
