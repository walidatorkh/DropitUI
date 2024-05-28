# DropitUI
site https://shop.polymer-project.org to test UI automation testing skills

Added scenarios:
1. Positive scenario:
- Go to https://shop.polymer-project.org
- From the “Men’s Outerwear” section add to the cart the following item:
- Name of item: YouTube Ultimate Hooded Sweatshirt , Size: XL ,
Quantity: 3
- From the “Ladies T-Shirts” section add to the cart the following item:
- Name of item: MTV Ladies Yellow T-Shirt , Size: S , Quantity: 2
- Click on the cart icon on the top right hand corner of the page
- Go to the “Checkout” section by clicking on the “CHECKOUT” button.
- Fill in all the information in the form as you like ( as long as it is valid)
- Click on “PLACE ORDER”
- Click on “FINISH”
2. Negative test scenario:
- Go to https://shop.polymer-project.org
- Add 2 different items to the cart as you choose, one item from each.
- Click on the cart icon on the top right hand corner of the page
- Go to the “Checkout” section by clicking on the “CHECKOUT” button.
- In the Email field add a non-valid input.
- In the Card Number field add a non-valid input.
- Verify that the user cannot place the order.

- Next request can't be tested due not exist validation for non-valid input for enail field:
   "After adding a non-valid input to a field, a verification is needed to make sure that
the right error message is presented to the user (for the email field, for example,
the message “Invalid Email” should be presented to the user under the field)." 


