using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoad : MonoBehaviour
{
    //public string AssetName = "AssetBundleData/asset_pack01"; //LW
    public string AssetName = "AssetBundleData/my_assetdata"; //BB2

    //public string[] ObjectNames = new string[] { "TomatoPrefab", "ParticleSystemPrefab", "FirePrefab" }; //LW //ここをロードするアセットごとに変える
    public string[] ObjectNames = new string[] { "ExplodePrefab", "FlashPrefab", "TrailPrefab", "BulletFlashSmallPrefab" }; //BB2

    void Start()
    {
        // アセットバンドルのロード
        AssetBundle ab = AssetBundle.LoadFromFile(AssetName);

        if (ab == null)
        {
            // ロード失敗
            Debug.LogError("error : load bundle " + AssetName);
        }
        else
        {
            // ロード成功
            Debug.Log("success : load bundle " + AssetName);

            // Prefabのロード
            
            GameObject prefab;
            foreach (string name in ObjectNames)
            {
                prefab = ab.LoadAsset<GameObject>(name);
                if (prefab == null)
                {
                    // Prefabのロード失敗
                    Debug.LogError("error : load asset " + name);
                }
                else
                {
                    // Prefabのロード成功
                    // Prefabをインスタンス化
                    Instantiate(prefab);
                }
            }
            
            // マテリアルのロード
            /*
            Material mat;
            foreach (string name in ObjectNames)
            {
                mat = ab.LoadAsset<Material>(name);
                if (mat == null)
                {
                    // マテリアルのロード失敗
                    Debug.LogError("error : load asset " + name);
                }
                else
                {
                    // マテリアルのロード成功
                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.GetComponent<MeshRenderer>().material = mat;
                }
            }
            */
        }
    }
}