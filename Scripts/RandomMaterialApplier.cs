using UnityEngine;

public class RandomMaterialApplier : MonoBehaviour
{
    public Material[] materials;

    void Start()
    {
        ApplyRandomMaterial();
    }

    void ApplyRandomMaterial()
    {
        if (materials != null && materials.Length > 0)
        {
            Renderer renderer = GetComponent<Renderer>();

            if (renderer != null)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                renderer.material = randomMaterial;
                Debug.Log("Material applied successfully: " + randomMaterial.name);
            }
            else
            {
                Debug.LogError("Renderer component not found on the object!");
            }
        }
        else
        {
            Debug.LogError("Materials array is null or empty!");
        }
    }
}