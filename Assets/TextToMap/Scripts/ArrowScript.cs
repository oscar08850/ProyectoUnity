using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    GameObject objeto;
    int damage = 40;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide (name) : " + collision.collider.gameObject.name);
        Debug.Log("collide (tag) : " + collision.collider.gameObject.tag);
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        KnightScript knight = hitInfo.GetComponent<KnightScript>();
        TinajaVaciaScript tinajaVacia = hitInfo.GetComponent<TinajaVaciaScript>();
        TinajaLlaveScript tinajaLlave = hitInfo.GetComponent<TinajaLlaveScript>();
        TinajaMonedaScript tinajaMoneda = hitInfo.GetComponent<TinajaMonedaScript>();
        CoinController moneda = hitInfo.GetComponent<CoinController>();
        BossScript boss = hitInfo.GetComponent<BossScript>();

        Debug.Log("HIT INFO" + hitInfo.name);
        if (knight != null)
        {
            knight.TakeDamage(damage);
            Destroy(gameObject, 0f);

        }
        else if (tinajaVacia != null)
        {
            tinajaVacia.TakeDamage(damage);
            Destroy(gameObject, 0f);

        }
        else if (tinajaLlave != null)
        {
            tinajaLlave.TakeDamage(damage);
            Destroy(gameObject, 0f);

        }
        else if (tinajaMoneda != null)
        {
            tinajaMoneda.TakeDamage(damage);
            Destroy(gameObject, 0f);

        }
        else if (boss != null)
        {
            boss.TakeDamage(damage);
            Destroy(gameObject, 0f);

        }
        else {

        }
    }
}
