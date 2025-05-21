using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HexGridMeshGeneration))]
public class HexGridMeshGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        HexGridMeshGeneration hexGridMeshGeneration = (HexGridMeshGeneration)target;
        if (GUILayout.Button("Generate Hex Mesh")){
            hexGridMeshGeneration.CreateHexMesh();
        }

        if (GUILayout.Button("Clear Hex Mesh")){
            hexGridMeshGeneration.ClearHexGridMesh();
        }
    }
}
