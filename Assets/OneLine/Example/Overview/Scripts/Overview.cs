﻿using System.Collections;
using System;
using UnityEngine;

namespace OneLine.Examples {
    [CreateAssetMenu]
    public class Overview : ScriptableObject {

#region One Line
        [Separator("[ One Line Attribute ]")]
        [SerializeField, OneLine]
        private OneField oneField;
        [SerializeField, OneLine]
        private TwoFields twoFields;
        [SerializeField, OneLine]
        private ThreeFields threeFields;
        [SerializeField, OneLine]
        private ThreeFields[] arrayWithThreeFields;

        [Serializable]
        public class OneField {
            [SerializeField]
            private string first;
        }
        [Serializable]
        public class TwoFields {
            [SerializeField]
            private string first;
            [SerializeField]
            private string second;
        }
        [Serializable]
        public class ThreeFields {
            [SerializeField]
            private string first;
            [SerializeField]
            private string second;
            [SerializeField]
            private string third;
        }
#endregion

#region Weights
        [Separator("[ Weight Attribute ]")]
        [SerializeField, OneLine]
        private Weights1 differentWeights1;
        [SerializeField, OneLine]
        private Weights2 differentWeights2;
        [SerializeField, OneLine]
        private Weights2[] arrayWithDifferentWeights;

        [Serializable]
        public class Weights1 {
            [SerializeField, Weight(3)]
            private int first;
            [SerializeField, Weight(2)]
            private int second;
            [SerializeField, Weight(1)]
            private int third;
        }
        [Serializable]
        public class Weights2 {
            [SerializeField, Weight(5)]
            private int first;
            [SerializeField, Weight(1)]
            private int second;
        }
#endregion

#region Width
        [Separator("[ Width Attribute ]")]
        [SerializeField, OneLine]
        private WidthAndWeight fixedWidth;
        [SerializeField, OneLine]
        private WidthOnly onlyFixedWidth;
        [SerializeField, OneLine]
        private WidthOnly[] arrayWithOnlyFixedWidths;

        [Serializable]
        public class WidthOnly {
            [SerializeField, Width(50)]
            private string first;
            [SerializeField, Width(75)]
            private string second;
        }
        [Serializable]
        public class WidthAndWeight {
            [SerializeField, Width(50)]
            private string first;
            [SerializeField]
            private string second;
            [SerializeField, Width(75)]
            private string third;
        }
#endregion

#region Hide Label
        [Separator("[ Hide Label Attribute ]")]
        [SerializeField, OneLine, HideLabel]
        private OneField oneFieldHidesLabel;
        [SerializeField, OneLine, HideLabel]
        private TwoFields twoFieldsHidesLabel;
        [SerializeField, OneLine, HideLabel]
        private TwoFields[] arrayHidesLabels;
#endregion

#region Highlight
        [Separator("[ Highlight Attribute ]")]
        [SerializeField, OneLine, Highlight]
        private OneField highlightedZeroDepthField;
        [SerializeField, OneLine]
        private HighlightedFields highlightedFields;
        [SerializeField, OneLine]
        private HighlightedFields[] arrayWithHighlightedFields;

        [Serializable]
        public class HighlightedFields {
            [SerializeField, Highlight(0, 1, 0)]
            private string first;
            [SerializeField, Highlight(0, 0, 1)]
            private string second;
            [SerializeField]
            private string third;
            [SerializeField, Highlight(1, 1, 0)]
            private string fourth;
        }
#endregion

#region Arrays
        [Separator("Arrays, [Hide Buttons Attribute], [Array Length]")]
        [SerializeField, OneLine]
        private OneLineArray oneLineArray;
        [SerializeField, OneLine]
        private TwoArrays twoArraysInOneLine;
        [SerializeField, OneLine]
        private ArrayHidesButtons arrayHidesButtons;
        [SerializeField, OneLine]
        private ImmutableLengthArray arrayWithImmutableLength;
        [SerializeField, OneLine]
        private OneLineArray[] arrayWithArrays;

        [Serializable]
        public class OneLineArray {
            [SerializeField]
            private string[] array;
        }
        [Serializable]
        public class TwoArrays {
            [SerializeField, Highlight(1, 0, 0)]
            private int[] first;
            [SerializeField, Highlight(0, 1, 0), Width(50)]
            private string[] second;
        }
        [Serializable]
        public class ArrayHidesButtons {
            [SerializeField, HideButtons]
            private string[] array;
        }
        [Serializable]
        public class ImmutableLengthArray {
            [SerializeField, ArrayLength(3)]
            private string[] array;
        }
#endregion

    }
}