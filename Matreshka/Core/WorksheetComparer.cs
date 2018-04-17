using System;

namespace Matreshka.Core
{
    public static class WorksheetComparer
    {
        public static bool Compare(Worksheet first, Worksheet second)
        {
            return first.Gender != second.Gender &&
                   Score(first.Desires, second.PersonalData) >= 0.5f &&
                   Score(second.Desires, first.PersonalData) >= 0.5f;
        }

        private static float Score(PersonalData origin, PersonalData other)
        {
            var score = 0;
            var maxScore = 0;

            ScoreFields(origin.BadHabbits, other.BadHabbits, ref score, ref maxScore);
            ScoreFields(origin.LoveChildren, other.LoveChildren, ref score, ref maxScore);
            ScoreFields(origin.Humor, other.Humor, ref score, ref maxScore);
            ScoreFields(origin.Kindness, other.Kindness, ref score, ref maxScore);
            ScoreFields(origin.Cookery, other.Cookery, ref score, ref maxScore);
            ScoreFields(origin.Jealousy, other.Jealousy, ref score, ref maxScore);
            ScoreFields(origin.HaveCar, other.HaveCar, ref score, ref maxScore);
            ScoreFields(origin.FixedIncome, other.FixedIncome, ref score, ref maxScore);
            ScoreFields(origin.EyeColor, other.EyeColor, ref score, ref maxScore);
            ScoreFields(origin.Growth, other.Growth, ref score, ref maxScore);
            if (maxScore == 0)
                return 1f;
            return (float)score / maxScore;
        }

        private static void ScoreFields(Growth first, Growth second, ref int score, ref int maxScore)
        {
            if(first == Growth.Other)
                return;
            maxScore += 1;
            switch (first)
            {
                case Growth.Little when (int)second <= 150:
                    score += 1;
                    break;
                case Growth.Small when 151 <= (int) second && (int) second <= 170:
                    score += 1;
                    break;
                case Growth.High when (int)second >= 171:
                    score += 1;
                    break;
            }

        }

        private static void ScoreFields(string first, string second, ref int score, ref int maxScore)
        {
            if(string.IsNullOrEmpty(first))
                return;
            maxScore += 1;
            if (string.Equals(first, second, StringComparison.CurrentCultureIgnoreCase))
                score += 1;
        }

        private static void ScoreFields(VarBool first, VarBool second, ref int score, ref int maxScore)
        {
            if(first == VarBool.None)
                return;
            maxScore += 1;
            if (first == second)
                score += 1;
        }

        private static void ScoreFields(EyeColor first, EyeColor second, ref int score, ref int maxScore)
        {
            if (first == EyeColor.Other)
                return;
            maxScore += 1;
            if (first == second)
                score += 1;
        }
    }
}