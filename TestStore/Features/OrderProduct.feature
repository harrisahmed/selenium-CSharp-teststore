Feature: Order first in-stock non-promo product

  Scenario: Order the first in-stock non-promo product
    Given I navigate to the home page
    When I clicked on Category A
    And I filter out in stock products.
    And I buy the first in-stock non-promo product
    Then the product should be successfully added to the cart
    When I proceed to checkout.
    And I chose shoping as a guest
        | field      | value              |
        | Email      | test@gmail.com     |
    
    And I enter shipping information
       | field        | value              |
       | First Name   | John               |
       | Sur Name     | Doe                |
       | Phone        | 12345              |
       | City         | Alberton           |
       | Country      | South Africa       |
       | Postal       | 5400               |
       | Adresss      | Main Africa        |
       | Additional   | Handle with care   |

   And I confirm the order
   Then the order should be successfully placed

   Scenario: Verify 50 % label is visible
    Given I navigate to the home page
    Then Verify 50 percent label is visible on product


