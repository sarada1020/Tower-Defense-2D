using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe "InimigoRoxo" que herda de "InimigoBase".
// Representa um inimigo espec�fico, com um comportamento customizado ao chegar no final do caminho.
public class InimigoRoxo : InimigoBase
{
    // M�todo que � chamado quando o inimigo chega ao final do caminho.
    // O comportamento padr�o para este inimigo � destruir o objeto quando chega ao final.
    protected override void ChegarNoFinalDoCaminho()
    {
        // Quando o inimigo chega ao final do caminho, ele � destru�do.
        Destroy(gameObject);
    }
}

