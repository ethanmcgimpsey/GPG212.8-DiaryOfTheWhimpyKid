using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseRight : MonoBehaviour
{
    public float curSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * curSpeed * Time.deltaTime);
    }
}
