using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe "TorreExistente" que gerencia a existência e definição de uma torre em um local específico.
public class TorreExistente : MonoBehaviour
{
    private GameObject torre; // Armazena a referência para a torre, se houver uma colocada neste local.

    // Método para verificar se há uma torre já definida.
    // Retorna true se já houver uma torre no local, ou false caso contrário.
    public bool TemTorre()
    {
        // Retorna verdadeiro se a variável 'torre' não for nula, indicando que existe uma torre.
        return torre != null;
    }

    // Método para definir uma nova torre neste local.
    // Armazena o objeto da torre para referência futura.
    public void DefinirTorre(GameObject novaTorre)
    {
        // Define o objeto da torre, substituindo qualquer torre que já exista.
        torre = novaTorre;
    }
}


