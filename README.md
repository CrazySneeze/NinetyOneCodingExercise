# NinetyOneCodingExercise
For this project I first had to look at the formatting for the spreadsheet and how I could best convert that to a data type that I can manipulate within code. By opening the CSV file in a text editor, I found that the data was separated by two things, new lines for each row, and a comma to then separate each value within that row. As such I settled on a List or string arrays. To get the raw file into this form I read each line of the file and then split up each line based on where there was a comma.

I then needed to work out how best to get the file so I allowed for it to either be provided as an argument or if no arguments were provided then it will ask the user to write the directory of the file they seek to have parsed. Next I pass this to the function that will convert the file into a 2D array. I will then iterate through the first row of the 2D array to try and find which index the score is in. While this isn't necessary as we know where the score is, it does help to provide better expandability as we can then search for by any given field. This function is part of a sheet class. This class can also be expanded with classes like minimum or equals to in future.

Once we have the row we need to look at we can then iterate through all elements and find the largest. Given that there can be multiple elements of the same size we will need to have an array to store the current largest elements. If the current element is larger than the recorded largest score it will reset the aforementioned array and make the variable equal to a new array containing only the current element being looked at. If the current element is the same as the largest recorded score then we simply add the current element to the array we are using to store largest elements. After we've iterated through the entire array we will then need to output this information to the user. To do this we simply sort the array alphabetically and then iterate through it outputting each element. Finally, the score is output.

# How to run the program
To run this you can either run the program with the file you wish to see parsed or simply run it an write the path for the file you wish to parsed.

# The program running

![Screenshot 2023-09-22 123206](https://github.com/CrazySneeze/NinetyOneCodingExercise/assets/72107671/0dc8856e-cb81-4f89-b2b4-89b01244f437)
