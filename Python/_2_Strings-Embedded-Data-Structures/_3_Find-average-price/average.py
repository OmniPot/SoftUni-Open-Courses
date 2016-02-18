import re

STOP_PHRASE = 'stop'
MIN_PRICES_LEN = 4

price_list = []
price = input('Price: ')

# Input all the prices
while price != STOP_PHRASE:
    if price is not None and price.isalnum():
        price_list.append(float(price))
    else:
        print("Invalid price input...")
    price = input('Price: ')

# Calculate average price
if len(price_list) >= MIN_PRICES_LEN:
    price_list.remove(min(price_list))
    price_list.remove(max(price_list))
    average_price = sum(price_list) / float(len(price_list))

    output = 'Average price: ' + str(round(average_price, 2))
else:
    output = 'Not enough data to find average.'

print(output)
