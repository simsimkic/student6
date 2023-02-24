using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Utils
{
	public static class FuzzyMatcher
	{
		public static bool FuzzyMatch(string stringToSearch, string pattern)
		{
			var patternIdx = 0;
			var strIdx = 0;
			var patternLength = pattern.Length;
			var strLength = stringToSearch.Length;

			while (patternIdx != patternLength && strIdx != strLength)
			{
				if (char.ToLower(pattern[patternIdx]) == char.ToLower(stringToSearch[strIdx]))
					++patternIdx;
				++strIdx;
			}

			return patternLength != 0 && strLength != 0 && patternIdx == patternLength;
		}

		public static bool FuzzyMatch(string stringToSearch, string pattern, out int outScore)
		{
			const int adjacencyBonus = 5;               
			const int separatorBonus = 10;              
			const int camelBonus = 10;                  

			const int leadingLetterPenalty = -3;        
			const int maxLeadingLetterPenalty = -9;     
			const int unmatchedLetterPenalty = -1;      


			var score = 0;
			var patternIdx = 0;
			var patternLength = pattern.Length;
			var strIdx = 0;
			var strLength = stringToSearch.Length;
			var prevMatched = false;
			var prevLower = false;
			var prevSeparator = true;                   // true if first letter match gets separator bonus

			char? bestLetter = null;
			char? bestLower = null;
			int? bestLetterIdx = null;
			var bestLetterScore = 0;

			var matchedIndices = new List<int>();

			while (strIdx != strLength)
			{
				var patternChar = patternIdx != patternLength ? pattern[patternIdx] as char? : null;
				var strChar = stringToSearch[strIdx];

				var patternLower = patternChar != null ? char.ToLower((char)patternChar) as char? : null;
				var strLower = char.ToLower(strChar);
				var strUpper = char.ToUpper(strChar);

				var nextMatch = patternChar != null && patternLower == strLower;
				var rematch = bestLetter != null && bestLower == strLower;

				var advanced = nextMatch && bestLetter != null;
				var patternRepeat = bestLetter != null && patternChar != null && bestLower == patternLower;
				if (advanced || patternRepeat)
				{
					score += bestLetterScore;
					matchedIndices.Add((int)bestLetterIdx);
					bestLetter = null;
					bestLower = null;
					bestLetterIdx = null;
					bestLetterScore = 0;
				}

				if (nextMatch || rematch)
				{
					var newScore = 0;

					if (patternIdx == 0)
					{
						var penalty = Math.Max(strIdx * leadingLetterPenalty, maxLeadingLetterPenalty);
						score += penalty;
					}

					if (prevMatched)
						newScore += adjacencyBonus;

					if (prevSeparator)
						newScore += separatorBonus;

					if (prevLower && strChar == strUpper && strLower != strUpper)
						newScore += camelBonus;

					if (nextMatch)
						++patternIdx;

					if (newScore >= bestLetterScore)
					{
						if (bestLetter != null)
							score += unmatchedLetterPenalty;

						bestLetter = strChar;
						bestLower = char.ToLower((char)bestLetter);
						bestLetterIdx = strIdx;
						bestLetterScore = newScore;
					}

					prevMatched = true;
				}
				else
				{
					score += unmatchedLetterPenalty;
					prevMatched = false;
				}

				prevLower = strChar == strLower && strLower != strUpper;
				prevSeparator = strChar == '_' || strChar == ' ';

				++strIdx;
			}

			if (bestLetter != null)
			{
				score += bestLetterScore;
				matchedIndices.Add((int)bestLetterIdx);
			}

			outScore = score;
			return patternIdx == patternLength;
		}
	}
}
