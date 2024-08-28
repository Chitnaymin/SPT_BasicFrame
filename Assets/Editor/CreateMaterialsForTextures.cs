using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

public class CreateMaterialsForTextures : ScriptableWizard
{
    public Shader shader;

    [MenuItem("Tools/CreateMaterialsForTextures")]
    static void CreateURPUnlitShaderForTextures()
    {
        try
        {
            AssetDatabase.StartAssetEditing();
            var textures = Selection.GetFiltered(typeof(Texture), SelectionMode.Assets).Cast<Texture>();
            foreach (var tex in textures)
            {
                string path = "Assets/Materials/"+tex.name+".mat";
                path = path.Substring(0, path.LastIndexOf(".")) + ".mat";
                if (AssetDatabase.LoadAssetAtPath(path, typeof(Material)) != null)
                {
                    Debug.LogWarning("Can't create material, it already exists: " + path);
                    continue;
                }
                var mat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                mat.mainTexture = tex;
                mat.SetTexture(Shader.PropertyToID("_BaseMap"), tex);
                
                AssetDatabase.CreateAsset(mat, path);
            }
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
            AssetDatabase.SaveAssets();
        }
    }
}