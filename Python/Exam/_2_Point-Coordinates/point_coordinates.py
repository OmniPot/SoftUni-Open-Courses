filename = input()

if not filename:
    print('INVALID INPUT')
else:
    x = 0.0
    y = 0.0
    empty = True

    with open(filename, encoding='utf-8') as file:
        for line in file.readlines():
            if not line.strip():
                continue

            empty = False
            parts = line.strip().split(' ')

            if len(parts) != 2:
                print('INVALID INPUT')
                exit()

            direction = parts[0]
            try:
                speed = float(parts[1])
            except Exception as e:
                print('INVALID INPUT')
                exit()

            if direction == 'right':
                x += float(speed)
            elif direction == 'left':
                x -= float(speed)
            elif direction == 'up':
                y += float(speed)
            elif direction == 'down':
                y -= float(speed)
            else:
                print('INVALID INPUT')
                exit()

    if empty:
        print('INVALID INPUT')
        exit()

    print('X {0:.3f}'.format(x))
    print('Y {0:.3f}'.format(y))
