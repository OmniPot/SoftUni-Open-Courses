import os
import csv
import iso8601

filename = input()

# filename = 'sales.txt'

if not filename or not os.path.exists(filename):
    print('INVALID INPUT')
    exit()

city_sales = {}

with open(filename, encoding='utf-8') as file:
    reader = csv.reader(file)
    content = list(reader)

    if not content:
        print('INVALID INPUT')
        exit()

    for line in content:
        if not line:
            continue

        if len(line) != 5:
            print('INVALID INPUT')
            exit()

        try:
            item_code = line[0]
            country_code = line[1]
            city = line[2]
            date = iso8601.parse_date(line[3])
            price = float(line[4])

            if city not in city_sales:
                city_sales[city] = {item_code}
            else:
                city_sales[city].add(item_code)

        except Exception as e:
            print(e)
            print('INVALID INPUT')
            exit()

uniques_count = 0
for city_name, items in sorted(city_sales.items()):
    uniques = []
    for item in items:
        unique = True
        for city_name2, items2 in city_sales.items():
            if city_name != city_name2 and item in items2:
                unique = False

        if unique:
            uniques.append(item)

    if uniques:
        uniques_count += len(uniques)
        print('{0},{1}'.format(city_name, ','.join(sorted(uniques))))

if not uniques_count:
    print('NO UNIQUE SALES')
