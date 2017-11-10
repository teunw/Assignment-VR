using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject PrefabToSpawn;

    public Vector3 ScaleOffset = new Vector3(0f, 0f, 0f);

    public Vector3 PositionOffset = new Vector3(0f, 0f, 0f);

    public bool ActiveOnSpawn = true;

    public GameObject Spawn()
    {
        var newObject = Instantiate(PrefabToSpawn, gameObject.transform.position + PositionOffset, gameObject.transform.rotation, transform);
        newObject.SetActive(ActiveOnSpawn);
        newObject.transform.localScale += ScaleOffset;
        return newObject;
    }
}
