# Selenium-NextBasket-Assessment
This repo contains BDD tests written in Selenium(C#, SpecFlow, NUnit) for Next basket application.

## Prerequisites

- .NET Core SDK (version 6 or higher)
- Visual Studio or Visual Studio Code

## Installation

1. Clone the Repository: Clone this repository to your local machine using:

   git clone <repository_url>


## Run Tests
To run tests in interactive mode through the test runner, use the following steps:

Open Test Explorer: In Visual Studio, navigate to Test > Test Explorer.

Run Tests: Select the tests you want to run and click the Run button.



## Patterns
Despite what Cypress says, Page Object Model is used because it improves code readability.
- POM pattern is used and every page at(https://teststoreforsouthafri.nextbasket.shop/) is represented as a single class  
- pages Folder contain all classes
- Feature Folders contains test scenarios  written in Gerkin language
- Data is fed from feature file using tables
- StepDefination folder Contains the implementation of the steps defined in the feature file
- BBD-TestCases text files contains the testcases related to cart 
- BUGS text file contain bugs find in application
- Video folder contains videos of Test running.



## Authur
    Harris Ahmed





