using UnityEngine;

namespace My.Football.Unity.Fields.Drawing
{
   // the style of the field, including color scheme and grass sprite
   [CreateAssetMenu(fileName = "Field Style - ", menuName = "Field/Field Style")]
   public class FieldStyle : ScriptableObject
   {
      [SerializeField] private Color bkgGrassColor = new Color(0, 0.46875f, 0.24f, 1);
      [SerializeField] private Color grassColor = new Color( 0, 0.703125f, 0, 1 );
      [SerializeField] private Color lineColor = Color.black;
      [SerializeField] private Color netColor = Color.white;

      [SerializeField] private float lineWidth = 0.3f;

      [SerializeField]
      private Color[]
         wZoneColors = new Color[2] {
            new Color(.5f, .5f,.5f,.15f),
            new Color(0, 0, 0, .2f)
         },
         dZoneColors = new Color[2] {
            new Color( 0, 0, 0, .2f ),
            new Color( 1, 1, 1, .1f ),
         };


      public Color BackgroundGrassColor => bkgGrassColor;
      public Color GrassColor => grassColor;

      public Color LineColor => lineColor;
      public Color NetColor => netColor;

      public float LineWidth => lineWidth;


      public Color[] WZoneColors => wZoneColors;
      public Color[] DZoneColors => dZoneColors;
   }
}