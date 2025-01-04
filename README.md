# Currency Exchange API Mock Test

This project includes unit tests and integration tests for testing a mock API that simulates currency exchange rates. The mock API is simulated using [Mockoon](https://mockoon.com/), and the tests use [xUnit](https://xunit.net/) for assertions and [SpecFlow](https://specflow.org/) for behavior-driven development (BDD).

## Requirements

- [Mockoon](https://mockoon.com/) to simulate the API
- .NET 8.0
- Visual Studio (or another C# development environment)
- xUnit for unit testing
- Moq for mocking dependencies
- HttpClient for making API requests in integration tests

## Project Structure

The project consists of the following test categories:

- **Unit Tests**: These tests focus on individual methods in the application, such as `LogDecision` and `SendNotification`. They are fast, isolated, and test small parts of the system.
- **Integration Tests**: These tests validate the interaction with the mock API (simulated with Mockoon) and test the integration of multiple components, such as making API calls and processing responses.
- **Acceptance tests**: These tests verify that the API responds correctly to various currency exchange requests. They simulate real-world usage by checking if the mock API correctly handles different currencies, returns valid exchange rates, and provides appropriate error messages for invalid requests.

## Tests Overview

### Unit Tests

Unit tests are found in the `FinancialUnitTests` class. The tests focus on verifying that individual methods work as expected, including handling edge cases and exceptions.

#### Example Unit Tests:
1. **LogDecision_ShouldLogMessage_WhenMessageIsValid**:
   - Verifies that a valid decision message is logged without errors.

### Integration Tests

Integration tests are located in the FinancialIntegrationTests class. These tests simulate real interactions with the mock API, checking if the system correctly communicates with the external mock service. These tests ensure that data flows properly between components when integrating with the mock API.

### Example Integration Tests:
1. **GetExchangeRate_ShouldReturnValidRate_WhenValidCurrencyIsProvided**:
   - Verifies that the API correctly returns the exchange rate for a valid currency (e.g., USD).

### Acceptance Tests
Acceptance tests are designed to simulate user interactions with the mock API and verify its overall behavior. They ensure that the API behaves correctly in real-world scenarios, particularly when handling requests for currency exchange rates.

### Example Acceptance Tests:
1. **GetExchangeRate_ShouldReturnValidExchangeRate_WhenValidCurrencyIsRequested**:
   - Ensures that the mock API correctly handles valid currency requests and returns the appropriate exchange rate.


## How to Set Up Mockoon for the Mock API
Mockoon is used to simulate the currency exchange API. Below are the steps to set up and start Mockoon:

### Download and Install Mockoon:

- Visit Mockoon's official website and download the latest version for your operating system.
- Import the API definition provided in the mockoon-api.json file into Mockoon.
- Launch Mockoon and start the mock API on port 3001 to simulate the exchange rate API.
- Once the mock API is running, you can verify it by making a request to http://localhost:3001/api/exchange-rate/USD. This should return the exchange rate data.
