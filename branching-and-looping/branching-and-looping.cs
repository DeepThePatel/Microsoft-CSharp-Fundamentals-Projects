// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;
int petCount = 0;
string anotherPet = "y";
bool validEntry = false;
int petAge = 0;

// array of search animation icons
string[] searchingIcons = {"| ", "/ ", "--", @"\ "};

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

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
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "3";
            animalPhysicalDescription = "large tuxedo male, litter box trained";
            animalPersonalityDescription = "selfish and only child, loves to eat treats, easily scared";
            animalNickname = "Doj";
            suggestedDonation = "25.00";

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
    
    if (!decimal.TryParse(suggestedDonation, out decimalDonation)) {
        decimalDonation = 45.00m;
    }
    ourAnimals[i,6] = $"Suggested Donation: {decimalDonation:C2}";
}

// display the top-level menu options
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

    // use switch-case to process the selected menu option
    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            //
            // The ourAnimals array contains
            //    1. the species (cat or dog). a required field
            //    2. the ID number - for example C17
            //    3. the pet's age. can be blank at initial entry.
            //    4. the pet's nickname. can be blank.
            //    5. a description of the pet's physical appearance. can be blank.
            //    6. a description of the pet's personality. can be blank.

            anotherPet = "y";
            petCount = 0;
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
                            //Console.WriteLine($"You entered: {animalSpecies}.");
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


                // get a description of the pet's physical appearance - animalPhysicalDescription can be blank.
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
                } while (validEntry == false);


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
                } while (validEntry == false);


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
                } while (validEntry == false);

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

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
                //NOTE: The value of anotherPet (either "y" or "n") is evaluated in the while statement expression - at the top of the while loop
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("\n\rPress the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("The current pet's " + ourAnimals[i, 0]);


                    do {
                        Console.WriteLine("Enter an age for " + ourAnimals[i, 0]);
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(readResult)) {
                            animalAge = readResult;
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else {
                            validEntry = false;
                        }
                    } while (validEntry == false);

                    do {
                        Console.WriteLine("Enter a physical description for " + ourAnimals[i,0] + " (size, color, breed, gender, weight, housebroken)"); 
                        readResult = Console.ReadLine();
                        if(!string.IsNullOrWhiteSpace(readResult)) {
                            animalPhysicalDescription = readResult;
                            validEntry = true;
                        }
                        else {
                            validEntry = false;
                        }
                    } while (validEntry == false);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine("\n\rPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("The current pet's " + ourAnimals[i, 0]);


                    do {
                        Console.WriteLine("Enter a nickname for " + ourAnimals[i, 0]);
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(readResult)) {
                            animalNickname = readResult;
                            validEntry = true;
                        }
                        else {
                            validEntry = false;
                        }
                    } while (validEntry == false);

                    do {
                        Console.WriteLine("Enter a personality description for " + ourAnimals[i,0] + " (likes or dislikes, tricks, energy level)"); 
                        readResult = Console.ReadLine();
                        if(!string.IsNullOrWhiteSpace(readResult)) {
                            animalPhysicalDescription = readResult;
                            validEntry = true;
                        }
                        else {
                            validEntry = false;
                        }
                    } while (validEntry == false);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("\n\rPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Edit an animal’s age";
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("The current pet's " + ourAnimals[i, 0]);
                    Console.WriteLine("Current " + ourAnimals[i,2]);

                    do {
                        Console.WriteLine("Enter an updated age for " + ourAnimals[i, 0]);
                        readResult = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(readResult)) {
                            if (int.TryParse(readResult, out petAge)) {
                                ourAnimals[i,2] = petAge.ToString();
                                validEntry = true;
                            }
                        }
                        else {
                            validEntry = false;
                        }
                    } while (validEntry == false); 
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Edit an animal’s personality description");
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("The current pet's " + ourAnimals[i, 0]);
                    Console.WriteLine(ourAnimals[i,5]);

                    do {
                        Console.WriteLine("Enter the updated personality description for " + ourAnimals[i, 0]);

                        readResult = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(readResult)) {
                                ourAnimals[i,5] = readResult;
                                validEntry = true;
                        }
                        else {
                            validEntry = false;
                        }
                    } while (validEntry == false); 
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Display all dogs with a specified characteristic
            string catCharacteristic = "";
            int catCharacteristicsCount = 0;
            string [] searchCatCharacteristics = new string[catCharacteristicsCount];

            while(catCharacteristic == "") {
                Console.WriteLine($"\nEnter desired cat characteristics to search for separated by commas");
                readResult = Console.ReadLine();
                if (readResult != null) {
                    catCharacteristic = readResult.ToLower().Trim();
                    searchCatCharacteristics = catCharacteristic.Split(',');
                    Array.Sort(searchCatCharacteristics);
                    catCharacteristicsCount = searchCatCharacteristics.Length;
                }
            }

            string catDescription = "";
            bool noMatchesCat = true;

            // Loop through array to search for matching animals
            for (int i = 0; i < maxPets; i++) {
                if (ourAnimals[i, 1].Contains("cat"))
                {
                    catCharacteristicsCount = searchCatCharacteristics.Length - 1;

                    foreach (string searchChar in searchCatCharacteristics) {
                        // Search combined descriptions and report results
                        catDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5]; 
                        
                        for (int j = 5; j > -1 ; j--)
                        {
                        // #5 update "searching" message to show countdown 
                            foreach (string icon in searchingIcons)
                            {
                                Console.Write($"\rSearching our cat {ourAnimals[i, 3]} for {searchChar} {icon}  {catCharacteristicsCount}");    
                                Thread.Sleep(250);
                            }
                            
                            Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                        }
                        catCharacteristicsCount--;
                        // #3a iterate submitted characteristic terms and search description for each term
                        
                        if (catDescription.Contains(searchChar))
                        {
                            // #3b update message to reflect term 
                            // #3c set a flag "this dog" is a match
                            Console.WriteLine($"\nOur cat {ourAnimals[i, 3]} is a {searchChar} match!");

                            noMatchesCat = false;
                        }

                    }
                    if (noMatchesCat == false) {
                        Console.WriteLine($"{ourAnimals[i,3]} ({ourAnimals[i,0]})\n{ourAnimals[i,4]}\n{ourAnimals[i,5]}");
                    }                               
                }
            }

            if (noMatchesCat) {
                Console.WriteLine("None of our cats are a match for: " + catCharacteristic);
            }

            Console.WriteLine("\n\rPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            string dogCharacteristic = "";
            int dogCharacteristicsCount = 0;
            string [] searchCharacteristics = new string[dogCharacteristicsCount];

            while(dogCharacteristic == "") {
                Console.WriteLine($"\nEnter desired dog characteristics to search for separated by commas");
                readResult = Console.ReadLine();
                if (readResult != null) {
                    dogCharacteristic = readResult.ToLower().Trim();
                    searchCharacteristics = dogCharacteristic.Split(',');
                    Array.Sort(searchCharacteristics);
                    dogCharacteristicsCount = searchCharacteristics.Length;
                }
            }

            string dogDescription = "";
            bool noMatchesDog = true;

            // Loop through array to search for matching animals
            for (int i = 0; i < maxPets; i++)             {

                if (ourAnimals[i, 1].Contains("dog"))
                {
                    dogCharacteristicsCount = searchCharacteristics.Length - 1;

                    foreach (string searchChar in searchCharacteristics) {
                        // Search combined descriptions and report results
                        dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];
                        
                        
                        for (int j = 5; j > -1 ; j--)
                        {
                        // #5 update "searching" message to show countdown 
                            foreach (string icon in searchingIcons)
                            {
                                Console.Write($"\rSearching our dog {ourAnimals[i, 3]} for {searchChar} {icon}  {dogCharacteristicsCount}");    
                                Thread.Sleep(250);
                            }
                            
                            Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                        }
                        dogCharacteristicsCount--;
                        // #3a iterate submitted characteristic terms and search description for each term
                        
                        if (dogDescription.Contains(searchChar))
                        {
                            // #3b update message to reflect term 
                            // #3c set a flag "this dog" is a match
                            Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a {searchChar} match!");

                            noMatchesDog = false;
                        }

                    }
                    if (noMatchesDog == false) {
                        Console.WriteLine($"{ourAnimals[i,3]} ({ourAnimals[i,0]})\n{ourAnimals[i,4]}\n{ourAnimals[i,5]}");
                    }                               
                }
            }

            if (noMatchesDog) {
                Console.WriteLine("None of our dogs are a match for: " + dogCharacteristic);
            }

            Console.WriteLine("\n\rPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");
