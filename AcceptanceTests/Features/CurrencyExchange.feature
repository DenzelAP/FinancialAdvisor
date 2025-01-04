Feature: Currency Exchange Rates with Mockoon
  As a financial advisor
  I want to fetch exchange rates for various currencies
  So that I can provide accurate advice to my clients

  Background:
    Given Mockoon is running

  Scenario: Get valid exchange rate for USD from the mock API
    Given I have a currency "USD"
    When I fetch the exchange rate from the mock API
    Then the exchange rate should be 1.1

    Scenario: Get valid exchange rate for EUR from the mock API
    Given I have a currency "EUR"
    When I fetch the exchange rate from the mock API
    Then the exchange rate should be 1.0

    Scenario: Get valid exchange rate for GBP from the mock API
    Given I have a currency "GBP"
    When I fetch the exchange rate from the mock API
    Then the exchange rate should be 0.85

    Scenario: Get valid exchange rate for JPY from the mock API
    Given I have a currency "JPY"
    When I fetch the exchange rate from the mock API
    Then the exchange rate should be 120

    Scenario: Get valid exchange rate for CNY from the mock API
    Given I have a currency "CNY"
    When I fetch the exchange rate from the mock API
    Then the exchange rate should be 7.8

  Scenario: Invalid currency input from the mock API
    Given I have a currency "XYZ"
    When I fetch the exchange rate from the mock API
    Then an error should be thrown with message "Currency not found"
