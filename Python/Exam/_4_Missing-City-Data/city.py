import os
import csv
import iso8601
import collections

filename = input()

if not filename or not os.path.exists(filename):
    print('INVALID INPUT')
    exit()

cities = set()
dates = {}

with open(filename, encoding='utf-8') as file:
    reader = csv.reader(file)
    for line in reader:
        if not line:
            continue

        if len(line) != 3:
            print('INVALID INPUT')
            exit()

        try:
            date = iso8601.parse_date(line[0])
            city = line[1]
            temp = float(line[2])

            if date not in dates:
                dates[date] = [city]
            else:
                dates[date].append(city)

            if city not in cities:
                cities.add(city)
        except Exception as e:
            print('INVALID INPUT')
            exit()

    if not dates:
        print('INVALID INPUT')
        exit()

    dates = collections.OrderedDict(sorted(dates.items()))
    missing = []
    for date, date_cities in dates.items():
        cities_with_missing_data = sorted([city for city in cities if city not in date_cities])

        if cities_with_missing_data:
            missing.append('{},{}'.format(date.strftime('%Y-%m-%d'), ','.join(cities_with_missing_data)))

    if not missing:
        print('ALL DATA AVAILABLE')
        exit()

    for m in missing:
        print(m)
