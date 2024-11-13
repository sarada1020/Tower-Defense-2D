using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Classe "InimigoAmarelo" que herda de "InimigoBase".
// Representa um tipo espec�fico de inimigo, que segue o caminho at� o final.
public class InimigoAmarelo : InimigoBase
{
    // M�todo que � chamado quando o inimigo chega ao final do caminho.
    // O comportamento padr�o para este inimigo � destruir o objeto quando chega ao final.
    protected override void ChegarNoFinalDoCaminho()
    {
        // Quando o inimigo chega ao final do caminho, ele � destru�do.
        Destroy(gameObject);
    }
}


