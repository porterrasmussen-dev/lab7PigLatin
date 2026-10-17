//Porter Rasmussen, 10/16/26, Lab 7 Pig Latin
Console.Clear();

//Welcome
Console.WriteLine("Welcome to encryption headquarters!\nToday we are testing our latest technology: the ePIGma machine.");
Console.WriteLine("This machine first converts your message to pig latin, and then puts it through the enigma machine.");
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

//Make rotors
string baseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
string rotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
string rotor3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
string backwardsRotor1 = "UWYGADFPVZBECKMTHXSLRINQOJ";
string backwardsRotor2 = "AJPCZWRLFBDKOTYUQGENHXMIVS";
string backwardsRotor3 = "TAGBPCSDQEUFVNZHYIXJWLRKOM";

//Make shifts
int shift1 = 0;
int shift2 = 0;
int shift3 = 0;

//Make stepping mechanism
bool timeToShift1 = shift1 == 16;
bool timeToShift2 = shift2 == 4;

//Put message through rotors
for (int i = 0; i < responseArray.Length; i++)
{
    if (char.IsLetter(responseArray[i]))
    {
        //Shifting
        if (timeToShift2) shift3 = (shift3 +1)%26;
        if (timeToShift2||timeToShift1) shift2 = (shift2 +1)%26;
        shift1 = (shift1 +1)%26;

        //Encrypting
        responseArray[i] = baseAlphabet[(rotor1[(letterNumbers[i] + shift1) % 26] - 'A' - shift1 + 26) % 26];
        letterNumbers[i] = responseArray[i] - 'A';

        responseArray[i] = baseAlphabet[(rotor2[(letterNumbers[i] + shift2) % 26] - 'A' - shift2 + 26) % 26];;
        letterNumbers[i] = responseArray[i] - 'A';

        responseArray[i] = baseAlphabet[(rotor3[(letterNumbers[i] + shift3) % 26] - 'A' - shift3 + 26) % 26];
        letterNumbers[i] = responseArray[i] - 'A';

        responseArray[i] = reflector[letterNumbers[i]];
        letterNumbers[i] = responseArray[i] - 'A';

        responseArray[i] = baseAlphabet[(backwardsRotor3[(letterNumbers[i] + shift3) % 26] - 'A' - shift3 + 26) % 26];
        letterNumbers[i] = responseArray[i] - 'A';

        responseArray[i] = baseAlphabet[(backwardsRotor2[(letterNumbers[i] + shift2) % 26] - 'A' - shift2 + 26) % 26];
        letterNumbers[i] = responseArray[i] - 'A';

        responseArray[i] = baseAlphabet[(backwardsRotor1[(letterNumbers[i] + shift1) % 26] - 'A' - shift1 + 26) % 26];
        letterNumbers[i] = responseArray[i] - 'A';
    }
}



string encryptedMessage = new string(responseArray);
encryptedMessage = encryptedMessage[0] + encryptedMessage.Substring(1).ToLower();
Console.Write($"\nThe final message is {encryptedMessage}.");
