using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenEvents : MonoBehaviour
{
    CameraController cameraController;
    private void Awake()
    {
        cameraController = GetComponent<CameraController>();
    }

    public void Meet(string who)
    {
        switch (who)
        {
            case "smith":
                Smith();
                break;
            case "trainer":
                Trainer();
                break;
            case "coachman":
                Coachman();
                break;
            case "barman":
                Barman();
                break;
            case "armorer":
                Armorer();
                break;

        }
    }

    private void Smith()
    {
        StartCoroutine(cameraController.DownToCharacter("smith"));
        Debug.Log("Меня зовут Кузнец");

    }

    private void Trainer()
    {
        Debug.Log("Меня зовут Тренер");
    }

    private void Coachman()
    {
        Debug.Log("Меня зовут Шафер");
    }

    private void Barman()
    {
        Debug.Log("Меня зовут Бармен");
    }

    private void Armorer()
    {
        StartCoroutine(cameraController.DownToCharacter("armorer"));
        Debug.Log("Меня зовут Бронник");
    }

}
