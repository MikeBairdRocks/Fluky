using System.Collections.Generic;
using System.Globalization;
using Fluky.Extensions;

namespace Fluky
{
  public partial class Randomizer
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sentences"></param>
    /// <returns></returns>
    public string Paragraph(int? sentences = null)
    {
      sentences = sentences.HasValue ? sentences.Value : Natural(3, 7);
      var sentenceList = new List<string>();

      for (var i = 0; i < sentences; i++)
      {
        sentenceList.Add(Sentence());
      }

      return string.Join(" ", sentenceList.ToArray());
    }

    private string Syllable(int? length = null)
    {
      length = length ?? Natural(2, 3);
      var all = string.Format("{0}{1}", Constants.Consonants, Constants.Vowels);
      var text = "";
      var chr = '\0';

      // I'm sure there's a more elegant way to do this, but this works decently well.
      for (var i = 0; i < length; i++)
      {
        if (i == 0)
        {
          // First character can be anything
          chr = Character(pool: all);
        }
        else if (Constants.Consonants.IndexOf(chr.ToString(), System.StringComparison.Ordinal) == -1)
        {
          // Last character was a vowel, now we want a consonant
          chr = Character(pool: Constants.Consonants);
        }
        else
        {
          // Last character was a consonant, now we want a vowel
          chr = Character(pool: Constants.Vowels);
        }

        text += chr;
      }

      return text;
    }

    private string Sentence(int? words = null)
    {
      words = words.HasValue ? words : Natural(12, 18);
      var wordList = new List<string>();
      var text = "";
      for (var i = 0; i < words; i++)
      {
        wordList.Add(Word());
      }

      text = string.Join(" ", wordList.ToArray());

      // Capitalize first letter of sentence, add period at end
      text = string.Format("{0}{1}", text.Capitalize(), '.');

      return text;
    }

    private string Word(int? length = null, int? syllables = null)
    {
      syllables = syllables.HasValue ? syllables : Natural(1, 3);
      var text = "";

      if (length.HasValue)
      {
        // Either bound word by length
        do
        {
          text += Syllable();
        } while (text.Length < length.Value);
        text = text.Substring(0, length.Value);
      }
      else
      {
        // Or by number of syllables
        for (var i = 0; i < syllables; i++)
        {
          text += Syllable();
        }
      }

      return text;
    }
  }
}
