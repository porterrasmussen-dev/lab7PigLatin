//Porter Rasmussen, 10/16/26, Lab 7 Pig Latin
Console.Clear();

//Welcome
Console.WriteLine("Welcome to encryption headquarters!\nToday we are testing our latest technology: the ePIGma machine.");
Console.WriteLine("This machine first converts your message to pig latin, and then puts it through three rotors of the enigma machine.");
Console.Write("\nWhat message do you want to put through the ePIGma machine? ");

//Take Input
string input = Console.ReadLine()!;
input = input.ToUpper();
string[] pigArray = input.Split(' ');

//Change to Pig Latin
for (int i = 0; i < pigArray.Length; i++)
{
    int vowelPosition = -1;
    bool vowelFound = false;

    int j = 0;
    while (!vowelFound && j < pigArray[i].Length)
    {

        if (pigArray[i][j] == 'A'|| pigArray[i][j] == 'E'|| pigArray[i][j] == 'I'|| pigArray[i][j] == 'O'|| pigArray[i][j] == 'U')
        {
            vowelPosition = j;
            vowelFound = true;
        }
        j++;
    }
    int x = 0;
    while (x < vowelPosition)
    {
        char temp = pigArray[i][0];
        char[] letters = pigArray[i].ToCharArray();

        for (int y = 0; y < letters.Length - 1; y++)
        {
            letters[y] = letters[y + 1];
        }
        letters[letters.Length - 1] = temp;
        pigArray[i] = new string(letters);
        x++;
    }
    
    
}

for (int i = 0; i < pigArray.Length; i++)
{
    pigArray[i] = pigArray[i] + "AY";
}

string response = string.Join(' ', pigArray);
Console.WriteLine($"Your message in pig latin is {response}.");
Console.WriteLine();


//Encrypt through enigma

response = response.ToUpper();
char[] responseArray = response.ToCharArray();
int[] letterNumbers = new int[response.Length];

//Convert letters to numbers
for (int i = 0; i < responseArray.Length; i++)
{
    letterNumbers[i] = responseArray[i] - 'A';
}

//Make shifts
int shift1 = 0;
int shift2 = 0;
int shift3 = 0;

//pass letters through first rotor
string rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
for (int i = 0; i < responseArray.Length; i++)
{
    if (char.IsLetter(responseArray[i]))
    {
        responseArray[i] = rotor1[(letterNumbers[i]+shift1)%26];
        letterNumbers[i] = responseArray[i] - 'A';
        //Console.Write($"{responseArray[i]} {letterNumbers[i]}, ");
        shift1++;
        if (shift1 >= 21)
        {
            shift1=0;
            shift2++;
        }
        if (shift2 >= 16)
        {
            shift2=0;
            shift3++;
        }
        if (shift3 >= 26)
        {
            shift3=0;
        }
    }
}
Console.WriteLine();

//pass letters through second rotor
string rotor2 = "ZAQWSXCDERFVBGTYHNMJUIKLOP";
for (int i = 0; i < responseArray.Length; i++)
{
    if (char.IsLetter(responseArray[i]))
    {
        responseArray[i] = rotor2[(letterNumbers[i]+shift2)%26];
        letterNumbers[i] = responseArray[i] - 'A';
        //Console.Write($"{responseArray[i]} {letterNumbers[i]}, ");
        shift1++;
        if (shift1 >= 21)
        {
            shift1=0;
            shift2++;
        }
        if (shift2 >= 16)
        {
            shift2=0;
            shift3++;
        }
        if (shift3 >= 26)
        {
            shift3=0;
        }
    }
}
Console.WriteLine();

//pass letters through third rotor
string rotor3 = "ZAQWSXCDERFVBGTYHNMJUIKLOP";
for (int i = 0; i < responseArray.Length; i++)
{
    if (char.IsLetter(responseArray[i]))
    {
        responseArray[i] = rotor3[(letterNumbers[i]+shift3)%26];
        letterNumbers[i] = responseArray[i] - 'A';
        //Console.Write($"{responseArray[i]} {letterNumbers[i]}, ");
        shift1++;
        if (shift1 >= 21)
        {
            shift1=0;
            shift2++;
        }
        if (shift2 >= 16)
        {
            shift2=0;
            shift3++;
        }
        if (shift3 >= 26)
        {
            shift3=0;
        }
    }
}

/*
for (int i = 0; i<responseArray.Length; i++)
{
    if (i != 0)
    {
        responseArray[i] = responseArray[i].ToLower();
    }
}*/

string encryptedMessage = new string(responseArray);
Console.Write($"\nThe final message is {encryptedMessage}.");
