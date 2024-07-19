using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Spawn edilecek objenin prefabı
    public List<GameObject> objectToSpawn = new List<GameObject>();
    
    // Spawn noktaları için belirli bir alan
    public Vector3 spawnArea;

    // Spawn zaman aralığı
    public float spawnInterval = 2f;

    private void Start()
    {
        // Spawn işlemini tekrarlı şekilde başlat
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        // Sonsuz döngü ile belirli aralıklarla obje spawn et
        while (true)
        {
            // Pozitif değerlerde rastgele bir pozisyon belirle
            Vector3 spawnPosition = new Vector3(
                Random.Range(transform.position.x, spawnArea.x),
                Random.Range(transform.position.y, spawnArea.y),
                Random.Range(transform.position.z, spawnArea.z)
            );

            // Yeni obje oluştur
            Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Count)], spawnPosition, Quaternion.Euler(0, 270, 0));

            // Belirli süre bekle
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Gizmos ile spawn alanını görünür hale getirelim
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + spawnArea / 2, spawnArea);
    }
}
