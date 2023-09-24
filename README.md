# NinetyOneCodingExercise
For this project I first had to look at the formatting for the spreadsheet and how I could best convert that to a data type that I can manipulate within code. By opening the CSV file in a text editor, I found that the data was separated by two things, new lines for each row, and a comma to then separate each value within that row. As such I settled on a List or string arrays. To get the raw file into this form I read each line of the file and then split up each line based on where there was a comma.

I then needed to work out how best to get the file so I allowed for it to either be provided as an argument or if no arguments were provided then it will ask the user to write the directory of the file they seek to have parsed. Next I pass this to the function that will convert the file into a 2D array. I will then iterate through the first row of the 2D array to try and find which index the score is in. While this isn't necessary as we know where the score is, it does help to provide better expandability as we can then search for by any given field. This function is part of a sheet class. This class can also be expanded with classes like minimum or equals to in future.

Once we have the row we need to look at we can then iterate through all elements and find the largest. Given that there can be multiple elements of the same size we will need to have an array to store the current largest elements. If the current element is larger than the recorded largest score it will reset the aforementioned array and make the variable equal to a new array containing only the current element being looked at. If the current element is the same as the largest recorded score then we simply add the current element to the array we are using to store largest elements. After we've iterated through the entire array we will then need to output this information to the user. To do this we simply sort the array alphabetically and then iterate through it outputting each element. Finally, the score is output.

SOme potential ideas I had to better improve the program were adding a better input reading system. Given that the csv fields could contain any number of things including a ',' I need to find a way to distinguish between the comman used to seperate entries and those that are within an entry.

# How to run the program
To run this you can either run the program with the file you wish to see parsed or simply run it an write the path for the file you wish to parsed. A way to do this would be that instead of using split we iterate through each character when reading a line and check for what character comes first. If a comman has not had a special character before hand it will be treated as a seperator of entries however if the comman is within speach marks it is part of a entry and so will be ignored. This character by char acter approach can also allow for special characters to be used or even certain kinds of conditional formatting.

# The program running

Using the test data provided the output is:
![Screenshot 2023-09-22 123206](https://github.com/CrazySneeze/NinetyOneCodingExercise/assets/72107671/0dc8856e-cb81-4f89-b2b4-89b01244f437)

Using some additional data I have placed in the sheet as seen here:
![image](https://github.com/CrazySneeze/NinetyOneCodingExercise/assets/72107671/790cc302-ee8d-4765-a9ac-a42351e858ab)

The output result is:
![image](https://github.com/CrazySneeze/NinetyOneCodingExercise/assets/72107671/6d9db1d1-5c72-4acc-a3b4-91e505817099)

