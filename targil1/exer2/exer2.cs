// See https://aka.ms/new-console-template for more information

static int GetMaxCharIndex(string str)
{
    int maxIndex = 0;
    char maxChar = str[0];

    for (int i = 1; i < str.Length; i++)
    {
        if (str[i] > maxChar)
        {
            maxIndex = i;
            maxChar = str[i];
        }
    }

    return maxIndex;
}

static string SmallestString(string inputString, int k)
{
    string newString = inputString;

    while (String.Compare(inputString, newString) != -1)
    {
        inputString = newString;
        int maxCharIndex = GetMaxCharIndex(newString.Substring(0, k));
        newString += newString[maxCharIndex];
        newString = newString.Remove(maxCharIndex, 1);
    }

    return inputString;
}


Console.WriteLine(SmallestString("baaca", 3)); 