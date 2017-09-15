﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace OneLine {
    internal static class RectExtension {

        public static Rect WithBounds(this Rect rect, float bounds){
            return new Rect(
                x: rect.x - bounds,
                y: rect.y - bounds,
                width: rect.width + 2*bounds,
                height: rect.height + 2*bounds
            );
        }

        public static Rect WithBoundsH(this Rect rect, Vector2 bounds){
            return new Rect(
                x: rect.x - bounds.x,
                y: rect.y,
                width: rect.width + bounds.x + bounds.y,
                height: rect.height
            );
        }

        public static Rect[] CutFromBottom(this Rect rect, float height) {
            var left = new Rect(
                x: rect.x,
                y: rect.y,
                width: rect.width,
                height: rect.height - height
            );
            var right = new Rect(
                x: rect.x,
                y: rect.y + left.height,
                width: rect.width,
                height: height
            );
            return new Rect[]{left, right};
        }
        
        public static Rect[] CutFromTop(this Rect rect, float height) {
            var left = new Rect(
                x: rect.x,
                y: rect.y,
                width: rect.width,
                height: height
            );
            var right = new Rect(
                x: rect.x,
                y: rect.y + height,
                width: rect.width,
                height: rect.height + height
            );
            return new Rect[]{left, right};
        }
        
        public static Rect[] CutFromLeft(this Rect rect, float width) {
            var left = new Rect(
                x: rect.x,
                y: rect.y,
                width: width,
                height: rect.height
            );
            var right = new Rect(
                x: rect.x + width,
                y: rect.y,
                width: rect.width - width,
                height: rect.height
            );
            return new Rect[]{left, right};
        }

        public static Rect[] CutFromRight(this Rect rect, float width) {
            var left = new Rect(
                x: rect.x,
                y: rect.y,
                width: rect.width - width,
                height: rect.height
            );
            var right = new Rect(
                x: rect.x + left.width,
                y: rect.y,
                width: width,
                height: rect.height
            );
            return new Rect[]{left, right};
        }

        public static Rect[] SplitV(this Rect rect, int slices, float space = 5){
            var weights = Enumerable.Repeat(1f, slices).ToArray();
            return SplitV(rect, weights, null, space);
        }

        public static Rect[] SplitV(this Rect rect, IEnumerable<float> weights, IEnumerable<float> fixedWidthes = null, float space = 5){
            return rect.Invert()
                       .Split(weights, fixedWidthes, 5)
                       .Select(Invert)
                       .ToArray();
        }

        private static Rect Invert(this Rect rect){
            return new Rect(
                x: rect.y,
                y: rect.x,
                width: rect.height,
                height: rect.width
            );
        }
        
        public static Rect[] Split(this Rect rect, IEnumerable<float> weights, IEnumerable<float> fixedWidthes = null, float space = 5){
            if (fixedWidthes == null){
                fixedWidthes = weights.Select(x => 0f);
            }
            var cells = weights.Merge(fixedWidthes, (weight, width) => new Cell(weight, width));

            float weightUnit = GetWeightUnit(rect.width, cells, space);

            var result = new List<Rect>();
            float nextX = rect.x;
            foreach (var cell in cells) {
                result.Add(new Rect(
                               x: nextX,
                               y: rect.y,
                               width: cell.GetWidth(weightUnit),
                               height: rect.height
                           ));

                nextX += cell.HasWidth ? (cell.GetWidth(weightUnit) + space) : 0;
            }

            return result.ToArray();
        }

        private static float GetWeightUnit(float fullWidth, IEnumerable<Cell> cells, float space) {
            float result = 0;
            float weightsSum = cells.Sum(cell => cell.Weight);

            if (weightsSum > 0) {
                float fixedWidth = cells.Sum(cell => cell.FixedWidth);
                float spacesWidth = (cells.Count(cell => cell.HasWidth) - 1) * space;
                result = (fullWidth - fixedWidth - spacesWidth) / weightsSum;
            }

            return result;
        }

        private class Cell {
            public float Weight { get; private set; }
            public float FixedWidth { get; private set; }

            public Cell(float weight, float fixedWidth) {
                this.Weight = weight;
                this.FixedWidth = fixedWidth;

            }

            public bool HasWidth { get { return FixedWidth > 0 || Weight > 0; } }
            public float GetWidth(float weightUnit) {
                return FixedWidth + Weight * weightUnit;
            }
        }

    }
}
