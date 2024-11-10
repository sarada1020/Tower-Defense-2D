using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TorreBase : MonoBehaviour
{
    public float alcance;
    public int dano;
    public Transform spawnPonto;
    public float intervaloDeDisparo = 1.5f;

    private float contadorDeDisparo = 0f;
    protected List<IAtacavel> atacaveisNoAlcance = new List<IAtacavel>();

    void Update()
    {
        AtualizarAlvosNoAlcance();
        contadorDeDisparo -= Time.deltaTime;

        if (atacaveisNoAlcance.Count > 0 && contadorDeDisparo <= 0)
        {
            Atacar();
            contadorDeDisparo = intervaloDeDisparo;
        }
    }

    protected abstract bool PodeAtacar(IAtacavel atacavel);

    void AtualizarAlvosNoAlcance()
    {
        atacaveisNoAlcance.Clear();
        Collider2D[] alvosDetectados = Physics2D.OverlapCircleAll(transform.position, alcance);
        foreach (Collider2D col in alvosDetectados)
        {
            IAtacavel atacavel = col.GetComponent<IAtacavel>();
            if (atacavel != null && PodeAtacar(atacavel))
            {
                atacaveisNoAlcance.Add(atacavel);
            }
        }
    }

    public abstract void Atacar();
}

