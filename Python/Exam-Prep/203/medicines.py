import csv

width = input()
height = input()
depth = input()

medicines_filename = input()

with open(medicines_filename, 'r', encoding='utf-8') as file:
    reader = csv.reader(file)

    for line in reader:
        print(line)
