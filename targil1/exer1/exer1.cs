// See https://aka.ms/new-console-template for more information

static bool MatchHelper(string input, string pattern, int inputIndex, int patternIndex)
{
    int inputLength = input.Length;
    int patterLength = pattern.Length;

    if (patternIndex == patterLength)
    {
        return inputIndex == inputLength;
    }

    bool firstMatch = (inputIndex < inputLength) && (pattern[patternIndex] == input[inputIndex] || pattern[patternIndex] == '.');

    if (patternIndex + 1 < patterLength && pattern[patternIndex + 1] == '*')  // Case 1: the pattern has a "*"
    {
        return (MatchHelper(input, pattern, inputIndex, patternIndex + 2) || (firstMatch && MatchHelper(input, pattern, inputIndex + 1, patternIndex)));
    }
    else  // Case 2: the pattern does not have a "*"
    {
        return firstMatch && MatchHelper(input, pattern, inputIndex + 1, patternIndex + 1);
    }
}
static bool Regex(string input, string pattern)
{
    return MatchHelper(input, pattern, 0, 0);
}


Console.WriteLine(Regex("aabc", "a*bc"));
