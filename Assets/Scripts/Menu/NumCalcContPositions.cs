using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCalcContPositions : MonoBehaviour
{
    public GameObject referenceObject;
    public List<int> contNum;
    public int soma; 

    public int totalcont
    {
        get
        {
            soma = 0;
            for (int i = 0; i < contNum.Count; i++)
            {
                soma += contNum[i];
            }
            return soma;
        }
    }

    public void CreateRefObject(float num, float y)
    {
        float newPosition = -((num * 0.4f) / 2) + 0.2f;
        for (int i = 0; i < num; i++)
        {
            var a = Instantiate(referenceObject);
            a.transform.position = new Vector3(newPosition, y, 0);
            newPosition += 0.4f;
        }
    }

    public void RandomList()
    {
        contNum = contNum.ShuffleList();
    }
}
