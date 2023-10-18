using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCoordinate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOnePos = GameObject.Find("PlayerOne").transform.position;

        Debug.Log($"{playerOnePos.x} {playerOnePos.y} {playerOnePos.z}");
    }
}
