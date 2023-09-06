using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    int floor;
    [SerializeField] Text floorNum;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameManager._floor;
        floorNum.text = floor.ToString() + "ŠK";
    }

    public void FloorUp()
    {
        floor++;
        floorNum.text = floor.ToString() + "ŠK";
        SceneManager.LoadScene(floor);
    }
}
