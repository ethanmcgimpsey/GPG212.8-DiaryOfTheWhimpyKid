using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseLeft : MonoBehaviour
{
    public float curSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * curSpeed * Time.deltaTime);
    }
}
