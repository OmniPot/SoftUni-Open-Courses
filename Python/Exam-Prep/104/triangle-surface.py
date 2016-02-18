import math

a = input()
b = input()
c = input()

if not a or not b or not c:
    print('INVALID INPUT')
else:
    try:
        a = float(a)
        b = float(b)
        c = float(c)

        p = (a + b + c) / 2
        surface = math.sqrt(p * (p - a) * (p - b) * (p - c))

        print(round(surface, 2))
    except ValueError:
        print('INVALID INPUT')
