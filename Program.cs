// the ourAnimals array will store the following: 
using System;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];


// create some initial ourAnimals array entries
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
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "?";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();

    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    //Console.WriteLine($"You selected menu option {menuSelection}.");
    //Console.WriteLine("Press the Enter key to continue");
    // pause code execution
    //readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            // List all of our current pet information
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
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
            bool validEntry = false;
            // get species (cat or dog) - string animalSpecies is a required field 
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

            // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
            animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
            // get the pet's age. can be ? at initial entry. 
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

            // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
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
            // get a description of the pet's personality - animalPersonalityDescription can be blank.
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

            // get the pet's nickname. animalNickname can be blank.
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

            // store the pet information in the ourAnimals array (zero based)
            ourAnimals[petCount, 0] = "ID #: " + animalID;
            ourAnimals[petCount, 1] = "Species: " + animalSpecies;
            ourAnimals[petCount, 2] = "Age: " + animalAge;
            ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
            ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

            while (anotherPet == "y" && petCount < maxPets)
            {
                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
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
                readResult = Console.ReadLine();
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "3":
            int newAge;
            string newPetDescription = "";

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    string id = ourAnimals[i, 0].Substring(5); // Extract ID from the string
                    string age = ourAnimals[i, 2].Substring(5); // Extract age from the string
                    string description = ourAnimals[i, 4].Substring(22); // Extract age from the 

                    while (age == "?" || string.IsNullOrEmpty(age))
                    {
                        bool validAgeEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter an age for ID #:{id} ");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                string ageInput = readResult.ToLower();
                                if (int.TryParse(ageInput, out newAge))
                                {
                                    validAgeEntry = true;
                                    age = Convert.ToString(newAge);
                                }
                                else { validAgeEntry = false; }
                            }
                        }
                        while (!validAgeEntry);
                    }

                    while (description == "?" || string.IsNullOrEmpty(description))
                    {
                        bool validDescriptionEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter a description for ID #:{id}" + " (size, color, breed, gender, weight, housebroken)");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                string input = readResult.ToLower();
                                validDescriptionEntry = true;
                                description = input;
                            }

                            else { validDescriptionEntry = false; }

                        }
                        while (!validDescriptionEntry);
                    }

                    ourAnimals[i, 2] = "Age: " + age;
                    ourAnimals[i, 4] = "Physical description: " + description;

                    if ((age != "?" && age != null) && (description != "?" && description != null))
                    {
                        Console.WriteLine("Age and physical description fields are complete for all of our friends.");
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":

            string newPersonalityDescription = "";
            string newNickName = "";

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    string id = ourAnimals[i, 0].Substring(5); // Extract ID from the string
                    string nickname = ourAnimals[i, 3].Substring(10); // extract Nickname
                    string personality = ourAnimals[i, 5].Substring(13); // extract personality

                    while (personality == "?" || string.IsNullOrEmpty(personality))
                    {
                        bool validPersonalityEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter a personality description for ID #:{id}" + " (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                string input = readResult.ToLower();
                                validPersonalityEntry = true;
                                personality = input;
                            }

                            else { validPersonalityEntry = false; }

                        }
                        while (!validPersonalityEntry);
                    }

                    while (nickname == "?" || string.IsNullOrEmpty(nickname))
                    {
                        bool validNickNameEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter a nickname for ID #:{id} ");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                string input = readResult.ToLower();
                                validNickNameEntry = true;
                                nickname = input;
                            }

                            else { validNickNameEntry = false; }

                        }
                        while (!validNickNameEntry);
                    }

                    ourAnimals[i, 3] = "Nickname: " + nickname;
                    ourAnimals[i, 5] = "Personality: " + personality;

                    if ((personality == "?" && personality != "") && (nickname == "?" || nickname != ""))
                    {
                        Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            //Console.WriteLine("Edit an animal’s age");
            string newAnimalAge = "";
            string animalId = "";
            bool validAnimalId = false;

            //user input for animalID that needs editing + validation for id format
            do
            {

                Console.WriteLine("Enter animal ID: ");
                readResult = Console.ReadLine();
                animalId = readResult;
                string animalNumber = animalId.Substring(1);
                int idNumber = 0;
                bool isValidAnimalNum = int.TryParse(animalNumber, out idNumber) && (idNumber > 0 && idNumber <= 8);

                if (animalId != null && animalId.Length == 2 && (animalId.Substring(0, 1).ToLower() == "d" || animalId.Substring(0, 1).ToLower() == "c") && animalId.Substring(1, 1).Length == 1 && animalId.Substring(1).Length == 1 && isValidAnimalNum == true)
                {
                    validAnimalId = true;

                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")

                        {
                            string id = ourAnimals[i, 0].Substring(5).Trim();
                            string age = ourAnimals[i, 2].Substring(5);
                            if (id != null && id == readResult)
                            {
                                int editedAge;
                                Console.WriteLine("Animal found! Enter new animal age: ");
                                readResult = Console.ReadLine();
                                if (readResult != null && Int32.TryParse(readResult, out editedAge))
                                {
                                    newAnimalAge = readResult;
                                }
                            }
                        }

                        ourAnimals[i, 2] = "Age: " + newAnimalAge;
                        break;
                    }
                }
                else { Console.WriteLine("Incorrect animal ID format"); }

            } while (!validAnimalId);

            Console.WriteLine($"Animal age for {animalId} has been successfully updated to {newAnimalAge}");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            Console.WriteLine("Edit an animal’s personality description");
            string newAnimalDescription = "";
            bool animalIdVerification = false;

            //user input for animalID that needs editing + validation for id format
            do
            {

                Console.WriteLine("Enter animal ID: ");
                readResult = Console.ReadLine();
                animalId = readResult;
                string animalNumber = animalId.Substring(1);
                int idNumber = 0;
                bool isValidAnimalNum = int.TryParse(animalNumber, out idNumber) && (idNumber > 0 && idNumber <= 8);

                if (animalId != null && animalId.Length == 2 && (animalId.Substring(0, 1).ToLower() == "d" || animalId.Substring(0, 1).ToLower() == "c") && animalId.Substring(1, 1).Length == 1 && animalId.Substring(1).Length == 1 && isValidAnimalNum == true)
                {
                    animalIdVerification = true;

                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")

                        {
                            string id = ourAnimals[i, 0].Substring(5).Trim();
                            string personality = ourAnimals[i, 5].Substring(13);

                            if (id != null && id == readResult)
                            {
                                Console.WriteLine($"Animal found! Old personality description is: {personality}");
                                Console.WriteLine("\nEnter new animal personality description: ");
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                {
                                    newAnimalDescription = readResult;
                                    ourAnimals[i, 5] = "Personality: " + newAnimalDescription;
                                    break;
                                }
                            }
                        }
                    }
                }
                else { Console.WriteLine("Incorrect animal ID format"); }

            } while (!animalIdVerification);

            Console.WriteLine($"Personality description for animal id {animalId} has been updated!");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            string menuSelectionCat = "";
            string characteristic = "";
            bool validEntryCats = false;

            do
            {
                Console.WriteLine("Select characteristic to search for: age, physical description, personality or nickname ");
                menuSelectionCat = Console.ReadLine().ToLower();


                if (menuSelectionCat != null && menuSelectionCat != "" && (menuSelectionCat == "age" || menuSelectionCat == "physical description" || menuSelectionCat == "personality" || menuSelectionCat == "nickname"))
                {
                    validEntryCats = true;
                    Console.WriteLine($"Enter pet {menuSelectionCat}");
                    characteristic = Console.ReadLine().ToLower();

                    for (int i = 0; i < maxPets; i++)
                    {
                        string[] idArray = ourAnimals[i, 0].Split(":");
                        string trimmedCatId = idArray[1].ToLower();
                        if (ourAnimals[i, 0] != "ID #: " && trimmedCatId.Contains("c"))
                        {
                            Console.WriteLine();

                            for (int j = 0; j < 6; j++)
                            {
                                string catId = ourAnimals[j, 0];
                                string[] parts = ourAnimals[i, j].Split(':');
                                string trimmed = parts[0].ToLower().Trim();

                                if (parts.Length == 2 && parts[0].ToLower().Trim().Contains(menuSelectionCat) && parts[1].ToLower().Contains(characteristic))
                                {
                                    Console.WriteLine($"The following animal match your search criteria :{catId}  {ourAnimals[i, j]}");
                                }
                            }
                        }
                    }
                }
                else { validEntryCats = false; Console.WriteLine("Invalid characteristic entry. Try again."); }

            }
            while (!validEntryCats);

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            string menuSelectionDog = "";
            string characteristicDog = "";
            bool validEntryDogs = false;

            do
            {
                Console.WriteLine("Select characteristic to search for: age, physical description, personality or nickname ");
                menuSelectionDog = Console.ReadLine().ToLower();


                if (menuSelectionDog != null && menuSelectionDog != "" && (menuSelectionDog == "age" || menuSelectionDog == "physical description" || menuSelectionDog == "personality" || menuSelectionDog == "nickname"))
                {
                    validEntryDogs = true;
                    Console.WriteLine($"Enter dog {menuSelectionDog}");
                    characteristicDog = Console.ReadLine().ToLower();

                    for (int i = 0; i < maxPets; i++)
                    {
                        string[] idArrayDog = ourAnimals[i, 0].Split(":");
                        string trimmedDogId = idArrayDog[1].ToLower();
                        if (ourAnimals[i, 0] != "ID #: " && trimmedDogId.Contains("d"))
                        {
                            Console.WriteLine();

                            for (int j = 0; j < 6; j++)
                            {
                                string dogId = ourAnimals[j, 0];
                                string[] parts = ourAnimals[i, j].Split(':');
                                string trimmed = parts[0].ToLower().Trim();

                                if (parts.Length == 2 && parts[0].ToLower().Trim().Contains(menuSelectionDog) && parts[1].ToLower().Contains(characteristicDog))
                                {
                                    Console.WriteLine($"The following animal match your search criteria :{dogId}  {ourAnimals[i, j]}");
                                }
                            }
                        }
                    }
                }
                else { validEntryDogs = false; Console.WriteLine("Invalid characteristic entry. Try again."); }

            }
            while (!validEntryDogs);

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;

    }

} while (menuSelection != "exit");




