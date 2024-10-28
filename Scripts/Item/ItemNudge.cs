using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ItemNudge : MonoBehaviour
{
    private WaitForSeconds pause;
    private bool isAnimating = false;

    private void Awake()
    {
        pause = new WaitForSeconds(0.04f);
    }

    // oyuncu nesneye çarptığında
    private void OnTriggerEnter2D(Collider2D other)
    {
        // animasyon oynatılmıyorsa nesnenin konumuna göre oynatılsın
        if (isAnimating == false)
        {
            // oyuncunun çarptığı nesne x eksenine göre oyuncunun sağında mı?
            if (gameObject.transform.position.x < other.gameObject.transform.position.x)
            {
                // nesne sola doğru yalpalanacak
                StartCoroutine(RotateAntiClock());
            }
            else
            {
                // oyuncunun çarptığı nesne x eksenine göre oyuncunun solunda mı?
                StartCoroutine(RotateClock());
            }
        }
    }

    // oyuncu nesneden ayrıldığında
    private void OnTriggerExit2D(Collider2D other)
    {
        // animasyon oynatılmıyorsa nesnenin konumuna göre oynatılsın
        if (isAnimating == false)
        {
            // oyuncunun ayrıldığı nesne x eksenine göre oyuncunun solunda mı?
            if (gameObject.transform.position.x > other.gameObject.transform.position.x)
            {
                // nesne saat yönünün tersine doğru yalpalanacak
                StartCoroutine(RotateAntiClock());
            }
            else
            {
                // nesne saat yönüne doğru yalpalanacak
                StartCoroutine(RotateClock());
            }
        }
    }

    private IEnumerator RotateAntiClock()
    {
        isAnimating = true;

        // yalpalanacak
        for (int i = 0; i < 4; i++)
        {
            // kaktüs/nesnenin z eksenine 2 birim eklenecek
            gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f);

            yield return pause; // duraklama
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f);

            yield return pause;
        }

        // eski haline geri dönecek
        gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f);

        yield return pause;

        isAnimating = false;
    }

    private IEnumerator RotateClock()
    {
        isAnimating = true;

        // yalpalanacak
        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f);

            yield return pause;
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f);

            yield return pause;
        }

        // eski haline geri dönecek
        gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f);

        yield return pause;

        isAnimating = false;
    }


}
