import csv
import os
import math

litres = input()
filename = input()

if not litres or not filename or not os.path.exists(filename):
    print('INVALID INPUT')
    exit()

suitable_containers = {}

with open(filename, encoding='utf-8') as file:
    reader = csv.reader(file)

    for line in reader:
        if not line:
            continue

        if len(line) != 3 or not line[0]:
            print('INVALID INPUT')
            exit()

        try:
            litres = float(litres)
            if litres <= 0:
                print('INVALID INPUT')
                exit()
            container_name = line[0]

            container_radius = float(line[1]) / 10
            container_height = float(line[2]) / 10
            container_volume = math.pi * pow(container_radius, 2) * container_height

            if container_volume - litres > 0:
                suitable_containers[container_name] = container_volume - litres

        except Exception as e:
            print('INVALID INPUT')
            exit()

    if not suitable_containers:
        print('NO SUITABLE CONTAINER')
        exit()

    best_container = min(suitable_containers, key=suitable_containers.get)
    print(best_container)
