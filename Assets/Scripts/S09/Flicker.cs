using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Light))]
public class Flicker : MonoBehaviour
{
    public Light thisLight;
    public Vector2 range;
    // Start is called before the first frame update
    void Reset()
    {
        thisLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        thisLight.intensity = Random.Range(range.x, range.y);
    }
}
