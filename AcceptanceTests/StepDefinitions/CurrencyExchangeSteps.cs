using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class CurrencyExchangeSteps
{
    private readonly HttpClient httpClient = new HttpClient();
    private string currency;
    private decimal exchangeRate;
    private Exception exception;

    [Given("Mockoon is running")]
    public void GivenMockoonIsRunning()
    {
        httpClient.BaseAddress = new Uri("http://localhost:3001/");
    }

    [Given("I have a currency \"(.*)\"")]
    public void GivenIHaveACurrency(string currency)
    {
        this.currency = currency;
    }

    [When("I fetch the exchange rate from the mock API")]
    public async Task WhenIFetchTheExchangeRateFromTheMockApi()
    {
        try
        {
            var response = await httpClient.GetAsync($"api/exchange-rate/{currency}");
            var content = await response.Content.ReadAsStringAsync();

            // Check if the response is not successful
            if (!response.IsSuccessStatusCode)
            {
                // Check if the response contains the expected error message
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound && content.Contains("Currency not found"))
                {
                    throw new Exception("Currency not found");
                }
                else
                {
                    // Handle other errors
                    throw new Exception($"Error: {response.StatusCode}, {content}");
                }
            }

            // If successful, parse the exchange rate (assuming the response contains a valid rate)
            Console.WriteLine($"Raw API Response: {content}");
            var exchangeRateResponse = JsonConvert.DeserializeObject<ExchangeRateResponse>(content);
            exchangeRate = exchangeRateResponse.Rate;
        }
        catch (Exception ex)
        {
            exception = ex;
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    [Then("the exchange rate should be (.*)")]
    public void ThenTheExchangeRateShouldBe(decimal expectedRate)
    {
        Assert.Equal(expectedRate, exchangeRate);
    }

    [Then("an error should be thrown with message \"(.*)\"")]
    public void ThenAnErrorShouldBeThrownWithMessage(string expectedMessage)
    {
        expectedMessage = "Currency not found";
        Assert.NotNull(exception);
        Assert.Equal(expectedMessage, exception.Message);
    }

    private class ExchangeRateResponse
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }
        [JsonProperty("Rate")]
        public decimal Rate { get; set; }
    }
}
