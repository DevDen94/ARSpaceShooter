using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (other.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(other.gameObject);
                }
            }

            Destroy(other.gameObject);
            //GameManager.Instance.Lives--;
            Handheld.Vibrate();
            GameManager.Instance.ScreenDamageEffect.SetActive(true);
            Invoke(nameof(DisableDamageTakenEffect), 0.1f);
            GameManager.Instance.currentHealth -= 0.03f;
        }

        if (other.CompareTag("S_Ast"))
        {
            for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (other.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(other.gameObject);
                }
            }

            Destroy(other.gameObject);
            //GameManager.Instance.Lives--;
            Handheld.Vibrate();
            GameManager.Instance.ScreenDamageEffect.SetActive(true);
            Invoke(nameof(DisableDamageTakenEffect), 0.1f);
            GameManager.Instance.currentHealth -= 0.03f;
        }

        if (other.CompareTag("Asteroids"))
        {
            for (int i = 0; i < MonsterGenerator.Instance._enemies.Count; i++)
            {
                if (other.gameObject == MonsterGenerator.Instance._enemies[i])
                {
                    MonsterGenerator.Instance._enemies.Remove(other.gameObject);
                }
            }

            Destroy(other.gameObject);
            Handheld.Vibrate();
            GameManager.Instance.ScreenDamageEffect.SetActive(true);
            Invoke(nameof(DisableDamageTakenEffect), 0.1f);
            GameManager.Instance.currentHealth -= 0.05f;
        }

        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Handheld.Vibrate();
            GameManager.Instance.ScreenDamageEffect.SetActive(true);
            Invoke(nameof(DisableDamageTakenEffect), 0.1f);
            GameManager.Instance.currentHealth -= 0.015f;
        }
    }

    void DisableDamageTakenEffect()
    {
        GameManager.Instance.ScreenDamageEffect.SetActive(false);
    }
}
