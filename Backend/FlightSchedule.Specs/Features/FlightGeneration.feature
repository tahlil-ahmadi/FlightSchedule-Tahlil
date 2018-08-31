Feature: FlightGeneration
	In order to generate my flights easily & time-efficient
	As a agency manager
	I want to be able to generate flights in batch from schedule

@api 
Scenario: Generate flights from weekly flight plan
	Given I have reserved a charter flight from airline with following information
	| Aircraft    | FlightNo | Origin | Destination | StartReserveDate | EndReserveDate |
	| Airbus-W350 | WS-2040  | IKA    | FRA         | 2018-03-17       | 2018-04-01 |
	And I have entered the following weekly flight schedule
	 | Day       | DepartTime |
	 | Monday    | 08:00      |
	 | Wednesday | 17:00      |
	 When I press generate
	 Then The following flights should be generated
	 | DepartDate | Aircraft    | FlightNo | Origin | Destination |
	 | 2018-03-19 | Airbus-W350 | WS-2040  | IKA    | FRA         |
	 | 2018-03-21 | Airbus-W350 | WS-2040  | IKA    | FRA         |
	 | 2018-03-26 | Airbus-W350 | WS-2040  | IKA    | FRA         |
	 | 2018-03-28 | Airbus-W350 | WS-2040  | IKA    | FRA         |