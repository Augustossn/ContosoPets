using System;
using System.Reflection.PortableExecutable;
using System.Threading;

public class Program
{
    static void Main()
    {
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";
        string suggestedDonation = "";

        int maxPets = 8;
        string? readResult;
        string menuSelection = "";
        decimal decimalDonation = 0.00m;

        string[,] ourAnimals = new string[maxPets, 7];

        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    suggestedDonation = "85,00";
                    break;

                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "loki";
                    suggestedDonation = "49,99";
                    break;

                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "Puss";
                    suggestedDonation = "40,00";
                    break;

                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "?";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "tbd";
                    animalNickname = "tbd";
                    suggestedDonation = "";
                    break;

                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    suggestedDonation = "";
                    break;
            }
            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

            if (!decimal.TryParse(suggestedDonation, out decimalDonation))
            {
                decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
            }
            ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
        }

        Console.Clear();

        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages, nicknames, physical descriptions and personality descriptions are complete");
        Console.WriteLine(" 4. Edit an animal’s age");
        Console.WriteLine(" 5. Edit an animal’s personality description");
        Console.WriteLine(" 6. Display all cats with a specified characteristic");
        Console.WriteLine(" 7. Display all dogs with a specified characteristic");
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

        do
        {
            readResult = Console.ReadLine();
            menuSelection = readResult;

            switch (menuSelection)
            {
                case "1":
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 7; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    break;

                case "2":
                    string anotherPet = "y";
                    int petCount = 0;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            petCount += 1;
                        }
                    }

                    if (petCount < maxPets)
                    {
                        Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
                    }

                    while (anotherPet == "y" && petCount < maxPets)
                    {
                        bool validEntry = false;

                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalSpecies = readResult.ToLower();
                                if (animalSpecies != "dog" && animalSpecies != "cat")
                                {
                                    validEntry = false;
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        do
                        {
                            int petAge;
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult;
                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.ToLower();
                                if (animalPhysicalDescription == "")
                                {
                                    animalPhysicalDescription = "tbd";
                                }
                            }
                        } while (animalPhysicalDescription == "");

                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();
                                if (animalPersonalityDescription == "")
                                {
                                    animalPersonalityDescription = "tbd";
                                }
                            }
                        } while (animalPersonalityDescription == "");

                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();
                                if (animalNickname == "")
                                {
                                    animalNickname = "tbd";
                                }
                            }
                        } while (animalNickname == "");

                        ourAnimals[petCount, 0] = "ID #: " + animalID;
                        ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                        ourAnimals[petCount, 2] = "Age: " + animalAge;
                        ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                        ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                        ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                        petCount++;

                        if (petCount < maxPets)
                        {
                            Console.WriteLine("Do you want to enter info for another pet (y/n)");
                            do
                            {
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    anotherPet = readResult.ToLower();
                                }

                            } while (anotherPet != "y" && anotherPet != "n");
                        }
                    }

                    if (petCount >= maxPets)
                    {
                        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                        Console.WriteLine("Press the Enter key to continue.");
                        Console.ReadLine();
                    }

                    break;

                case "3":
                    bool allDataComplete = false;

                    for (int i = 0; i < maxPets; i++)
                    {
                        bool petDataComplete = true;
                        for (int j = 1; j < 6; j++)
                        {
                            
                            if (string.IsNullOrEmpty(ourAnimals[i, j].Split(":")[1].Trim()) || ourAnimals[i, j].Split(":")[1].Trim() == "tbd")
                            {
                                
                                petDataComplete = false;

                                switch (j)
                                {
                                    case 1:
                                        Console.WriteLine($"Enter the pet {i} species:");
                                        ourAnimals[i, j] = Console.ReadLine();
                                        break;
                                    case 2:
                                        int age;
                                        Console.WriteLine($"Enter the pet's {i} age:");
                                        while (!int.TryParse(Console.ReadLine(), out age))
                                        {
                                            Console.WriteLine("Invalid input. Please enter a valid age:");
                                        }
                                        ourAnimals[i, j] = age.ToString();
                                        break;
                                    case 3:
                                        Console.WriteLine($"Enter the pet's {i} nickname:");
                                        ourAnimals[i, j] = Console.ReadLine();
                                        break;
                                    case 4: 
                                        Console.WriteLine($"Enter the pet's {i} physical description:");
                                        ourAnimals[i, j] = Console.ReadLine();
                                        break;
                                    case 5:
                                        Console.WriteLine($"Enter the pet's {i} personality description:");
                                        ourAnimals[i, j] = Console.ReadLine();
                                        break;
                                }
                            }
                        }

                        if (!petDataComplete)
                        {
                            allDataComplete = false;
                        }
                    }

                    if (allDataComplete)
                    {
                        Console.WriteLine("All pets data requirements are met.");
                    }
                    else
                    {
                        Console.WriteLine("Some pet data was missing or incomplete and has been updated.");
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    break;

                case "4":
                    Console.WriteLine("Enter the ID of the pet you want to edit the age:");
                    string animalToEdit = Console.ReadLine();

                    bool found = false;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] == "ID #: " + animalToEdit)
                        {
                            found = true;
                            int newAge;
                            Console.WriteLine($"Enter the new age for {ourAnimals[i, 3].Substring(10)}:");
                            while (!int.TryParse(Console.ReadLine(), out newAge))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid age:");
                            }
                            ourAnimals[i, 2] = "Age: " + newAge;
                            Console.WriteLine("Age updated successfully.");
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Animal not found. Please try again with a valid ID.");
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    break;

                case "5":
                    Console.WriteLine("Enter the ID of the pet you want to edit the age:");
                    string animalToChange = Console.ReadLine();

                    bool locate = false;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] == "ID #: " + animalToChange)
                        {
                            locate = true;
                            Console.WriteLine($"Enter the new personality for {ourAnimals[i, 3].Substring(10)}:");
                            string newPersonality = Console.ReadLine();
                            while (string.IsNullOrEmpty(newPersonality))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid personality:");
                                newPersonality = Console.ReadLine();
                            }
                            ourAnimals[i, 5] = "Personality: " + newPersonality;
                            Console.WriteLine("Personality updated successfully.");
                        }
                    }

                    if (!locate)
                    {
                        Console.WriteLine("Animal not found. Please try again with a valid ID.");
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    break;

                case "6":
                    string characteristic = "";
                    bool catFound = false;

                    while (characteristic == "")
                    {
                        Console.WriteLine($"Enter cat characteristics to search for separated by commas");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            characteristic = readResult.ToLower();
                            Console.WriteLine();
                        }
                    }

                    string[] searches = characteristic.Split(",");

                    for (int i = 0; i < searches.Length; i++)
                    {
                        searches[i] = searches[i].Trim();
                    }

                    string[] searchingIcon = { ". ", ".. ", "..." };
                    string descriptions = "";


                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0].StartsWith("ID #: ") && ourAnimals[i, 1].Contains("cat"))
                        {
                            descriptions = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                            bool currentCat = false;

                            foreach (string term in searches)
                            {
                                if (term != null && term.Trim() != "")
                                {
                                    for (int j = 2; j > -1; j--)
                                    {
                                        foreach (string icon in searchingIcon)
                                        {
                                            Console.Write($"\rsearching our cat {ourAnimals[i, 3]} for {term.Trim()} {icon} \t{j.ToString()}");
                                            Thread.Sleep(100);                                       }

                                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                                    }

                                    if (descriptions.Contains(" " + term.Trim() + " "))
                                    {

                                        Console.WriteLine($"\rOur cat {ourAnimals[i, 3]} matches your search for {term.Trim()}");

                                        currentCat = true;
                                        catFound = true;

                                        if (currentCat)
                                        {
                                            Console.WriteLine($"\r{ourAnimals[i, 3]} ({ourAnimals[i, 0]})\n{descriptions}\n");
                                        }
                                    }

                                }
                            }
                        }
                    }
                    if (!catFound)
                    {
                        Console.WriteLine($"No cats found with the characteristic: {characteristic}.");
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    break;

                case "7":
                    string characteristics = "";
                    bool dogFound = false;

                    while (characteristics == "")
                    {
                        Console.WriteLine($"Enter dog characteristics to search for separated by commas");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            characteristics = readResult.ToLower();
                            Console.WriteLine();
                        }
                    }

                    string[] search = characteristics.Split(",");

                    for (int i = 0; i < search.Length; i++)
                    {
                        search[i] = search[i].Trim();
                    }

                    string[] searchingIcons = { ". ", ".. ", "..." };
                    string description = "";


                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0].StartsWith("ID #: ") && ourAnimals[i, 1].Contains("dog"))
                        {
                            description = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                            bool currentDog = false;

                            foreach (string term in search)
                            {
                                if (term != null && term.Trim() != "")
                                {
                                    for (int j = 2; j > -1; j--)
                                    {
                                        foreach (string icon in searchingIcons)
                                        {
                                            Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {term.Trim()} {icon} {j.ToString()}");
                                            Thread.Sleep(100);
                                        }

                                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                                    }

                                    if (description.Contains(" " + term.Trim() + " "))
                                    {

                                        Console.WriteLine($"\rOur dog {ourAnimals[i, 3]} matches your search for {term.Trim()}");

                                        currentDog = true;
                                        dogFound = true;

                                        if (currentDog)
                                        {
                                            Console.WriteLine($"\r{ourAnimals[i, 3]} ({ourAnimals[i, 0]})\n{description}\n");
                                        }
                                    }

                                }
                            }
                        }
                    }
                    if (!dogFound)
                    {
                        Console.WriteLine($"No dogs found with the characteristic: {characteristics}.");
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    break;

                case "exit":
                    break;

                default:
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    break;

            }

        } while (menuSelection != "exit");

    }
}
