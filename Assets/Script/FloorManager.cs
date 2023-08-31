using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    int floor;
    [SerializeField] Text floorNum;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameManager._floor;
    }

    // Update is called once per frame
    void Update()
    {
        floorNum.text = floor.ToString() + "ŠK";
    }

    public void FloorUp()
    {
        floor++;
    }
}
