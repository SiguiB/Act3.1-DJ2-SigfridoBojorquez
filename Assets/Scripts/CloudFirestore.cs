using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;
using TMPro;

public class CloudFirestore: MonoBehaviour
{
    FirebaseFirestore db;
    Dictionary <string, object> user;
    [SerializeField] TextMeshProUGUI puntosField;
    [SerializeField] Button submitButton;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    public void guardardata()
    {
         submitButton.onClick.AddListener(() =>
        {
            user = new Dictionary <string, object>
        {
            {"Puntos",puntosField.text}
        };

        db.Collection("Usuario").Document("Puntaje Total").SetAsync(user).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Guardado correcto");
            }
            else
            {
                Debug.Log("Hubo un error");
            }
        });
        });
    }
}