using System.Linq;

using UnityEngine;

namespace My.Football.Unity.Fields
{
   /// <summary>
   /// The dimentions of the field.
   /// </summary>
   [CreateAssetMenu(fileName = "Field []", menuName = "Field/Field Config")]
   public class FieldConfig : ScriptableObject
   {
      [SerializeField] private int[] verticalZoneDepths;
      [SerializeField] private int[] horizontalZoneWidths;

      public int[] VerticalZoneDepths => verticalZoneDepths;
      public int[] HorizontalZoneWidths => horizontalZoneWidths;
      public int Length => verticalZoneDepths.Sum();
      public int Width => horizontalZoneWidths.Sum();
   }
}