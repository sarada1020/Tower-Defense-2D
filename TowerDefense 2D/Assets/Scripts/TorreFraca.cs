using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe específica de uma torre chamada "TorreFraca", que herda de TorreBase.
// Essa torre tem características únicas, como atacar inimigos de certas cores e usar um tipo específico de munição.
public class TorreFraca : TorreBase
{
    public GameObject prefabMunicao; // Prefab da munição que será instanciada quando a torre atacar.

    // Define a lógica para determinar se a torre pode atacar um inimigo.
    // A "TorreFraca" só pode atacar inimigos do tipo "InimigoAmarelo" ou "InimigoLaranja".
    protected override bool PodeAtacar(IAtacavel atacavel)
    {
        return atacavel is InimigoAmarelo || atacavel is InimigoLaranja;
    }

    // Implementa o método de ataque específico para esta torre.
    public override void Atacar()
    {
        // Verifica se há inimigos no alcance.
        if (atacaveisNoAlcance.Count > 0)
        {
            IAtacavel alvo = atacaveisNoAlcance[0]; // Seleciona o primeiro inimigo da lista.
            Disparar(alvo); // Chama o método para disparar munição contra o alvo.
        }
    }

    // Método que lida com o disparo da munição.
    private void Disparar(IAtacavel alvo)
    {
        // Instancia o objeto de munição no ponto de spawn da torre.
        GameObject municaoObj = Instantiate(prefabMunicao, spawnPonto.position, Quaternion.identity);

        // Obtém o componente "Municao" do objeto instanciado.
        Municao municao = municaoObj.GetComponent<Municao>();

        // Inicializa a munição, passando o alvo e o dano da torre.
        municao.Iniciar((InimigoBase)alvo, dano);
    }
}


