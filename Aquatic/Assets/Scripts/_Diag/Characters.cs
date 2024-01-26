using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    private static int[] indexDialogue;
    private static int[] pointArretIndex;


    private static bool[] repeatSameDialogue;


    private void Awake()
    {

        if (indexDialogue == null)
        {
            // Créer un tableau avec la même taille que le nombre d'éléments dans l'énumération PNJ
            indexDialogue = new int[System.Enum.GetValues(typeof(PNJ)).Length];
            pointArretIndex = new int[System.Enum.GetValues(typeof(PNJ)).Length];
            repeatSameDialogue = new bool[System.Enum.GetValues(typeof(PNJ)).Length];
            // Remplir le tableau avec une valeur par défaut (0 dans cet exemple)
            Array.Fill(indexDialogue, 0);
            Array.Fill(repeatSameDialogue, false);

        }
    }

    private void Update()
    {
    }

    public static int GetLastDiagIndex(PNJ value)
    {
        return indexDialogue[(int)value];
    }

    public static void SetLastDiagIndex(PNJ index, int value)
    {
        indexDialogue[(int)index] = value;
    }

    public static int GetPointArretIndex(PNJ value)
    {
        return pointArretIndex[(int)value];
    }

    public static void SetPointArretIndex(PNJ index, int value)
    {
        pointArretIndex[(int)index] = value;
    }

    public static bool GetRepeatSameDialogue(PNJ value)
    {
        return repeatSameDialogue[(int)value];
    }

    public static void SetRepeatSameDialogue(PNJ index, bool value)
    {
        repeatSameDialogue[(int)index] = value;
    }
}

public enum PNJ : int
{
    EncrevaFurtiflimb = 0
}
