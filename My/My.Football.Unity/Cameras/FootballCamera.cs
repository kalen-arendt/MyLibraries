using System;

using My.Football.Unity.Fields;

using UnityEngine;

using MyField = My.Football.Unity.Fields.Field;

namespace My.Football.Unity.Cameras
{
   [RequireComponent(typeof(Camera))]
   [DisallowMultipleComponent]
   public class FootballCamera : MonoBehaviour
   {
      [SerializeField] [Range( 3, 5 )] private int border = 3;

      private new Camera camera;
      private float maxDist;

      private const int CAMERA_DEPTH = -10;


      private void Awake ()
      {
         camera = GetComponent<Camera>();
      }

      // Start is called before the first frame update
      private void Start ()
      {
         Setup();
      }

      private void Setup ()
      {
         FieldConfig config = MyField.FieldConfig ?? throw new Exception("Instance of Field must exist in scene for FootballCamera!");

         // set the Camera.size to fit the width of the field + border on either side
         // set the min/max position.y for Camera to keep it in bounds.
         maxDist = (config.Length / 2) + border - CalculateSize(config.Width);

         SetCameraPosition(-maxDist);
      }


      [ContextMenu("Resize")]
      private void CalculateFieldSize ()
      {
         MyField field = FindObjectOfType<MyField>();
         if (field == null)
         {
            return;
         }

         FieldConfig config = field.Config;
         var width = config.Width;

         camera = GetComponent<Camera>();
         CalculateSize(width);
      }


      //Camera.size => HEIGHT/2
      //we need to adjust the size for a certain WIDTH
      //aspect = width / height
      //[WIDTH / 2 + border] / aspect = Camera.size
      public float CalculateSize (float width)
      {
         var size = (int)(((width / 2) + border) / camera.aspect) + 1;
         camera.orthographicSize = size;
         return size;
      }


      public void SetCameraPosition (float y)
      {
         camera.transform.position
                  = new Vector3(0, Mathf.Clamp(y, -maxDist, maxDist), CAMERA_DEPTH);
      }
   }
}
