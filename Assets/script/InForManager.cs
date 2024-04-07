using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoManager : MonoBehaviour
{
    public Text info;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        info.text = "Ten nguoi choi Khoi Nguyen";
    }
}
