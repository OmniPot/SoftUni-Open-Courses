from datetime import datetime
import csv
import pytz

FILENAME = "sales.csv"
time_zone = pytz.timezone('Europe/Sofia')


def find_most_sales_day(filename):
    sales_per_date = {}
    with open(filename, 'r') as file:
        contents = csv.reader(file)
        for i, line in enumerate(contents):
            if len(line) != 2:
                print('Invalid arguments at line {}'.format(i))
                continue

            s_date = time_zone.localize(datetime.strptime(line[0], '%Y-%m-%d %H:%M:%S'))
            s_value = float(line[1])
            formatted = s_date.strftime('%Y-%m-%d')
            if formatted not in sales_per_date:
                sales_per_date[formatted] = s_value
            sales_per_date[formatted] += s_value

    return sales_per_date

result = find_most_sales_day(FILENAME)
for s_date, s_value in result.items():
    if s_value == max(result.values()):
        print('Date with most sales {0:.2f} is \'{1}\''.format(s_value, s_date))
