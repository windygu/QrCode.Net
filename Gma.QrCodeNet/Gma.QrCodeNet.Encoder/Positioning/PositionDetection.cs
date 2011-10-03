﻿using com.google.zxing;

namespace Gma.QrCodeNet.Encoding.Positioning
{
    internal static class PositioninngPatternBuilder
    {

        private static readonly sbyte[][] s_PatternStamp = new[]
                                                                           {
                                                                               new sbyte [] {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                                               new sbyte[] {0, 1, 1, 1, 1, 1, 1, 1, 0},
                                                                               new sbyte[] {0, 1, 0, 0, 0, 0, 0, 1, 0},
                                                                               new sbyte[] {0, 1, 0, 1, 1, 1, 0, 1, 0},
                                                                               new sbyte[] {0, 1, 0, 1, 1, 1, 0, 1, 0},
                                                                               new sbyte[] {0, 1, 0, 1, 1, 1, 0, 1, 0},
                                                                               new sbyte[] {0, 1, 0, 0, 0, 0, 0, 1, 0},
                                                                               new sbyte[] {0, 1, 1, 1, 1, 1, 1, 1, 0},
                                                                               new sbyte[] {0, 0, 0, 0, 0, 0, 0, 0, 0}
                                                                           };



        private static readonly int[][] POSITION_DETECTION_PATTERN = new int[][]
                                                                         {
                                                                             new int[] { 1, 1, 1, 1, 1, 1, 1 }, 
                                                                             new int[] { 1, 0, 0, 0, 0, 0, 1 }, 
                                                                             new int[] { 1, 0, 1, 1, 1, 0, 1 }, 
                                                                             new int[] { 1, 0, 1, 1, 1, 0, 1 }, 
                                                                             new int[] { 1, 0, 1, 1, 1, 0, 1 }, 
                                                                             new int[] { 1, 0, 0, 0, 0, 0, 1 }, 
                                                                             new int[] { 1, 1, 1, 1, 1, 1, 1 }
                                                                         };

        private static readonly int[][] HORIZONTAL_SEPARATION_PATTERN = new int[][] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0 } };

