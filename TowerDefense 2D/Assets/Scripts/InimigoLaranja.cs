using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoLaranja : InimigoBase
{
    protected override void ChegarNoFinalDoCaminho()
    {
        // Aqui voc� pode definir o que acontece quando o inimigo chega no final
        Destroy(gameObject);
    }
}

