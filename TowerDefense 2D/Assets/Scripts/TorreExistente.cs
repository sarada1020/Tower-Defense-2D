using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe "TorreExistente" que gerencia a exist�ncia e defini��o de uma torre em um local espec�fico.
public class TorreExistente : MonoBehaviour
{
    private GameObject torre; // Armazena a refer�ncia para a torre, se houver uma colocada neste local.

    // M�todo para verificar se h� uma torre j� definida.
    // Retorna true se j� houver uma torre no local, ou false caso contr�rio.
    public bool TemTorre()
    {
        // Retorna verdadeiro se a vari�vel 'torre' n�o for nula, indicando que existe uma torre.
        return torre != null;
    }

    // M�todo para definir uma nova torre neste local.
    // Armazena o objeto da torre para refer�ncia futura.
    public void DefinirTorre(GameObject novaTorre)
    {
        // Define o objeto da torre, substituindo qualquer torre que j� exista.
        torre = novaTorre;
    }
}


