using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseUp : MonoBehaviour
{
    public float curSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * curSpeed * Time.deltaTime);
    }
}
