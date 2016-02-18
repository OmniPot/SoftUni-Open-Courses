import math

paper_size = input()
height = input()
width = input()
depth = input()

if not paper_size or not height or not width or not depth:
    print('INVALID INPUT')
    exit()

try:
    paper_size = float(paper_size)

    if not paper_size or not height or not width or not depth:
        print('INVALID INPUT')
        exit()

    height = float(height)
    width = float(width)
    depth = float(depth)

    sideA_surface = width * height * 2
    sideB_surface = height * depth * 2
    base_surface = width * depth * 2

    whole_surface = sideA_surface + sideB_surface + base_surface
    print(math.ceil((whole_surface / paper_size) * 1.098))

except Exception as e:
    print(e)
    print('INVALID INPUT')
    exit()
