using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleCalculator
{
    float maxScale = 3.5f;
    float minScale = 1.2f;
    float ObstacleDamageValue = 0.7f;
    private LevelController levelController;

    public Vector3 CalculatePlayerHeadSize(GateType gateType, int gateValue, Transform headTransform)
    {
        float changeSize = gateValue / 100f;

        float newXScale = 0;
        float newYScale = 0;
        float newZScale = 0;

        switch (gateType)
        {
            case GateType.fatterType:
                newXScale = headTransform.localScale.x + changeSize;
                newYScale = headTransform.localScale.y + changeSize;
                newZScale = headTransform.localScale.z;

                if (newXScale > maxScale)
                {
                    newXScale = maxScale;
                }
                if (newYScale > maxScale)
                {
                    newYScale = maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.thinnerType:
                newXScale = headTransform.localScale.x - changeSize;
                newYScale = headTransform.localScale.y - changeSize;
                newZScale = headTransform.localScale.z;

                if (newXScale < minScale)
                {
                    newXScale = minScale;
                }
                if (newYScale < minScale)
                {
                    newYScale = minScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.tallerType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z + changeSize;

                if (newXScale > maxScale)
                {
                    newXScale = maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.shorterType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z - changeSize;

                if (newZScale < minScale)
                {
                    newZScale = minScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);
        }

        return new Vector3(newXScale, newYScale, newZScale);
    }

    public Vector3 DecreasePlayerHeadSize(Transform playerTransform)
    {
        float newXScale = playerTransform.localScale.x - ObstacleDamageValue;
        float newYScale = playerTransform.localScale.y - ObstacleDamageValue;
        float newZScale = playerTransform.localScale.z - ObstacleDamageValue;


        if (newXScale < minScale)
        {
            // newXScale = minScale;
            ReloadLevel();
        }
        if (newYScale < minScale)
        {
            //newYScale = minScale;
            ReloadLevel();
        }
        if (newZScale < minScale)
        {
           // newZScale = minScale;
            ReloadLevel();
        }

        return new Vector3(newXScale, newYScale, newZScale);
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
