using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typper : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = .1f;

    public string phrase;

    private bool stopBool;

    private void Awake()
    {
        EraseTest();
    }

    public void EraseTest()
    {
        textMesh.text = "";
        stopBool = true;
    }

    public void startTypeAprove()
    {
        stopBool = false;
    }

    [NaughtyAttributes.Button]
    public void startType()
    {
        StartCoroutine(Types(phrase));
    }

    IEnumerator Types(string s)
    {
        textMesh.text = "";
        foreach (char l in s.ToCharArray())
        {
            if (stopBool)
            {
                break;
            }
            textMesh.text += l;            
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}
