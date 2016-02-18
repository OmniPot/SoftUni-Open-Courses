from math import ceil

FLASK_COVERAGE = 1.76

width = float(input())
height = float(input())

flasks_needed = ceil((width * height) / FLASK_COVERAGE)

print(flasks_needed)
