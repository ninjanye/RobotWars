RobotWars
=========

This project is simply an interview task I was asked to complete.  Although a simple request, I found it was a good excercise so thought I'd share my solution.

The Brief
=========

Write the following in c# showing off your TDD and coding best practices.
The output can be in whatever format you want, a console app will suffice.
Use either NUnit or MSTest. Use any other frameworks you want.

*Requirements*
A fleet of hand built robots are due to engage in battle for the annual “Robot Wars” competition. Each robot will be placed within a rectangular battle arena and will navigate their way around the arena using a built in computer system.

A robot’s location and heading is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The arena is divided up into a grid to simplify navigation. An example position might be 0, 0, N which means the robot is in the bottom left corner and facing North.

In order to control a robot, the competition organisers have provided a console for sending a simple string of letters to the on-board navigation system. The possible letters are ‘L’, ‘R’ and ‘M’. ‘L’ and ‘R’ make the rover spin 90 degrees to the left or right respectively without moving from its current spot while ‘M’ means move forward one grid point and maintain the same heading. Assume that the square directly North from (x, y) is (x, y+1).

*INPUT:*
The first line of input is the upper-right coordinates of the arena, the lower-left coordinates are assumed to be (0, 0).

The rest of the input is information pertaining to the robots that have been deployed. Each robot has two lines of input - the first gives the robot’s position and the second is a series of instructions telling the robot how to move within the arena.

The position is made up of two integers and a letter separated by spaces, corresponding to the x and y coordinates and the robot’s orientation. Each robot will finish moving sequentially, which means that the second robot won’t start to move until the first one has finished moving.

*OUTPUT:*
The output for each robot should be its final coordinates and heading.


*Acceptance criteria*

In order to confirm your program is working correctly, we have provided some test input and output for your use. Implement these details however you consider most appropriate.

*TEST INPUT:*

5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

*EXPECTED OUTPUT:*

1 3 N
5 1 E
