import csv

item_key = input()
sales_filename = input()

item_sales = {}

with open(sales_filename, 'r', encoding='utf-8') as file:
    reader = csv.reader(file)

    if reader:
        for line in reader:
            if line[0] == item_key:
                item_sales[line[2]] = float(line[4])

        print(min(item_sales, key=item_sales.get))
