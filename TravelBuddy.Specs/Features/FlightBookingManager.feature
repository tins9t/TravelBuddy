Feature: FlightBookingManager

# As a customer I want to be able to see the total price for my selected travel class and meal, 
# so that I can make an informed decision about my booking.	
		
@validBookings
Scenario Outline: Calculate total price for valid booking
	Given the amount of available seats are <availableSeats>
	And the travel class is <travelClass>
	And the meal is <meal>
	When the total price is calculated
	Then the result should be <result>
	
# Travel class:	1: First, 2: Business, 3: Economy
# Meal: 1: None, 2: Standard, 3: Vegetarian
	
Examples: 
  | availableSeats | travelClass | meal | result  |
  | 30             | 3           | 1    | 1500    |
  | 3              | 2           | 2    | 2562.50 |
  | 7              | 1           | 3    | 3530.50 |
  | 15             | 3           | 1    | 1575    |

# As a customer I might be able to forget to choose an option for travel class or meal,
# so the system should be able to handle this case.

@invalidBookings
Scenario Outline: Calculate total price for invalid booking
	Given the amount of available seats are <availableSeats>
	And the travel class is <travelClass>
	And the meal is <meal>
	When the total price is calculated an error is thrown
	
Examples: 
  | availableSeats | travelClass | meal | 
  | 30             | 0           | 1    | 
  | 3              | 3           | 0    | 