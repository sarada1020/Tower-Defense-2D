using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe "TorreMedia", representando uma torre com for�a intermedi�ria.
// Esta torre � especializada em atacar inimigos das classes InimigoVermelho e InimigoAzul.
public class TorreMedia : TorreBase
{
    public GameObject prefabMunicao; // Refer�ncia ao prefab da muni��o que ser� disparada.

    // Determina quais tipos de inimigos a torre pode atacar.
    // A "TorreMedia" ataca apenas inimigos das classes "InimigoVermelho" e "InimigoAzul".
    protected override bool PodeAtacar(IAtacavel atacavel)
    {
        return atacavel is InimigoVermelho || atacavel is InimigoAzul;
    }

    // M�todo que realiza o ataque da torre.
    public override void Atacar()
    {
        // Verifica se h� inimigos no alcance.
        if (atacaveisNoAlcance.Count > 0)
        {
            IAtacavel alvo = atacaveisNoAlcance[0]; // Seleciona o primeiro inimigo na lista de alvos no alcance.
            Disparar(alvo); // Chama o m�todo para disparar muni��o contra o inimigo.
            Debug.Log("Atirou"); // Exibe uma mensagem no console para depura��o.
        }
    }

    // M�todo que realiza o disparo da muni��o contra o inimigo.
    private void Disparar(IAtacavel alvo)
    {
        // Instancia o prefab da muni��o na posi��o de spawn da torre.
        GameObject municaoObj = Instantiate(prefabMunicao, spawnPonto.position, Quaternion.identity);

        // Obt�m o componente "Municao" do objeto instanciado.
        Municao municao = municaoObj.GetComponent<Municao>();

        // Inicializa a muni��o com o alvo e o dano da torre.
        municao.Iniciar((InimigoBase)alvo, dano);
    }
}
