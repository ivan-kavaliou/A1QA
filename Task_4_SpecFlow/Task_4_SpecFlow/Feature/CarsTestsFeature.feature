Feature: CarsTestsFeature
	
@Step_1
Scenario: Compare cars
	Given User navigate to home page
	When Navigate to Buy and Review a Car
		And Set random car with name <"FirstCar"> 
		And Click Search button
		And Click Model details link
		And Click first car in trim car bar with name <"FirstCar"> 
		And Save Car options with name <"FirstCar"> 

	When Navigate to Buy and Review a Car
		And Set random car with name <"SecondCar"> 
		And Click Search button
		And Click Model details link
		And Click first car in trim car bar with name <"SecondCar"> 
		And Save Car options with name <"SecondCar"> 


		When Navigate to Buy and Review a Car
		And Set random car with name <"ThirdCar"> 
		And Click Search button
		And Click Model details link
		And Click first car in trim car bar with name <"ThirdCar"> 
		And Save Car options with name <"ThirdCar"> 

	When Click compare checkbox
		And Click Compare now button
		And Add <"FirstCar"> to compare
		And Add <"SecondCar"> to compare


	Then Is  selected cars options are correct


