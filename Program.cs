//Porter Rasmussen, 10/16/26, Lab 7 Pig Latin
Console.Clear();

Console.Write("What message do you want to put through the enigma machine? ");
string response = Console.ReadLine()!;
response = response.ToUpper();
char[] responseArray = response.ToCharArray();
int[] letterNumbers = new int[response.Length];

//Convert letters to numbers
for (int i = 0; i < responseArray.Length; i++)
{
    letterNumbers[i] = responseArray[i] - 'A';
}
//write letters
for (int i = 0; i < letterNumbers.Length; i++)
{
    Console.WriteLine(letterNumbers[i]);
}
//Make shifts
int shift1 = 0;
int shift2 = 0;
int shift3 = 0;

//pass letters through first rotor
string rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
for (int i = 0; i < responseArray.Length; i++)
{
    responseArray[i] = rotor1[(letterNumbers[i]+shift1)%26];
    letterNumbers[i] = responseArray[i] - 'A';
    Console.WriteLine($"{responseArray[i]} {letterNumbers[i]}");
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
Console.WriteLine();

//pass letters through second rotor
string rotor2 = "ZAQWSXCDERFVBGTYHNMJUIKLOP";
for (int i = 0; i < responseArray.Length; i++)
{
    responseArray[i] = rotor2[(letterNumbers[i]+shift2)%26];
    letterNumbers[i] = responseArray[i] - 'A';
    Console.WriteLine($"{responseArray[i]} {letterNumbers[i]}");
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
Console.WriteLine();

//pass letters through third rotor
string rotor3 = "ZAQWSXCDERFVBGTYHNMJUIKLOP";
for (int i = 0; i < responseArray.Length; i++)
{
    responseArray[i] = rotor3[(letterNumbers[i]+shift3)%26];
    letterNumbers[i] = responseArray[i] - 'A';
    Console.WriteLine($"{responseArray[i]} {letterNumbers[i]}");
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

Console.Write($"\nThe final message is ");
for (int i = 0; i < responseArray.Length; i++)
{
    Console.Write($"{responseArray[i]}");
}