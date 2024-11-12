using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreExistente : MonoBehaviour
{
    private GameObject torre;

    public bool TemTorre()
    {
        return torre != null;
    }

    public void DefinirTorre(GameObject novaTorre)
    {
        torre = novaTorre;
    }
}

