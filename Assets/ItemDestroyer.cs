using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    GameObject mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < mainCamera.transform.position.z)
        {
            //通過したオブジェクトを破棄
            Destroy(this.gameObject);
        }
    }
}