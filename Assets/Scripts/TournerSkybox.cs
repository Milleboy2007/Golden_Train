  using UnityEngine;
  
  public class TournerSkybox : MonoBehaviour
  {
      [SerializeField] private float vitesse = 0.5f;
      private float rotation;
  
      private void Update()
      {
          if (RenderSettings.skybox == null) return;
  
          rotation += vitesse * Time.deltaTime;
          RenderSettings.skybox.SetFloat("_Rotation", rotation);
      }
  }