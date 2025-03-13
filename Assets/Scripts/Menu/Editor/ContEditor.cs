using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NumCalcContPositions))]
public class ContEditor : Editor
{
    public override void OnInspectorGUI()
    {
        NumCalcContPositions myTarget = (NumCalcContPositions)target;

        myTarget.referenceObject = (GameObject)EditorGUILayout.ObjectField(myTarget.referenceObject, typeof(GameObject), true);

        EditorGUILayout.LabelField("Lista de Números");

        for (int i = 0; i < myTarget.contNum.Count; i++)
        {
            myTarget.contNum[i] = EditorGUILayout.IntField($"Número {i + 1}:", myTarget.contNum[i]);
        }

        if (GUILayout.Button("RandomList"))
        {
            myTarget.RandomList();
        }

        EditorGUILayout.LabelField("Total Cont = ", myTarget.totalcont.ToString());
        EditorGUILayout.HelpBox("Calcule os Numeros ", MessageType.Info);

        if(myTarget.totalcont > 50)
        {
            EditorGUILayout.HelpBox("Contagem excessiva poder prejudicar o desempenho", MessageType.Warning);
        }

        GUI.color = Color.red;
        if (GUILayout.Button("CriateObject"))
        {
            myTarget.CreateRefObject(myTarget.contNum[0], 3.5f);
        }
        GUI.color = Color.green;
        if (GUILayout.Button("CriateObject"))
        {
            myTarget.CreateRefObject(myTarget.contNum[1], 2f);
        }
        GUI.color = Color.blue;
        if (GUILayout.Button("CriateObject"))
        {
            myTarget.CreateRefObject(myTarget.contNum[2], 0.3f);
        }
        GUI.color = Color.yellow;
        if (GUILayout.Button("CriateObject"))
        {
            myTarget.CreateRefObject(myTarget.contNum[3], -1.2f);
        }
    }
    
    
}
