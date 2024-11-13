using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Classe "InimigoAmarelo" que herda de "InimigoBase".
// Representa um tipo específico de inimigo, que segue o caminho até o final.
public class InimigoAmarelo : InimigoBase
{
    // Método que é chamado quando o inimigo chega ao final do caminho.
    // O comportamento padrão para este inimigo é destruir o objeto quando chega ao final.
    protected override void ChegarNoFinalDoCaminho()
    {
        // Quando o inimigo chega ao final do caminho, ele é destruído.
        Destroy(gameObject);
    }
}


