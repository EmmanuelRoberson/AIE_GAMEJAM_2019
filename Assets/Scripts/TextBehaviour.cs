using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class TextBehaviour : MonoBehaviour
{
    public int numberValue;

    public string textValue;

    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.SetText(textValue + " - " + numberValue);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Decrement()
    {
        Debug.Log("DecrementCalled");
        if (numberValue > 0)
        {
            numberValue -= 1;
        }
        
        textMesh.SetText(textValue + " - " + numberValue);
    }
}
