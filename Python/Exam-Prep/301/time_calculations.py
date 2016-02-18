import csv

distances_filename = input()

total_time = 0

with open(distances_filename, 'r', encoding='utf-8') as file:
    reader = csv.reader(file)

    if reader:
        for line in reader:
            if len(line) is not 3 or not [num for num in line if num.isdigit()]:
                print('INVALID INPUT')
                exit()

            total_time += (int(line[1]) - int(line[0]) + 1) / int(line[2])

    else:
        print('INVALID INPUT')

print('{0:.2f}'.format(total_time))
