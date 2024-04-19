User Guide for “Trivia Master Challenge: Test Your Knowledge!” 

Developed by Volodymyr Ruzhak 

 

Table of Content 

1. Getting Started 

Downloading and Installing the Game 

Launching the Game 

2. Playing the Game 

Main Screen Guide for Trivia Master Challenge 

Gameplay Mechanics for Trivia Master Challenge 

Winning Screen Overview 

Accessing the Admin Page 

Logging into the Admin Panel 

Managing Questions Screen 

Exiting the Game 

DATABASE QUESTIONS 

 

 

 

Getting Started 

Downloading and Installing the Game: 

Download Microsoft SQL Server Management Studio and install it. 

Set up a new database and name it TriviaDB. 

Set up a new table and name it dbo.Trivia_Table. 

Add three columns: Column Name, Data Type, and Allow Nulls. 

Add eight rows and add this data types for each: QuestionID -> int, Question -> nchar(100), AnswerOne -> nchar(70), AnswerTwo -> nchar(70), AnswerThree -> nchar(70), AnswerFour -> nchar(70), CorrectAnswer -> nchar(70), and DeleteQuestion -> bit. 

All Allow Nulls must be deselected! 

After all previous steps completed insert TABLE values using query (create new query) INSERT INTO dbo.Trivia_Table(see table at the end of this document) 

Download Visual Studio 2022 and install it. 

After installation is completed, open Visual Studio. 

Choose option -> Clone a repository. 

Use this to clone it -> https://github.com/MetalJames/Trivia_Master_Challenge_Test_Your_Knowledge.git 

