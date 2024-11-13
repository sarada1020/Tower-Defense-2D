using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe espec�fica de uma torre chamada "TorreFraca", que herda de TorreBase.
// Essa torre tem caracter�sticas �nicas, como atacar inimigos de certas cores e usar um tipo espec�fico de muni��o.
public class TorreFraca : TorreBase
{
    public GameObject prefabMunicao; // Prefab da muni��o que ser� instanciada quando a torre atacar.

    // Define a l�gica para determinar se a torre pode atacar um inimigo.
    // A "TorreFraca" s� pode atacar inimigos do tipo "InimigoAmarelo" ou "InimigoLaranja".
    protected override bool PodeAtacar(IAtacavel atacavel)
    {
        return atacavel is InimigoAmarelo || atacavel is InimigoLaranja;
    }

    // Implementa o m�todo de ataque espec�fico para esta torre.
    public override void Atacar()
    {
        // Verifica se h� inimigos no alcance.
        if (atacaveisNoAlcance.Count > 0)
        {
            IAtacavel alvo = atacaveisNoAlcance[0]; // Seleciona o primeiro inimigo da lista.
            Disparar(alvo); // Chama o m�todo para disparar muni��o contra o alvo.
        }
    }

    // M�todo que lida com o disparo da muni��o.
    private void Disparar(IAtacavel alvo)
    {
        // Instancia o objeto de muni��o no ponto de spawn da torre.
        GameObject municaoObj = Instantiate(prefabMunicao, spawnPonto.position, Quaternion.identity);

        // Obt�m o componente "Municao" do objeto instanciado.
        Municao municao = municaoObj.GetComponent<Municao>();

        // Inicializa a muni��o, passando o alvo e o dano da torre.
        municao.Iniciar((InimigoBase)alvo, dano);
    }
}


