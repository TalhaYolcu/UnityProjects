
using UnityEngine;
using System;
using System.Collections;


public class ReadScript : MonoBehaviour
{

    public GameObject prefab;
    public Texture myTexture;
    public Material myMaterial;

    // Start is called before the first frame update
    void Start(){   
        /*
        1-Obje oluştur
        2-Obje verdiğin obj dosyasını kullansın
        3-Material oluştur, textureları material a at
        4-Objeye material ata
        */

        //create game object
        GameObject clone=(GameObject)Instantiate(Resources.Load("Chair"));   

        //get texture
        myTexture=(Texture)Resources.Load("Chair_diffuse");
        
        //get material
        myMaterial=(Material)Resources.Load("red");

        //give texture to the material
        myMaterial.mainTexture = myTexture;

        clone.AddComponent<MeshRenderer>();
        clone.GetComponent<MeshRenderer>().material=myMaterial;

        //apply material to the all childs
        Renderer[] children;
        children = clone.GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in children){
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++){
                mats[j] = myMaterial;
            }
            rend.materials = mats;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
