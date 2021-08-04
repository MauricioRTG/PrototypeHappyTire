using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float TilesSpawned = 0;
    public float tileLengthZ = -6;
    public float tileLengthY = -3;
    public int InitialNumberOfTiles = 3;//Este se tiene que cambiar manualmente.
    private Queue<GameObject> activeTiles = new Queue<GameObject>();
    //private List<GameObject> activeTiles = new List<GameObject>();
    //Que se reutilice las instancias. <---ToDO
    public Transform playerTransform;
    void Start()
    {
        for (int i = 0; i < InitialNumberOfTiles; i++)
        {
              GameObject NewTile = Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(0f,tileLengthY,tileLengthZ) * TilesSpawned, Quaternion.identity);
              //Se guarda en una cola la instancia para poder borrarla despues.
              activeTiles.Enqueue(NewTile);
              TilesSpawned ++; //Lleva el conteo de cuantos elementos o tiles se han generado (se puede multiplicar por tileLenghtZ, para saber cual el el tamaño total de la rampa generada)
        }      
    }

    void Update()
    {
       //Detecta cuando la rueda ya paso un elemento y lo borra para no desperdiciar memoria.
       //el -50 controla que tan rapido se borra, pero es dependiente del numero de elementos (tiles) que eligas generar. Si son 3 un buen numero es -30, pero se tiene que ajustar la camara para que no sea vea como aparece y desaparece.
        if(playerTransform.position.z - 50 < TilesSpawned*tileLengthZ + (InitialNumberOfTiles*tileLengthZ)){
                //Genera un nuevo elemento y lo posiciona enfrente del elemento ya creado.
                GameObject NewTile2 = Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)], new Vector3(0f,tileLengthY,tileLengthZ) * TilesSpawned, Quaternion.identity);
                activeTiles.Enqueue(NewTile2); 
                TilesSpawned++;
                GameObject OldTile = activeTiles.Dequeue();
                Destroy(OldTile);
        }
         
    }

}