        private static readonly int[][] VERTICAL_SEPARATION_PATTERN = new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 } };

        private static readonly int[][] POSITION_ADJUSTMENT_PATTERN = new int[][] { new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 1, 0, 1, 0, 1 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 1, 1, 1, 1, 1 } };

        private static readonly int[][] POSITION_ADJUSTMENT_PATTERN_COORDINATE_TABLE = new int[][] { new int[] { -1, -1, -1, -1, -1, -1, -1 }, new int[] { 6, 18, -1, -1, -1, -1, -1 }, new int[] { 6, 22, -1, -1, -1, -1, -1 }, new int[] { 6, 26, -1, -1, -1, -1, -1 }, new int[] { 6, 30, -1, -1, -1, -1, -1 }, new int[] { 6, 34, -1, -1, -1, -1, -1 }, new int[] { 6, 22, 38, -1, -1, -1, -1 }, new int[] { 6, 24, 42, -1, -1, -1, -1 }, new int[] { 6, 26, 46, -1, -1, -1, -1 }, new int[] { 6, 28, 50, -1, -1, -1, -1 }, new int[] { 6, 30, 54, -1, -1, -1, -1 }, new int[] { 6, 32, 58, -1, -1, -1, -1 }, new int[] { 6, 34, 62, -1, -1, -1, -1 }, new int[] { 6, 26, 46, 66, -1, -1, -1 }, new int[] { 6, 26, 48, 70, -1, -1, -1 }, new int[] { 6, 26, 50, 74, -1, -1, -1 }, new int[] { 6, 30, 54, 78, -1, -1, -1 }, new int[] { 6, 30, 56, 82, -1, -1, -1 }, new int[] { 6, 30, 58, 86, -1, -1, -1 }, new int[] { 6, 34, 62, 90, -1, -1, -1 }, new int[] { 6, 28, 50, 72, 94, -1, -1 }, new int[] { 6, 26, 50, 74, 98, -1, -1 }, new int[] { 6, 30, 54, 78, 102, -1, -1 }, new int[] { 6, 28, 54, 80, 106, -1, -1 }, new int[] { 6, 32, 58, 84, 110, -1, -1 }, new int[] { 6, 30, 58, 86, 114, -1, -1 }, new int[] { 6, 34, 62, 90, 118, -1, -1 }, new int[] { 6, 26, 50, 74, 98, 122, -1 }, new int[] { 6, 30, 54, 78, 102, 126, -1 }, new int[] { 6, 26, 52, 78, 104, 130, -1 }, new int[] { 6, 30, 56, 82, 108, 134, -1 }, new int[] { 6, 34, 60, 86, 112, 138, -1 }, new int[] { 6, 30, 58, 86, 114, 142, -1 }, new int[] { 6, 34, 62, 90, 118, 146, -1 }, new int[] { 6, 30, 54, 78, 102, 126, 150 }, new int[] { 6, 24, 50, 76, 102, 128, 154 }, new int[] { 6, 28, 54, 80, 106, 132, 158 }, new int[] { 6, 32, 58, 84, 110, 136, 162 }, new int[] { 6, 26, 54, 82, 110, 138, 166 }, new int[] { 6, 30, 58, 86, 114, 142, 170 } };

        // Embed basic patterns. On success, modify the matrix and return true.
        // The basic patterns are:
        // - Position detection patterns
        // - Timing patterns
        // - Dark dot at the left bottom corner
        // - Position adjustment patterns, if need be
        internal static void EmbedBasicPatterns(int version, TriStateMatrix matrix)
        {
            // Let's get started with embedding big squares at corners.
            embedPositionDetectionPatternsAndSeparators(matrix);
            // Then, embed the dark dot at the left bottom corner.
            embedDarkDotAtLeftBottomCorner(matrix);

            // Position adjustment patterns appear if version >= 2.
            maybeEmbedPositionAdjustmentPatterns(version, matrix);
            // Timing patterns should be embedded after position adj. patterns.
            embedTimingPatterns(matrix);
        }


        private static void embedTimingPatterns(TriStateMatrix matrix)
        {
            // -8 is for skipping position detection patterns (size 7), and two horizontal/vertical
            // separation patterns (size 1). Thus, 8 = 7 + 1.
            for (int i = 8; i < matrix.Width - 8; ++i)
            {   
                bool value = (sbyte)((i + 1) % 2)==1;
                // Horizontal line.
               
                if (!matrix.IsUsed(6, i))
                {
                    matrix.Set(6, i,value);
                }

                // Vertical line.
                if (!matrix.IsUsed(i, 6))
                {
                    matrix.Set(i, 6, value);
                }
            }
        }

        // Embed the lonely dark dot at left bottom corner. JISX0510:2004 (p.46)
        private static void embedDarkDotAtLeftBottomCorner(TriStateMatrix matrix)
        {
            matrix.Set(8, matrix.Width - 8, true);
        }

        private static void embedHorizontalSeparationPattern(int xStart, int yStart, TriStateMatrix matrix)
        {
            for (int x = 0; x < 8; ++x)
            {
                matrix.Set(yStart, xStart + x, (sbyte)HORIZONTAL_SEPARATION_PATTERN[0][x]==1);
            }
        }

        private static void embedVerticalSeparationPattern(int xStart, int yStart, TriStateMatrix matrix)
        {
            for (int y = 0; y < 7; ++y)
            {
                matrix.Set(yStart + y, xStart, (sbyte)VERTICAL_SEPARATION_PATTERN[y][0]==1);
            }
        }

        // Note that we cannot unify the function with embedPositionDetectionPattern() despite they are
        // almost identical, since we cannot write a function that takes 2D arrays in different sizes in
        // C/C++. We should live with the fact.
        private static void embedPositionAdjustmentPattern(int xStart, int yStart, TriStateMatrix matrix)
        {
            for (int y = 0; y < 5; ++y)
            {
                for (int x = 0; x < 5; ++x)
                {
                    matrix.Set(yStart + y, xStart + x, (sbyte)POSITION_ADJUSTMENT_PATTERN[y][x]==1);
                }
            }
        }

        private static void embedPositionDetectionPattern(int xStart, int yStart, TriStateMatrix matrix)
        {
            for (int y = 0; y < 7; ++y)
            {
                for (int x = 0; x < 7; ++x)
                {
                    matrix.Set(yStart + y, xStart + x, (sbyte)POSITION_DETECTION_PATTERN[y][x]==1);
                }
            }
        }

        // Embed position detection patterns and surrounding vertical/horizontal separators.
        private static void embedPositionDetectionPatternsAndSeparators(TriStateMatrix matrix)
        {
            // Embed three big squares at corners.
            int pdpWidth = POSITION_DETECTION_PATTERN[0].Length;
            // Left top corner.
            embedPositionDetectionPattern(0, 0, matrix);
            // Right top corner.
            embedPositionDetectionPattern(matrix.Width - pdpWidth, 0, matrix);
            // Left bottom corner.
            embedPositionDetectionPattern(0, matrix.Width - pdpWidth, matrix);

            // Embed horizontal separation patterns around the squares.
            int hspWidth = HORIZONTAL_SEPARATION_PATTERN[0].Length;
            // Left top corner.
            embedHorizontalSeparationPattern(0, hspWidth - 1, matrix);
            // Right top corner.
            embedHorizontalSeparationPattern(matrix.Width - hspWidth, hspWidth - 1, matrix);
            // Left bottom corner.
            embedHorizontalSeparationPattern(0, matrix.Width - hspWidth, matrix);

            // Embed vertical separation patterns around the squares.
            int vspSize = VERTICAL_SEPARATION_PATTERN.Length;
            // Left top corner.
            embedVerticalSeparationPattern(vspSize, 0, matrix);
            // Right top corner.
            embedVerticalSeparationPattern(matrix.Width - vspSize - 1, 0, matrix);
            // Left bottom corner.
            embedVerticalSeparationPattern(vspSize, matrix.Width - vspSize, matrix);
        }

        // Embed position adjustment patterns if need be.
        private static void maybeEmbedPositionAdjustmentPatterns(int version, TriStateMatrix matrix)
        {
            if (version < 2)
            {
                // The patterns appear if version >= 2
                return;
            }
            int index = version - 1;
            int[] coordinates = POSITION_ADJUSTMENT_PATTERN_COORDINATE_TABLE[index];
            int numCoordinates = POSITION_ADJUSTMENT_PATTERN_COORDINATE_TABLE[index].Length;
            for (int i = 0; i < numCoordinates; ++i)
            {
                for (int j = 0; j < numCoordinates; ++j)
                {
                    int y = coordinates[i];
                    int x = coordinates[j];
                    if (x == -1 || y == -1)
                    {
                        continue;
                    }
                    // If the cell is unset, we embed the position adjustment pattern here.
                    if (!matrix.IsUsed(y, x))
                    {
                        // -2 is necessary since the x/y coordinates point to the center of the pattern, not the
                        // left top corner.
                        embedPositionAdjustmentPattern(x - 2, y - 2, matrix);
                    }
                }
            }
        }
    }
}