# TenForce-ChiragRajpara
TenForce Test

Exercise 1
Overview

The goal of the exercise is to fix the AverageMoonGravity property on the Planet class. To do this you
may adapt and extend each part of the code as you see fit. After you have made your adjustments, all
tables produced by the code should still be functioning and be unchanged.

Please motivate the changes you introduce in the domain model and in the API interface.

Preparing your environment
• Clone the git repository
• Create a new branch you will use to do your intermediate commits to (name: "TenForce
yourinitials")

The code
• Enrich your code with comments and error handling. Also keep the users informed by showing
the different steps the code is in, during execution. ("Loading data...", "Writing data...", ...) • Make
functional complete commits to your branch "TenForce-yourinitials"
• You can use nuget packages and open source libraries to your liking. 


Exercise 2
Propose in less than 5 lines an alternative solution to this problem (if possible) and explain a benefit and
a drawback versus the solution that you have chosen. 


======================================
Reply from Chirag:
Exercise 1: 
I update the code as per the latest copy for calculating gravity for the moon and calculating the average gravity for the planet.
Also Adding "App Processing Start", "Loading Data", "Writing Data" and "App Process completed" state messages in the Title of the Console.

Exercise 2:
Issue: Current Solutions is taking a long time to process:

Root cause: 
- I found that in the app first, we get All Planet data, and under we are getting each planet's moon data through calling HttpClient call, Which is taking more time.
- Also, we are getting moons data multiple times in the same console, which is wrong also.

Solutions:
- First, we need to get all planet data as below.
GET: https://api.le-systeme-solaire.net/rest/bodies?data=id,semiMajorAxis,moons,moon,rel,gravity,mass,massValue,massExponent,meanRadius,isPlanet&filter[]=isPlanet,eq,true
- Then we need to get all moon data as below.
GET: https://api.le-systeme-solaire.net/rest/bodies?data=id,semiMajorAxis,moons,moon,rel,gravity,mass,massValue,massExponent,meanRadius,isPlanet&filter[]=isPlanet,eq,false

- Then Store both responses in the list.
- Then do calculations and write them in the table.

benefit:
- Application Outbound calls will reduce, application processing time and memory will reduce.

drawback:
- 