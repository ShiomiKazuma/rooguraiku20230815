using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _dialogText;
    [TextArea(5, 5)]
    [SerializeField] string _msgText;
    [SerializeField] float _msgSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        _dialogText.text = "";
        
    }

    IEnumerable TypeDisplay()
    {
        foreach(char item in _msgText.ToCharArray())
        {
            _dialogText.text += item;
            yield return new WaitForSeconds(_msgSpeed);
        }
    }
}
