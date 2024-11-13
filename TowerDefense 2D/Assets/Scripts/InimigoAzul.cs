using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Classe "InimigoAzul" que herda de "InimigoBase".
// Representa um inimigo específico, com um comportamento customizado ao chegar no final do caminho.
public class InimigoAzul : InimigoBase
{
    // Método que é chamado quando o inimigo chega ao final do caminho.
    // O comportamento padrão para este inimigo é destruir o objeto quando chega ao final.
    protected override void ChegarNoFinalDoCaminho()
    {
        // Quando o inimigo chega ao final do caminho, ele é destruído.
        Destroy(gameObject);
    }
}

