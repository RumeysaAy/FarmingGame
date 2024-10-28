using UnityEngine;

public class TriggerObscuringItemFader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // oyuncunun çarptığı nesnenin ve çocuklarının ObscuringItemFader bileşeni alındı
        ObscuringItemFader[] obscuringItemFaders = other.gameObject.GetComponentsInChildren<ObscuringItemFader>();

        if (obscuringItemFaders.Length > 0)
        {
            for (int i = 0; i < obscuringItemFaders.Length; i++)
            {
                // oyuncunun çarptığı nesnenin ve çocuklarının rengi soluklaştırıldı
                obscuringItemFaders[i].FadeOut();
            }
        }
    }

    // oyuncu çarptığı nesneden ayrılırsa
    private void OnTriggerExit2D(Collider2D other)
    {
        ObscuringItemFader[] obscuringItemFaders = other.gameObject.GetComponentsInChildren<ObscuringItemFader>();

        if (obscuringItemFaders.Length > 0)
        {
            for (int i = 0; i < obscuringItemFaders.Length; i++)
            {
                // nesnenin ve çocukarının rengi belirginleştirilir
                obscuringItemFaders[i].FadeIn();
            }
        }
    }
}
