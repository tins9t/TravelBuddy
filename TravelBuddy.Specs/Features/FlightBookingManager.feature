Feature: FlightBookingManager

@validBookings
Scenario: Calculate total price for valid booking
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

@invalidBookings
Scenario: Calculate total price for invalid booking
	Given the amount of available seats are <availableSeats>
	And the travel class is <travelClass>
	And the meal is <meal>
	When the total price is calculated an error is thrown
	
Examples: 
  | availableSeats | travelClass | meal | 
  | 30             | 0           | 1    | 
  | 3              | 3           | 0    | 