using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreMedia: TorreBase
{
    public GameObject prefabMunicao;

    protected override bool PodeAtacar(IAtacavel atacavel)
    {
        return atacavel is InimigoVermelho || atacavel is InimigoAzul;
    }

    public override void Atacar()
    {
        if (atacaveisNoAlcance.Count > 0)
        {
            IAtacavel alvo = atacaveisNoAlcance[0];
            Disparar(alvo);
            Debug.Log("Atirou");
        }
    }

    private void Disparar(IAtacavel alvo)
    {
        GameObject municaoObj = Instantiate(prefabMunicao, spawnPonto.position, Quaternion.identity);
        Municao municao = municaoObj.GetComponent<Municao>();
        municao.Iniciar((InimigoBase)alvo, dano);
    }
}
