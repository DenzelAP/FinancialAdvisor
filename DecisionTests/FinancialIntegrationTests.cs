using FinancialAdvisor;
using System.Text.Json;
using System.Net;

namespace FinancialTests
{
    public class FinancialIntegrationTests
    {
        // Declare private variables for HttpClient and MockInformationProvider
        private readonly HttpClient _httpClient;
        private readonly MockInformationProvider _mockInformationProvider;

        // Constructor: Initializes HttpClient for making API requests and sets up MockInformationProvider
        public FinancialIntegrationTests()
        {
            // Setup HttpClient for Mockoon Server
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:3001") // The URL of the Mockoon server running locally
            };

            // Initialize MockInformationProvider (used for mocking exchange rate data)
            _mockInformationProvider = new MockInformationProvider();
        }

        [Fact]
        public async Task GetExchangeRate_ShouldReturnValidRate_WhenValidCurrencyIsProvided()
        {
            // Arrange
            string currency = "USD"; // The currency to request
            decimal expectedRate = 1.1m; // The expected exchange rate for USD

            // Act: Send a GET request to the API with the specified currency
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/exchange-rate/{currency}");
            response.EnsureSuccessStatusCode(); // Ensures that the status code is 2xx (success)

            // Read the response content as a string
            string responseContent = await response.Content.ReadAsStringAsync();

            // Log the response content to the console for debugging
            Console.WriteLine($"Response Content: {responseContent}");

            // Deserialize the response JSON into an ExchangeRateResponse object
            var responseData = JsonSerializer.Deserialize<ExchangeRateResponse>(responseContent);

            // Assert
            Assert.NotNull(responseData); // Ensure that response data is not null
            Assert.Equal("USD", responseData.Currency); // Check that the currency in the response matches the expected value
            Assert.Equal(expectedRate, responseData.Rate); // Check that the exchange rate in the response matches the expected value
        }

        [Fact]
        public async Task GetExchangeRate_ShouldReturnError_WhenCurrencyIsInvalid()
        {
            // Arrange
            string currency = "INVALID"; // The currency to request

            // Act: Send a GET request to the API with the invalid currency
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/exchange-rate/{currency}");
            string errorMessage = await response.Content.ReadAsStringAsync(); // Read the error message from the response

            // Log the error response for debugging purposes
            Console.WriteLine($"Response Content: {errorMessage}");

            // Assert
            Assert.False(response.IsSuccessStatusCode); // Ensure that the response status code is not in the success range
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode); // Verify that the status code is BadRequest (400)
            Assert.Contains("Currency not found", errorMessage); // Check that the error message contains the expected text
        }

        // Private class representing the structure of the exchange rate response from the API
        private class ExchangeRateResponse
        {
            public string Currency { get; set; } // The currency code (e.g., "USD")
            public decimal Rate { get; set; } // The exchange rate for the specified currency
        }
    }
}
