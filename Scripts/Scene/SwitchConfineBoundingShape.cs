using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }

    /// özet
    /// Switch the collider that cinemachine uses to define the edges of the screen
    /// Cinemachine'in ekranın kenarlarını tanımlamak için kullandığı çarpıştırıcıyı değiştirin
    /// 
    private void SwitchBoundingShape()
    {
        // Get the polygon collider on the 'boundsconfiner' gameobject which is used by Cinemachine to prevent the camera going beyond the screen edges
        // Cinemachine tarafından kameranın ekran kenarlarının ötesine geçmesini önlemek için kullanılan 'boundsconfiner' oyun nesnesindeki poligon çarpıştırıcısını edinin
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();

        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        // since the confiner bounds have changed need to call this to clear the cache
        // sınırlayıcı sınırları değiştiğinden önbelleği temizlemek için bunu çağırmak gerekiyor
        cinemachineConfiner.InvalidatePathCache();
    }
}