After cloning is completed go to tab “Tools” -> “Connect to Database” -> select -> “Microsoft SQL Server (SqlClient)” from “Data Source” -> in the “Server Name” enter your database server name (example - DESKTOP-RDHALNI- usually it's the name of your computer) -> click “OK” button. 

Launching the Game: 

Run game in Visual Studio by pressing green button next to the name of the game. 

 

Playing the Game 


1. Main Screen Guide for Trivia Master Challenge 


Overview 

The main screen of the Trivia Master Challenge is your starting point to dive into a fun and interactive quiz experience. You can choose to play a solo game or compete with a friend in multiplayer mode. 

Options and Features 

Game Mode Selection: 

Solo/Multiplayer: To toggle between solo and multiplayer modes, simply check the "Multiplayer" checkbox. 

Name Entry: Both players can use the default names ("Player 1" and "Player 2") or enter their desired names in the provided text boxes. In multiplayer mode, ensure that "Player 2 Name" is enabled by checking the "Multiplayer" box. 

Question Selection: 

Number of Questions: Players can select how many questions they wish to tackle during the game by choosing from the drop-down menu options, either 5 or 10 questions. 

Administrative Access: 

Manage Questions: If you are an admin, you can access the Manage Questions screen by clicking the "Manage Questions" button located at the top right of the main screen. This feature allows you to edit, add, or delete questions, ensuring the quiz content is up-to-date and challenging. 

Starting the Game: 

Start Button: Once you've set up your game preferences, click the "Start the Game" button located at the bottom center of the screen. This will launch the quiz based on your selected options, and the trivia challenge begins! 

 

2. Gameplay Mechanics for Trivia Master Challenge 


Overview 

The gameplay mechanics in Trivia Master Challenge are designed to provide both solo and multiplayer experiences with intuitive controls and engaging feedback. Here's how you can navigate through the game: 

 

Solo Gameplay 

Answering Questions: In solo mode, simply select your answer from the given choices for each question and press the "Submit" button. 

Feedback: After submitting your answer, a prompt will inform you whether your response was correct or not. Your score will be updated accordingly, allowing you to track your progress throughout the game. 

Game Progress: Continue answering the questions until you have responded to all in the quiz. The game will track your correct answers and provide a final score at the end. 

Multiplayer Gameplay 

Screen Division: In multiplayer mode, the game screen is divided into two sections, each displaying unique questions for the respective player. This setup ensures that each player faces a distinct set of challenges, unknown to their opponent. 

Answer Submission: Players answer their questions independently. The game interface is designed to keep the gameplay for each player separate and simultaneous. 

End of Game: Each player proceeds through their question set at their own pace. The first player to finish all their questions will receive a message indicating that there are no more questions left for them. The second player can continue to answer their remaining questions. 

Winning Screen: Once both players have completed their questions, they will be directed to the winning screen which displays the final scores and declares the winner based on who scored higher or, in some settings, who answered all questions the fastest. 

This interactive and competitive setup ensures that players remain engaged and challenged, making Trivia Master Challenge an enjoyable game for solo players and groups alike. Enjoy testing your knowledge and competing with friends! 


3. Winning Screen Overview


Celebrating the Winner 

At the conclusion of each game session in Trivia Master Challenge, players are directed to the Winning Screen. This vibrant display serves as the culmination of your trivia contest, announcing the results in a celebratory format. 

Key Features of the Winning Screen: 

Winner Announcement: The screen will proudly display the name of the winner or announce "It Is a Tie" in cases where the scores are equal, ensuring that every game ends with clear and exciting results. 

Score Display: All scores are prominently displayed, allowing players to see how they performed relative to their opponent(s). This is an excellent way for players to reflect on the game and assess their trivia skills. 

Options for Next Steps: 

Replay the Game: Players are given the option to start a new game immediately, which is perfect for those looking to have a rematch or simply continue the fun without interruption. 

Return to Main Menu: For those wishing to modify game settings, switch players, or take a break, the option to return to the main menu provides a seamless transition back to the initial game setup screen. 

This engaging and interactive Winning Screen ensures that each game ends on a high note, whether you’re celebrating a victory, contemplating a near win, or planning your next round of trivia challenges. 

 

4. Accessing the Admin Page 


Navigating to the Admin Screen 

For administrators looking to manage the game's content, accessing the Admin Page is a straightforward process: 

Manage Questions Button: Located prominently on the Main Screen, the "Manage Questions" button is your gateway to the Admin Page. Simply click this button to transition from player mode to administrator mode. 

This quick and easy access allows game administrators to efficiently update, add, or remove trivia questions, ensuring the game remains engaging and up-to-date for all players. 

 

5. Logging into the Admin Panel 


Accessing the Login Screen 

To access the Admin Panel and manage the game's content, follow these steps: 

Navigate to the Login Screen: Upon selecting the "Manage Questions" button from the Main Screen, you'll be directed to the Login Screen. 

Enter Your Credentials: In the designated fields, input the default login credentials: 

Login: Enter "admin" as the username. 

Password: Input "admin" as the password. 

Verification: To ensure security, check the "I am not a robot" checkbox to complete the verification process. 

Login: After entering your credentials and completing the verification, click the "Login" button to access the Admin Panel. 

Access for Non-Authorized Users 

Alternative Option: For users who are not authorized to access the Admin Panel, there is a convenient option to return to the Main Screen. Simply select this option to navigate back to the game's main menu. 

 

6. Managing Questions Screen 


Overview: 

In the Admin Panel's "Manage Questions" section, administrators are presented with several options to handle game questions efficiently. 

Available Options: 

Get Question: 

This option retrieves questions from the database. 

Update Question: 

Admins can update selected questions. Note that the question ID remains unchanged. This option populates the bottom fields with the selected question, allowing admins to edit and update it in the database. 

Delete Question: 

Admins can delete selected questions from the database. 

Return to Main Menu: 

Selecting this option logs out the admin and returns them to the Main Screen. 

Add New Question: 

To add a new question to the game's database, admins can use this option. Upon selection, admins are prompted to enter the question and four possible answers, including the correct one. The Question ID is generated automatically to prevent database issues. After entering all the necessary information, admins can press the "Add New Question" button to finalize the process. 

Note: 

These options provide admins with a comprehensive toolkit to manage the game's questions effectively, ensuring an engaging and up-to-date gaming experience for players. 

 

7. Exiting the Game 


Overview: 

Exiting the game is a straightforward process that can be accomplished by closing the game window. 

Procedure: 

Close the Window: 

To exit the game, simply close the game window by clicking the close button (usually denoted by an "X" symbol) located at the top-right corner of the window. 

Note: 

Closing the game window terminates the game session and returns the user to their desktop or previous application, allowing for a seamless transition out of the game environment. 


8. DATABASE QUESTIONS 


THIS CAN BE COPY PASTED INTO THE DATABASE 

INSERT INTO dbo.Trivia_Table(QuestionID, Question, AnswerOne, AnswerTwo, AnswerThree, AnswerFour, CorrectAnswer, DeleteQuestion) 

VALUES  

(001, 'When Minecraft was Released', 'September 10, 2020', 'August 15, 2005', 'June 26, 1987', 'November 18, 2011', 'November 18, 2011', '0'), 

(002, 'When Roblox was Released', 'October 18, 1989', 'August 20, 2013', 'August 27, 1965', 'September 1, 2006', 'September 1, 2006', '0'), 

(003, 'When Super Mario Bros. was Released', 'September 14, 2001', 'July 19, 2002', 'September 13, 1985', 'March 14, 1983', 'September 13, 1985', '0'), 

(004, 'When Sonic the Hedgehog was Released', 'December 23, 1998', 'June 23, 1991', 'February 12, 2020', 'June 26, 1987', 'June 23, 1991', '0'), 

(005, 'When Tetris was Released', 'June 6, 1984', 'November 1, 1989', 'January 1, 1988', 'November 1, 1987', 'June 6, 1984', '0'), 

(006, 'How many provinces and territories does Canada have?', '10 provinces and 3 territories', '25 provinces and 0 territories', '3 provinces and 10 territories', 'Canada does not have any provinces and territories, it is one big place', '10 provinces and 3 territories', '0'), 

(007, 'How many states does the USA have?', '52 states', '50 states', '1 state', '43 states', '50 states', '0'), 

(008, 'How many continents are there?', '6 continents', '5 continents', '8 continents', '7 continents', '7 continents', '0'), 

(009, 'What continent does not have any countries?', 'Antarctica', 'North Pole', 'North America', 'Australia', 'Antarctica', '0'), 

(010, 'What continent is occupied by only one country?', 'Alaska', 'Africa', 'Australia', 'Greenland', 'Australia', '0'), 

(011, 'How many planets are there in the solar system?', '9', '0', '8', '5', '8 planets', '0'), 

(012, 'What space object is located in the center of the solar system?', 'The Black Hole', 'The Star', 'The Planet', 'The Pulsar', 'The Star', '0'), 

(013, 'What is the name of the planet that has not been considered a planet since 2006?', 'Moon', 'Io', 'Pluto', 'Mercury', 'Pluto', '0'), 

(014, 'What is the last planet in the solar system?', 'Pluto', 'Neptune', 'Earth', 'Enceladus', 'Neptune', '0'), 

(015, 'What is the name of the galaxy we live in?', 'The Solar System', 'The Milky Way', 'The Universe', 'TON 618', 'The Milky Way', '0'), 

(016, 'Who invented git?', 'Linus Torvalds', 'Bill Gates', 'Ernest Git', 'Nikola Tesla', 'Linus Torvalds', '0'), 

(017, 'What is not a type of an API?', 'Open', 'Partner', 'Private', 'Close', 'Close', '0'), 

(018, 'What is not a Postman method?', 'GET', 'DELETE', 'POST', 'JOIN', 'JOIN', '0'), 

(019, 'What is not a programming language?', 'CSS', 'Ruby', 'ActionScript', 'C', 'CSS', '0'), 

(020, 'What is CI/CD?', 'Cable Installation/Computer Deactivation', 'Continuous integration/Continuous delivery', 'Client Interaction/Code Destruction', 'Computer Interface/Computer Design', 'continuous integration and continuous delivery', '0'); 

 

 

 
