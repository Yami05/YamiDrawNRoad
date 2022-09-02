using UnityEngine;

public class MaterialManager : Singleton<MaterialManager>
{
    public void SetColor(ColorType colorDecider, Material material)
    {

        switch (colorDecider)
        {
            case ColorType.Blue:
                material.color = Color.blue;
                break;
            case ColorType.Red:
                material.color = Color.red;
                break;

            default:
                break;
        }
    }
}
