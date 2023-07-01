﻿using UnityEngine;

namespace My.Football.Unity.Fields.Drawing
{
   [CreateAssetMenu(fileName = "Zone Style - ", menuName = "Field/Zone Style")]
   public class FieldZoneStyle : ScriptableObject
   {
      [SerializeField] private Material zoneLinesMaterial;
      [SerializeField] [Range( 0.1f, 0.5f )] private float zoneBoarderWidth = .3f;
      [SerializeField] [Range( 0.0f, 0.5f )] private float zoneDividerWidth = .2f;
      [SerializeField] private Color zoneBoarderColor = new Color( 0, 0, 0, .6f );
      [SerializeField] private Color zoneDividerColor = new Color( 0, 0, 0, .4f );

      public Material ZoneLinesMaterial => zoneLinesMaterial;
      public float ZoneBoarderWidth => zoneBoarderWidth;
      public float ZoneDividerWidth => zoneDividerWidth;
      public Color ZoneBoarderColor => zoneBoarderColor;
      public Color ZoneDividerColor => zoneDividerColor;
   }
}